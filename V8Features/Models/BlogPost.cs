using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace V8Features
{
    public class BlogPost 
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string SharedBy { get ; set ; }

        public List<Comment> Comments;
        public BlogPost(string type, ICollection<Comment> comments ,string title )
        {
            Type = type;
            Comments = comments.ToList();
            Title = title;
        }
        public bool isShareAble()
        {
            if (Comments.Any(c => c.PostedBy is { Role: "admin", IsCreator : true })) //PropertyPatternSample tries to match property 
                return true;

            return false;
        }

    }
    
}
