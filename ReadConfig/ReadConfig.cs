
using System.Text.Json;

namespace ReadConfig
{
    public class DatabaseConfig
    {
        public string ConnectionString { get; set; }
        public string? Param1 { get; set; }
        public bool Param2 { get; set; }
    }

    public class ConfigReader
    {
        private readonly string _configFilePath;
        public DatabaseConfig Config { get; private set; }

        public ConfigReader(string configFilePath)
        {
            _configFilePath = configFilePath;
        }

        public void LoadConfig()
        {
            try
            {
                string jsonContent = File.ReadAllText(_configFilePath);
                Config = JsonSerializer.Deserialize<DatabaseConfig>(jsonContent);

                if (Config == null)
                {
                    throw new ArgumentNullException(nameof(Config), "Configuration is null or malformed.");
                }

                if (string.IsNullOrEmpty(Config.ConnectionString))
                {
                    throw new Exception("ConnectionString is required in the config.");
                }

                if (!Config.Param2)
                {
                    throw new Exception("Param2 is a required boolean parameter.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}");
                throw;
            }
        }
    }
}
