using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WX.DMApi.Model
{
    /// <summary>
    /// 自卸车生产信息
    /// </summary>
    [Table("zxcproduct_table")]
    public class ZxcProductInfo
    {
        /// <summary>
        /// 订单id
        /// </summary>
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        [Column("ProductDate")]
        public DateTime? ProductDate { get; set; }
        /// <summary>
        /// 合同号
        /// </summary>
        [Column("ContractNum")]
        public string ContractNum { get; set; }
        /// <summary>
        /// VIN号
        /// </summary>
        [Column("VINNum")]
        public string VINNum { get; set; }
        /// <summary>
        /// 下料
        /// </summary>
        [Column("Blanking")]
        public string Blanking { get; set; }
        /// <summary>
        /// 边板
        /// </summary>
        [Column("SideBoard")]
        public string SideBoard { get; set; }
        /// <summary>
        /// 底板
        /// </summary>
        [Column("Floor")]
        public string Floor { get; set; }
        /// <summary>
        /// 前挡
        /// </summary>
        [Column("FrontDoor")]
        public string FrontDoor { get; set; }
        /// <summary>
        /// 后门
        /// </summary>
        [Column("BackDoor")]
        public string BackDoor { get; set; }
        /// <summary>
        /// 合箱
        /// </summary>
        [Column("CloseCompartments")]
        public string CloseCompartments { get; set; }
        /// <summary>
        /// 总装厢
        /// </summary>
        [Column("FinalAssembly")]
        public string FinalAssembly { get; set; }
        /// <summary>
        /// 喷漆
        /// </summary>
        [Column("SprayPaint")]
        public string SprayPaint { get; set; }
        /// <summary>
        /// 小件
        /// </summary>
        [Column("SmallParts")]
        public string SmallParts { get; set; }
    }
}
