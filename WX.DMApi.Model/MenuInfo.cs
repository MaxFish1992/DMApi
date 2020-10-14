using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WX.DMApi.Model
{
    [Table("menu_table")]
    public class MenuInfo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 路由
        /// </summary>
        [Column("Router")]
        public string Router { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }
        /// <summary>
        /// 所需权限
        /// </summary>
        [Column("Authority")]
        public int Authority { get; set; }
    }
}
