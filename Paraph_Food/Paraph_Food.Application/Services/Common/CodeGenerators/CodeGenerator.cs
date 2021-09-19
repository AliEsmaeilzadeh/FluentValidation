using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Common.CodeGenerators
{
    public class CodeGenerator
    {
        public static string generateNumeralCode(int from, int to)
        {
            Random rnd = new Random();
            int RandomNo = rnd.Next(from, to);

            return RandomNo.ToString();
        }
    }
}
