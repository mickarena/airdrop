using System.Collections.Generic;
using Newtonsoft.Json;

namespace Renewal.Application.ResultObjects
{
    public abstract class AbstractResult<T>
    {
        protected AbstractResult() { }

        protected AbstractResult(T obj, params string[] messages)
        {
            Messages = new List<string>(messages);

            ResultObj = obj;
        }

        protected AbstractResult(T obj, IEnumerable<string> messageList)
        {
            Messages = new List<string>(messageList);

            ResultObj = obj;
        }

        public abstract bool IsSuccess { get; set; }

        public IList<string> Messages { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonIgnore]
        public string PlainTextMessages => JsonConvert.SerializeObject(Messages);

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T ResultObj { get; set; }

        [JsonIgnore]
        public bool IsSuccessResult
        {
            get
            {
                if (GetType().IsGenericType
                    && GetType().GetGenericTypeDefinition() == typeof(AppSuccessResult<>))
                {
                    return true;
                }

                return GetType() == typeof(AppResultDetail) && IsSuccess;
            }
        }

        [JsonIgnore]
        public bool IsErrorResult => !IsSuccessResult;

        public void SetIsSuccess(bool isSuccess) => IsSuccess = isSuccess;
    }

    public sealed class AppResultDetail : AbstractResult<string>
    {
        public AppResultDetail()
        {
        }

        public AppResultDetail(bool isSuccess, params string[] messages)
            : base(null, messages)
        {
            IsSuccess = isSuccess;
        }

        public AppResultDetail(bool isSuccess, IEnumerable<string> messageList)
            : base(null, messageList)
        {
            IsSuccess = isSuccess;
        }

        public override bool IsSuccess { get; set; }
    }

    public sealed class AppSuccessResult<T> : AbstractResult<T>
    {
        public AppSuccessResult()
        {
        }

        public override bool IsSuccess { get; set; } = true;

        public AppSuccessResult(T obj, params string[] messages)
            : base(obj, messages) { }

        public AppSuccessResult(T obj, IEnumerable<string> messageList)
            : base(obj, messageList) { }
    }

    public sealed class AppErrorResult<T> : AbstractResult<T>
    {
        public AppErrorResult()
        {
        }

        public override bool IsSuccess { get; set; } = false;

        public AppErrorResult(T obj, params string[] messages)
            : base(obj, messages) { }

        public AppErrorResult(T obj, IEnumerable<string> messageList)
            : base(obj, messageList) { }
    }
}
