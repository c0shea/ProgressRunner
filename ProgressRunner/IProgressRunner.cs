using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgressRunner
{
    public interface IProgressRunner
    {
        string Title { get; set; }
        bool IsRunning { get; }

        void AddTask(IRunnableTask task);
        void AddTasks(IEnumerable<IRunnableTask> tasks);
        Task RunAsync();
    }
}
