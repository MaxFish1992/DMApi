using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.DMApi.IServices;
using WX.DMApi.Model;
using WX.DMApi.Services.DataContext;

namespace WX.DMApi.Services
{
    public class ProductService:IProductService
    {
        public ProductContext Context;
        public ProductService(ProductContext context)
        {
            Context = context;
        }
        public IEnumerable<ProductInfo> GetAll()
        {
            return Context.Products.ToList();
        }

        public ProductInfo GetSingle(string vin)
        {
            return Context.Products.SingleOrDefault(x => x.VINNum.Equals(vin));
        }

        public bool Add(ProductInfo productInfo)
        {
            Context.Products.Add(productInfo);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(ProductInfo productInfo)
        {
            var oldProduct = Context.Products.SingleOrDefault(x => x.VINNum.Equals(productInfo.VINNum));
            if (oldProduct != null)
                Context.Products.Remove(oldProduct);
            return Context.SaveChanges() > 0;
        }

        public bool Update(ProductInfo productInfo)
        {
            var state = false;
            var old = Context.Products.SingleOrDefault(x => x.VINNum.Equals(productInfo.VINNum));

            if (old != null)
            {
                old.BackDoor = productInfo.BackDoor;
                old.Blanking = productInfo.Blanking;
                old.Bridge = productInfo.Bridge;
                old.CloseCompartments = productInfo.CloseCompartments;
                old.ContractNum = productInfo.ContractNum;
                old.FinalAssembly = productInfo.FinalAssembly;
                old.Floor = productInfo.Floor;
                old.FrontDoor = productInfo.FrontDoor;
                old.Girder = productInfo.Girder;
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
        public bool Exist(ProductInfo productInfo)
        {
            return Context.Products.Any(x => x.VINNum.Equals(productInfo.VINNum));
        }
    }
}
