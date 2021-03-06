﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VelocityCoders.FitnessPractice.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelloWorld" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HelloWorld.svc or HelloWorld.svc.cs at the Solution Explorer and start debugging.
    public class HelloWorld : IHelloWorld
    {

        public string GetHelloWorld(string firstName)
        {
            if (!string.IsNullOrEmpty(firstName))
                return "Hi " + firstName + ". This is a Hello World example.";
            else
                return "Hi stranger. This is a Hello World example.";
        }

    }
}
