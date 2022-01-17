
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.ComTypes;
using Comman.Data.Model.DB;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ticket_System.ViewModel
{
    public class TicketModel : BaseViewModel
    {
        public IEnumerable<Ticket> QueryList { get; set; }
        public QueryFilter ResultFilter { get; set; }
        public class QueryFilter
        {
            /// <summary>
            ///流水編號
            ///</summary>
            [Required]
            [Column("Sno")]
            [DisplayName("流水編號")]
            public Guid Sno { get; set; }
            /// <summary>
            ///問題類型
            ///</summary>
            [Required]
            [Column("TicketType")]
            [DisplayName("問題類型")]
            public string TicketType { get; set; }

            public List<SelectListItem> DdlTicketType { get; set; }

            /// <summary>
            ///是否解決
            ///</summary>
            [Required]
            [Column("IsResolve")]
            [DisplayName("是否解決")]
            public bool IsResolve { get; set; }

            public string IsResolveText { get; set; }

            /// <summary>
            ///IsDelete
            ///</summary>
            [Required]
            [Column("IsDelete")]
            [DisplayName("IsDelete")]
            public bool IsDelete { get; set; }
        }


    }
}