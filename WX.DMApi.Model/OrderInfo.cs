using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WX.DMApi.Model
{
    /// <summary>
    /// 订单信息
    /// </summary>
    [Table("Order_Table")]
    public class OrderInfo
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
        /// 大架号
        /// </summary>
        [Column("VIN")]
        public string VIN { get; set; }
        /// <summary>
        /// 出图
        /// </summary>
        [Column("Drawing")]
        public string Drawing { get; set; }
        /// <summary>
        /// 是否下料
        /// </summary>
        [Column("Blanking")]
        public string Blanking { get; set; }
        /// <summary>
        /// 是否合箱
        /// </summary>
        [Column("CloseCompartment")]
        public string CloseCompartment { get; set; }
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
    }
}
