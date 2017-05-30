# CustomChromaSDK.CustomChromaPackage.Model.KeyboardInput
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Effect** | [**EffectType**](EffectType.md) |  | 
**Param** | **List&lt;List&lt;int?&gt;&gt;** | 2 dimensional array of size 6 rows by 22 columns. Each cell contains the color value in BGR format | [optional] 
**Color** | **List&lt;int?&gt;** | 6 by 22 columns of array containing the value of color in BGR format | [optional] 
**Key** | **List&lt;int?&gt;** | 6 by 22 columns of array containing the value of color on the specific key at the location in BGR format. Specify a bit mask of 0x01000000 with the color value for each keys that has an effect. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

