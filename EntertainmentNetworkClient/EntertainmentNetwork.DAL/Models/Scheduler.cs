using System;
using System.Collections.Generic;
using System.ComponentModel;
using EntertainmentNetwork.DAL.Models.Interfaces;
using System.Xml.Serialization;
using System.Globalization;

namespace EntertainmentNetwork.DAL.SchedulerService
{
    public partial class scheduler : baseModel, IScheduler
    {
        public scheduler() 
        {
            this.schTimeFromFieldSpecified = true;
            this.schTimeToFieldSpecified = true;
            this.hallIdFieldSpecified = true;
            this.showIdFieldSpecified = true;
            this.schCoefSpecified = true;
        }

        public scheduler(decimal schId, string schName, string schDescr, DateTime schTimeFrom, DateTime schTimeTo, decimal schCoef, decimal hallId, decimal showId)
        {
            this.id = schId;
            this.name = schName;
            this.schDescr = schDescr;
            this.schTimeFrom = schTimeFrom;
            this.schTimeFromFieldSpecified = true;
            this.schTimeTo = schTimeTo;
            this.schTimeToFieldSpecified = true;
            this.hallId = hallId;
            this.hallIdFieldSpecified = true;
            this.showId = showId;
            this.showIdFieldSpecified = true;
            this.schCoef = schCoef;
            this.schCoefSpecified = true;
        }

        [XmlIgnore]
        public bool IsNew
        {
            get
            {
                return this.id == 0;
            }
        }

        [XmlIgnore]
        public bool IsChanged { get; set; }

        [XmlIgnore]
        public string ShortDT
        {
            get 
            {
                return this.ToString();
            }
        }

        public decimal GetId()
        {
            return this.id;
        }

        public void Update(IBaseModel model)
        {
            IScheduler scheduler = (IScheduler)model;
            this.id = scheduler.id;
            this.name = scheduler.name;
            this.schDescr = scheduler.schDescr;
            this.schTimeFrom = scheduler.schTimeFrom;
            this.schTimeFromFieldSpecified = true;
            this.schTimeTo = scheduler.schTimeTo;
            this.schTimeToFieldSpecified = true;
            this.hallId = scheduler.hallId;
            this.hallIdFieldSpecified = true;
            this.showId = scheduler.showId;
            this.showIdFieldSpecified = true;
            this.schCoef = scheduler.schCoef;
            this.schCoefSpecified = true;
        }

        public override bool Equals(object scheduler)
        {
            IScheduler schedulerToCompare = scheduler as IScheduler;
            return schedulerToCompare != null && this.id.Equals(schedulerToCompare.id);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        public override string ToString()
        {
            return this.schTimeFrom.ToString(String.Format("{0} - {1}",
                CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern,
                CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern));
        }

    }
}
