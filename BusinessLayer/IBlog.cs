using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBlog
    {
        bool Add(BlogModel model);
        bool Update(int id, BlogModel model);
        bool Delete(int id);
        IEnumerable<BlogModel> Get();
    }
}
