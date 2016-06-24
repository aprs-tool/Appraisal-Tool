namespace APRST.DAL.Entities
{
    public class TestAnswer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int Point { get; set; }
        public string Answer { get; set; }

        public TestQuestion Question { get; set; }
    }
}
