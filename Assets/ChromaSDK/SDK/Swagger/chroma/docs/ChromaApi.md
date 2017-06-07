# ChromaSDK.ChromaPackage.ChromaApi

All URIs are relative to *http://localhost:54235/chromasdk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteChromaSdk**](ChromaApi.md#deletechromasdk) | **DELETE** / | 
[**Heartbeat**](ChromaApi.md#heartbeat) | **PUT** /heartbeat | 
[**PostChromaLink**](ChromaApi.md#postchromalink) | **POST** /chromalink | 
[**PostChromaLinkCustom**](ChromaApi.md#postchromalinkcustom) | **POST** /chromalink/custom | 
[**PostChromaLinkNone**](ChromaApi.md#postchromalinknone) | **POST** /chromalink/none | 
[**PostChromaLinkStatic**](ChromaApi.md#postchromalinkstatic) | **POST** /chromalink/static | 
[**PostHeadset**](ChromaApi.md#postheadset) | **POST** /headset | 
[**PostHeadsetCustom**](ChromaApi.md#postheadsetcustom) | **POST** /headset/custom | 
[**PostHeadsetNone**](ChromaApi.md#postheadsetnone) | **POST** /headset/none | 
[**PostHeadsetStatic**](ChromaApi.md#postheadsetstatic) | **POST** /headset/static | 
[**PostKeyboard**](ChromaApi.md#postkeyboard) | **POST** /keyboard | 
[**PostKeyboardCustom**](ChromaApi.md#postkeyboardcustom) | **POST** /keyboard/custom | 
[**PostKeyboardNone**](ChromaApi.md#postkeyboardnone) | **POST** /keyboard/none | 
[**PostKeyboardStatic**](ChromaApi.md#postkeyboardstatic) | **POST** /keyboard/static | 
[**PostKeypad**](ChromaApi.md#postkeypad) | **POST** /keypad | 
[**PostKeypadCustom**](ChromaApi.md#postkeypadcustom) | **POST** /keypad/custom | 
[**PostKeypadNone**](ChromaApi.md#postkeypadnone) | **POST** /keypad/none | 
[**PostKeypadStatic**](ChromaApi.md#postkeypadstatic) | **POST** /keypad/static | 
[**PostMouse**](ChromaApi.md#postmouse) | **POST** /mouse | 
[**PostMouseCustom**](ChromaApi.md#postmousecustom) | **POST** /mouse/custom2 | 
[**PostMouseNone**](ChromaApi.md#postmousenone) | **POST** /mouse/none | 
[**PostMouseStatic**](ChromaApi.md#postmousestatic) | **POST** /mouse/static | 
[**PostMousepad**](ChromaApi.md#postmousepad) | **POST** /mousepad | 
[**PostMousepadCustom**](ChromaApi.md#postmousepadcustom) | **POST** /mousepad/custom | 
[**PostMousepadNone**](ChromaApi.md#postmousepadnone) | **POST** /mousepad/none | 
[**PostMousepadStatic**](ChromaApi.md#postmousepadstatic) | **POST** /mousepad/static | 
[**PutChromaLink**](ChromaApi.md#putchromalink) | **PUT** /chromalink | 
[**PutChromaLinkCustom**](ChromaApi.md#putchromalinkcustom) | **PUT** /chromalink/custom | 
[**PutChromaLinkNone**](ChromaApi.md#putchromalinknone) | **PUT** /chromalink/none | 
[**PutChromaLinkStatic**](ChromaApi.md#putchromalinkstatic) | **PUT** /chromalink/static | 
[**PutEffect**](ChromaApi.md#puteffect) | **PUT** /effect | 
[**PutHeadset**](ChromaApi.md#putheadset) | **PUT** /headset | 
[**PutHeadsetCustom**](ChromaApi.md#putheadsetcustom) | **PUT** /headset/custom | 
[**PutHeadsetNone**](ChromaApi.md#putheadsetnone) | **PUT** /headset/none | 
[**PutHeadsetStatic**](ChromaApi.md#putheadsetstatic) | **PUT** /headset/static | 
[**PutKeyboard**](ChromaApi.md#putkeyboard) | **PUT** /keyboard | 
[**PutKeyboardCustom**](ChromaApi.md#putkeyboardcustom) | **PUT** /keyboard/custom | 
[**PutKeyboardNone**](ChromaApi.md#putkeyboardnone) | **PUT** /keyboard/none | 
[**PutKeyboardStatic**](ChromaApi.md#putkeyboardstatic) | **PUT** /keyboard/static | 
[**PutKeypad**](ChromaApi.md#putkeypad) | **PUT** /keypad | 
[**PutKeypadCustom**](ChromaApi.md#putkeypadcustom) | **PUT** /keypad/custom | 
[**PutKeypadNone**](ChromaApi.md#putkeypadnone) | **PUT** /keypad/none | 
[**PutKeypadStatic**](ChromaApi.md#putkeypadstatic) | **PUT** /keypad/static | 
[**PutMouse**](ChromaApi.md#putmouse) | **PUT** /mouse | 
[**PutMouseCustom**](ChromaApi.md#putmousecustom) | **PUT** /mouse/custom2 | 
[**PutMouseNone**](ChromaApi.md#putmousenone) | **PUT** /mouse/none | 
[**PutMouseStatic**](ChromaApi.md#putmousestatic) | **PUT** /mouse/static | 
[**PutMousepad**](ChromaApi.md#putmousepad) | **PUT** /mousepad | 
[**PutMousepadCustom**](ChromaApi.md#putmousepadcustom) | **PUT** /mousepad/custom | 
[**PutMousepadNone**](ChromaApi.md#putmousepadnone) | **PUT** /mousepad/none | 
[**PutMousepadStatic**](ChromaApi.md#putmousepadstatic) | **PUT** /mousepad/static | 
[**RemoveEffect**](ChromaApi.md#removeeffect) | **PUT** /effect/remove | 


<a name="deletechromasdk"></a>
# **DeleteChromaSdk**
> DeleteChromaSdkResponse DeleteChromaSdk ()



Delete the Chroma SDK session

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class DeleteChromaSdkExample
    {
        public void main()
        {
            
            var apiInstance = new ChromaApi();

            try
            {
                DeleteChromaSdkResponse result = apiInstance.DeleteChromaSdk();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.DeleteChromaSdk: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**DeleteChromaSdkResponse**](DeleteChromaSdkResponse.md)

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
            
            var apiInstance = new ChromaApi();

            try
            {
                apiInstance.Heartbeat();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.Heartbeat: " + e.Message );
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
            
            var apiInstance = new ChromaApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostChromaLink(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostChromaLink: " + e.Message );
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

<a name="postchromalinkcustom"></a>
# **PostChromaLinkCustom**
> EffectResponseId PostChromaLinkCustom (EffectArray1dInput data = null)



1D array with 5 elements. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostChromaLinkCustomExample
    {
        public void main()
        {
            
            var apiInstance = new ChromaApi();
            var data = new EffectArray1dInput(); // EffectArray1dInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostChromaLinkCustom(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostChromaLinkCustom: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectArray1dInput**](EffectArray1dInput.md)|  | [optional] 

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
            
            var apiInstance = new ChromaApi();

            try
            {
                EffectResponseId result = apiInstance.PostChromaLinkNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostChromaLinkNone: " + e.Message );
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
> EffectResponseId PostChromaLinkStatic (int? color)



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
            
            var apiInstance = new ChromaApi();
            var color = 56;  // int? | Color value in BGR format

            try
            {
                EffectResponseId result = apiInstance.PostChromaLinkStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostChromaLinkStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | 

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
            
            var apiInstance = new ChromaApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostHeadset(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostHeadset: " + e.Message );
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

<a name="postheadsetcustom"></a>
# **PostHeadsetCustom**
> EffectResponseId PostHeadsetCustom (EffectArray1dInput data = null)



1D array with 5 elements. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostHeadsetCustomExample
    {
        public void main()
        {
            
            var apiInstance = new ChromaApi();
            var data = new EffectArray1dInput(); // EffectArray1dInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostHeadsetCustom(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostHeadsetCustom: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectArray1dInput**](EffectArray1dInput.md)|  | [optional] 

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
            
            var apiInstance = new ChromaApi();

            try
            {
                EffectResponseId result = apiInstance.PostHeadsetNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostHeadsetNone: " + e.Message );
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
> EffectResponseId PostHeadsetStatic (int? color)



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
            
            var apiInstance = new ChromaApi();
            var color = 56;  // int? | Color value in BGR format

            try
            {
                EffectResponseId result = apiInstance.PostHeadsetStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostHeadsetStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | 

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
            
            var apiInstance = new ChromaApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostKeyboard(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostKeyboard: " + e.Message );
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

<a name="postkeyboardcustom"></a>
# **PostKeyboardCustom**
> EffectResponseId PostKeyboardCustom (EffectArray2dInput data = null)



2D array with 6 rows of 22 columns. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostKeyboardCustomExample
    {
        public void main()
        {
            
            var apiInstance = new ChromaApi();
            var data = new EffectArray2dInput(); // EffectArray2dInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostKeyboardCustom(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostKeyboardCustom: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectArray2dInput**](EffectArray2dInput.md)|  | [optional] 

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
            
            var apiInstance = new ChromaApi();

            try
            {
                EffectResponseId result = apiInstance.PostKeyboardNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostKeyboardNone: " + e.Message );
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
> EffectResponseId PostKeyboardStatic (int? color)



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
            
            var apiInstance = new ChromaApi();
            var color = 56;  // int? | Color value in BGR format

            try
            {
                EffectResponseId result = apiInstance.PostKeyboardStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostKeyboardStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | 

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
            
            var apiInstance = new ChromaApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostKeypad(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostKeypad: " + e.Message );
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

<a name="postkeypadcustom"></a>
# **PostKeypadCustom**
> EffectResponseId PostKeypadCustom (EffectArray2dInput data = null)



1D array with 4 rows of 5 columns. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostKeypadCustomExample
    {
        public void main()
        {
            
            var apiInstance = new ChromaApi();
            var data = new EffectArray2dInput(); // EffectArray2dInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostKeypadCustom(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostKeypadCustom: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectArray2dInput**](EffectArray2dInput.md)|  | [optional] 

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
            
            var apiInstance = new ChromaApi();

            try
            {
                EffectResponseId result = apiInstance.PostKeypadNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostKeypadNone: " + e.Message );
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
> EffectResponseId PostKeypadStatic (int? color)



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
            
            var apiInstance = new ChromaApi();
            var color = 56;  // int? | Color value in BGR format

            try
            {
                EffectResponseId result = apiInstance.PostKeypadStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostKeypadStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | 

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
            
            var apiInstance = new ChromaApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostMouse(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostMouse: " + e.Message );
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

<a name="postmousecustom"></a>
# **PostMouseCustom**
> EffectResponseId PostMouseCustom (EffectArray2dInput data = null)



2D array with 9 rows of 7 columns. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostMouseCustomExample
    {
        public void main()
        {
            
            var apiInstance = new ChromaApi();
            var data = new EffectArray2dInput(); // EffectArray2dInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostMouseCustom(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostMouseCustom: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectArray2dInput**](EffectArray2dInput.md)|  | [optional] 

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
            
            var apiInstance = new ChromaApi();

            try
            {
                EffectResponseId result = apiInstance.PostMouseNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostMouseNone: " + e.Message );
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
> EffectResponseId PostMouseStatic (int? color)



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
            
            var apiInstance = new ChromaApi();
            var color = 56;  // int? | Color value in BGR format

            try
            {
                EffectResponseId result = apiInstance.PostMouseStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostMouseStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | 

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
            
            var apiInstance = new ChromaApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostMousepad(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostMousepad: " + e.Message );
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

<a name="postmousepadcustom"></a>
# **PostMousepadCustom**
> EffectResponseId PostMousepadCustom (EffectArray1dInput data = null)



1D array with 15 elements. POST will return an effect id.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PostMousepadCustomExample
    {
        public void main()
        {
            
            var apiInstance = new ChromaApi();
            var data = new EffectArray1dInput(); // EffectArray1dInput |  (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostMousepadCustom(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostMousepadCustom: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectArray1dInput**](EffectArray1dInput.md)|  | [optional] 

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
            
            var apiInstance = new ChromaApi();

            try
            {
                EffectResponseId result = apiInstance.PostMousepadNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostMousepadNone: " + e.Message );
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
> EffectResponseId PostMousepadStatic (int? color)



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
            
            var apiInstance = new ChromaApi();
            var color = 56;  // int? | Color value in BGR format

            try
            {
                EffectResponseId result = apiInstance.PostMousepadStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PostMousepadStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | 

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
            
            var apiInstance = new ChromaApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutChromaLink(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutChromaLink: " + e.Message );
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

<a name="putchromalinkcustom"></a>
# **PutChromaLinkCustom**
> EffectResponse PutChromaLinkCustom (EffectArray1dInput data = null)



1D array with 5 elements.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutChromaLinkCustomExample
    {
        public void main()
        {
            
            var apiInstance = new ChromaApi();
            var data = new EffectArray1dInput(); // EffectArray1dInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutChromaLinkCustom(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutChromaLinkCustom: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectArray1dInput**](EffectArray1dInput.md)|  | [optional] 

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
            
            var apiInstance = new ChromaApi();

            try
            {
                EffectResponse result = apiInstance.PutChromaLinkNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutChromaLinkNone: " + e.Message );
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
> EffectResponse PutChromaLinkStatic (int? color)



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
            
            var apiInstance = new ChromaApi();
            var color = 56;  // int? | Color value in BGR format

            try
            {
                EffectResponse result = apiInstance.PutChromaLinkStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutChromaLinkStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | 

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
            
            var apiInstance = new ChromaApi();
            var data = new EffectIdentifierInput(); // EffectIdentifierInput |  (optional) 

            try
            {
                EffectIdentifierResponse result = apiInstance.PutEffect(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutEffect: " + e.Message );
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
            
            var apiInstance = new ChromaApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutHeadset(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutHeadset: " + e.Message );
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

<a name="putheadsetcustom"></a>
# **PutHeadsetCustom**
> EffectResponse PutHeadsetCustom (EffectArray1dInput data = null)



1D array with 5 elements.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutHeadsetCustomExample
    {
        public void main()
        {
            
            var apiInstance = new ChromaApi();
            var data = new EffectArray1dInput(); // EffectArray1dInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutHeadsetCustom(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutHeadsetCustom: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectArray1dInput**](EffectArray1dInput.md)|  | [optional] 

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
            
            var apiInstance = new ChromaApi();

            try
            {
                EffectResponse result = apiInstance.PutHeadsetNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutHeadsetNone: " + e.Message );
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
> EffectResponse PutHeadsetStatic (int? color)



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
            
            var apiInstance = new ChromaApi();
            var color = 56;  // int? | Color value in BGR format

            try
            {
                EffectResponse result = apiInstance.PutHeadsetStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutHeadsetStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | 

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
            
            var apiInstance = new ChromaApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutKeyboard(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutKeyboard: " + e.Message );
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

<a name="putkeyboardcustom"></a>
# **PutKeyboardCustom**
> EffectResponse PutKeyboardCustom (EffectArray2dInput data = null)



2D array with 6 rows of 22 columns.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutKeyboardCustomExample
    {
        public void main()
        {
            
            var apiInstance = new ChromaApi();
            var data = new EffectArray2dInput(); // EffectArray2dInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutKeyboardCustom(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutKeyboardCustom: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectArray2dInput**](EffectArray2dInput.md)|  | [optional] 

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
            
            var apiInstance = new ChromaApi();

            try
            {
                EffectResponse result = apiInstance.PutKeyboardNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutKeyboardNone: " + e.Message );
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
> EffectResponse PutKeyboardStatic (int? color)



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
            
            var apiInstance = new ChromaApi();
            var color = 56;  // int? | Color value in BGR format

            try
            {
                EffectResponse result = apiInstance.PutKeyboardStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutKeyboardStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | 

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
            
            var apiInstance = new ChromaApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutKeypad(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutKeypad: " + e.Message );
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

<a name="putkeypadcustom"></a>
# **PutKeypadCustom**
> EffectResponse PutKeypadCustom (EffectArray2dInput data = null)



2D array with 4 rows of 5 columns.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutKeypadCustomExample
    {
        public void main()
        {
            
            var apiInstance = new ChromaApi();
            var data = new EffectArray2dInput(); // EffectArray2dInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutKeypadCustom(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutKeypadCustom: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectArray2dInput**](EffectArray2dInput.md)|  | [optional] 

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
            
            var apiInstance = new ChromaApi();

            try
            {
                EffectResponse result = apiInstance.PutKeypadNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutKeypadNone: " + e.Message );
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
> EffectResponse PutKeypadStatic (int? color)



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
            
            var apiInstance = new ChromaApi();
            var color = 56;  // int? | Color value in BGR format

            try
            {
                EffectResponse result = apiInstance.PutKeypadStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutKeypadStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | 

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
            
            var apiInstance = new ChromaApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutMouse(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutMouse: " + e.Message );
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

<a name="putmousecustom"></a>
# **PutMouseCustom**
> EffectResponse PutMouseCustom (EffectArray2dInput data = null)



2D array with 9 rows of 7 columns.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutMouseCustomExample
    {
        public void main()
        {
            
            var apiInstance = new ChromaApi();
            var data = new EffectArray2dInput(); // EffectArray2dInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutMouseCustom(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutMouseCustom: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectArray2dInput**](EffectArray2dInput.md)|  | [optional] 

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
            
            var apiInstance = new ChromaApi();

            try
            {
                EffectResponse result = apiInstance.PutMouseNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutMouseNone: " + e.Message );
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
> EffectResponse PutMouseStatic (int? color)



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
            
            var apiInstance = new ChromaApi();
            var color = 56;  // int? | Color value in BGR format

            try
            {
                EffectResponse result = apiInstance.PutMouseStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutMouseStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | 

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
            
            var apiInstance = new ChromaApi();
            var data = new EffectInput(); // EffectInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutMousepad(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutMousepad: " + e.Message );
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

<a name="putmousepadcustom"></a>
# **PutMousepadCustom**
> EffectResponse PutMousepadCustom (EffectArray1dInput data = null)



1D array with 15 elements.

### Example
```csharp
using System;
using System.Diagnostics;
using ChromaSDK.ChromaPackage;
using ChromaSDK.Client;
using ChromaSDK.ChromaPackage.Model;

namespace Example
{
    public class PutMousepadCustomExample
    {
        public void main()
        {
            
            var apiInstance = new ChromaApi();
            var data = new EffectArray1dInput(); // EffectArray1dInput |  (optional) 

            try
            {
                EffectResponse result = apiInstance.PutMousepadCustom(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutMousepadCustom: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **data** | [**EffectArray1dInput**](EffectArray1dInput.md)|  | [optional] 

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
            
            var apiInstance = new ChromaApi();

            try
            {
                EffectResponse result = apiInstance.PutMousepadNone();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutMousepadNone: " + e.Message );
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
> EffectResponse PutMousepadStatic (int? color)



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
            
            var apiInstance = new ChromaApi();
            var color = 56;  // int? | Color value in BGR format

            try
            {
                EffectResponse result = apiInstance.PutMousepadStatic(color);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.PutMousepadStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **color** | **int?**| Color value in BGR format | 

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
            
            var apiInstance = new ChromaApi();
            var data = new EffectIdentifierInput(); // EffectIdentifierInput |  (optional) 

            try
            {
                EffectIdentifierResponse result = apiInstance.RemoveEffect(data);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChromaApi.RemoveEffect: " + e.Message );
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

