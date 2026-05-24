using LiteDB;
using TodoLijstApp.databases;
using TodoLijstApp.Models;

namespace TodoLijstApp.Repositories;

public class PersonRepository
{
    private readonly ILiteCollection<Person> _persons;

    public PersonRepository()
    {
        var db = new DatabaseContext();
        _persons = db.GetCollection<Person>("persons");
    }

    public List<Person> GetAll()
    {
        return _persons.FindAll().ToList();
    }

    public Person? GetById(int id)
    {
        return _persons.FindById(id);
    }

    public void Add(Person person)
    {
        _persons.Insert(person);
    }

    public void Update(Person person)
    {
        _persons.Update(person);
    }

    public void Delete(int id)
    {
        _persons.Delete(id);
    }
}