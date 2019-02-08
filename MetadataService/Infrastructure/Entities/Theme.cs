using System.ComponentModel.DataAnnotations.Schema;

namespace MetadataService.Infrastructure.Entities
{
  public class Theme : EntityBase
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
