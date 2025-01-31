﻿using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public HttpResponseMessage Found(object obj)
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, obj);
        }

        public new HttpResponseMessage BadRequest(string message)
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.BadRequest, message);
        }

        public HttpResponseMessage Found()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage DoesNotExist()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Conflict(string message)
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.Conflict, message);
        }

        public HttpResponseMessage NoContent()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}