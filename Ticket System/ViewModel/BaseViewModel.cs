using System;
using Ticket_System.Interface;

namespace Ticket_System.ViewModel
{
    public class BaseViewModel
    {
        public IUser UserPermissionUser { get; set; }
        public Guid AccountID { get; set; }
        public string AccountType { get; set; }
    }
}