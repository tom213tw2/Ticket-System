using System;
using System.Collections.Generic;
using System.Linq;
using Comman.Data;
using Comman.Data.Model.DB;
using Comman.Data.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ticket_System.ViewModel;
using XFRS.Data;

namespace Ticket_System.Service
{
    public class TicketService
    {
        private readonly Guid _id;
        private BaseViewModel _baseViewModel=new BaseViewModel();

        public TicketService(Guid id)
        {
            this._id = id;
            this._baseViewModel = new UserService(id).GetAccountId();
        }

        public TicketModel.QueryFilter GetAllDll(TicketModel.QueryFilter filter)
        {
            if (filter == null)
            {
                TicketModel.QueryFilter _filter = new TicketModel.QueryFilter();
                _filter.DdlTicketType = GetDdlTicketType("");
                return _filter;
            }
            else
            {
                filter.DdlTicketType = GetDdlTicketType(filter.TicketType);
                return filter;
            }

        }

        public TicketModel GetIndexData(Guid id)
        {
            TicketModel model = new TicketModel();
            var repo = new TicketRepository(QueryRepository.CFRSContext);
            var data = repo.GetList("where Sno=@Sno", new { Sno = id }).Select(s => new TicketModel.QueryFilter
            {
                Sno = s.Sno,
                IsResolveText = s.IsResolve == true ? "是" : "否",
                IsResolve = s.IsResolve,
                IsDelete = s.IsDelete,
                TicketType = s.TicketType

            });

            var queryFilters = data.ToList();
            foreach (var item in queryFilters)
            {
                switch (item.TicketType)
                {
                    case "1":
                        item.TicketType = "bug";
                        break;
                    case "2":
                        item.TicketType = "Test";
                        break;
                    case "3":
                        item.TicketType = "Feature Request";
                        break;
                }
            }
            model.ResultFilter = queryFilters.FirstOrDefault();


            _baseViewModel.CopyPropertiesTo(model);
            return model;
        }

        public void ResolveIssue(TicketModel.QueryFilter filter)
        {
            var repo = new TicketRepository(QueryRepository.CFRSContext);
            var data = repo.Get(filter.Sno, null);
            data.IsResolve = true;
            repo.Update(data);
        }
        public TicketModel GetList()
        {
            var service = new UserService(_id).GetAccountId();
            var model = new TicketModel();
            var repo = new TicketRepository(QueryRepository.CFRSContext);
            model.QueryList = repo.GetList("where IsDelete=@IsDelete ", new { IsDelete = false });
            foreach (var itemTicket in model.QueryList)
            {
                switch (itemTicket.TicketType)
                {
                    case "1":
                        itemTicket.TicketType = "bug";
                        break;
                    case "2":
                        itemTicket.TicketType = "Test";
                        break;
                    case "3":
                        itemTicket.TicketType = "Feature Request";
                        break;
                }

                itemTicket.IsResolveText = itemTicket.IsResolve == true ? "是" : "否";
            }
            _baseViewModel.CopyPropertiesTo(model);
            return model;
        }

        private List<SelectListItem> GetDdlTicketType(string listItem)
        {
            var service = new UserService(_id).GetAccountId();
            List<SelectListItem> listItems = new List<SelectListItem>();
            if (_baseViewModel.UserPermissionUser.CanCreateErrorTask())
            {
                listItems.Add(new SelectListItem
                {
                    Value = "1",
                    Text = "bug"
                });
            }

            if (_baseViewModel.UserPermissionUser.CanCreateTestCase())
            {
                listItems.Add(new SelectListItem
                {
                    Value = "2",
                    Text = "Test Case"
                });
            }

            if (_baseViewModel.UserPermissionUser.CanFeatureRequest())
            {
                listItems.Add(new SelectListItem
                {
                    Value = "3",
                    Text = "Feature Request"
                });
            }

            if (listItems.Any(s => s.Value.Equals(listItem)))
            {
                listItems.FirstOrDefault(s => s.Value.Equals(listItem))!.Selected = true;
            }

            return listItems;
        }
    }
}