using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Lab52.Pages;

public class IndexModel : PageModel
{
    private readonly QuestionsSettings _questions;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, IOptions<QuestionsSettings> questions)
    {
        _questions = questions.Value;
        _logger = logger;

        Questions = _questions.Questions;
    }

    public List<QuestionSettings>? Questions { get; set; }

    [BindProperty] public InputAnswers InputAnswers { get; set; } = new();

    public ResultScores? ResultScores { get; set; }
    
    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            var results = InputAnswers.Answers.Select((value, i) => _questions.Questions[i].Answers[value].IsCorrect).ToList();

            ResultScores = new ResultScores
            {
                Name = InputAnswers.Name,
                Score = results.Count(t => t) * 5
            };
        }
    }
}

public class InputAnswers
{
    [Required] public string Name { get; set; } = string.Empty;
    public List<int> Answers { get; set; } = new();
}

public class ResultScores
{
    public string Name { get; set; } = string.Empty;
    public int Score { get; set; }
}