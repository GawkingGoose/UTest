using System;
using UnityEngine;

public class UtilsNumber {

    public static int roundToNearest(float value, int factor) {

        return (int)Math.Round( (value / (double)factor), MidpointRounding.AwayFromZero ) * factor;
    }

    public static long hashNumbers(Vector2 position) {
        return hashNumbers((int)position.x, (int)position.y);
    }

    public static long hashNumbers(int a, int b) {
        //To get the effect of far away coordinates - when the player starts a new game randomize to a number between 1,000,000 and 100,000,000
        //Use this number in hash function - add it to A  and B, this moves the co-ordinate accross stopping minus numbers
        a += 230000; b += 230000; 
        long A = (long)(a >= 0 ? 2 * (long)a : -2 * (long)a - 1);
        long B = (long)(b >= 0 ? 2 * (long)b : -2 * (long)b - 1);
        long C = (long)((A >= B ? A * A + A + B : A + B * B) / 2);
        return a < 0 && b < 0 || a >= 0 && b >= 0 ? C : -C - 1;
    }

    public static int scaleNumber(long number, int maxNum) {

        long divided = number / maxNum;
        long times = divided * maxNum;
        long amt = number - times;
        return (int)amt;
    }

    public static long incrementMultiple(long value, int numIncrements) {
        long newHashed = value;
        for (int i = 0; i < numIncrements; i++) {
            newHashed = incrementNumber(newHashed);
        }
        return newHashed;
    }

    public static long incrementNumber(long value)
    {
        //convert Integer to number array
        string str = value.ToString();
        char[] strA = str.ToCharArray();

        int[] num = Array.ConvertAll(strA, c => (int)Char.GetNumericValue(c));

        //increment
        int incrementAmt = 1;
        for (int i = 0; i < num.Length; i++)
        {
            if (incrementAmt > 9)
            {
                incrementAmt = 1;
            }
            if (incrementAmt == 5)
            {
                incrementAmt += 2;
            }
            num[i] = num[i] + incrementAmt;
            incrementAmt += 2;
            if (num[i] > 9)
            {
                num[i] /= 10;
            }
        }

        //convert back
        long finalNum = 0;
        for (int i = 0; i < num.Length; i++)
        {
            finalNum += num[i] * Convert.ToInt64(Math.Pow(10, num.Length - i - 1));
        }

        return finalNum;
    }
}
