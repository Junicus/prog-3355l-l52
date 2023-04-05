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
    }

    public List<QuestionSettings>? Questions { get; set; }

    public void OnGet()
    {
        Questions = _questions.Questions;
    }

    public void OnPost()
    {
        
    }
}

public class InputAnswers
{
    public string Name { get; set; }
    public List<int> Answers { get; set; }
}