

namespace PruebaTecnica
{
    public class MorseDecoder
    {
        private readonly static Dictionary<string, char> _morseDictionary = new Dictionary<string, char>
        {
            { ".-", 'a' },
            { "-...", 'b' },
            { "-.-.", 'c' },
            { "-..", 'd' },
            { ".", 'e' },
            { "..-.", 'f' },
            { "--.", 'g' },
            { "....", 'h' },
            { "..", 'i' },
            { ".---", 'j' },
            { "-.-", 'k' },
            { ".-..", 'l' },
            { "--", 'm' },
            { "-.", 'n' },
            { "---", 'o' },
            { ".--.", 'p' },
            { "--.-", 'q' },
            { ".-.", 'r' },
            { "...", 's' },
            { "-", 't' },
            { "..-", 'u' },
            { "...-", 'v' },
            { ".--", 'w' },
            { "-..-", 'x' },
            { "-.--", 'y' },
            { "--..", 'z' }
        };

        private HashSet<string> _words;
        public MorseDecoder(IEnumerable<string> words)
        {
            _words = words.Select(word => word.ToLower()).ToHashSet();
        }

        public List<string> DecodeWithStack(string morseSequence)
        {
            List<string> results = new List<string>();
            Stack<(string, string, string)> stack = new Stack<(string RemainingMorse, string CurrentWord, string CurrentSentence)>();

            stack.Push((morseSequence, "", ""));

            while (stack.Count > 0)
            {
                var (remainingMorse, currentWord, currentSentence) = stack.Pop();

                if (string.IsNullOrEmpty(remainingMorse) && !string.IsNullOrEmpty(currentSentence))
                {
                    results.Add(currentSentence.Trim());
                    continue;
                }

                for (int i = 1; i <= remainingMorse.Length; i++)
                {
                    string morseSubstring = remainingMorse.Substring(0, i);

                    if (_morseDictionary.TryGetValue(morseSubstring, out char letter))
                    {
                        string newWord = currentWord + letter;

                        if (_words.Any(x => x.StartsWith(newWord)))
                        {
                            stack.Push((remainingMorse.Substring(i), newWord, currentSentence));

                           if (_words.Contains(newWord))
                            {
                                stack.Push((remainingMorse.Substring(i), "", currentSentence + " " + newWord));
                            }
                        }
                    }
                }
            }

            return results;
        }

        public List<string> DecodeUsingRecursive(string morseSequence)
        {
            List<string> results = new List<string>();
            DecodeRecursive(morseSequence, "", results, "");
            return results;
        }

        private void DecodeRecursive(string morseSequence, string currentWord, List<string> results, string currentSentence)
        {
            if (string.IsNullOrEmpty(morseSequence) && !string.IsNullOrEmpty(currentSentence))
            {
                results.Add(currentSentence.Trim());
                return;
            }

            for (int i = 1; i <= morseSequence.Length; i++)
            {
                string morseSubstring = morseSequence.Substring(0, i);

                if (_morseDictionary.TryGetValue(morseSubstring, out char letter))
                {
                    string newWord = currentWord + letter;

                    if (_words.Any(x => x.StartsWith(newWord)))
                    {
                        DecodeRecursive(morseSequence.Substring(i), newWord, results, currentSentence);

                        if (_words.Contains(newWord))
                        {
                            DecodeRecursive(morseSequence.Substring(i), "", results, currentSentence + " " + newWord);
                        }
                    }
                }
            }


        }
    }
}
