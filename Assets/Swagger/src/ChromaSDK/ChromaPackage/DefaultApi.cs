using System;
using System.Collections.Generic;
using RestSharp;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace ChromaSDK.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApi
    {
        /// <summary>
        ///  Initialize the client.
        /// </summary>
        /// <param name="baseInput"></param>
        /// <returns>SessionResponse</returns>
        SessionResponse CallBase (BaseInput baseInput);
        /// <summary>
        ///  Creating effects on Keyboards by sending PUT to the URI. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <returns></returns>
        void Heartbeat ();
        /// <summary>
        ///  Creating effects on Keyboards by sending POST to the URI. POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="keyboardInput"></param>
        /// <returns>KeyboardResponseId</returns>
        KeyboardResponseId PostKeyboard (KeyboardInput keyboardInput);
        /// <summary>
        ///  Creating effects on Keyboards by sending PUT to the URI. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="keyboardInput"></param>
        /// <returns>KeyboardResponse</returns>
        KeyboardResponse PutKeyboard (KeyboardInput keyboardInput);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DefaultApi : IDefaultApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DefaultApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DefaultApi(String basePath)
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
        ///  Initialize the client.
        /// </summary>
        /// <param name="baseInput"></param> 
        /// <returns>SessionResponse</returns>            
        public SessionResponse CallBase (BaseInput baseInput)
        {
            
    
            var path = "/razer/chromasdk";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(baseInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CallBase: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CallBase: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SessionResponse) ApiClient.Deserialize(response.Content, typeof(SessionResponse), response.Headers);
        }
    
        /// <summary>
        ///  Creating effects on Keyboards by sending PUT to the URI. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <returns></returns>            
        public void Heartbeat ()
        {
            
    
            var path = "/chromasdk/heartbeat";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Heartbeat: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Heartbeat: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        ///  Creating effects on Keyboards by sending POST to the URI. POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="keyboardInput"></param> 
        /// <returns>KeyboardResponseId</returns>            
        public KeyboardResponseId PostKeyboard (KeyboardInput keyboardInput)
        {
            
    
            var path = "/chromasdk/keyboard";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(keyboardInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeyboard: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeyboard: " + response.ErrorMessage, response.ErrorMessage);
    
            return (KeyboardResponseId) ApiClient.Deserialize(response.Content, typeof(KeyboardResponseId), response.Headers);
        }
    
        /// <summary>
        ///  Creating effects on Keyboards by sending PUT to the URI. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="keyboardInput"></param> 
        /// <returns>KeyboardResponse</returns>            
        public KeyboardResponse PutKeyboard (KeyboardInput keyboardInput)
        {
            
    
            var path = "/chromasdk/keyboard";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(keyboardInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeyboard: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeyboard: " + response.ErrorMessage, response.ErrorMessage);
    
            return (KeyboardResponse) ApiClient.Deserialize(response.Content, typeof(KeyboardResponse), response.Headers);
        }
    
    }
}
