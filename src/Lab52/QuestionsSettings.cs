namespace Lab52;

public class QuestionsSettings
{
    public const string SectionName = "QuestionsSettings";

    public List<QuestionSettings> Questions { get; set; }
}

public class QuestionSettings
{
    public string Question { get; set; }
    public List<AnswerSettings> Answers { get; set; }
    public QuestionType Type { get; set; }
}

public class AnswerSettings
{
    public string Answer { get; set; }
    public bool IsCorrect { get; set; }
}

public enum QuestionType
{
    Combo,
    Radio,
}