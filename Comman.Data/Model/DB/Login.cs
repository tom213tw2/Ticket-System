using System;
using System.ComponentModel;
using Dapper;

namespace Comman.Data.Model.DB
{
    [Table("Login", Schema = "dbo")]
    public class Login
    {
        /// <summary>
        ///Sno
        ///</summary>
        [Required]
        [Column("Sno")]
        [DisplayName("Sno")]
        public Guid Sno { get; set; }
        /// <summary>
        ///UserID
        ///</summary>
        [Required]
        [Column("UserID")]
        [DisplayName("UserID")]
        public string UserID { get; set; }
        /// <summary>
        ///Pwd
        ///</summary>
        [Required]
        [Column("Pwd")]
        [DisplayName("Pwd")]
        public string Pwd { get; set; }
        /// <summary>
        ///IsDelete
        ///</summary>
        [Required]
        [Column("IsDelete")]
        [DisplayName("IsDelete")]
        public bool IsDelete { get; set; }
    }
}