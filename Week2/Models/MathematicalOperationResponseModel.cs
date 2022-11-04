namespace BackendStageTwo.Models
{
    public class MathematicalOperationResponseModel
    {

        public string slackUsername { get; private set; } = "David Okeke";
        public int result { get; set; }
        public OperationType operation_type { get; set; }
    }
}