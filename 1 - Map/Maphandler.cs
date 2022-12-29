using System;
using Microsoft.VisualBasic;

public static class Maphandler
{
    private static string[] HEX_CHARS = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
    private static string ZKARRAY = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";

    private static string Unescape(string StringToDecode)
    {
        return System.Web.HttpUtility.UrlDecode(StringToDecode);
    }

    public static void PrepareKey(string key)
    {
        string d = key;

        string _loc3 = "";
        int _loc4 = 0;

        while (_loc4 < d.Length)
        {
            _loc3 += Strings.Chr(Convert.ToInt64(d.Substring(_loc4, 2), 16));
            _loc4 += 2;
        }

        _loc3 = Unescape(_loc3);

        return _loc3;
    }

    public static void DecypherData(string d, string k, int c)
    {
        string _loc5 = "";
        int _loc6 = k.Length;
        int _loc7 = 0;
        int _loc9 = 0;

        while (_loc9 < d.Length)
        {
            int a = Convert.ToInt64(d.Substring(_loc9, 2), 16);
            int b = Strings.Asc(k.Substring((_loc7 + c) % _loc6, 1));
            _loc5 += Strings.Chr(a ^ b);
            _loc7 += 1;
            _loc9 += 2;
        }

        _loc5 = Unescape(_loc5);

        return _loc5;
    }

    public static void Checksum(string s)
    {
        string _loc3 = 0;
        string _loc4 = 0;

        while (_loc4 < s.Length)
        {
            _loc3 += Strings.Asc(s.Substring(_loc4, 1)) % 16;
            _loc4 += 1;
        }

        return HEX_CHARS[_loc3 % 16];
    }

    private static void HashCodes(string a)
    {
        return ZKARRAY.IndexOf(a);
    }

    public struct Cell
    {
        public int movement;
        public int groundLevel;
        public int groundSlope;
        public int layerGroundRot;
        public int layerGroundNum;
        public int layerObject1Num;
        public int layerObject2Num;
        public int layerObject1Rot;

        public bool active; // Cellule active ou non (ou on peut marcher)
        public bool lineOfSight;
        public bool layerGroundFlip;
        public bool layerObject1Flip;
        public bool layerObject2Flip;
        public bool layerObject2Interactive;
    }

    private static Cell UncompressCell(string sData)
    {
        Cell Cellule;
        int sDataLenght = sData.Length - 1;
        int[] Numero = new int[5001];

        while ((sDataLenght >= 0))
        {
            Numero[sDataLenght] = HashCodes(sData[sDataLenght]);
            sDataLenght -= 1;
        }

        Cellule.active = (Numero[0] & 32) >> 5;
        Cellule.lineOfSight = Numero[0] & 1;
        Cellule.layerGroundRot = (Numero[1] & 48) >> 4;
        Cellule.groundLevel = Numero[1] & 15;
        Cellule.movement = (Numero[2] & 56) >> 3;
        Cellule.layerGroundNum = ((Numero[0] & 24) << 6) + ((Numero[2] & 7) << 6) + Numero[3];
        Cellule.groundSlope = (Numero[4] & 60) >> 2;
        Cellule.layerGroundFlip = (Numero[4] & 2) >> 1;
        Cellule.layerObject1Num = ((Numero[0] & 4) << 11) + ((Numero[4] & 1) << 12) + (Numero[5] << 6) + Numero[6];
        Cellule.layerObject1Rot = (Numero[7] & 48) >> 4;
        Cellule.layerObject1Flip = (Numero[7] & 8) >> 3;
        Cellule.layerObject2Flip = (Numero[7] & 4) >> 2;
        Cellule.layerObject2Interactive = (Numero[7] & 2) >> 1;
        Cellule.layerObject2Num = ((Numero[0] & 2) << 12) + ((Numero[7] & 1) << 12) + (Numero[8] << 6) + Numero[9];

        return Cellule;
    }

    public static Cell[] UncompressMap(string sData)
    {
        Cell[] Cellule = new Cell[1025];
        int Fin = sData.Length;
        int Numero = 0;
        int Debut = 0;

        while (Debut < Fin)
        {
            Cellule[Numero] = UncompressCell(sData.Substring(Debut, 10));
            Debut += 10;
            Numero += 1;
        }

        return Cellule;
    }
}
