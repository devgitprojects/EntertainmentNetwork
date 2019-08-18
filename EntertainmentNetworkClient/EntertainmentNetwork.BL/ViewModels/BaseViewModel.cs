using EntertainmentNetwork.DAL;

namespace EntertainmentNetwork.BL.ViewModels
{
    public abstract class BaseViewModel
    {
        public BaseViewModel()
        {
        }

        public virtual bool IsLoading { get; protected set; }
    }
}
