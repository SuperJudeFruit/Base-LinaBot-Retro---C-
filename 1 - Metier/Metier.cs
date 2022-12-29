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

namespace Metier
{
    static class Metier
    {
        public static void Equipement(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // OT 28
                    // OT Id Métier

                    if (data.Length > 2)
                    {
                        if (withBlock.Metier.ContainsKey(Strings.Mid(data, 3)))
                            withBlock.Metier(Strings.Mid(data, 3)).ItemEquipe = true;
                    }
                    else
                        foreach (Metier_Variable.Base pair in withBlock.Metier.Values)

                            pair.ItemEquipe = false;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Metier_Equipement", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Mode_Public(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // EW + OU -

                    foreach (Metier_Variable.Base Pair in withBlock.Metier.Values)
                    {
                        {
                            var withBlock1 = Pair;
                            switch (Strings.Mid(data, 3))
                            {
                                case "+":
                                    {
                                        withBlock1.ModePublic = true;
                                        break;
                                    }

                                case "-":
                                    {
                                        withBlock1.ModePublic = false;
                                        break;
                                    }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Metier_Mode_Public", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Information(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // JS | 17        ; 142                   ~ 2                    ~ 0                    ~ 0 ~ 70                  , next info métier actuel | Nex métier
                    // JS | ID_Métier ; ID_Atelier/ressources ~ Nbr_Case/Récolte min ~ Nbr_Case/Récolte max ~ ? ~ %_Réussite ou temps ,                         |

                    string[] separateData = Strings.Split(data, "|");

                    for (var i = 1; i <= separateData.Length - 1; i++)
                    {
                        string[] separate = Strings.Split(separateData[i], ";");

                        int idJob = separate[0];

                        separate = Strings.Split(separate[1], ",");

                        Metier_Variable.Base newMetier = new Metier_Variable.Base();

                        {
                            var withBlock1 = newMetier;
                            withBlock1.ID = idJob;
                            withBlock1.Nom = VarMetier(idJob).Nom;

                            withBlock1.Atelier = new Dictionary<int, Metier_Variable.Atelier>();

                            for (var a = 0; a <= separate.Length - 1; a++)
                            {
                                string[] separateCraft = Strings.Split(separate[a], "~");

                                Metier_Variable.Atelier newMétierAtelierRessource = new Metier_Variable.Atelier();

                                {
                                    var withBlock2 = newMétierAtelierRessource;
                                    withBlock2.ID = separateCraft[0];
                                    withBlock2.Nom = VarMetier(idJob).AtelierRessource(separateCraft[0]).Nom;
                                    withBlock2.NombreCaseRecolte.Minimum = separateCraft[1];
                                    withBlock2.NombreCaseRecolte.Maximum = separateCraft[2];
                                    withBlock2.TempsReussite = separateCraft[4];
                                    withBlock2.Action = VarMetier(idJob).AtelierRessource(separateCraft[0]).Action;
                                }

                                if (withBlock1.Atelier.ContainsKey(separateCraft[0]))
                                    withBlock1.Atelier(separateCraft[0]) = newMétierAtelierRessource;
                                else
                                    withBlock1.Atelier.Add(separateCraft[0], newMétierAtelierRessource);
                            }
                        }

                        if (withBlock.Metier.ContainsKey(idJob))
                        {
                            newMetier.ItemEquipe = withBlock.Metier(idJob).ItemEquipe;
                            withBlock.Metier(idJob) = newMetier;
                        }
                        else
                            withBlock.Metier.Add(idJob, newMetier);
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Metier_Information", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Up(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // JN 28        | 73
                    // JN ID Métier | Level

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");

                    if (withBlock.Metier.ContainsKey(separateData[0]))
                        withBlock.Metier(separateData[0]).Niveau = separateData[1];

                    EcritureMessage("[Dofus]", "Ton métier " + VarMetier(separateData[0]).Nom + " passe niveau " + separateData[1] + ".", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Metier_Up", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Experience(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // JX | 17         ; 42     ; 41044   ; 43205      ; 43378   ; ? |
                    // JX | ID_Métiers ; Niveau ; Exp_Min ; Exp_actuel ; Exp_Max ;   | Métier_Suivant

                    string[] separateData = Strings.Split(data, "|");

                    for (var i = 1; i <= separateData.Length - 1; i++)
                    {
                        string[] separate = Strings.Split(separateData[i], ";");

                        if (separate[4] < 0)
                            separate[4] = separate[3];

                        if (withBlock.Metier.ContainsKey(separate[0]))
                        {
                            {
                                var withBlock1 = withBlock.Metier(separate[0]);
                                withBlock1.Niveau = separate[1];

                                {
                                    var withBlock2 = withBlock1.Experience;
                                    withBlock2.Minimum = separate[2];
                                    withBlock2.Actuelle = separate[3];
                                    withBlock2.Maximum = separate[4];
                                    withBlock2.Pourcentage = withBlock2.Actuelle / (double)withBlock2.Maximum * 100;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Metier_Experience", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Option(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // JO 0             | 4                      | 5
                    // JO Numéro_Métier | Nombre_Pour_Check_Case | Nbr minimum ingrédient 

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");

                    foreach (Metier_Variable.Base pair in withBlock.Metier.Values)
                    {
                        if (System.Convert.ToInt32(separateData[0]) == 0)
                        {
                            {
                                var withBlock1 = pair;
                                withBlock1.Payant = false;
                                withBlock1.NeFournitAucuneRessource = false;
                                withBlock1.GratuitSurEchec = false;
                                withBlock1.NombreIngredientMinimum = separateData[2];

                                while (System.Convert.ToInt32(separateData[1]) > 0)
                                {
                                    switch (separateData[1])
                                    {
                                        case object _ when separateData[1] >= 4 // Ne Fournit aucune ressource
                                       :
                                            {
                                                withBlock1.NeFournitAucuneRessource = true;
                                                separateData[1] = System.Convert.ToInt32(separateData[1]) - 4;
                                                break;
                                            }

                                        case object _ when separateData[1] >= 2 // Gratuit sur échec
                                 :
                                            {
                                                withBlock1.GratuitSurEchec = true;
                                                separateData[1] = System.Convert.ToInt32(separateData[1]) - 2;
                                                break;
                                            }

                                        case object _ when separateData[1] >= 1 // Payant
                                 :
                                            {
                                                withBlock1.Payant = true;
                                                separateData[1] = System.Convert.ToInt32(separateData[1]) - 1;
                                                break;
                                            }
                                    }
                                }
                            }

                            break;
                        }
                        else
                            separateData[0] = System.Convert.ToInt32(separateData[0]) - 1;
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Metier_Option", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Supprime(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // JR 56
                    // JR id métier

                    if (withBlock.Metier.ContainsKey(Strings.Mid(data, 3)))
                        withBlock.Metier.Remove(Strings.Mid(data, 3));

                    EcritureMessage("[Dofus]", "Tu as désappris le métier " + VarMetier(Strings.Mid(data, 3)).Nom + ".", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Metier_Supprime", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
