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
    public class ZxcOrderController : ControllerBase
    {
        public IZxcOrderService OrderService;
        private ILogger<ZxcOrderController> _logger;

        public ZxcOrderController(IZxcOrderService orderService, ILogger<ZxcOrderController> logger)
        {
            OrderService = orderService;
            _logger = logger;
        }
        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public string GetAll()
        {
            return JsonConvert.SerializeObject(OrderService.GetAll().ToList());
        }
        /// <summary>
        /// 获取单个订单信息
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        [HttpGet("getsingle")]
        public string GetSingle(string vin)
        {
            return JsonConvert.SerializeObject(OrderService.GetSingle(vin));
        }
        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public string Add(ZxcOrderInfo orderInfo)
        {
            try
            {
                if (OrderService.Exist(orderInfo))
                {
                    _logger.LogInformation("该订单VIN已存在，无法重复添加:" + orderInfo.FloorNumber);
                    return "该VIN已存在，无法重复添加";
                }
                var state = OrderService.Add(orderInfo);
                if (state)
                {
                    _logger.LogInformation("添加订单信息成功:" + orderInfo.FloorNumber);
                    return "添加成功";
                }

                return "添加失败";
            }
            catch (Exception ex)
            {
                _logger.LogError("添加订单信息失败", ex);
                return "添加失败";
            }

        }
        /// <summary>
        /// 删除订单信息
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public string Delete(ZxcOrderInfo orderInfo)
        {
            try
            {
                var state = OrderService.Delete(orderInfo);
                if (state)
                {
                    _logger.LogInformation("删除订单信息成功:" + orderInfo.FloorNumber);
                    return "删除成功";
                }

                return "删除失败";
            }
            catch (Exception ex)
            {
                _logger.LogError("删除订单信息失败", ex);
                return "删除失败";
            }

        }
        /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        [HttpPost("update")]
        [DisableRequestSizeLimit]
        public string Update(ZxcOrderInfo orderInfo)
        {
            try
            {
                var state = OrderService.Update(orderInfo);
                if (state)
                {
                    _logger.LogInformation("更新订单信息成功:" + orderInfo.FloorNumber);
                    return "更新成功";
                }

                return "更新失败";
            }
            catch (Exception ex)
            {
                _logger.LogError("更新订单信息失败", ex);
                return "更新失败";
            }

        }
    }
}
