namespace BackendStageTwo.Models
{

    public class MathematicalOperationModel
    {

        public int x { get; set; }


        public int y { get; set; }

 
        public OperationType operation_type { get; set; }

        public int result { get; private set; }

        public int Add(int firstValue, int secondValue)
        {
            return firstValue + secondValue;
        }

        public int Subtract(int firstValue, int secondValue)
        {
            return firstValue - secondValue;
        }

        public int Multiply(int firstValue, int secondValue)
        {
            return firstValue * secondValue;
        }

        public void PerformOperation()
        {
            switch (operation_type)
            {
                case OperationType.addition:
                    result = Add(x, y);
                    break;
                case OperationType.subtraction:
                    result = Subtract(x, y);
                    break;
                case OperationType.multiplication:
                    result = Multiply(x, y);
                    break;
                default:
                    break;
            }
        }
    }

    public enum OperationType
    {
        addition, subtraction, multiplication
    }
}