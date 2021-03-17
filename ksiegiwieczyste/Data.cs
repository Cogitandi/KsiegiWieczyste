using System;
using System.Collections.Generic;
using System.Text;

namespace ksiegiwieczyste
{
    class Data
    {
        internal static Dictionary<char, int> Dane = new Dictionary<char, int>()
        {
            ['0'] = 0,
            ['1'] = 1,
            ['2'] = 2,
            ['3'] = 3,
            ['4'] = 4,
            ['5'] = 5,
            ['6'] = 6,
            ['7'] = 7,
            ['8'] = 8,
            ['9'] = 9,
            ['X'] = 10,
            ['A'] = 11,
            ['B'] = 12,
            ['C'] = 13,
            ['D'] = 14,
            ['E'] = 15,
            ['F'] = 16,
            ['G'] = 17,
            ['H'] = 18,
            ['I'] = 19,
            ['J'] = 20,
            ['K'] = 21,
            ['L'] = 22,
            ['M'] = 23,
            ['N'] = 24,
            ['O'] = 25,
            ['P'] = 26,
            ['R'] = 27,
            ['S'] = 28,
            ['T'] = 29,
            ['U'] = 30,
            ['W'] = 31,
            ['Y'] = 32,
            ['Z'] = 33,
        };
        internal static Dictionary<int, int> Wagi = new Dictionary<int, int>()
        {
            [1] = 1,
            [2] = 3,
            [3] = 7,
            [4] = 1,
            [5] = 3,
            [6] = 7,
            [7] = 1,
            [8] = 3,
            [9] = 7,
            [10] = 1,
            [11] = 3,
            [12] = 7,
        };
        public static bool IsNumberValid(String CourtCode,String identifier, int controlDigit)
        {
            var sum = GetCourtCodeSum(CourtCode) + GetIdentifierSum(identifier);

            return (sum % 10 == controlDigit) ? true : false;
        }
        private static string AddZerosToNumber(string identifier)
        {
            var quantity0ToAdd = 8 - identifier.Length;

            var stringBuilder = new StringBuilder();
            for (int i = quantity0ToAdd; i > 0; i--)
            {
                stringBuilder.Append("0");
            }
            return String.Concat(stringBuilder, identifier);
        }
        private static int GetCourtCodeSum(string code)
        {
            if (code.Length != 4) throw new ArgumentException("Nieprawidłowy kod sądu");
            int sum = 0;
            for(int i=0;i<4;i++)
            {
                sum += GetValue(i+1, code[i]);
            }
            return sum;

        }
        private static int GetIdentifierSum(string identifier)
        {
            var correctIdentifier = AddZerosToNumber(identifier);
            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                sum += GetValue(i + 5, correctIdentifier[i]);
            }
            return sum;

        }
        private static int GetValue(int position, char character)
        {
            return Dane.GetValueOrDefault(character) * Wagi.GetValueOrDefault(position);
        }
    }
}
