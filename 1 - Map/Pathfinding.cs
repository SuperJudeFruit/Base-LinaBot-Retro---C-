using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

internal class Pathfinding
{

    // ------------------------------------------------------------------------'
    // --------------------------METTRE A JOUR---------------------------------'
    // ------------------------------------------------------------------------'

    private string[] cases = new string[2501];
    private ArrayList openlist = new ArrayList();
    private ArrayList closelist = new ArrayList();
    private int[] Plist = new int[1026];
    private int[] Flist = new int[1026];
    private int[] Glist = new int[1026];
    private int[] Hlist = new int[1026];
    private Cell[] MapHandler;
    private bool fight;
    private int nombreDePM = 9999;
    private int mapLargeur;
    private bool EviteChangeur;

    private void LoadSprites(int cellEnd)
    {
        for (int i = 1; i <= 1000; i++)
        {
            if (MapHandler[i].active && MapHandler[i].movement > 1)
            {
                if (MapHandler[i].lineOfSight == false)
                    closelist.Add(i);
                else if (fight == false)
                {

                    // S'il s'agit d'une case avec des soleils pour changer de map
                    if ((MapHandler[i].layerObject1Num == 1030) || (MapHandler[i].layerObject2Num == 1030))
                    {

                        // Je v�rifie qu'il s'agit d'une case autre de celle que je souhaite.
                        if (i != cellEnd && EviteChangeur)
                            closelist.Add(i);
                    }
                }
            }
            else
                closelist.Add(i);
        }
    }

    private void LoadEntity(int cellEnd, int caseActuel)
    {
        {
            var withBlock = Bot;
            foreach (Map_Variable.Entite pair in withBlock.Map.Entite.Values)
            {
                if (pair.Cellule != caseActuel && pair.Cellule != cellEnd)
                    closelist.Add(pair.Cellule);
            }
        }
    }

    private void LoadCell()
    {
        for (var i = 0; i <= 1024; i++)
        {
            Plist[i] = 0;
            Flist[i] = 0;
            Glist[i] = 0;
            Hlist[i] = 0;
        }
    }

    public void Pathing(int nCellEnd, int nbrPM = 9999)
    {
        {
            var withBlock = Bot;
            try
            {
                if (withBlock.Map.Handler(nCellEnd).active == false)
                    return "";

                mapLargeur = withBlock.Map.Largeur == 0 ? 15 : withBlock.Map.Largeur;
                EviteChangeur = !withBlock.Combat.Combat;
                MapHandler = withBlock.Map.Handler;
                fight = withBlock.Combat.Combat;

                InitializeCells();
                LoadCell();

                if (fight)
                {
                    if (nbrPM == 9999)
                        nombreDePM = 3;
                    else
                        nombreDePM = nbrPM;
                }
                else
                    nombreDePM = nbrPM;

                LoadSprites(nCellEnd);

                LoadEntity(nCellEnd, withBlock.Map.Entite(withBlock.Personnage.ID).Cellule);

                closelist.Remove(nCellEnd);

                string returnPath = Findpath(withBlock.Map.Entite(withBlock.Personnage.ID).Cellule, nCellEnd);

                withBlock.Map.PathTotal = returnPath;

                return cleanPath(returnPath);
            }
            catch (Exception ex)
            {
            }

            return "";
        }
    }

