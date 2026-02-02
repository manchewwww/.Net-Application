using System;
using AutoPartsShop.Enums;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoPartsShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:address_type", "billing,shipping")
                .Annotation("Npgsql:Enum:address_type.address_type", "shipping,billing")
                .Annotation("Npgsql:Enum:delivery_type", "address,locker,office,pickup_point")
                .Annotation("Npgsql:Enum:delivery_type.delivery_type", "address,office,locker,pickup_point")
                .Annotation("Npgsql:Enum:fitment_type", "direct_fit,requires_mod,universal")
                .Annotation("Npgsql:Enum:fitment_type.fitment_type", "direct_fit,requires_mod,universal")
                .Annotation("Npgsql:Enum:order_status", "cancelled,delivered,new,packing,paid,refunded,shipped")
                .Annotation("Npgsql:Enum:order_status.order_status", "new,paid,packing,shipped,delivered,cancelled,refunded")
                .Annotation("Npgsql:Enum:part_number_type", "ean,interchange,manufacturer,oem,upc")
                .Annotation("Npgsql:Enum:part_number_type.part_number_type", "oem,ean,upc,interchange,manufacturer")
                .Annotation("Npgsql:Enum:payment_status", "authorized,captured,failed,pending,refunded")
                .Annotation("Npgsql:Enum:payment_status.payment_status", "pending,authorized,captured,failed,refunded")
                .Annotation("Npgsql:Enum:return_status", "approved,received,refunded,rejected,requested")
                .Annotation("Npgsql:Enum:return_status.return_status", "requested,approved,received,rejected,refunded")
                .Annotation("Npgsql:Enum:shipment_status", "created,delivered,in_transit,lost,returned")
                .Annotation("Npgsql:Enum:shipment_status.shipment_status", "created,in_transit,delivered,lost,returned")
                .Annotation("Npgsql:Enum:stock_movement_type", "adjustment,purchase,release,reserve,return,sale,transfer_in,transfer_out")
                .Annotation("Npgsql:Enum:stock_movement_type.stock_movement_type", "purchase,sale,return,adjustment,transfer_in,transfer_out,reserve,release");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    parent_category_id = table.Column<long>(type: "bigint", nullable: true),
                    name = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    slug = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                    table.ForeignKey(
                        name: "FK_categories_categories_parent_category_id",
                        column: x => x.parent_category_id,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    country_code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.country_code);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    currency_code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    symbol = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencies", x => x.currency_code);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customer_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    phone = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_makes",
                columns: table => new
                {
                    make_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_makes", x => x.make_id);
                });

            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    brand_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    country_code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.brand_id);
                    table.ForeignKey(
                        name: "FK_brands_countries_country_code",
                        column: x => x.country_code,
                        principalTable: "countries",
                        principalColumn: "country_code");
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    supplier_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    country_code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    phone = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.supplier_id);
                    table.ForeignKey(
                        name: "FK_suppliers_countries_country_code",
                        column: x => x.country_code,
                        principalTable: "countries",
                        principalColumn: "country_code");
                });

            migrationBuilder.CreateTable(
                name: "warehouses",
                columns: table => new
                {
                    warehouse_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    country_code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    city = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    address1 = table.Column<string>(type: "character varying(220)", maxLength: 220, nullable: false),
                    address2 = table.Column<string>(type: "character varying(220)", maxLength: 220, nullable: true),
                    postcode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouses", x => x.warehouse_id);
                    table.ForeignKey(
                        name: "FK_warehouses_countries_country_code",
                        column: x => x.country_code,
                        principalTable: "countries",
                        principalColumn: "country_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exchange_rates",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    base_currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    quote_currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    rate = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    as_of = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exchange_rates", x => x.id);
                    table.ForeignKey(
                        name: "FK_exchange_rates_currencies_base_currency",
                        column: x => x.base_currency,
                        principalTable: "currencies",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_exchange_rates_currencies_quote_currency",
                        column: x => x.quote_currency,
                        principalTable: "currencies",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "price_lists",
                columns: table => new
                {
                    price_list_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    currency_code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    country_code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_price_lists", x => x.price_list_id);
                    table.ForeignKey(
                        name: "FK_price_lists_countries_country_code",
                        column: x => x.country_code,
                        principalTable: "countries",
                        principalColumn: "country_code");
                    table.ForeignKey(
                        name: "FK_price_lists_currencies_currency_code",
                        column: x => x.currency_code,
                        principalTable: "currencies",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    address_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<long>(type: "bigint", nullable: false),
                    type = table.Column<AddressType>(type: "address_type", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    line1 = table.Column<string>(type: "character varying(220)", maxLength: 220, nullable: false),
                    line2 = table.Column<string>(type: "character varying(220)", maxLength: 220, nullable: true),
                    city = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    region = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    postal_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    country_code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    is_default = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_addresses_countries_country_code",
                        column: x => x.country_code,
                        principalTable: "countries",
                        principalColumn: "country_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_addresses_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    cart_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.cart_id);
                    table.ForeignKey(
                        name: "FK_carts_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_number = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    customer_id = table.Column<long>(type: "bigint", nullable: true),
                    status = table.Column<OrderStatus>(type: "order_status", nullable: false),
                    currency_code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    shipping_cost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    discount_total = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    tax_total = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    grand_total = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    shipping_provider = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    delivery_type = table.Column<DeliveryType>(type: "delivery_type", nullable: false),
                    shipping_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    shipping_phone = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    shipping_country_code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    shipping_city = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    shipping_address1 = table.Column<string>(type: "character varying(220)", maxLength: 220, nullable: false),
                    shipping_address2 = table.Column<string>(type: "character varying(220)", maxLength: 220, nullable: true),
                    shipping_postal_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    provider_location_id = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    provider_location_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    billing_address_snapshot = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_orders_countries_shipping_country_code",
                        column: x => x.shipping_country_code,
                        principalTable: "countries",
                        principalColumn: "country_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_currencies_currency_code",
                        column: x => x.currency_code,
                        principalTable: "currencies",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_models",
                columns: table => new
                {
                    model_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    make_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_models", x => x.model_id);
                    table.ForeignKey(
                        name: "FK_vehicle_models_vehicle_makes_make_id",
                        column: x => x.make_id,
                        principalTable: "vehicle_makes",
                        principalColumn: "make_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parts",
                columns: table => new
                {
                    part_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sku = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    brand_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "character varying(220)", maxLength: 220, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    weight_kg = table.Column<decimal>(type: "numeric(10,3)", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parts", x => x.part_id);
                    table.ForeignKey(
                        name: "FK_parts_brands_brand_id",
                        column: x => x.brand_id,
                        principalTable: "brands",
                        principalColumn: "brand_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_parts_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "import_jobs",
                columns: table => new
                {
                    import_job_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    supplier_id = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    started_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    finished_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    stats_json = table.Column<string>(type: "jsonb", nullable: true),
                    error_message = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_import_jobs", x => x.import_job_id);
                    table.ForeignKey(
                        name: "FK_import_jobs_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "suppliers",
                        principalColumn: "supplier_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "supplier_parts",
                columns: table => new
                {
                    supplier_part_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    supplier_id = table.Column<long>(type: "bigint", nullable: false),
                    supplier_sku = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    name = table.Column<string>(type: "character varying(220)", maxLength: 220, nullable: false),
                    brand_name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    cost = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    currency_code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    lead_time_days = table.Column<int>(type: "integer", nullable: true),
                    last_imported_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier_parts", x => x.supplier_part_id);
                    table.ForeignKey(
                        name: "FK_supplier_parts_currencies_currency_code",
                        column: x => x.currency_code,
                        principalTable: "currencies",
                        principalColumn: "currency_code");
                    table.ForeignKey(
                        name: "FK_supplier_parts_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "suppliers",
                        principalColumn: "supplier_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    payment_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    provider = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    provider_ref = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    status = table.Column<PaymentStatus>(type: "payment_status", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_payments_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "returns",
                columns: table => new
                {
                    return_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<ReturnStatus>(type: "return_status", nullable: false),
                    reason = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_returns", x => x.return_id);
                    table.ForeignKey(
                        name: "FK_returns_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shipments",
                columns: table => new
                {
                    shipment_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    carrier = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    tracking_number = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    status = table.Column<ShipmentStatus>(type: "shipment_status", nullable: false),
                    shipped_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    delivered_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipments", x => x.shipment_id);
                    table.ForeignKey(
                        name: "FK_shipments_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_variants",
                columns: table => new
                {
                    variant_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    model_id = table.Column<long>(type: "bigint", nullable: false),
                    year_from = table.Column<int>(type: "integer", nullable: false),
                    year_to = table.Column<int>(type: "integer", nullable: false),
                    engine_code = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_variants", x => x.variant_id);
                    table.ForeignKey(
                        name: "FK_vehicle_variants_vehicle_models_model_id",
                        column: x => x.model_id,
                        principalTable: "vehicle_models",
                        principalColumn: "model_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cart_items",
                columns: table => new
                {
                    cart_item_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cart_id = table.Column<long>(type: "bigint", nullable: false),
                    part_id = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart_items", x => x.cart_item_id);
                    table.ForeignKey(
                        name: "FK_cart_items_carts_cart_id",
                        column: x => x.cart_id,
                        principalTable: "carts",
                        principalColumn: "cart_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cart_items_parts_part_id",
                        column: x => x.part_id,
                        principalTable: "parts",
                        principalColumn: "part_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    part_id = table.Column<long>(type: "bigint", nullable: false),
                    warehouse_id = table.Column<long>(type: "bigint", nullable: false),
                    qty_on_hand = table.Column<int>(type: "integer", nullable: false),
                    qty_reserved = table.Column<int>(type: "integer", nullable: false),
                    reorder_point = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => new { x.part_id, x.warehouse_id });
                    table.ForeignKey(
                        name: "FK_inventory_parts_part_id",
                        column: x => x.part_id,
                        principalTable: "parts",
                        principalColumn: "part_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventory_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    order_item_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    part_id = table.Column<long>(type: "bigint", nullable: false),
                    sku_snapshot = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    name_snapshot = table.Column<string>(type: "character varying(220)", maxLength: 220, nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    qty = table.Column<int>(type: "integer", nullable: false),
                    line_total = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => x.order_item_id);
                    table.ForeignKey(
                        name: "FK_order_items_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_items_parts_part_id",
                        column: x => x.part_id,
                        principalTable: "parts",
                        principalColumn: "part_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "part_attributes",
                columns: table => new
                {
                    part_attribute_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    part_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    value = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_part_attributes", x => x.part_attribute_id);
                    table.ForeignKey(
                        name: "FK_part_attributes_parts_part_id",
                        column: x => x.part_id,
                        principalTable: "parts",
                        principalColumn: "part_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "part_images",
                columns: table => new
                {
                    image_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    part_id = table.Column<long>(type: "bigint", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_part_images", x => x.image_id);
                    table.ForeignKey(
                        name: "FK_part_images_parts_part_id",
                        column: x => x.part_id,
                        principalTable: "parts",
                        principalColumn: "part_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "part_numbers",
                columns: table => new
                {
                    part_number_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    part_id = table.Column<long>(type: "bigint", nullable: false),
                    type = table.Column<PartNumberType>(type: "part_number_type", nullable: false),
                    value = table.Column<string>(type: "character varying(140)", maxLength: 140, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_part_numbers", x => x.part_number_id);
                    table.ForeignKey(
                        name: "FK_part_numbers_parts_part_id",
                        column: x => x.part_id,
                        principalTable: "parts",
                        principalColumn: "part_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "part_prices",
                columns: table => new
                {
                    part_price_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    part_id = table.Column<long>(type: "bigint", nullable: false),
                    price_list_id = table.Column<long>(type: "bigint", nullable: false),
                    list_price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    sale_price = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    valid_from = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    valid_to = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_part_prices", x => x.part_price_id);
                    table.ForeignKey(
                        name: "FK_part_prices_parts_part_id",
                        column: x => x.part_id,
                        principalTable: "parts",
                        principalColumn: "part_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_part_prices_price_lists_price_list_id",
                        column: x => x.price_list_id,
                        principalTable: "price_lists",
                        principalColumn: "price_list_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stock_movements",
                columns: table => new
                {
                    movement_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    part_id = table.Column<long>(type: "bigint", nullable: false),
                    warehouse_id = table.Column<long>(type: "bigint", nullable: false),
                    type = table.Column<StockMovementType>(type: "stock_movement_type", nullable: false),
                    qty_change = table.Column<int>(type: "integer", nullable: false),
                    reference_type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    reference_id = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_movements", x => x.movement_id);
                    table.ForeignKey(
                        name: "FK_stock_movements_parts_part_id",
                        column: x => x.part_id,
                        principalTable: "parts",
                        principalColumn: "part_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stock_movements_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "part_supplier_links",
                columns: table => new
                {
                    part_id = table.Column<long>(type: "bigint", nullable: false),
                    supplier_part_id = table.Column<long>(type: "bigint", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    is_primary = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_part_supplier_links", x => new { x.part_id, x.supplier_part_id });
                    table.ForeignKey(
                        name: "FK_part_supplier_links_parts_part_id",
                        column: x => x.part_id,
                        principalTable: "parts",
                        principalColumn: "part_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_part_supplier_links_supplier_parts_supplier_part_id",
                        column: x => x.supplier_part_id,
                        principalTable: "supplier_parts",
                        principalColumn: "supplier_part_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "supplier_part_numbers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    supplier_part_id = table.Column<long>(type: "bigint", nullable: false),
                    type = table.Column<PartNumberType>(type: "part_number_type", nullable: false),
                    value = table.Column<string>(type: "character varying(140)", maxLength: 140, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier_part_numbers", x => x.id);
                    table.ForeignKey(
                        name: "FK_supplier_part_numbers_supplier_parts_supplier_part_id",
                        column: x => x.supplier_part_id,
                        principalTable: "supplier_parts",
                        principalColumn: "supplier_part_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "part_fitments",
                columns: table => new
                {
                    part_id = table.Column<long>(type: "bigint", nullable: false),
                    variant_id = table.Column<long>(type: "bigint", nullable: false),
                    fitment = table.Column<FitmentType>(type: "fitment_type", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_part_fitments", x => new { x.part_id, x.variant_id });
                    table.ForeignKey(
                        name: "FK_part_fitments_parts_part_id",
                        column: x => x.part_id,
                        principalTable: "parts",
                        principalColumn: "part_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_part_fitments_vehicle_variants_variant_id",
                        column: x => x.variant_id,
                        principalTable: "vehicle_variants",
                        principalColumn: "variant_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "return_items",
                columns: table => new
                {
                    return_item_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    return_id = table.Column<long>(type: "bigint", nullable: false),
                    order_item_id = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<int>(type: "integer", nullable: false),
                    condition = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    refund_amount = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_return_items", x => x.return_item_id);
                    table.ForeignKey(
                        name: "FK_return_items_order_items_order_item_id",
                        column: x => x.order_item_id,
                        principalTable: "order_items",
                        principalColumn: "order_item_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_return_items_returns_return_id",
                        column: x => x.return_id,
                        principalTable: "returns",
                        principalColumn: "return_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_country_code",
                table: "addresses",
                column: "country_code");

            migrationBuilder.CreateIndex(
                name: "ix_addresses_customer_type",
                table: "addresses",
                columns: new[] { "customer_id", "type" });

            migrationBuilder.CreateIndex(
                name: "IX_brands_country_code",
                table: "brands",
                column: "country_code");

            migrationBuilder.CreateIndex(
                name: "IX_cart_items_cart_id_part_id",
                table: "cart_items",
                columns: new[] { "cart_id", "part_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cart_items_part_id",
                table: "cart_items",
                column: "part_id");

            migrationBuilder.CreateIndex(
                name: "IX_carts_customer_id",
                table: "carts",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_parent_category_id",
                table: "categories",
                column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_exchange_rates_base_currency_quote_currency_as_of",
                table: "exchange_rates",
                columns: new[] { "base_currency", "quote_currency", "as_of" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_exchange_rates_quote_currency",
                table: "exchange_rates",
                column: "quote_currency");

            migrationBuilder.CreateIndex(
                name: "IX_import_jobs_supplier_id",
                table: "import_jobs",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_part",
                table: "inventory",
                column: "part_id");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_warehouse",
                table: "inventory",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_items_order",
                table: "order_items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_part_id",
                table: "order_items",
                column: "part_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_currency_code",
                table: "orders",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "ix_orders_customer_created",
                table: "orders",
                columns: new[] { "customer_id", "created_at" });

            migrationBuilder.CreateIndex(
                name: "IX_orders_shipping_country_code",
                table: "orders",
                column: "shipping_country_code");

            migrationBuilder.CreateIndex(
                name: "ix_part_attributes_part_name",
                table: "part_attributes",
                columns: new[] { "part_id", "name" });

            migrationBuilder.CreateIndex(
                name: "ix_part_fitments_variant_part",
                table: "part_fitments",
                columns: new[] { "variant_id", "part_id" });

            migrationBuilder.CreateIndex(
                name: "IX_part_images_part_id_sort_order",
                table: "part_images",
                columns: new[] { "part_id", "sort_order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_part_numbers_part_id_type_value",
                table: "part_numbers",
                columns: new[] { "part_id", "type", "value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_part_numbers_type_value",
                table: "part_numbers",
                columns: new[] { "type", "value" });

            migrationBuilder.CreateIndex(
                name: "ix_part_prices_part_pricelist",
                table: "part_prices",
                columns: new[] { "part_id", "price_list_id" });

            migrationBuilder.CreateIndex(
                name: "ix_part_prices_validity",
                table: "part_prices",
                columns: new[] { "price_list_id", "valid_from", "valid_to" });

            migrationBuilder.CreateIndex(
                name: "ix_part_supplier_links_supplier_part",
                table: "part_supplier_links",
                column: "supplier_part_id");

            migrationBuilder.CreateIndex(
                name: "ix_parts_brand_id",
                table: "parts",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_parts_category_id",
                table: "parts",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_payments_order",
                table: "payments",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_price_lists_country_code",
                table: "price_lists",
                column: "country_code");

            migrationBuilder.CreateIndex(
                name: "IX_price_lists_currency_code",
                table: "price_lists",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "IX_price_lists_name_currency_code_country_code",
                table: "price_lists",
                columns: new[] { "name", "currency_code", "country_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_return_items_order_item_id",
                table: "return_items",
                column: "order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_return_items_return_id",
                table: "return_items",
                column: "return_id");

            migrationBuilder.CreateIndex(
                name: "ix_returns_order",
                table: "returns",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_shipments_order",
                table: "shipments",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_shipments_tracking",
                table: "shipments",
                column: "tracking_number");

            migrationBuilder.CreateIndex(
                name: "ix_stock_movements_part_warehouse_time",
                table: "stock_movements",
                columns: new[] { "part_id", "warehouse_id", "created_at" });

            migrationBuilder.CreateIndex(
                name: "IX_stock_movements_warehouse_id",
                table: "stock_movements",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_part_numbers_supplier_part_id",
                table: "supplier_part_numbers",
                column: "supplier_part_id");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_part_numbers_type_value",
                table: "supplier_part_numbers",
                columns: new[] { "type", "value" });

            migrationBuilder.CreateIndex(
                name: "IX_supplier_parts_currency_code",
                table: "supplier_parts",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_parts_supplier_id_supplier_sku",
                table: "supplier_parts",
                columns: new[] { "supplier_id", "supplier_sku" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_country_code",
                table: "suppliers",
                column: "country_code");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_models_make_id",
                table: "vehicle_models",
                column: "make_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_models_make_id_name",
                table: "vehicle_models",
                columns: new[] { "make_id", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_variants_engine_code",
                table: "vehicle_variants",
                column: "engine_code");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_variants_model_year",
                table: "vehicle_variants",
                columns: new[] { "model_id", "year_from", "year_to" });

            migrationBuilder.CreateIndex(
                name: "IX_warehouses_country_code",
                table: "warehouses",
                column: "country_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "cart_items");

            migrationBuilder.DropTable(
                name: "exchange_rates");

            migrationBuilder.DropTable(
                name: "import_jobs");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "part_attributes");

            migrationBuilder.DropTable(
                name: "part_fitments");

            migrationBuilder.DropTable(
                name: "part_images");

            migrationBuilder.DropTable(
                name: "part_numbers");

            migrationBuilder.DropTable(
                name: "part_prices");

            migrationBuilder.DropTable(
                name: "part_supplier_links");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "return_items");

            migrationBuilder.DropTable(
                name: "shipments");

            migrationBuilder.DropTable(
                name: "stock_movements");

            migrationBuilder.DropTable(
                name: "supplier_part_numbers");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "vehicle_variants");

            migrationBuilder.DropTable(
                name: "price_lists");

            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "returns");

            migrationBuilder.DropTable(
                name: "warehouses");

            migrationBuilder.DropTable(
                name: "supplier_parts");

            migrationBuilder.DropTable(
                name: "vehicle_models");

            migrationBuilder.DropTable(
                name: "parts");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "vehicle_makes");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "currencies");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
