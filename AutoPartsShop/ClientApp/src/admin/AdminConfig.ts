export type LookupDef = {
  endpoint: string;
  labelKey: string;
};

export type FieldDef = {
  name: string;
  type: "string" | "number" | "bool" | "datetime" | "enum" | "lookup";
  options?: keyof typeof enumOptions;
  lookup?: LookupDef;
};

export type AdminEntity = {
  key: string;
  label: string;
  endpoint: string;
  fields: FieldDef[];
};

export const enumOptions = {
  AddressType: ["SHIPPING", "BILLING"],
  DeliveryType: ["ADDRESS", "OFFICE", "LOCKER", "PICKUP_POINT"],
  OrderStatus: ["NEW", "PAID", "PACKING", "SHIPPED", "DELIVERED", "CANCELLED", "REFUNDED"],
  FitmentType: ["DIRECT_FIT", "REQUIRES_MOD", "UNIVERSAL"],
  PartNumberType: ["OEM", "EAN", "UPC", "INTERCHANGE", "MANUFACTURER"],
  PaymentStatus: ["PENDING", "AUTHORIZED", "CAPTURED", "FAILED", "REFUNDED"],
  ReturnStatus: ["REQUESTED", "APPROVED", "RECEIVED", "REJECTED", "REFUNDED"],
  ShipmentStatus: ["CREATED", "IN_TRANSIT", "DELIVERED", "LOST", "RETURNED"],
  StockMovementType: ["PURCHASE", "SALE", "RETURN", "ADJUSTMENT", "TRANSFER_IN", "TRANSFER_OUT", "RESERVE", "RELEASE"]
} as const;

