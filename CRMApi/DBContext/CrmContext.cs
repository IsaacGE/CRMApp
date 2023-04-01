using System;
using System.Collections.Generic;
using CRMApi.Common;
using CRMApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMApi.DBContext;

public partial class CrmContext : DbContext
{
    public CrmContext()
    {
    }

    public CrmContext(DbContextOptions<CrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlphabeticalListOfProduct> AlphabeticalListOfProducts { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticleCategory> ArticleCategories { get; set; }

    public virtual DbSet<CategorySalesFor1997> CategorySalesFor1997s { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientsCategory> ClientsCategories { get; set; }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<CurrentProductList> CurrentProductLists { get; set; }

    public virtual DbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCities { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<OrderDetailsExtended> OrderDetailsExtendeds { get; set; }

    public virtual DbSet<OrderSubtotal> OrderSubtotals { get; set; }

    public virtual DbSet<OrdersQry> OrdersQries { get; set; }

    public virtual DbSet<ProductSalesFor1997> ProductSalesFor1997s { get; set; }

    public virtual DbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrices { get; set; }

    public virtual DbSet<ProductsByCategory> ProductsByCategories { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<QuarterlyOrder> QuarterlyOrders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<SalesByCategory> SalesByCategories { get; set; }

    public virtual DbSet<SalesProcess> SalesProcesses { get; set; }

    public virtual DbSet<SalesStatus> SalesStatuses { get; set; }

    public virtual DbSet<SalesTotalsByAmount> SalesTotalsByAmounts { get; set; }

    public virtual DbSet<SalesTracking> SalesTrackings { get; set; }

    public virtual DbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarters { get; set; }

    public virtual DbSet<SummaryOfSalesByYear> SummaryOfSalesByYears { get; set; }

    public virtual DbSet<SystemTracking> SystemTrackings { get; set; }

    public virtual DbSet<UnitMeasurement> UnitMeasurements { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Constants.ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlphabeticalListOfProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Alphabetical list of products");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__articles__3213E83F306E8541");

            entity.ToTable("articles");

            entity.HasIndex(e => e.Code, "UQ__articles__357D4CF91C9FE912").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Cost)
                .HasColumnType("money")
                .HasColumnName("cost");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Provider).HasColumnName("provider");
            entity.Property(e => e.RegisterDate)
                .HasColumnType("datetime")
                .HasColumnName("registerDate");
            entity.Property(e => e.RegisteringUser).HasColumnName("registeringUser");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UnitMeasurement).HasColumnName("unitMeasurement");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Articles)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__articles__catego__5629CD9C");

            entity.HasOne(d => d.ProviderNavigation).WithMany(p => p.Articles)
                .HasForeignKey(d => d.Provider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__articles__provid__5535A963");

            entity.HasOne(d => d.RegisteringUserNavigation).WithMany(p => p.Articles)
                .HasForeignKey(d => d.RegisteringUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__articles__regist__5812160E");

            entity.HasOne(d => d.UnitMeasurementNavigation).WithMany(p => p.Articles)
                .HasForeignKey(d => d.UnitMeasurement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__articles__unitMe__571DF1D5");
        });

        modelBuilder.Entity<ArticleCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__articleC__3213E83F3F1EE1D8");

            entity.ToTable("articleCategory");

            entity.HasIndex(e => e.Name, "UQ__articleC__72E12F1B2DCB8F01").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CategorySalesFor1997>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Category Sales for 1997");

            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.CategorySales).HasColumnType("money");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clients__3213E83FA898FE2B");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.RegisterDate)
                .HasColumnType("datetime")
                .HasColumnName("registerDate");
            entity.Property(e => e.RegisteringUser).HasColumnName("registeringUser");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("zipCode");
            entity.Property(e => e.Password)
                .HasMaxLength(355)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__clients__categor__4316F928");

            entity.HasOne(d => d.RegisteringUserNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.RegisteringUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__clients__registe__440B1D61");
        });

