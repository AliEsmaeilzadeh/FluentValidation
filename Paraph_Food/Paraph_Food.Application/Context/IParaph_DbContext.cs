using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Paraph_Food.Domain.Enities.Orders;
using Paraph_Food.Domain.Enities.Products;
using Paraph_Food.Domain.Enities.Users;
using System.Threading;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Context
{
    public interface IParaph_DbContext
    {
        #region Users
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<Profile> Profiles { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<VerificationCode> VerificationCodes { get; set; }
        DbSet<Customer> Customers { get; set; }
        #endregion

        #region Products
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductFavorite> ProductFavorites { get; set; }
        DbSet<ProductScore> ProductScores { get; set; }

        #endregion

        #region Orders
        DbSet<ShoppingCart> ShoppingCarts { get; set; }
        #endregion

        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}
