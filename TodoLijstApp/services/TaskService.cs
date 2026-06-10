using TodoLijstApp.Models;
using TodoLijstApp.Repositories;

namespace TodoLijstApp.services;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public List<TaskItem> GetAll()
    {
        return _taskRepository.GetAll();
    }

    public void Add(TaskItem task)
    {
        _taskRepository.Add(task);
    }

    public void Update(TaskItem task)
    {
        _taskRepository.Update(task);
    }

    public void Delete(int id)
    {
        _taskRepository.Delete(id);
    }
}