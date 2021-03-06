﻿using System.Configuration;

namespace VelocityCoders.FitnessPractice.DAL
{
    public static class AppConfiguration
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;  }
        }

        public static string ConnectionStringName
        {
            get { return ConfigurationManager.AppSettings["ConnectionStringName"];  }
        }

    }
}
