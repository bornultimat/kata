using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//The usage of this program is to reject the "analog time"
//Like: you look to an analog watch "10:00" 
// Watch it through a Mirror it is "02:00"
namespace MirrorWatch
{
    public enum TimeStamp
    {
        minute,
        hour
    }

    internal class Program
    {
        private static int _hour;
        private static int _minute;
        static void Main(string[] args)
        {
            string oldTime = "10:00";
            string newTime = WhatIsTheTime(oldTime);
            Console.WriteLine($"Old Time: {oldTime}");
            Console.WriteLine($"New Time: {newTime}");
            Console.ReadKey();
        }

        public static string WhatIsTheTime(string mirrorTime)
        {
            string[] seperatedTime = mirrorTime.Split(':');

            string hour = seperatedTime[0];
            string minute = seperatedTime[1];

            int.TryParse(hour, out _hour);
            int.TryParse(minute, out _minute);

            int secondaryhour = GetReflectTime(_hour, TimeStamp.hour);
            int secondaryminute = GetReflectTime(_minute, TimeStamp.minute);

            hour = ConcateMissingZeros(secondaryhour);
            minute = ConcateMissingZeros(secondaryminute);

            return hour + ":" + minute;
        }

        private static string ConcateMissingZeros(int time)
        {
            if (time < 10)
            {
                return "0" + time.ToString();
            }
            else
            {
                return time.ToString();
            }
        }
        private static int GetReflectTime(int time, TimeStamp timeStamp)
        {
            if (timeStamp == TimeStamp.hour)
            {
                if (11 - time == 0)
                {
                    return 12;
                }
                else if (time == 12 || time == 6)
                {
                    if (_minute == 0)
                    {
                        return time;
                    }
                    else
                    {
                        return time - 1;
                    }
                }
                else if (_minute > 0)
                {
                    return 11 - time;
                }

                return 12 - time;
            }
            else
            {
                if (time == 60  || time == 0)
                {
                    return 0;
                }

                return 60 - time;
            }
        }
    }
}
