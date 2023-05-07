namespace SeetourAPI.DAL.DTO
{
    public record QuestionAnswerDto
    (
        int QuestionId,
        string Question,
        int? AnswerId,
        string Answer
    );
}
