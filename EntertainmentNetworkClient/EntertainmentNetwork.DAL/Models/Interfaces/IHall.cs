using EntertainmentNetwork.DAL.CinemaService;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface IHall : IBaseModel, INotifyPropertyChanged
    {
        [ReadOnly(true)]
        decimal id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "The value cannot exceed 100 characters.")]
        string name { get; set; }
        [Display(AutoGenerateField = false)]
        section[] sections { get; set; }
    }
}
