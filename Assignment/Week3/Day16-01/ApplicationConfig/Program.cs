using System;
using System.Xml.Linq;

namespace ApplicationConfig
{
    class ApplicationConfig
    {

      public   static string ApplicationName {  get; set; }
       public static string Environment { get; set; }
     public   static int AccessCount {  get; set; }
      public  static bool IsInitialised { get; set; }

         static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialised = false;

            Console.WriteLine("Static Constructor Executed");
        }
        public static void Initialize(string name, string environment)
        {
            ApplicationName = name;
            Environment= environment;
            IsInitialised = true;
            AccessCount++;
        }
        public static string getCofigurationSummary()
        {
            AccessCount++;
            return $"ApplicationName : {ApplicationName}\n" +
                $"Environment :{Environment}\n" +
                $"AccessCount : {AccessCount}\n"+
                $"InitializationStatus :{IsInitialised}\n";
                 
                 }
        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount++;
            IsInitialised = false;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ApplicationConfig.ApplicationName);
            ApplicationConfig.Initialize("Kush", "Tech");
            Console.WriteLine(ApplicationConfig.getCofigurationSummary());
            ApplicationConfig.ResetConfiguration();
            Console.WriteLine(ApplicationConfig.getCofigurationSummary());


        }
    }
}
