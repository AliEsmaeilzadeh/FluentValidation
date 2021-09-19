using Paraph_Food.Application.Services.Users.Commands.AddAddressService;
using Paraph_Food.Application.Services.Users.Commands.AddUserInRole;
using Paraph_Food.Application.Services.Users.Commands.ChargeCustomerCashService;
using Paraph_Food.Application.Services.Users.Commands.EditCustomerProfile;
using Paraph_Food.Application.Services.Users.Commands.RegisterCustomer;
using Paraph_Food.Application.Services.Users.Commands.RegisterUser;
using Paraph_Food.Application.Services.Users.Commands.RemoveVCode;
using Paraph_Food.Application.Services.Users.Commands.SetDefaultAddressService;
using Paraph_Food.Application.Services.Users.Commands.SetVCode;
using Paraph_Food.Application.Services.Users.Common;
using Paraph_Food.Application.Services.Users.Queries.CheckVCode;
using Paraph_Food.Application.Services.Users.Queries.CustomerLogin;
using Paraph_Food.Application.Services.Users.Queries.ExistThisUser;
using Paraph_Food.Application.Services.Users.Queries.GetCurrentUserId;
using Paraph_Food.Application.Services.Users.Queries.GetCustomerFinancialService;
using Paraph_Food.Application.Services.Users.Queries.GetCustomerInfoService;
using Paraph_Food.Application.Services.Users.Queries.GetCustomerProfile;
using Paraph_Food.Application.Services.Users.Queries.GetRole;
using Paraph_Food.Application.Services.Users.Queries.GetUser;
using Paraph_Food.Application.Services.Users.Queries.GetUserRoles;
using Paraph_Food.Application.Services.Users.Queries.UserLoginService;
using Paraph_Food.Application.Services.Users.Queries.VerifyCustomer;
using Paraph_Food.Application.Services.Users.Queries.VerifyUser;

namespace Paraph_Food.Application.Services.Users.FacadPattern
{
    public interface IUsersFacad
    {
        IRegisterUserService RegisterUser { get; }
        IExistThisUserService ExistThisUser { get; }
        IRegisterCustomerService RegisterCustomer { get; }
        IGetUserService GetUser { get; }
        IVerifyCustomerService VerifyCustomer { get; }
        IGetUserRolesService GetUserRoles { get; }
        IGenerateTokenService GenerateToken { get; }
        ICustomerLoginService CustomerLogin { get; }
        ISetVCodeService SetVCode { get; }
        ICheckVCodeService CheckVCode { get; }
        IRemoveVCodeService RemoveVCode { get; }
        IGetRoleService GetRole { get; }
        IAddUserInRoleService AddUserInRole { get; }
        IGetCustomerProfileService GetCustomerProfile { get; }
        IGetCurrentUserIdService GetCurrentUserId { get; }
        IEditCustomerProfileService EditCustomerProfile { get; }
        IVerifyUserService VerifyUser { get; }
        IUserLoginService UserLogin { get; }
        IGetCustomerFinancialService GetCustomerFinancial { get; }
        IGetCustomerInfoService GetCustomerInfo { get; }
        IChargeCustomerCashService ChargeCustomerCash { get; }
        IAddAddressService AddAddress { get; }
        ISetDefaultAddressService SetDefaultAddress { get; }
    }
}
