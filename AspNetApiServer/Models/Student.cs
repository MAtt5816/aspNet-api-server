/*
 * API schema for research project
 *
 * API schema for research project
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using AspNetApiServer.Converters;

namespace AspNetApiServer.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Student : IEquatable<Student>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Gender
        /// </summary>
        [MaxLength(10)]
        [DataMember(Name="gender", EmitDefaultValue=false)]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [MaxLength(20)]
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [MaxLength(50)]
        [Column("first_name")]
        [DataMember(Name="first_name", EmitDefaultValue=false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [MaxLength(50)]
        [Column("last_name")]
        [DataMember(Name="last_name", EmitDefaultValue=false)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [MaxLength(100)]
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }

        /// <summary>
        /// date of birth
        /// </summary>
        /// <value>date of birth</value>
        [DataMember(Name="dob", EmitDefaultValue=false)]
        public DateTime Dob { get; set; }

        /// <summary>
        /// date of registration
        /// </summary>
        /// <value>date of registration</value>
        [DataMember(Name="registered", EmitDefaultValue=false)]
        public DateTime Registered { get; set; }

        /// <summary>
        /// Gets or Sets Phone
        /// </summary>
        [MaxLength(20)]
        [DataMember(Name="phone", EmitDefaultValue=false)]
        public string Phone { get; set; }

        /// <summary>
        /// national identification number type
        /// </summary>
        /// <value>national identification number type</value>
        [MaxLength(20)]
        [Column("id_name")]
        [DataMember(Name="id_name", EmitDefaultValue=false)]
        public string IdName { get; set; }

        /// <summary>
        /// national identification number value
        /// </summary>
        /// <value>national identification number value</value>
        [MaxLength(50)]
        [Column("id_value")]
        [DataMember(Name="id_value", EmitDefaultValue=false)]
        public string IdValue { get; set; }

        /// <summary>
        /// nationality short code
        /// </summary>
        /// <value>nationality short code</value>
        [MaxLength(10)]
        [DataMember(Name="nat", EmitDefaultValue=false)]
        public string Nat { get; set; }

        /// <summary>
        /// Gets or Sets Location
        /// </summary>
        [DataMember(Name="location", EmitDefaultValue=false)]
        public Location Location { get; set; }

        /// <summary>
        /// Gets or Sets Picture
        /// </summary>
        [DataMember(Name="picture", EmitDefaultValue=false)]
        public Picture Picture { get; set; }

        /// <summary>
        /// Copy and set fields values based on fields from passed object
        /// </summary>
        /// <param name="objectToCopy">Object from which will be copy fields values</param>
        public void CopyFieldsFromGivenObject(Student objectToCopy)
        {
            this.Gender = objectToCopy.Gender;
            this.Title = objectToCopy.Title;
            this.FirstName = objectToCopy.FirstName;
            this.LastName = objectToCopy.LastName;
            this.Email = objectToCopy.Email;
            this.Dob = objectToCopy.Dob;
            this.Phone = objectToCopy.Phone;
            this.IdName = objectToCopy.IdName;
            this.IdValue = objectToCopy.IdValue;
            this.Nat = objectToCopy.Nat;
            this.Location.CopyFieldsFromGivenObject(objectToCopy.Location);
            this.Picture.CopyFieldsFromGivenObject(objectToCopy.Picture);
        }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Student {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Gender: ").Append(Gender).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Dob: ").Append(Dob).Append("\n");
            sb.Append("  Registered: ").Append(Registered).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  IdName: ").Append(IdName).Append("\n");
            sb.Append("  IdValue: ").Append(IdValue).Append("\n");
            sb.Append("  Nat: ").Append(Nat).Append("\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  Picture: ").Append(Picture).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Student)obj);
        }

        /// <summary>
        /// Returns true if Student instances are equal
        /// </summary>
        /// <param name="other">Instance of Student to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Student other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    
                    Id.Equals(other.Id)
                ) && 
                (
                    Gender == other.Gender ||
                    Gender != null &&
                    Gender.Equals(other.Gender)
                ) && 
                (
                    Title == other.Title ||
                    Title != null &&
                    Title.Equals(other.Title)
                ) && 
                (
                    FirstName == other.FirstName ||
                    FirstName != null &&
                    FirstName.Equals(other.FirstName)
                ) && 
                (
                    LastName == other.LastName ||
                    LastName != null &&
                    LastName.Equals(other.LastName)
                ) && 
                (
                    Email == other.Email ||
                    Email != null &&
                    Email.Equals(other.Email)
                ) && 
                (
                    Dob == other.Dob ||
                    Dob != null &&
                    Dob.Equals(other.Dob)
                ) && 
                (
                    Registered == other.Registered ||
                    Registered != null &&
                    Registered.Equals(other.Registered)
                ) && 
                (
                    Phone == other.Phone ||
                    Phone != null &&
                    Phone.Equals(other.Phone)
                ) && 
                (
                    IdName == other.IdName ||
                    IdName != null &&
                    IdName.Equals(other.IdName)
                ) && 
                (
                    IdValue == other.IdValue ||
                    IdValue != null &&
                    IdValue.Equals(other.IdValue)
                ) && 
                (
                    Nat == other.Nat ||
                    Nat != null &&
                    Nat.Equals(other.Nat)
                ) && 
                (
                    Location == other.Location ||
                    Location != null &&
                    Location.Equals(other.Location)
                ) && 
                (
                    Picture == other.Picture ||
                    Picture != null &&
                    Picture.Equals(other.Picture)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Gender != null)
                    hashCode = hashCode * 59 + Gender.GetHashCode();
                    if (Title != null)
                    hashCode = hashCode * 59 + Title.GetHashCode();
                    if (FirstName != null)
                    hashCode = hashCode * 59 + FirstName.GetHashCode();
                    if (LastName != null)
                    hashCode = hashCode * 59 + LastName.GetHashCode();
                    if (Email != null)
                    hashCode = hashCode * 59 + Email.GetHashCode();
                    if (Dob != null)
                    hashCode = hashCode * 59 + Dob.GetHashCode();
                    if (Registered != null)
                    hashCode = hashCode * 59 + Registered.GetHashCode();
                    if (Phone != null)
                    hashCode = hashCode * 59 + Phone.GetHashCode();
                    if (IdName != null)
                    hashCode = hashCode * 59 + IdName.GetHashCode();
                    if (IdValue != null)
                    hashCode = hashCode * 59 + IdValue.GetHashCode();
                    if (Nat != null)
                    hashCode = hashCode * 59 + Nat.GetHashCode();
                    if (Location != null)
                    hashCode = hashCode * 59 + Location.GetHashCode();
                    if (Picture != null)
                    hashCode = hashCode * 59 + Picture.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Student left, Student right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Student left, Student right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
