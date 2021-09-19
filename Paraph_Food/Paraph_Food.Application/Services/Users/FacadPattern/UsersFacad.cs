using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
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
using Paraph_Food.Domain.Common;

namespace Paraph_Food.Application.Services.Users.FacadPattern
{
    public class UsersFacad : IUsersFacad
    {
        private readonly IParaph_DbContext _dbContext;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly AppSettings _appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersFacad(IParaph_DbContext dbContext, 
                          IOptions<JwtIssuerOptions> jwtOptions, 
                          IOptions<AppSettings> appSettings,
                          IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _jwtOptions = jwtOptions.Value;
            _appSettings = appSettings.Value;
            _httpContextAccessor = httpContextAccessor;
        }


        private IRegisterUserService _registerUser;
        public IRegisterUserService RegisterUser
        {
            get
            {
                return _registerUser = _registerUser ?? new RegisterUserService(_dbContext, this);
            }
        }


        private IExistThisUserService _existThisUser;
        public IExistThisUserService ExistThisUser
        {
            get
            {
                return _existThisUser = _existThisUser ?? new ExistThisUserService(_dbContext);
            }
        }


        private IRegisterCustomerService _registerCustomer;
        public IRegisterCustomerService RegisterCustomer
        {
            get
            {
                return _registerCustomer = _registerCustomer ?? new RegisterCustomerService(_dbContext, this);
            }
        }


        private IGetUserService _getUser;
        public IGetUserService GetUser
        {
            get
            {
                return _getUser = _getUser ?? new GetUserService(_dbContext);
            }
        }


        private IVerifyCustomerService _verifyCustomer;
        public IVerifyCustomerService VerifyCustomer
        {
            get
            {
                return _verifyCustomer = _verifyCustomer ?? new VerifyCustomerService(this);
            }
        }


        private IGetUserRolesService _getUserRoles;
        public IGetUserRolesService GetUserRoles
        {
            get
            {
                return _getUserRoles = _getUserRoles ?? new GetUserRolesService(_dbContext);
            }
        }


        private IGenerateTokenService _generateToken;
        public IGenerateTokenService GenerateToken
        {
            get
            {
                return _generateToken = _generateToken ?? new GenerateTokenService(_jwtOptions, _appSettings);
            }
        }


        private ICustomerLoginService _customerLogin;
        public ICustomerLoginService CustomerLogin
        {
            get
            {
                return _customerLogin = _customerLogin ?? new CustomerLoginService(this);
            }
        }


        private ISetVCodeService _setVCode;
        public ISetVCodeService SetVCode
        {
            get
            {
                return _setVCode = _setVCode ?? new SetVCodeService(_dbContext);
            }
        }


        private ICheckVCodeService _checkVCode;
        public ICheckVCodeService CheckVCode
        {
            get
            {
                return _checkVCode = _checkVCode ?? new CheckVCodeService(_dbContext, this);
            }
        }


        private IRemoveVCodeService _removeVCode;
        public IRemoveVCodeService RemoveVCode
        {
            get
            {
                return _removeVCode = _removeVCode ?? new RemoveVCodeService(_dbContext);
            }
        }


        private IGetRoleService _getRole;
        public IGetRoleService GetRole
        {
            get
            {
                return _getRole = _getRole ?? new GetRoleService(_dbContext);
            }
        }


        private IAddUserInRoleService _addUserInRole;
        public IAddUserInRoleService AddUserInRole
        {
            get
            {
                return _addUserInRole = _addUserInRole ?? new AddUserInRoleService(_dbContext, this);
            }
        }


        private IGetCustomerProfileService _getCustomerProfile;
        public IGetCustomerProfileService GetCustomerProfile
        {
            get
            {
                return _getCustomerProfile = _getCustomerProfile ?? new GetCustomerProfileService(_dbContext,_appSettings);
            }
        }


        private IGetCurrentUserIdService _getCurrentUserId;
        public IGetCurrentUserIdService GetCurrentUserId
        {
            get
            {
                return _getCurrentUserId = _getCurrentUserId ?? new GetCurrentUserIdService(_httpContextAccessor);
            }
        }


        private IEditCustomerProfileService _editCustomerProfile;
        public IEditCustomerProfileService EditCustomerProfile
        {
            get
            {
                return _editCustomerProfile = _editCustomerProfile ?? new EditCustomerProfileService(_dbContext, _appSettings);
            }
        }


        private IVerifyUserService _verifyUser;
        public IVerifyUserService VerifyUser
        {
            get
            {
                return _verifyUser = _verifyUser ?? new VerifyUserService(_dbContext, this);
            }
        }


        private IUserLoginService _userLogin;
        public IUserLoginService UserLogin
        {
            get
            {
                return _userLogin = _userLogin ?? new UserLoginService(this);
            }
        }


        private IGetCustomerFinancialService _getFinancial;
        public IGetCustomerFinancialService GetCustomerFinancial
        {
            get
            {
                return _getFinancial = _getFinancial ?? new GetCustomerFinancialService(_dbContext);
            }
        }


        private IGetCustomerInfoService _getCustomerInfo;
        public IGetCustomerInfoService GetCustomerInfo
        {
            get
            {
                return _getCustomerInfo = _getCustomerInfo ?? new GetCustomerInfoService(this);
            }
        }


        private IChargeCustomerCashService _chargeCustomerCash;
        public IChargeCustomerCashService ChargeCustomerCash
        {
            get
            {
                return _chargeCustomerCash = _chargeCustomerCash ?? new ChargeCustomerCashService(_dbContext);
            }
        }


        private IAddAddressService _addAddress;
        public IAddAddressService AddAddress
        {
            get
            {
                return _addAddress = _addAddress ?? new AddAddressService(_dbContext,_appSettings);
            }
        }


        private ISetDefaultAddressService _setDefaultAddress;
        public ISetDefaultAddressService SetDefaultAddress
        {
            get
            {
                return _setDefaultAddress = _setDefaultAddress ?? new SetDefaultAddressService(_dbContext);
            }
        }

    }
}
