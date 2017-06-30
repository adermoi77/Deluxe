using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Deluxe.Models.UserInfo
{
    [Table("UserInfo")]
   public class UserInfos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]//主键和自增  
        public int Id { get; set; }

        public string UserName { get; set; }

        public string  PassWord { get; set; }

    }
}
