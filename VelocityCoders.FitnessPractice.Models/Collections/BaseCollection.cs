using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VelocityCoders.FitnessPractice.Models
{
    public abstract class BaseCollection<T> : Collection<T>, IList<T>
    {
        protected BaseCollection() : base(new List<T>()) { }
    }
}
