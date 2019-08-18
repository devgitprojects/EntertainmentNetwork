using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EntertainmentNetwork.DAL.CinemaService;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface ISection : IBaseModel, INotifyPropertyChanged
    {
        [ReadOnly(true)]
        decimal id { get; set; }
        [StringLength(100, ErrorMessage = "The value cannot exceed 100 characters.")]
        string name { get; set; }
        decimal secCoef { get; set; }
        [Display(AutoGenerateField = false)]
        seat[] seats { get; set; }
    }
}
