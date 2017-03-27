using System;

namespace estore_model
{
    public class Ping
    {
        public string ResponseMessage { get; set; }
        public string Url { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public DateTime ServerTimestamp { get; set; }
    }
}
