using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WX.DMApi.Model
{
    [Table("new_zxcorder_table")]
    public class NewZxcOrderInfo
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
        /// 生产号
        /// </summary>
        [Column("ProductNumber")]
        public string ProductNumber { get; set; }
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
        /// 底盘类型
        /// </summary>
        [Column("FloorType")]
        public string FloorType { get; set; }
        /// <summary>
        /// 底盘号
        /// </summary>
        [Column("VIN")]
        public string VIN { get; set; }
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
        /// 加高板高度
        /// </summary>
        [Column("Heightening")]
        public string Heightening { get; set; }
        /// <summary>
        /// 举升缸
        /// </summary>
        [Column("OilCylinder")]
        public string OilCylinder { get; set; }
        /// <summary>
        /// 底板厚度
        /// </summary>
        [Column("DThickness")]
        public string DThickness { get; set; }
        /// <summary>
        /// 底板材质
        /// </summary>
        [Column("DMaterial")]
        public string DMaterial { get; set; }
        /// <summary>
        /// 底板纵梁数
        /// </summary>
        [Column("DCatlingNumber")]
        public string DCatlingNumber { get; set; }
        /// <summary>
        /// 底板加强筋
        /// </summary>
        [Column("DReinRib")]
        public string DReinRib { get; set; }
        /// <summary>
        /// 底板尾座下铺铁板厚度
        /// </summary>
        [Column("DStailIronThickness")]
        public string DStailIronThickness { get; set; }
        /// <summary>
        /// 副梁尾座数量
        /// </summary>
        [Column("FStailNumber")]
        public string FStailNumber { get; set; }
        /// <summary>
        /// 副梁尾座下铺铁板
        /// </summary>
        [Column("FStailIron")]
        public string FStailIron { get; set; }
        /// <summary>
        /// 边板厚度
        /// </summary>
        [Column("BThickness")]
        public string BThickness { get; set; }
        /// <summary>
        /// 边板材质
        /// </summary>
        [Column("BMaterial")]
        public string BMaterial { get; set; }
        /// <summary>
        /// 立柱厚度
        /// </summary>
        [Column("BPostThickness")]
        public string BPostThickness { get; set; }
        /// <summary>
        /// 立柱材质
        /// </summary>
        [Column("BPostMaterial")]
        public string BPostMaterial { get; set; }
        /// <summary>
        /// 上边梁
        /// </summary>
        [Column("BAbove")]
        public string BAbove { get; set; }
        /// <summary>
        /// 下边梁
        /// </summary>
        [Column("BBelow")]
        public string BBelow { get; set; }
        /// <summary>
        /// 边板加强筋
        /// </summary>
        [Column("BReinRib")]
        public string BReinRib { get; set; }
        /// <summary>
        /// 前挡厚度
        /// </summary>
        [Column("QThickness")]
        public string QThickness { get; set; }
        /// <summary>
        /// 前挡材质
        /// </summary>
        [Column("QMaterial")]
        public string QMaterial { get; set; }
        /// <summary>
        /// 前挡备胎安装方式
        /// </summary>
        [Column("QSpareTireWay")]
        public string QSpareTireWay { get; set; }
        /// <summary>
        /// 前挡加强筋规格
        /// </summary>
        [Column("QReinRib")]
        public string QReinRib { get; set; }
        /// <summary>
        /// 后门厚度
        /// </summary>
        [Column("HThickness")]
        public string HThickness { get; set; }
        /// <summary>
        /// 后门边框
        /// </summary>
        [Column("HBorder")]
        public string HBorder { get; set; }
        /// <summary>
        /// 后门材质
        /// </summary>
        [Column("HMaterial")]
        public string HMaterial { get; set; }
        /// <summary>
        /// 竖筋
        /// </summary>
        [Column("HVerticalRein")]
        public string HVerticalRein { get; set; }
        /// <summary>
        /// 横筋
        /// </summary>
        [Column("HHorizontalRein")]
        public string HHorizontalRein { get; set; }
        /// <summary>
        /// 后门推车板
        /// </summary>
        [Column("HPushBoard")]
        public string HPushBoard { get; set; }
        /// <summary>
        /// 后门加角钢
        /// </summary>
        [Column("H100AngleIron")]
        public string H100AngleIron { get; set; }
        /// <summary>
        /// 其它要求
        /// </summary>
        [Column("OtherRequirements")]
        public string OtherRequirements { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("Mark")]
        public string Mark { get; set; }
    }
}
