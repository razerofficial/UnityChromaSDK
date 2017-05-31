# CustomChromaSDK.CustomChromaPackage.DefaultApi

All URIs are relative to *http://localhost:54235*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PostKeyboard**](DefaultApi.md#postkeyboard) | **POST** /chromasdk/keyboard | 
[**PutKeyboard**](DefaultApi.md#putkeyboard) | **PUT** /chromasdk/keyboard | 


<a name="postkeyboard"></a>
# **PostKeyboard**
> KeyboardResponseId PostKeyboard (KeyboardInput keyboardInput = null)



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

