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
    public class OrderController : ControllerBase
    {
        public IOrderService OrderService;
        private ILogger<OrderController> _logger;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
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
        /// <param name="orderJson"></param>
        /// <returns></returns>
        [HttpGet("add")]
        public string Add(string orderJson)
        {
            try
            {
                var order = JsonConvert.DeserializeObject<OrderInfo>(orderJson);
                if (OrderService.Exist(order))
                {
                    return "该VIN已存在";
                }
                var state = OrderService.Add(order);
                if (state)
                {
                    _logger.LogInformation("用户成功添加订单信息:" + order.VIN);
                    return "添加成功";
                }

                return "添加失败";
            }
            catch (Exception ex)
            {
                _logger.LogError("用户添加订单信息失败:", ex);
                return "添加失败";
            }
        }
        /// <summary>
        /// 删除订单信息
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        [HttpGet("delete")]
        public string Delete(string orderJson)
        {
            try
            {
                var order = JsonConvert.DeserializeObject<OrderInfo>(orderJson);
                var state = OrderService.Delete(order);
                if (state)
                {
                    _logger.LogInformation("用户成功删除订单信息:" + order.VIN);
                    return "删除成功";
                }

                return "删除失败";
            }
            catch (Exception ex)
            {
                _logger.LogError("用户删除订单信息失败:" , ex);
                return "删除失败";
            }
        }
        /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        [HttpGet("update")]
        public string Update(string orderJson)
        {
            try
            {
                var order = JsonConvert.DeserializeObject<OrderInfo>(orderJson);
                var state = OrderService.Update(order);
                if (state)
                {
                    _logger.LogInformation("用户成功更新订单信息:" + order.VIN);
                    return "更新成功";
                }

                return "更新失败";
            }
            catch (Exception ex)
            {
                _logger.LogError("用户更新订单信息失败:" , ex);
                return "更新失败";
            }
            
        }
    }
}
