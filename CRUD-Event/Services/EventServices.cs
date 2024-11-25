using CRUD_Event.Models;

namespace CRUD_Event.Services;

public class EventServices
{
    private List<Event> eventList;
    public EventServices()
    {
        eventList = new List<Event>();
    }
    public Event Add(Event added)
    {
        added.Id = Guid.NewGuid();
        eventList.Add(added);
        return added;
    }
    public bool Delete(Guid id)
    {
        var TF = false;
        foreach (var eventId in eventList)
        {
            if (eventId.Id == id)
            {
                eventList.Remove(eventId);
                TF = true;
                break;
            }
        }
        return TF;
    }
    public bool Update(Event obj)
    {
        var TF = false;
        for (var i = 0; i < eventList.Count; i++)
        {
            if (obj.Id == eventList[i].Id)
            {
                eventList[i] = obj;
                TF = true;
            }
        }
        return TF;
    }
    public void ShowInfo()
    {
        foreach (var read in eventList)
        {
            Console.WriteLine($"ID: {read.Id}");
            Console.WriteLine($"Title: {read.Title}");
            Console.WriteLine($"Location: {read.Location}");
            Console.WriteLine($"Description: {read.Description}");
            Console.WriteLine($"Date: {read.Time}");
            foreach (var person in read.Attendees)
            {
                Console.WriteLine($"Attendess: {person}");
            }
        }
        Console.ReadKey();
    }
    public Event GetById(Guid id)
    {
        foreach (var evnt in eventList)
        {
            if (evnt.Id == id)
            {
                return evnt;
            }
        }
        return null;
    }
    public List<Event> GetAll()
    {
        return eventList;
    }
    public List<Event> GetEventsByLocation(string location)
    {
        var newList = new List<Event>();
        foreach (var evnt in eventList)
        {
            if (evnt.Location == location)
            {
                newList.Add(evnt);
            }
        }
        return newList;
    }
    public Event GetPopularEvent()
    {
        var listEvent = new Event();
        foreach (var evnt in eventList)
        {
            if (evnt.Attendees.Count > listEvent.Attendees.Count)
            {
                listEvent = evnt;
            }
        }
        return listEvent;
    }
    public Event GetMaxTaggedEvent()
    {
        var maxComment = new Event();
        foreach (var evnt in eventList)
        {
            if (evnt.Tags.Count > maxComment.Tags.Count)
            {
                maxComment = evnt;
            }
        }
        return maxComment;
    }
    public bool AddPersonToEvent(Guid id, string name)
    {
        foreach (var evnt in eventList)
        {
            if (id == evnt.Id)
            {
                evnt.Attendees.Add(name);
                return true;
            }
        }
        return false;
    }

}
