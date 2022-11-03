using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLeague.Models.ConData
{
  [Table("AspNetUserTokens", Schema = "dbo")]
  public partial class AspNetUserToken
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
    public string UserId
    {
      get;
      set;
    }
    public AspNetUser AspNetUser { get; set; }
    [Key]
    public string LoginProvider
    {
      get;
      set;
    }
    [Key]
    public string Name
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Value
    {
      get;
      set;
    }
  }
}
