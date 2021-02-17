using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
        public string BlogContent { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public int FK_User_Id { get; set; }
    }
}
