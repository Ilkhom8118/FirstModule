using CRUD_Person.Models;

namespace CRUD_Person.Services;

public class PersonServices
{
    private List<Person> persons;
    public PersonServices()
    {
        persons = new List<Person>();
    }

    public Person PersonAdd(Person added)
    {

        added.Id = Guid.NewGuid();
        persons.Add(added);
        return added;
    }

    public bool PersonDelete(Guid id)
    {
        var TF = false;
        foreach (var person in persons)
        {
            if (person.Id == id)
            {
                persons.Remove(person);
                TF = true;
                break;
            }
        }
        return TF;
    }
    public Person GetByPersonId(Guid id)
    {
        foreach (var person in persons)
        {
            if (person.Id == id)
            {
                return person;
            }
        }
        return null;
    }
    public bool PersonUpdate(Person newPerson)
    {
        var personId = GetByPersonId(newPerson.Id);
        var TF = true;
        if (personId is null)
        {
            TF = false;
        }
        persons[persons.IndexOf(personId)] = newPerson;
        return TF;
    }
    public List<Person> GetAll()
    {
        return persons;
    }
}
