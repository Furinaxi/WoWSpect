using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WoWSpect.ConfigHandler;

public static class AppConfigHandler
{
    private const string ConfigFileName = "WoWSpect.settings.json";
    private const string FolderName = "WoWSpect";
    
    public static string ClientIdKey = "clientID";
    public static string ClientSecretKey = "clientSecret";

    public static void CheckConfigFile()
    {
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string wowSpectFolderPath = Path.Combine(appDataPath, FolderName);
        
        CreateFolderIfNotExists(wowSpectFolderPath);

        string configFilePath = Path.Combine(wowSpectFolderPath, ConfigFileName);

        SetupFileIfNotExists(configFilePath);
    }

    private static void CreateFolderIfNotExists(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }


    private static void SetupFileIfNotExists(string filePath)
    {
        if (!File.Exists(filePath))
        {
            StringBuilder sb = new();
            StringWriter sw = new(sb);
                
            using(JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                    
                writer.WriteStartObject();
                writer.WritePropertyName(ClientIdKey);
                writer.WriteValue("");
                writer.WritePropertyName(ClientSecretKey);
                writer.WriteValue("");
                writer.WriteEndObject();
            }

            using (FileStream fs = new(filePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter file = new(fs))
                {
                    file.Write(sb.ToString());
                }
            }
        }
    }
    
    public static bool TryGetValue(string key, out string value)
    {
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string kupoFinderFolderPath = Path.Combine(appDataPath, FolderName);
        string configFilePath = Path.Combine(kupoFinderFolderPath, ConfigFileName);
            
        string json = File.ReadAllText(configFilePath);
        JObject obj = JObject.Parse(json);
            
        if (obj.TryGetValue(key, out JToken? token) && token.Value<string>() != string.Empty)
        {
            value = token.Value<string>();
            return true;
        }
            
        value = string.Empty;
        return false;
    }
    
    public static bool TryGetValues(string[] keys, out IDictionary<string, string> valuePairs)
    {
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string wowSpectFolderPath = Path.Combine(appDataPath, FolderName);
        string configFilePath = Path.Combine(wowSpectFolderPath, ConfigFileName);
            
        string json = File.ReadAllText(configFilePath);
        JObject obj = JObject.Parse(json);
            
        Dictionary<string, string> pairs = new();
            
        foreach (string key in keys)
        {
            if (obj.TryGetValue(key, out JToken? token) && token.Value<string>() != string.Empty)
            {
                pairs[key] = token.Value<string>();
            }
            else
            {
                valuePairs = null;
                return false;
            }
        }
            
        valuePairs = pairs;
        return true;
    }

    public static void SetValue(string key, string value)
    {
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string wowSpectFolderPath = Path.Combine(appDataPath, FolderName);
        string configFilePath = Path.Combine(wowSpectFolderPath, ConfigFileName);

        JObject obj;
        
        using (FileStream fs = new(configFilePath, FileMode.Open, FileAccess.Read))
        {
            string json;

            using (StreamReader sr = new(fs))
            {
                json = sr.ReadToEnd();
                obj = JObject.Parse(json);
            }

            obj[key] = value;
        }

        using (FileStream fs = new(configFilePath, FileMode.Truncate, FileAccess.Write))
        {
            using (StreamWriter sw = new(fs))
            {
                sw.Write(obj.ToString());
            }
        }
    }
    
    public static void SetValues(IDictionary<string, string> valuePairs)
    {
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string wowSpectFolderPath = Path.Combine(appDataPath, FolderName);
        string configFilePath = Path.Combine(wowSpectFolderPath, ConfigFileName);

        JObject obj;
        
        using (FileStream fs = new(configFilePath, FileMode.Open, FileAccess.Read))
        {
            string json;

            using (StreamReader sr = new(fs))
            {
                json = sr.ReadToEnd();
                obj = JObject.Parse(json);
            }

            foreach((string key, string value) in valuePairs)
            {
                obj[key] = value;
            }
        }

        using (FileStream fs = new(configFilePath, FileMode.Truncate, FileAccess.Write))
        {
            using (StreamWriter sw = new(fs))
            {
                sw.Write(obj.ToString());
            }
        }
    }
}