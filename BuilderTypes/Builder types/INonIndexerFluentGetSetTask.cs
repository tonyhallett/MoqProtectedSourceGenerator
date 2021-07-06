using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface INonIndexerFluentGetSetTask<TMock>:
        INonIndexerFluentGetTask<TMock>,
        INonIndexerFluentSetTask<TMock>,
        ISetupProperty<TMock,Task>
        where TMock : class
    { }
    
}


