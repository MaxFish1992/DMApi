using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.DMApi.IServices;
using WX.DMApi.Model;
using WX.DMApi.Services.DataContext;

namespace WX.DMApi.Services
{
    public class NewZxcOrderService: INewZxcOrderService
    {
        public NewZxcOrderContext Context;
        public NewZxcOrderService(NewZxcOrderContext context)
        {
            Context = context;
        }
        public IEnumerable<NewZxcOrderInfo> GetAll()
        {
            return Context.Orders.ToList();
        }

        public NewZxcOrderInfo GetSingle(string vin)
        {
            return Context.Orders.SingleOrDefault(x => x.VIN.Equals(vin));
        }

        public bool Add(NewZxcOrderInfo orderInfo)
        {
            Context.Orders.Add(orderInfo);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(NewZxcOrderInfo orderInfo)
        {
            var oldProduct = Context.Orders.SingleOrDefault(x => x.VIN.Equals(orderInfo.VIN));
            if (oldProduct != null)
                Context.Orders.Remove(oldProduct);
            return Context.SaveChanges() > 0;
        }

        public bool Update(NewZxcOrderInfo orderInfo)
        {
            var state = false;
            var old = Context.Orders.SingleOrDefault(x => x.VIN.Equals(orderInfo.VIN));

            if (old != null)
            {
                old.ProductNumber = orderInfo.ProductNumber;
                old.OrderDate = orderInfo.OrderDate;
                old.DeliveryDate = orderInfo.DeliveryDate;
                old.CustomerName = orderInfo.CustomerName;
                old.FloorType = orderInfo.FloorType;
                old.VIN = orderInfo.VIN;
                old.Length = orderInfo.Length;
                old.Width = orderInfo.Width;
                old.Height = orderInfo.Height;
                old.Heightening = orderInfo.Heightening;
                old.OilCylinder = orderInfo.OilCylinder;
                old.DThickness = orderInfo.DThickness;
                old.DMaterial = orderInfo.DMaterial;
                old.DCatlingNumber = orderInfo.DCatlingNumber;
                old.DReinRib = orderInfo.DReinRib;
                old.FStailNumber = orderInfo.FStailNumber;
                old.FStailIron = orderInfo.FStailIron;
                old.BThickness = orderInfo.BThickness;
                old.BMaterial = orderInfo.BMaterial;
                old.BPostThickness = orderInfo.BPostThickness;
                old.BPostMaterial = orderInfo.BPostMaterial;
                old.BAbove = orderInfo.BAbove;
                old.BBelow = orderInfo.BBelow;
                old.BReinRib = orderInfo.BReinRib;
                old.QThickness = orderInfo.QThickness;
                old.QMaterial = orderInfo.QMaterial;
                old.QSpareTireWay = orderInfo.QSpareTireWay;
                old.QReinRib = orderInfo.QReinRib;
                old.HThickness = orderInfo.HThickness;
                old.HBorder = orderInfo.HBorder;
                old.HMaterial = orderInfo.HMaterial;
                old.HVerticalRein = orderInfo.HVerticalRein;
                old.HHorizontalRein = orderInfo.HHorizontalRein;
                old.HPushBoard = orderInfo.HPushBoard;
                old.H100AngleIron = orderInfo.H100AngleIron;
                old.OtherRequirements = orderInfo.OtherRequirements;
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
        public bool Exist(NewZxcOrderInfo productInfo)
        {
            return Context.Orders.Any(x => x.VIN.Equals(productInfo.VIN));
        }
    }
}
