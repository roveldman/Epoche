using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Epoche
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "Ranges.json";

            if(args.Length > 0)
            {
                filename = args[0];
            }

            List<TimeRange> ranges = new List<TimeRange>();
            PersonalDetails personal = null;

            try
            {
                var fileContents = File.ReadAllText(filename);
                var convertOptions = new JsonSerializerOptions();
                convertOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                ranges = JsonSerializer.Deserialize<List<TimeRange>>(fileContents, convertOptions);

                personal = JsonSerializer.Deserialize<PersonalDetails>(File.ReadAllText("Personal.json"));
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            DateTime birth = personal.BirthDate;

            DateTime death = birth.AddYears(personal.LifeExpectancy);
            DateTime now = DateTime.Now;
            int yearGrouping = 5;

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

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
