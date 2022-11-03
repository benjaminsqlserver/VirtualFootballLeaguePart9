using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLeague.Models.ConData
{
  [Table("AspNetRoles", Schema = "dbo")]
  public partial class AspNetRole
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
    public string Id
    {
      get;
      set;
    }

    public IEnumerable<AspNetRoleClaim> AspNetRoleClaims { get; set; }
    public IEnumerable<AspNetUserRole> AspNetUserRoles { get; set; }
    [ConcurrencyCheck]
    public string Name
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string NormalizedName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ConcurrencyStamp
    {
      get;
      set;
    }
  }
}
