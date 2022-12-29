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

namespace Maison
{
    static class Maison
    {
        public static void Porte_Verouiller(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // hX 999 | 0
                    // hX Id  | Vérouillé (oui ou non)

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");

                    if (withBlock.Maison.Map.ContainsKey(separateData[0]))
                        withBlock.Maison.Map(separateData[0]).Verouiller = separateData[1];
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Porte_Verouiller", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Coffre_Verouiller(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // sX 9999   _ 999     | 0
                    // sX Id map _ cellule | Vérouillé (oui ou non)

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");

                    int MapID = Strings.Split(separateData[0], "_")(0);
                    int CelluleID = Strings.Split(separateData[0], "_")(1);

                    if (withBlock.Maison.Map(MapID).Coffre.ContainsKey(MapID + "_" + CelluleID))
                        withBlock.Maison.Map(MapID).Coffre(MapID + "_" + CelluleID).Verouiller = separateData[1];
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Coffre_Verouiller", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void MaMaison(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // hL + 999       ; 1          ; 0        ; 0
                    // hL + Id Maison ; Verouiller ; En Vente ; En Guilde

                    string[] separate = Strings.Split(Strings.Mid(data, 4), ";");

                    {
                        var withBlock1 = withBlock.Maison.Personnelle;
                        withBlock1.ID = separate[0];
                        withBlock1.Verouiller = separate[1];
                        withBlock1.Vente = separate[2];
                        withBlock1.Guilde = separate[3];
                        withBlock1.Cellule = VarMaison(withBlock1.ID).CellulePorte;
                        withBlock1.MapID = VarMaison(withBlock1.ID).MapId;
                        withBlock1.Coordonnees = VarMaison(withBlock1.ID).Map;
                        withBlock1.Prix = 0;
                        withBlock1.Code = 0;
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Maison", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Supprime(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // hL -
                    // hL -

                    withBlock.Maison.Personnelle = new Maison_Variable.Maison();

                    EcritureMessage("[Dofus]", "Vous n'avez plus de maison.", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Supprime", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Vendu(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // M15 | 1000 ; slider 
                    // M15 | Prix ; Pseudo 

                    string[] separateData = Strings.Split(data, "|");
                    separateData = Strings.Split(separateData[1], ";");

                    EcritureMessage("[Dofus]", "L'une de vos maisons vient d'être achetée " + separateData[0] + " kamas par " + separateData[1] + ". La somme a été placée sur votre compte en banque.", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Vendu", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Coffres(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // sL + 9999   _ 114     ; 1          | Next
                    // sL + Id Map _ Cellule ; Verouiller | Next

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    for (var i = 0; i <= separateData.Length - 1; i++)
                    {
                        string[] separate = Strings.Split(separateData[i], ";");

                        bool Verouiller = separate[1];
                        int MapID = Strings.Split(separate[0], "_")(0);
                        int CelluleID = Strings.Split(separate[0], "_")(1);

                        Maison_Variable.Coffre varCoffre = new Maison_Variable.Coffre();

                        {
                            var withBlock1 = varCoffre;
                            withBlock1.Coordonnees = VarMap(MapID);
                            withBlock1.MapID = MapID;
                            withBlock1.Cellule = CelluleID;
                            withBlock1.Verouiller = Verouiller;
                            withBlock1.Code = -1;
                        }

                        if (withBlock.Maison.Personnelle.Coffre.ContainsKey(MapID + "_" + CelluleID))
                            withBlock.Maison.Personnelle.Coffre(MapID + "_" + CelluleID) = varCoffre;
                        else
                            withBlock.Maison.Personnelle.Coffre.Add(MapID + "_" + CelluleID, varCoffre);
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Coffres", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Map(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // hP 444 | Linacu ; 0            ; Lenculeur lourd ; a     , 0    ,i     ,9drge
                    // hP Id  | Pseudo ; pas en vente ; Nom guilde      ; blason,blason,blason,blason

                    data = Strings.Mid(data, 3);

                    string[] separateData = Strings.Split(data, "|");

                    int id = separateData[0];

                    separateData = Strings.Split(separateData[1], ";");

                    if (!VarMaison.ContainsKey(id))
                        MaisonAjouteInformation(id);

                    Maison_Variable.Maison newMaison = new Maison_Variable.Maison();

                    {
                        var withBlock1 = newMaison;
                        withBlock1.ID = id;
                        withBlock1.Verouiller = false;
                        withBlock1.Vente = separateData[1];
                        withBlock1.Guilde = false;
                        withBlock1.Proprietaire = separateData[0];
                        withBlock1.Cellule = VarMaison(id).CellulePorte;
                        withBlock1.MapID = Bot.Map.ID;
                        withBlock1.Coordonnees = Bot.Map.Coordonnees;
                        withBlock1.Prix = -1;
                        withBlock1.Code = -1;

                        if (separateData.Length > 2)
                            withBlock1.Nom_Guilde = separateData[2];
                    }

                    if (withBlock.Maison.Map.ContainsKey(id))
                        withBlock.Maison.Map(id) = newMaison;
                    else
                        withBlock.Maison.Map.Add(id, newMaison);

                    if (VarMaison(id).Map == "[X,Y]" || VarMaison(id).MapId == "0")
                        MaisonChangeInformation(id);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_mdlMaison_GiMaisonMap", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        private static void MaisonChangeInformation(string id)
        {
            {
                var withBlock = Bot;
                try
                {


                    // Mise à jour de la version automatiquement (celui du fichier)
                    System.IO.StreamReader swLecture = new System.IO.StreamReader(Application.StartupPath + @"\Data/Maison.txt");

                    string ligneFinal = "";

                    while (!swLecture.EndOfStream)
                    {
                        string Ligne = swLecture.ReadLine();

                        if (Ligne != "")
                        {
                            string[] separate = Strings.Split(Ligne, " | ");

                            if (separate[0] == "hP : " + id)
                                ligneFinal += "hP : " + id + " | Porte : " + VarMaison(id).CellulePorte + " | Map : " + withBlock.Map.Coordonnees + " | Mapid : " + withBlock.Map.ID + " | Nom : " + VarMaison(id).Nom + Constants.vbCrLf;
                            else
                                ligneFinal += Ligne + Constants.vbCrLf;
                        }
                    }

                    // Puis je ferme le fichier.
                    swLecture.Close();

                    // J'ouvre le fichier pour y écrire se que je souhaite
                    System.IO.StreamWriter Sw_Ecriture = new System.IO.StreamWriter(Application.StartupPath + @"\Data/Maison.txt");

                    // J'écris dedans avant de le fermer.
                    Sw_Ecriture.Write(ligneFinal);

                    // Puis je le ferme.
                    Sw_Ecriture.Close();

                    ChargeMaison();
                }

                catch (Exception ex)
                {
                }
            }
        }

        private static void MaisonAjouteInformation(string id)
        {
            {
                var withBlock = Bot;
                try
                {

                    // Mise à jour de la version automatiquement (celui du fichier)
                    System.IO.StreamReader swLecture = new System.IO.StreamReader(Application.StartupPath + @"\Data/Maison.txt");

                    string ligneFinal = "";

                    while (!swLecture.EndOfStream)
                    {
                        string ligne = swLecture.ReadLine();

                        if (ligne != "")
                            ligneFinal += ligne + Constants.vbCrLf;
                    }

                    // Puis je ferme le fichier.
                    swLecture.Close();

                    ligneFinal += "hP : " + id + " | Porte : 0 | Map : " + withBlock.Map.Coordonnees + " | Mapid : " + withBlock.Map.ID + " | Nom : Maison";

                    // J'ouvre le fichier pour y écrire se que je souhaite
                    System.IO.StreamWriter Sw_Ecriture = new System.IO.StreamWriter(Application.StartupPath + @"\Data/Maison.txt");

                    // J'écris dedans avant de le fermer.
                    Sw_Ecriture.Write(ligneFinal);

                    // Puis je le ferme.
                    Sw_Ecriture.Close();

                    ChargeMaison();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public static void Quitte_Achat(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // hV

                    withBlock.Personnage.EnInteraction = false;

                    EcritureMessage("[Dofus]", "Le bot n'est plus en achat de maison.", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Quitte_Achat", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Prix(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // hCK 607 | 8999999
                    // hCK Id  | Prix

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    if (withBlock.Maison.Map.ContainsKey(separateData[0]))
                        withBlock.Maison.Map(separateData[0]).Prix = separateData[1];
                }

                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Prix", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Achete(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // hBK 999 | 10000000 
                    // hBK ID  | Prix 

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    EcritureMessage("[Dofus]", "Tu viens d'acheter 'Maison' pour " + separateData[1] + " kamas.", Color.Green);
                }

                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Achete", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Mis_En_Vente(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // hSK 999 |10000000 
                    // hSK ID  | Prix 

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    EcritureMessage("[Dofus]", "'Maison' est mise en vente au prix de " + separateData[1] + " kamas.", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Mis_En_Vente", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Ouverture(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // KCK 1 | 8 
                    // KCK 1 | lenombre de chiffre maximum  

                    withBlock.Maison.Ouverture = true;

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    switch (separateData[0])
                    {
                        case "0":
                            {
                                EcritureMessage("[Dofus]", "Veuillez saisir le code.", Color.Green);
                                break;
                            }

                        case "1":
                            {
                                EcritureMessage("[Dofus]", "Veuillez saisir le nouveau code (maximum de " + separateData[1] + " chiffres).", Color.Green);
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Code", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Code_Modifie(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // KKK

                    EcritureMessage("[Dofus]", "Code changé", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Code_Modifie", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Guilde(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // hG 999
                    // hG ID

                    EcritureMessage("[Dofus]", "Vous pouvez changer les droits de la maison de guilde.", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_mdlMaison_GiMaisonGuilde", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Code_Echec(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // KKE

                    EcritureMessage("[Dofus]", "Code erroné", Color.Red);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Code_Echec", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Fermeture(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // KV

                    withBlock.Maison.Ouverture = false;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Fermeture", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
