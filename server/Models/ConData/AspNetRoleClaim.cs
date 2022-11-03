using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLeague.Models.ConData
{
  [Table("AspNetRoleClaims", Schema = "dbo")]
  public partial class AspNetRoleClaim
  {
    [NotMapped]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("@odata.etag")]
    public string ETag
    {
        get;
        set;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string RoleId
    {
      get;
      set;
    }
    public AspNetRole AspNetRole { get; set; }
    [ConcurrencyCheck]
    public string ClaimType
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ClaimValue
    {
      get;
      set;
    }
  }
}
