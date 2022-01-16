using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comman.Dapper;
using Octon.ConfigSettings;

namespace XFRS.Data
{
    public static class QueryRepository
    {
        public static IRepositoryContext CFRSContext => new DapperContext(getConnStr("CFRS"));

        private static string getConnStr(string ConStrName, bool IsEncryption = true)
        {
            string ServiceConnectUrl = ConfigurationManager.AppSettings["ServiceConnectUrl"] == null ? "" : ConfigurationManager.AppSettings["ServiceConnectUrl"].ToString();
            string cnStr = "";
            string ServiceConnectStrName = "CFRS";
            string resName = "DBEntity";
            switch (ConStrName)
            {
                case "DBEntities":
                case "CFRS.Data.Properties.Settings.CFRSConnectionString":
                case "elmah-sqlserver":
                    ServiceConnectStrName = "CFRS";
                    resName = "DBEntity";
                    break;
                case "CTI":
                    ServiceConnectStrName = "CTI";
                    resName = "CTI";
                    break;
                case "MMCCEntities":
                    ServiceConnectStrName = "ocmp";
                    resName = "MMCCEntity";
                    break;
            }
            if (!String.IsNullOrEmpty(ServiceConnectUrl))
            {
                DBInfo info = ConfigSettigns.GetDBSetting("DB", ServiceConnectStrName);
                if (info.Code == "0000")
                {
                    cnStr = info.ConnStr;
                    SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder
                    {
                        ConnectionString = cnStr,
                        MultipleActiveResultSets = true,
                        ConnectTimeout = 360,
                        MaxPoolSize = 200,
                        ApplicationName = "CFRS",
                        LoadBalanceTimeout = 60,
                        Pooling = false
                    };


                    cnStr = scsb.ToString();

                }
            }
            else
            {
                //設定檔之連線字串應加密
                cnStr = ConfigurationManager.ConnectionStrings[ConStrName].ConnectionString;
                //自動偵測，支援加密及未加密的連線字串，測時不加密，上線時再加密
                //在連線字串找到metadata字樣表示為加密字串
                if (IsEncryption)
                {
                    cnStr = Encoding.UTF8.GetString(Convert.FromBase64String(cnStr));
                }
            }

            return cnStr;
        }
    }
}
