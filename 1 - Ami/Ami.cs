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

namespace Ami
{
    static class Ami
    {
        public static void Reception(string data)
        {
            try
            {
                {
                    var withBlock = Bot;

                    // FL | Linaculer#9999  ; 1      ; Linaculers   ; 1     ; 0           ; 7         ; 1    ; 71 
                    // FL | Pseudo          ; en ami ; Nom          ; Level ; alignement  ; id classe ; Sexe ; classe + sexe
                    // iL = ennemi

                    string[] separateData = Strings.Split(data, "|");

                    switch (separateData[0])
                    {
                        case "FL":
                            {
                                withBlock.Ami.Reset();
                                break;
                            }

                        case "iL":
                            {
                                withBlock.Ennemi.Reset();
                                break;
                            }
                    }

                    if (separateData.Length > 1)
                    {
                        for (var i = 1; i <= separateData.Length - 1; i++)
                        {
                            string[] separate = Strings.Split(separateData[i], ";");

                            Ami_Variable.Information newFriend = new Ami_Variable.Information();

                            {
                                var withBlock1 = newFriend;
                                withBlock1.Pseudo = separate[0]; // Linaculer#9999

                                if (separate.Length > 1)
                                {
                                    withBlock1.Ajoute = separate[1] != "?";

                                    withBlock1.Connecte = true;

                                    withBlock1.Nom = separate[2];

                                    withBlock1.Niveau = separate[3] == "?" ? -1 : separate[3];

                                    withBlock1.Alignement = separate[4];

                                    withBlock1.Classe = separate[5];

                                    withBlock1.Sex = separate[6];

                                    withBlock1.ClasseSex = separate[7];
                                }
                            }

                            switch (separateData[0])
                            {
                                case "FL":
                                    {
                                        withBlock.Ami.Ajoute = newFriend;
                                        break;
                                    }

                                case "iL":
                                    {
                                        withBlock.Ennemi.Ajoute = newFriend;
                                        break;
                                    }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Ami_Reception", data + Constants.vbCrLf + ex.Message);
            }
        }

        public static void Ajoute(string data)
        {
            try
            {
                {
                    var withBlock = Bot;

                    // FAK Linacu ; 2 ; Linaculer ; 99     ; 9      ; 0    ; 90 
                    // FAK Pseudo ; ? ; Nom       ; Niveau ; Classe ; Sexe ; Classe + Sexe

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), ";");

                    switch (Strings.Mid(separateData[0], 1, 3))
                    {
                        case "FAK":
                            {
                                EcritureMessage("[Dofus]", "(" + separateData[0] + ") " + separateData[2] + " a été ajouté à votre liste d'ami.", Color.Green);
                                break;
                            }

                        case "iAK":
                            {
                                EcritureMessage("[Dofus]", "(" + separateData[0] + ") " + separateData[2] + " a été ajouté à votre liste d'ennemi", Color.Green);
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Ami_Ajoute", data + Constants.vbCrLf + ex.Message);
            }
        }

        public static void Supprimer(string data)
        {
            try
            {
                {
                    var withBlock = Bot;

                    // FDK 
                    // iDK

                    switch (data)
                    {
                        case "FDK":
                            {
                                EcritureMessage("[Dofus]", "Tu viens de perdre un ami.", Color.Green);
                                break;
                            }

                        case "iDK":
                            {
                                EcritureMessage("[Dofus]", "L'ennemi a été effacé, la paix gagne une bataille.", Color.Green);
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Ami_Supprimer", data + Constants.vbCrLf + ex.Message);
            }
        }

        public static void Ajoute_Supprime_Echec(string data)
        {
            try
            {
                {
                    var withBlock = Bot;

                    // FAEf = Ami
                    // iAEf = Ennemi
                    // FAEa
                    // iAEa

                    switch (data)
                    {
                        case "FAEf":
                        case "iAEf":
                            {
                                EcritureMessage("[Dofus]", "Impossible, ce perso ou compte n'existe pas ou n'est pas connecté.", Color.Red);
                                break;
                            }

                        case "FAEa":
                            {
                                EcritureMessage("[Dofus]", "Déjà dans ta liste d'amis.", Color.Red);
                                break;
                            }

                        case "iAEa":
                            {
                                EcritureMessage("[Dofus]", "Déjà dans ta liste d'ennemis.", Color.Red);
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Ami_Ajoute_Supprime_Echec", data + Constants.vbCrLf + ex.Message);
            }
        }

        public static void Information(string data)
        {
            try
            {
                {
                    var withBlock = Bot;

                    // BWK Linaculer | 1 | Lenculé | 7
                    // BWK Pseudo    | ? | Nom     | Zone

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    string phrase = separateData[2] + " (" + separateData[1] + ") se trouve en ";

                    switch (separateData[3])
                    {
                        case "-1":
                            {
                                phrase += "zone inconnue.";
                                break;
                            }

                        case "7":
                            {
                                phrase += "bonta.";
                                break;
                            }

                        case "11":
                            {
                                phrase += "Brakmar";
                                break;
                            }

                        case "18":
                            {
                                phrase += "Astrub";
                                break;
                            }
                    }

                    EcritureMessage("[Dofus]", phrase, Color.Green);
                }
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Ami_Information", data + Constants.vbCrLf + ex.Message);
            }
        }

        public static void Information_Echec(string data)
        {
            try
            {
                {
                    var withBlock = Bot;

                    // BWE Linaculer 
                    // BWE Pseudo    

                    EcritureMessage("[Dofus]", Strings.Mid(data, 4) + " n'est pas connecté ou n'existe pas.", Color.Green);
                }
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Ami_Information_Echec", data + Constants.vbCrLf + ex.Message);
            }
        }

        public static void Averti(string data)
        {
            try
            {
                {
                    var withBlock = Bot;

                    // FO - ou +

                    switch (data)
                    {
                        case "FO-":
                            {
                                withBlock.Ami.Averti = false;

                                EcritureMessage("[Dofus]", "Vous serez pas avertis lors de la connexion d'un ami.", Color.Green);
                                break;
                            }

                        case "FO+":
                            {
                                withBlock.Ami.Averti = true;

                                EcritureMessage("[Dofus]", "Vous serez avertis lors de la connexion d'un ami.", Color.Green);
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Ami_Averti", data + Constants.vbCrLf + ex.Message);
            }
        }
    }
}
