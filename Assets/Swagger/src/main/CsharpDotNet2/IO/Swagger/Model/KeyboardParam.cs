using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Effect definition
  /// </summary>
  [DataContract]
  public class KeyboardParam {

    /// <summary>
    /// Color value in BGR format
    /// </summary>
    /// <value>Color value in BGR format</value>
    [DataMember(Name="color", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "color")]
    public double? Color { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class KeyboardParam {\n");
      sb.Append("  Color: ").Append(Color).Append("\n");
      sb.Append("}\n");
            UnityEngine.Debug.Log(sb.ToString());
     return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
