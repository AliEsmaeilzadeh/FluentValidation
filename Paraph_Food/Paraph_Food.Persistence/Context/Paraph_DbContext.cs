using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Paraph_Food.Application.Context;
using Paraph_Food.Domain.Enities.Orders;
using Paraph_Food.Domain.Enities.Products;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Paraph_Food.Persistence.Context
{
    public class Paraph_DbContext : DbContext, IParaph_DbContext
    {
        public Paraph_DbContext(DbContextOptions<Paraph_DbContext> option):base(option)
        {
        }

        #region Users
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<VerificationCode> VerificationCodes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        #endregion

        #region Products
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductFavorite> ProductFavorites { get; set; }
        public virtual DbSet<ProductScore> ProductScores { get; set; }
        #endregion

        #region Orders
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Users
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<User>(u =>
            {
                // Id
                u.HasKey("Id");
                u.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                // UserName
                u.Property("UserName")
                     .HasColumnType("nvarchar(256)")
                     .IsRequired()
                     .HasMaxLength(256);
                u.HasIndex("UserName")
                    .IsUnique();

                // Password
                u.Property("Password")
                     .HasColumnType("nvarchar(256)")
                     .HasMaxLength(256);

                // UserStatus
                u.Property("UserStatus")
                     .HasColumnType("tinyint")
                     .IsRequired();

                // CreatedDateTime
                u.Property("CreatedDateTime")
                     .IsRequired();

                // CreatedUserId
                u.Property("CreatedUserId");

                // LastModifiedDateTime
                u.Property("LastModifiedDateTime");

                // LastModifiedUserId
                u.Property("LastModifiedUserId");

                // Deleted
                u.Property("Deleted")
                     .HasColumnType("bit")
                     .IsRequired();
            });

            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<Role>(u =>
            {
                // Id
                u.HasKey("Id");
                u.Property("Id")
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                // Name
                u.Property("Name")
                     .HasColumnType("nvarchar(50)")
                     .IsRequired()
                     .HasMaxLength(50);
                u.HasIndex("Name")
                    .IsUnique();

                // CreatedDateTime
                u.Property("CreatedDateTime")
                     .IsRequired();

                // CreatedUserId
                u.Property("CreatedUserId");

                // LastModifiedDateTime
                u.Property("LastModifiedDateTime");

                // LastModifiedUserId
                u.Property("LastModifiedUserId");

                // Deleted
                u.Property("Deleted")
                     .HasColumnType("bit")
                     .IsRequired();
            });

            modelBuilder.Entity<UserRole>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<UserRole>(u =>
            {
                u.HasKey("UserId", "RoleId");

                // Deleted
                u.Property("Deleted")
                     .HasColumnType("bit")
                     .IsRequired();
            });

            modelBuilder.Entity<Profile>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<Profile>(u =>
            {
                // UserId
                u.HasKey("UserId");
                u.Property("UserId")
                    .IsRequired();
                u.HasIndex("UserId")
                    .IsUnique();

                // FirstName
                u.Property("FirstName")
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(50);

                // LastName
                u.Property("LastName")
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(50);

                // BirthDate
                u.Property("BirthDate");

                // Mobile
                u.Property("Mobile")
                    .HasColumnType("nvarchar(11)")
                    .HasMaxLength(11);

                // Image
                u.Property("Image")
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                // CreatedDateTime
                u.Property("CreatedDateTime")
                     .IsRequired();

                // CreatedUserId
                u.Property("CreatedUserId");

                // LastModifiedDateTime
                u.Property("LastModifiedDateTime");

                // LastModifiedUserId
                u.Property("LastModifiedUserId");

                // Deleted
                u.Property("Deleted")
                     .HasColumnType("bit")
                     .IsRequired();
            });

            modelBuilder.Entity<Address>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<Address>(u =>
            {
                // Id
                u.HasKey("Id");

                // ProfileId
                u.Property("ProfileId")
                    .HasColumnType("bigint")
                    .IsRequired();

                // Title
                u.Property("Title")
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                // Description
                u.Property("Description")
                    .HasColumnType("nvarchar(Max)")
                    .IsRequired();

                // Location
                u.Property("Location")
                   .IsRequired();

                // IsDefault
                u.Property("IsDefault")
                    .HasColumnType("bit")
                    .IsRequired();

                // Deleted
                u.Property("Deleted")
                     .HasColumnType("bit")
                     .IsRequired();
            });

            modelBuilder.Entity<VerificationCode>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<VerificationCode>(u =>
            {
                // Id
                u.HasKey("Id");

                // UserName
                u.Property("UserName")
                    .HasColumnType("nvarchar(256)")
                    .IsRequired()
                    .HasMaxLength(256);

                // Code
                u.Property("Code")
                   .HasColumnType("nvarchar(4)")
                   .IsRequired()
                   .HasMaxLength(4);

                // GenerateDateTime
                u.Property("GenerateDateTime")
                   .IsRequired();

                // ExpirationDateTime
                u.Property("ExpirationDateTime")
                   .IsRequired();

                // Deleted
                u.Property("Deleted")
                    .HasColumnType("bit")
                    .IsRequired();
            });

            modelBuilder.Entity<Customer>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<Customer>(u =>
            {
                // UserId
                u.HasKey("UserId");
                u.Property("UserId")
                    .IsRequired();
                u.HasIndex("UserId")
                    .IsUnique();


                // CreatedDateTime
                u.Property("CreatedDateTime")
                     .IsRequired();

                // CreatedUserId
                u.Property("CreatedUserId");

                // LastModifiedDateTime
                u.Property("LastModifiedDateTime");

                // LastModifiedUserId
                u.Property("LastModifiedUserId");

                // Deleted
                u.Property("Deleted")
                     .HasColumnType("bit")
                     .IsRequired();

            });
            #endregion

            #region Products
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<Category>(u =>
            {
                // Id
                u.HasKey("Id");
                u.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                // Title
                u.Property("Title")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                // Image
                u.Property("Image")
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                // CreatedDateTime
                u.Property("CreatedDateTime")
                     .IsRequired();

                // CreatedUserId
                u.Property("CreatedUserId");

                // LastModifiedDateTime
                u.Property("LastModifiedDateTime");

                // LastModifiedUserId
                u.Property("LastModifiedUserId");

                // Deleted
                u.Property("Deleted")
                     .HasColumnType("bit")
                     .IsRequired();
            });

            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<Product>(u =>
            {
                // Id
                u.HasKey("Id");
                u.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                // CategoryId
                u.Property("CategoryId")
                    .HasColumnType("int")
                    .IsRequired();

                // "Title"
                u.Property("Title")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired();

                // Ingredients
                u.Property("Ingredients")
                    .HasColumnType("nvarchar(200)")
                    .HasMaxLength(200);

                // Price
                u.Property("Price")
                    .HasColumnType("bigint")
                    .IsRequired();

                // Image
                u.Property("Image")
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                // DiscountPercent
                u.Property("DiscountValue")
                    .HasColumnType("float")
                    .IsRequired();


                // DiscountValueType
                u.Property("DiscountValueType")
                    .HasColumnType("tinyint")
                    .IsRequired();

                // IsAvailable
                u.Property("IsAvailable")
                    .HasColumnType("bit")
                    .IsRequired();

                // CreatedDateTime
                u.Property("CreatedDateTime")
                     .IsRequired();

                // CreatedUserId
                u.Property("CreatedUserId");

                // LastModifiedDateTime
                u.Property("LastModifiedDateTime");

                // LastModifiedUserId
                u.Property("LastModifiedUserId");

                // Deleted
                u.Property("Deleted")
                     .HasColumnType("bit")
                     .IsRequired();
            });

            modelBuilder.Entity<ProductFavorite>(u =>
            {
                u.HasKey("ProductId", "UserId");
            });

            modelBuilder.Entity<ProductScore>(u =>
            {
                u.HasKey("ProductId", "UserId");

                u.Property<double>("Score")
                    .IsRequired();
            });

            #endregion

            #region Orders
            modelBuilder.Entity<ShoppingCart>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<ShoppingCart>(u =>
            {
                u.HasKey("CustomerId", "ProductId");

                // "Title"
                u.Property("Title")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired();

                // Ingredients
                u.Property("Ingredients")
                    .HasColumnType("nvarchar(200)")
                    .HasMaxLength(200);

                // Price
                u.Property("Price")
                    .HasColumnType("bigint")
                    .IsRequired();

                // DiscountAmount
                u.Property("DiscountAmount")
                    .HasColumnType("bigint")
                    .IsRequired();

                // DateTime
                u.Property("DateTime")
                     .IsRequired();

                // Image
                u.Property("Image")
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

            });
            #endregion
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await base.Database.BeginTransactionAsync();
        }

    }
}
