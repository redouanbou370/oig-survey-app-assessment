using QuestionnairesServer.Database;
using QuestionnairesServer.Models;
using QuestionnairesServer.Services.Repository;
using FluentValidation;

namespace QuestionnairesServer.Services;
using QuestionnairesServer.Entities;


public class QuestionnaireService : IQuestionnaireService
{
    private readonly DataContext _context;

    public QuestionnaireService(DataContext dataContext)
    {
        _context = dataContext;
    }

    public List<QuestionnaireModel> GetQuestionnaires()
    {
        List<QuestionnaireModel> questionnaireList = new List<QuestionnaireModel>();
        var dataList = _context.Questionnaires.ToList();

        foreach (var data in dataList)
        {   
            questionnaireList.Add(new QuestionnaireModel
            {   
                Id = data.Id,
                Name = data.Name,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
            });
        }

        return questionnaireList;
    }

    public QuestionnaireModel GetQuestionnaire(int id)
    {
        var data = GetQuestionnaires().Where(item => item.Id == id).FirstOrDefault();
        if (data == null)
            throw new Exception("No Questionnaire found with the given id");

        return data;
    }
    
    public void CreateQuestionnaire(QuestionnaireModel questionnaire)
    {
        var status = _context.Status.FirstOrDefault(item => item.Id == questionnaire.StatusId);
        if (status == null)
            throw new Exception("No Status found with the given id"); 
        
        Questionnaire questionnaireEntity = new Questionnaire();

        questionnaireEntity.Name = questionnaire.Name;
        questionnaireEntity.StartDate = questionnaire.StartDate;
        questionnaireEntity.EndDate = questionnaire.EndDate;
        questionnaireEntity.Status = status;
        _context.Questionnaires.Add(questionnaireEntity);
        _context.SaveChanges();
    }

    public void EditQuestionnaire(int id, QuestionnaireModel questionnaire)
    {
        Questionnaire questionnaireEntity = new Questionnaire();

        questionnaireEntity = _context.Questionnaires.Where(d => d.Id == id).FirstOrDefault();
        if (questionnaireEntity != null) 
        {
            
            var status = _context.Status.FirstOrDefault(item => item.Id == questionnaire.StatusId);
            if (status == null)
                throw new Exception("No Status found with the given id"); 

            questionnaireEntity.Name = questionnaire.Name;
            questionnaireEntity.StartDate = questionnaire.StartDate;
            questionnaireEntity.EndDate = questionnaire.EndDate;
            questionnaireEntity.Status = status;
            _context.Questionnaires.Update(questionnaireEntity);
            _context.SaveChanges();
        }
    }

    public void DeleteQuestionnaire(int id)
    {
        var data = _context.Questionnaires.Where(item => item.Id == id).FirstOrDefault();
        if (data != null)
        {
            _context.Questionnaires.Remove(data);
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("No Questionnaire found with the given id");
        }

    }
    
}