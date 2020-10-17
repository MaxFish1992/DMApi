using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WX.DMApi.IServices;
using WX.DMApi.Model;

namespace WX.DMApi.Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductService ProductService;

        public ProductController(IProductService orderService)
        {
            ProductService = orderService;
        }
        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public string GetAll()
        {
            return JsonConvert.SerializeObject(ProductService.GetAll().ToList());
        }
        /// <summary>
        /// 获取单个订单信息
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        [HttpGet("getsingle")]
        public string GetSingle(string vin)
        {
            return JsonConvert.SerializeObject(ProductService.GetSingle(vin));
        }
        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <param name="productJson"></param>
        /// <returns></returns>
        [HttpGet("add")]
        public string Add(string productJson)
        {
            var product = JsonConvert.DeserializeObject<ProductInfo>(productJson);
            if (ProductService.Exist(product))
            {
                return "该VIN已存在";
            }
            var state = ProductService.Add(product);
            if (state)
            {
                return "添加成功";
            }

            return "添加失败";
        }
        /// <summary>
        /// 删除订单信息
        /// </summary>
        /// <param name="productJson"></param>
        /// <returns></returns>
        [HttpGet("delete")]
        public string Delete(string productJson)
        {
            var state = ProductService.Delete(JsonConvert.DeserializeObject<ProductInfo>(productJson));
            if (state)
            {
                return "删除成功";
            }

            return "删除失败";
        }
        /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <param name="productJson"></param>
        /// <returns></returns>
        [HttpGet("update")]
        public string Update(string productJson)
        {
            var state = ProductService.Update(JsonConvert.DeserializeObject<ProductInfo>(productJson));
            if (state)
            {
                return "更新成功";
            }

            return "更新失败";
        }
    }
}
