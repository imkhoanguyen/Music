using Music.Domain.Consts;
using Music.Domain.Enum;

namespace Music.Application.Dtos
{
    public class TData
    {
        /// <summary>
        /// result by enum
        /// </summary>
        public ResultStatus Status { get; set; }

        /// <summary>
        /// success or error message
        /// </summary>
        public string? Message { get; set; }

        public string? Description { get; set; }

        public void SetSuccess(string? message = null, string? description = null)
        {
            Status = ResultStatus.Success;
            Message = message ?? AppConsts.RES_SUCCESS;
            Description = description;
        }

        public void SetError(string? message = null, string? description = null)
        {
            Status = ResultStatus.InternalServerError;
            Message = message ?? AppConsts.RES_ERROR;
            Description = description;
        }

        public void SetNotFound(string? message = null, string? description = null)
        {
            Status = ResultStatus.NotFound;
            Message = message ?? AppConsts.RES_NOT_FOUND;
            Description = description;
        }

        public void SetBadRequest(string message, string? description = null)
        {
            Status = ResultStatus.BadRequest;
            Message = message;
            Description = description;
        }

    }
}
