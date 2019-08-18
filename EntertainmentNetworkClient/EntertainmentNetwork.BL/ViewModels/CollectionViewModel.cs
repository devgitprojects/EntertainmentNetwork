using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using EntertainmentNetwork.DAL.Models.Interfaces;

namespace EntertainmentNetwork.BL.ViewModels
{
    [POCOViewModel]
    public abstract class CollectionViewModel<D, M> : BaseViewModel
        where D : IBaseRepository<M>
        where M : class, INotifyPropertyChanged
    {
        public CollectionViewModel(D dataSource)
        {
            this.DataSource = dataSource;
        }

        public virtual IList<M> Entities { get; protected set; }

        public virtual M SelectedEntity { get; set; }

        protected virtual D DataSource { get; set; }

        public virtual async Task LoadData()
        {
            this.IsLoading = true;

            this.Entities.Clear();
            var result = await this.GetData();

            foreach (M item in result)
            {
                this.Entities.Add(item);
            }

            this.IsLoading = false;
        }

        public virtual async Task Save()
        {
            await this.DataSource.Save(this.Entities); 
        }

        public abstract bool CanSave();

        public virtual async Task Remove()
        {
            await this.DataSource.Remove(this.SelectedEntity);
            this.Entities.Remove(this.SelectedEntity);
        }

        public virtual bool CanRemove()
        {
            return this.SelectedEntity != null;
        }

        protected abstract Task<IEnumerable<M>> GetData();

        protected virtual void OnEntitiesAddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = this.DataSource.Create();
        }

        protected virtual void OnEntitiesListChanged(object sender, ListChangedEventArgs e)
        {
            this.UpdateCommands();
        }

        protected virtual void OnIsLoadingChanged()
        {
            this.UpdateCommands();
        }

        protected virtual void OnSelectedEntityChanged()
        {
            this.UpdateCommands();
            Messenger.Default.Send(this.SelectedEntity);
        }

        protected virtual void UpdateCommands()
        {
            #pragma warning disable 4014
            this.RaiseCanExecuteChanged(x => x.LoadData());
            this.RaiseCanExecuteChanged(x => x.Save());
            this.RaiseCanExecuteChanged(x => x.Remove());
            #pragma warning restore 4014      

        }
    }
}
