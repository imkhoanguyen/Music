using Music.Domain.Consts;
using Music.Domain.Enum;

namespace Music.Application.Dtos
{
    public class TData<T> : TData
    {
        /// <summary>
        /// total records, used for pagination
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// data
        /// </summary>
        public T? Data { get; set; }

        public void SetSuccess(T data, string? message = null, string? description = null)
        {
            Data = data;
            base.SetSuccess(message, description);
        }
    }
}
