using System;
using System.Threading.Tasks;
using EntertainmentNetwork.DAL.Models.Interfaces;

namespace EntertainmentNetwork.BL.ViewModels
{
    public class OrderViewModel : SingleViewModel<IOrderRepository, IOrder>
    {
        public OrderViewModel(IOrderRepository dataSource)
            : base(dataSource)
        {
        }

        public override async Task Remove()
        {
            await base.Remove();
            this.DataSource.Reset(this.Entity);
        }

        public override Task Reset()
        {
            this.DataSource.Reset(this.Entity);
            return Task.FromResult(0);
        }

        protected override async Task<IOrder> GetData()
        {
            if (this.Entity.IsNew)
            {
                return await this.DataSource.GenerateOrder(String.Empty);
            }
            else
            {
                return await this.DataSource.FindById(this.Entity.GetId());           
            }
        }

        public override async Task LoadData()
        {
            this.IsLoading = true;
            var task = await this.GetData();
            this.DataSource.Update(this.Entity, task);
            this.IsLoading = false;
        }

        protected override void OnParameterChanged(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
