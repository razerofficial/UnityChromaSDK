# RazerSDK.RazerPackage.DefaultApi

All URIs are relative to *http://localhost:54235/razer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteChromaSdk**](DefaultApi.md#deletechromasdk) | **DELETE** /chromasdk | 
[**PostChromaSdk**](DefaultApi.md#postchromasdk) | **POST** /chromasdk | 


<a name="deletechromasdk"></a>
# **DeleteChromaSdk**
> DeleteChromaSdkResponse DeleteChromaSdk ()



Uninitialize the Chroma SDK

### Example
```csharp
using System;
using System.Diagnostics;
using RazerSDK.RazerPackage;
using RazerSDK.Client;
using RazerSDK.RazerPackage.Model;

namespace Example
{
    public class DeleteChromaSdkExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();

            try
            {
                DeleteChromaSdkResponse result = apiInstance.DeleteChromaSdk();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeleteChromaSdk: " + e.Message );
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

<a name="postchromasdk"></a>
# **PostChromaSdk**
> PostChromaSdkResponse PostChromaSdk (ChromaSdkInput baseInput = null)



Initialize the Chroma SDK

### Example
```csharp
using System;
using System.Diagnostics;
using RazerSDK.RazerPackage;
using RazerSDK.Client;
using RazerSDK.RazerPackage.Model;

namespace Example
{
    public class PostChromaSdkExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var baseInput = new ChromaSdkInput(); // ChromaSdkInput |  (optional) 

            try
            {
                PostChromaSdkResponse result = apiInstance.PostChromaSdk(baseInput);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.PostChromaSdk: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **baseInput** | [**ChromaSdkInput**](ChromaSdkInput.md)|  | [optional] 

### Return type

[**PostChromaSdkResponse**](PostChromaSdkResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

