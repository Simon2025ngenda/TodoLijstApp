using TodoLijstApp.Models;

namespace TodoLijstApp.Strategies;

public class AllTasksFilterStrategy : ITaskFilterStrategy
{
    public List<TaskItem> Filter(List<TaskItem> tasks)
    {
        return tasks;
    }
}