using System;

namespace Common
{
    [Serializable]
    public class Result<T>
    {
        public T ReturnValue { get; set; }
        public string ReturnMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}
