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
    public interface IChromaApi
    {
        /// <summary>
        ///  Delete the Chroma SDK session
        /// </summary>
        /// <returns>DeleteChromaSdkResponse</returns>
        DeleteChromaSdkResponse DeleteChromaSdk ();
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
        ///  1D array with 5 elements. POST will return an effect id.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostChromaLinkCustom (EffectArray1dInput data);
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
        ///  1D array with 5 elements. POST will return an effect id.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostHeadsetCustom (EffectArray1dInput data);
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
        ///  2D array with 6 rows of 22 columns. POST will return an effect id.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostKeyboardCustom (EffectArray2dInput data);
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
        ///  1D array with 4 rows of 5 columns. POST will return an effect id.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostKeypadCustom (EffectArray2dInput data);
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
        ///  2D array with 9 rows of 7 columns. POST will return an effect id.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostMouseCustom (EffectArray2dInput data);
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
        ///  1D array with 15 elements. POST will return an effect id.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponseId</returns>
        EffectResponseId PostMousepadCustom (EffectArray1dInput data);
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
        ///  1D array with 5 elements.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutChromaLinkCustom (EffectArray1dInput data);
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
        ///  1D array with 5 elements.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutHeadsetCustom (EffectArray1dInput data);
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
        ///  2D array with 6 rows of 22 columns.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutKeyboardCustom (EffectArray2dInput data);
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
        ///  2D array with 4 rows of 5 columns.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutKeypadCustom (EffectArray2dInput data);
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
        ///  2D array with 9 rows of 7 columns.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutMouseCustom (EffectArray2dInput data);
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
        ///  1D array with 15 elements.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>EffectResponse</returns>
        EffectResponse PutMousepadCustom (EffectArray1dInput data);
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
    public class ChromaApi : IChromaApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChromaApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public ChromaApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="ChromaApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ChromaApi(String basePath)
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
        ///  Delete the Chroma SDK session
        /// </summary>
        /// <returns>DeleteChromaSdkResponse</returns>            
        public DeleteChromaSdkResponse DeleteChromaSdk ()
        {
            
    
            var path = "/";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteChromaSdk: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteChromaSdk: " + response.ErrorMessage, response.ErrorMessage);
    
            return (DeleteChromaSdkResponse) ApiClient.Deserialize(response.Content, typeof(DeleteChromaSdkResponse), response.Headers);
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
        ///  1D array with 5 elements. POST will return an effect id.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostChromaLinkCustom (EffectArray1dInput data)
        {
            
    
            var path = "/chromalink/custom";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PostChromaLinkCustom: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostChromaLinkCustom: " + response.ErrorMessage, response.ErrorMessage);
    
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
            
            // verify the required parameter 'color' is set
            if (color == null) throw new ApiException(400, "Missing required parameter 'color' when calling PostChromaLinkStatic");
            
    
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
        ///  1D array with 5 elements. POST will return an effect id.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostHeadsetCustom (EffectArray1dInput data)
        {
            
    
            var path = "/headset/custom";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PostHeadsetCustom: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostHeadsetCustom: " + response.ErrorMessage, response.ErrorMessage);
    
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
            
            // verify the required parameter 'color' is set
            if (color == null) throw new ApiException(400, "Missing required parameter 'color' when calling PostHeadsetStatic");
            
    
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
        ///  2D array with 6 rows of 22 columns. POST will return an effect id.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostKeyboardCustom (EffectArray2dInput data)
        {
            
    
            var path = "/keyboard/custom";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeyboardCustom: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeyboardCustom: " + response.ErrorMessage, response.ErrorMessage);
    
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
            
            // verify the required parameter 'color' is set
            if (color == null) throw new ApiException(400, "Missing required parameter 'color' when calling PostKeyboardStatic");
            
    
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
        ///  1D array with 4 rows of 5 columns. POST will return an effect id.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostKeypadCustom (EffectArray2dInput data)
        {
            
    
            var path = "/keypad/custom";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeypadCustom: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostKeypadCustom: " + response.ErrorMessage, response.ErrorMessage);
    
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
            
            // verify the required parameter 'color' is set
            if (color == null) throw new ApiException(400, "Missing required parameter 'color' when calling PostKeypadStatic");
            
    
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
        ///  2D array with 9 rows of 7 columns. POST will return an effect id.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostMouseCustom (EffectArray2dInput data)
        {
            
    
            var path = "/mouse/custom2";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PostMouseCustom: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMouseCustom: " + response.ErrorMessage, response.ErrorMessage);
    
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
            
            // verify the required parameter 'color' is set
            if (color == null) throw new ApiException(400, "Missing required parameter 'color' when calling PostMouseStatic");
            
    
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
        ///  1D array with 15 elements. POST will return an effect id.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponseId</returns>            
        public EffectResponseId PostMousepadCustom (EffectArray1dInput data)
        {
            
    
            var path = "/mousepad/custom";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PostMousepadCustom: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PostMousepadCustom: " + response.ErrorMessage, response.ErrorMessage);
    
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
            
            // verify the required parameter 'color' is set
            if (color == null) throw new ApiException(400, "Missing required parameter 'color' when calling PostMousepadStatic");
            
    
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
        ///  1D array with 5 elements.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutChromaLinkCustom (EffectArray1dInput data)
        {
            
    
            var path = "/chromalink/custom";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PutChromaLinkCustom: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutChromaLinkCustom: " + response.ErrorMessage, response.ErrorMessage);
    
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
            
            // verify the required parameter 'color' is set
            if (color == null) throw new ApiException(400, "Missing required parameter 'color' when calling PutChromaLinkStatic");
            
    
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
        ///  1D array with 5 elements.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutHeadsetCustom (EffectArray1dInput data)
        {
            
    
            var path = "/headset/custom";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PutHeadsetCustom: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutHeadsetCustom: " + response.ErrorMessage, response.ErrorMessage);
    
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
            
            // verify the required parameter 'color' is set
            if (color == null) throw new ApiException(400, "Missing required parameter 'color' when calling PutHeadsetStatic");
            
    
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
        ///  2D array with 6 rows of 22 columns.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutKeyboardCustom (EffectArray2dInput data)
        {
            
    
            var path = "/keyboard/custom";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeyboardCustom: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeyboardCustom: " + response.ErrorMessage, response.ErrorMessage);
    
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
            
            // verify the required parameter 'color' is set
            if (color == null) throw new ApiException(400, "Missing required parameter 'color' when calling PutKeyboardStatic");
            
    
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
        ///  2D array with 4 rows of 5 columns.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutKeypadCustom (EffectArray2dInput data)
        {
            
    
            var path = "/keypad/custom";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeypadCustom: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutKeypadCustom: " + response.ErrorMessage, response.ErrorMessage);
    
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
            
            // verify the required parameter 'color' is set
            if (color == null) throw new ApiException(400, "Missing required parameter 'color' when calling PutKeypadStatic");
            
    
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
        ///  2D array with 9 rows of 7 columns.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutMouseCustom (EffectArray2dInput data)
        {
            
    
            var path = "/mouse/custom2";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PutMouseCustom: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutMouseCustom: " + response.ErrorMessage, response.ErrorMessage);
    
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
            
            // verify the required parameter 'color' is set
            if (color == null) throw new ApiException(400, "Missing required parameter 'color' when calling PutMouseStatic");
            
    
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
        ///  1D array with 15 elements.
        /// </summary>
        /// <param name="data"></param> 
        /// <returns>EffectResponse</returns>            
        public EffectResponse PutMousepadCustom (EffectArray1dInput data)
        {
            
    
            var path = "/mousepad/custom";
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
                throw new ApiException ((int)response.StatusCode, "Error calling PutMousepadCustom: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PutMousepadCustom: " + response.ErrorMessage, response.ErrorMessage);
    
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
            
            // verify the required parameter 'color' is set
            if (color == null) throw new ApiException(400, "Missing required parameter 'color' when calling PutMousepadStatic");
            
    
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
