using System.Collections.Generic;

namespace Paraph_Food.Application.Services.Users.Queries.GetCustomerProfile
{
    public class CustomerProfileResultDto
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Image { get; set; }
        public List<CustomerAddressesResultDto> Addresses { get; set; }
    }
}
