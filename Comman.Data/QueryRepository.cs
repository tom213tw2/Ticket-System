using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comman.Dapper;
using Microsoft.Extensions.Configuration;

namespace XFRS.Data
{
    public static class QueryRepository
    {
        private static string ProviderInvarientName = "Microsoft.Data.SqlClient";
     
        public static IRepositoryContext CFRSContext => new DapperContext("DATA SOURCE=172.16.5.220;PASSWORD=octon168;PERSIST SECURITY INFO=True;USER ID=sa;INITIAL CATALOG=CFRS;");

    


    }
}
