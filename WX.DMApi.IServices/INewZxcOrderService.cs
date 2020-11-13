using System;
using System.Collections.Generic;
using System.Text;
using WX.DMApi.Model;

namespace WX.DMApi.IServices
{
    /// <summary>
    /// 自卸车订单服务接口
    /// </summary>
    public interface INewZxcOrderService
    {
        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<NewZxcOrderInfo> GetAll();

        /// <summary>
        /// 根据VIN获取订单信息
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        NewZxcOrderInfo GetSingle(string vin);

        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Add(NewZxcOrderInfo orderInfo);

        /// <summary>
        /// 删除订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Delete(NewZxcOrderInfo orderInfo);

        /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Update(NewZxcOrderInfo orderInfo);
        bool Exist(NewZxcOrderInfo productInfo);
    }
}
