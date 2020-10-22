using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.DMApi.IServices;
using WX.DMApi.Model;
using WX.DMApi.Services.DataContext;

namespace WX.DMApi.Services
{
    public class ZxcProductService:IZxcProductService
    {
        public ZxcProductContext Context;
        public ZxcProductService(ZxcProductContext context)
        {
            Context = context;
        }
        public IEnumerable<ZxcProductInfo> GetAll()
        {
            return Context.Products.ToList();
        }

        public ZxcProductInfo GetSingle(string vin)
        {
            return Context.Products.SingleOrDefault(x => x.VINNum.Equals(vin));
        }

        public bool Add(ZxcProductInfo productInfo)
        {
            Context.Products.Add(productInfo);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(ZxcProductInfo productInfo)
        {
            var oldProduct = Context.Products.SingleOrDefault(x => x.VINNum.Equals(productInfo.VINNum));
            if (oldProduct != null)
                Context.Products.Remove(oldProduct);
            return Context.SaveChanges() > 0;
        }

        public bool Update(ZxcProductInfo productInfo)
        {
            var state = false;
            var old = Context.Products.SingleOrDefault(x => x.VINNum.Equals(productInfo.VINNum));

            if (old != null)
            {
                old.BackDoor = productInfo.BackDoor;
                old.Blanking = productInfo.Blanking;
                old.CloseCompartments = productInfo.CloseCompartments;
                old.ProductDate = productInfo.ProductDate;
                old.ContractNum = productInfo.ContractNum;
                old.FinalAssembly = productInfo.FinalAssembly;
                old.Floor = productInfo.Floor;
                old.FrontDoor = productInfo.FrontDoor;
                old.SideBoard = productInfo.SideBoard;
                old.SmallParts = productInfo.SmallParts;
                old.SprayPaint = productInfo.SprayPaint;
                state = Context.SaveChanges() > 0;
            }

            return state;
        }
        /// <summary>
        /// 判断当前VIN是否存在
        /// </summary>
        /// <param name="productInfo"></param>
        /// <returns></returns>
        public bool Exist(ZxcProductInfo productInfo)
        {
            return Context.Products.Any(x => x.VINNum.Equals(productInfo.VINNum));
        }
    }
}
