using System;
using System.Collections.Generic;
using System.Text;

namespace V8Features
{
    public class Comment
    {
        public string Body { get; set; }
        public Author PostedBy { get; set; }

        public Comment(string body, Author postedby)
        {
            Body = body;
            PostedBy = postedby;
        }
    }
}
