using System;
using System.Collections.Generic;
using System.Text;
using WX.DMApi.Model;

namespace WX.DMApi.IServices
{
    /// <summary>
    /// 半挂车生产进度数据服务接口
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// 获取所有生产信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductInfo> GetAll();

        /// <summary>
        /// 根据VIN获取生产信息
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        ProductInfo GetSingle(string vin);

        /// <summary>
        /// 添加生产信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Add(ProductInfo orderInfo);

        /// <summary>
        /// 删除生产信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Delete(ProductInfo orderInfo);

        /// <summary>
        /// 更新生产信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        bool Update(ProductInfo orderInfo);
        bool Exist(ProductInfo productInfo);
    }
}
