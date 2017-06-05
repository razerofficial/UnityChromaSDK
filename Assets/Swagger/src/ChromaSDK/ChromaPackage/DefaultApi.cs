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
        ///  Turn off effect. POST will return an effect id.
        /// </summary>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostChromaLinkNone ();
        /// <summary>
        ///  To set static color. POST will return an effect id.
        /// </summary>
        /// <param name="color">Color value in BGR format</param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostChromaLinkStatic (int? color);
        /// <summary>
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostHeadset (EffectInput data);
        /// <summary>
        ///  Turn off effect. POST will return an effect id.
        /// </summary>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostHeadsetNone ();
        /// <summary>
        ///  To set static color. POST will return an effect id.
        /// </summary>
        /// <param name="color">Color value in BGR format</param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostHeadsetStatic (int? color);
        /// <summary>
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostKeyboard (EffectInput data);
        /// <summary>
        ///  Turn off effect. POST will return an effect id.
        /// </summary>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostKeyboardNone ();
        /// <summary>
        ///  To set static color. POST will return an effect id.
        /// </summary>
        /// <param name="color">Color value in BGR format</param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostKeyboardStatic (int? color);
        /// <summary>
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostKeypad (EffectInput data);
        /// <summary>
        ///  Turn off effect. POST will return an effect id.
        /// </summary>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostKeypadNone ();
        /// <summary>
        ///  To set static color. POST will return an effect id.
        /// </summary>
        /// <param name="color">Color value in BGR format</param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostKeypadStatic (int? color);
        /// <summary>
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostMouse (EffectInput data);
        /// <summary>
        ///  Turn off effect. POST will return an effect id.
        /// </summary>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostMouseNone ();
        /// <summary>
        ///  To set static color. POST will return an effect id.
        /// </summary>
        /// <param name="color">Color value in BGR format</param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostMouseStatic (int? color);
        /// <summary>
        ///  POST will return an effect id. To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostMousepad (EffectInput data);
        /// <summary>
        ///  Turn off effect. POST will return an effect id.
        /// </summary>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostMousepadNone ();
        /// <summary>
        ///  To set static color. POST will return an effect id.
        /// </summary>
        /// <param name="color">Color value in BGR format</param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostMousepadStatic (int? color);
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutChromaLink (EffectInput data);
        /// <summary>
        ///  Turn off effect
        /// </summary>
        /// <returns>EffectResponse</returns>
        EffectResponse PutChromaLinkNone ();
        /// <summary>
        ///  To set static color.
        /// </summary>
        /// <param name="color">Color value in BGR format</param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutChromaLinkStatic (int? color);
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
        ///  Turn off effect
        /// </summary>
        /// <returns>EffectResponse</returns>
        EffectResponse PutHeadsetNone ();
        /// <summary>
        ///  To set static color.
        /// </summary>
        /// <param name="color">Color value in BGR format</param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutHeadsetStatic (int? color);
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutKeyboard (EffectInput data);
        /// <summary>
        ///  Turn off effect
        /// </summary>
        /// <returns>EffectResponse</returns>
        EffectResponse PutKeyboardNone ();
        /// <summary>
        ///  To set static color.
        /// </summary>
        /// <param name="color">Color value in BGR format</param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutKeyboardStatic (int? color);
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutKeypad (EffectInput data);
        /// <summary>
        ///  Turn off effect
        /// </summary>
        /// <returns>EffectResponse</returns>
        EffectResponse PutKeypadNone ();
        /// <summary>
        ///  To set static color.
        /// </summary>
        /// <param name="color">Color value in BGR format</param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutKeypadStatic (int? color);
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutMouse (EffectInput data);
        /// <summary>
        ///  Turn off effect
        /// </summary>
        /// <returns>EffectResponse</returns>
        EffectResponse PutMouseNone ();
        /// <summary>
        ///  To set static color.
        /// </summary>
        /// <param name="color">Color value in BGR format</param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutMouseStatic (int? color);
        /// <summary>
        ///  To turn off effect use CHROMA_NONE.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutMousepad (EffectInput data);
        /// <summary>
        ///  Turn off effect
        /// </summary>
        /// <returns>EffectResponse</returns>
        EffectResponse PutMousepadNone ();
        /// <summary>
        ///  To set static color.
        /// </summary>
        /// <param name="color">Color value in BGR format</param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutMousepadStatic (int? color);
        /// <summary>
        ///  Remove an effect or a set of effects with identifier. Effects must be removed to free resources.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectIdentifierResponse</returns>
        EffectIdentifierResponse RemoveEffect (EffectIdentifierInput data);
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
        ///  Turn off effect. POST will return an effect id.
        /// </summary>
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostChromaLinkNone ()
        {
            
    
            var path = "/chromalink/none";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostChromaLinkNone: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostChromaLinkNone: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponseId) ApiClient.Deserialize(response.Content, typeof(EffectResponseId), response.Headers);
        }
    
        /// <summary>
        ///  To set static color. POST will return an effect id.
        /// </summary>
        /// <param name="color">Color value in BGR format</param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostChromaLinkStatic (int? color)
        {
            
    
            var path = "/chromalink/static";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(color); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostChromaLinkStatic: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostChromaLinkStatic: " + response.ErrorMessage, response.ErrorMessage);
    
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
        ///  Turn off effect. POST will return an effect id.
        /// </summary>
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostHeadsetNone ()
        {
            
    
            var path = "/headset/none";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostHeadsetNone: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostHeadsetNone: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponseId) ApiClient.Deserialize(response.Content, typeof(EffectResponseId), response.Headers);
        }
    
        /// <summary>
        ///  To set static color. POST will return an effect id.
        /// </summary>
        /// <param name="color">Color value in BGR format</param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostHeadsetStatic (int? color)
        {
            
    
            var path = "/headset/static";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(color); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostHeadsetStatic: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostHeadsetStatic: " + response.ErrorMessage, response.ErrorMessage);
    
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
        ///  Turn off effect. POST will return an effect id.
        /// </summary>
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostKeyboardNone ()
        {
            
    
            var path = "/keyboard/none";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeyboardNone: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeyboardNone: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponseId) ApiClient.Deserialize(response.Content, typeof(EffectResponseId), response.Headers);
        }
    
        /// <summary>
        ///  To set static color. POST will return an effect id.
        /// </summary>
        /// <param name="color">Color value in BGR format</param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostKeyboardStatic (int? color)
        {
            
    
            var path = "/keyboard/static";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(color); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeyboardStatic: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeyboardStatic: " + response.ErrorMessage, response.ErrorMessage);
    
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
        ///  Turn off effect. POST will return an effect id.
        /// </summary>
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostKeypadNone ()
        {
            
    
            var path = "/keypad/none";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeypadNone: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeypadNone: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponseId) ApiClient.Deserialize(response.Content, typeof(EffectResponseId), response.Headers);
        }
    
        /// <summary>
        ///  To set static color. POST will return an effect id.
        /// </summary>
        /// <param name="color">Color value in BGR format</param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostKeypadStatic (int? color)
        {
            
    
            var path = "/keypad/static";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(color); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeypadStatic: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeypadStatic: " + response.ErrorMessage, response.ErrorMessage);
    
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
        ///  Turn off effect. POST will return an effect id.
        /// </summary>
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostMouseNone ()
        {
            
    
            var path = "/mouse/none";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMouseNone: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMouseNone: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponseId) ApiClient.Deserialize(response.Content, typeof(EffectResponseId), response.Headers);
        }
    
        /// <summary>
        ///  To set static color. POST will return an effect id.
        /// </summary>
        /// <param name="color">Color value in BGR format</param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostMouseStatic (int? color)
        {
            
    
            var path = "/mouse/static";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(color); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMouseStatic: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMouseStatic: " + response.ErrorMessage, response.ErrorMessage);
    
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
        ///  Turn off effect. POST will return an effect id.
        /// </summary>
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostMousepadNone ()
        {
            
    
            var path = "/mousepad/none";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMousepadNone: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMousepadNone: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponseId) ApiClient.Deserialize(response.Content, typeof(EffectResponseId), response.Headers);
        }
    
        /// <summary>
        ///  To set static color. POST will return an effect id.
        /// </summary>
        /// <param name="color">Color value in BGR format</param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostMousepadStatic (int? color)
        {
            
    
            var path = "/mousepad/static";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(color); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMousepadStatic: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMousepadStatic: " + response.ErrorMessage, response.ErrorMessage);
    
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
        ///  Turn off effect
        /// </summary>
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutChromaLinkNone ()
        {
            
    
            var path = "/chromalink/none";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PutChromaLinkNone: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutChromaLinkNone: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponse) ApiClient.Deserialize(response.Content, typeof(EffectResponse), response.Headers);
        }
    
        /// <summary>
        ///  To set static color.
        /// </summary>
        /// <param name="color">Color value in BGR format</param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutChromaLinkStatic (int? color)
        {
            
    
            var path = "/chromalink/static";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(color); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutChromaLinkStatic: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutChromaLinkStatic: " + response.ErrorMessage, response.ErrorMessage);
    
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
        ///  Turn off effect
        /// </summary>
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutHeadsetNone ()
        {
            
    
            var path = "/headset/none";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PutHeadsetNone: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutHeadsetNone: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponse) ApiClient.Deserialize(response.Content, typeof(EffectResponse), response.Headers);
        }
    
        /// <summary>
        ///  To set static color.
        /// </summary>
        /// <param name="color">Color value in BGR format</param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutHeadsetStatic (int? color)
        {
            
    
            var path = "/headset/static";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(color); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutHeadsetStatic: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutHeadsetStatic: " + response.ErrorMessage, response.ErrorMessage);
    
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
        ///  Turn off effect
        /// </summary>
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutKeyboardNone ()
        {
            
    
            var path = "/keyboard/none";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeyboardNone: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeyboardNone: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponse) ApiClient.Deserialize(response.Content, typeof(EffectResponse), response.Headers);
        }
    
        /// <summary>
        ///  To set static color.
        /// </summary>
        /// <param name="color">Color value in BGR format</param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutKeyboardStatic (int? color)
        {
            
    
            var path = "/keyboard/static";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(color); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeyboardStatic: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeyboardStatic: " + response.ErrorMessage, response.ErrorMessage);
    
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
        ///  Turn off effect
        /// </summary>
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutKeypadNone ()
        {
            
    
            var path = "/keypad/none";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeypadNone: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeypadNone: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponse) ApiClient.Deserialize(response.Content, typeof(EffectResponse), response.Headers);
        }
    
        /// <summary>
        ///  To set static color.
        /// </summary>
        /// <param name="color">Color value in BGR format</param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutKeypadStatic (int? color)
        {
            
    
            var path = "/keypad/static";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(color); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeypadStatic: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeypadStatic: " + response.ErrorMessage, response.ErrorMessage);
    
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
        ///  Turn off effect
        /// </summary>
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutMouseNone ()
        {
            
    
            var path = "/mouse/none";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PutMouseNone: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutMouseNone: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponse) ApiClient.Deserialize(response.Content, typeof(EffectResponse), response.Headers);
        }
    
        /// <summary>
        ///  To set static color.
        /// </summary>
        /// <param name="color">Color value in BGR format</param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutMouseStatic (int? color)
        {
            
    
            var path = "/mouse/static";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(color); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutMouseStatic: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutMouseStatic: " + response.ErrorMessage, response.ErrorMessage);
    
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
    
        /// <summary>
        ///  Turn off effect
        /// </summary>
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutMousepadNone ()
        {
            
    
            var path = "/mousepad/none";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PutMousepadNone: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutMousepadNone: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponse) ApiClient.Deserialize(response.Content, typeof(EffectResponse), response.Headers);
        }
    
        /// <summary>
        ///  To set static color.
        /// </summary>
        /// <param name="color">Color value in BGR format</param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutMousepadStatic (int? color)
        {
            
    
            var path = "/mousepad/static";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(color); // http body (model) parameter
			UnityEngine.Debug.Log(postBody);
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PutMousepadStatic: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutMousepadStatic: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectResponse) ApiClient.Deserialize(response.Content, typeof(EffectResponse), response.Headers);
        }
    
        /// <summary>
        ///  Remove an effect or a set of effects with identifier. Effects must be removed to free resources.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectIdentifierResponse</returns>            
        public EffectIdentifierResponse RemoveEffect (EffectIdentifierInput data)
        {
            
    
            var path = "/effect/remove";
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
                throw new ApiException ((int)response.StatusCode, "Error calling RemoveEffect: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RemoveEffect: " + response.ErrorMessage, response.ErrorMessage);
    
            return (EffectIdentifierResponse) ApiClient.Deserialize(response.Content, typeof(EffectIdentifierResponse), response.Headers);
        }
    
    }
}
