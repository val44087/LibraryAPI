﻿using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class CachingController : ControllerBase
    {
        ILookupDevelopers DeveloperLookup;

        public CachingController(ILookupDevelopers developerLookup)
        {
            DeveloperLookup = developerLookup;
        }

        [HttpGet("/time")]
        [ResponseCache(Duration = 30)]
        public ActionResult GetTime()
        {
            return Ok(new { data = $"The time is now{ DateTime.Now.ToLongTimeString()}" });
        }

        [HttpGet("/oncall")]
        public async Task<ActionResult> GetOnCallDeveloper()
        {
           // var onCallDeveloper = "BOB";
            string onCallDeveloper = await DeveloperLookup.GetCurrentOnCallDeveloper();
            return Ok(new { developer  = onCallDeveloper });

        }
    }
}
