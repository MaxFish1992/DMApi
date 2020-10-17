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
    public class ZxcOrderController : ControllerBase
    {
        public IZxcOrderService OrderService;

        public ZxcOrderController(IZxcOrderService orderService)
        {
            OrderService = orderService;
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
            if (OrderService.Exist(orderInfo))
            {
                return "该VIN已存在";
            }
            var state = OrderService.Add(orderInfo);
            if (state)
            {
                return "添加成功";
            }

            return "添加失败";
        }
        /// <summary>
        /// 删除订单信息
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public string Delete(ZxcOrderInfo orderInfo)
        {
            var state = OrderService.Delete(orderInfo);
            if (state)
            {
                return "删除成功";
            }

            return "删除失败";
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
            //var orderInfo = JsonConvert.DeserializeObject<ZxcOrderInfo>(orderJson);
            var state = OrderService.Update(orderInfo);
            if (state)
            {
                return "更新成功";
            }

            return "更新失败";
        }
    }
}
