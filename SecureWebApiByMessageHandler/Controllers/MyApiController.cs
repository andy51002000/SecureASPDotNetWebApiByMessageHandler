using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace SecureWebApiByMessageHandler.Controllers
{
    public class MyApiController : ApiController
    {
        [HttpGet]
        [Route("api/myapi/res")]
        public IHttpActionResult GetResource1()
        {
            return Ok("Hello Andy: welcome to my site ");
        }

    }
}