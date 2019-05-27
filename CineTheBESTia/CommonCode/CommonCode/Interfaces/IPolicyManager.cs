using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IPolicyManager
    {
        Task<T> GetFallbackPolicy<T>(Func<CancellationToken, Task<T>> fallBackAction, Func<Task<T>> action);
    }
}
