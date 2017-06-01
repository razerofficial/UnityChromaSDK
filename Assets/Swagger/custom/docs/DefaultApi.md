# CustomChromaSDK.CustomChromaPackage.DefaultApi

All URIs are relative to *http://localhost:54235/chromasdk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PostChromaLink**](DefaultApi.md#postchromalink) | **POST** /chromalink | 
[**PostHeadset**](DefaultApi.md#postheadset) | **POST** /headset | 
[**PostKeyboard**](DefaultApi.md#postkeyboard) | **POST** /keyboard | 
[**PostKeypad**](DefaultApi.md#postkeypad) | **POST** /keypad | 
[**PostMouse**](DefaultApi.md#postmouse) | **POST** /mouse | 
[**PostMousepad**](DefaultApi.md#postmousepad) | **POST** /mousepad | 
[**PutChromaLink**](DefaultApi.md#putchromalink) | **PUT** /chromalink | 
[**PutHeadset**](DefaultApi.md#putheadset) | **PUT** /headset | 
[**PutKeyboard**](DefaultApi.md#putkeyboard) | **PUT** /keyboard | 
[**PutKeypad**](DefaultApi.md#putkeypad) | **PUT** /keypad | 
[**PutMouse**](DefaultApi.md#putmouse) | **PUT** /mouse | 
[**PutMousepad**](DefaultApi.md#putmousepad) | **PUT** /mousepad | 


<a name="postchromalink"></a>
# **PostChromaLink**
> EffectResponseId PostChromaLink (EffectInput1D effectInput = null)



To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.

### Example
```csharp
using System;
using System.Diagnostics;
using CustomChromaSDK.CustomChromaPackage;
using CustomChromaSDK.Client;
using CustomChromaSDK.CustomChromaPackage.Model;

namespace Example
{
    public class PostChromaLinkExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var effectInput = new EffectInput1D(); // EffectInput1D | Array dimensions are 5 elements. (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostChromaLink(effectInput);
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
 **effectInput** | [**EffectInput1D**](EffectInput1D.md)| Array dimensions are 5 elements. | [optional] 

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
> EffectResponseId PostHeadset (EffectInput1D effectInput = null)



To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.

### Example
```csharp
using System;
using System.Diagnostics;
using CustomChromaSDK.CustomChromaPackage;
using CustomChromaSDK.Client;
using CustomChromaSDK.CustomChromaPackage.Model;

namespace Example
{
    public class PostHeadsetExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var effectInput = new EffectInput1D(); // EffectInput1D | Array dimensions are 5 elements. (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostHeadset(effectInput);
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
 **effectInput** | [**EffectInput1D**](EffectInput1D.md)| Array dimensions are 5 elements. | [optional] 

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
> EffectResponseId PostKeyboard (EffectInput effectInput = null)



To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.

### Example
```csharp
using System;
using System.Diagnostics;
using CustomChromaSDK.CustomChromaPackage;
using CustomChromaSDK.Client;
using CustomChromaSDK.CustomChromaPackage.Model;

namespace Example
{
    public class PostKeyboardExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var effectInput = new EffectInput(); // EffectInput | Array dimensions are 6 rows by 22 columns. (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostKeyboard(effectInput);
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
 **effectInput** | [**EffectInput**](EffectInput.md)| Array dimensions are 6 rows by 22 columns. | [optional] 

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
> EffectResponseId PostKeypad (EffectInput effectInput = null)



To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.

### Example
```csharp
using System;
using System.Diagnostics;
using CustomChromaSDK.CustomChromaPackage;
using CustomChromaSDK.Client;
using CustomChromaSDK.CustomChromaPackage.Model;

namespace Example
{
    public class PostKeypadExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var effectInput = new EffectInput(); // EffectInput | Array dimensions are 4 rows by 5 columns. (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostKeypad(effectInput);
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
 **effectInput** | [**EffectInput**](EffectInput.md)| Array dimensions are 4 rows by 5 columns. | [optional] 

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
> EffectResponseId PostMouse (EffectInput effectInput = null)



To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.

### Example
```csharp
using System;
using System.Diagnostics;
using CustomChromaSDK.CustomChromaPackage;
using CustomChromaSDK.Client;
using CustomChromaSDK.CustomChromaPackage.Model;

namespace Example
{
    public class PostMouseExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var effectInput = new EffectInput(); // EffectInput | Array dimensions are 9 rows by 7 columns. (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostMouse(effectInput);
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
 **effectInput** | [**EffectInput**](EffectInput.md)| Array dimensions are 9 rows by 7 columns. | [optional] 

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
> EffectResponseId PostMousepad (EffectInput1D effectInput = null)



To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.

### Example
```csharp
using System;
using System.Diagnostics;
using CustomChromaSDK.CustomChromaPackage;
using CustomChromaSDK.Client;
using CustomChromaSDK.CustomChromaPackage.Model;

namespace Example
{
    public class PostMousepadExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var effectInput = new EffectInput1D(); // EffectInput1D | Array dimensions are 15 elements. (optional) 

            try
            {
                EffectResponseId result = apiInstance.PostMousepad(effectInput);
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
 **effectInput** | [**EffectInput1D**](EffectInput1D.md)| Array dimensions are 15 elements. | [optional] 

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
> EffectResponse PutChromaLink (EffectInput1D effectInput = null)



To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.

### Example
```csharp
using System;
using System.Diagnostics;
using CustomChromaSDK.CustomChromaPackage;
using CustomChromaSDK.Client;
using CustomChromaSDK.CustomChromaPackage.Model;

namespace Example
{
    public class PutChromaLinkExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var effectInput = new EffectInput1D(); // EffectInput1D | Array dimensions are 5 elements. (optional) 

            try
            {
                EffectResponse result = apiInstance.PutChromaLink(effectInput);
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
 **effectInput** | [**EffectInput1D**](EffectInput1D.md)| Array dimensions are 5 elements. | [optional] 

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putheadset"></a>
# **PutHeadset**
> EffectResponse PutHeadset (EffectInput1D effectInput = null)



To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.

### Example
```csharp
using System;
using System.Diagnostics;
using CustomChromaSDK.CustomChromaPackage;
using CustomChromaSDK.Client;
using CustomChromaSDK.CustomChromaPackage.Model;

namespace Example
{
    public class PutHeadsetExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var effectInput = new EffectInput1D(); // EffectInput1D | Array dimensions are 5 elements. (optional) 

            try
            {
                EffectResponse result = apiInstance.PutHeadset(effectInput);
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
 **effectInput** | [**EffectInput1D**](EffectInput1D.md)| Array dimensions are 5 elements. | [optional] 

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
> EffectResponse PutKeyboard (EffectInput effectInput = null)



To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.

### Example
```csharp
using System;
using System.Diagnostics;
using CustomChromaSDK.CustomChromaPackage;
using CustomChromaSDK.Client;
using CustomChromaSDK.CustomChromaPackage.Model;

namespace Example
{
    public class PutKeyboardExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var effectInput = new EffectInput(); // EffectInput | Array dimensions are 6 rows by 22 columns. (optional) 

            try
            {
                EffectResponse result = apiInstance.PutKeyboard(effectInput);
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
 **effectInput** | [**EffectInput**](EffectInput.md)| Array dimensions are 6 rows by 22 columns. | [optional] 

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
> EffectResponse PutKeypad (EffectInput effectInput = null)



To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.

### Example
```csharp
using System;
using System.Diagnostics;
using CustomChromaSDK.CustomChromaPackage;
using CustomChromaSDK.Client;
using CustomChromaSDK.CustomChromaPackage.Model;

namespace Example
{
    public class PutKeypadExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var effectInput = new EffectInput(); // EffectInput | Array dimensions are 4 rows by 5 columns. (optional) 

            try
            {
                EffectResponse result = apiInstance.PutKeypad(effectInput);
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
 **effectInput** | [**EffectInput**](EffectInput.md)| Array dimensions are 4 rows by 5 columns. | [optional] 

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
> EffectResponse PutMouse (EffectInput effectInput = null)



To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.

### Example
```csharp
using System;
using System.Diagnostics;
using CustomChromaSDK.CustomChromaPackage;
using CustomChromaSDK.Client;
using CustomChromaSDK.CustomChromaPackage.Model;

namespace Example
{
    public class PutMouseExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var effectInput = new EffectInput(); // EffectInput | Array dimensions are 9 rows by 7 columns. (optional) 

            try
            {
                EffectResponse result = apiInstance.PutMouse(effectInput);
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
 **effectInput** | [**EffectInput**](EffectInput.md)| Array dimensions are 9 rows by 7 columns. | [optional] 

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
> EffectResponse PutMousepad (EffectInput1D effectInput = null)



To create a custom effect use CHROMA_CUSTOM and fill in the colors in each element in the array.

### Example
```csharp
using System;
using System.Diagnostics;
using CustomChromaSDK.CustomChromaPackage;
using CustomChromaSDK.Client;
using CustomChromaSDK.CustomChromaPackage.Model;

namespace Example
{
    public class PutMousepadExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var effectInput = new EffectInput1D(); // EffectInput1D | Array dimensions are 15 elements. (optional) 

            try
            {
                EffectResponse result = apiInstance.PutMousepad(effectInput);
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
 **effectInput** | [**EffectInput1D**](EffectInput1D.md)| Array dimensions are 15 elements. | [optional] 

### Return type

[**EffectResponse**](EffectResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

