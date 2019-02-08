using System.ComponentModel.DataAnnotations.Schema;

namespace MetadataService.Infrastructure.Entities
{
  public class VideoInfo : EntityBase
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Url { get; set; }
    public VideoState State { get; set; }

    public enum VideoState
    {
      Available, NotAvailable
    }
  }
}
