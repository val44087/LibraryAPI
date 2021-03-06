﻿using LibraryApi.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPIIntergrationTests.Fakes
{
    public class TestingDeveloperCache : ILookupDevelopers
    {
        public Task<string> GetCurrentOnCallDeveloper()
        {
            return Task.FromResult("Shelly Johnson");
        }
    }
    
}
