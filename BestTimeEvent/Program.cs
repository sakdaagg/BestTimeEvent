using System.Collections.Generic;
using System;
using System.Linq;

namespace BestTimeEvent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Etkinlik sayisini giriniz: ");
            int eventsCount = int.Parse(Console.ReadLine());

            List<Events> events = new List<Events>();
            int Id = 0;

            for (int i = 0; i < eventsCount; i++)
            {
                Id++;

                Console.WriteLine("Etkinlik baslangic zamani giriniz:");
                DateTime startTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Etkinlik bitis zamani giriniz:");
                DateTime endTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Etkinlik yerini giriniz:");
                string location = Console.ReadLine();
                Console.WriteLine("Etkinlik onem derecesini giriniz:");
                int priority = int.Parse(Console.ReadLine());
                Events evnt = new Events(Id, startTime, endTime, location, priority);
                events.Add(evnt);
            }

            List<string> locationList = events.Select(k => k.Location).Distinct().ToList();

            List<KeyValuePair<string, Locations>> locations = new List<KeyValuePair<string, Locations>>();

            foreach(var location in locationList)
            {
                locations.Add(new KeyValuePair<string, Locations>
                    (location, new Locations(location)));
            }

            Console.WriteLine("Kac tane mekanlar arasi ulasim suresi eklemek istiyorsunuz?");
            int travelTimeCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < travelTimeCount; i++)
            {
                Console.WriteLine("Bulundugunuz mekanin ismini giriniz: ");
                string from = Console.ReadLine();
                Console.WriteLine("Gideceginiz mekanin ismini giriniz: ");
                string to = Console.ReadLine();
                Console.WriteLine("Bu iki mekan arasi ulaşım süresini giriniz: ");
                int travelTime = int.Parse(Console.ReadLine());
                locations.Find(k => k.Key == from).Value.AddTravelTime(to, travelTime);
            }

            Console.WriteLine("Uygun oldugunuz baslangic saatini giriniz:");
            DateTime currentStartTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Uygun oldugunuz bitis saatini giriniz:");
            DateTime currentEndTime = DateTime.Parse(Console.ReadLine());

            BestTimeEventCalculator calculator = new BestTimeEventCalculator(events, locations);

            var calculatorResult = calculator.GetBestTimeEvents(currentStartTime, currentEndTime);

            Console.WriteLine($"Katılınabilecek Maksimum Etkinlik Sayısı: {calculatorResult.BestEventCount}");
            Console.WriteLine("Katılınabilecek Etkinliklerin ID'leri: " + string.Join(", ", calculatorResult.BestEventIds));
            Console.WriteLine($"Toplam Değer (Priority): {calculatorResult.Total}");
        }
    }
}
