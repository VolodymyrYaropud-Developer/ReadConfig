
using System.Text.Json;

namespace ReadConfig
{
    public class DatabaseConfig
    {
        public string ConnectionString { get; set; }
        public string? Param1 { get; set; }
        public bool? Param2 { get; set; }

        public override string ToString()
        {
            return $"ConnectionString: {ConnectionString}\n" +
                $"Param1: {Param1}\n" +
                $"Param2: {Param2}\n";
        }
    }

    public class ConfigReader
    {
        public DatabaseConfig LoadConfig(string configFilePath)
        {
            DatabaseConfig config = null;

            if (string.IsNullOrEmpty(configFilePath))
            {

                Console.WriteLine("File path is uncorrect");
                return config;
            }

            if (!File.Exists(configFilePath))
            {
                Console.WriteLine("File doesn`t exist");
                return config;
            }

            string jsonContent = File.ReadAllText(configFilePath);
            if (string.IsNullOrEmpty(jsonContent))
            {
                Console.WriteLine("File data is empty");
                return config;
            }
            try
            {
                config = JsonSerializer.Deserialize<DatabaseConfig>(jsonContent);

                if (string.IsNullOrEmpty(config.ConnectionString))
                {
                    Console.WriteLine("Connection string is empty");
                    return null;
                }

                if (config.Param2 is null)
                {
                    Console.WriteLine("Param2 is required");
                    return null;
                }
                return config;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error occured while parsing data " + ex.Message);
                return config;
            }
        }
    }
}