export const adminEntities: AdminEntity[] = [
  {
    key: "parts",
    label: "Parts",
    endpoint: "/api/parts",
    fields: [
      { name: "Sku", type: "string" },
      { name: "BrandId", type: "lookup", lookup: { endpoint: "/api/brands", labelKey: "name" } },
      { name: "CategoryId", type: "lookup", lookup: { endpoint: "/api/categories", labelKey: "name" } },
      { name: "Name", type: "string" },
      { name: "Description", type: "string" },
      { name: "IsActive", type: "bool" },
      { name: "WeightKg", type: "number" }
    ]
  },
  {
    key: "categories",
    label: "Categories",
    endpoint: "/api/categories",
    fields: [
      { name: "ParentCategoryId", type: "lookup", lookup: { endpoint: "/api/categories", labelKey: "name" } },
      { name: "Name", type: "string" },
      { name: "Slug", type: "string" }
    ]
  },
  {
    key: "brands",
    label: "Brands",
    endpoint: "/api/brands",
    fields: [
      { name: "Name", type: "string" },
      { name: "CountryId", type: "lookup", lookup: { endpoint: "/api/countries", labelKey: "name" } }
    ]
  },
  {
    key: "partprices",
    label: "Part Prices",
    endpoint: "/api/partprices",
    fields: [
      { name: "PartId", type: "lookup", lookup: { endpoint: "/api/parts", labelKey: "sku" } },
      { name: "PriceListId", type: "lookup", lookup: { endpoint: "/api/pricelists", labelKey: "name" } },
      { name: "ListPrice", type: "number" },
      { name: "SalePrice", type: "number" },
      { name: "ValidFrom", type: "datetime" },
      { name: "ValidTo", type: "datetime" }
    ]
  },
  {
    key: "warehouses",
    label: "Warehouses",
    endpoint: "/api/warehouses",
    fields: [
      { name: "Name", type: "string" },
      { name: "CountryId", type: "lookup", lookup: { endpoint: "/api/countries", labelKey: "name" } },
      { name: "City", type: "string" },
      { name: "Address1", type: "string" },
      { name: "Address2", type: "string" },
      { name: "Postcode", type: "string" }
    ]
  },
  {
    key: "inventory",
    label: "Inventory",
    endpoint: "/api/inventories",
    fields: [
      { name: "PartId", type: "lookup", lookup: { endpoint: "/api/parts", labelKey: "sku" } },
      { name: "WarehouseId", type: "lookup", lookup: { endpoint: "/api/warehouses", labelKey: "name" } },
      { name: "QtyOnHand", type: "number" },
      { name: "QtyReserved", type: "number" },
      { name: "ReorderPoint", type: "number" }
    ]
  },
  {
    key: "suppliers",
    label: "Suppliers",
    endpoint: "/api/suppliers",
    fields: [
      { name: "Name", type: "string" },
      { name: "CountryId", type: "lookup", lookup: { endpoint: "/api/countries", labelKey: "name" } },
      { name: "Email", type: "string" },
      { name: "Phone", type: "string" },
      { name: "IsActive", type: "bool" }
    ]
  },
  {
    key: "supplierparts",
    label: "Supplier Parts",
    endpoint: "/api/supplierparts",
    fields: [
      { name: "SupplierId", type: "lookup", lookup: { endpoint: "/api/suppliers", labelKey: "name" } },
      { name: "SupplierSku", type: "string" },
      { name: "Name", type: "string" },
      { name: "BrandName", type: "string" },
      { name: "Cost", type: "number" },
      { name: "CurrencyId", type: "lookup", lookup: { endpoint: "/api/currencies", labelKey: "code" } },
      { name: "LeadTimeDays", type: "number" },
      { name: "LastImportedAt", type: "datetime" }
    ]
  },
  {
    key: "partsupplierlinks",
    label: "Part Supplier Links",
    endpoint: "/api/partsupplierlinks",
    fields: [
      { name: "PartId", type: "lookup", lookup: { endpoint: "/api/parts", labelKey: "sku" } },
      { name: "SupplierPartId", type: "lookup", lookup: { endpoint: "/api/supplierparts", labelKey: "supplierSku" } },
      { name: "Priority", type: "number" },
      { name: "IsPrimary", type: "bool" }
    ]
  },
  {
    key: "partnumbers",
    label: "Part Numbers",
    endpoint: "/api/partnumbers",
    fields: [
      { name: "PartId", type: "lookup", lookup: { endpoint: "/api/parts", labelKey: "sku" } },
      { name: "Type", type: "enum", options: "PartNumberType" },
      { name: "Value", type: "string" }
    ]
  },
  {
    key: "partattributes",
    label: "Part Attributes",
    endpoint: "/api/partattributes",
    fields: [
      { name: "PartId", type: "lookup", lookup: { endpoint: "/api/parts", labelKey: "sku" } },
      { name: "Name", type: "string" },
      { name: "Value", type: "string" }
    ]
  },
  {
    key: "partimages",
    label: "Part Images",
    endpoint: "/api/partimages",
    fields: [
      { name: "PartId", type: "lookup", lookup: { endpoint: "/api/parts", labelKey: "sku" } },
      { name: "Url", type: "string" },
      { name: "SortOrder", type: "number" }
    ]
  },
  {
    key: "partfitments",
    label: "Part Fitments",
    endpoint: "/api/partfitments",
    fields: [
      { name: "PartId", type: "lookup", lookup: { endpoint: "/api/parts", labelKey: "sku" } },
      { name: "VariantId", type: "lookup", lookup: { endpoint: "/api/vehiclevariants", labelKey: "engineCode" } },
      { name: "Fitment", type: "enum", options: "FitmentType" },
      { name: "Notes", type: "string" }
    ]
  },
  {
    key: "vehiclemakes",
    label: "Vehicle Makes",
    endpoint: "/api/vehiclemakes",
    fields: [{ name: "Name", type: "string" }]
  },
  {
    key: "vehiclemodels",
    label: "Vehicle Models",
    endpoint: "/api/vehiclemodels",
    fields: [
      { name: "MakeId", type: "lookup", lookup: { endpoint: "/api/vehiclemakes", labelKey: "name" } },
      { name: "Name", type: "string" }
    ]
  },
  {
    key: "vehiclevariants",
    label: "Vehicle Variants",
    endpoint: "/api/vehiclevariants",
    fields: [
      { name: "ModelId", type: "lookup", lookup: { endpoint: "/api/vehiclemodels", labelKey: "name" } },
      { name: "YearFrom", type: "number" },
      { name: "YearTo", type: "number" },
      { name: "EngineCode", type: "string" },
      { name: "Notes", type: "string" }
    ]
  },
  {
    key: "pricelists",
    label: "Price Lists",
    endpoint: "/api/pricelists",
    fields: [
      { name: "Name", type: "string" },
      { name: "CurrencyId", type: "lookup", lookup: { endpoint: "/api/currencies", labelKey: "code" } },
      { name: "CountryId", type: "lookup", lookup: { endpoint: "/api/countries", labelKey: "name" } },
      { name: "IsActive", type: "bool" }
    ]
  },
  {
    key: "currencies",
    label: "Currencies",
    endpoint: "/api/currencies",
    fields: [
      { name: "Code", type: "string" },
      { name: "Name", type: "string" },
      { name: "Symbol", type: "string" }
    ]
  },
  {
    key: "countries",
    label: "Countries",
    endpoint: "/api/countries",
    fields: [
      { name: "Name", type: "string" },
      { name: "Code", type: "string" }
    ]
  },
  {
    key: "exchangerates",
    label: "Exchange Rates",
    endpoint: "/api/exchangerates",
    fields: [
      { name: "BaseCurrencyId", type: "lookup", lookup: { endpoint: "/api/currencies", labelKey: "code" } },
      { name: "QuoteCurrencyId", type: "lookup", lookup: { endpoint: "/api/currencies", labelKey: "code" } },
      { name: "Rate", type: "number" },
      { name: "AsOf", type: "datetime" }
    ]
  },
  {
    key: "customers",
    label: "Customers",
    endpoint: "/api/customers",
    fields: [
      { name: "Email", type: "string" },
      { name: "Phone", type: "string" },
      { name: "IsAdmin", type: "bool" },
      { name: "Password", type: "string" }
    ]
  },
  {
    key: "addresses",
    label: "Addresses",
    endpoint: "/api/addresses",
    fields: [
      { name: "CustomerId", type: "lookup", lookup: { endpoint: "/api/customers", labelKey: "email" } },
      { name: "Type", type: "enum", options: "AddressType" },
      { name: "Name", type: "string" },
      { name: "Line1", type: "string" },
      { name: "Line2", type: "string" },
      { name: "City", type: "string" },
      { name: "Region", type: "string" },
      { name: "PostalCode", type: "string" },
      { name: "CountryId", type: "lookup", lookup: { endpoint: "/api/countries", labelKey: "name" } },
      { name: "IsDefault", type: "bool" }
    ]
  },
  {
    key: "carts",
    label: "Carts",
    endpoint: "/api/carts",
    fields: [{ name: "CustomerId", type: "lookup", lookup: { endpoint: "/api/customers", labelKey: "email" } }]
  },
  {
    key: "cartitems",
    label: "Cart Items",
    endpoint: "/api/cartitems",
    fields: [
      { name: "CartId", type: "lookup", lookup: { endpoint: "/api/carts", labelKey: "id" } },
      { name: "PartId", type: "lookup", lookup: { endpoint: "/api/parts", labelKey: "sku" } },
      { name: "Qty", type: "number" }
    ]
  },
  {
    key: "orders",
    label: "Orders",
    endpoint: "/api/orders",
    fields: [
      { name: "OrderNumber", type: "string" },
      { name: "CustomerId", type: "lookup", lookup: { endpoint: "/api/customers", labelKey: "email" } },
      { name: "Status", type: "enum", options: "OrderStatus" },
      { name: "CurrencyId", type: "lookup", lookup: { endpoint: "/api/currencies", labelKey: "code" } },
      { name: "Subtotal", type: "number" },
      { name: "ShippingCost", type: "number" },
      { name: "DiscountTotal", type: "number" },
      { name: "TaxTotal", type: "number" },
      { name: "GrandTotal", type: "number" },
      { name: "ShippingProvider", type: "string" },
      { name: "DeliveryType", type: "enum", options: "DeliveryType" },
      { name: "ShippingName", type: "string" },
      { name: "ShippingPhone", type: "string" },
      { name: "ShippingCountryId", type: "lookup", lookup: { endpoint: "/api/countries", labelKey: "name" } },
      { name: "ShippingCity", type: "string" },
      { name: "ShippingAddress1", type: "string" },
      { name: "ShippingAddress2", type: "string" },
      { name: "ShippingPostalCode", type: "string" },
      { name: "ProviderLocationId", type: "string" },
      { name: "ProviderLocationName", type: "string" },
      { name: "BillingAddressSnapshot", type: "string" }
    ]
  },
  {
    key: "orderitems",
    label: "Order Items",
    endpoint: "/api/orderitems",
    fields: [
      { name: "OrderId", type: "lookup", lookup: { endpoint: "/api/orders", labelKey: "orderNumber" } },
      { name: "PartId", type: "lookup", lookup: { endpoint: "/api/parts", labelKey: "sku" } },
      { name: "SkuSnapshot", type: "string" },
      { name: "NameSnapshot", type: "string" },
      { name: "UnitPrice", type: "number" },
      { name: "Qty", type: "number" },
      { name: "LineTotal", type: "number" }
    ]
  },
  {
    key: "payments",
    label: "Payments",
    endpoint: "/api/payments",
    fields: [
      { name: "OrderId", type: "lookup", lookup: { endpoint: "/api/orders", labelKey: "orderNumber" } },
      { name: "Provider", type: "string" },
      { name: "ProviderRef", type: "string" },
      { name: "Status", type: "enum", options: "PaymentStatus" },
      { name: "Amount", type: "number" }
    ]
  },
  {
    key: "shipments",
    label: "Shipments",
    endpoint: "/api/shipments",
    fields: [
      { name: "OrderId", type: "lookup", lookup: { endpoint: "/api/orders", labelKey: "orderNumber" } },
      { name: "Carrier", type: "string" },
      { name: "TrackingNumber", type: "string" },
      { name: "Status", type: "enum", options: "ShipmentStatus" },
      { name: "ShippedAt", type: "datetime" },
      { name: "DeliveredAt", type: "datetime" }
    ]
  },
  {
    key: "returns",
    label: "Returns",
    endpoint: "/api/returns",
    fields: [
      { name: "OrderId", type: "lookup", lookup: { endpoint: "/api/orders", labelKey: "orderNumber" } },
      { name: "Status", type: "enum", options: "ReturnStatus" },
      { name: "Reason", type: "string" }
    ]
  },
  {
    key: "returnitems",
    label: "Return Items",
    endpoint: "/api/returnitems",
    fields: [
      { name: "ReturnId", type: "lookup", lookup: { endpoint: "/api/returns", labelKey: "id" } },
      { name: "OrderItemId", type: "lookup", lookup: { endpoint: "/api/orderitems", labelKey: "id" } },
      { name: "Qty", type: "number" },
      { name: "Condition", type: "string" },
      { name: "RefundAmount", type: "number" }
    ]
  },
  {
    key: "stockmovements",
    label: "Stock Movements",
    endpoint: "/api/stockmovements",
    fields: [
      { name: "PartId", type: "lookup", lookup: { endpoint: "/api/parts", labelKey: "sku" } },
      { name: "WarehouseId", type: "lookup", lookup: { endpoint: "/api/warehouses", labelKey: "name" } },
      { name: "Type", type: "enum", options: "StockMovementType" },
      { name: "QtyChange", type: "number" },
      { name: "ReferenceType", type: "string" },
      { name: "ReferenceId", type: "number" },
      { name: "Note", type: "string" }
    ]
  },
  {
    key: "importjobs",
    label: "Import Jobs",
    endpoint: "/api/importjobs",
    fields: [
      { name: "SupplierId", type: "lookup", lookup: { endpoint: "/api/suppliers", labelKey: "name" } },
      { name: "Status", type: "string" },
      { name: "StartedAt", type: "datetime" },
      { name: "FinishedAt", type: "datetime" },
      { name: "StatsJson", type: "string" },
      { name: "ErrorMessage", type: "string" }
    ]
  },
  {
    key: "supplierpartnumbers",
    label: "Supplier Part Numbers",
    endpoint: "/api/supplierpartnumbers",
    fields: [
      { name: "SupplierPartId", type: "lookup", lookup: { endpoint: "/api/supplierparts", labelKey: "supplierSku" } },
      { name: "Type", type: "enum", options: "PartNumberType" },
      { name: "Value", type: "string" }
    ]
  }
];