        modelBuilder.Entity<ClientsCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clientsC__3213E83F28344951");

            entity.ToTable("clientsCategory");

            entity.HasIndex(e => e.Name, "UK_ClientsCategory_Name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__configur__3213E83FA5B85929");

            entity.ToTable("configuration");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConfigKey)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("configKey");
            entity.Property(e => e.ConfigValue)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("configValue");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.RegisterDate)
                .HasColumnType("datetime")
                .HasColumnName("registerDate");
            entity.Property(e => e.RegisteringUser).HasColumnName("registeringUser");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.RegisteringUserNavigation).WithMany(p => p.Configurations)
                .HasForeignKey(d => d.RegisteringUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__configura__regis__46E78A0C");
        });

        modelBuilder.Entity<CurrentProductList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Current Product List");

            entity.Property(e => e.ProductId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
        });

        modelBuilder.Entity<CustomerAndSuppliersByCity>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Customer and Suppliers by City");

            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.Relationship)
                .HasMaxLength(9)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Invoices");

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName).HasMaxLength(40);
            entity.Property(e => e.ExtendedPrice).HasColumnType("money");
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.Salesperson).HasMaxLength(31);
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.ShipperName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<OrderDetailsExtended>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Order Details Extended");

            entity.Property(e => e.ExtendedPrice).HasColumnType("money");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<OrderSubtotal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Order Subtotals");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Subtotal).HasColumnType("money");
        });

        modelBuilder.Entity<OrdersQry>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Orders Qry");

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductSalesFor1997>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Product Sales for 1997");

            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.ProductSales).HasColumnType("money");
        });

        modelBuilder.Entity<ProductsAboveAveragePrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Products Above Average Price");

            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<ProductsByCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Products by Category");

            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__promotio__3213E83F5D58AFE9");

            entity.ToTable("promotions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Article).HasColumnName("article");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.CityApply)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cityApply");
            entity.Property(e => e.ClientCategory).HasColumnName("clientCategory");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.DiscountPercentage).HasColumnName("discountPercentage");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RegisterDate)
                .HasColumnType("datetime")
                .HasColumnName("registerDate");
            entity.Property(e => e.RegisteringUser).HasColumnName("registeringUser");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");

            entity.HasOne(d => d.ArticleNavigation).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.Article)
                .HasConstraintName("FK__promotion__artic__5BE2A6F2");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("FK__promotion__categ__5CD6CB2B");

            entity.HasOne(d => d.ClientCategoryNavigation).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.ClientCategory)
                .HasConstraintName("FK__promotion__clien__5DCAEF64");

            entity.HasOne(d => d.RegisteringUserNavigation).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.RegisteringUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__promotion__regis__5AEE82B9");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__provider__3213E83FFC4CB9F8");

            entity.ToTable("providers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.RegisterDate)
                .HasColumnType("datetime")
                .HasColumnName("registerDate");
            entity.Property(e => e.RegisteringUser).HasColumnName("registeringUser");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("zipCode");
            entity.Property(e => e.Password)
                .HasMaxLength(355)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.RegisteringUserNavigation).WithMany(p => p.Providers)
                .HasForeignKey(d => d.RegisteringUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__providers__regis__4CA06362");
        });

        modelBuilder.Entity<QuarterlyOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Quarterly Orders");

            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F7A4FB4F7");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.RegisterDate)
                .HasColumnType("datetime")
                .HasColumnName("registerDate");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sales__3213E83FEBEBCDFE");

            entity.ToTable("sales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Client).HasColumnName("client");
            entity.Property(e => e.Folio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("folio");
            entity.Property(e => e.SaleDate)
                .HasColumnType("datetime")
                .HasColumnName("saleDate");
            entity.Property(e => e.SellerUser).HasColumnName("sellerUser");
            entity.Property(e => e.TotalCost)
                .HasColumnType("money")
                .HasColumnName("totalCost");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("totalPrice");
            entity.Property(e => e.TotalQuantity).HasColumnName("totalQuantity");
            entity.Property(e => e.TotalSaleTax)
                .HasColumnType("money")
                .HasColumnName("totalSaleTax");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sales__client__60A75C0F");

            entity.HasOne(d => d.SellerUserNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.SellerUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sales__sellerUse__619B8048");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__saleDeta__3213E83F1A290FE0");

            entity.ToTable("saleDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AaleTax)
                .HasColumnType("money")
                .HasColumnName("aaleTax");
            entity.Property(e => e.Article).HasColumnName("article");
            entity.Property(e => e.JsonArticleDetail)
                .IsUnicode(false)
                .HasColumnName("jsonArticleDetail");
            entity.Property(e => e.JsonArticlePromotion)
                .IsUnicode(false)
                .HasColumnName("jsonArticlePromotion");
            entity.Property(e => e.Sale).HasColumnName("sale");
            entity.Property(e => e.SalePrice)
                .HasColumnType("money")
                .HasColumnName("salePrice");

            entity.HasOne(d => d.ArticleNavigation).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.Article)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__saleDetai__artic__6477ECF3");

            entity.HasOne(d => d.SaleNavigation).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.Sale)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__saleDetail__sale__656C112C");
        });

        modelBuilder.Entity<SalesByCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Sales by Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.ProductSales).HasColumnType("money");
        });

        modelBuilder.Entity<SalesProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__salesPro__3213E83FCB578D84");

            entity.ToTable("salesProcess");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ProcessName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("processName");
        });

        modelBuilder.Entity<SalesStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__salesEst__3213E83F3F710A75");

            entity.ToTable("salesStatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EstatusName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estatusName");
        });

        modelBuilder.Entity<SalesTotalsByAmount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Sales Totals by Amount");

            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.SaleAmount).HasColumnType("money");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SalesTracking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__salesTra__3213E83F577041A2");

            entity.ToTable("salesTracking");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Folio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("folio");
            entity.Property(e => e.SaleId).HasColumnName("saleId");
            entity.Property(e => e.SaleProcessId).HasColumnName("saleProcessId");
            entity.Property(e => e.SaleStatusId).HasColumnName("saleStatusId");

            entity.HasOne(d => d.Sale).WithMany(p => p.SalesTrackings)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesTracking_saleId");

            entity.HasOne(d => d.SaleProcess).WithMany(p => p.SalesTrackings)
                .HasForeignKey(d => d.SaleProcessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesTracking_saleProcess");

            entity.HasOne(d => d.SaleStatus).WithMany(p => p.SalesTrackings)
                .HasForeignKey(d => d.SaleStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesTracking_saleStatus");
        });

        modelBuilder.Entity<SummaryOfSalesByQuarter>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Summary of Sales by Quarter");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.Subtotal).HasColumnType("money");
        });

        modelBuilder.Entity<SummaryOfSalesByYear>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Summary of Sales by Year");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.Subtotal).HasColumnType("money");
        });

        modelBuilder.Entity<SystemTracking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__systemTr__3213E83F03838C4E");

            entity.ToTable("systemTracking");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TkDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tkDescription");
            entity.Property(e => e.TkJsonafter)
                .IsUnicode(false)
                .HasColumnName("tkJSONAfter");
            entity.Property(e => e.TkJsonbefore)
                .IsUnicode(false)
                .HasColumnName("tkJSONBefore");
            entity.Property(e => e.TkType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tkType");
        });

        modelBuilder.Entity<UnitMeasurement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__unitMeas__3213E83F4AA086E6");

            entity.ToTable("unitMeasurement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.UnitKey)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("unitKey");
            entity.Property(e => e.UnitValue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unitValue");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F2190F1EB");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.RegisterDate)
                .HasColumnType("datetime")
                .HasColumnName("registerDate");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("zipCode");
            entity.Property(e => e.Password)
                .HasMaxLength(355)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__roleId__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
