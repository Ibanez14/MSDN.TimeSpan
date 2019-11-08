using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SpanAndOthers
{
    public class Program
    {
        public static void Main(string[] args)
        {


            #region TimeSpan Introduction


            // A TimeSpan object represents a time interval(duration of time or elapsed time) 
            // that is measured as a positive or negative number of days, hours, minutes, seconds, 
            // and fractions of a second.

            // The largest unit of time that the TimeSpan structure uses to measure duration is a day

            // The value of a TimeSpan object is the number of ticks that equal the represented time interval. 
            // A tick is equal to 100 nanoseconds, or one ten-millionth of a second. 

            var arrival = new DateTime(2018, 8, 18, 8, 0, 15);
            var departure = new DateTime(2018, 8, 1, 13, 30, 30);

            TimeSpan difference = arrival - departure;
            difference._();
            difference.TotalSeconds._(); 
            difference.TotalMilliseconds._();
            difference.Days._();
            difference.Minutes._();
            difference.Hours._();
            difference.Ticks._();

            #endregion

            #region TimeSpan Instantiation

            // 1
            var timespan = new TimeSpan();
            (timespan == TimeSpan.Zero)._(); // true

            // 2
            timespan = new TimeSpan(hours: 12, minutes: 12, seconds: 12);
            timespan.ToString()._(); // 12:12:2




            #endregion

            #region TimeSpan Incrementing
            
            var timeSpent = TimeSpan.Zero;
            timespan += new TimeSpan(hours: new Random().Next(3, 6),
                                      minutes: 0,
                                      seconds: 0);

            #endregion

            #region TimeSpan Parsing

            Console.WriteLine("Parsing");

            TimeSpan.Parse("12")._();           // 12:00:00:00
            TimeSpan.Parse("12").Days._();      // 12
            TimeSpan.Parse("12").Minutes._();   // 0 

            TimeSpan.Parse("5.8:32:16")._();    // 5.8:32:16
            #endregion

            #region TimeSpan Some Features

            timespan = TimeSpan.Zero;
            timespan.Add(new TimeSpan(ticks: 100000000));
            timespan.Subtract(new TimeSpan(1, 1, 1));
            timespan.Divide(new TimeSpan(1));

            Console.WriteLine("................................... TimeSpan");
            new TimeSpan(1, 1, 1).Negate()._(); // -01:01:01

            #endregion

            #region TimeSpan Second trick
            Console.WriteLine("One second Time Span");
            var secondTS = TimeSpan.FromSeconds(1);

            secondTS.Ticks._();     // 10000000
            secondTS.Seconds._();   // 1
            secondTS.Hours._();     // 0
            secondTS.Days._();      // 0

            #endregion


            #region Time Span Ticks Per

            TimeSpan.TicksPerDay._(); // 864000000000000
            TimeSpan.TicksPerSecond._();  // 10000000
            TimeSpan.TicksPerHour._(); // 3600000000
            TimeSpan.TicksPerMinute._(); // ....

            #endregion

            #region TimeSpan Operators

            timespan = TimeSpan.FromSeconds(30);
            var timespan2 = TimeSpan.FromSeconds(40);

            Console.WriteLine("Is Greater ?");
            (timespan > timespan2)._(); 
            (timespan != timespan2)._();
            (timespan <= timespan2)._();
            #endregion

            #region TimeSpan Formatting

            Console.WriteLine("Timespan Formatting ........................");
            timespan = new TimeSpan(1, 12, 12, 13);
            timespan.ToString("c")._();                 // 1.12:12:13 (default)
            timespan.ToString("g")._();                 // 1.12:12:13
            timespan.ToString(@"hh\:mm\:ss")._();       // 12:12:13
            timespan.ToString(@"hh\:mm\:ss", new CultureInfo("ru-RU"))._();       // 12:12:13
            timespan.ToString(@"hh\:mm\:ss", new CultureInfo("en-US"))._();       // 12:12:13

            #endregion


            
            Console.Read();
        }

    }


  
    public static class Ex { public static void _(this object obj) => Console.WriteLine(obj); }
}
