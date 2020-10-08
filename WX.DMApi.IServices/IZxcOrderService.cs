using System;
using System.Collections.Generic;
using System.Text;
using WX.DMApi.Model;

namespace WX.DMApi.IServices
{
    /// <summary>
    /// 自卸车订单服务接口
    /// </summary>
   public interface IZxcOrderService
    {
        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<ZxcOrderInfo> GetAll();

        /// <summary>
        /// 根据VIN获取订单信息
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        ZxcOrderInfo GetSingle(string vin);

        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Add(ZxcOrderInfo orderInfo);

        /// <summary>
        /// 删除订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Delete(ZxcOrderInfo orderInfo);

        /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Update(ZxcOrderInfo orderInfo);
    }
}
