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
        ///  Deleting an effect or a set of effects with identifier. Effects must be deleted to free resources.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectIdentifierResponse</returns>
        EffectIdentifierResponse DeleteEffect (EffectIdentifierArrayInput data);
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <returns></returns>
        void Heartbeat ();
        /// <summary>
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostChromaLink (EffectInput data);
        /// <summary>
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostHeadset (EffectInput data);
        /// <summary>
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostKeyboard (EffectInput data);
        /// <summary>
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostKeypad (EffectInput data);
        /// <summary>
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostMouse (EffectInput data);
        /// <summary>
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostMousepad (EffectInput data);
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutChromaLink (EffectInput data);
        /// <summary>
        ///  Setting effect with an identifier or set of identifiers.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectIdentifierResponse</returns>
        EffectIdentifierResponse PutEffect (EffectIdentifierInput data);
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutHeadset (EffectInput data);
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutKeyboard (EffectInput data);
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutKeypad (EffectInput data);
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutMouse (EffectInput data);
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutMousepad (EffectInput data);
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
        ///  Deleting an effect or a set of effects with identifier. Effects must be deleted to free resources.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectIdentifierResponse</returns>            
        public EffectIdentifierResponse DeleteEffect (EffectIdentifierArrayInput data)
        {
            
    
            var path = "/effect";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteEffect: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteEffect: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectIdentifierResponse) ApiClient.Deserialize(response.Content, typeof(EffectIdentifierResponse), response.Headers);
        }
    
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <returns></returns>            
        public void Heartbeat ()
        {
            
    
            var path = "/heartbeat";
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
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostChromaLink (EffectInput data)
        {
            
    
            var path = "/chromalink";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
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
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostHeadset (EffectInput data)
        {
            
    
            var path = "/headset";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
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
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostKeyboard (EffectInput data)
        {
            
    
            var path = "/keyboard";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
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
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostKeypad (EffectInput data)
        {
            
    
            var path = "/keypad";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
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
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostMouse (EffectInput data)
        {
            
    
            var path = "/mouse";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
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
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostMousepad (EffectInput data)
        {
            
    
            var path = "/mousepad";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
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
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutChromaLink (EffectInput data)
        {
            
    
            var path = "/chromalink";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
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
        ///  Setting effect with an identifier or set of identifiers.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectIdentifierResponse</returns>            
        public EffectIdentifierResponse PutEffect (EffectIdentifierInput data)
        {
            
    
            var path = "/effect";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutEffect: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutEffect: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectIdentifierResponse) ApiClient.Deserialize(response.Content, typeof(EffectIdentifierResponse), response.Headers);
        }
    
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutHeadset (EffectInput data)
        {
            
    
            var path = "/headset";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
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
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutKeyboard (EffectInput data)
        {
            
    
            var path = "/keyboard";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
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
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutKeypad (EffectInput data)
        {
            
    
            var path = "/keypad";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
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
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutMouse (EffectInput data)
        {
            
    
            var path = "/mouse";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
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
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutMousepad (EffectInput data)
        {
            
    
            var path = "/mousepad";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(data); // http body (model) parameter
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
