using PruebaTecnica;

namespace Test
{
    public class TestPruebaTecnica
    {

        private readonly string _dictionaryPath = "../../../../PruebaTecnica/words.txt";
        private readonly string[] _dictionary;

        public TestPruebaTecnica()
        {
            _dictionary = File.ReadAllLines(_dictionaryPath);
        }

        [Fact]
        public void Test()
        {

            string morseSequence = "--.--.---.......-.---.-.-.-..-.....--..-....-.-----..-";

            MorseDecoder decoder = new MorseDecoder(_dictionary);

            List<string> solucionStack = decoder.DecodeWithStack(morseSequence);

            List<string> solucionRecursivity = decoder.DecodeUsingRecursive(morseSequence);

            Assert.Equal(solucionStack.Count, solucionRecursivity.Count);
        }

        [Fact]
        public void TestEmptyMorseSequence()
        {
            string morseSequence = "";

            MorseDecoder decoder = new MorseDecoder(_dictionary);

            List<string> solucionStack = decoder.DecodeWithStack(morseSequence);
            List<string> solucionRecursivity = decoder.DecodeUsingRecursive(morseSequence);

            Assert.Empty(solucionStack);
            Assert.Empty(solucionRecursivity);
        }

        [Fact]
        public void TestSimpleMorseSequence()
        {
            string morseSequence = ".--...--....-............-.."; //published word in morse

            MorseDecoder decoder = new MorseDecoder(_dictionary);

            List<string> solucionStack = decoder.DecodeWithStack(morseSequence);
            List<string> solucionRecursivity = decoder.DecodeUsingRecursive(morseSequence);

            Assert.Contains("published", solucionStack);
            Assert.Contains("published", solucionRecursivity);
        }

    }
}