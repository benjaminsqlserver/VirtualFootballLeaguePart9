using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLeague.Models.ConData
{
  [Table("Keys", Schema = "dbo")]
  public partial class Key
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
    [ConcurrencyCheck]
    public int Version
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime Created
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Use
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Algorithm
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public bool IsX509Certificate
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public bool DataProtected
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Data
    {
      get;
      set;
    }
  }
}
