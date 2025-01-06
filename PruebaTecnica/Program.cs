
namespace PruebaTecnica
{
    public class Program
    {
        
        static void Main()
        {
            string dictionaryPath = "../../../words.txt";
            IEnumerable<string> dictionary = File.ReadAllLines(dictionaryPath);

            string morseSequence = "--.--.---.......-.---.-.-.-..-.....--..-....-.-----..-";

            MorseDecoder decoder = new MorseDecoder(dictionary);
            List<string> sentences = decoder.DecodeUsingRecursive(morseSequence);
            List<string> alternativeSolution = decoder.DecodeWithStack(morseSequence);


            Console.WriteLine("Possible sentences:");

            foreach (var solution in sentences)
            {
                Console.WriteLine(solution);
            }

            Console.WriteLine("Alternative solution:");

            foreach (var solution in alternativeSolution)
            {
                Console.WriteLine(solution);
            }
        }
    }

}