namespace TheHundredPrisonersProblem
{
    internal class Program
    {
        #region Variables

        static int runs = 10000;
        static HashSet<int> boxes = new HashSet<int>();
        static bool[] prisoners = new bool[100];
        static int correctCount = 0;

        static int survived = 0;
        static int executed = 0;

        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine($"Running simulation {runs} times. Please wait...");

            for (int i = 0; i < runs; i++)
            {
                boxes.Clear();
                prisoners = new bool[100];

                PopulateBoxes();
                Pick();
                CountCorrect();

                if (correctCount == 100)
                    survived++;
                else
                    executed++;

                correctCount = 0;
            }

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine($"Survived: {survived}");
            Console.WriteLine($"Executed: {executed}");

            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }

        #region Main algorithm

        private static void Pick()
        {
            int currentBox = 0;

            for (int i = 0; i < prisoners.Length; i++)
            {
                currentBox = boxes.ElementAt(i);

                for (int j = 0; j < 50; j++)
                {
                    if (currentBox != i)
                        currentBox = boxes.ElementAt(currentBox);
                    else
                    {
                        prisoners[i] = true;
                        break;
                    }
                }
            }
        }

        #endregion

        #region Helpers

        private static void PopulateBoxes()
        {
            Random rng = new Random(DateTime.Now.Ticks.GetHashCode());

            while (boxes.Count != 100)
            {
                _ = boxes.Add(rng.Next(0, 100));
            }
        }

        private static void CountCorrect()
        {
            for (int i = 0; i < prisoners.Length; i++)
                if (prisoners[i])
                    correctCount++;
        }

        #endregion
    }
}