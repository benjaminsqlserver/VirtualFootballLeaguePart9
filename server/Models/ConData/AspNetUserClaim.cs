using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLeague.Models.ConData
{
  [Table("AspNetUserClaims", Schema = "dbo")]
  public partial class AspNetUserClaim
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
    public string UserId
    {
      get;
      set;
    }
    public AspNetUser AspNetUser { get; set; }
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
