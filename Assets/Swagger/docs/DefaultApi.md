# ChromaSDK.ChromaPackage.DefaultApi

All URIs are relative to *http://localhost:54235/chromasdk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Heartbeat**](DefaultApi.md#heartbeat) | **PUT** /heartbeat | 
[**PostChromaLink**](DefaultApi.md#postchromalink) | **POST** /chromalink | 
[**PostChromaLinkNone**](DefaultApi.md#postchromalinknone) | **POST** /chromalink/none | 
[**PostChromaLinkStatic**](DefaultApi.md#postchromalinkstatic) | **POST** /chromalink/static | 
[**PostHeadset**](DefaultApi.md#postheadset) | **POST** /headset | 
[**PostHeadsetNone**](DefaultApi.md#postheadsetnone) | **POST** /headset/none | 
[**PostHeadsetStatic**](DefaultApi.md#postheadsetstatic) | **POST** /headset/static | 
[**PostKeyboard**](DefaultApi.md#postkeyboard) | **POST** /keyboard | 
[**PostKeyboardNone**](DefaultApi.md#postkeyboardnone) | **POST** /keyboard/none | 
[**PostKeyboardStatic**](DefaultApi.md#postkeyboardstatic) | **POST** /keyboard/static | 
[**PostKeypad**](DefaultApi.md#postkeypad) | **POST** /keypad | 
[**PostKeypadNone**](DefaultApi.md#postkeypadnone) | **POST** /keypad/none | 
[**PostKeypadStatic**](DefaultApi.md#postkeypadstatic) | **POST** /keypad/static | 
[**PostMouse**](DefaultApi.md#postmouse) | **POST** /mouse | 
[**PostMouseNone**](DefaultApi.md#postmousenone) | **POST** /mouse/none | 
[**PostMouseStatic**](DefaultApi.md#postmousestatic) | **POST** /mouse/static | 
[**PostMousepad**](DefaultApi.md#postmousepad) | **POST** /mousepad | 
[**PostMousepadNone**](DefaultApi.md#postmousepadnone) | **POST** /mousepad/none | 
[**PostMousepadStatic**](DefaultApi.md#postmousepadstatic) | **POST** /mousepad/static | 
[**PutChromaLink**](DefaultApi.md#putchromalink) | **PUT** /chromalink | 
[**PutChromaLinkNone**](DefaultApi.md#putchromalinknone) | **PUT** /chromalink/none | 
[**PutChromaLinkStatic**](DefaultApi.md#putchromalinkstatic) | **PUT** /chromalink/static | 
[**PutEffect**](DefaultApi.md#puteffect) | **PUT** /effect | 
[**PutHeadset**](DefaultApi.md#putheadset) | **PUT** /headset | 
[**PutHeadsetNone**](DefaultApi.md#putheadsetnone) | **PUT** /headset/none | 
[**PutHeadsetStatic**](DefaultApi.md#putheadsetstatic) | **PUT** /headset/static | 
[**PutKeyboard**](DefaultApi.md#putkeyboard) | **PUT** /keyboard | 
[**PutKeyboardNone**](DefaultApi.md#putkeyboardnone) | **PUT** /keyboard/none | 
[**PutKeyboardStatic**](DefaultApi.md#putkeyboardstatic) | **PUT** /keyboard/static | 
[**PutKeypad**](DefaultApi.md#putkeypad) | **PUT** /keypad | 
[**PutKeypadNone**](DefaultApi.md#putkeypadnone) | **PUT** /keypad/none | 
[**PutKeypadStatic**](DefaultApi.md#putkeypadstatic) | **PUT** /keypad/static | 
[**PutMouse**](DefaultApi.md#putmouse) | **PUT** /mouse | 
[**PutMouseNone**](DefaultApi.md#putmousenone) | **PUT** /mouse/none | 
[**PutMouseStatic**](DefaultApi.md#putmousestatic) | **PUT** /mouse/static | 
[**PutMousepad**](DefaultApi.md#putmousepad) | **PUT** /mousepad | 
[**PutMousepadNone**](DefaultApi.md#putmousepadnone) | **PUT** /mousepad/none | 
[**PutMousepadStatic**](DefaultApi.md#putmousepadstatic) | **PUT** /mousepad/static | 
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

<a name="postchromalinkstatic"></a>
# **PostChromaLinkStatic**
> EffectResponseId PostChromaLinkStatic (int? color = null)



To set static color. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostChromaLinkStaticExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var color = 56;  // int? | Color value in BGR format (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostChromaLinkStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostChromaLinkStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | [optional] 

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

<a name="postheadsetstatic"></a>
# **PostHeadsetStatic**
> EffectResponseId PostHeadsetStatic (int? color = null)



To set static color. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostHeadsetStaticExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var color = 56;  // int? | Color value in BGR format (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostHeadsetStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostHeadsetStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | [optional] 

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

<a name="postkeyboardstatic"></a>
# **PostKeyboardStatic**
> EffectResponseId PostKeyboardStatic (int? color = null)



To set static color. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostKeyboardStaticExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var color = 56;  // int? | Color value in BGR format (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostKeyboardStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostKeyboardStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | [optional] 

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

<a name="postkeypadstatic"></a>
# **PostKeypadStatic**
> EffectResponseId PostKeypadStatic (int? color = null)



To set static color. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostKeypadStaticExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var color = 56;  // int? | Color value in BGR format (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostKeypadStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostKeypadStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | [optional] 

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

<a name="postmousestatic"></a>
# **PostMouseStatic**
> EffectResponseId PostMouseStatic (int? color = null)



To set static color. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostMouseStaticExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var color = 56;  // int? | Color value in BGR format (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostMouseStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostMouseStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | [optional] 

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

<a name="postmousepadstatic"></a>
# **PostMousepadStatic**
> EffectResponseId PostMousepadStatic (int? color = null)



To set static color. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostMousepadStaticExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var color = 56;  // int? | Color value in BGR format (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostMousepadStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostMousepadStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | [optional] 

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

<a name="putchromalinkstatic"></a>
# **PutChromaLinkStatic**
> EffectResponse PutChromaLinkStatic (int? color = null)



To set static color.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutChromaLinkStaticExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var color = 56;  // int? | Color value in BGR format (optional) 

            try
            {
                EffectResponse result = apiInstance.PutChromaLinkStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutChromaLinkStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | [optional] 

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

<a name="putheadsetstatic"></a>
# **PutHeadsetStatic**
> EffectResponse PutHeadsetStatic (int? color = null)



To set static color.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutHeadsetStaticExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var color = 56;  // int? | Color value in BGR format (optional) 

            try
            {
                EffectResponse result = apiInstance.PutHeadsetStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutHeadsetStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | [optional] 

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

<a name="putkeyboardstatic"></a>
# **PutKeyboardStatic**
> EffectResponse PutKeyboardStatic (int? color = null)



To set static color.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutKeyboardStaticExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var color = 56;  // int? | Color value in BGR format (optional) 

            try
            {
                EffectResponse result = apiInstance.PutKeyboardStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutKeyboardStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | [optional] 

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

<a name="putkeypadstatic"></a>
# **PutKeypadStatic**
> EffectResponse PutKeypadStatic (int? color = null)



To set static color.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutKeypadStaticExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var color = 56;  // int? | Color value in BGR format (optional) 

            try
            {
                EffectResponse result = apiInstance.PutKeypadStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutKeypadStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | [optional] 

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

<a name="putmousestatic"></a>
# **PutMouseStatic**
> EffectResponse PutMouseStatic (int? color = null)



To set static color.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutMouseStaticExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var color = 56;  // int? | Color value in BGR format (optional) 

            try
            {
                EffectResponse result = apiInstance.PutMouseStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutMouseStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | [optional] 

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

<a name="putmousepadstatic"></a>
# **PutMousepadStatic**
> EffectResponse PutMousepadStatic (int? color = null)



To set static color.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutMousepadStaticExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var color = 56;  // int? | Color value in BGR format (optional) 

            try
            {
                EffectResponse result = apiInstance.PutMousepadStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutMousepadStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | [optional] 

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

