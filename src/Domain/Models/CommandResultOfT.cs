namespace Domain.Models
{
    public class CommandResultOfT<T> : CommandResult
    {
        public T Result { get; private set; }

        public static new CommandResultOfT<T> Create()
        {
            return new CommandResultOfT<T>();
        }
        public void SetResult(T result)
        {
            Result = result;
        }
    }
}
