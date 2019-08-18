using System;
using System.ComponentModel;
using System.Threading.Tasks;
using DevExpress.Mvvm.POCO;
using EntertainmentNetwork.DAL;
using EntertainmentNetwork.DAL.Models.Interfaces;
using DevExpress.Mvvm;

namespace EntertainmentNetwork.BL.ViewModels
{
    public abstract class SingleViewModel<D, M> : BaseViewModel, ISupportParameter
        where D : IBaseRepository<M>
        where M : IBaseModel
    {
        public SingleViewModel(D dataSource) : base()
        {
            this.DataSource = dataSource;
            this.Create();
        }

        public virtual D DataSource { get; protected set; }

        public virtual M Entity { get; set; }

        public virtual void Create()
        {
            this.Entity = this.DataSource.Create();
            this.Entity.PropertyChanged += OnEntitiesMembersChanged;
        }

        public abstract Task LoadData();

        public virtual async Task Remove()
        {
            await this.DataSource.Remove(this.Entity);
        }

        public virtual bool CanRemove()
        {
            return !this.Entity.IsNew;
        }

        public abstract Task Reset();

        public virtual async Task Save()
        {
            await this.DataSource.Save(this.Entity);
        }

        public virtual bool CanSave()
        {
            return this.Entity.IsChanged;
        }

        protected virtual void OnIsLoadingChanged()
        {
            this.UpdateCommands();
        }

        protected virtual void OnEntityChanged()
        {
            this.UpdateCommands();
        }

        protected virtual void OnEntitiesMembersChanged(object sender, PropertyChangedEventArgs e)
        {
            this.UpdateCommands();
        }

        protected abstract void OnParameterChanged(object parameter);

        public virtual void UpdateCommands()
        {
            #pragma warning disable 4014
            this.RaiseCanExecuteChanged(x => x.Save());
            this.RaiseCanExecuteChanged(x => x.Remove());
            this.RaiseCanExecuteChanged(x => x.LoadData());
            #pragma warning restore 4014
        }

        #region ISupportParameter

        object ISupportParameter.Parameter
        {
            get { return this.parameter; }
            set
            {
                this.parameter = value;
                this.OnParameterChanged(this.parameter);
            }
        }

        private object parameter;

        #endregion

        protected abstract Task<M> GetData();
    }
}
