using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface INonIndexerFluentGetSetValueTaskResult<TMock, TValueTaskResult> :
        INonIndexerFluentGetValueTaskResult<TMock, TValueTaskResult>,
        INonIndexerFluentSetValueTaskResult<TMock, TValueTaskResult>,
        ISetupProperty<TMock, ValueTask<TValueTaskResult>>
        where TMock : class
    { }
    
}


