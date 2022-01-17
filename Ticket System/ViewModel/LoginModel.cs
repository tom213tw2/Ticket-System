using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using Comman.Data.Model.DB;
using Ticket_System.Interface;

namespace Ticket_System.ViewModel
{
    public class LoginModel:BaseViewModel
    {
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



    }

   
}