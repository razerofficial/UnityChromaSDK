using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// JSON Data
  /// </summary>
  [DataContract]
  public class KeyboardInput {
    /// <summary>
    /// Effect type
    /// </summary>
    /// <value>Effect type</value>
    [DataMember(Name="effect", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "effect")]
    public string Effect { get; set; }

    /// <summary>
    /// Gets or Sets Param
    /// </summary>
    [DataMember(Name="param", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "param")]
    public KeyboardParam Param { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class KeyboardInput {\n");
      sb.Append("  Effect: ").Append(Effect).Append("\n");
      sb.Append("  Param: ").Append(Param).Append("\n");
      sb.Append("}\n");
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
