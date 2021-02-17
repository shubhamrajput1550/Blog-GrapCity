using BusinessLayer;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicBlogApplication.Controllers
{
    public class BlogController : ApiController
    {
        IBlog service;
        public BlogController()
        {
            service = new BlogService();
        }

        // GET api/values
        public IEnumerable<BlogModel> Get()
        {
            return service.Get();
        }

        // POST api/values
        public IHttpActionResult Post(BlogModel model)
        {
            IHttpActionResult actionResult = null;
            try
            {
                var flag = service.Add(model);
                actionResult = Ok(flag);
            }
            catch(Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, BlogModel model)
        {
            IHttpActionResult actionResult = null;
            try
            {
                var flag = service.Update(id, model);
                actionResult = Ok(flag);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            IHttpActionResult actionResult = null;
            try
            {
                var flag = service.Delete(id);
                actionResult = Ok(flag);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }
    }
}
