using Paraph_Food.Application.Services.Common.FileUploader;
using System;

namespace Paraph_Food.Application.Services.Users.Commands.EditCustomerProfile
{
    public class EditCustomerProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public FileModel Image { get; set; }
    }
}
