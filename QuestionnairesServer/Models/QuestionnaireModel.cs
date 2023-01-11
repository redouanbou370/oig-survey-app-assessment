namespace QuestionnairesServer.Models;

public class QuestionnaireModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int StatusId { get; set; }
}