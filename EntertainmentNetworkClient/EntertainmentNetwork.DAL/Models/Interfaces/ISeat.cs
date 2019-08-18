using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface ISeat : IBaseModel, INotifyPropertyChanged
    {
        [ReadOnly(true)]
        decimal id { get; set; }
        [Range(0, 999)]
        int seatColumn { get; set; }
        [Range(0, 9999)]
        int seatNum { get; set; }
        [Range(0, 999)]
        int seatRow { get; set; }
        [Range(0, 10)]
        int seatType { get; set; }
        [Range(0, 10)]
        bool seatIsactive { get; set; }
    }
}
