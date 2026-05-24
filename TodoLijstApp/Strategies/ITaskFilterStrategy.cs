using TodoLijstApp.Models;

namespace TodoLijstApp.Strategies;

public interface ITaskFilterStrategy
{
    List<TaskItem> Filter(List<TaskItem> tasks);
}