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

namespace Inventaire
{
    static class Inventaire
    {
        public static void Pods(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // Ow 750         | 3353
                    // Ow Pods actuel | Pods Max

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");

                    {
                        var withBlock1 = withBlock.Personnage.Pods;
                        withBlock1.Maximum = separateData[1];
                        withBlock1.Actuelle = separateData[0];
                        withBlock1.Pourcentage = (separateData[0] / (double)separateData[1]) * 100;
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Inventaire_Pods", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Information(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // ASK | 1234567   | Linaculer  | 99    | 9         | 0       | 90            | -1       | -1       | -1       | 262c1bc        ~ 241      ~ 1         ~ 1                 ~ 64#2#4#0#1d3+1  , 7d#1#0#0#0d0+1 ; Next Item
                    // ASK | ID Joueur | Nom Joueur | Level | Id Classe | Id Sexe | Classe + Sexe | Couleur1 | Couleur2 | Couleur3 | Id Unique Item ~ Id Objet ~ Quantity  ~ Number equipment  ~ Caractéristique , Caract Next    ; Item suivent

                    string[] separateData = Strings.Split(data, "|");

                    withBlock.Inventaire.Reset();

                    LinaBot.PictureBox_Interface_Personnage.Image = LinaBot.ImageList_Personnage.Images.Item(LinaBot.ImageList_Personnage.Images.IndexOfKey(separateData[6]));

                    Item.Ajoute(separateData[10], withBlock.Inventaire);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Inventaire_Information", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Supprimer(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // OR 55156977
                    // OR id Unique

                    withBlock.Inventaire.Supprimer = withBlock.Inventaire.Item(Strings.Mid(data, 3));
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Inventaire_Supprime", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Quantiter(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // OQ 55259212  | 699
                    // OQ Id Unique | Quantité

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");

                    Item_Variable.Information newItem = withBlock.Inventaire.Item(separateData[0]);

                    newItem.Quantiter = separateData[1];

                    withBlock.Inventaire.Modifie = newItem;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Inventaire_Quantiter", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Equipement(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // OM 123515576 | 7
                    // OM id unique | Numéro équipement

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");

                    Item_Variable.Information newItem = withBlock.Inventaire.Item(separateData[0]);

                    {
                        var withBlock1 = newItem;
                        if (separateData[1] != null)
                            withBlock1.Equipement = separateData[1];
                        else
                            withBlock1.Equipement = "";
                    }

                    withBlock.Inventaire.Modifie = newItem;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Inventaire_Equipement", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Caracteristique(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // OCO 4a239fd  ~ 1f40    ~ 1        ~ 8                 ~ 320#5#48#9,328#28a#1f5#466,326#0#0#48,327#0#0#18a,9e#2da#0#0#0d0+730 ; 
                    // OCO idUnique ~ IdObjet ~ Quantité ~ Numéro Equipement ~ Caractéristique                                                      ; Next item

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), ";");

                    for (var i = 0; i <= separateData.Length - 1; i++)
                    {
                        if (separateData[i] != "")
                        {
                            string[] separateItem = Strings.Split(separateData[i], "~");

                            string IdUnique = Convert.ToInt64(separateItem[0], 16);

                            Item_Variable.Information newItem = withBlock.Inventaire.Item(IdUnique);

                            {
                                var withBlock1 = newItem;
                                withBlock1.Quantiter = Convert.ToInt64(separateItem[2], 16);

                                withBlock1.Caracteristique = Item.Caracteristique(separateItem[4], Convert.ToInt64(separateItem[1], 16));
                                withBlock1.CaracteristiqueBrute = separateItem[4];

                                if (separateItem[3] != "")
                                    withBlock1.Equipement = Convert.ToInt64(separateItem[3], 16);
                                else if (VarItems(Convert.ToInt64(separateItem[1], 16)).Catégorie == "24")
                                    withBlock1.Equipement = "24";
                                else
                                    withBlock1.Equipement = "";
                            }

                            withBlock.Inventaire.Modifie = newItem;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Inventaire_Caracteristique", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
