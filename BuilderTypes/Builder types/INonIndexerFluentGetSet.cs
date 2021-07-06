namespace MoqProtectedGenerated
{
    public interface INonIndexerFluentGetSet<TMock, TProperty> : 
        INonIndexerFluentGet<TMock, TProperty>, 
        INonIndexerFluentSet<TMock, TProperty>,
        ISetupProperty<TMock,TProperty>
        where TMock : class
    {
       
    }
}
