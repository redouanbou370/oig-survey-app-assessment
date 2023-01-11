using QuestionnairesServer.Models;

namespace QuestionnairesServer.Services.Repository;

public interface IQuestionnaireService
{
    List<QuestionnaireModel> GetQuestionnaires();
    QuestionnaireModel GetQuestionnaire(int id);
    void CreateQuestionnaire(QuestionnaireModel questionnaire);
    void EditQuestionnaire(int id, QuestionnaireModel questionnaire);
    void DeleteQuestionnaire(int id);
}