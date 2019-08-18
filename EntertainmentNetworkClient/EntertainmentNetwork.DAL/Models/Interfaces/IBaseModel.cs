using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface IBaseModel : INotifyPropertyChanged
    {
        [Display(AutoGenerateField = false)]
        bool IsChanged { get; set; }
        [Display(AutoGenerateField = false)]
        bool IsNew { get; }

        decimal GetId();
        void Update(IBaseModel model);
    }  
}
