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

namespace Item
{
    static class Item
    {
        public static void Ajoute(string data, Item_Variable.Base choix)
        {
            {
                var withBlock = Bot;
                try
                {

                    // 262c1bc   ~ 241      ~ 5        ~ 1                 ~ 64#2#4#0#1d3+1  ,
                    // Id unique ~ Id Objet ~ Quantité ~ Numéro Equipement ~ Caractéristique , etc... ; tchatItem Suivant

                    if (data != "")
                    {
                        string[] separateData = Strings.Split(data, ";");

                        for (var i = 0; i <= separateData.Length - 2; i++)
                        {
                            string[] separateItem = Strings.Split(separateData[i], "~");

                            Item_Variable.Information newItem = new Item_Variable.Information();

                            try
                            {
                                {
                                    var withBlock1 = newItem;
                                    withBlock1.IdObjet = Convert.ToInt64(separateItem[1], 16);

                                    withBlock1.IdUnique = Convert.ToInt64(separateItem[0], 16);

                                    withBlock1.Nom = VarItems(Convert.ToInt64(separateItem[1], 16)).Nom;

                                    withBlock1.Quantiter = Convert.ToInt64(separateItem[2], 16);

                                    withBlock1.Caracteristique = Caracteristique(separateItem[4], Convert.ToInt64(separateItem[1], 16));

                                    withBlock1.CaracteristiqueBrute = separateItem[4];

                                    withBlock1.Categorie = VarItems(withBlock1.IdObjet).Catégorie;

                                    if (separateItem[3] != "")
                                        withBlock1.Equipement = Convert.ToInt64(separateItem[3], 16);
                                    else if (VarItems(Convert.ToInt64(separateItem[1], 16)).Catégorie == "24")
                                        withBlock1.Equipement = "Quete";
                                    else
                                        withBlock1.Equipement = "";
                                }
                            }
                            catch (Exception ex)
                            {
                                ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Item_Ajoute_NewItem", data + Constants.vbCrLf + ex.Message);
                            }

                            choix.Ajoute = newItem;
                        }

                        if (separateData[separateData.Length - 1].Contains('G'))
                            withBlock.Echange.Moi.Kamas = Strings.Mid(separateData[separateData.Length - 1], 2, separateData[separateData.Length - 1].Length);
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Item_Ajoute", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Bonus_Ajoute(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // OS+ 5               | 2476     ; 2478    | 76#a#0#0,7d#a#0#0,77#a#0#0,7b#a#0#0,7c#a#0#0,7e#a#0#0
                    // OS+ Numéro_Panoplie | ID_Objet ; ID_Objet| Caractéristique

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    Item_Variable.Bonus newBonus = new Item_Variable.Bonus();

                    {
                        var withBlock1 = newBonus;
                        withBlock1.NumeroPanoplie = separateData[0];
                        withBlock1.IDObjet = Strings.Split(separateData[1], ";");
                        withBlock1.Caracteristique = Caracteristique(separateData[2]);
                        withBlock1.CaracteristiqueBrute = separateData[2];
                    }

                    if (withBlock.BonusEquipement.ContainsKey(separateData[0]))
                        withBlock.BonusEquipement(separateData[0]) = newBonus;
                    else
                        withBlock.BonusEquipement.Add(separateData[0], newBonus);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Item_Ajoute", data + Constants.vbCrLf + ex.Message);
                }
            }
        }



        public static void Bonus_Supprime(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // OS- 5               
                    // OS- Numéro_Panoplie 

                    if (withBlock.BonusEquipement.ContainsKey(Strings.Mid(data, 4)))
                        withBlock.BonusEquipement.Remove(Strings.Mid(data, 4));
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Item_Supprimer", data + Constants.vbCrLf + ex.Message);
                }
            }
        }



