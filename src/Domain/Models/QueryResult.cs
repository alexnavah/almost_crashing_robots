namespace Domain.Models
{
    public class QueryResultOfT<T>
    {
        public T Result { get; set; }

        public static QueryResultOfT<T> Create()
        {
            return new QueryResultOfT<T>();
        }

        public void SetResult(T result)
        {
            Result = result;
        }
    }
}
