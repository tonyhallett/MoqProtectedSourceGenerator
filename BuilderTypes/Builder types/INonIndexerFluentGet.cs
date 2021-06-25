public interface INonIndexerFluentGet<T, TProperty> where T : class
{
    IGetterBuilder<T, TProperty> Get();

}

public interface IIndexerFluentGet<T, TKey, TProperty> where T : class
{
    IGetterBuilder<T, TProperty> Get(TKey key);

}

public interface IIndexerFluentGet<T, TKey1,TKey2, TProperty> where T : class
{
    IGetterBuilder<T, TProperty> Get(TKey1 key1, TKey2 key2);

}

public class IndexerFluentGet<T, TKey1, TKey2, TProperty> : IIndexerFluentGet<T, TKey1, TKey2, TProperty> where T : class
{
    public IGetterBuilder<T, TProperty> Get(TKey1 key1, TKey2 key2)
    {
        throw new System.NotImplementedException();
    }
}
