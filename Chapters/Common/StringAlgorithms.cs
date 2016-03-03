using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Chapters.Common
{
    public class StringAlgorithms : IEnumerable<char>//, IEnumerable<string>
    {

        private string Input { get; set; }

        public StringAlgorithms(string input)
        {
            Input = input;
        }

        #region Interface implementations


        IEnumerator<char> IEnumerable<char>.GetEnumerator()
        {
            foreach (var d in Input)
                yield return d;
        }

        //IEnumerator<string> IEnumerable<string>.GetEnumerator()
        //{
        //    foreach (var d in Input)
        //        yield return d.ToString();
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        
        #endregion



        public static StringAlgorithms Create(Chapter9TaskType type, object param = null)
        {
            switch (type)
            {
                case Chapter9TaskType.FromString:
                    return new StringAlgorithms(param as string);

                //case Chapter9TaskType.FromFile:
                //    return new StringAlgorithms(param as Stream);

                default:
                    throw new ArgumentOutOfRangeException(type.GetType().Name, type, null);
            }

        }

        //1

        //2
               
        //3
               
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
            //var matches = Regex.Matches(Input, @"\d+");//Input - данная строка
            //List<int> res = new List<int>();
            //foreach (Match m in matches)
            //    res.Add(Convert.ToInt32(m.Value));
            //return res;

            /*
            List<int> res = new List<int>();
            for(int i=0; i<str.Length; i++)
            {
                string num="";
                while(str[i].IsDigit() && i<str.Length)
                    num+=str[i]; i++;

                res.Add(Convert.ToInt32(num));
            }
            */
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
        public List<string> ExtracthWords()
        {
            List<string> res = new List<string>();
            for (int i = 0; i < Input.Length; i++)
            {
                string word = "";
                while (char.IsLetter(Input[i]) && i < Input.Length)
                {
                    word += Input[i]; i++;
                }
                res.Add(word);
            }
            return res;
        }

        //12
        public void InsertSpaceAfterPunctuation()
        {
            if (char.IsPunctuation(Input[Input.Length - 1]))
                Input += ' ';
            for (int i = 0; i < Input.Length-1; i++)
                if (char.IsPunctuation(Input[i]))
                    Input.Insert(i+1, " ");
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
        public override string ToString()
        {
            return Input;
        }

        //14
        private void FindMinWord()
        {
            int temp = 0;
            int len = 0;
            bool isFirst = false;
            int start = 0;
            int step = 1;

            for (int i = 0; i < Input.Length; i+=step)
            {
               
                    if (char.IsLetter(Input[i]) && !isFirst)
                    {
                        isFirst = true;
                        start = i;
                        temp++;
                    }
                    if (char.IsLetter(Input[i]) && isFirst)
                        temp++;
                    else
                    {
                        if (temp < len)
                            len = temp;
                        isFirst = false;
                        temp = 0;
                        start = 0;
                    }
               
            }
        }

        // I'll write this method and i'm sure you'll reuse it in a future multiple times
        private IEnumerable<Tuple<int, int>> FindSequences(Predicate<char> isThisBelongsToSequence)
        {
            var result = new List<Tuple<int, int>>();

            for(var i = 0; i < Input.Length; ++i)
            {
                if (isThisBelongsToSequence(Input[i]))
                {
                    var j = i + 1;

                    for (; j < Input.Length; ++j)
                        if (!isThisBelongsToSequence(Input[j]))
                            break;

                    result.Add(Tuple.Create(i, j >= Input.Length ? Input.Length - 1 : j-1));

                    i = j;
                }
            }

            return result;
        }
        // done



    }
}