using System.Threading.Tasks;
using EntertainmentNetwork.DAL.ShowService;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface IOrderRepository : IBaseRepository<IOrder> 
    {
        Task<IOrder> GenerateOrder(string orderComment);
        void Reset(IOrder order);
        void Update(IOrder target, IOrder source);
    }
}
