using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WX.DMApi.Model
{
    /// <summary>
    /// 半挂车订单信息
    /// </summary>
    [Table("order_table")]
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
        /// 边板材质
        /// </summary>
        [Column("SideBoardMaterial")]
        public string SideBoardMaterial { get; set; }
        /// <summary>
        /// 底板厚度
        /// </summary>
        [Column("FloorThickness")]
        public string FloorThickness { get; set; }
        /// <summary>
        /// 底板材质
        /// </summary>
        [Column("FloorMaterial")]
        public string FloorMaterial { get; set; }
        /// <summary>
        /// 车桥
        /// </summary>
        [Column("Axle")]
        public string Axle { get; set; }
        /// <summary>
        /// 是否有自动调整臂
        /// </summary>
        [Column("HasAdjustingArm")]
        public string HasAdjustingArm { get; set; }
        /// <summary>
        /// 是否有空气悬架
        /// </summary>
        [Column("HasAirSuspension")]
        public string HasAirSuspension { get; set; }
        /// <summary>
        /// ABS类型
        /// </summary>
        [Column("ABS")]
        public string ABS { get; set; }
        /// <summary>
        /// 牵引销类型,50或者90
        /// </summary>
        [Column("TractionPin")]
        public string TractionPin { get; set; }
        /// <summary>
        /// 轮胎品牌
        /// </summary>
        [Column("TireBrand")]
        public string TireBrand { get; set; }
        /// <summary>
        /// 轮胎形状
        /// </summary>
        [Column("TireShape")]
        public string TireShape { get; set; }
        /// <summary>
        /// 轮胎数量
        /// </summary>
        [Column("TireNum")]
        public string TireNum { get; set; }
        /// <summary>
        /// 钢圈类型
        /// </summary>
        [Column("SteelRingMaterial")]
        public string SteelRingMaterial { get; set; }
        /// <summary>
        /// 钢圈数量
        /// </summary>
        [Column("SteelRingNum")]
        public string SteelRingNum { get; set; }
        /// <summary>
        /// 板簧品牌
        /// </summary>
        [Column("PlateSpringBrand")]
        public string PlateSpringBrand { get; set; }
        /// <summary>
        /// 板簧厚度
        /// </summary>
        [Column("PlateSpringThickness")]
        public string PlateSpringThickness { get; set; }
        /// <summary>
        /// 板簧片数
        /// </summary>
        [Column("PlateSpringNum")]
        public string PlateSpringNum { get; set; }
        /// <summary>
        /// 液压品牌
        /// </summary>
        [Column("HydraulicBrand")]
        public string HydraulicBrand { get; set; }
        /// <summary>
        /// 液压型号
        /// </summary>
        [Column("HydraulicModel")]
        public string HydraulicModel { get; set; }
        /// <summary>
        /// 后门类型
        /// </summary>
        [Column("BackDoorType")]
        public string BackDoorType { get; set; }
        /// <summary>
        /// 车厢颜色
        /// </summary>
        [Column("CarriageColor")]
        public string CarriageColor { get; set; }
        /// <summary>
        /// 其它要求
        /// </summary>
        [Column("Mark")]
        public string Mark { get; set; }
    }
}
