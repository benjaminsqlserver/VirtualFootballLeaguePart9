using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLeague.Models.ConData
{
  [Table("DeviceCodes", Schema = "dbo")]
  public partial class DeviceCode
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
    public string UserCode
    {
      get;
      set;
    }

    [Column("DeviceCode")]
    [ConcurrencyCheck]
    public string DeviceCode1
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string SubjectId
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string SessionId
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ClientId
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Description
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime CreationTime
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime Expiration
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
