using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.DMApi.IServices;
using WX.DMApi.Model;
using WX.DMApi.Services.DataContext;

namespace WX.DMApi.Services
{
    /// <summary>
    /// 自卸车订单服务
    /// </summary>
    public class ZxcOrderService: IZxcOrderService
    {
        public ZxcOrderContext Context;
        public ZxcOrderService(ZxcOrderContext context)
        {
            Context = context;
        }
        public IEnumerable<ZxcOrderInfo> GetAll()
        {
            return Context.Orders.ToList();
        }

        public ZxcOrderInfo GetSingle(string vin)
        {
            return Context.Orders.SingleOrDefault(x => x.FloorNumber.Equals(vin));
        }

        public bool Add(ZxcOrderInfo orderInfo)
        {
            Context.Orders.Add(orderInfo);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(ZxcOrderInfo orderInfo)
        {
            var oldProduct = Context.Orders.SingleOrDefault(x => x.FloorNumber.Equals(orderInfo.FloorNumber));
            if (oldProduct != null)
                Context.Orders.Remove(oldProduct);
            return Context.SaveChanges() > 0;
        }

        public bool Update(ZxcOrderInfo orderInfo)
        {
            var state = false;
            var old = Context.Orders.SingleOrDefault(x => x.FloorNumber.Equals(orderInfo.FloorNumber));

            if (old != null)
            {
                old.ProductNumber = orderInfo.ProductNumber;
                old.OrderDate = orderInfo.OrderDate;
                old.DeliveryDate = orderInfo.DeliveryDate;
                old.CustomerName = orderInfo.CustomerName;
                old.CustomerPhone = orderInfo.CustomerPhone;
                old.Qualified = orderInfo.Qualified;
                old.Material = orderInfo.Material;
                old.LeaveFactory = orderInfo.LeaveFactory;
                old.SideBoardThickness = orderInfo.SideBoardThickness;
                old.FloorThickness = orderInfo.FloorThickness;
                old.FrontboardThickness = orderInfo.FrontboardThickness;
                old.BackboardThickness = orderInfo.BackboardThickness;
                old.Height = orderInfo.Height;
                old.Length = orderInfo.Length;
                old.Width = orderInfo.Width;
                old.FloorType = orderInfo.FloorType;
                old.CarlingNumber = orderInfo.CarlingNumber;
                old.OilCylinder = orderInfo.OilCylinder;
                old.Mark = orderInfo.Mark;
                state = Context.SaveChanges() > 0;
            }

            return state;
        }
        /// <summary>
        /// 判断当前VIN是否存在
        /// </summary>
        /// <param name="productInfo"></param>
        /// <returns></returns>
        public bool Exist(ZxcOrderInfo productInfo)
        {
            return Context.Orders.Any(x => x.FloorNumber.Equals(productInfo.FloorNumber));
        }
    }
}
