using System;
using System.Collections.Generic;
using RestSharp;
using RazerSDK.Client;
using RazerSDK.ChromaPackage.Model;

namespace RazerSDK.Api
{
    using Type = System.Type;

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IRazerApi
    {
        /// <summary>
        ///  Initialize the Chroma SDK
        /// </summary>
        /// <param name="baseInput"></param>
        /// <returns>PostChromaSdkResponse</returns>
        PostChromaSdkResponse PostChromaSdk (ChromaSdkInput baseInput);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class RazerApi : IRazerApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RazerApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public RazerApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="RazerApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RazerApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        ///  Initialize the Chroma SDK
        /// </summary>
        /// <param name="baseInput"></param> 
        /// <returns>PostChromaSdkResponse</returns>            
        public PostChromaSdkResponse PostChromaSdk (ChromaSdkInput baseInput)
        {
            
    
            var path = "/chromasdk";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(baseInput); // http body (model) parameter
			//UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostChromaSdk: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostChromaSdk: " + response.ErrorMessage, response.ErrorMessage);
    
            return (PostChromaSdkResponse) ApiClient.Deserialize(response.Content, typeof(PostChromaSdkResponse), response.Headers);
        }
    
    }
}
