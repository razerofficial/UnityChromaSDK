/* 
 * Chroma Rest API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 0.0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CustomChromaSDK.CustomChromaPackage.Model
{
    /// <summary>
    /// EffectResponseId
    /// </summary>
    [DataContract]
    public partial class EffectResponseId :  IEquatable<EffectResponseId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EffectResponseId" /> class.
        /// </summary>
        /// <param name="Id">Id.</param>
        /// <param name="Result">Result.</param>
        /// <param name="Results">Results.</param>
        public EffectResponseId(string Id = default(string), int? Result = default(int?), List<EffectResponseItemId> Results = default(List<EffectResponseItemId>))
        {
            this.Id = Id;
            this.Result = Result;
            this.Results = Results;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id")]
		[JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        /// <summary>
        /// Gets or Sets Result
        /// </summary>
        [DataMember(Name="result")]
		[JsonProperty(PropertyName = "result")]
        public int? Result { get; set; }
        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [DataMember(Name="results")]
		[JsonProperty(PropertyName = "results")]
        public List<EffectResponseItemId> Results { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EffectResponseId {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Result: ").Append(Result).Append("\n");
            sb.Append("  Results: ").Append(Results).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as EffectResponseId);
        }

        /// <summary>
        /// Returns true if EffectResponseId instances are equal
        /// </summary>
        /// <param name="other">Instance of EffectResponseId to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EffectResponseId other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Result == other.Result ||
                    this.Result != null &&
                    this.Result.Equals(other.Result)
                ) && 
                (
                    this.Results == other.Results ||
                    this.Results != null &&
                    this.Results.SequenceEqual(other.Results)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.Result != null)
                    hash = hash * 59 + this.Result.GetHashCode();
                if (this.Results != null)
                    hash = hash * 59 + this.Results.GetHashCode();
                return hash;
            }
        }
    }

}