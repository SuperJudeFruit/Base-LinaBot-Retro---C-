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

static class Chargement
{
    public static void ChargeServeur()
    {
        try
        {
            VarServeur.Clear();

            // J'ouvre et je lis le fichier.
            System.IO.StreamReader swLecture = new System.IO.StreamReader(Application.StartupPath + @"\Data/Serveur.txt");

            while (!swLecture.EndOfStream)
            {
                string Ligne = swLecture.ReadLine();

                if (Ligne != "")
                {
                    string[] Separation = Strings.Split(Ligne.Replace(" ", ""), "|");

                    if (!VarServeur.ContainsKey(Separation[0]))
                    {
                        ClassServeur varServer = new ClassServeur();

                        {
                            var withBlock = varServer;
                            withBlock.Nom = Separation[0];
                            withBlock.IP = Separation[1];
                            withBlock.Port = Separation[2];
                            withBlock.ID = Separation[3];
                        }

                        VarServeur.Add(Separation[0], varServer);
                    }
                }
            }

            // Puis je ferme le fichier.
            swLecture.Close();
        }
        catch (Exception ex)
        {
            ErreurFichier("Load", "ChargeServeur", ex.Message);
        }
    }

    public static void ChargeCaracteristique()
    {

        // J'ouvre et je lis le fichier.
        System.IO.StreamReader swReading = new System.IO.StreamReader(Application.StartupPath + @"\Data/Caracteristique.txt");

        while (!swReading.EndOfStream)
        {
            string line = swReading.ReadLine();

            if (line != "")
            {
                string[] separate = Strings.Split(line.Replace(" ", ""), "|");

                if (!VarCaractéristique.ContainsKey(separate[0]))
                    VarCaractéristique.Add(separate[0], new Dictionary<string, string[]>() { { separate[1], separate } });
                else
                    VarCaractéristique(separate[0]).Add(separate[1], separate);
            }
        }

        // Puis je ferme le fichier.
        swReading.Close();
    }

    public static void ChargeItems()
    {
        try
        {

            // J'ouvre et je lis le fichier.
            System.IO.StreamReader swReading = new System.IO.StreamReader(Application.StartupPath + @"\Data/Items.txt");

            while (!swReading.EndOfStream)
            {
                string lige = swReading.ReadLine();

                if (lige != "")
                {
                    string[] separate = Strings.Split(lige, "|");

                    if (!VarItems.ContainsKey(separate[0]))
                    {
                        sItems _varItems = new sItems();

                        {
                            var withBlock = _varItems;
                            withBlock.ID = separate[0];
                            withBlock.Nom = separate[1];
                            withBlock.Catégorie = separate[2];
                            withBlock.Pods = separate[3];
                        }

                        VarItems.Add(separate[0], _varItems);
                    }
                }
            }

            // Puis je ferme le fichier.
            swReading.Close();
        }
        catch (Exception ex)
        {
            ErreurFichier("Load", "ChargeItems", ex.Message);
        }
    }

    public static void ChargeSort()
    {
        try
        {

            // Si le fichier sort éxiste.
            if (System.IO.File.Exists(@"Data\Sort.txt"))
            {

                // Je l'ouvre.
                System.IO.StreamReader swReading = new System.IO.StreamReader(@"Data\Sort.txt");

                // Puis je regarde chaque ligne jusqu'à la fin du fichier.
                while (!swReading.EndOfStream)
                {

                    // Je met la ligne dans une variable string.
                    string line = swReading.ReadLine();

                    // Si elle n'est pas vide alors.
                    if (line != "")

                        // Je sépare les informations.
                        string[] separate = Strings.Split(line, "|");
                }

                // Je ferme mon fichier.
                swReading.Close();
            }
        }
        catch (Exception ex)
        {
            ErreurFichier("chargesort", "ChargeSort", ex.Message);
        }
    }

