using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgressRunner
{
    public interface IProgressRunner
    {
        string Title { get; set; }
        bool IsRunning { get; }

        void AddTask(RunnableTask task);
        void AddTasks(IEnumerable<RunnableTask> tasks);
        Task RunAsync();
    }
}
