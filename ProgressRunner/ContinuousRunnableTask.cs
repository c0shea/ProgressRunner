using System;

namespace ProgressRunner
{
    public class ContinuousRunnableTask : IRunnableTask
    {
        public string Name { get; }
        public Action Task { get; }

        public ContinuousRunnableTask(string name, Action task)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Task = task ?? throw new ArgumentNullException(nameof(task));
        }
    }
}
