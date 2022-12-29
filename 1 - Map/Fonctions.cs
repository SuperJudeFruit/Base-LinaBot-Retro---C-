using System;

public static class Fonctions
{

    // Tout refaire avec explication + simplification du code.

    public static double DistanceLa(int pos1, int pos2, int MapLargeur)
    {
        decimal num4 = decimal.op_Decrement(Math.Ceiling(System.Convert.ToDecimal(pos1 / (double)((MapLargeur * 2) - 1))));
        decimal num12 = decimal.op_Decrement(Math.Ceiling(System.Convert.ToDecimal(pos2 / (double)((15 * 2) - 1))));
        decimal num15 = num12 - decimal.op_Modulus(pos2 - (num12 * ((15 * 2) - 1)), 15);
        return Math.Sqrt(Math.Pow(Convert.ToDouble(pos2 - ((15 - 1) * num15 / (double)15) - (pos1 - ((MapLargeur - 1) * (num4 - decimal.op_Modulus(pos1 - (num4 * ((MapLargeur * 2) - 1)), MapLargeur)))) / (double)MapLargeur), 2) + Math.Pow(Convert.ToDouble(num15 - (num4 - decimal.op_Modulus(pos1 - (num4 * ((MapLargeur * 2) - 1)), MapLargeur))), 2));
    }

    public static double Distance2(int pos1, int pos2, int MapLargeur)
    {
        double num18;
        int num = pos1;
        int num2 = MapLargeur;
        decimal d = num / (double)((num2 * 2) - 1);
        decimal num4 = decimal.op_Decrement(Math.Ceiling(d));
        decimal num5 = num - (num4 * ((num2 * 2) - 1));
        decimal num6 = decimal.op_Modulus(num5, num2);
        decimal num7 = num4 - num6;
        decimal num8 = (num - ((num2 - 1) * num7)) / (double)num2;
        int num9 = pos2;
        int num10 = 15;
        decimal num11 = num9 / (double)((num10 * 2) - 1);
        decimal num12 = decimal.op_Decrement(Math.Ceiling(num11));
        decimal num13 = num9 - (num12 * ((num10 * 2) - 1));
        decimal num14 = decimal.op_Modulus(num13, num10);
        decimal num15 = num12 - num14;
        decimal num16 = (num9 - ((num10 - 1) * num15)) / (double)num10;
        num18 = Math.Sqrt(Math.Pow(Convert.ToDouble(num16 - num8), 2) + Math.Pow(Convert.ToDouble(num15 - num7), 2));
        return num18;
    }

    private class loc8
    {
        public int y = 0;
        public int x = 0;
    }

    public static void getX(int laCase, int MapLargeur)
    {
        try
        {
            var _loc4 = MapLargeur;
            var _loc5 = Math.Floor(laCase / (double)(_loc4 * 2 - 1));
            var _loc6 = laCase - _loc5 * (_loc4 * 2 - 1);
            var _loc7 = _loc6 % _loc4;
            loc8 _loc8 = new loc8();

            int y = _loc5 - _loc7;
            int x = (laCase - (_loc4 - 1) * y) / (double)_loc4;
            return x;
        }
        catch (Exception ex)
        {
        }
        return 0;
    }

    public static void getY(int laCase, int MapLargeur)
    {
        try
        {
            var _loc4 = MapLargeur;
            var _loc5 = Math.Floor(laCase / (double)(_loc4 * 2 - 1));
            var _loc6 = laCase - _loc5 * (_loc4 * 2 - 1);
            var _loc7 = _loc6 % _loc4;
            loc8 _loc8 = new loc8();
            int y = _loc5 - _loc7;
            int x = (laCase - (_loc4 - 1) * y) / (double)_loc4;
            return y;
        }
        catch (Exception ex)
        {
        }
        return 0;
    }

    public static int goalDistance(int pos1, int pos2, int MapLargeur)
    {
        var _loc7 = Math.Abs(getX(pos1, MapLargeur) - getX(pos2, MapLargeur));
        var _loc8 = Math.Abs(getY(pos1, MapLargeur) - getY(pos2, MapLargeur));
        return _loc7 + _loc8;
    }

    public static int ReturnLastCell(string code)
    {
        try
        {
            int Number = 0;
            string[] hash = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-", "_" };
            string[] hash2 = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            int i = 0;
            for (i = 0; i <= hash2.Length - 1; i++)
            {
                int j = 0;
                for (j = 0; j <= hash.Length - 1; j++)
                {
                    if (hash2[i] + hash[j] == code)
                        return Number;
                    Number += 1;
                }
            }
        }
        catch (Exception ex)
        {
        }
        return 0;
    }
}
