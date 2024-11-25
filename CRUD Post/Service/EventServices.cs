using CRUD_Post.Models;

namespace CRUD_Post.Service;

internal class EventServices
{
    private List<Event> eventList;

    public EventServices()
    {
        var eventList = new Event();
    }

    public Event Add(Event added)
    {
        var id = Guid.NewGuid();
        eventList.Add(added);
        return added;
    }
    public bool Delete(Guid eventId)
    {
        var TF = false;
        foreach (var id in eventList)
        {
            if (id.Id == eventId)
            {
                eventList.Remove(id);
                TF = true;
                break;
            }
        }
        return TF;
    }

    public bool Update(Event updateEvent)
    {
        var TF = false;
        for (var i = 0; i < eventList.Count; i++)
        {
            if (eventList[i].Id == updateEvent.Id)
            {
                eventList[i] = updateEvent;
                TF = true;
                break;
            }
        }
        return TF;
    }
    public Event GetById(Guid id)
    {
        foreach (var eventId in eventList)
        {
            if (eventId.Id == id)
            {
                return eventId;
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
        var sameLocation = new List<Event>();
        foreach (var eventL in eventList)
        {
            if (eventL.Location == location)
            {
                sameLocation.Add(eventL);

            }
        }
        return sameLocation;
    }
    public Event GetPopularEvent()
    {
        var maxPopular = new Event();
        foreach (var count in eventList)
        {
            if (maxPopular.Attendees.Count < count.Attendees.Count)
            {
                maxPopular = count;
            }
        }
        return maxPopular;
    }
    public Event GetMaxTaggedEvent()
    {
        var maxTags = new Event();
        foreach (var tags in eventList)
        {
            if (tags.Tags.Count > maxTags.Tags.Count)
            {
                maxTags = tags;
            }
        }
        return maxTags;
    }

    public bool AddPersonToEvent(Guid personId, string name)
    {
        var res = GetById(personId);
        if (res is null)
        {
            return false;
        }
        eventList[eventList.IndexOf(res)].Attendees.Add(name);
        return true;
    }
}


//CRUD: Manage event details.
//GetEventsByLocation: Retrieve events in a specific location.
//GetPopularEvent: Find the event with the highest number of attendees.
//GetMaxTaggedEvent
//AddPersonToEvent