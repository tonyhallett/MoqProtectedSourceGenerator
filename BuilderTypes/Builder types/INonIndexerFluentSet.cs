public interface INonIndexerFluentSet<T, TProperty> where T : class
{
    ISetterBuilder<T, TProperty> Set(TProperty property);

}
