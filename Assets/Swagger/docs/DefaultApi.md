# ChromaSDK.ChromaPackage.DefaultApi

All URIs are relative to *http://localhost:54235/chromasdk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteEffect**](DefaultApi.md#deleteeffect) | **DELETE** /effect | 
[**Heartbeat**](DefaultApi.md#heartbeat) | **PUT** /heartbeat | 
[**PostChromaLink**](DefaultApi.md#postchromalink) | **POST** /chromalink | 
[**PostHeadset**](DefaultApi.md#postheadset) | **POST** /headset | 
[**PostKeyboard**](DefaultApi.md#postkeyboard) | **POST** /keyboard | 
[**PostKeypad**](DefaultApi.md#postkeypad) | **POST** /keypad | 
[**PostMouse**](DefaultApi.md#postmouse) | **POST** /mouse | 
[**PostMousepad**](DefaultApi.md#postmousepad) | **POST** /mousepad | 
[**PutChromaLink**](DefaultApi.md#putchromalink) | **PUT** /chromalink | 
[**PutEffect**](DefaultApi.md#puteffect) | **PUT** /effect | 
[**PutHeadset**](DefaultApi.md#putheadset) | **PUT** /headset | 
[**PutKeyboard**](DefaultApi.md#putkeyboard) | **PUT** /keyboard | 
[**PutKeypad**](DefaultApi.md#putkeypad) | **PUT** /keypad | 
[**PutMouse**](DefaultApi.md#putmouse) | **PUT** /mouse | 
[**PutMousepad**](DefaultApi.md#putmousepad) | **PUT** /mousepad | 


<a name="deleteeffect"></a>
# **DeleteEffect**
> EffectIdentifierResponse DeleteEffect (EffectIdentifierArrayInput data = null)



Deleting an effect or a set of effects with identifier. Effects must be deleted to free resources.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class DeleteEffectExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var data = new EffectIdentifierArrayInput(); // EffectIdentifierArrayInput |  (optional) 

            try
            {
                EffectIdentifierResponse result = apiInstance.DeleteEffect(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeleteEffect: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectIdentifierArrayInput**](EffectIdentifierArrayInput.md)|  | [optional] 

### Return type

[**EffectIdentifierResponse**](EffectIdentifierResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

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

