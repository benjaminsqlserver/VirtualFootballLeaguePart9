using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLeague.Models.ConData
{
  [Table("AspNetUsers", Schema = "dbo")]
  public partial class AspNetUser
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

    public IEnumerable<AspNetUserClaim> AspNetUserClaims { get; set; }
    public IEnumerable<AspNetUserLogin> AspNetUserLogins { get; set; }
    public IEnumerable<AspNetUserRole> AspNetUserRoles { get; set; }
    public IEnumerable<AspNetUserToken> AspNetUserTokens { get; set; }
    public IEnumerable<SeasonFixture> SeasonFixtures { get; set; }
    [ConcurrencyCheck]
    public string UserName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string NormalizedUserName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Email
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string NormalizedEmail
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public bool EmailConfirmed
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string PasswordHash
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string SecurityStamp
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
    [ConcurrencyCheck]
    public string PhoneNumber
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public bool PhoneNumberConfirmed
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public bool TwoFactorEnabled
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTimeOffset? LockoutEnd
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public bool LockoutEnabled
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int AccessFailedCount
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string FirstName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string LastName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Photo
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string WhatsAppNumber
    {
      get;
      set;
    }
  }
}
