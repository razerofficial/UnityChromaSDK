# ChromaSDK.ChromaPackage.DefaultApi

All URIs are relative to *http://localhost:54235/chromasdk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Heartbeat**](DefaultApi.md#heartbeat) | **PUT** /heartbeat | 
[**PostChromaLink**](DefaultApi.md#postchromalink) | **POST** /chromalink | 
[**PostChromaLinkNone**](DefaultApi.md#postchromalinknone) | **POST** /chromalink/none | 
[**PostHeadset**](DefaultApi.md#postheadset) | **POST** /headset | 
[**PostHeadsetNone**](DefaultApi.md#postheadsetnone) | **POST** /headset/none | 
[**PostKeyboard**](DefaultApi.md#postkeyboard) | **POST** /keyboard | 
[**PostKeyboardNone**](DefaultApi.md#postkeyboardnone) | **POST** /keyboard/none | 
[**PostKeypad**](DefaultApi.md#postkeypad) | **POST** /keypad | 
[**PostKeypadNone**](DefaultApi.md#postkeypadnone) | **POST** /keypad/none | 
[**PostMouse**](DefaultApi.md#postmouse) | **POST** /mouse | 
[**PostMouseNone**](DefaultApi.md#postmousenone) | **POST** /mouse/none | 
[**PostMousepad**](DefaultApi.md#postmousepad) | **POST** /mousepad | 
[**PostMousepadNone**](DefaultApi.md#postmousepadnone) | **POST** /mousepad/none | 
[**PutChromaLink**](DefaultApi.md#putchromalink) | **PUT** /chromalink | 
[**PutChromaLinkNone**](DefaultApi.md#putchromalinknone) | **PUT** /chromalink/none | 
[**PutEffect**](DefaultApi.md#puteffect) | **PUT** /effect | 
[**PutHeadset**](DefaultApi.md#putheadset) | **PUT** /headset | 
[**PutHeadsetNone**](DefaultApi.md#putheadsetnone) | **PUT** /headset/none | 
[**PutKeyboard**](DefaultApi.md#putkeyboard) | **PUT** /keyboard | 
[**PutKeyboardNone**](DefaultApi.md#putkeyboardnone) | **PUT** /keyboard/none | 
[**PutKeypad**](DefaultApi.md#putkeypad) | **PUT** /keypad | 
[**PutKeypadNone**](DefaultApi.md#putkeypadnone) | **PUT** /keypad/none | 
[**PutMouse**](DefaultApi.md#putmouse) | **PUT** /mouse | 
[**PutMouseNone**](DefaultApi.md#putmousenone) | **PUT** /mouse/none | 
[**PutMousepad**](DefaultApi.md#putmousepad) | **PUT** /mousepad | 
[**PutMousepadNone**](DefaultApi.md#putmousepadnone) | **PUT** /mousepad/none | 
[**RemoveEffect**](DefaultApi.md#removeeffect) | **PUT** /effect/remove | 


<a name="heartbeat"></a>
# **Heartbeat**
> void Heartbeat ()



To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class HeartbeatExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                apiInstance.Heartbeat();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.Heartbeat: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postchromalink"></a>
# **PostChromaLink**
> EffectResponseId PostChromaLink (EffectInput data = null)



POST will return an effect id. To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostChromaLinkExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostChromaLink(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostChromaLink: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectInput**](EffectInput.md)|  | [optional] 

### Return type

[**EffectResponseId**](EffectResponseId.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postchromalinknone"></a>
# **PostChromaLinkNone**
> EffectResponseId PostChromaLinkNone ()



Turn off effect. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostChromaLinkNoneExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                EffectResponseId result = apiInstance.PostChromaLinkNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostChromaLinkNone: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**EffectResponseId**](EffectResponseId.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postheadset"></a>
# **PostHeadset**
> EffectResponseId PostHeadset (EffectInput data = null)



POST will return an effect id. To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostHeadsetExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostHeadset(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostHeadset: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectInput**](EffectInput.md)|  | [optional] 

### Return type

[**EffectResponseId**](EffectResponseId.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postheadsetnone"></a>
# **PostHeadsetNone**
> EffectResponseId PostHeadsetNone ()



Turn off effect. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostHeadsetNoneExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                EffectResponseId result = apiInstance.PostHeadsetNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostHeadsetNone: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**EffectResponseId**](EffectResponseId.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postkeyboard"></a>
# **PostKeyboard**
> EffectResponseId PostKeyboard (EffectInput data = null)



POST will return an effect id. To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostKeyboardExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostKeyboard(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostKeyboard: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectInput**](EffectInput.md)|  | [optional] 

### Return type

[**EffectResponseId**](EffectResponseId.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postkeyboardnone"></a>
# **PostKeyboardNone**
> EffectResponseId PostKeyboardNone ()



Turn off effect. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostKeyboardNoneExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                EffectResponseId result = apiInstance.PostKeyboardNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostKeyboardNone: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**EffectResponseId**](EffectResponseId.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postkeypad"></a>
# **PostKeypad**
> EffectResponseId PostKeypad (EffectInput data = null)



POST will return an effect id. To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostKeypadExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostKeypad(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostKeypad: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectInput**](EffectInput.md)|  | [optional] 

### Return type

[**EffectResponseId**](EffectResponseId.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postkeypadnone"></a>
# **PostKeypadNone**
> EffectResponseId PostKeypadNone ()



Turn off effect. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostKeypadNoneExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                EffectResponseId result = apiInstance.PostKeypadNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostKeypadNone: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**EffectResponseId**](EffectResponseId.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postmouse"></a>
# **PostMouse**
> EffectResponseId PostMouse (EffectInput data = null)



POST will return an effect id. To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostMouseExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostMouse(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostMouse: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectInput**](EffectInput.md)|  | [optional] 

### Return type

[**EffectResponseId**](EffectResponseId.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postmousenone"></a>
# **PostMouseNone**
> EffectResponseId PostMouseNone ()



Turn off effect. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostMouseNoneExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                EffectResponseId result = apiInstance.PostMouseNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostMouseNone: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**EffectResponseId**](EffectResponseId.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postmousepad"></a>
# **PostMousepad**
> EffectResponseId PostMousepad (EffectInput data = null)



POST will return an effect id. To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostMousepadExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostMousepad(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostMousepad: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectInput**](EffectInput.md)|  | [optional] 

### Return type

[**EffectResponseId**](EffectResponseId.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postmousepadnone"></a>
# **PostMousepadNone**
> EffectResponseId PostMousepadNone ()



Turn off effect. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostMousepadNoneExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                EffectResponseId result = apiInstance.PostMousepadNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostMousepadNone: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**EffectResponseId**](EffectResponseId.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putchromalink"></a>
# **PutChromaLink**
> EffectResponse PutChromaLink (EffectInput data = null)



To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutChromaLinkExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutChromaLink(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutChromaLink: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectInput**](EffectInput.md)|  | [optional] 

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putchromalinknone"></a>
# **PutChromaLinkNone**
> EffectResponse PutChromaLinkNone ()



Turn off effect

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutChromaLinkNoneExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                EffectResponse result = apiInstance.PutChromaLinkNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutChromaLinkNone: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="puteffect"></a>
# **PutEffect**
> EffectIdentifierResponse PutEffect (EffectIdentifierInput data = null)



Setting effect with an identifier or set of identifiers.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutEffectExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectIdentifierInput(); // EffectIdentifierInput |  (optional) 

            try
            {
                EffectIdentifierResponse result = apiInstance.PutEffect(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutEffect: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectIdentifierInput**](EffectIdentifierInput.md)|  | [optional] 

### Return type

[**EffectIdentifierResponse**](EffectIdentifierResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putheadset"></a>
# **PutHeadset**
> EffectResponse PutHeadset (EffectInput data = null)



To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutHeadsetExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutHeadset(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutHeadset: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectInput**](EffectInput.md)|  | [optional] 

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putheadsetnone"></a>
# **PutHeadsetNone**
> EffectResponse PutHeadsetNone ()



Turn off effect

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutHeadsetNoneExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                EffectResponse result = apiInstance.PutHeadsetNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutHeadsetNone: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putkeyboard"></a>
# **PutKeyboard**
> EffectResponse PutKeyboard (EffectInput data = null)



To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutKeyboardExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutKeyboard(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutKeyboard: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectInput**](EffectInput.md)|  | [optional] 

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putkeyboardnone"></a>
# **PutKeyboardNone**
> EffectResponse PutKeyboardNone ()



Turn off effect

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutKeyboardNoneExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                EffectResponse result = apiInstance.PutKeyboardNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutKeyboardNone: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putkeypad"></a>
# **PutKeypad**
> EffectResponse PutKeypad (EffectInput data = null)



To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutKeypadExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutKeypad(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutKeypad: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectInput**](EffectInput.md)|  | [optional] 

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putkeypadnone"></a>
# **PutKeypadNone**
> EffectResponse PutKeypadNone ()



Turn off effect

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutKeypadNoneExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                EffectResponse result = apiInstance.PutKeypadNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutKeypadNone: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putmouse"></a>
# **PutMouse**
> EffectResponse PutMouse (EffectInput data = null)



To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutMouseExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutMouse(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutMouse: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectInput**](EffectInput.md)|  | [optional] 

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putmousenone"></a>
# **PutMouseNone**
> EffectResponse PutMouseNone ()



Turn off effect

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutMouseNoneExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                EffectResponse result = apiInstance.PutMouseNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutMouseNone: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putmousepad"></a>
# **PutMousepad**
> EffectResponse PutMousepad (EffectInput data = null)



To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutMousepadExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutMousepad(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutMousepad: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectInput**](EffectInput.md)|  | [optional] 

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putmousepadnone"></a>
# **PutMousepadNone**
> EffectResponse PutMousepadNone ()



Turn off effect

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutMousepadNoneExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                EffectResponse result = apiInstance.PutMousepadNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutMousepadNone: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="removeeffect"></a>
# **RemoveEffect**
> EffectIdentifierResponse RemoveEffect (EffectIdentifierInput data = null)



Remove an effect or a set of effects with identifier. Effects must be removed to free resources.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class RemoveEffectExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectIdentifierInput(); // EffectIdentifierInput |  (optional) 

            try
            {
                EffectIdentifierResponse result = apiInstance.RemoveEffect(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.RemoveEffect: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectIdentifierInput**](EffectIdentifierInput.md)|  | [optional] 

### Return type

[**EffectIdentifierResponse**](EffectIdentifierResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

