using Chapters.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Chapters
{
    public class StringAlgorithms : IEnumerable<char>
    {

        private string Input { get; set; }
        private string[] Inputs { get; set; }

        public StringAlgorithms(string input, bool isMultilineString = false)
        {
            if (isMultilineString)
            {
                Inputs = input.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                return;
            }
            Input = input;
        }

        public StringAlgorithms(char[] input)
        {
            foreach(var i in input)
                Input += i;
        }

       

        #region Interface implementations


        IEnumerator<char> IEnumerable<char>.GetEnumerator()
        {
            foreach (var d in Input)
                yield return d;
        }

        public IEnumerable<string> GetLinesEnumerator()
        {
            foreach (var d in Inputs)
                yield return d;
        }

        //IEnumerator<string[]> IEnumerable<string[]>.GetEnumerator()
        //{
        //    foreach (var d in Inputs)
        //        yield return new string[] { d };
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        #endregion

        public override string ToString()
        {
            return Input;
        }

        private IEnumerable<Tuple<int, int>> FindSequences(Predicate<char> isThisBelongsToSequence)
        {
            var result = new List<Tuple<int, int>>();
            for (var i = 0; i < Input.Length; ++i)
            {
                if (isThisBelongsToSequence(Input[i]))
                {
                    var j = i + 1;

                    for (; j < Input.Length; ++j)
                        if (!isThisBelongsToSequence(Input[j]))
                            break;

                    result.Add(Tuple.Create(i, j >= Input.Length ? Input.Length - 1 : j - 1));

                    i = j;
                }
            }

            return result;
        }

        public static StringAlgorithms Create(Chapter9TaskType type, object param = null)
        {
            switch (type)
            {
                case Chapter9TaskType.FromString:
                    return new StringAlgorithms(param as string);
                case Chapter9TaskType.FromCharsArray:
                    return new StringAlgorithms(param as char[]);
                case Chapter9TaskType.FromFile:
                    return new StringAlgorithms(param as string, true);

                default:
                    throw new ArgumentOutOfRangeException(type.GetType().Name, type, null);
            }
        }

        

        private IEnumerable<string> MultilineExecutionContextStart()
        {
            var inputBackup = Input;
            foreach (var line in Inputs)
            {
                Input = line;
                yield return line;
            }
            Input = inputBackup;
        }

        public int CountWordsInAOddLines()
        {
            return MultilineExecutionContextStart().Where((x, i) => i % 2 == 1).Select(x => ExtractWords().Count()).Sum();
        }

        // CountPunctuationsInTheEvenStrings
        public int CountPunctuationsInTheEvenLines()
        {
            return MultilineExecutionContextStart().Where((x, i) => i % 2 == 0).SelectMany(x => FindSequences(ch => char.IsPunctuation(ch))).Sum(x=>x.Item2-x.Item1+1);
        }


        public int CountSimplesInTheText()
        {
            return MultilineExecutionContextStart().SelectMany(x => ExtractNumbers().Select(y=>Convert.ToInt32(y)).Where(y=>y.IsSimple(z=>z))).Count();
        }

        public int CountSentencesInTheText()
        {
            return MultilineExecutionContextStart().Select(y => FindSequences(x => !(x == '.' || x == '?' || x == '!')).Count()).Sum();
        }

        public string[] ExtractWords()
        {
            var wordSequences = FindSequences(ch => char.IsLetter(ch)).OrderBy(x => x.Item1).ToList();
            //var sb = new StringBuilder();
            string[] input = new string[wordSequences.Count];
            // Here we extracted word sequences, next we need to reverse
            for (int i = 0, currentSequence = 0; i < Input.Length; ++i)
            {
                if (i == wordSequences[currentSequence].Item1)
                {
                    var word = Input.Substring(i, wordSequences[currentSequence].Item2 - i + 1);
                    input[currentSequence] = word;
                    //sb.Append(word);
                    i = wordSequences[currentSequence].Item2;
                    ++currentSequence;
                }
                // fix
                if (currentSequence >= wordSequences.Count)
                    break;
            }
            return input;
        }

        //4
        public void RemoveSpacesBeforePunctuation()
        {
            for (int i = 1; i < Input.Length; i++)
                if (char.IsPunctuation(Input[i]) && Input[i - 1] == ' ')
                {
                    Input = Input.Remove(i - 1, 1);
                    --i;
                }
        }
        
        //5
        public void InsertNumberAfterSpaces(int num)
        {
            for (int i = 0; i < Input.Length - 1; i++)
                if (Input[i] == ' ')
                {
                    Input = Input.Insert(i + 1, num.ToString());
                    i+=num.ToString().Length;
                }
            if (Input[Input.Length - 1] == ' ')
                Input += num.ToString(); 
        }
        
        //6
        public void InsertNumberBeforeExclamation(int n)
        {
            string num = n.ToString();

            if (Input[0] == '!')
                Input = n.ToString() + Input;
            for (int i = 1; i < Input.Length; i++)
                if (Input[i] == '!')
                    foreach (var n1 in num)
                    {
                        Input = Input.Insert(i, n1.ToString());
                        i++;
                    }        
        }

        //7
        public List<int> ExtractNumbers()
        {
            var numberSequence = FindSequences(num => char.IsDigit(num)).ToList();
            if (numberSequence.Count == 0)
                return new List<int> { 0 };
            var res = new List<int>();
            for (int i = 0, currentSequence = 0; i < Input.Length; i++)
            {
                if (currentSequence < numberSequence.Count && i == numberSequence[currentSequence].Item1)
                {
                    var number = Convert.ToInt32(Input.Substring(i, numberSequence[currentSequence].Item2 - i + 1));
                    res.Add(number);
                    i = numberSequence[currentSequence].Item2;
                    ++currentSequence;
                }
            }
            return res;
        }
   
        //10
        public void DeleteMaxLengthWords()
        {
            var wordSequences = FindSequences(ch => char.IsLetter(ch)).ToList();
            var maxLength = wordSequences.Max(x=>x.Item2-x.Item1+1);
            var index = wordSequences.FindIndex( x=> x.Item2-x.Item1+1 == maxLength );
            var sb = new StringBuilder();
            // Here we extracted word sequences, next we need to reverse
            for (int i = 0, currentSequence = 0; i < Input.Length; ++i)
            {
                if (i == wordSequences[currentSequence].Item1)
                {
                    var word = Input.Substring(i, wordSequences[currentSequence].Item2 - i + 1);
                    if(currentSequence != index)
                        sb.Append(word);
                    i = wordSequences[currentSequence].Item2;
                    ++currentSequence;
                }
                else
                    sb.Append(Input[i]);
            }
            Input = sb.ToString();
        }

        //12
        public void InsertSpaceAfterPunctuation()
        {
            if (char.IsPunctuation(Input[Input.Length - 1]))
                Input += ' ';
            for (int i = 0; i < Input.Length - 1; i++)
                if (char.IsPunctuation(Input[i]))
                {
                    Input = Input.Insert(i + 1, " ");
                    ++i;
                }
        }

        //13
        public void ReverseWords()
        {
            var wordSequences = FindSequences(ch => char.IsLetter(ch)).OrderBy(x => x.Item1).ToList();
            var sb = new StringBuilder();
            // Here we extracted word sequences, next we need to reverse
            for (int i = 0, currentSequence = 0; i < Input.Length; ++i)
            {
                if(i == wordSequences[currentSequence].Item1)
                {
                    var word = Input.Substring(i, wordSequences[currentSequence].Item2 - i + 1);
                    var reversedWord = new string(word.Reverse().ToArray());
                    sb.Append(reversedWord);
                    i = wordSequences[currentSequence].Item2;
                    ++currentSequence;
                }
                else
                    sb.Append(Input[i]);
            }

            Input = sb.ToString();
        }
        
        //14
        public int MinWordCount()
        {
            var wordSequences = FindSequences(ch => char.IsLetter(ch)).ToList();
            var minLength = wordSequences.Min(x => x.Item2 - x.Item1 + 1);
            var count = wordSequences.Count(x => x.Item2 - x.Item1 + 1 == minLength);
            return count;
        }

        //15
        public int VowelEndLetterCount()
        {
            // Вычислить, сколько в строке слов, заканчивающихся гласной буквой

            var wordSequences = FindSequences(ch => char.IsLetter(ch)).OrderBy(x => x.Item1).ToArray();
            const string vowel = "AaEeIiOoYyUu";
            var res = wordSequences.Where(x => vowel.Contains(Input[x.Item2])).Count();
            return res;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}