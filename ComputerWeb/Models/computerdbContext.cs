using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ComputerWeb.Models
{
    public partial class computerdbContext : DbContext
    {
        public computerdbContext()
        {
        }

        public computerdbContext(DbContextOptions<computerdbContext> options) : base(options) { }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ComputerOrder> ComputerOrder { get; set; }
        public virtual DbSet<Consignee> Consignee { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerType> CustomerType { get; set; }
        public virtual DbSet<CustomerWords> CustomerWords { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<PriceList> PriceList { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductClass> ProductClass { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<SystemRole> SystemRole { get; set; }
        public virtual DbSet<SystemUser> SystemUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NCKS0EU;Initial Catalog=computerdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.TheArea);

                entity.Property(e => e.TheArea)
                    .HasColumnName("theArea")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aname)
                    .IsRequired()
                    .HasColumnName("aname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TheCity).HasColumnName("theCity");

                entity.HasOne(d => d.TheCityNavigation)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.TheCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AreaFK");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.TheCity);

                entity.Property(e => e.TheCity)
                    .HasColumnName("theCity")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasColumnName("cname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TheProvince).HasColumnName("theProvince");

                entity.HasOne(d => d.TheProvinceNavigation)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.TheProvince)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CityFK");
            });

            modelBuilder.Entity<ComputerOrder>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amt).HasColumnName("amt");

                entity.Property(e => e.OrderState)
                    .IsRequired()
                    .HasColumnName("orderState")
                    .HasColumnType("char(12)");

                entity.Property(e => e.OrderTime)
                    .HasColumnName("orderTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TheOrder).HasColumnName("theOrder");

                entity.Property(e => e.ThePayment).HasColumnName("thePayment");

                entity.Property(e => e.TheProductId).HasColumnName("theProductID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.TheOrderNavigation)
                    .WithMany(p => p.ComputerOrder)
                    .HasForeignKey(d => d.TheOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ComputerOrderFK3");

                entity.HasOne(d => d.ThePaymentNavigation)
                    .WithMany(p => p.ComputerOrder)
                    .HasForeignKey(d => d.ThePayment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ComputerOrderFK2");

                entity.HasOne(d => d.TheProduct)
                    .WithMany(p => p.ComputerOrder)
                    .HasForeignKey(d => d.TheProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ComputerOrderFK1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ComputerOrder)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ComputerOrderFK");
            });

            modelBuilder.Entity<Consignee>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

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
                    .HasMaxLength(50)
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

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HomePhone)
                    .IsRequired()
                    .HasColumnName("homePhone")
                    .HasColumnType("char(20)");

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasColumnName("mobilePhone")
                    .HasColumnType("char(20)");

                entity.Property(e => e.OfficePhone)
                    .IsRequired()
                    .HasColumnName("officePhone")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasColumnName("pwd")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.QqNumber)
                    .IsRequired()
                    .HasColumnName("qqNumber")
                    .HasColumnType("char(10)");

                entity.Property(e => e.TheCustomerType).HasColumnName("theCustomerType");

                entity.HasOne(d => d.TheCustomerTypeNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.TheCustomerType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerFK1");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.HasKey(e => e.TheCustomerType);

                entity.Property(e => e.TheCustomerType)
                    .HasColumnName("theCustomerType")
                    .ValueGeneratedNever();

                entity.Property(e => e.MinSpending).HasColumnName("minSpending");

                entity.Property(e => e.Typename)
                    .IsRequired()
                    .HasColumnName("typename")
                    .HasColumnType("char(20)");
            });

            modelBuilder.Entity<CustomerWords>(entity =>
            {
                entity.HasKey(e => e.TheOrder);

                entity.Property(e => e.TheOrder)
                    .HasColumnName("theOrder")
                    .ValueGeneratedNever();

                entity.Property(e => e.Words)
                    .HasColumnName("words")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.ThePayment);

                entity.Property(e => e.ThePayment)
                    .HasColumnName("thePayment")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasColumnName("accountName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNo)
                    .IsRequired()
                    .HasColumnName("accountNo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.TransNo).HasColumnName("transNo");

                entity.Property(e => e.TransTime)
                    .HasColumnName("transTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("typeName")
                    .HasColumnType("char(20)");

                entity.HasOne(d => d.TypeNameNavigation)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.TypeName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PaymentFK");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.TypeName);

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .HasColumnType("char(20)")
                    .ValueGeneratedNever();

                entity.Property(e => e.BigImg)
                    .HasColumnName("bigImg")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MethodName)
                    .HasColumnName("methodName")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Purl)
                    .IsRequired()
                    .HasColumnName("purl")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SmallImg)
                    .HasColumnName("smallImg")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PriceList>(entity =>
            {
                entity.HasKey(e => e.TheProductId);

                entity.Property(e => e.TheProductId)
                    .HasColumnName("theProductID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RealPrice)
                    .HasColumnName("realPrice")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.TheCustomerType).HasColumnName("theCustomerType");

                entity.HasOne(d => d.TheCustomerTypeNavigation)
                    .WithMany(p => p.PriceList)
                    .HasForeignKey(d => d.TheCustomerType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PriceListFK1");

                entity.HasOne(d => d.TheProduct)
                    .WithOne(p => p.PriceList)
                    .HasForeignKey<PriceList>(d => d.TheProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PriceListFK");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.TheProductId);

                entity.Property(e => e.TheProductId)
                    .HasColumnName("theProductID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BigImg)
                    .HasColumnName("bigImg")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Cpu)
                    .IsRequired()
                    .HasColumnName("cpu")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("productId")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductState)
                    .IsRequired()
                    .HasColumnName("productState")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Productpositioning)
                    .HasColumnName("productpositioning")
                    .HasMaxLength(130)
                    .IsUnicode(false);

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

                entity.Property(e => e.Screensize)
                    .IsRequired()
                    .HasColumnName("screensize")
                    .HasColumnType("char(50)");

                entity.Property(e => e.SmallImg)
                    .HasColumnName("smallImg")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Timetommarket)
                    .HasColumnName("timetommarket")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<ProductClass>(entity =>
            {
                entity.HasKey(e => e.ObjId);

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.TheProductId).HasColumnName("theProductID");

                entity.Property(e => e.TheProductType).HasColumnName("theProductType");

                entity.HasOne(d => d.TheProduct)
                    .WithMany(p => p.ProductClass)
                    .HasForeignKey(d => d.TheProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductClassFK");

                entity.HasOne(d => d.TheProductTypeNavigation)
                    .WithMany(p => p.ProductClass)
                    .HasForeignKey(d => d.TheProductType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductClassFK1");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.TheProductType);

                entity.Property(e => e.TheProductType)
                    .HasColumnName("theProductType")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassifyType)
                    .IsRequired()
                    .HasColumnName("classifyType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("typeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.TheProvince);

                entity.Property(e => e.TheProvince)
                    .HasColumnName("theProvince")
                    .ValueGeneratedNever();

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasColumnName("pname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SystemRole>(entity =>
            {
                entity.HasKey(e => e.TheRole);

                entity.ToTable("systemRole");

                entity.Property(e => e.TheRole)
                    .HasColumnName("theRole")
                    .ValueGeneratedNever();

                entity.Property(e => e.Sname)
                    .IsRequired()
                    .HasColumnName("sname")
                    .HasColumnType("char(20)");
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("systemUser");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .ValueGeneratedNever();

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

                entity.Property(e => e.UserState)
                    .IsRequired()
                    .HasColumnName("userState")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TheRoleNavigation)
                    .WithMany(p => p.SystemUser)
                    .HasForeignKey(d => d.TheRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("systemUserFK");
            });
        }
    }
}
