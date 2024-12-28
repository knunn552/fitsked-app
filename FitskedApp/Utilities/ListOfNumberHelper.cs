namespace FitskedApp.Utilities
{
    public class ListOfNumberHelper
    {
        public static List<int> GenerateListOfNumbers(int start,  int end, int increment)
        {
            List<int> numbers = new List<int>();
            int trackingNumber = increment;
            for (int i = start; i <= end; i++)
            {
                if(i == start)
                {
                    numbers.Add(i);
                    trackingNumber += increment;
                }
                if ((i == trackingNumber) && (i != start))
                {
                    numbers.Add(i);
                    trackingNumber += increment;
                }
            }
            return numbers;
        }
    }
}
