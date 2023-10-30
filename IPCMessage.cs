using System;

namespace IPCLocal
{
    public class IPCMessage
    {
        public string ApplicationName { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
