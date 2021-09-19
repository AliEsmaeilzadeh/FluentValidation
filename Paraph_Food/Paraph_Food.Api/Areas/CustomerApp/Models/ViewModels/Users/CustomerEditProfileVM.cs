using Paraph_Food.Application.Services.Common.FileUploader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paraph_Food.Api.Areas.CustomerApp.Models.ViewModels.Users
{
    public class CustomerEditProfileVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public FileModel Image { get; set; }

    }
}
