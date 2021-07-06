using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface INonIndexerFluentGetSetTaskResult<TMock,TTaskResult> :
        INonIndexerFluentGetTaskResult<TMock,TTaskResult>,
        INonIndexerFluentSetTaskResult<TMock,TTaskResult>,
        ISetupProperty<TMock, Task<TTaskResult>>
        where TMock : class
    { }
    
}


