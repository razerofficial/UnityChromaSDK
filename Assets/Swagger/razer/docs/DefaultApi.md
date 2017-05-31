# RazerSDK.RazerPackage.DefaultApi

All URIs are relative to *http://localhost:54235/razer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Chromasdk**](DefaultApi.md#chromasdk) | **POST** /chromasdk | 


<a name="chromasdk"></a>
# **Chromasdk**
> ChromaSdkResponse Chromasdk (ChromaSdkInput baseInput = null)



Initialize the client.

### Example
```csharp
using System;
using System.Diagnostics;
using RazerSDK.RazerPackage;
using RazerSDK.Client;
using RazerSDK.RazerPackage.Model;

namespace Example
{
    public class ChromasdkExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var baseInput = new ChromaSdkInput(); // ChromaSdkInput |  (optional) 

            try
            {
                ChromaSdkResponse result = apiInstance.Chromasdk(baseInput);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.Chromasdk: " + e.Message );
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

[**ChromaSdkResponse**](ChromaSdkResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

