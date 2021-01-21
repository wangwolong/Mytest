using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class ConfigurationManager
    {
        public static ConfigurationManager_Temp AppSettings
        {
            get
            {
                return new ConfigurationManager_Temp();
            }
        }

        public class ConfigurationManager_Temp
        {
            public IConfiguration get()
            {

                var appVersion = Environment.GetEnvironmentVariable("FirstDemo-environment-version") ?? "";
                var configuration = new ConfigurationBuilder();
                switch (appVersion)
                {
                    case "dev":
                    case "uat":
                    case "prd":
                    default:
                        configuration.AddJsonFile($"Config.{appVersion}.json");
                        break;
                    case "":
                        configuration.AddJsonFile("Config.json");
                        break;
                }


                IConfiguration config = configuration.Build();
                return config;
            }
            public string this[string name]
            {
                get
                {
                    try
                    {
                        //danny 增加了 SetBasePath(Directory.GetCurrentDirectory())，解决获找不到配置文件的问题                        
                        var appVersion = Environment.GetEnvironmentVariable("FirstDemo-environment-version") ?? "";
                        var configuration = new ConfigurationBuilder();
                        switch (appVersion)
                        {
                            case "dev":
                            case "uat":
                            case "prd":
                            default:
                                configuration.AddJsonFile($"Config.{appVersion}.json");
                                break;
                            case "":
                                configuration.AddJsonFile("Config.json");
                                break;
                        }

                        IConfiguration config = configuration.Build();
                        return config[name];
                    }
                    catch (Exception ex) { Console.WriteLine("目标: " + name); Console.WriteLine(ex); return null; }
                }
            }
        }
    }
}
