using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WX.DMApi.Model
{
    /// <summary>
    /// 自卸车订单信息
    /// </summary>
    [Table("zxcorder_table")]
    public class ZxcOrderInfo
    {
        /// <summary>
        /// 订单id
        /// </summary>
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        [Column("OrderDate")]
        public string OrderDate { get; set; }
        /// <summary>
        /// 交货期
        /// </summary>
        [Column("DeliveryDate")]
        public string DeliveryDate { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        [Column("CustomerName")]
        public string CustomerName { get; set; }
        /// <summary>
        /// 客户联系方式
        /// </summary>
        [Column("CustomerPhone")]
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 生产号
        /// </summary>
        [Column("ProductNumber")]
        public string ProductNumber { get; set; }
        /// <summary>
        /// 底盘类型
        /// </summary>
        [Column("FloorType")]
        public string FloorType { get; set; }
        /// <summary>
        /// 底盘号
        /// </summary>
        [Column("FloorNumber")]
        public string FloorNumber { get; set; }
        /// <summary>
        /// 是否出厂
        /// </summary>
        [Column("LeaveFactory")]
        public string LeaveFactory { get; set; }
        /// <summary>
        /// 是否合格
        /// </summary>
        [Column("Qualified")]
        public string Qualified { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        [Column("Length")]
        public string Length { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        [Column("Width")]
        public string Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        [Column("Height")]
        public string Height { get; set; }
        /// <summary>
        /// 边板厚度
        /// </summary>
        [Column("SideBoardThickness")]
        public string SideBoardThickness { get; set; }
        /// <summary>
        /// 底板厚度
        /// </summary>
        [Column("FloorThickness")]
        public string FloorThickness { get; set; }
        /// <summary>
        /// 前挡厚度
        /// </summary>
        [Column("FrontboardThickness")]
        public string FrontboardThickness { get; set; }
        /// <summary>
        /// 后门厚度
        /// </summary>
        [Column("BackboardThickness")]
        public string BackboardThickness { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        [Column("Material")]
        public string Material { get; set; }
        /// <summary>
        /// 纵梁数
        /// </summary>
        [Column("CarlingNumber")]
        public string CarlingNumber { get; set; }
        /// <summary>
        /// 举升缸
        /// </summary>
        [Column("OilCylinder")]
        public string OilCylinder { get; set; }
        /// <summary>
        /// 其它要求
        /// </summary>
        [Column("Mark")]
        public string Mark { get; set; }
    }
}
