using _9_dars_uyga_vazifa.Models;

namespace _9_dars_uyga_vazifa.Services;

public class EventService
{
    private List<Event> ListedEvents;

    public EventService()
    {
        ListedEvents = new List<Event>();
        DataSeed();
    }

    public Event AddedEvent(Event addingEvent)
    {
        addingEvent.ID = Guid.NewGuid();
        ListedEvents.Add(addingEvent);
        return addingEvent;
    }
    public Event GetById(Guid eventId)
    {
        foreach (var chek in ListedEvents)
        {
            if (chek.ID == eventId)
            {
                return chek;
            }
        }
        return null;
    }
    public bool DeletedEvent(Guid Id)
    {
        var deleteEvent = GetById(ListedEvents.ID);
        if (deleteEvent is null)
        {
            return false;
        }
        ListedEvents.Remove(deleteEvent);
        return true;
    }
    public bool UpdateEvent(Event eventId)
    {
        var eventDb = GetById(eventId.ID);
        if (eventDb is null)
        {
            return false;
        }
        var index = ListedEvents.IndexOf(eventDb);
        ListedEvents[index] = eventDb;
        return true;
    }
    public List<Event> GetAllEvents()
    {
        return ListedEvents;
    }
    public void DisplayInfo(Event chek)
    {
        Console.WriteLine($"ID: {chek.ID}");
        Console.WriteLine($"Title: {chek.Title}");
        Console.WriteLine($"Location: {chek.Location}");
        Console.WriteLine($"Date: {chek.Date}");
        Console.WriteLine($"Description: {chek.Description}");
        Console.WriteLine("Attendees: ");
        foreach (var name in chek.Attendees)
        {
            Console.WriteLine($" - {name}");
        }
        Console.WriteLine("Tags: ");
        foreach (var tag in chek.Tags)
        {
            Console.WriteLine($" - {tag}");
        }
    }
    public List<Event> GetEventsByLocation(string location)
    {
        var eventsByLocation = new List<Event>();
        foreach (var chek in ListedEvents)
        {
            if (chek.Location == location)
            {
                eventsByLocation.Add(chek);
            }
        }

        return eventsByLocation;
    }

    public Event GetPopularEvent()
    {
        var mostPopularevent = new Event();
        foreach (var eventItem in ListedEvents)
        {
            if (eventItem.Attendees.Count > mostPopularevent.Attendees.Count)
            {
                mostPopularevent = eventItem;
            }
        }

        return mostPopularevent;
    }
 
    public Event GetMaxTaggedEvent()
    {
        var mostTaggedEvent = new Event();
        foreach (var eventItem in ListedEvents)
        {
            if (eventItem.Attendees.Count > mostTaggedEvent.Attendees.Count)
            {
                mostTaggedEvent = eventItem;
            }
        }

        return mostTaggedEvent;
    }

    public bool AddPersonToEvent(Guid Id, string person)
    {
        var EventFromDB = GetById(Id);
        if (EventFromDB is null)
        {
            return false;
        }
        EventFromDB.Attendees.Add(person);

        return true;
    }

}