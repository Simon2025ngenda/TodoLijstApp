using LiteDB;
using TodoLijstApp.databases;
using TodoLijstApp.Models;

namespace TodoLijstApp.Repositories;

public class TaskRepository
{
    private readonly ILiteCollection<TaskItem> _tasks;

    public TaskRepository()
    {
        var db = new DatabaseContext();

        _tasks = db.GetCollection<TaskItem>("tasks");
    }

    public List<TaskItem> GetAll()
    {
        return _tasks.FindAll().ToList();
    }

    public void Add(TaskItem task)
    {
        _tasks.Insert(task);
    }

    public void Update(TaskItem task)
    {
        _tasks.Update(task);
    }

    public void Delete(int id)
    {
        _tasks.Delete(id);
    }
}