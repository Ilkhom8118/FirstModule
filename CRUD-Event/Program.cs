using CRUD_Event.Models;
using CRUD_Event.Services;

namespace CRUD_Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FrontEnd();
        }
        public static void FrontEnd()
        {
            var eventService = new EventServices();
            while (true)
            { 
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. GetAll");
                Console.WriteLine("5. GetById");
                Console.WriteLine("6. View Events By Location");
                Console.WriteLine("7. View Popular Event");
                Console.WriteLine("8. View Max Tagged Event");
                Console.WriteLine("9. Add Person To Event");
                Console.Write("Choose: ");
                var option = int.Parse(Console.ReadLine());
                Event evnt;
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        evnt = FillEvent();
                        eventService.Add(evnt);
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Enter Id Of Event: ");
                        var id = Guid.Parse(Console.ReadLine());
                        if (eventService.Delete(id))
                        {
                            Console.WriteLine("Deleted !!!");
                        }
                        else
                        {
                            Console.WriteLine("Not Deleted !!!");
                        }
                        break;
                    case 3:
                        Console.Clear();

                        Console.Write("Enter Id Of Event: ");
                        var evntId = Guid.Parse(Console.ReadLine());
                        evnt = FillEvent();
                        evnt.Id = evntId;
                        if (eventService.Update(evnt))
                        {
                            Console.WriteLine("Updated !!!");
                        }
                        else
                        {
                            Console.WriteLine("Not Updated !!!");
                        }
                        break;
                    case 4:
                        Console.Clear();
                        eventService.ShowInfo();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Enter Id Of Event: ");
                        var eventId = Guid.Parse(Console.ReadLine());
                        evnt = eventService.GetById(eventId);
                        ShowEventInfo(evnt);
                        break;
                    case 6:
                        Console.Clear();
                        Console.Write("Enter Location: ");
                        var location = Console.ReadLine();
                        List<Event> listOfEvents = eventService.GetEventsByLocation(location);
                        foreach (var eventObj in listOfEvents)
                        {
                            ShowEventInfo(eventObj);
                        }
                        break;
                    case 7:
                        Console.Clear();
                        evnt = eventService.GetPopularEvent();
                        ShowEventInfo(evnt);
                        break;
                    case 8:
                        Console.Clear();
                        evnt = eventService.GetMaxTaggedEvent();
                        ShowEventInfo(evnt);
                        break;
                    case 9:
                        Console.Clear();
                        Console.Write("Enter Id Of Event: ");
                        var evId = Guid.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        var name = Console.ReadLine();
                        eventService.AddPersonToEvent(evId, name);
                        break;
                }
            }

        }


        public static void ShowEventInfo(Event evnt)
        {

            Console.WriteLine($"Id: {evnt.Id}");
            Console.WriteLine($"Title: {evnt.Title}");
            Console.WriteLine($"Time: {evnt.Time}");
            Console.WriteLine($"Location: {evnt.Location}");
            Console.WriteLine($"Description: {evnt.Description}");
            Console.WriteLine($"Attendees:");
            foreach (var person in evnt.Attendees)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine($"Tag: ");
            foreach (var person in evnt.Tags)
            {
                Console.WriteLine(person);
            }
            
        }
        public static Event FillEvent()
        {
            var evnt = new Event();
            Console.Write("Enter Title: ");
            evnt.Title = Console.ReadLine();
            Console.Write("Enter Location: ");
            evnt.Location = Console.ReadLine();
            evnt.Time = DateTime.Now;
            Console.Write("Enter Description: ");
            evnt.Description = Console.ReadLine();
            Console.WriteLine("Enter Attendess: ");
            string name = "";
            while (true)
            {
                name = Console.ReadLine();
                if (name == "stop")
                {
                    break;
                }
                evnt.Attendees.Add(name);
            }
            Console.Write("Enter Tags");
            while (true)
            {
                name = Console.ReadLine();
                if (name == "stop")
                {
                    break;
                }
                evnt.Tags.Add(name);
            }
            return evnt;
        }
    }
}
