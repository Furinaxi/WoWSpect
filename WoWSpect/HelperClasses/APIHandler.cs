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
}
