using System;

namespace AirborneBall.Interacts
{
    public interface IInitializable<T>
    {
        public void Init(T data);
    }
}
