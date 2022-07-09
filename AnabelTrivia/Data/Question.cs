using System.ComponentModel.DataAnnotations;

namespace AnabelTrivia.Data
{
    public class Question
    {
        [Key] public int ID { get; set; }
        [DataType(DataType.Text)] public string QuestionText { get; set; }
        [DataType(DataType.Text)] public string Category { get; set; }
        [DataType(DataType.Text)] public string Used { get; set; }
    }
}