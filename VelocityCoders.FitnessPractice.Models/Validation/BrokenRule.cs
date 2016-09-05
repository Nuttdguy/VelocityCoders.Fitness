using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.Models
{

    public class BrokenRule
    {
        /// <summary>
        /// Constructor to initialize new instance of BrokenRule class.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="message"></param>
        public BrokenRule(string propertyName, string message)
        {
            this.PropertyName = propertyName;
            this.Message = message;

        }

        public string PropertyName { get; set; }
        public string Message { get; set; }

    }

    public class BrokenRuleCollection : Collection<BrokenRule>
    {

        #region METHODS

        /// <summary>
        /// Creates a new BrokenRule instance and adds it to the inner list.
        /// </summary>
        /// <param name="message"></param>

        public void Add(string message)
        {
            Add(new BrokenRule(string.Empty, message));
        }

        /// <summary>
        /// Creates a new BrokenRule instance and adds it to the inner list.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="message"></param>
        public void Add(string propertyName, string message)
        {
            Add(new BrokenRule(propertyName, message));
        }

        #endregion
    }


}
