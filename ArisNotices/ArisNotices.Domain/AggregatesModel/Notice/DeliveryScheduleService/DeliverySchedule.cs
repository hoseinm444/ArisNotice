using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ArisNotices.Domain.AggregatesModel.Notice.DeliveryScheduleService;
public class DeliverySchedule :  IDeliverySchedule
{
    public DeliverySchedule()
    {
    }
    public DeliverySchedule(DateTime startperiodictime, DateTime endperiodictime, DateTime years, DateTime daysofweek,
        DateTime months,DateTime daysofmonth, DateTime hours,DateTime minutes,DateTime seconds)
    {
        StartPeriodicTime = startperiodictime;
        EndPeriodicTime = endperiodictime;
        Years = years;
        DaysOfWeek = daysofweek;
        Months = months;
        DaysOfMonth= daysofmonth;
        Hours = hours;
        Minutes=minutes;
        Secondes=seconds;
    }
    public DeliverySchedule(IDeliverySchedule delivery)
    {
        StartPeriodicTime = delivery.StartPeriodicTime;
        EndPeriodicTime = delivery.EndPeriodicTime;
        Years = delivery.Years;
        DaysOfWeek = delivery.DaysOfWeek;
        Months = delivery.Months;
        DaysOfMonth = delivery.DaysOfMonth;
        Hours = delivery.Hours;
        Minutes = delivery.Minutes;
        Secondes = delivery.Secondes;
    }
    //[JsonIgnore]
    //public int? NoticeId { get; private set; }
 
    //The property 'DeliverySchedule.Days' is of type 'IList<DateTime>'
    //which is not supported by the current database provider. Either
    //change the property CLR type, or ignore the property using the
    //'[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore'
    //in 'OnModelCreating'.

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy HH:MM}")]
    public DateTime StartPeriodicTime { get;private set; }
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy HH:MM}")]
    public DateTime EndPeriodicTime { get; private set; }

    [Range(1900, 2099, ErrorMessage = " Years can only be between 1900 ... 2099")]
    public DateTime Years { get; private set; }           /// "* * * * * * 1" Every second, only in 1901


    [Range(0, 6, ErrorMessage = " DaysOfWeek can only be between 0 ... 6")]
    public DateTime DaysOfWeek { get; private set; }     /// "* * * * * 1 *"  Every second, only on Monday


    [Range(1, 12, ErrorMessage = " Months can only be between 1 ... 12")]
    public DateTime Months { get; private set; }         /// "* * * * 1 * *"  Every second, only in January


    [Range(1, 31, ErrorMessage = " DaysOfMonth can only be between 1 ... 31")]
    public DateTime DaysOfMonth { get; private set; }    /// "* * * 1 * * *"  Every second, on day 1 of the month


    [Range(0, 23, ErrorMessage = " Hours can only be between 0 ... 23")]
    public DateTime Hours { get; private set; }         /// "* * 1 * * * *"  Every second, between 01:00 AM and 01:59 AM


    [Range(0, 59, ErrorMessage = " Minutes can only be between 0 ... 59")]
    public DateTime Minutes { get; private set; }        /// "* 1 * * * * *"  Every second, at 1 minutes past the hour


    [Range(0, 59, ErrorMessage = "Seconds can only be between 0 ... 59")]
    public DateTime Secondes { get; private set; }       /// "1 * * * * * *"  At 1 seconds past the minute

   // public string CronExpression { get; private set; }

}