    private string Findpath(int cell1, int cell2)
    {
        int current;
        int i = 0;

        openlist.Add(cell1);

        while (!openlist.Contains(cell2))
        {
            i += 1;
            if (i > 1000)
                return "";

            current = getFpoint();

            if (current == cell2)
                break;

            closelist.Add(current);
            openlist.Remove(current);

            foreach (int cell in getChild(current))
            {
                if (closelist.Contains(cell) == false)
                {
                    if (openlist.Contains(cell))
                    {
                        if (Glist[current] + 5 < Glist[cell])
                        {
                            Plist[cell] = current;
                            Glist[cell] = Glist[current] + 5;
                            Hlist[cell] = goalDistance(cell, cell2);
                            Flist[cell] = Glist[cell] + Hlist[cell];
                        }
                    }
                    else
                    {
                        openlist.Add(cell);
                        openlist.Item(openlist.Count - 1) = cell;
                        Glist[cell] = Glist[current] + 5;
                        Hlist[cell] = goalDistance(cell, cell2);
                        Flist[cell] = Glist[cell] + Hlist[cell];
                        Plist[cell] = current;
                    }
                }
            }
        }

        return (GetParent(cell1, cell2));
    }
    private void GetParent(int cell1, int cell2)
    {
        int current = cell2;
        ArrayList pathCell = new ArrayList() { current };

        while (!current == cell1)
        {
            pathCell.Add(Plist[current]);
            current = Plist[current];
            if (current == 0)
                break;
        }
        return getPath(pathCell);
    }


    private void InitializeCells()
    {
        int Number = 0;
        string[] hash = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-", "_" };
        string[] hash2 = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        for (var i = 0; i <= hash2.Length - 1; i++)
        {
            for (var j = 0; j <= hash.Length - 1; j++)
            {
                cases[Number] = hash2[i] + hash[j];
                Number += 1;
            }
        }
    }

    private void GetPath(ArrayList pathCell)
    {
        pathCell.Reverse();
        string pathing = "";
        var current;
        var child;
        int PMUsed = 0;

        for (var i = 0; i <= pathCell.Count - 2; i++)
        {
            PMUsed += 1;
            if ((PMUsed > nombreDePM))
                return pathing;
            current = pathCell(i);
            child = pathCell(i + 1);
            pathing += getOrientation(current, child, mapLargeur) + cases[child];
        }
        return pathing;
    }

    private void getChild(int cell)
    {
        var x = getCaseCoordonneeX(cell);
        var y = getCaseCoordonneeY(cell);
        ArrayList children = new ArrayList();
        var temp;
        var locx, locy;

        if (fight == false)
        {
            temp = cell - (mapLargeur * 2 - 1);
            locx = getCaseCoordonneeX(temp);
            locy = getCaseCoordonneeY(temp);
            if (temp > 1 & temp < 1024 & locx == x - 1 & locy == y - 1 & closelist.Contains(temp) == false)
                children.Add(temp);

            temp = cell + (mapLargeur * 2 - 1);
            locx = getCaseCoordonneeX(temp);
            locy = getCaseCoordonneeY(temp);
            if (temp > 1 & temp < 1024 & locx == x + 1 & locy == y + 1 & closelist.Contains(temp) == false)
                children.Add(temp);
        }

        temp = cell - mapLargeur;
        locx = getCaseCoordonneeX(temp);
        locy = getCaseCoordonneeY(temp);
        if (temp > 1 & temp < 1024 & locx == x - 1 & locy == y & closelist.Contains(temp) == false)
            children.Add(temp);

        temp = cell + mapLargeur;
        locx = getCaseCoordonneeX(temp);
        locy = getCaseCoordonneeY(temp);
        if (temp > 1 & temp < 1024 & locx == x + 1 & locy == y & closelist.Contains(temp) == false)
            children.Add(temp);

        temp = cell - (mapLargeur - 1);
        locx = getCaseCoordonneeX(temp);
        locy = getCaseCoordonneeY(temp);
        if (temp > 1 & temp < 1024 & locx == x & locy == y - 1 & closelist.Contains(temp) == false)
            children.Add(temp);

        temp = cell + (mapLargeur - 1);
        locx = getCaseCoordonneeX(temp);
        locy = getCaseCoordonneeY(temp);
        if (temp > 1 & temp < 1024 & locx == x & locy == y + 1 & closelist.Contains(temp) == false)
            children.Add(temp);

        if (fight == false)
        {
            temp = cell - 1;
            locx = getCaseCoordonneeX(temp);
            locy = getCaseCoordonneeY(temp);
            if (temp > 1 & temp < 1024 & locx == x - 1 & locy == y + 1 & closelist.Contains(temp) == false)
                children.Add(temp);

            temp = cell + 1;
            locx = getCaseCoordonneeX(temp);
            locy = getCaseCoordonneeY(temp);
            if (temp > 1 & temp < 1024 & locx == x + 1 & locy == y - 1 & closelist.Contains(temp) == false)
                children.Add(temp);
        }

        return children;
    }