    public static void ChargeQuête()
    {
        System.IO.StreamReader swReading = new System.IO.StreamReader("Data/Quête.txt");

        while (!swReading.EndOfStream)
        {
            string Line = swReading.ReadLine();

            if (Line != "")
            {
                string[] separate = Strings.Split(Line, "|");

                VarQuête.Add(separate[0], separate[1]);
            }
        }

        swReading.Close();
    }

    public static void ChargeMap()
    {
        try
        {
            VarMap.Clear();

            System.IO.StreamReader swReading = new System.IO.StreamReader("Data/Maps.txt");

            while (!swReading.EndOfStream)
            {
                string line = swReading.ReadLine();

                if (line != "")
                {
                    string[] separate = Strings.Split(line, ":");

                    VarMap.Add(separate[0], separate[1]);
                }
            }

            swReading.Close();
        }
        catch (Exception ex)
        {
            ErreurFichier("Unknow", "LoadMaps", ex.Message);
        }
    }

    public static void ChargeDivers()
    {
        try
        {
            VarInteraction.Clear();

            System.IO.StreamReader swReading = new System.IO.StreamReader("Data/Divers.txt");

            while (!swReading.EndOfStream)
            {
                string line = swReading.ReadLine();

                if (line != "")
                {
                    string[] separate = Strings.Split(line, "|");

                    sInteraction _varInteraction = new sInteraction();

                    {
                        var withBlock = _varInteraction;
                        withBlock.IdSprite = separate[0];
                        withBlock.Name = separate[1];
                        withBlock.DicoInteraction = new Dictionary<string, int>();

                        string[] separateNameInteraction = Strings.Split(separate[2], ":");
                        string[] separateIDInteraction = Strings.Split(separate[3], ":");

                        for (var i = 0; i <= separateNameInteraction.Count() - 1; i++)
                            withBlock.DicoInteraction.Add(separateNameInteraction[i].ToLower(), separateIDInteraction[i].ToLower());
                    }

                    VarInteraction.Add(separate[0], _varInteraction);
                }
            }

            swReading.Close();
        }
        catch (Exception ex)
        {
            ErreurFichier("Unknow", "LoadMetier", ex.Message);
        }
    }

    public static void ChargeRecolte()
    {
        try
        {
            VarInteraction.Clear();

            System.IO.StreamReader swReading = new System.IO.StreamReader("Data/Recolte.txt");

            while (!swReading.EndOfStream)
            {
                string line = swReading.ReadLine();

                if (line != "")
                {
                    string[] separate = Strings.Split(line, "|");

                    sInteraction _varInteraction = new sInteraction();

                    {
                        var withBlock = _varInteraction;
                        withBlock.IdSprite = separate[0];
                        withBlock.Name = separate[1];
                        withBlock.DicoInteraction = new Dictionary<string, int>();

                        string[] separateNameInteraction = Strings.Split(separate[2], ":");
                        string[] separateIDInteraction = Strings.Split(separate[3], ":");

                        for (var i = 0; i <= separateNameInteraction.Count() - 1; i++)
                            withBlock.DicoInteraction.Add(separateNameInteraction[i].ToLower(), separateIDInteraction[i].ToLower());
                    }

                    VarRecolte.Add(separate[0], _varInteraction);
                }
            }

            swReading.Close();
        }
        catch (Exception ex)
        {
            ErreurFichier("Unknow", "ChargeRecolte", ex.Message);
        }
    }

