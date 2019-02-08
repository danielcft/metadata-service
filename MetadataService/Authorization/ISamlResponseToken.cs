namespace MetadataService.Authorization
{
  public interface ISamlResponseToken
  {
    bool IsValid();
    string GetUser();
    string GetRole();
  }
}
