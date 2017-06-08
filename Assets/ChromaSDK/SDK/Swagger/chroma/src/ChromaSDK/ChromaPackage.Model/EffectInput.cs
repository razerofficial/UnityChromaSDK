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

namespace ChromaSDK.ChromaPackage.Model
{
    /// <summary>
    /// JSON Data
    /// </summary>
    [DataContract]
    public partial class EffectInput :  IEquatable<EffectInput>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EffectInput" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EffectInput() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EffectInput" /> class.
        /// </summary>
        /// <param name="Effect">Effect (required).</param>
        /// <param name="Param">Param.</param>
        public EffectInput(EffectType Effect = default(EffectType), EffectInputParam Param = default(EffectInputParam))
        {
            // to ensure "Effect" is required (not null)
            if (Effect == null)
            {
                throw new Exception("Effect is a required property for EffectInput and cannot be null");
            }
            else
            {
                this.Effect = Effect;
            }
            this.Param = Param;
        }
        
        /// <summary>
        /// Gets or Sets Effect
        /// </summary>
        [DataMember(Name="effect")]
		[JsonProperty(PropertyName = "effect")]
        public EffectType Effect { get; set; }
        /// <summary>
        /// Gets or Sets Param
        /// </summary>
        [DataMember(Name="param")]
		[JsonProperty(PropertyName = "param")]
        public EffectInputParam Param { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EffectInput {\n");
            sb.Append("  Effect: ").Append(Effect).Append("\n");
            sb.Append("  Param: ").Append(Param).Append("\n");
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
            return this.Equals(obj as EffectInput);
        }

        /// <summary>
        /// Returns true if EffectInput instances are equal
        /// </summary>
        /// <param name="other">Instance of EffectInput to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EffectInput other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Effect == other.Effect ||
                    this.Effect != null &&
                    this.Effect.Equals(other.Effect)
                ) && 
                (
                    this.Param == other.Param ||
                    this.Param != null &&
                    this.Param.Equals(other.Param)
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
                if (this.Effect != null)
                    hash = hash * 59 + this.Effect.GetHashCode();
                if (this.Param != null)
                    hash = hash * 59 + this.Param.GetHashCode();
                return hash;
            }
        }
    }

}
