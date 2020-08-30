using System;
using System.Collections.Generic;
using WX.DMApi.Model;

namespace WX.DMApi.IServices
{
    /// <summary>
    /// 订单数据服务接口
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<OrderInfo> GetAll();

        /// <summary>
        /// 根据VIN获取订单信息
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        OrderInfo GetSingle(string vin);

        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Add(OrderInfo orderInfo);

        /// <summary>
        /// 删除订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Delete(OrderInfo orderInfo);

        /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Update(OrderInfo orderInfo);
    }
}
