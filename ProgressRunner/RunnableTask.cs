using System;
using System.Threading;

namespace ProgressRunner
{
    public class RunnableTask
    {
        public string Name { get; }
        public Action<IProgress<IterationStatus>, CancellationToken> Task { get; }

        public RunnableTask(string name, Action<IProgress<IterationStatus>, CancellationToken> task)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Task = task ?? throw new ArgumentNullException(nameof(task));
        }
    }
}
