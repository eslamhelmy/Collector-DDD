namespace Collector.Domain.ViewModels
{
        public abstract class ResponseViewModel<T>
        {
            public T Data { get; set; }
            public string Message { get; set; }
            public bool Status { get; set; }
        }

        public class SuccessResponseDto<T> : ResponseViewModel<T>
        {
            public SuccessResponseDto()
            {
                Status = true;
            }
        }

        public class FailureResponseDto<T> : ResponseViewModel<T>
        {
            public FailureResponseDto()
            {
                Status = false;
            }
        }
    }
