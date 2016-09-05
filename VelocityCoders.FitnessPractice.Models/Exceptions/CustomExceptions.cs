using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.Models
{
    public class CustomExceptions : Exception
    {
        //====  PROPERTIES
        public BrokenRuleCollection BrokenRules { get; set; }


        //====  CONSTRUCTORS

        public CustomExceptions() : base() { }        

        public CustomExceptions(string message) : base(message) { }

        public CustomExceptions(string message, BrokenRuleCollection brokenRules) : base(message)
        {
            this.BrokenRules = brokenRules;
        }

        public CustomExceptions(string message, Exception inner) : base(message, inner) { }

        public CustomExceptions(string message, Exception inner, BrokenRuleCollection brokenRules) : base(message, inner)
        {
            this.BrokenRules = brokenRules;
        }

    }
}
