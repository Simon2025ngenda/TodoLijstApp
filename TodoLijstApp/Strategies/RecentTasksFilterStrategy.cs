using TodoLijstApp.Models;

namespace TodoLijstApp.Strategies;

public class RecentTasksFilterStrategy : ITaskFilterStrategy
{
    public List<TaskItem> Filter(List<TaskItem> tasks)
    {
        return tasks
            .OrderByDescending(task => task.UpdatedAt)
            .ToList();
    }
}