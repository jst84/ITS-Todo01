using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace Todo.UI.Controllers
{
    [RoutePrefix("api/todo")]
    public class TodoController : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public List<Todo.DAL.Todo> GetAll()
        {
            DAL.DAL d = new DAL.DAL(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            var todos = d.GetTodos();
            return todos;
        }

        [HttpDelete]
        [Route("DeleteTodo")]
        public HttpResponseMessage DeleteTodo(DAL.Todo todo)
        {
            try
            {
                DAL.DAL d = new DAL.DAL(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                var response = d.DeleteTodo(todo);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                //send email
                //appInsight.TrackError(ex);
                

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }

            //return true;
        }
    }
}
