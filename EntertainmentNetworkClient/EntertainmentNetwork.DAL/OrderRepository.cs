using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService = EntertainmentNetwork.DAL.OrdersService;
using EntertainmentNetwork.DAL.Logging;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.OrdersService;

namespace EntertainmentNetwork.DAL
{
    public class OrderRepository : BaseRepository<IOrder>, IOrderRepository
    {
        public OrderRepository(DataService.OrderService orderService)
        {
            this.orderService = orderService;
        }

        #region IOrderRepository

        public IOrder Create()
        {
            IOrder neworder = new orders();
            neworder.PropertyChanged += this.Entity_PropertyChanged;
            return neworder;
        }

        public async Task<IOrder> FindById(decimal id)
        {
            var result = await Logger.ExecuteAndLog<Task<findOrdersByIdResponse>>(
                () => this.orderService.findOrdersByIdAsync(new findOrdersByIdRequest(id)));
            return result == null || result.@return == null ? null : result.@return.FirstOrDefault(x => x.id == id);
        }

        public async Task<IOrder> GenerateOrder(string orderComment)
        {
            var result = await Logger.ExecuteAndLog<Task<generateOrderResponse>>(
                () => this.orderService.generateOrderAsync(new generateOrderRequest(orderComment)));
            return result.@return;
        }

        public async Task<List<IOrder>> GetAll()
        {
            return await Logger.ExecuteAndLog<Task<List<IOrder>>>(async () => 
            {
                var result = await this.orderService.getOrdersAsync(new getOrdersRequest());
                List<IOrder> orders = this.CastToList(result.@return);
                orders.ForEach(x => x.PropertyChanged += this.Entity_PropertyChanged);
                return orders;
            });
        }   

        public async Task Remove(IOrder order)
        {
            await Logger.ExecuteAndLog<Task>(() => this.orderService.removeOrderAsync(new removeOrderRequest(order.GetId())));
        }

        public void Reset(IOrder order)
        {
            order.Update(new orders());
        }

        public Task Save(IList<IOrder> orders)
        {
            throw new NotImplementedException();
        }

        public Task Save(IOrder order)
        {
            throw new NotImplementedException();
        }

        #endregion

        private readonly DataService.OrderService orderService;
    }
}
