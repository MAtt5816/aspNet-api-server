using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AspNetApiServer.Models;

[DataContract]
public class User : IEquatable<User>
{
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=true)]
    public int Id { get; set; }
    
    /// <summary>
    /// Gets or Sets Username
    /// </summary>
    [MaxLength(50)]
    [DataMember(Name="username", EmitDefaultValue=false)]
    public string Username { get; set; }

    /// <summary>
    /// Gets or Sets Salt
    /// </summary>
    [MaxLength(20)]
    [DataMember(Name="salt", EmitDefaultValue=false)]
    public string Salt { get; set; }

    /// <summary>
    /// Gets or Sets Password
    /// </summary>
    [MaxLength(64)]
    [DataMember(Name="sha256", EmitDefaultValue=false)]
    public string Sha256 { get; set; }
    
    /// <summary>
    /// Returns true if User instances are equal
    /// </summary>
    /// <param name="other">Instance of User to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(User? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return
            (
                Id == other.Id ||
                Id.Equals(other.Id)
            ) &&
            (
                Username == other.Username ||
                Username != null &&
                Username.Equals(other.Username)
            ) &&
            (
                Salt == other.Salt ||
                Salt != null &&
                Salt.Equals(other.Salt)
            ) &&
            (
                Sha256 == other.Sha256 ||
                Sha256 != null &&
                Sha256.Equals(other.Sha256)
            );
    }
}