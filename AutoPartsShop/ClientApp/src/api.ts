export type AuthUser = {
  id: number;
  email: string;
  isAdmin: boolean;
};

const storageKeys = {
  token: "ap_token",
  user: "ap_user",
  cart: "ap_cart_local"
};

export function getToken(): string | null {
  return localStorage.getItem(storageKeys.token);
}

export function setToken(token: string | null) {
  if (token) {
    localStorage.setItem(storageKeys.token, token);
  } else {
    localStorage.removeItem(storageKeys.token);
  }
}

export function getUser(): AuthUser | null {
  const raw = localStorage.getItem(storageKeys.user);
  if (!raw) return null;
  try {
    return JSON.parse(raw) as AuthUser;
  } catch {
    return null;
  }
}

export function setUser(user: AuthUser | null) {
  if (user) {
    localStorage.setItem(storageKeys.user, JSON.stringify(user));
  } else {
    localStorage.removeItem(storageKeys.user);
  }
}

export function logout() {
  setToken(null);
  setUser(null);
}

export type LocalCartItem = { partId: number; qty: number };

export function getLocalCart(): LocalCartItem[] {
  const raw = localStorage.getItem(storageKeys.cart);
  if (!raw) return [];
  try {
    return JSON.parse(raw) as LocalCartItem[];
  } catch {
    return [];
  }
}

export function setLocalCart(items: LocalCartItem[]) {
  localStorage.setItem(storageKeys.cart, JSON.stringify(items));
}

async function apiRequest<T>(path: string, options: RequestInit = {}): Promise<T> {
  const token = getToken();
  const headers: Record<string, string> = {
    "Content-Type": "application/json",
    ...(options.headers as Record<string, string> | undefined)
  };
  if (token) {
    headers.Authorization = `Bearer ${token}`;
  }

  const response = await fetch(path, { ...options, headers });
  if (response.status === 401 || response.status === 403) {
    logout();
  }
  if (!response.ok) {
    const text = await response.text();
    throw new Error(text || "Request failed");
  }
  if (response.status === 204) {
    return null as T;
  }
  return response.json() as Promise<T>;
}

export const api = {
  get: <T>(path: string) => apiRequest<T>(path),
  post: <T>(path: string, body: unknown) => apiRequest<T>(path, { method: "POST", body: JSON.stringify(body) }),
  put: <T>(path: string, body: unknown) => apiRequest<T>(path, { method: "PUT", body: JSON.stringify(body) }),
  del: <T>(path: string) => apiRequest<T>(path, { method: "DELETE" })
};

export async function syncLocalCartToServer() {
  const local = getLocalCart();
  if (!local.length) return;
  for (const item of local) {
    await api.post("/api/me/cart/items", { partId: item.partId, qty: item.qty });
  }
  setLocalCart([]);
}
