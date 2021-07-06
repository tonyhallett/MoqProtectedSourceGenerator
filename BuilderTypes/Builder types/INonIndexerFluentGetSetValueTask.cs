using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface INonIndexerFluentGetSetValueTask<TMock> :
        INonIndexerFluentGetValueTask<TMock>,
        INonIndexerFluentSetValueTask<TMock>,
        ISetupProperty<TMock, ValueTask>
        where TMock : class
    { }
    
}


