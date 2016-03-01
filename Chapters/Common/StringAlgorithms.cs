using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Chapters.Common
{
    public class StringAlgorithms
    {

        private string Input { get; set; }

        public StringAlgorithms(string input)
        {
            Input = input;
        }

       
        //private StringAlgorithms(Stream input)
        //{
        //    Input = new char[input.Length];
        //    input.Read(Input, 0, Input.Length);
        //}

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
        public int PunctuationCount()
        {
            int sum = 0;
            foreach (var s in Input)
                if(char.IsPunctuation(s))
                        sum++;
            return sum;
        }

        //2
        public int PointExclamationPointCount()
        {
            int sum = 0;
            foreach (var c in Input)
                if (c == '.' || c == '!')
                    sum++;
            return sum;
        }
        
        //3
        public void RemoveAllCommas()
        {
            for (var i = 0; i < Input.Length; i++)
                if (Input[i] == ',')
                    Input.Remove(i, 1);
        }
        
        //4
        public void RemoveSpacesBeforePunctuation()
        {
            for (int i = 1; i < Input.Length; i++)
                if (Input[i] == ' ' && char.IsPunctuation(Input[i - 1]))
                    Input.Remove(i, 1);
        }
        
        //5
        public void InsertNumberAfterSpaces(int num)
        {
            for (int i = 0; i < Input.Length - 1; i++)
                if (Input[i] == ' ')
                    Input.Insert(i + 1, num.ToString());
        }
        
        //6
        public void InsertNumberBeforeExclamation(int num)
        {
            for (int i = 1; i < Input.Length; i++)
                if (Input[i] == '!')
                    Input.Insert(i, num.ToString());
        }

        //7
        public int SumAllNumbers()
        {
            int step = 1;
            int sum = 0;
            int start = 0;
            bool isFirst = false;

            for (int i = 0; i < Input.Length; i+=step)
            {

                if (char.IsDigit(Input[i]) && !isFirst)
                {
                    isFirst = true;
                    start = i;
                }
                else
                {
                    isFirst = false;
                    step = i - start;
                    
                    byte[] num = new byte[step];
                    for (int j = start; j < i; j++)
                        num[i - j] = Convert.ToByte(Input[j]);
                    for (int j = num.Length - 1; j > 0; j--)
                        sum += num[j] * (int)Math.Pow(10, num.Length - 1 - j);
                }
                
            }
            return sum;
        }

        //8
        public void RemoveNumbers()
        {
            for (int i = 0; i < Input.Length; i++)
                if (char.IsDigit(Input[i]))
                    Input.Remove(i, 1); 
        }

        //9
        public int SumAllSimpleNumbers()
        {
            int step = 1;
            int sum = 0;
            int start = 0;
            int number = 0;
            bool isFirst = false;

            for (int i = 0; i < Input.Length; i += step)
            {

                if (char.IsDigit(Input[i]) && !isFirst)
                {
                    isFirst = true;
                    start = i;
                }
                else
                {
                    isFirst = false;
                    step = i - start;

                    byte[] num = new byte[step];
                    for (int j = start; j < i; j++)
                        num[i - j] = Convert.ToByte(Input[j]);
                    for (int j = num.Length - 1; j > 0; j--)
                        number += num[j] * (int)Math.Pow(10, num.Length - 1 - j);
                    if (BinaryFile.IsSimple(number))
                        sum += number;
                }
            }
            return sum;
        }


        //10
        public void RemoveMaxLengthWord()
        {
            int temp = 0;
            int start = 0;
            bool isFirst = false;
            int[] word = new [] { 0, 0};

            //Find 
            for (int i = 0; i < Input.Length; i++)
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
                    if (temp > word[1])
                    {
                        word[0] = start;
                        word[1] = temp;
                    }
                    isFirst = false;
                    temp = 0;
                    start = 0;
                }
            }

            Input.Remove(word[0], word[1]);
        }

        //11
        public int FindSimpleNumbers()
        {
            int step = 1;
            int count = 0;
            int start = 0;
            int number = 0;
            bool isFirst = false;

            for (int i = 0; i < Input.Length; i += step)
            {
                if (char.IsDigit(Input[i]) && !isFirst)
                {
                    isFirst = true;
                    start = i;
                }
                else
                {
                    isFirst = false;
                    step = i - start;

                    byte[] num = new byte[step];
                    for (int j = start; j < i; j++)
                        num[i - j] = Convert.ToByte(Input[j]);
                    for (int j = num.Length - 1; j > 0; j--)
                        number += num[j] * (int)Math.Pow(10, num.Length - 1 - j);
                    if (BinaryFile.IsSimple(number))
                        count++;
                }
            }
            return count;
        }

        //12
        public void InsertSpaceAfterPunctuation()
        {
            for (int i = 0; i < Input.Length; i++)
                if (char.IsPunctuation(Input[i]))
                    Input.Insert(i + 1, " ");
        }

        //13
        public void ReverseWords()
        {
            bool isFirstLetterWas = false;
            int start = 0;
            int step = 1;

            StringBuilder res = new StringBuilder();

            for (int i = 0; i < Input.Length; i+=step)
            {
                
                if (char.IsLetter(Input[i]) && !isFirstLetterWas)
                {
                    isFirstLetterWas = true;
                    start = i;
                }
                if (!char.IsLetter(Input[i]) && isFirstLetterWas)
                {
                        isFirstLetterWas = false;
                        step = i - start;

                        StringBuilder s = new StringBuilder();
                        for (int j = start; j < i; j++)
                            s.Append(Input[j]);
                        
                        for (int j = s.Length - 1; j > 0; j--)
                            res.Append(s[j]);
                }
            }
            Input = res.ToString();
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
                for (int i = 0; i < Input.Length; i++)
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
        }




    }
}