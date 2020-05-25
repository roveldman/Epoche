using System;
using System.Collections.Generic;
using System.Linq;

namespace Epoche
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime birth = new DateTime(1991, 1, 1);
            int lifeExpectancy = 70;
            DateTime death = birth.AddYears(lifeExpectancy);
            DateTime now = DateTime.Now;
            int yearGrouping = 5;

            var ranges = new List<TimeRange>();
            ranges.Add(new TimeRange
            {
                Color = ConsoleColor.DarkYellow,
                Character = '*',
                Start = new DateTime(2002, 8, 1),
                End = new DateTime(2008, 8, 1)
            });
            ranges.Add(new TimeRange
            {
                Color = ConsoleColor.DarkRed,
                Character = 'X',
                Start = new DateTime(2008, 8, 1),
                End = new DateTime(2009, 8, 1)
            });
            ranges.Add(new TimeRange
            {
                Color = ConsoleColor.DarkGreen,
                Character = '$',
                Start = new DateTime(2010, 1, 1),
                End = new DateTime(2015, 4, 30)
            });

            for (int year = birth.Year; year < death.Year + 1; year++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                if ((year - birth.Year) % yearGrouping == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    Console.Write(year + " ");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("|");
                }

                for (int month = 1; month <= 12; month++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    var date = new DateTime(year, month, now.Day);
                    if (date.AddDays(-date.Day + 1).AddMonths(1) <= birth)
                    {
                        Console.Write(" ");
                    } else if (date.AddDays(-date.Day + 1).AddMonths(1) > death)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        var match = ranges.Where(x => x.Start < date && x.End > date).FirstOrDefault();
                        if (match != null)
                        {
                            Console.BackgroundColor = match.Color;
                            Console.Write(match.Character);
                        } else if (date > DateTime.Now)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(".");
                        } else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("-");
                        }
                    }
                    
                }

            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
