using alter_array.enums;
using LibraryForArrays;

namespace alter_array
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Size of your array: ");
            int size = ArrayTool.InputCorrectLength();

            int[] arr = new int[size];
            Console.WriteLine("Fill your array: ");
            ArrayTool.InputArray(arr);

            while (true)
            {
                Console.WriteLine("\nDo you want to change your array?");
                Console.WriteLine("  [1] - yes | [2] - no");
                Console.Write("Your choice: ");
                CheckAnswer(out int changeOrNot, 1, 2);

                if (changeOrNot == 2)
                    return;

                Console.WriteLine("\nWhat exactly you want to do with your array?");
                Console.WriteLine("  [1] - add element    | [3] - change element");
                Console.WriteLine("  [2] - remove element | [4] - i changed my mind");
                Console.Write("Your choice: ");
                CheckAnswer(out int whichOperation, 1, 4);

                if (whichOperation == 4)
                    return;

                Console.WriteLine("\nNow you have to select element:");
                Console.WriteLine("  [1] - at the end | [3] - by index (in the middle)");
                Console.WriteLine("  [2] - at start   | [4] - i changed my mind");

                Console.Write("Your choice: ");
                CheckAnswer(out int answer, 1, 4);
                WhichElement whichElement = (WhichElement)answer;

                int index;
                switch (whichElement)
                {
                    case WhichElement.AtTheEnd:
                        index = arr.Length - 1;
                        break;
                    case WhichElement.AtTheBeginning:
                        index = 0;
                        break;
                    case WhichElement.ByIndex:
                        Console.Write("Index: ");
                        CheckAnswer(out index, 0, arr.Length - 1, "There no element with this index.");
                        break;
                    default:
                        return;
                }

                ChooseOperation(whichOperation, ref arr, index);
                ArrayTool.ShowArray(arr);
            }
        }

        static void CheckAnswer(out int answer, int min, int max, string msg = "Unknown answer.")
        {
            while (!Int32.TryParse(Console.ReadLine(), out answer) || (answer < min || answer > max))
                Console.Write(msg + "\nTry again: ");
        }
        static void ChooseOperation(int answer, ref int[] arr, int index)
        {
            Operation operation = (Operation)answer;
            switch (operation)
            {
                case Operation.Add:
                    ArrayTool.AddElementInArray(ref arr, index, InputElement());
                    break;
                case Operation.Delete:
                    ArrayTool.RemoveElementFromArray(ref arr, index);
                    break;
                case Operation.Change:
                    arr[index] = InputElement();
                    break;
            }
        }
        static int InputElement()
        {
            Console.Write("New element: ");
            do
            {
                bool successfullyParsed = int.TryParse(Console.ReadLine(), out int newElement);
                if (successfullyParsed)
                    return newElement;
                else
                    Console.Write("Try again: ");
            } while (true);
        }
    }
}
