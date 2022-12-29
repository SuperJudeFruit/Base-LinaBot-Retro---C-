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

namespace Dragodinde
{
    static class Dragodinde
    {
        public static void Ouvre(string data)
        {
            {
                var withBlock = Bot;
                try
                {
                    withBlock.Dragodinde.Enclos.Clear();
                    withBlock.Dragodinde.Etable.Clear();

                    // ECK16 etc...
                    string[] separateData = Strings.Split(data, "|");

                    separateData = Strings.Split(separateData[1], "~");

                    if (separateData[0] != "")
                        Information(separateData[0], "Etable");

                    if (separateData[1] != "")
                        Information(separateData[1], "Enclos");
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Dragodinde_Ouvre", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Information(string data, string choix)
        {
            {
                var withBlock = Bot;
                try
                {

                    // Re+ 1200859   : 46 : 10,3,10,15,22,10,10,15,46,23,18,3,22,10 :           ,            :     : 0    :  7587      , 7250   , 9250   : 7      : 1        : 185 : 0 : 2249      , 10000         : 2000     , 2000         : 206     , 1205        : -10000       , -10000    , 10000  : 2500  , 10000     : -1          : 0 : 7d#7#0#0 , 7c#1#0#0 : 0       , 240         : 5     , 20
                    // Re+ Id unique : Id : Arbre généalogique                      : Capacité1 , Capacité 2 : Nom : Sexe :  Xp actuel , Xp Min , Xp Max : Niveau : Montable : ?   : ? : Endurance , Endurance Max : Maturité , Maturité max : Energie , Energie max :  Agressivité , Equilibré , Serein : Amour , Amour max : Fécondation : ? : +7 vita  , +1 sag   : Fatigue , Fatigue max : Repro , Repro max

                    string[] sexe = new[] { "Male", "Femelle" };
                    string[] capacite = new[] { "Infatigable", "Porteuse", "Reproductrice", "Sage", "Endurante", "Amoureuse", "Precoce", "Predisposee Genetique", "Cameleone" };

                    string[] separateData = Strings.Split(data.Replace("Rd", "").Replace("Re+", "").Replace("Ee+", "").Replace("Ef+", "").Replace("Ee~", ""), ";");

                    for (var i = 0; i <= separateData.Length - 1; i++)
                    {
                        string[] separate = Strings.Split(separateData[i], ":");

                        Dragodinde_Variable.Information newDragodinde = new Dragodinde_Variable.Information();

                        {
                            var withBlock1 = newDragodinde;

                            // Id Unique
                            withBlock1.IdUnique = separate[0];

                            // ID
                            withBlock1.ID = separate[1];

                            // Type
                            if (VarDragodindeId.ContainsKey(separate[1]))
                                withBlock1.Type = VarDragodindeId(separate[1]);
                            else
                                withBlock1.Type = "Unknow";

                            // Arbre Généalogique
                            withBlock1.ArbreGenealogique = separate[2];

                            // Nom
                            withBlock1.Nom = separate[4] == null ? "SansNom" : separate[4];

                            // Sexe
                            withBlock1.Sexe = sexe[separate[5]];

                            // Niveau
                            withBlock1.Niveau = separate[7];

                            // Expérience
                            {
                                var withBlock2 = withBlock1.Experience;
                                withBlock2.Minimum = Strings.Split(separate[6], ",")(1);
                                withBlock2.Actuelle = Strings.Split(separate[6], ",")(0);
                                withBlock2.Maximum = Strings.Split(separate[6], ",")(2);
                                withBlock2.Pourcentage = withBlock2.Actuelle / (double)withBlock2.Maximum * 100;
                            }

                            // Montable
                            withBlock1.Montable = separate[8] != "0";

                            // Endurance
                            {
                                var withBlock2 = withBlock1.Endurance;
                                withBlock2.Actuelle = Strings.Split(separate[11], ",")(0);
                                withBlock2.Maximum = Strings.Split(separate[11], ",")(1);
                                withBlock2.Pourcentage = withBlock2.Actuelle / (double)withBlock2.Maximum * 100;
                            }

                            // Maturité
                            {
                                var withBlock2 = withBlock1.Maturite;
                                withBlock2.Actuelle = Strings.Split(separate[12], ",")(0);
                                withBlock2.Maximum = Strings.Split(separate[12], ",")(1);
                                withBlock2.Pourcentage = withBlock2.Actuelle / (double)withBlock2.Maximum * 100;
                            }

                            // Amour
                            {
                                var withBlock2 = withBlock1.Amour;
                                withBlock2.Actuelle = Strings.Split(separate[15], ",")(0);
                                withBlock2.Maximum = Strings.Split(separate[15], ",")(1);
                                withBlock2.Pourcentage = withBlock2.Actuelle / (double)withBlock2.Maximum * 100;
                            }

                            // Etat
                            {
                                var withBlock2 = withBlock1.Etat;
                                withBlock2.Agressiviter = Strings.Split(separate[14], ",")(0);
                                withBlock2.Equilibrer = Strings.Split(separate[14], ",")(1);
                                withBlock2.Sereniter = Strings.Split(separate[14], ",")(2);
                            }

                            // Energie
                            {
                                var withBlock2 = withBlock1.Energie;
                                withBlock2.Actuelle = Strings.Split(separate[13], ",")(0);
                                withBlock2.Maximum = Strings.Split(separate[13], ",")(1);
                                withBlock2.Pourcentage = withBlock2.Actuelle / (double)withBlock2.Maximum * 100;
                            }

                            // Fatigue
                            {
                                var withBlock2 = withBlock1.Fatigue;
                                withBlock2.Actuelle = Strings.Split(separate[19], ",")(0);
                                withBlock2.Maximum = Strings.Split(separate[19], ",")(1);
                                withBlock2.Pourcentage = withBlock2.Actuelle / (double)withBlock2.Maximum * 100;
                            }

                            // Capacité
                            {
                                var withBlock2 = withBlock1.Capacite;
                                withBlock2.Primaire = capacite[Strings.Split(separate[3], ",")(0)];
                                withBlock2.Secondaire = capacite[Strings.Split(separate[3], ",")(1)];
                            }

                            // Caractéristique
                            if (separate[18] != null)
                                withBlock1.Caracteristique = Item.Caracteristique(separate[18]);

                            // Fécondation
                            if (withBlock1.Endurance.Actuelle >= 7500 && withBlock1.Maturite.Actuelle == withBlock1.Maturite.Maximum && withBlock1.Amour.Actuelle >= 7500 && withBlock1.Niveau >= 5)
                                withBlock1.Fecondation.Fecondable = true;
                            else
                                withBlock1.Fecondation.Fecondable = false;

                            if (separate[16] != "-1")
                                withBlock1.Fecondation.Heure = separate[16];

                            // Reproduction
                            {
                                var withBlock2 = withBlock1.Reproduction;
                                withBlock2.Actuelle = Strings.Split(separate[20], ",")(0);
                                withBlock2.Maximum = Strings.Split(separate[20], ",")(1);
                                withBlock2.Pourcentage = withBlock2.Actuelle / (double)withBlock2.Maximum * 100;
                            }
                        }

                        {
                            var withBlock1 = withBlock.Dragodinde;
                            switch (choix.ToLower())
                            {
                                case "information":
                                    {
                                        withBlock1.Information = newDragodinde;
                                        break;
                                    }

                                case "equipe":
                                case "equiper":
                                    {
                                        withBlock1.Equiper = newDragodinde;
                                        break;
                                    }

                                case "enclos":
                                case "enclo":
                                    {
                                        if (withBlock1.Enclos.ContainsKey(separate[0]))
                                            withBlock1.Enclos(separate[0]) = newDragodinde;
                                        else
                                            withBlock1.Enclos.Add(separate[0], newDragodinde);
                                        break;
                                    }

                                case "etable":
                                    {
                                        if (withBlock1.Etable.ContainsKey(separate[0]))
                                            withBlock1.Etable(separate[0]) = newDragodinde;
                                        else
                                            withBlock1.Etable.Add(separate[0], newDragodinde);
                                        break;
                                    }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Dragodinde_Information", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Monter(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // Rr +
                    // Rr Monte ou descend

                    switch (Strings.Mid(data, 3))
                    {
                        case "+":
                            {
                                withBlock.Dragodinde.Monter = true;
                                EcritureMessage("[Dofus]", "Vous êtes monté sur votre monture.", Color.Green);
                                break;
                            }

                        case "-":
                            {
                                withBlock.Dragodinde.Monter = false;
                                EcritureMessage("[Dofus]", "Vous êtes déscendu de votre monture.", Color.Green);
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Dragodinde_Monter", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void XP(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // Rx 95
                    // Rx Xp donnée

                    withBlock.Dragodinde.Xp = Strings.Mid(data, 3);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Dragondinde_XP", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Nom(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // Rn Linaculer
                    // Rn Nom donnée

                    withBlock.Dragodinde.Equiper.Nom = Strings.Mid(data, 3);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Dragodinde_Nom", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Pods(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // Ew 0        ; 185
                    // Ew Actuelle ; Maximum

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), ";");

                    {
                        var withBlock1 = withBlock.Dragodinde.Equiper.Pods;
                        withBlock1.Actuelle = separateData[0];
                        withBlock1.Maximum = separateData[1];
                        withBlock1.Pourcentage = System.Convert.ToDouble(separateData[0]) / (double)System.Convert.ToDouble(separateData[1]) * 100;
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Dragodinde_Pods", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Etable_Supprime(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // Ee- 1714320
                    // Ee- id dragodinde

                    if (withBlock.Dragodinde.Etable.ContainsKey(Strings.Mid(data, 4)))
                        withBlock.Dragodinde.Etable.Remove(Strings.Mid(data, 4));
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Dragodinde_Etable_Supprime", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Enclos_Supprime(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // Ef- 1714320
                    // Ef- id dragodinde

                    if (withBlock.Dragodinde.Enclos.ContainsKey(Strings.Mid(data, 4)))
                        withBlock.Dragodinde.Enclos.Remove(Strings.Mid(data, 4));
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Dragodinde_Enclos_Supprime", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
