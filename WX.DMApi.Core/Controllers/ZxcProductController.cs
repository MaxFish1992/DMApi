﻿using System;
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
    public class ZxcProductController : ControllerBase
    {
        public IZxcProductService ProductService;
        private ILogger<ZxcProductController> _logger;

        public ZxcProductController(IZxcProductService orderService, ILogger<ZxcProductController> logger)
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
            return JsonConvert.SerializeObject(ProductService.GetAll().ToList().OrderByDescending(x=>x.ProductDate));
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
                var product = JsonConvert.DeserializeObject<ZxcProductInfo>(productJson);
                if (ProductService.Exist(product))
                {
                    _logger.LogInformation("该VIN已存在,无法重复添加:" + product.VINNum);
                    return "该VIN已存在,无法重复添加";
                }
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
                _logger.LogError("添加生产信息失败", ex);
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
                var product = JsonConvert.DeserializeObject<ZxcProductInfo>(productJson);
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
                _logger.LogError("删除生产信息失败,", ex);
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
                var product = JsonConvert.DeserializeObject<ZxcProductInfo>(productJson);
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
