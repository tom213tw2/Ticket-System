using System;
using System.ComponentModel;
using Dapper;

namespace Comman.Data.Model.DB
{
    [Table("Login", Schema = "dbo")]
    public class Login
    {
        /// <summary>
        ///流水編號
        ///</summary>
        [Key]
        [Required]
        [Column("Sno")]
        [DisplayName("流水編號")]
        public Guid Sno { get; set; }
        /// <summary>
        ///帳號
        ///</summary>
        [Required]
        [Column("UserID")]
        [DisplayName("帳號")]
        public string UserID { get; set; }
        /// <summary>
        ///密碼
        ///</summary>
        [Required]
        [Column("Pwd")]
        [DisplayName("密碼")]
        public string Pwd { get; set; }
        /// <summary>
        ///登入類型
        ///</summary>
        [Required]
        [Column("LoginType")]
        [DisplayName("登入類型")]
        public string LoginType { get; set; }
        /// <summary>
        ///是否刪除
        ///</summary>
        [Required]
        [Column("IsDelete")]
        [DisplayName("是否刪除")]
        public bool IsDelete { get; set; }
    }
}