using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelocityCoders.FitnessPratice.WebForm
{
    public static class Utilities
    {
        public static string GetApplicationKeyValue(string keyName)
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings[keyName];
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}