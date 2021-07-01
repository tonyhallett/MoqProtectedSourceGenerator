namespace MoqProtectedGenerated
{
    public interface INonIndexerFluentGetSet<T, TProperty> : INonIndexerFluentGet<T, TProperty>, INonIndexerFluentSet<T, TProperty> where T : class
    {
        void SetupProperty(TProperty initialValue = default(TProperty)); // return type tbd
    }
}
