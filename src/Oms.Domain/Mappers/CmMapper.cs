using Oms.Domain.Entities;
using Oms.Domain.Requests.Cm;
using Oms.Domain.Responses;
using System;
using System.Collections.Generic;

namespace Oms.Domain.Mappers
{
    public class CmMapper : ICmMapper
    {
        private readonly IOrderProductMapper _orderProductMapper;
        private readonly IOrderDetailsMapper _orderDetailsMapper;

        public CmMapper(IOrderProductMapper orderProductMapper, IOrderDetailsMapper orderDetailsMapper)
        {
            _orderDetailsMapper = orderDetailsMapper;
            _orderProductMapper = orderProductMapper;
        }

        public Cm Map(AddCmRequest request)
        {
            if (request == null) 
                return null;

            var cm = new Cm
            {
                Products = request.Products,
                FactoryId = request.FactoryId
            };
            return cm;
        }

        public Cm Map(EditCmRequest request)
        {
            if (request == null)
                return null;

            var cm = new Cm
            {
                CmsId = request.CmsId,
                Products = request.Products,
                FactoryId = request.FactoryId
            };
            return cm;
        }

        public CmResponse Map(Cm request)
        {
            if (request == null)
                return null;

            var response = new CmResponse
            {
                CmsId = request.CmsId,
                FactoryId = request.FactoryId,
                OrderDetails = _orderDetailsMapper.Map(request.OrderDetails)
            };

            if (request.Products != null)
            {
                List<OrderProductResponse> orderProductsResponse = new List<OrderProductResponse>();

                foreach (var product in request.Products)
                {
                    orderProductsResponse.Add(_orderProductMapper.Map(product));
                }

                response.Products = orderProductsResponse;
            }

            return response;
        }
    }
}
