namespace Adform_Todo.Common.Models
{
    public class RequestResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
    }
}