        public static void Joueur(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // Oa 1234567   | 553 , 2412~16~1 , 2411~17~1 ,          , 2509
                    // Oa ID Unique | Cac , Coiffe    , Cape      , Familier , Bouclier

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), "|"); // 1234567 | 553,2412~16~1,2411~17~1,,2509

                    string idUnique = separateData[0]; // 1234567

                    separateData = Strings.Split(separateData[1], ","); // 553,2412~16~1,2411~17~1,,2509

                    if (withBlock.Map.Entite.ContainsKey(idUnique))
                    {
                        {
                            var withBlock1 = withBlock.Map.Entite(idUnique).Equipement;
                            if (separateData[0] != null)
                                withBlock1.Cac = Convert.ToInt64(separateData[0], 16);

                            if (separateData[1] != null)
                            {
                                string[] separateObvijevan = Strings.Split(separateData[1], "~");

                                withBlock1.Chapeau.ID = Convert.ToInt64(separateObvijevan[0], 16);

                                if (separateData[1].Contains('~'))
                                {
                                    withBlock1.Chapeau.Niveau = Convert.ToInt64(separateObvijevan[1], 16);
                                    withBlock1.Chapeau.Forme = Convert.ToInt64(separateObvijevan[2], 16);
                                }
                            }
                            else
                                withBlock1.Chapeau = new Map_Variable.Information();

                            if (separateData[2] != null)
                            {
                                string[] separateObvijevan = Strings.Split(separateData[2], "~");

                                withBlock1.Cape.ID = Convert.ToInt64(separateObvijevan[0], 16);

                                if (separateData[2].Contains('~'))
                                {
                                    withBlock1.Cape.Niveau = Convert.ToInt64(separateObvijevan[1], 16);
                                    withBlock1.Cape.Forme = Convert.ToInt64(separateObvijevan[2], 16);
                                }
                            }
                            else
                                withBlock1.Cape = new Map_Variable.Information();

                            if (separateData[3] != null)
                                withBlock1.Familier = Convert.ToInt64(separateData[3], 16);

                            if (separateData[4] != null)
                                withBlock1.Bouclier = Convert.ToInt64(separateData[4], 16);
                        }

                        if (idUnique == withBlock.Personnage.ID)
                            withBlock.Personnage.Equipement = withBlock.Map.Entite(idUnique).Equipement;
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Item_Joueur", data + Constants.vbCrLf + ex.Message);
                }
            }
        }



        public static Item_Variable.Caracteristique Caracteristique(string _caracteristique, int id = 0)
        {
            Item_Variable.Caracteristique resultat = new Item_Variable.Caracteristique();

            try
            {

                // 76 # a      # 0      # 0      # 0d0+1  , next
                // 7b # 1      # 0      # 0      # 0d0+1  , next
                // ID # Divers # Divers # Divers # Aléatoire (exemple CAC) , Caractéristique suivante

                // 1d3+5 = Un chiffre alétoire entre 1 à 3, puis rajoute à ça +5

                if (_caracteristique != "")
                {
                    string[] separateCaracteristique = Strings.Split(_caracteristique, ","); // 76#a#0#0,7b#1#0#0#0d0+1

                    try
                    {
                        {
                            var withBlock = resultat;
                            for (var i = 0; i <= separateCaracteristique.Length - 1; i++) // 76#a#0#0
                            {
                                if (separateCaracteristique[i] != "")
                                {
                                    string[] separate = Strings.Split(separateCaracteristique[i], "#");

                                    int choixCaractéristique = separate[0] != "-1" ? Convert.ToInt64(separate[0], 16) : separate[0]; // 76
                                    // 15
                                    // 3
                                    int valeur1 = Convert.ToInt64(separate[1], 16);
                                    int valeur2;
                                    int valeur3 = separate[3] != "" ? Convert.ToInt64(separate[3], 16) : 0;

                                    switch (choixCaractéristique)
                                    {
                                        case -1:
                                            {
                                                break;
                                            }

                                        case 93:
                                            {
                                                withBlock.Vole.Air = valeur1 + " a " + Convert.ToInt64(separate[2], 16);
                                                break;
                                            }

                                        case 96:
                                            {
                                                withBlock.Dommage.Eau = valeur1 + " a " + Convert.ToInt64(separate[2], 16);
                                                break;
                                            }

                                        case 97:
                                            {
                                                withBlock.Dommage.Terre = valeur1 + " a " + Convert.ToInt64(separate[2], 16);
                                                break;
                                            }

                                        case 98 // Dégât air
                                 :
                                            {
                                                withBlock.Dommage.Air = valeur1 + " a " + Convert.ToInt64(separate[2], 16);
                                                break;
                                            }

                                        case 99:
                                            {
                                                withBlock.Dommage.Feu = valeur1 + " a " + Convert.ToInt64(separate[2], 16);
                                                break;
                                            }

                                        case 100 // 64 = Dommage neutre ?
                                 :
                                            {
                                                withBlock.Dommage.Neutre = valeur1 + " a " + Convert.ToInt64(separate[2], 16);
                                                break;
                                            }

                                        case 101 // 65 = PA -
                                 :
                                            {
                                                withBlock.PertePA = -valeur1;
                                                break;
                                            }

                                        case 110:
                                            {
                                                withBlock.Pdv = valeur1;
                                                break;
                                            }

                                        case 118 // 76 = Force +
                                 :
                                            {
                                                withBlock.Force = valeur1;
                                                break;
                                            }

                                        case 157 // 9d = Force -
                                 :
                                            {
                                                withBlock.Force = valeur1;
                                                break;
                                            }

                                        case 125 // 7d = Vitalité +
                                 :
                                            {
                                                withBlock.Vitalite = valeur1;
                                                break;
                                            }

                                        case 153 // 99 = Vitalité -
                                 :
                                            {
                                                withBlock.Vitalite = valeur1;
                                                break;
                                            }

                                        case 124 // 7c = Sagesse +
                                 :
                                            {
                                                withBlock.Sagesse = valeur1;
                                                break;
                                            }

                                        case 156 // 9c = Sagesse -
                                 :
                                            {
                                                withBlock.Sagesse = valeur1;
                                                break;
                                            }

                                        case 126 // 7e = Intelligence +
                                 :
                                            {
                                                withBlock.Intelligence = valeur1;
                                                break;
                                            }

                                        case 155 // 9b = Intelligence -
                                 :
                                            {
                                                withBlock.Intelligence = valeur1;
                                                break;
                                            }

                                        case 123 // 7b = Chance +
                                 :
                                            {
                                                withBlock.Chance = valeur1;
                                                break;
                                            }

                                        case 152 // 98 = Chance -
                                 :
                                            {
                                                withBlock.Chance = valeur1;
                                                break;
                                            }

                                        case 119 // 77 = Agilité +
                                 :
                                            {
                                                withBlock.Agilite = valeur1;
                                                break;
                                            }

                                        case 154 // 9a = Agilité -
                                 :
                                            {
                                                withBlock.Agilite = valeur1;
                                                break;
                                            }

                                        case 111 // 6f = PA +
                                 :
                                            {
                                                withBlock.PA = valeur1;
                                                break;
                                            }

                                        case 128 // 80 = PM +
                                 :
                                            {
                                                withBlock.PM = valeur1;
                                                break;
                                            }

                                        case 127 // 7f = PM -
                                 :
                                            {
                                                withBlock.PM = valeur1;
                                                break;
                                            }

                                        case 117 // 75 = PO +
                                 :
                                            {
                                                withBlock.PO = valeur1;
                                                break;
                                            }

                                        case 116 // 74 = PO -
                                 :
                                            {
                                                withBlock.PO = valeur1;
                                                break;
                                            }

                                        case 182 // b6 = Invocation +
                                 :
                                            {
                                                withBlock.Invocation = valeur1;
                                                break;
                                            }

                                        case 174 // ae = Initiative +
                                 :
                                            {
                                                withBlock.Initiative = valeur1;
                                                break;
                                            }

                                        case 175 // af = Initiative -
                                 :
                                            {
                                                withBlock.Initiative = valeur1;
                                                break;
                                            }

                                        case 176 // b0 = Prospection +
                                 :
                                            {
                                                withBlock.Prospection = valeur1;
                                                break;
                                            }

                                        case 177 // b1 = Prospection -
                                 :
                                            {
                                                withBlock.Prospection = valeur1;
                                                break;
                                            }

                                        case 158 // 9e = Pods +
                                 :
                                            {
                                                withBlock.Pods = valeur1;
                                                break;
                                            }

                                        case 115 // 73 = Coups Critiques +   
                                 :
                                            {
                                                withBlock.CC = valeur1;
                                                break;
                                            }

                                        case 112 // 70 = Dommage +
                                 :
                                            {
                                                withBlock.Dommage.Physique.Fixe = valeur1;
                                                break;
                                            }

                                        case 138 // 8a = %Dommage +
                                 :
                                            {
                                                withBlock.Dommage.Physique.Pourcentage = valeur1;
                                                break;
                                            }

                                        case 225 // e1 = Dommage Piège +
                                 :
                                            {
                                                withBlock.Piege.Fixe = valeur1;
                                                break;
                                            }

                                        case 226 // e2 = %Dommage Piège +
                                 :
                                            {
                                                withBlock.Piege.Pourcentage = valeur1;
                                                break;
                                            }

                                        case 178 // b2 = Soin +
                                 :
                                            {
                                                withBlock.Soin = valeur1;
                                                break;
                                            }

                                        case 110 // 6e = Régénération +
                                 :
                                            {
                                                break;
                                            }

                                        case 193:
                                            {
                                                break;
                                            }

                                        case 240 // f0 = Résistance Terre +
                               :
                                            {
                                                withBlock.Resistance.Terre.Fixe = valeur1;
                                                break;
                                            }

                                        case 241 // f1 = Résistance Eau +
                                 :
                                            {
                                                withBlock.Resistance.Eau.Fixe = valeur1;
                                                break;
                                            }

                                        case 242 // f2 = Résistance Air +
                                 :
                                            {
                                                withBlock.Resistance.Air.Fixe = valeur1;
                                                break;
                                            }

                                        case 243 // f3 = Résistance Feu +
                                 :
                                            {
                                                withBlock.Resistance.Feu.Fixe = valeur1;
                                                break;
                                            }

                                        case 244 // f4 = Résistance Neutre +
                                 :
                                            {
                                                withBlock.Resistance.Neutre.Fixe = valeur1;
                                                break;
                                            }

                                        case 210 // d2 = %Résistance Terre +
                                 :
                                            {
                                                withBlock.Resistance.Terre.Pourcentage = valeur1;
                                                break;
                                            }

                                        case 215 // d7 = %Résistance Terre -
                                 :
                                            {
                                                withBlock.Resistance.Terre.Pourcentage = valeur1;
                                                break;
                                            }

                                        case 211 // d3 = %Résistance Eau +
                                 :
                                            {
                                                withBlock.Resistance.Eau.Pourcentage = valeur1;
                                                break;
                                            }

                                        case 216 // d8 = %Résistance Eau -
                                 :
                                            {
                                                withBlock.Resistance.Eau.Pourcentage = valeur1;
                                                break;
                                            }

                                        case 212 // d4 = %Résistance Air  +
                                 :
                                            {
                                                withBlock.Resistance.Air.Pourcentage = valeur1;
                                                break;
                                            }

                                        case 217 // d9 = %Résistance Air  -
                                 :
                                            {
                                                withBlock.Resistance.Air.Pourcentage = valeur1;
                                                break;
                                            }

                                        case 213 // d5 = %Résistance Feu +
                                 :
                                            {
                                                withBlock.Resistance.Feu.Pourcentage = valeur1;
                                                break;
                                            }

                                        case 218 // da = %Résistance Feu -
                                 :
                                            {
                                                withBlock.Resistance.Feu.Pourcentage = valeur1;
                                                break;
                                            }

                                        case 214 // d6 = %Résistance Neutre +
                                 :
                                            {
                                                withBlock.Resistance.Neutre.Pourcentage = valeur1;
                                                break;
                                            }

                                        case 219 // db = %Résistance Neutre -
                                 :
                                            {
                                                withBlock.Resistance.Neutre.Pourcentage = valeur1;
                                                break;
                                            }

                                        case 100 // 64 = Corps à Corps +
                                 :
                                            {
                                                withBlock.Cac = separate[4];
                                                break;
                                            }

                                        case 101 // 65 = PA perdus à la cible : X à Y
                                 :
                                            {
                                                break;
                                            }

                                        case 108 // 6c = PDV rendus : X à Y
                               :
                                            {
                                                break;
                                            }

                                        case 600:
                                            {
                                                break;
                                            }

                                        case 601 // 259
                               :
                                            {

                                                // resultat &= "Potion de cite : "

                                                if (separate[2] != null)
                                                {
                                                    switch (Convert.ToInt64(separate[2], 16))
                                                    {
                                                        case 6167:
                                                            {
                                                                break;
                                                            }

                                                        case 6159:
                                                            {
                                                                break;
                                                            }

                                                        default:
                                                            {
                                                                ErreurFichier("Unknow", "Item_Caracteristique", "Caracteristique Inconnu" + Constants.vbCrLf + _caracteristique + Constants.vbCrLf + separateCaracteristique[i]);
                                                                break;
                                                            }
                                                    }
                                                }

                                                break;
                                            }

                                        case 605 // 25d
                                 :
                                            {
                                                break;
                                            }

                                        case 614:
                                            {
                                                break;
                                            }

                                        case 622:
                                            {
                                                break;
                                            }

                                        case 623 // 26f = Pierre d'âme 
                               :
                                            {

                                                // 26f#0#0#93,26f#0#0#94,26f#0#0#94,26f#0#0#94,26f#0#0#65,26f#0#0#65,26f#0#0#65,26f#0#0#65;
                                                if (IsNothing(withBlock.PierreAme))
                                                    withBlock.PierreAme = new List<string>();

                                                withBlock.PierreAme.Add(valeur3);
                                                break;
                                            }

                                        case 699:
                                            {
                                                break;
                                            }

                                        case 701:
                                            {
                                                withBlock.Puissance = valeur1;
                                                break;
                                            }

                                        case 795:
                                            {
                                                break;
                                            }

                                        case 800 // 320 = Point de vie +
                               :
                                            {

                                                // 320 #5      #48     #7
                                                withBlock.Familier.Pdv = valeur3;
                                                break;
                                            }

                                        case 806 // 326 = 'Repas et Corpulence 
                                 :
                                            {

                                                // 326#1#0#1ab

                                                {
                                                    var withBlock1 = withBlock.Familier;
                                                    valeur2 = Convert.ToInt64(separate[2], 16);

                                                    if (valeur3 >= 7)
                                                    {
                                                        valeur3 = valeur3 > 100 ? 100 : valeur3;

                                                        withBlock1.Repas = -valeur3;
                                                        withBlock1.Corpulence = "Maigrichon";
                                                    }
                                                    else if (valeur2 >= 7)
                                                    {
                                                        withBlock1.Repas = valeur3;
                                                        withBlock1.Corpulence = "Obese";
                                                    }
                                                    else
                                                    {
                                                        withBlock1.Repas = "0";
                                                        withBlock1.Corpulence = "Normal";
                                                    }
                                                }

                                                break;
                                            }

                                        case 807 // 327 = Dernier Repas (objet utilisé)
                                 :
                                            {

                                                // 327#0#0#734

                                                {
                                                    var withBlock1 = withBlock.Familier;
                                                    switch (valeur3)
                                                    {
                                                        case 2114:
                                                            {
                                                                withBlock1.Repas_Dernier = "Aliment inconnu";
                                                                break;
                                                            }

                                                        case "0":
                                                            {
                                                                withBlock1.Repas_Dernier = "Aucun";
                                                                break;
                                                            }

                                                        default:
                                                            {
                                                                withBlock1.Repas_Dernier = VarItems(valeur3).Nom;
                                                                break;
                                                            }
                                                    }
                                                }

                                                break;
                                            }

                                        case 808 // "328" 'Date / Heure  
                                 :
                                            {

                                                // 328 # 28a   # cc          # 398   = A mangé le : 04/03/650 9:20
                                                // 328 # Année # Mois + Jour # Heure

                                                if (VarItems(id).Catégorie != 90)
                                                {
                                                    valeur2 = Convert.ToInt64(separate[2], 16);

                                                    int Année = valeur1 + 1370;

                                                    int Mois = valeur2 < 100 ? 1 : Strings.Mid(valeur2, 1, valeur2.ToString().Length - 2) + 1;
                                                    int Jour = valeur2 < 100 ? valeur2 : Strings.Mid(valeur2, valeur2.ToString().Length - 1, 2);

                                                    string Heure = valeur3.ToString().Insert(valeur3.ToString().Length - 2, ":");
                                                    if (Heure.Length == 3)
                                                        Heure = "00" + Heure;

                                                    DateTime dateFinal = (DateTime)Jour + "/" + Mois + "/" + Année + " " + Heure;

                                                    withBlock.Familier.Repas_Date = dateFinal;
                                                    withBlock.Familier.Repas_Prochain = dateFinal.AddHours(VarFamilier(id).IntervalRepasMin);
                                                }

                                                break;
                                            }

                                        case 811 // Malédiction/booste bonbon etc....
                                 :
                                            {
                                                switch (valeur1)
                                                {
                                                    case 15 // Malédiction du ballotin
                                                   :
                                                        {
                                                            withBlock.TourRestant = valeur3;
                                                            break;
                                                        }
                                                }

                                                break;
                                            }

                                        case 812:
                                            {
                                                withBlock.ResistanceItem = valeur1 + "/" + valeur3;

                                                switch (VarItems(id).Catégorie)
                                                {
                                                    case 5:
                                                    case 19:
                                                    case 8:
                                                    case 22:
                                                    case 7:
                                                    case 3:
                                                    case 4:
                                                    case 6:
                                                    case 20:
                                                    case 21:
                                                    case 83:
                                                        {
                                                            withBlock.Etheree = true;
                                                            break;
                                                        }

                                                    default:
                                                        {
                                                            withBlock.Etheree = false;
                                                            break;
                                                        }
                                                }

                                                break;
                                            }

                                        case 830:
                                            {

                                                // resultat &= "Potion de : "

                                                switch (valeur3)
                                                {
                                                    case 1:
                                                        {
                                                            break;
                                                        }

                                                    case 2:
                                                        {
                                                            break;
                                                        }
                                                }

                                                break;
                                            }

                                        case 850 // ?
                                 :
                                            {
                                                break;
                                            }

                                        case 851 // ? Vole or 1d5+5 d'or ?
                               :
                                            {
                                                break;
                                            }

                                        case 940 // "3ac" 'Capacité accrue Familier
                               :
                                            {

                                                // 3ac#0#0#a
                                                // a = 10, donc le familier peut avoir +10 en caract, etc... selon le familier.
                                                withBlock.Familier.Capacite_Accrue = true;
                                                break;
                                            }

                                        case 948:
                                            {
                                                break;
                                            }

                                        case 970:
                                            {
                                                break;
                                            }

                                        case 971:
                                            {
                                                break;
                                            }

                                        case 972:
                                            {
                                                break;
                                            }

                                        case 973:
                                            {
                                                break;
                                            }

                                        case 974:
                                            {
                                                break;
                                            }

                                        case 985:
                                            {
                                                break;
                                            }

                                        case 988:
                                            {
                                                break;
                                            }

                                        case 994 // 3e2
                               :
                                            {
                                                withBlock.Dragodinde.Date = DateTime.TimeOfDay;
                                                break;
                                            }

                                        case 995 // 3e3 = ID de la dragodinde pour avoir les caractéristiques (quand elle se trouve dans l'inventaire)
                                 :
                                            {
                                                // 3e3#c0a#1710bbb0c60#0

                                                withBlock.Dragodinde.IdUnique = "Rd" + valeur1 + Constants.vbCrLf + "|" + separate[2];
                                                break;
                                            }

                                        case 996 // 3e4 = Nom du joueur qui posséde la dragodinde.
                                 :
                                            {
                                                // 3e4#0#0#0#Linaculer

                                                withBlock.Dragodinde.Possesseur = separate[4];
                                                break;
                                            }

                                        case 997 // 3e5 = Nom de la dragodinde
                                 :
                                            {
                                                // 3e5#15#0#0#Linaculeur

                                                withBlock.Dragodinde.Nom = separate[4];
                                                break;
                                            }

                                        case 998 // "3e6" ' Jour/ heure / minute restant.
                                 :
                                            {
                                                // 3e6#13#17#3b

                                                withBlock.Dragodinde.Parchemin = DateTime.DateAdd(DateInterval.Day, valeur1, DateTime.Today).ToString() + " " + Convert.ToInt64(separate[2], 16) + ":" + valeur3;
                                                break;
                                            }

                                        case 805 // "325" 'Divers
                                 :
                                            {
                                                break;
                                            }

                                        default:
                                            {
                                                ErreurFichier("Unknow", "Item_Caracteristique", _caracteristique + Constants.vbCrLf + separateCaracteristique[i]);
                                                break;
                                            }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                ErreurFichier("Unknow", "Item_Caracteristique", _caracteristique + Constants.vbCrLf + ex.Message);
            }

            return resultat;
        }
    }
}
