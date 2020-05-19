using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SOLID;
using Services.Filters;
using Services.Exceptions;

namespace Services.Controllers
{
    [Route("api/User")]
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            string message = "IN HOME CONTROLLER";
            return Ok(message);
        }

        [HttpGet]
        [Route("Permission")]
        public IActionResult PostSample()
        {
            //TODO 
            //checking user permissions by identity services 
            throw new AuthorizationException("Unauthorised access"," User Permission is not allowed");
        }


        public IActionResult Get()
        {
            string message = "IN HOME CONTROLLER";
            return Ok(message);
        }
    }
}