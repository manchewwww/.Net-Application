using AutoPartsShop.Entities;
using AutoPartsShop.Enums;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.Data
{
    public class AutoPartsShopDbContext : DbContext
    {
        public AutoPartsShopDbContext(DbContextOptions<AutoPartsShopDbContext> options) : base(options)
        {
        }

        public DbSet<AddressEntity> Addresses => Set<AddressEntity>();
        public DbSet<BrandEntity> Brands => Set<BrandEntity>();
        public DbSet<CartEntity> Carts => Set<CartEntity>();
        public DbSet<CartItemEntity> CartItems => Set<CartItemEntity>();
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<CountryEntity> Countries => Set<CountryEntity>();
        public DbSet<CurrencyEntity> Currencies => Set<CurrencyEntity>();
        public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
        public DbSet<ExchangeRateEntity> ExchangeRates => Set<ExchangeRateEntity>();
        public DbSet<ImportJobEntity> ImportJobs => Set<ImportJobEntity>();
        public DbSet<InventoryEntity> Inventory => Set<InventoryEntity>();
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<OrderItemEntity> OrderItems => Set<OrderItemEntity>();
        public DbSet<PartAttributeEntity> PartAttributes => Set<PartAttributeEntity>();
        public DbSet<PartEntity> Parts => Set<PartEntity>();
        public DbSet<PartFitmentEntity> PartFitments => Set<PartFitmentEntity>();
        public DbSet<PartImageEntity> PartImages => Set<PartImageEntity>();
        public DbSet<PartNumberEntity> PartNumbers => Set<PartNumberEntity>();
        public DbSet<PartPriceEntity> PartPrices => Set<PartPriceEntity>();
        public DbSet<PartSupplierLinkEntity> PartSupplierLinks => Set<PartSupplierLinkEntity>();
        public DbSet<PaymentEntity> Payments => Set<PaymentEntity>();
        public DbSet<PriceListEntity> PriceLists => Set<PriceListEntity>();
        public DbSet<ReturnEntity> Returns => Set<ReturnEntity>();
        public DbSet<ReturnItemEntity> ReturnItems => Set<ReturnItemEntity>();
        public DbSet<ShipmentEntity> Shipments => Set<ShipmentEntity>();
        public DbSet<StockMovementEntity> StockMovements => Set<StockMovementEntity>();
        public DbSet<SupplierEntity> Suppliers => Set<SupplierEntity>();
        public DbSet<SupplierPartEntity> SupplierParts => Set<SupplierPartEntity>();
        public DbSet<SupplierPartNumberEntity> SupplierPartNumbers => Set<SupplierPartNumberEntity>();
        public DbSet<VehicleMakeEntity> VehicleMakes => Set<VehicleMakeEntity>();
        public DbSet<VehicleModelEntity> VehicleModels => Set<VehicleModelEntity>();
        public DbSet<VehicleVariantEntity> VehicleVariants => Set<VehicleVariantEntity>();
        public DbSet<WarehouseEntity> Warehouses => Set<WarehouseEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<PartNumberType>("part_number_type");
            modelBuilder.HasPostgresEnum<FitmentType>("fitment_type");
            modelBuilder.HasPostgresEnum<OrderStatus>("order_status");
            modelBuilder.HasPostgresEnum<PaymentStatus>("payment_status");
            modelBuilder.HasPostgresEnum<ShipmentStatus>("shipment_status");
            modelBuilder.HasPostgresEnum<AddressType>("address_type");
            modelBuilder.HasPostgresEnum<DeliveryType>("delivery_type");
            modelBuilder.HasPostgresEnum<StockMovementType>("stock_movement_type");
            modelBuilder.HasPostgresEnum<ReturnStatus>("return_status");

            modelBuilder.Entity<CountryEntity>(entity =>
            {
                entity.ToTable("countries");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CountryCode).HasColumnName("country_code").HasMaxLength(2);
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(120);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<CurrencyEntity>(entity =>
            {
                entity.ToTable("currencies");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CurrencyCode).HasColumnName("currency_code").HasMaxLength(3);
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(60);
                entity.Property(e => e.Symbol).HasColumnName("symbol").HasMaxLength(10);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<ExchangeRateEntity>(entity =>
            {
                entity.ToTable("exchange_rates");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.BaseCurrencyId).HasColumnName("base_currency_id");
                entity.Property(e => e.QuoteCurrencyId).HasColumnName("quote_currency_id").HasMaxLength(3);
                entity.Property(e => e.Rate).HasColumnName("rate").HasColumnType("numeric(18,6)");
                entity.Property(e => e.AsOf).HasColumnName("as_of");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.BaseCurrencyId, e.QuoteCurrencyId, e.AsOf }).IsUnique();
                entity.HasOne<CurrencyEntity>().WithMany().HasForeignKey(e => e.BaseCurrencyId);
                entity.HasOne<CurrencyEntity>().WithMany().HasForeignKey(e => e.QuoteCurrencyId);
            });

            modelBuilder.Entity<BrandEntity>(entity =>
            {
                entity.ToTable("brands");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(120);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasOne<CountryEntity>().WithMany().HasForeignKey(e => e.CountryId);
            });

            modelBuilder.Entity<CategoryEntity>(entity =>
            {
                entity.ToTable("categories");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(160);
                entity.Property(e => e.Slug).HasColumnName("slug").HasMaxLength(180);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasOne<CategoryEntity>()
                    .WithMany()
                    .HasForeignKey(e => e.ParentCategoryId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<PartEntity>(entity =>
            {
                entity.ToTable("parts");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Sku).HasColumnName("sku").HasMaxLength(60);
                entity.Property(e => e.BrandId).HasColumnName("brand_id");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(220);
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.WeightKg).HasColumnName("weight_kg").HasColumnType("numeric(10,3)");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => e.BrandId).HasDatabaseName("ix_parts_brand_id");
                entity.HasIndex(e => e.CategoryId).HasDatabaseName("ix_parts_category_id");
                entity.HasOne<BrandEntity>().WithMany().HasForeignKey(e => e.BrandId);
                entity.HasOne<CategoryEntity>().WithMany().HasForeignKey(e => e.CategoryId);
            });

            modelBuilder.Entity<PartImageEntity>(entity =>
            {
                entity.ToTable("part_images");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PartId).HasColumnName("part_id");
                entity.Property(e => e.Url).HasColumnName("url");
                entity.Property(e => e.SortOrder).HasColumnName("sort_order");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.PartId, e.SortOrder }).IsUnique();
                entity.HasOne<PartEntity>().WithMany().HasForeignKey(e => e.PartId).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<PartNumberEntity>(entity =>
            {
                entity.ToTable("part_numbers");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PartId).HasColumnName("part_id");
                entity.Property(e => e.Type).HasColumnName("type").HasColumnType("part_number_type");
                entity.Property(e => e.Value).HasColumnName("value").HasMaxLength(140);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.PartId, e.Type, e.Value }).IsUnique();
                entity.HasIndex(e => new { e.Type, e.Value }).HasDatabaseName("ix_part_numbers_type_value");
                entity.HasOne<PartEntity>().WithMany().HasForeignKey(e => e.PartId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PartAttributeEntity>(entity =>
            {
                entity.ToTable("part_attributes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PartId).HasColumnName("part_id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(80);
                entity.Property(e => e.Value).HasColumnName("value").HasMaxLength(180);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.PartId, e.Name }).HasDatabaseName("ix_part_attributes_part_name");
                entity.HasOne<PartEntity>().WithMany().HasForeignKey(e => e.PartId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<VehicleMakeEntity>(entity =>
            {
                entity.ToTable("vehicle_makes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(120);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<VehicleModelEntity>(entity =>
            {
                entity.ToTable("vehicle_models");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.MakeId).HasColumnName("make_id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(120);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => e.MakeId).HasDatabaseName("ix_vehicle_models_make_id");
                entity.HasIndex(e => new { e.MakeId, e.Name }).IsUnique();
                entity.HasOne<VehicleMakeEntity>().WithMany().HasForeignKey(e => e.MakeId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<VehicleVariantEntity>(entity =>
            {
                entity.ToTable("vehicle_variants");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ModelId).HasColumnName("model_id");
                entity.Property(e => e.YearFrom).HasColumnName("year_from");
                entity.Property(e => e.YearTo).HasColumnName("year_to");
                entity.Property(e => e.EngineCode).HasColumnName("engine_code").HasMaxLength(60);
                entity.Property(e => e.Notes).HasColumnName("notes");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.ModelId, e.YearFrom, e.YearTo }).HasDatabaseName("ix_vehicle_variants_model_year");
                entity.HasIndex(e => e.EngineCode).HasDatabaseName("ix_vehicle_variants_engine_code");
                entity.HasOne<VehicleModelEntity>().WithMany().HasForeignKey(e => e.ModelId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PartFitmentEntity>(entity =>
            {
                entity.ToTable("part_fitments");
                entity.HasKey(e => new { e.PartId, e.VariantId });
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PartId).HasColumnName("part_id");
                entity.Property(e => e.VariantId).HasColumnName("variant_id");
                entity.Property(e => e.Fitment).HasColumnName("fitment").HasColumnType("fitment_type");
                entity.Property(e => e.Notes).HasColumnName("notes");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.VariantId, e.PartId }).HasDatabaseName("ix_part_fitments_variant_part");
                entity.HasOne<PartEntity>().WithMany().HasForeignKey(e => e.PartId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<VehicleVariantEntity>().WithMany().HasForeignKey(e => e.VariantId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<WarehouseEntity>(entity =>
            {
                entity.ToTable("warehouses");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(120);
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.City).HasColumnName("city").HasMaxLength(120);
                entity.Property(e => e.Address1).HasColumnName("address1").HasMaxLength(220);
                entity.Property(e => e.Address2).HasColumnName("address2").HasMaxLength(220);
                entity.Property(e => e.Postcode).HasColumnName("postcode").HasMaxLength(20);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasOne<CountryEntity>().WithMany().HasForeignKey(e => e.CountryId);
            });

            modelBuilder.Entity<InventoryEntity>(entity =>
            {
                entity.ToTable("inventory");
                entity.HasKey(e => new { e.PartId, e.WarehouseId });
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PartId).HasColumnName("part_id");
                entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
                entity.Property(e => e.QtyOnHand).HasColumnName("qty_on_hand");
                entity.Property(e => e.QtyReserved).HasColumnName("qty_reserved");
                entity.Property(e => e.ReorderPoint).HasColumnName("reorder_point");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => e.PartId).HasDatabaseName("ix_inventory_part");
                entity.HasIndex(e => e.WarehouseId).HasDatabaseName("ix_inventory_warehouse");
                entity.HasOne<PartEntity>().WithMany().HasForeignKey(e => e.PartId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<WarehouseEntity>().WithMany().HasForeignKey(e => e.WarehouseId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<StockMovementEntity>(entity =>
            {
                entity.ToTable("stock_movements");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PartId).HasColumnName("part_id");
                entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
                entity.Property(e => e.Type).HasColumnName("type").HasColumnType("stock_movement_type");
                entity.Property(e => e.QtyChange).HasColumnName("qty_change");
                entity.Property(e => e.ReferenceType).HasColumnName("reference_type").HasMaxLength(30);
                entity.Property(e => e.ReferenceId).HasColumnName("reference_id");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.PartId, e.WarehouseId, e.CreatedAt }).HasDatabaseName("ix_stock_movements_part_warehouse_time");
                entity.HasOne<PartEntity>().WithMany().HasForeignKey(e => e.PartId);
                entity.HasOne<WarehouseEntity>().WithMany().HasForeignKey(e => e.WarehouseId);
            });
            modelBuilder.Entity<PriceListEntity>(entity =>
            {
                entity.ToTable("price_lists");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(120);
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.Name, e.CurrencyId, e.CountryId }).IsUnique();
                entity.HasOne<CurrencyEntity>().WithMany().HasForeignKey(e => e.CurrencyId);
                entity.HasOne<CountryEntity>().WithMany().HasForeignKey(e => e.CountryId);
            });

            modelBuilder.Entity<PartPriceEntity>(entity =>
            {
                entity.ToTable("part_prices");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PartId).HasColumnName("part_id");
                entity.Property(e => e.PriceListId).HasColumnName("price_list_id");
                entity.Property(e => e.ListPrice).HasColumnName("list_price").HasColumnType("numeric(18,2)");
                entity.Property(e => e.SalePrice).HasColumnName("sale_price").HasColumnType("numeric(18,2)");
                entity.Property(e => e.ValidFrom).HasColumnName("valid_from");
                entity.Property(e => e.ValidTo).HasColumnName("valid_to");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.PartId, e.PriceListId }).HasDatabaseName("ix_part_prices_part_pricelist");
                entity.HasIndex(e => new { e.PriceListId, e.ValidFrom, e.ValidTo }).HasDatabaseName("ix_part_prices_validity");
                entity.HasOne<PartEntity>().WithMany().HasForeignKey(e => e.PartId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<PriceListEntity>().WithMany().HasForeignKey(e => e.PriceListId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SupplierEntity>(entity =>
            {
                entity.ToTable("suppliers");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(160);
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(200);
                entity.Property(e => e.Phone).HasColumnName("phone").HasMaxLength(40);
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasOne<CountryEntity>().WithMany().HasForeignKey(e => e.CountryId);
            });

            modelBuilder.Entity<SupplierPartEntity>(entity =>
            {
                entity.ToTable("supplier_parts");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
                entity.Property(e => e.SupplierSku).HasColumnName("supplier_sku").HasMaxLength(80);
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(220);
                entity.Property(e => e.BrandName).HasColumnName("brand_name").HasMaxLength(120);
                entity.Property(e => e.Cost).HasColumnName("cost").HasColumnType("numeric(18,2)");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.LeadTimeDays).HasColumnName("lead_time_days");
                entity.Property(e => e.LastImportedAt).HasColumnName("last_imported_at");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.SupplierId, e.SupplierSku }).IsUnique();
                entity.HasOne<SupplierEntity>().WithMany().HasForeignKey(e => e.SupplierId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<CurrencyEntity>().WithMany().HasForeignKey(e => e.CurrencyId);
            });

            modelBuilder.Entity<SupplierPartNumberEntity>(entity =>
            {
                entity.ToTable("supplier_part_numbers");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.SupplierPartId).HasColumnName("supplier_part_id");
                entity.Property(e => e.Type).HasColumnName("type").HasColumnType("part_number_type");
                entity.Property(e => e.Value).HasColumnName("value").HasMaxLength(140);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.Type, e.Value }).HasDatabaseName("ix_supplier_part_numbers_type_value");
                entity.HasOne<SupplierPartEntity>().WithMany().HasForeignKey(e => e.SupplierPartId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PartSupplierLinkEntity>(entity =>
            {
                entity.ToTable("part_supplier_links");
                entity.HasKey(e => new { e.PartId, e.SupplierPartId });
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PartId).HasColumnName("part_id");
                entity.Property(e => e.SupplierPartId).HasColumnName("supplier_part_id");
                entity.Property(e => e.Priority).HasColumnName("priority");
                entity.Property(e => e.IsPrimary).HasColumnName("is_primary");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => e.SupplierPartId).HasDatabaseName("ix_part_supplier_links_supplier_part");
                entity.HasOne<PartEntity>().WithMany().HasForeignKey(e => e.PartId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<SupplierPartEntity>().WithMany().HasForeignKey(e => e.SupplierPartId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ImportJobEntity>(entity =>
            {
                entity.ToTable("import_jobs");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
                entity.Property(e => e.Status).HasColumnName("status").HasMaxLength(20);
                entity.Property(e => e.StartedAt).HasColumnName("started_at");
                entity.Property(e => e.FinishedAt).HasColumnName("finished_at");
                entity.Property(e => e.StatsJson).HasColumnName("stats_json").HasColumnType("jsonb");
                entity.Property(e => e.ErrorMessage).HasColumnName("error_message");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasOne<SupplierEntity>().WithMany().HasForeignKey(e => e.SupplierId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CustomerEntity>(entity =>
            {
                entity.ToTable("customers");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(200);
                entity.Property(e => e.Phone).HasColumnName("phone").HasMaxLength(40);
                entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<AddressEntity>(entity =>
            {
                entity.ToTable("addresses");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.Type).HasColumnName("type").HasColumnType("address_type");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(200);
                entity.Property(e => e.Line1).HasColumnName("line1").HasMaxLength(220);
                entity.Property(e => e.Line2).HasColumnName("line2").HasMaxLength(220);
                entity.Property(e => e.City).HasColumnName("city").HasMaxLength(120);
                entity.Property(e => e.Region).HasColumnName("region").HasMaxLength(120);
                entity.Property(e => e.PostalCode).HasColumnName("postal_code").HasMaxLength(20);
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.IsDefault).HasColumnName("is_default");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.CustomerId, e.Type }).HasDatabaseName("ix_addresses_customer_type");
                entity.HasOne<CustomerEntity>().WithMany().HasForeignKey(e => e.CustomerId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<CountryEntity>().WithMany().HasForeignKey(e => e.CountryId);
            });

            modelBuilder.Entity<OrderEntity>(entity =>
            {
                entity.ToTable("orders");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.OrderNumber).HasColumnName("order_number").HasMaxLength(40);
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.Status).HasColumnName("status").HasColumnType("order_status");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.Subtotal).HasColumnName("subtotal").HasColumnType("numeric(18,2)");
                entity.Property(e => e.ShippingCost).HasColumnName("shipping_cost").HasColumnType("numeric(18,2)");
                entity.Property(e => e.DiscountTotal).HasColumnName("discount_total").HasColumnType("numeric(18,2)");
                entity.Property(e => e.TaxTotal).HasColumnName("tax_total").HasColumnType("numeric(18,2)");
                entity.Property(e => e.GrandTotal).HasColumnName("grand_total").HasColumnType("numeric(18,2)");
                entity.Property(e => e.ShippingProvider).HasColumnName("shipping_provider").HasMaxLength(80);
                entity.Property(e => e.DeliveryType).HasColumnName("delivery_type").HasColumnType("delivery_type");
                entity.Property(e => e.ShippingName).HasColumnName("shipping_name").HasMaxLength(200);
                entity.Property(e => e.ShippingPhone).HasColumnName("shipping_phone").HasMaxLength(40);
                entity.Property(e => e.ShippingCountryId).HasColumnName("shipping_country_id").HasMaxLength(2);
                entity.Property(e => e.ShippingCity).HasColumnName("shipping_city").HasMaxLength(120);
                entity.Property(e => e.ShippingAddress1).HasColumnName("shipping_address1").HasMaxLength(220);
                entity.Property(e => e.ShippingAddress2).HasColumnName("shipping_address2").HasMaxLength(220);
                entity.Property(e => e.ShippingPostalCode).HasColumnName("shipping_postal_code").HasMaxLength(20);
                entity.Property(e => e.ProviderLocationId).HasColumnName("provider_location_id").HasMaxLength(80);
                entity.Property(e => e.ProviderLocationName).HasColumnName("provider_location_name").HasMaxLength(200);
                entity.Property(e => e.BillingAddressSnapshot).HasColumnName("billing_address_snapshot").HasColumnType("jsonb");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.CustomerId, e.CreatedAt }).HasDatabaseName("ix_orders_customer_created");
                entity.HasOne<CustomerEntity>().WithMany().HasForeignKey(e => e.CustomerId).OnDelete(DeleteBehavior.SetNull);
                entity.HasOne<CurrencyEntity>().WithMany().HasForeignKey(e => e.CurrencyId);
                entity.HasOne<CountryEntity>().WithMany().HasForeignKey(e => e.ShippingCountryId);
            });

            modelBuilder.Entity<OrderItemEntity>(entity =>
            {
                entity.ToTable("order_items");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.PartId).HasColumnName("part_id");
                entity.Property(e => e.SkuSnapshot).HasColumnName("sku_snapshot").HasMaxLength(60);
                entity.Property(e => e.NameSnapshot).HasColumnName("name_snapshot").HasMaxLength(220);
                entity.Property(e => e.UnitPrice).HasColumnName("unit_price").HasColumnType("numeric(18,2)");
                entity.Property(e => e.Qty).HasColumnName("qty");
                entity.Property(e => e.LineTotal).HasColumnName("line_total").HasColumnType("numeric(18,2)");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => e.OrderId).HasDatabaseName("ix_order_items_order");
                entity.HasOne<OrderEntity>().WithMany().HasForeignKey(e => e.OrderId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<PartEntity>().WithMany().HasForeignKey(e => e.PartId);
            });

            modelBuilder.Entity<PaymentEntity>(entity =>
            {
                entity.ToTable("payments");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.Provider).HasColumnName("provider").HasMaxLength(40);
                entity.Property(e => e.ProviderRef).HasColumnName("provider_ref").HasMaxLength(120);
                entity.Property(e => e.Status).HasColumnName("status").HasColumnType("payment_status");
                entity.Property(e => e.Amount).HasColumnName("amount").HasColumnType("numeric(18,2)");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => e.OrderId).HasDatabaseName("ix_payments_order");
                entity.HasOne<OrderEntity>().WithMany().HasForeignKey(e => e.OrderId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ShipmentEntity>(entity =>
            {
                entity.ToTable("shipments");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.Carrier).HasColumnName("carrier").HasMaxLength(80);
                entity.Property(e => e.TrackingNumber).HasColumnName("tracking_number").HasMaxLength(120);
                entity.Property(e => e.Status).HasColumnName("status").HasColumnType("shipment_status");
                entity.Property(e => e.ShippedAt).HasColumnName("shipped_at");
                entity.Property(e => e.DeliveredAt).HasColumnName("delivered_at");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => e.OrderId).HasDatabaseName("ix_shipments_order");
                entity.HasIndex(e => e.TrackingNumber).HasDatabaseName("ix_shipments_tracking");
                entity.HasOne<OrderEntity>().WithMany().HasForeignKey(e => e.OrderId).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<CartEntity>(entity =>
            {
                entity.ToTable("carts");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasOne<CustomerEntity>().WithMany().HasForeignKey(e => e.CustomerId).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<CartItemEntity>(entity =>
            {
                entity.ToTable("cart_items");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CartId).HasColumnName("cart_id");
                entity.Property(e => e.PartId).HasColumnName("part_id");
                entity.Property(e => e.Qty).HasColumnName("qty");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => new { e.CartId, e.PartId }).IsUnique();
                entity.HasOne<CartEntity>().WithMany().HasForeignKey(e => e.CartId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<PartEntity>().WithMany().HasForeignKey(e => e.PartId);
            });

            modelBuilder.Entity<ReturnEntity>(entity =>
            {
                entity.ToTable("returns");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.Status).HasColumnName("status").HasColumnType("return_status");
                entity.Property(e => e.Reason).HasColumnName("reason");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasIndex(e => e.OrderId).HasDatabaseName("ix_returns_order");
                entity.HasOne<OrderEntity>().WithMany().HasForeignKey(e => e.OrderId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ReturnItemEntity>(entity =>
            {
                entity.ToTable("return_items");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ReturnId).HasColumnName("return_id");
                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");
                entity.Property(e => e.Qty).HasColumnName("qty");
                entity.Property(e => e.Condition).HasColumnName("condition").HasMaxLength(80);
                entity.Property(e => e.RefundAmount).HasColumnName("refund_amount").HasColumnType("numeric(18,2)");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.HasOne<ReturnEntity>().WithMany().HasForeignKey(e => e.ReturnId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<OrderItemEntity>().WithMany().HasForeignKey(e => e.OrderItemId);
            });

            ConfigureDbManagedTimestamps(modelBuilder);
        }

        private static void ConfigureDbManagedTimestamps(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var createdAt = entityType.FindProperty("CreatedAt");
                var updatedAt = entityType.FindProperty("UpdatedAt");

                if (createdAt != null)
                {
                    createdAt.SetDefaultValueSql("now()");
                    createdAt.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
                }

                if (updatedAt != null)
                {
                    updatedAt.SetDefaultValueSql("now()");
                    updatedAt.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAddOrUpdate;

                    updatedAt.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
                }
            }
        }
    }
}