    private void GetFpoint()
    {
        int x = 9999;
        int cell;

        foreach (int item in openlist)
        {
            if (closelist.Contains(item) == false)
            {
                if (Flist[item] < x)
                {
                    x = Flist[item];
                    cell = item;
                }
            }
        }

        return cell;
    }

    public class loc8
    {
        public int y = 0;
        public int x = 0;
    }

    private int getCaseCoordonneeX(int nNum)
    {
        var _loc4 = mapLargeur;
        var _loc5 = Math.Floor(nNum / (double)(_loc4 * 2 - 1));
        var _loc6 = nNum - _loc5 * (_loc4 * 2 - 1);
        var _loc7 = _loc6 % _loc4;
        loc8 _loc8 = new loc8();

        int y = _loc5 - _loc7;
        int x = (nNum - (_loc4 - 1) * y) / (double)_loc4;
        return x;
    }

    private int getCaseCoordonneeY(int nNum)
    {
        var _loc4 = mapLargeur;
        var _loc5 = Math.Floor(nNum / (double)(_loc4 * 2 - 1));
        var _loc6 = nNum - _loc5 * (_loc4 * 2 - 1);
        var _loc7 = _loc6 % _loc4;
        loc8 _loc8 = new loc8();

        int y = _loc5 - _loc7;
        int x = (nNum - (_loc4 - 1) * y) / (double)_loc4;
        return y;
    }

    private void goalDistance(int nCell1, int nCell2)
    {
        var _loc5x = getCaseCoordonneeX(nCell1);
        var _loc5y = getCaseCoordonneeY(nCell1);
        var _loc6x = getCaseCoordonneeX(nCell2);
        var _loc6y = getCaseCoordonneeY(nCell2);
        var _loc7 = Math.Abs(_loc5x - _loc6x);
        var _loc8 = Math.Abs(_loc5y - _loc6y);
        return (_loc7 + _loc8);
    }

    private static object getOrientation(int cell1, int cell2, int Map_Largeur)
    {
        object obj;

        int num = cell2 - cell1;

        switch (num)
        {
            case object _ when 0 - (Map_Largeur * 2 - 1):
            case -29:
                {
                    obj = "g";
                    break;
                }

            case object _ when Map_Largeur * 2 - 1:
            case 29:
                {
                    obj = "c";
                    break;
                }

            case -1:
                {
                    obj = "e";
                    break;
                }

            case 1:
                {
                    obj = "a";
                    break;
                }

            case object _ when System.Convert.ToInt32(-Map_Largeur):
                {
                    obj = "f";
                    break;
                }

            case object _ when Map_Largeur:
                {
                    obj = "b";
                    break;
                }

            case object _ when num != 0 - (Map_Largeur - 1):
                {
                    obj = num != Map_Largeur - 1 ? "a" : "d";
                    break;
                }

            default:
                {
                    obj = "h";
                    break;
                }
        }

        return obj;
    }

    private string cleanPath(string path)
    {
        string cleanedPath = "";

        if ((path.Length > 3))
        {
            for (int i = 1; i <= path.Length; i += 3)
            {
                if ((Strings.Mid(path, i, 1) != Strings.Mid(path, i + 3, 1)))
                    cleanedPath += Strings.Mid(path, i, 3);
            }
        }
        else
            cleanedPath = path;
        return cleanedPath;
    }
}
