using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using Comman.Data.Model.DB;
using Comman.Data.Repository;
using Comman.Data.Repository;
using Microsoft.AspNetCore.Http;
using Ticket_System.UserPermission;
using Ticket_System.ViewModel;
using XFRS.Data;

namespace Ticket_System.Service
{
    public class UserService
    {
        private LoginModel _loginModel;
        private Guid Accountid;
        public UserService(LoginModel model)
        {
            this._loginModel = model;
        }

        public UserService(Guid Account)
        {
            this.Accountid = Account;
        }
        public (bool, string,Login) LoginIsSuccess()
        {
            (bool isSuccess, string Errormsg,Login login) aa;
            aa.isSuccess = true;
            aa.Errormsg = "";
            aa.login = new Login();
            LoginRepository repository = new LoginRepository(QueryRepository.CFRSContext);
            aa.login = repository.GetList("where UserID=@UserID and Pwd=@Pwd", new { UserID = _loginModel.UserID, Pwd = _loginModel.Pwd }).FirstOrDefault();
            if (aa.login == null)
            {
                aa.isSuccess = false;
                aa.Errormsg = "查無帳號!";

            }
          


            return aa;

        }

        public BaseViewModel GetAccountId()
        {
            BaseViewModel viewModel = new BaseViewModel();
            LoginRepository repo = new LoginRepository(QueryRepository.CFRSContext);
            var data = repo.Get(Accountid, null);
            if (data != null)
            {
                viewModel.AccountID = data.Sno;
                var accountType = data.LoginType;
                switch (accountType)
                {
                    case "1":
                        viewModel.UserPermissionUser = new QAPermission();
                        break;
                    case "2":
                        viewModel.UserPermissionUser = new RDPermission();
                        break;
                    case "3":
                        viewModel.UserPermissionUser = new PMPermission();
                        break;
                    case "4":
                        viewModel.UserPermissionUser = new AdministratorPermission();
                        break;

                }

                viewModel.AccountType = accountType;
                return viewModel;
            }

            return null;
        }
    }
}