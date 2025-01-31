using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Core.Services.Orders;
using Core.Services.Products;
using Core.Services.Users;
using WebApi.Models.Orders;
using WebApi.Models.Products;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrdersController : BaseApiController
    {
        private readonly ICreateOrderService _orderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;

        public OrdersController(ICreateOrderService orderService, IDeleteOrderService deleteOrderService, IGetOrderService getOrderService, IUpdateOrderService updateOrderService)
        {
            _orderService = orderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage Create(Guid orderId, [FromBody] OrdersModel model)
        {

            var order = _getOrderService.GetOrder(orderId);

            if (order != null)
            {
                return Conflict($"Order with Id:{orderId} already exists");
            }

            var message = _orderService.Create(orderId, model.CustomerId, model.Order);
            if (message != null)
            {
                return BadRequest(message);
                
            }
            else
            {
                order = _getOrderService.GetOrder(orderId);
                return Found(new OrderData(order));
            }
            
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetOrders()
        {
            var order = _getOrderService.GetAllOrders()
                .Select(p => new OrderData(p));

            return Found(order);
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetProductById(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);

            if(order is null)
            {
                return DoesNotExist();
            }
            return Found(new OrderData(order));
        }

        [Route("list/customer/{customerId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrderByCustomerId(Guid customerId)
        {
            var order = _getOrderService.GetAllOrdersByCustomer(customerId)
                           .Select(o => new OrderData(o)).ToList();

            return Found(order);
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrdersModel model)
        {
            var order = _getOrderService.GetOrder(orderId);

            if (order is null)
            {
                return DoesNotExist();
            }

            _updateOrderService.Update(order, model.CustomerId, model.Order);

            return Found(new OrderData(order));
        }



        [Route("{orderId:guid}")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);

            if (order is null)
            {
                return DoesNotExist();
            }

            _deleteOrderService.Delete(orderId);

            return NoContent();
        }

    }
}