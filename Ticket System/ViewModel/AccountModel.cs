using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comman.Data.Model.DB;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ticket_System.ViewModel
{
    public class AccountModel:BaseViewModel
    {
        public List<Login> QueryList { get; set; }

        public Result PageResult { get; set; }

        public class Result
        {
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
            /// 登入類型下拉選單
            /// </summary>
            public List<SelectListItem> DdlLoginType { get; set; }
        }
    }
 
}