using estore_common;
using estore_model;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace estore_api.Controllers
{
    public class DefaultController : ApiController
    {
        [AllowAnonymous]
        [Route(ControllerConstants.DefaultApiPrefix)]
        [HttpGet]
        public HttpResponseMessage Ping()
        {
            var result = new Ping
            {
                ResponseMessage = "Pong!",
                Url = Request.RequestUri.ToString(),
                StatusCode = (int)HttpStatusCode.OK,
                StatusMessage = "API is Up and Running!",
                ServerTimestamp = DateTime.Now
            };
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
