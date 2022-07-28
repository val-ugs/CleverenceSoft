using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverenceSoftTasks.Task2
{
    public class AsyncCaller
    {
        private EventHandler _eh;
        public AsyncCaller(EventHandler eh)
        {
            _eh = eh;
        }

        public bool Invoke(int millisecondsTimeout, object? sender, EventArgs e)
        {
            var task = Task.Factory.StartNew(() => _eh.Invoke(sender, e));

            return task.Wait(millisecondsTimeout);
        }
    }
}
