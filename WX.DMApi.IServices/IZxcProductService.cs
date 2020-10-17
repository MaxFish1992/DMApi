using System;
using System.Collections.Generic;
using System.Text;
using WX.DMApi.Model;

namespace WX.DMApi.IServices
{
    /// <summary>
    /// 自卸车生产进度数据服务接口
    /// </summary>
    public interface IZxcProductService
    {
        /// <summary>
        /// 获取所有生产信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<ZxcProductInfo> GetAll();

        /// <summary>
        /// 根据VIN获取生产信息
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        ZxcProductInfo GetSingle(string vin);

        /// <summary>
        /// 添加生产信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Add(ZxcProductInfo orderInfo);

        /// <summary>
        /// 删除生产信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Delete(ZxcProductInfo orderInfo);

        /// <summary>
        /// 更新生产信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Update(ZxcProductInfo orderInfo);
        bool Exist(ZxcProductInfo productInfo);
    }
}
