using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WX.DMApi.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("User_Table")]
    public class UserInfo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Column("UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Column("Password")]
        public string Password { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        [Column("Authority")]
        public int Authority { get; set; }
    }
}
