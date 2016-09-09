using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.Models
{
    public class BLLException : Exception
    {
        //====  PROPERTIES
        public BrokenRuleCollection BrokenRules { get; set; }


        //====  CONSTRUCTORS

        public BLLException() : base() { }        

        public BLLException(string message) : base(message) { }

        public BLLException(string message, BrokenRuleCollection brokenRules) : base(message)
        {
            this.BrokenRules = brokenRules;
        }

        public BLLException(string message, Exception inner) : base(message, inner) { }

        public BLLException(string message, Exception inner, BrokenRuleCollection brokenRules) : base(message, inner)
        {
            this.BrokenRules = brokenRules;
        }

    }
}
