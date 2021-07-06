using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface INonIndexerFluentSetTaskResult<TMock,TTaskResult> where TMock : class
    {
        ISetterBuilder<TMock, Task<TTaskResult>> Set(Task<TTaskResult> property);
    }
    
}


