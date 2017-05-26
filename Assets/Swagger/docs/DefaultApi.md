# IO.Swagger..DefaultApi

All URIs are relative to *http://localhost:80/chromasdk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PostKeyboardInput**](DefaultApi.md#postkeyboardinput) | **POST** /keyboard | 
[**PutHeartbeat**](DefaultApi.md#putheartbeat) | **PUT** /heartbeat | 
[**PutKeyboardInput**](DefaultApi.md#putkeyboardinput) | **PUT** /keyboard | 


<a name="postkeyboardinput"></a>
# **PostKeyboardInput**
> InlineResponseDefault1 PostKeyboardInput (KeyboardInput1 keyboardInput)



Creating effects on Keyboards by sending POST to the URI. POST will return an effect id. To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PostKeyboardInputExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var keyboardInput = new KeyboardInput1(); // KeyboardInput1 |  (optional) 

            try
            {
                InlineResponseDefault1 result = apiInstance.PostKeyboardInput(keyboardInput);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostKeyboardInput: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **keyboardInput** | [**KeyboardInput1**](KeyboardInput1.md)|  | [optional] 

### Return type

[**InlineResponseDefault1**](InlineResponseDefault1.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putheartbeat"></a>
# **PutHeartbeat**
> void PutHeartbeat ()



Creating effects on Keyboards by sending PUT to the URI. To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PutHeartbeatExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                apiInstance.PutHeartbeat();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutHeartbeat: " + e.Message );
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

<a name="putkeyboardinput"></a>
# **PutKeyboardInput**
> InlineResponseDefault PutKeyboardInput (KeyboardInput keyboardInput)



Creating effects on Keyboards by sending PUT to the URI. To turn off effect use CHROMA_NONE.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PutKeyboardInputExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var keyboardInput = new KeyboardInput(); // KeyboardInput |  (optional) 

            try
            {
                InlineResponseDefault result = apiInstance.PutKeyboardInput(keyboardInput);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PutKeyboardInput: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **keyboardInput** | [**KeyboardInput**](KeyboardInput.md)|  | [optional] 

### Return type

[**InlineResponseDefault**](InlineResponseDefault.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

