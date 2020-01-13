using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler.Lib
{
    public static class TaskExtensions
    {
        public static async Task<TResult> TimeoutAfterAsync<TResult>(this Task<TResult> task, TimeSpan timeout, CancellationTokenSource cancellationTokenSource)
        {
            var completedTask = await Task.WhenAny(task, Task.Delay(timeout, cancellationTokenSource.Token));
            if (completedTask == task)
            {
                cancellationTokenSource.Cancel();
                return await task;  // Very important in order to propagate exceptions
            }
            else
            {
                throw new TimeoutException();
            }
        }

        public static async Task<TResult> TimeoutAfterAsync<TResult>(this Task<TResult> task, TimeSpan timeout)
        {
            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                return await task.TimeoutAfterAsync(timeout, timeoutCancellationTokenSource);
            }
        }
    }
}
