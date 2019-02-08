using System.ComponentModel.DataAnnotations.Schema;

namespace MetadataService.Infrastructure.Entities
{
  public class CmsContent : EntityBase
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ThemeId { get; set; }
    public VideoInfo VideoInfo { get; set; }
  }
}
