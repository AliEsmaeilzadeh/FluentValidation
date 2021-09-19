using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetCurrentUserId
{
    public class GetCurrentUserIdService : IGetCurrentUserIdService
    {
        private readonly IHttpContextAccessor _httpContexAccessor;
        public GetCurrentUserIdService(IHttpContextAccessor httpContexAccessor)
        {
            _httpContexAccessor = httpContexAccessor;
        }

        public long? Execute()
        {
            var userId = _httpContexAccessor.HttpContext.User.Claims?.FirstOrDefault()?.Value;
            if (!string.IsNullOrWhiteSpace(userId))
                return Convert.ToInt64(userId);

            return null;
        }
    }
}
