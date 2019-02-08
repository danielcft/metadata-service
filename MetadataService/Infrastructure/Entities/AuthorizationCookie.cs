using System;

namespace MetadataService.Infrastructure.Entities
{
  public class AuthorizationCookie : EntityBase
{
    public int Id { get; set; }
    public string Cookie { get; set; }
    public string User { get; set; }
    public string Role { get; set; }
    public DateTime ExpirationDate { get; set; }
  }
}
