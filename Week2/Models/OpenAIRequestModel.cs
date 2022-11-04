namespace BackendStageTwo.Models
{
    public class OpenAIRequestModel
    {
        public string model { get; set; } = "text-davinci-002";
        public string prompt { get; set; } = "Convert this text to a single mathematical operation. Output should be one of Addition, Substitution, Multiplication\nExample = Alli goes to school and was asked to find the solution of 2 * 2\nOutput: Multiplication\n\nAsake was a good student but the teacher always asks him simple questions like \"find the sum of village rats in london\".";
        public double temperature { get; set; } = 0.1;
        public int max_tokens { get; set; } = 100;
        public int top_p { get; set; } = 1;
        public double frequency_penalty { get; set; } = 0.2;
        public double presence_penalty { get; set; } = 0;
    }
}