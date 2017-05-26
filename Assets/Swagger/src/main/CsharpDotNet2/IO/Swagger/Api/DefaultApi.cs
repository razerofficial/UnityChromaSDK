using System;
using System.Collections.Generic;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApi
    {
        /// <summary>
        ///  Creating effects on Keyboards by sending POST to the URI. POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="postKeyboardInput"></param>
        /// <returns>InlineResponseDefault1</returns>
        InlineResponseDefault1 PostKeyboardInput (PostKeyboardInput postKeyboardInput);
        /// <summary>
        ///  Creating effects on Keyboards by sending PUT to the URI. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="putKeyboardInput"></param>
        /// <returns>InlineResponseDefault</returns>
        InlineResponseDefault PutKeyboardInput (PutKeyboardInput putKeyboardInput);
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
        ///  Creating effects on Keyboards by sending POST to the URI. POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="postKeyboardInput"></param> 
        /// <returns>InlineResponseDefault1</returns>            
        public InlineResponseDefault1 PostKeyboardInput (PostKeyboardInput postKeyboardInput)
        {
            
    
            var path = "/keyboard";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(postKeyboardInput); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeyboardInput: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeyboardInput: " + response.ErrorMessage, response.ErrorMessage);
    
            return (InlineResponseDefault1) ApiClient.Deserialize(response.Content, typeof(InlineResponseDefault1), response.Headers);
        }
    
        /// <summary>
        ///  Creating effects on Keyboards by sending PUT to the URI. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="putKeyboardInput"></param> 
        /// <returns>InlineResponseDefault</returns>            
        public InlineResponseDefault PutKeyboardInput (PutKeyboardInput putKeyboardInput)
        {
            
    
            var path = "/keyboard";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(putKeyboardInput); // http body (model) parameter

            postBody = postBody.Replace(".0}", "}");
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeyboardInput: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeyboardInput: " + response.ErrorMessage, response.ErrorMessage);
    
            return (InlineResponseDefault) ApiClient.Deserialize(response.Content, typeof(InlineResponseDefault), response.Headers);
        }
    
    }
}
