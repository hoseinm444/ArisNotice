using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ArisNotices.Domain.AggregatesModel.DeliveryScheduleService;

public class DeliveryScheduleDto : IDeliverySchedule
{
    //DateTime.Parse("5/1/2008 8:30:52 AM")
    //    var date1 = new DateTime(2008, 3, 1, 7, 0, 0);
    //    Console.WriteLine(date1.ToString("F"));
    //// Displays Saturday, March 01, 2008 7:00:00 AM
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy HH:MM}")]
    public DateTime StartPeriodicTime { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy HH:MM}")]
    public DateTime EndPeriodicTime { get; set; }

    [Range(1900, 2099, ErrorMessage = " Years can only be between 1900 ... 2099")]
    public DateTime Years { get; set; }           /// "* * * * * * 1" Every second, only in 1901


    [Range(0, 6, ErrorMessage = " DaysOfWeek can only be between 0 ... 6")]
    public DateTime DaysOfWeek { get; set; }     /// "* * * * * 1 *"  Every second, only on Monday


    [Range(1, 12, ErrorMessage = " Months can only be between 1 ... 12")]
    public DateTime Months { get; set; }         /// "* * * * 1 * *"  Every second, only in January


    [Range(1, 31, ErrorMessage = " DaysOfMonth can only be between 1 ... 31")]
    public DateTime DaysOfMonth { get; set; }    /// "* * * 1 * * *"  Every second, on day 1 of the month


    [Range(0, 23, ErrorMessage = " Hours can only be between 0 ... 23")]
    public DateTime Hours { get; set; }         /// "* * 1 * * * *"  Every second, between 01:00 AM and 01:59 AM


    [Range(0, 59, ErrorMessage = " Minutes can only be between 0 ... 59")]
    public DateTime Minutes { get; set; }        /// "* 1 * * * * *"  Every second, at 1 minutes past the hour


    [Range(0, 59, ErrorMessage = "Seconds can only be between 0 ... 59")]
    public DateTime Secondes { get; set; }       /// "1 * * * * * *"  At 1 seconds past the minute

   // public string CronExpression { get; set; }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}

