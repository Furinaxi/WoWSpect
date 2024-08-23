using Flurl;
using Flurl.Http;

namespace WoWSpect.HelperClasses;

public class APIHandler
{
    
    /// <summary>
    /// Posts a request to the specified URL with the specified username and password
    /// </summary>
    /// <param name="url">The url to send the request to</param>
    /// <param name="username">The username to use</param>
    /// <param name="password">The password to use</param>
    /// <param name="postBody">Request body which will be serialized to a URL encoded string</param>
    /// <typeparam name="T">Type that matches the received JSON</typeparam>
    /// <returns>Object of the specified type containing the data</returns>
    public static async Task<T?> Receive<T>(string url, string username, string password, object postBody)
    {
        try
        {
            var response = await url
                .WithBasicAuth(username, password)
                .PostUrlEncodedAsync(postBody)
                .ReceiveJson<T>();
            
            return response;
        }
        catch (FlurlHttpException e)
        {
            return default;
        }
    }
    
    /// <summary>
    /// Sends a GET request to the specified URL
    /// </summary>
    /// <param name="url">URL to send the GET request to</param>
    /// <typeparam name="T">Type that matches the expected JSON</typeparam>
    /// <returns>Object of the specified type containing the data</returns>
    public static async Task<T?> Get<T>(string url)
    {
        try
        {
            var response = await url
                .GetJsonAsync<T>();
            
            return response;
        }
        catch (FlurlHttpException e)
        {
            return default;
        }
    }

    /// <summary>
    /// Sends a GET request to the specified URL with the specified parameters
    /// </summary>
    /// <param name="url">URL to send the GET request to</param>
    /// <param name="parameters">The query parameters to use</param>
    /// <typeparam name="T">Type that matches the received JSON</typeparam>
    /// <returns>Object of the specified type containing the data</returns>
    public static async Task<T?> Get<T>(string url, object parameters)
    {
        try
        {
            var response = await url
                .SetQueryParams(parameters)
                .GetJsonAsync<T>();
            
            return response;
        }
        catch (FlurlHttpException e)
        {
            return default;
        }
    }
}
