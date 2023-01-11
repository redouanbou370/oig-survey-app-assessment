using System.Net;
using Microsoft.AspNetCore.Mvc;
using QuestionnairesServer.Models;
using QuestionnairesServer.Services.Repository;

namespace QuestionnairesServer.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionnaireController : ControllerBase
{
    private readonly IQuestionnaireService _repository;

    public QuestionnaireController(IQuestionnaireService questionnaireService)
    {
        _repository = questionnaireService;
    }

    [HttpGet]
    public List<QuestionnaireModel> GetQuestionnaires()
    {
        return _repository.GetQuestionnaires();
    }

    [HttpGet("{id}")]
    public QuestionnaireModel GetQuestionnairy(int id)
    {
        return _repository.GetQuestionnaire(id);
    }

    [HttpPost]
    public void PostQuestionnaire(QuestionnaireModel questionnaire)
    {
        if (ModelState.IsValid) 
        {
            _repository.CreateQuestionnaire(questionnaire);
        }
    }

    [HttpPut("{id}")]
    public void PutQuestionnaire(int id, QuestionnaireModel questionnaire)
    {
        if (ModelState.IsValid)
        {
            _repository.EditQuestionnaire(id, questionnaire);
        }
        
    }

    [HttpDelete("{id}")]
    public void DeleteQuestionnaire(int id)
    {
        _repository.DeleteQuestionnaire(id);
    }
}