    public static void ChargeMobs()
    {

        // J'ouvre et je lis le fichier.
        System.IO.StreamReader swReading = new System.IO.StreamReader(Application.StartupPath + @"\Data/Mobs.txt");

        while (!swReading.EndOfStream)
        {
            string line = swReading.ReadLine();

            if (line != "")
            {
                string[] separate = Strings.Split(line, "|"); // 31|Larve Bleue|Level:2:Résistance:1:5:5:-9:-9:5:3|Next level

                int idMobs = separate[0];
                string nameMobs = separate[1];

                for (var a = 2; a <= separate.Count() - 1; a++) // Level:2:Résistance:1:5:5:-9:-9:5:3
                {
                    string[] separateData = Strings.Split(separate[a], ":");

                    sMobs _varMobs = new sMobs();

                    {
                        var withBlock = _varMobs;
                        withBlock.ID = separate[0];
                        withBlock.Nom = separate[1];
                        withBlock.Niveau = separateData[1];

                        withBlock.RésistanceNeutre = separateData[3];
                        withBlock.RésistanceTerre = separateData[4];
                        withBlock.RésistanceFeu = separateData[5];
                        withBlock.RésistanceEau = separateData[6];
                        withBlock.RésistanceAir = separateData[7];

                        withBlock.EsquivePA = separateData[8];
                        withBlock.EsquivePM = separateData[9];
                    }

                    if (VarMobs.ContainsKey(idMobs))
                        VarMobs(idMobs).Add(a - 2, _varMobs);
                    else
                        VarMobs.Add(idMobs, new Dictionary<int, sMobs>()
                        {
                            {
                                a - 2,
                                _varMobs
                            }
                        });
                }
            }
        }

        // Puis je ferme le fichier.
        swReading.Close();
    }

    public static void LoadPersonage()
    {

        // J'ouvre et je lis le fichier.
        System.IO.StreamReader swReading = new System.IO.StreamReader(Application.StartupPath + @"\Data/Personnage.txt");

        while (!swReading.EndOfStream)
        {
            string lige = swReading.ReadLine();

            if (lige != "")
            {
                string[] separate = Strings.Split(lige, "|");

                if (!VarPersonnage.ContainsKey(separate[0]))
                {
                    sPersonnage varPersonage = new sPersonnage();

                    {
                        var withBlock = varPersonage;
                        withBlock.ID = separate[0];
                        withBlock.Nom = separate[1];
                        withBlock.Sexe = separate[2];
                    }

                    VarPersonnage.Add(separate[0], varPersonage);
                }
            }
        }

        // Puis je ferme le fichier.
        swReading.Close();
    }

    public static void ChargePnj()
    {
        VarPnj.Clear();

        // J'ouvre et je lis le fichier.
        System.IO.StreamReader swReading = new System.IO.StreamReader(Application.StartupPath + @"\Data/Pnj.txt");

        while (!swReading.EndOfStream)
        {
            string line = swReading.ReadLine();

            if (line != "")
            {
                string[] separate = Strings.Split(line, "|");

                if (!VarPnj.ContainsKey(separate[0]))
                    VarPnj.Add(separate[0], separate[1]);// ID + Nom
            }
        }

        // Puis je ferme le fichier.
        swReading.Close();
    }

    public static void ChargePnjRéponse()
    {
        System.IO.StreamReader swReading = new System.IO.StreamReader("Data/PnjRéponse.txt");

        while (!swReading.EndOfStream)
        {
            string line = swReading.ReadLine();

            if (line != "")
            {
                string[] separate = Strings.Split(line, "=");

                VarPnjRéponse.Add(separate[0], separate[1]);
            }
        }

        swReading.Close();
    }

    public static void ChargeMaison()
    {

        // J'ouvre et je lis le fichier.
        System.IO.StreamReader swReading = new System.IO.StreamReader(Application.StartupPath + @"\Data/Maison.txt");

        VarMaison.Clear();

        while (!swReading.EndOfStream)
        {
            string line = swReading.ReadLine();

            if (line != "")
            {
                string[] separate = Strings.Split(line, " | ");

                string hP = Strings.Split(separate[0], " : ")(1);
                string cellDoor = Strings.Split(separate[1], " : ")(1);
                string map = Strings.Split(separate[2], " : ")(1);
                string mapId = Strings.Split(separate[3], " : ")(1);
                string name = Strings.Split(separate[4], " : ")(1);

                if (!VarMaison.ContainsKey(hP))
                {
                    sMaison varHouse = new sMaison();

                    {
                        var withBlock = varHouse;
                        withBlock.Nom = name;
                        withBlock.Map = map;
                        withBlock.CellulePorte = cellDoor;
                        withBlock.MapId = mapId;
                    }

                    VarMaison.Add(hP, varHouse);
                }
            }
        }

        // Puis je ferme le fichier.
        swReading.Close();
    }

