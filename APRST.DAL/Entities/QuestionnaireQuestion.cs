namespace APRST.DAL.Entities
{
    public class QuestionnaireQuestion
    {
        public int Id { get; set; }
        public string NameOfQuestion { get; set; }
        public int QuestionnaireCategoryId { get; set; }
        public QuestionnaireCategory QuestionnaireCategory { get; set; }
    }
}
