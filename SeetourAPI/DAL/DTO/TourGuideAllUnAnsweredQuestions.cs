namespace SeetourAPI.DAL.DTO
{
    public record TourGuideAllUnAnsweredQuestions
    (
        int questionId,
       string question,
       DateTime createdAt,
       int tourId,
       string tourTitle 
        );
}
