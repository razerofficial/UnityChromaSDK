# ChromaSDK.ChromaPackage.DefaultApi

All URIs are relative to *http://localhost:80/chromasdk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Heartbeat**](DefaultApi.md#heartbeat) | **PUT** /heartbeat | 
[**PostKeyboard**](DefaultApi.md#postkeyboard) | **POST** /keyboard | 
[**PutKeyboard**](DefaultApi.md#putkeyboard) | **PUT** /keyboard | 


<a name="heartbeat"></a>
# **Heartbeat**
> void Heartbeat ()



Creating effects on Keyboards by sending PUT to the URI. To turn off effect use CHROMA_NONE.

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

<a name="postkeyboard"></a>
# **PostKeyboard**
> KeyboardResponseId PostKeyboard (KeyboardInput keyboardInput = null)



Creating effects on Keyboards by sending POST to the URI. POST will return an effect id. To turn off effect use CHROMA_NONE.

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
            var keyboardInput = new KeyboardInput(); // KeyboardInput |  (optional) 

            try
            {
                KeyboardResponseId result = apiInstance.PostKeyboard(keyboardInput);
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
 **keyboardInput** | [**KeyboardInput**](KeyboardInput.md)|  | [optional] 

### Return type

[**KeyboardResponseId**](KeyboardResponseId.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putkeyboard"></a>
# **PutKeyboard**
> KeyboardResponse PutKeyboard (KeyboardInput keyboardInput = null)



Creating effects on Keyboards by sending PUT to the URI. To turn off effect use CHROMA_NONE.

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
            var keyboardInput = new KeyboardInput(); // KeyboardInput |  (optional) 

            try
            {
                KeyboardResponse result = apiInstance.PutKeyboard(keyboardInput);
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
 **keyboardInput** | [**KeyboardInput**](KeyboardInput.md)|  | [optional] 

### Return type

[**KeyboardResponse**](KeyboardResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

