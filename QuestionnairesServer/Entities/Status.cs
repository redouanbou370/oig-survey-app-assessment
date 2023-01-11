using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionnairesServer.Entities;

[Table("status")]
public class Status
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}