using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface INonIndexerFluentSetValueTaskResult<TMock, TValueTaskResult> where TMock : class
    {
        ISetterBuilder<TMock, ValueTask<TValueTaskResult>> Set(ValueTask<TValueTaskResult> property);
    }
    
}


