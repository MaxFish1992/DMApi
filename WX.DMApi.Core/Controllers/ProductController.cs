using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private ILogger<ProductController> _logger;

        public ProductController(IProductService orderService, ILogger<ProductController> logger)
        {
            ProductService = orderService;
            _logger = logger;
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
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [HttpGet("getproductbydate")]
        public string GetProductsByDate(DateTime? start, DateTime? end)
        {
            if (start == null || end == null || start > end)
            {
                return GetAll();
            }
            var result = JsonConvert.SerializeObject(ProductService.GetProductsByDate(start, end));
            return result;
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
            try
            {
                var product = JsonConvert.DeserializeObject<ProductInfo>(productJson);
                if (ProductService.Exist(product))
                {
                    _logger.LogInformation("该VIN已存在,无法重复添加:" + product.VINNum);
                    return "该VIN已存在,无法重复添加";
                }

                //product.ProductDate = product.ProductDate.Split('T')[0];
                var state = ProductService.Add(product);
                if (state)
                {
                    _logger.LogInformation("添加生产信息成功:" + product.VINNum);
                    return "添加成功";
                }

                return "添加失败";
            }
            catch (Exception ex)
            {
                _logger.LogError("添加生产进度信息失败,", ex);
                return "添加失败";
            }
        }
        /// <summary>
        /// 删除订单信息
        /// </summary>
        /// <param name="productJson"></param>
        /// <returns></returns>
        [HttpGet("delete")]
        public string Delete(string productJson)
        {
            try
            {
                var product = JsonConvert.DeserializeObject<ProductInfo>(productJson);
                var state = ProductService.Delete(product);
                if (state)
                {
                    _logger.LogInformation("删除生产信息成功:" + product.VINNum);
                    return "删除成功";
                }

                return "删除失败";
            }
            catch (Exception ex)
            {
                _logger.LogError("删除生产信息失败", ex);
                return "删除失败";
            }
        }
        /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <param name="productJson"></param>
        /// <returns></returns>
        [HttpGet("update")]
        public string Update(string productJson)
        {
            try
            {
                var product = JsonConvert.DeserializeObject<ProductInfo>(productJson);
                var state = ProductService.Update(product);
                if (state)
                {
                    _logger.LogInformation("更新生产信息成功:" + product.VINNum);
                    return "更新成功";
                }

                return "更新失败";
            }
            catch (Exception ex)
            {
                _logger.LogError("更新生产信息失败", ex);
                return "更新失败";
            }

        }
    }
}
