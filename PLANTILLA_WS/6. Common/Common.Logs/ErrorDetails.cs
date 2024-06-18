using Newtonsoft.Json;

namespace Common.Logs
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = default!;
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
