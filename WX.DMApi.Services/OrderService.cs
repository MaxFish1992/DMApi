using System;
using System.Collections.Generic;
using System.Linq;
using WX.DMApi.IServices;
using WX.DMApi.Model;
using WX.DMApi.Services.DataContext;

namespace WX.DMApi.Services
{
    /// <summary>
    /// 订单数据服务
    /// </summary>
    public class OrderService : IOrderService
    {
        public OrderContext Context;
        public OrderService(OrderContext context)
        {
            Context = context;
        }
        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderInfo> GetAll()
        {
            return Context.Orders.ToList();
        }
        /// <summary>
        /// 根据VIN获取订单信息
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public OrderInfo GetSingle(string vin)
        {
            return Context.Orders.SingleOrDefault(x => x.VIN.Equals(vin));
        }
        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public bool Add(OrderInfo orderInfo)
        {
            Context.Orders.Add(orderInfo);
            return Context.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public bool Delete(OrderInfo orderInfo)
        {
            var oldProduct = Context.Orders.SingleOrDefault(x => x.VIN.Equals(orderInfo.VIN));
            if (oldProduct != null)
                Context.Orders.Remove(oldProduct);
            return Context.SaveChanges() > 0;
        }
        /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public bool Update(OrderInfo orderInfo)
        {
            var state = false;
            var old = Context.Orders.SingleOrDefault(x => x.VIN.Equals(orderInfo.VIN));

            if (old != null)
            {
                //old.VIN = orderInfo.VIN;
                old.ProductNumber = orderInfo.ProductNumber;
                old.OrderDate = orderInfo.OrderDate;
                old.DeliveryDate = orderInfo.DeliveryDate;
                old.CustomerName = orderInfo.CustomerName;
                old.CustomerPhone = orderInfo.CustomerPhone;
                old.Drawing = orderInfo.Drawing;
                old.Blanking = orderInfo.Blanking;
                old.CloseCompartment = orderInfo.CloseCompartment;
                old.Qualified = orderInfo.Qualified;
                old.LeaveFactory = orderInfo.LeaveFactory;
                old.ABS = orderInfo.ABS;
                old.Axle = orderInfo.Axle;
                old.BackDoorType = orderInfo.BackDoorType;
                old.CarriageColor = orderInfo.CarriageColor;
                old.FloorMaterial = orderInfo.FloorMaterial;
                old.FloorThickness = orderInfo.FloorThickness;
                old.HasAdjustingArm = orderInfo.HasAdjustingArm;
                old.HasAirSuspension = orderInfo.HasAirSuspension;
                old.Height = orderInfo.Height;
                old.HydraulicBrand = orderInfo.HydraulicBrand;
                old.HydraulicModel = orderInfo.HydraulicModel;
                old.Length = orderInfo.Length;
                old.Width = orderInfo.Width;
                old.Mark = orderInfo.Mark;
                old.PlateSpringBrand = orderInfo.PlateSpringBrand;
                old.PlateSpringThickness = orderInfo.PlateSpringThickness;
                old.PlateSpringNum = orderInfo.PlateSpringNum;
                old.SideBoardMaterial = orderInfo.SideBoardMaterial;
                old.SideBoardThickness = orderInfo.SideBoardThickness;
                old.TireBrand = orderInfo.TireBrand;
                old.TireShape = orderInfo.TireShape;
                old.TireNum = orderInfo.TireNum;
                old.SteelRingMaterial = orderInfo.SteelRingMaterial;
                old.SteelRingNum = orderInfo.SteelRingNum;
                state = Context.SaveChanges() > 0;
            }

            return state;
        }
    }
}
