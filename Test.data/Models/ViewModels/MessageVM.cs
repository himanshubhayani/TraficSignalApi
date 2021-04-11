using System;
using System.Collections.Generic;
using System.Text;

namespace Test.data.Models
{
    public class MessageVM
    {
        public int MessageType { get; set; }
        public string Message { get; set; }
    }

    public enum MessageType
    {
        Success = 1,
        Validation = 2,
        Error = 3
    }
}
