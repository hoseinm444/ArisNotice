using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArisNotices.Domain.AggregatesModel.Notice.DeliveryScheduleService;

public interface IDeliverySchedule
{ 
   /// <summary>
   /// "* * * * * *"
   /// </summary>
    public DateTime StartPeriodicTime { get;  }

    public DateTime EndPeriodicTime { get; }

    [Range(1900, 2099, ErrorMessage = " Years can only be between 1900 ... 2099")]
    public DateTime Years { get; }           /// "* * * * * * 1" Every second, only in 1901


    [Range(0, 6, ErrorMessage = " DaysOfWeek can only be between 0 ... 6")]
    public DateTime DaysOfWeek { get; }     /// "* * * * * 1 *"  Every second, only on Monday


    [Range(1, 12, ErrorMessage = " Months can only be between 1 ... 12")]
    public DateTime Months { get; }         /// "* * * * 1 * *"  Every second, only in January


    [Range(1,31, ErrorMessage = " DaysOfMonth can only be between 1 ... 31")]
    public DateTime DaysOfMonth { get; }    /// "* * * 1 * * *"  Every second, on day 1 of the month


    [Range(0, 23, ErrorMessage = " Hours can only be between 0 ... 23")]
    public DateTime Hours { get;  }         /// "* * 1 * * * *"  Every second, between 01:00 AM and 01:59 AM


    [Range(0, 59, ErrorMessage =" Minutes can only be between 0 ... 59")]
    public DateTime Minutes { get; }        /// "* 1 * * * * *"  Every second, at 1 minutes past the hour


    [Range(0, 59, ErrorMessage = "Seconds can only be between 0 ... 59")]
    public DateTime Secondes { get; }       /// "1 * * * * * *"  At 1 seconds past the minute

   // public string CronExpression { get; }
}

