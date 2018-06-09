using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ComputerWeb.Models.EF1
{
    public partial class computerdbContext : DbContext
    {
        public computerdbContext(DbContextOptions<computerdbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ComputerOrder> ComputerOrder { get; set; }
        public virtual DbSet<Consignee> Consignee { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerType> CustomerType { get; set; }
        public virtual DbSet<CustomerWords> CustomerWords { get; set; }
        public virtual DbSet<Evaluate> Evaluate { get; set; }
        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<PriceList> PriceList { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductClass> ProductClass { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<SystemRole> SystemRole { get; set; }
        public virtual DbSet<SystemUser> SystemUser { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NCKS0EU;Initial Catalog=computerdb;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.HasIndex(e => e.TheArea)
                    .HasName("UQ__Area__610676EF91DE7A2F")
                    .IsUnique();

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.Aname)
                    .IsRequired()
                    .HasColumnName("aname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TheArea).HasColumnName("theArea");

                entity.Property(e => e.TheCity).HasColumnName("theCity");

                entity.HasOne(d => d.TheCityNavigation)
                    .WithMany(p => p.Area)
                    .HasPrincipalKey(p => p.TheCity)
                    .HasForeignKey(d => d.TheCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AreaFK");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.HasIndex(e => e.TheCity)
                    .HasName("UQ__City__895EB7AE3C16E219")
                    .IsUnique();

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasColumnName("cname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TheCity).HasColumnName("theCity");

                entity.Property(e => e.TheProvince).HasColumnName("theProvince");

                entity.HasOne(d => d.TheProvinceNavigation)
                    .WithMany(p => p.City)
                    .HasPrincipalKey(p => p.TheProvince)
                    .HasForeignKey(d => d.TheProvince)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CityFK");
            });

            modelBuilder.Entity<ComputerOrder>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.HasIndex(e => e.TheOrder)
                    .HasName("UQ__Computer__93391F8B6C7F4D29")
                    .IsUnique();

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.Amt).HasColumnName("amt");

                entity.Property(e => e.EvaluateState)
                    .IsRequired()
                    .HasColumnType("char(12)");

                entity.Property(e => e.OrderState)
                    .IsRequired()
                    .HasColumnName("orderState")
                    .HasColumnType("char(12)");

                entity.Property(e => e.OrderTime)
                    .HasColumnName("orderTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.TheOrder).HasColumnName("theOrder");

                entity.Property(e => e.ThePayment).HasColumnName("thePayment");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ComputerOrder)
                    .HasPrincipalKey(p => p.ProductId)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ComputerOrderFK1");

                entity.HasOne(d => d.ThePaymentNavigation)
                    .WithMany(p => p.ComputerOrder)
                    .HasPrincipalKey(p => p.ThePayment)
                    .HasForeignKey(d => d.ThePayment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ComputerOrderFK2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ComputerOrder)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ComputerOrderFK");
            });

            modelBuilder.Entity<Consignee>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasColumnName("cname")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fulladdress)
                    .IsRequired()
                    .HasColumnName("fulladdress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasColumnName("mobilePhone")
                    .HasColumnType("char(20)");

                entity.Property(e => e.TheArea).HasColumnName("theArea");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.ZipCode).HasColumnName("zipCode");

                entity.HasOne(d => d.TheAreaNavigation)
                    .WithMany(p => p.Consignee)
                    .HasPrincipalKey(p => p.TheArea)
                    .HasForeignKey(d => d.TheArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ConsigneeFK1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Consignee)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ConsigneeFK2");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasColumnName("cname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasColumnName("mobilePhone")
                    .HasColumnType("char(20)");

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasColumnName("pwd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TheCustomerType).HasColumnName("theCustomerType");

                entity.HasOne(d => d.TheCustomerTypeNavigation)
                    .WithMany(p => p.Customer)
                    .HasPrincipalKey(p => p.TheCustomerType)
                    .HasForeignKey(d => d.TheCustomerType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerFK1");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.HasIndex(e => e.TheCustomerType)
                    .HasName("UQ__Customer__639120DA88AE4B68")
                    .IsUnique();

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.MinSpending).HasColumnName("minSpending");

                entity.Property(e => e.TheCustomerType).HasColumnName("theCustomerType");

                entity.Property(e => e.Typename)
                    .IsRequired()
                    .HasColumnName("typename")
                    .HasColumnType("char(20)");
            });

            modelBuilder.Entity<CustomerWords>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.TheOrder).HasColumnName("theOrder");

                entity.Property(e => e.Words)
                    .HasColumnName("words")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TheOrderNavigation)
                    .WithMany(p => p.CustomerWords)
                    .HasPrincipalKey(p => p.TheOrder)
                    .HasForeignKey(d => d.TheOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerWordsFK");
            });

            modelBuilder.Entity<Evaluate>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.TheOrder).HasColumnName("theOrder");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Evaluate)
                    .HasPrincipalKey(p => p.ProductId)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EvaluateFK");
            });

            modelBuilder.Entity<Favorites>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Favorites)
                    .HasPrincipalKey(p => p.ProductId)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FavoritesFK1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FavoritesFK");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.HasIndex(e => e.ThePayment)
                    .HasName("UQ__Payment__F1CCBDF686A80284")
                    .IsUnique();

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.AccountNo)
                    .IsRequired()
                    .HasColumnName("accountNo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ThePayment).HasColumnName("thePayment");

                entity.Property(e => e.TransNo).HasColumnName("transNo");

                entity.Property(e => e.TransTime)
                    .HasColumnName("transTime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ThePaymentNavigation)
                    .WithOne(p => p.Payment)
                    .HasPrincipalKey<PaymentType>(p => p.ThePayment)
                    .HasForeignKey<Payment>(d => d.ThePayment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PaymentFK");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.HasIndex(e => e.ThePayment)
                    .HasName("UQ__PaymentT__F1CCBDF6FD5D2EA3")
                    .IsUnique();

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.BigImg)
                    .HasColumnName("bigImg")
                    .IsUnicode(false);

                entity.Property(e => e.MethodName)
                    .HasColumnName("methodName")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Purl)
                    .IsRequired()
                    .HasColumnName("purl")
                    .IsUnicode(false);

                entity.Property(e => e.SmallImg)
                    .HasColumnName("smallImg")
                    .IsUnicode(false);

                entity.Property(e => e.ThePayment).HasColumnName("thePayment");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("typeName")
                    .HasColumnType("char(20)");
            });

            modelBuilder.Entity<PriceList>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.RealPrice)
                    .HasColumnName("realPrice")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.TheCustomerType).HasColumnName("theCustomerType");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PriceList)
                    .HasPrincipalKey(p => p.ProductId)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PriceListFK");

                entity.HasOne(d => d.TheCustomerTypeNavigation)
                    .WithMany(p => p.PriceList)
                    .HasPrincipalKey(p => p.TheCustomerType)
                    .HasForeignKey(d => d.TheCustomerType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PriceListFK1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.HasIndex(e => e.ProductId)
                    .HasName("UQ__Product__2D10D16B4AFAB2E6")
                    .IsUnique();

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.BigImg)
                    .HasColumnName("bigImg")
                    .IsUnicode(false);

                entity.Property(e => e.Cpu)
                    .IsRequired()
                    .HasColumnName("cpu")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductState)
                    .IsRequired()
                    .HasColumnName("productState")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Ram)
                    .IsRequired()
                    .HasColumnName("ram")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Rom)
                    .IsRequired()
                    .HasColumnName("rom")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.SmallImg)
                    .HasColumnName("smallImg")
                    .IsUnicode(false);

                entity.Property(e => e.Timetommarket)
                    .HasColumnName("timetommarket")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<ProductClass>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.TheProductType).HasColumnName("theProductType");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductClass)
                    .HasPrincipalKey(p => p.ProductId)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductClassFK");

                entity.HasOne(d => d.TheProductTypeNavigation)
                    .WithMany(p => p.ProductClass)
                    .HasPrincipalKey(p => p.TheProductType)
                    .HasForeignKey(d => d.TheProductType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductClassFK1");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.HasIndex(e => e.TheProductType)
                    .HasName("UQ__ProductT__916BBD28C21DBD2F")
                    .IsUnique();

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.ClassifyType)
                    .IsRequired()
                    .HasColumnName("classifyType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TheProductType).HasColumnName("theProductType");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("typeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.HasIndex(e => e.TheProvince)
                    .HasName("UQ__Province__F488AD48C1BE0DC7")
                    .IsUnique();

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasColumnName("pname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TheProvince).HasColumnName("theProvince");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShoppingCart)
                    .HasPrincipalKey(p => p.ProductId)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("ShoppingCartFK1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingCart)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("ShoppingCartFK");
            });

            modelBuilder.Entity<SystemRole>(entity =>
            {
                entity.HasKey(e => e.Objid);

                entity.ToTable("systemRole");

                entity.HasIndex(e => e.TheRole)
                    .HasName("UQ__systemRo__AA7A03D3F32EA7AB")
                    .IsUnique();

                entity.Property(e => e.Objid).HasColumnName("objid");

                entity.Property(e => e.Sname)
                    .IsRequired()
                    .HasColumnName("sname")
                    .HasColumnType("char(20)");

                entity.Property(e => e.TheRole).HasColumnName("theRole");
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.ToTable("systemUser");

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasColumnName("mobilePhone")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasColumnName("pwd")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.TheRole).HasColumnName("theRole");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.UserState)
                    .IsRequired()
                    .HasColumnName("userState")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TheRoleNavigation)
                    .WithMany(p => p.SystemUser)
                    .HasPrincipalKey(p => p.TheRole)
                    .HasForeignKey(d => d.TheRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("systemUserFK");
            });
        }
    }
}
