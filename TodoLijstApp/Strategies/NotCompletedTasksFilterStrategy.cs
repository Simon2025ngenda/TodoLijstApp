using TodoLijstApp.Models;

namespace TodoLijstApp.Strategies;

public class NotCompletedTasksFilterStrategy : ITaskFilterStrategy
{
    public List<TaskItem> Filter(List<TaskItem> tasks)
    {
        return tasks
            .Where(task => !task.IsCompleted)
            .ToList();
    }
}