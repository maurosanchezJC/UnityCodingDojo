using System;
using System.Collections.Generic;

namespace CodingDojo3.Example1
{
    public class Example1A
    {
        public string GetDayOfTheWeek(int dayNumber)
        {
            string[] days = new[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            if (dayNumber < 1 || dayNumber > 7)
            {
                throw new Exception("Invalid day number!");
            }

            int dayIndex = dayNumber - 1;

            return days[dayIndex];

        }
    }

    public class Example1B
    {
        public string GetDayOfTheWeek(int dayNumber)
        {
            switch (dayNumber)
            {
                case 1:
                    return "Monday";
                case 2:
                    return "Tuesday";
                case 3:
                    return "Wednesday";
                case 4:
                    return "Thursday";
                case 5:
                    return "Friday";
                case 6:
                    return "Saturday";
                case 7:
                    return "Sunday";
                default:
                    throw new Exception("Invalid day number!");
            }
        }
    }

    public class Example1C
    {
        public string GetDayOfTheWeek(int number)
        {
            Dictionary<int, string> dayDic = new Dictionary<int, string>
            {
                { 1, "Monday" },
                { 2, "Tuesday" },
                { 3, "Monday" },
                { 4, "Wednesday" },
                { 5, "Thursday" },
                { 6, "Saturday" },
                { 7, "Sunday" },
            };

            if (!dayDic.ContainsKey(number))
            {
                throw new Exception("Invalid day number!");
            }

            return dayDic[number];
        }
    }
}