//.......................................2.4.......................................

using System;
using System.Collections.Generic;

class Program
{
    private static Dictionary<char, int> _romanMap = new Dictionary<char, int>
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };
 
    public static int ConvertRomanToNumber(string text)
    {
        int totalValue = 0, prevValue = 0;
        foreach (var c in text)
        {
            if (!_romanMap.ContainsKey(c))
                return 0;
            var crtValue = _romanMap[c];
            totalValue += crtValue;
            if (prevValue != 0 && prevValue < crtValue)
            {
                if (prevValue == 1 && (crtValue == 5 || crtValue == 10)
                    || prevValue == 10 && (crtValue == 50 || crtValue == 100)
                    || prevValue == 100 && (crtValue == 500 || crtValue == 1000))
                    totalValue -= 2 * prevValue;
                else
                    return 0;
            }
            prevValue = crtValue;
        }
        return totalValue;
    }
    static void Main(string[] args)
    {
        string rim = "MCMXCIV";                                     
        int num = ConvertRomanToNumber(rim);
        Console.WriteLine("Римская цифра {0} = {1} ", rim, num);
        Console.ReadKey();
    }
}