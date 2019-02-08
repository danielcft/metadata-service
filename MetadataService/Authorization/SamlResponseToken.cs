namespace MetadataService.Authorization
{
  public class SamlResponseToken : ISamlResponseToken
  {
    /// <summary>
    /// This class is for only for demonstration purposes.
    /// When in production, please use C#'s builtin SAML2.0 module ! 
    /// </summary>
    /// <param name="samlResponse"></param>
    public SamlResponseToken(string samlResponse)
    {
    }
    public bool IsValid()
    {
      // Mocked. Must validate assertions, signatures, decrypt fields whenever necessary
      return true;
    }

    public string GetUser()
    {
      // Mocked. Must return actual user from the SAML assertion
      return "foo_dev";
    }

    public string GetRole()
    {
      // Mocked. Must return actual role from the SAML assertion
      return "developer_team_01";
    }
  }
}
