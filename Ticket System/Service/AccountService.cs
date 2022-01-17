using System;
using System.Collections.Generic;
using System.Linq;
using Comman.Data;
using Comman.Data.Model.DB;
using Comman.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ticket_System.ViewModel;
using XFRS.Data;

namespace Ticket_System.Service
{
    public class AccountService
    {
        private readonly Guid _id;

        public AccountService(Guid id)
        {
            this._id = id;
        }

        public AccountModel GetList(AccountModel model)
        {
            AccountModel account = new AccountModel();
            var service = new UserService(_id).GetAccountId();
            var repo = new LoginRepository(QueryRepository.CFRSContext);
            var data = repo.GetList("where IsDelete=@IsDelete", new { IsDelete = 0 }).ToList();
            foreach (var item in data)
            {
                switch (item.LoginType)
                {
                    case "1":
                        item.LoginType = "QA";
                        break;
                    case "2":
                        item.LoginType = "RD";
                        break;
                    case "3":
                        item.LoginType = "PM";
                        break;
                    case "4":
                        item.LoginType = "Administrator";
                        break;
                }
            }

            account.QueryList = data;
            service.CopyPropertiesTo(account);
            return account;
        }

        public AccountModel GetDetail(Guid guid)
        {
            AccountModel result = new AccountModel();
            var repo = new LoginRepository(QueryRepository.CFRSContext);
            var data = repo.GetList("where Sno=@Sno", new { Sno = guid }).Select(s => new AccountModel.Result
            {
                Sno = s.Sno,
                UserID = s.UserID,
                Pwd = s.Pwd,
                LoginType = s.LoginType
                
            }).SingleOrDefault();
            result.PageResult = data;
         
            GetAllDll(result.PageResult);
            UserService service = new UserService(_id);
            service.GetAccountId().CopyPropertiesTo(result);
            return result;
        }
      
        public AccountModel.Result UpdateData(AccountModel.Result result)
        {
            AccountModel.Result _result = result;
            LoginRepository repo = new LoginRepository(QueryRepository.CFRSContext);
            var login = new Login()
            {
                Sno = result.Sno,
                Pwd = result.Pwd,
                UserID = result.UserID,
                LoginType = result.LoginType
            };
            if (login.Sno==Guid.Empty)
            {
                login.IsDelete=false;
                repo.Insert(login);
            }
            else
            {
                repo.Update(login);
            }
          
            return result;
        }

        public AccountModel GetInsert()
        {
            AccountModel model = new AccountModel();
            model.PageResult = GetAllDll(null);
            UserService service = new UserService(_id);
            service.GetAccountId().CopyPropertiesTo(model);
            return model;
        }

        public void DeleteData(Guid guid)
        {
            LoginRepository repo = new LoginRepository(QueryRepository.CFRSContext);
            var data = repo.Get(guid, null);
            data.IsDelete = true;
            repo.Update(data);
        }
        public AccountModel.Result GetAllDll(AccountModel.Result result)
        {
         
            if (result!=null)
            {
                result.DdlLoginType = DdlLoginType(result.LoginType);
                return result;
            }
            else
            {
                AccountModel.Result _result = new AccountModel.Result();
                _result.DdlLoginType= DdlLoginType("");
                return _result;
            }
        }
        /// <summary>
        /// 綁訂下拉選單
        /// </summary>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        private List<SelectListItem> DdlLoginType(string itemValue)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "1",
                    Text = "QA"
                },
                new SelectListItem
                {
                    Value = "2",
                    Text = "RD"
                },
                new SelectListItem
                {
                    Value = "3",
                    Text = "PM"
                },
                new SelectListItem
                {
                    Value = "4",
                    Text = "Administrator"
                }
            };
            if (items.Any(s => s.Value.Equals(itemValue)))
                items.FirstOrDefault(s => s.Value.Equals(itemValue))!.Selected = true;
            return items;
        }

    }
}