using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace System.Configuration
{
    public static class ConfigurationManagerEx
    {
        public static rb.Configuration.CustomWebConfig.AppSettingsClass AppSettings
        {
            get
            {
                return new rb.Configuration.CustomWebConfig.AppSettingsClass();
            }
        }
        public static rb.Configuration.CustomWebConfig.ConnectionStringClass ConnectionStrings
        {
            get
            {
                return new rb.Configuration.CustomWebConfig.ConnectionStringClass();
            }
        }
    }
}

namespace rb.Configuration
{
    public class CustomWebConfig
    {
        public static AppSettingsClass AppSettings
        {
            get
            {
                return new AppSettingsClass();
            }
        }
        public static ConnectionStringClass ConnectionStrings
        {
            get
            {
                return new ConnectionStringClass();
            }
        }

        public class AppSettingsClass : BaseSettingsClass
        {
            public string this[string setting]
            {
                get
                {
                    var s = ConfigurationManager.AppSettings[setting];
                    var x = getServerName();

                    var t = ConfigurationManager.AppSettings["[" + x + "]" + setting];
                    if (t != null)
                        s = t;

                    return s;
                }
            }
        }
        public class ConnectionStringClass : BaseSettingsClass
        {
            public ConnectionStringSettings this[string connectionString]
            {
                get
                {
                    var s = ConfigurationManager.ConnectionStrings[connectionString];
                    if (s!=null)
                        return s;

                    var x = getServerName();
                    var t = ConfigurationManager.ConnectionStrings["[" + x + "]" + connectionString];
                    if (t != null)
                        s = t;

                    return s;
                }
            }
        }
        public class BaseSettingsClass
        {
            protected string getServerName()
            {
                return System.Web.HttpContext.Current.Request.Url.Host.ToLower();
            }
        }
    }
}