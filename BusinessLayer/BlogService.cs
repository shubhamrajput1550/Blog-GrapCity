using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Model;
using DBLayer.DBEntity;

namespace BusinessLayer
{
    public class BlogService : IBlog
    {
        public bool Add(BlogModel model)
        {
            bool isAdded = false;
            using (BlogDBEntities dbContext = new BlogDBEntities())
            {
                Blog_Mst temp = new Blog_Mst()
                {
                    Title = model.Title,
                    BlogContent = model.BlogContent,
                    Description = model.Description,
                    FK_User_Id = model.FK_User_Id,
                    Keyword = model.Keyword,
                    IsActive = model.IsActive
                };
                dbContext.Blog_Mst.Add(temp);
                isAdded = dbContext.SaveChanges() > 0;
            }
            return isAdded;
        }

        public bool Update(int id, BlogModel model)
        {
            bool isUpdated = false;

            using (var dbContext = new BlogDBEntities())
            {
                if (!dbContext.Blog_Mst.Any(p => p.PK_Blog_id == id))
                {
                    throw new Exception("Not Found.");
                }
                var findObject = dbContext.Blog_Mst.Find(id);
                findObject.Title = model.Title;
                findObject.Keyword = model.Keyword;
                findObject.Description = model.Description;
                findObject.BlogContent = model.BlogContent;
                dbContext.Entry(findObject).State = System.Data.Entity.EntityState.Modified;
                isUpdated = dbContext.SaveChanges() > 0;
            }
            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDelete = false;
            using (var dbContext = new BlogDBEntities())
            {
                if (!dbContext.Blog_Mst.Any(p => p.PK_Blog_id == id))
                {
                    throw new Exception("Not Found.");
                }

                dbContext.Blog_Mst.Remove(dbContext.Blog_Mst.First(p => p.PK_Blog_id == id));
                isDelete = dbContext.SaveChanges() > 0;
            }
            return isDelete;

        }
        public IEnumerable<BlogModel> Get()
        {
            IEnumerable<BlogModel> blogsList = null;
            using (var dbContext = new BlogDBEntities())
            {

                blogsList = (from m in dbContext.Blog_Mst
                             select new BlogModel()
                             {
                                 Id = m.PK_Blog_id,
                                 Title = m.Title,
                                 BlogContent = m.BlogContent,
                                 Description = m.Description,
                                 FK_User_Id = m.FK_User_Id,
                                 Keyword = m.Keyword,
                                 IsActive = m.IsActive
                             }).ToList();
            }
            return blogsList;
        }

    }
}
