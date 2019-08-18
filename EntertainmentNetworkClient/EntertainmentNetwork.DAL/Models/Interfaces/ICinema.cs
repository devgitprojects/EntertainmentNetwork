using EntertainmentNetwork.DAL.CinemaService;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface ICinema : IBaseModel, INotifyPropertyChanged
    {
        [ReadOnly(true)]
        decimal id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "The value cannot exceed 100 characters.")]
        string name { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(255, ErrorMessage = "The value cannot exceed 255 characters.")]
        string cinAddress { get; set; }
        byte[] cinIcon { get; set; }
        [Display(AutoGenerateField = false)]
        string city { get; set; }
        [Display(AutoGenerateField = false)]
        hall[] halls { get; set; }
    }
}
