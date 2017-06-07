# RazerSDKDelete.RazerDeletePackage.RazerDeleteApi

All URIs are relative to *http://localhost:54235*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteChromaSdk**](RazerDeleteApi.md#deletechromasdk) | **DELETE** / | 


<a name="deletechromasdk"></a>
# **DeleteChromaSdk**
> DeleteChromaSdkResponse DeleteChromaSdk ()



Uninitialize the Chroma SDK

### Example
```csharp
using System;
using System.Diagnostics;
using RazerSDKDelete.RazerDeletePackage;
using RazerSDKDelete.Client;
using RazerSDKDelete.RazerDeletePackage.Model;

namespace Example
{
    public class DeleteChromaSdkExample
    {
        public void main()
        {
            
            var apiInstance = new RazerDeleteApi();

            try
            {
                DeleteChromaSdkResponse result = apiInstance.DeleteChromaSdk();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RazerDeleteApi.DeleteChromaSdk: " + e.Message );
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

