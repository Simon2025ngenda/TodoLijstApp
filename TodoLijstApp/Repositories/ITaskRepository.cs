using TodoLijstApp.Models;

namespace TodoLijstApp.Repositories;

public interface ITaskRepository
{
    List<TaskItem> GetAll();
    void Add(TaskItem task);
    void Update(TaskItem task);
    void Delete(int id);
}