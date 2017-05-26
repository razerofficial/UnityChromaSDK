# IO.Swagger..DefaultApi

All URIs are relative to *http://localhost:80/chromasdk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PostKeyboardInput**](DefaultApi.md#postkeyboardinput) | **POST** /keyboard | 
[**PutKeyboardInput**](DefaultApi.md#putkeyboardinput) | **PUT** /keyboard | 


<a name="postkeyboardinput"></a>
# **PostKeyboardInput**
> InlineResponseDefault1 PostKeyboardInput (PostKeyboardInput postKeyboardInput)



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
            var postKeyboardInput = new PostKeyboardInput(); // PostKeyboardInput |  (optional) 

            try
            {
                InlineResponseDefault1 result = apiInstance.PostKeyboardInput(postKeyboardInput);
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
 **postKeyboardInput** | [**PostKeyboardInput**](PostKeyboardInput.md)|  | [optional] 

### Return type

[**InlineResponseDefault1**](InlineResponseDefault1.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="putkeyboardinput"></a>
# **PutKeyboardInput**
> InlineResponseDefault PutKeyboardInput (PutKeyboardInput putKeyboardInput)



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
            var putKeyboardInput = new PutKeyboardInput(); // PutKeyboardInput |  (optional) 

            try
            {
                InlineResponseDefault result = apiInstance.PutKeyboardInput(putKeyboardInput);
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
 **putKeyboardInput** | [**PutKeyboardInput**](PutKeyboardInput.md)|  | [optional] 

### Return type

[**InlineResponseDefault**](InlineResponseDefault.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

