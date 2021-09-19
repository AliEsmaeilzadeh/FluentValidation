using Paraph_Food.Application.Services.Users.FacadPattern;
using Paraph_Food.Application.Services.Users.Queries.GetCustomerFinancialService;
using Paraph_Food.Application.Services.Users.Queries.GetCustomerProfile;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetCustomerInfoService
{
    public class GetCustomerInfoService : IGetCustomerInfoService
    {
        private readonly IUsersFacad _userServices;
        public GetCustomerInfoService(IUsersFacad userServices)
        {
            _userServices = userServices;
        }
        public async Task<CustomerInfoResultDto> ByUserId(long userId)
        {
            // دریافت اطلاعات پروفایل
            var customerProfile = await _userServices.GetCustomerProfile.ByUserId(userId);

            // دریافت اطلاعات مالی
            var customerFinancial = await _userServices.GetCustomerFinancial.ByUserId(userId);

            return new CustomerInfoResultDto()
            {
                Profile = new CustomerProfileResultDto()
                {
                    UserId = customerProfile.UserId,
                    FirstName = customerProfile.FirstName,
                    LastName = customerProfile.LastName,
                    BirthDate = customerProfile.BirthDate,
                    Image = customerProfile.Image,
                    Addresses = customerProfile.Addresses,
                },
                Financial = new CustomerFinancialResultDto()
                {
                    CashBalance = customerFinancial.CashBalance,
                    Score = customerFinancial.Score,
                },
            };
        }
    }
}
