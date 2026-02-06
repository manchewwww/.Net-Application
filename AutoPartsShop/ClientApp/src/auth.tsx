import React, { createContext, useCallback, useContext, useMemo, useState } from "react";
import { api, AuthUser, getUser, logout as logoutStorage, setToken, setUser, syncLocalCartToServer } from "./api";

type AuthContextValue = {
  user: AuthUser | null;
  login: (email: string, password: string) => Promise<AuthUser>;
  register: (payload: { email: string; password: string; phone?: string | null; isAdmin: boolean }) => Promise<AuthUser>;
  logout: () => void;
};

const AuthContext = createContext<AuthContextValue | undefined>(undefined);

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [user, setUserState] = useState<AuthUser | null>(() => getUser());

  const login = useCallback(async (email: string, password: string) => {
    const response = await api.post<{ id: number; email: string; isAdmin: boolean; token: string }>("/api/auth/login", {
      email,
      password
    });
    const nextUser: AuthUser = { id: response.id, email: response.email, isAdmin: response.isAdmin };
    setToken(response.token);
    setUser(nextUser);
    setUserState(nextUser);
    await syncLocalCartToServer();
    return nextUser;
  }, []);

  const register = useCallback(async (payload: { email: string; password: string; phone?: string | null; isAdmin: boolean }) => {
    const response = await api.post<{ id: number; email: string; isAdmin: boolean; token: string }>("/api/auth/register", payload);
    const nextUser: AuthUser = { id: response.id, email: response.email, isAdmin: response.isAdmin };
    setToken(response.token);
    setUser(nextUser);
    setUserState(nextUser);
    await syncLocalCartToServer();
    return nextUser;
  }, []);

  const logout = useCallback(() => {
    logoutStorage();
    setUserState(null);
  }, []);

  const value = useMemo(() => ({ user, login, register, logout }), [user, login, register, logout]);

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}

export function useAuth() {
  const ctx = useContext(AuthContext);
  if (!ctx) {
    throw new Error("useAuth must be used within AuthProvider");
  }
  return ctx;
}
