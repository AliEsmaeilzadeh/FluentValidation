using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Paraph_Food.Application.Common.AppSettings
{
    public class AppSettings
    {
        public string JWTSecretKey { get; set; }
        public string FilesBasePath { get; set; }
        public int GeographySRID { get; set; }
        public Urls Urls { get; set; }
        public SwaggerEndpoint SwaggerEndpoint { get; set; }
        public Files Files { get; set; }
    }
}