    public static void ChargeMetier()
    {
        try
        {
            VarMetier.Clear();

            System.IO.StreamReader swReading = new System.IO.StreamReader("Data/Metier.txt");

            while (!swReading.EndOfStream)
            {
                string Line = swReading.ReadLine();

                if (Line != "")
                {
                    string[] separate = Strings.Split(Line.ToLower(), "|");

                    sMetier varJob = new sMetier();

                    {
                        var withBlock = varJob;
                        withBlock.ID = separate[0];
                        withBlock.Nom = separate[1];
                        withBlock.AtelierRessource = new Dictionary<int, sMetierAtelierRessource>();

                        for (var i = 2; i <= separate.Count() - 1; i++)
                        {
                            string[] separateJob = Strings.Split(separate[i], ":");

                            sMetierAtelierRessource newsMetierAtelierRessource = new sMetierAtelierRessource();

                            {
                                var withBlock1 = newsMetierAtelierRessource;
                                withBlock1.ID = separateJob[0];
                                withBlock1.Nom = separateJob[1];
                                withBlock1.Action = separateJob[2];
                            }

                            withBlock.AtelierRessource.Add(separateJob[0], newsMetierAtelierRessource);
                        }
                    }

                    VarMetier.Add(separate[0], varJob);
                }
            }

            swReading.Close();
        }
        catch (Exception ex)
        {
            ErreurFichier("Unknow", "LoadMetier", ex.Message);
        }
    }

    public static void ChargeFamilier()
    {

        // J'ouvre et je lis le fichier.
        System.IO.StreamReader swReading = new System.IO.StreamReader(Application.StartupPath + @"\Data/Familier.txt");

        while (!swReading.EndOfStream)
        {
            string line = swReading.ReadLine();

            if (line != "")
            {
                string[] separate = Strings.Split(line, "|");

                sFamilier varPet = new sFamilier();

                if (VarFamilier.ContainsKey(separate[0]))
                    varPet = VarFamilier(separate[0]);

                {
                    var withBlock = varPet;
                    withBlock.Nom = separate[1];

                    string[] separateData = Strings.Split(separate[3], ",");

                    if (VarFamilier.ContainsKey(separate[0]))
                        withBlock.Caracteristique = VarFamilier(separate[0]).Caracteristique;
                    else
                        withBlock.Caracteristique = new Dictionary<string, List<int>>();

                    for (var a = 0; a <= separateData.Count() - 1; a++)
                    {
                        if (withBlock.Caracteristique.ContainsKey(separate[2].ToLower()))
                            withBlock.Caracteristique(separate[2].ToLower()).Add(separateData[a]);
                        else
                            withBlock.Caracteristique.Add(separate[2].ToLower(), new List<int>() { separateData[a] });
                    }

                    separateData = Strings.Split(separate[4], ",");

                    withBlock.CapacitéNormal = separateData[0];
                    withBlock.CapacitéMax = separateData[1];

                    separateData = Strings.Split(separate[5], ",");

                    withBlock.IntervalRepasMin = separateData[0];
                    withBlock.IntervalRepasMax = separateData[1];
                }

                if (!VarFamilier.ContainsKey(separate[0]))
                    VarFamilier.Add(separate[0], varPet);
                else
                    VarFamilier(separate[0]) = varPet;
            }
        }

        swReading.Close();
    }
}
