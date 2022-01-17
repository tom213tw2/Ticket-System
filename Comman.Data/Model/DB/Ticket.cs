using System;
using System.ComponentModel;
using Dapper;

namespace Comman.Data.Model.DB
{
    [Table("Ticket", Schema = "dbo")]
    public class Ticket
    {
        /// <summary>
        ///流水編號
        ///</summary>
        [Required]
        [Column("Sno")]
        [DisplayName("流水編號")]
        [Key]
        public Guid Sno { get; set; }
        /// <summary>
        ///問題類型
        ///</summary>
        [Required]
        [Column("TicketType")]
        [DisplayName("問題類型")]
        public string TicketType { get; set; }
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