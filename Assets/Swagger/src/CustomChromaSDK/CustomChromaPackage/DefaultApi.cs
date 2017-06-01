using System;
using System.Collections.Generic;
using RestSharp;
using CustomChromaSDK.Client;
using CustomChromaSDK.CustomChromaPackage.Model;

namespace CustomChromaSDK.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApi
    {
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 5 elements.</param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostChromaLink (EffectInput1D effectInput);
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 5 elements.</param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostHeadset (EffectInput1D effectInput);
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 6 rows by 22 columns.</param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostKeyboard (EffectInput effectInput);
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 4 rows by 5 columns.</param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostKeypad (EffectInput effectInput);
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 9 rows by 7 columns.</param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostMouse (EffectInput effectInput);
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 15 elements.</param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostMousepad (EffectInput1D effectInput);
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 5 elements.</param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutChromaLink (EffectInput1D effectInput);
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 5 elements.</param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutHeadset (EffectInput1D effectInput);
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 6 rows by 22 columns.</param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutKeyboard (EffectInput effectInput);
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 4 rows by 5 columns.</param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutKeypad (EffectInput effectInput);
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 9 rows by 7 columns.</param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutMouse (EffectInput effectInput);
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 15 elements.</param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutMousepad (EffectInput1D effectInput);
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
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 5 elements.</param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostChromaLink (EffectInput1D effectInput)
        {
            
    
            var path = "/chromalink";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(effectInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostChromaLink: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostChromaLink: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponseId) ApiClient.Deserialize(response.Content, typeof(EffectResponseId), response.Headers);
        }
    
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 5 elements.</param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostHeadset (EffectInput1D effectInput)
        {
            
    
            var path = "/headset";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(effectInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostHeadset: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostHeadset: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponseId) ApiClient.Deserialize(response.Content, typeof(EffectResponseId), response.Headers);
        }
    
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 6 rows by 22 columns.</param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostKeyboard (EffectInput effectInput)
        {
            
    
            var path = "/keyboard";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(effectInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeyboard: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeyboard: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponseId) ApiClient.Deserialize(response.Content, typeof(EffectResponseId), response.Headers);
        }
    
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 4 rows by 5 columns.</param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostKeypad (EffectInput effectInput)
        {
            
    
            var path = "/keypad";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(effectInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeypad: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeypad: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponseId) ApiClient.Deserialize(response.Content, typeof(EffectResponseId), response.Headers);
        }
    
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 9 rows by 7 columns.</param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostMouse (EffectInput effectInput)
        {
            
    
            var path = "/mouse";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(effectInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMouse: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMouse: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponseId) ApiClient.Deserialize(response.Content, typeof(EffectResponseId), response.Headers);
        }
    
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 15 elements.</param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostMousepad (EffectInput1D effectInput)
        {
            
    
            var path = "/mousepad";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(effectInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMousepad: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMousepad: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponseId) ApiClient.Deserialize(response.Content, typeof(EffectResponseId), response.Headers);
        }
    
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 5 elements.</param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutChromaLink (EffectInput1D effectInput)
        {
            
    
            var path = "/chromalink";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(effectInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutChromaLink: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutChromaLink: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponse) ApiClient.Deserialize(response.Content, typeof(EffectResponse), response.Headers);
        }
    
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 5 elements.</param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutHeadset (EffectInput1D effectInput)
        {
            
    
            var path = "/headset";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(effectInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutHeadset: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutHeadset: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponse) ApiClient.Deserialize(response.Content, typeof(EffectResponse), response.Headers);
        }
    
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 6 rows by 22 columns.</param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutKeyboard (EffectInput effectInput)
        {
            
    
            var path = "/keyboard";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(effectInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeyboard: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeyboard: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponse) ApiClient.Deserialize(response.Content, typeof(EffectResponse), response.Headers);
        }
    
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 4 rows by 5 columns.</param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutKeypad (EffectInput effectInput)
        {
            
    
            var path = "/keypad";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(effectInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeypad: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeypad: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponse) ApiClient.Deserialize(response.Content, typeof(EffectResponse), response.Headers);
        }
    
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 9 rows by 7 columns.</param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutMouse (EffectInput effectInput)
        {
            
    
            var path = "/mouse";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(effectInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutMouse: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutMouse: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponse) ApiClient.Deserialize(response.Content, typeof(EffectResponse), response.Headers);
        }
    
        /// <summary>
        ///  To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.
        /// </summary>
        /// <param name="effectInput">Array dimensions are 15 elements.</param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutMousepad (EffectInput1D effectInput)
        {
            
    
            var path = "/mousepad";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(effectInput); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutMousepad: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutMousepad: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponse) ApiClient.Deserialize(response.Content, typeof(EffectResponse), response.Headers);
        }
    
    }
}
