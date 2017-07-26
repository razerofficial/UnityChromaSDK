# RazerSDK.ChromaPackage.RazerApi

All URIs are relative to *http://localhost:54235/razer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetChromaSdk**](RazerApi.md#getchromasdk) | **GET** /chromasdk | 
[**PostChromaSdk**](RazerApi.md#postchromasdk) | **POST** /chromasdk | 


<a name="getchromasdk"></a>
# **GetChromaSdk**
> GetChromaSdkResponse GetChromaSdk ()



Check the REST version

### Example
```csharp
using System;
using System.Diagnostics;
using RazerSDK.ChromaPackage;
using RazerSDK.Client;
using RazerSDK.ChromaPackage.Model;

namespace Example
{
    public class GetChromaSdkExample
    {
        public void main()
        {
            
            var apiInstance = new RazerApi();

            try
            {
                GetChromaSdkResponse result = apiInstance.GetChromaSdk();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RazerApi.GetChromaSdk: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**GetChromaSdkResponse**](GetChromaSdkResponse.md)

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
using RazerSDK.ChromaPackage;
using RazerSDK.Client;
using RazerSDK.ChromaPackage.Model;

namespace Example
{
    public class PostChromaSdkExample
    {
        public void main()
        {
            
            var apiInstance = new RazerApi();
            var baseInput = new ChromaSdkInput(); // ChromaSdkInput |  (optional) 

            try
            {
                PostChromaSdkResponse result = apiInstance.PostChromaSdk(baseInput);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RazerApi.PostChromaSdk: " + e.Message );
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

