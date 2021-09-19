using Paraph_Food.Application.Common;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Commands.EditCustomerProfile
{
    public interface IEditCustomerProfileService
    {
        Task<CommandResultDto> ExecuteAsync(long userId, EditCustomerProfileDto newProfile);
    }
}
