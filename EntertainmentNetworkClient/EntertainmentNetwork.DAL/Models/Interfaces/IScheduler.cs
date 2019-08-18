using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface IScheduler : IBaseModel, INotifyPropertyChanged
    {
        [ReadOnly(true)]
        decimal id { get; set; }
        [StringLength(100, ErrorMessage = "The value cannot exceed 100 characters.")]
        [Required(AllowEmptyStrings = false)]
        string name { get; set; }
        [StringLength(255, ErrorMessage = "The value cannot exceed 255 characters.")]
        string schDescr { get; set; }
        DateTime schTimeFrom { get; set; }
        DateTime schTimeTo { get; set; }
        decimal schCoef { get; set; }
        decimal hallId { get; set; }
        decimal showId { get; set; }
        string ShortDT { get; }
    }
}
