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

namespace Groupe
{
    static class Groupe
    {
        public static void Invitation(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // PIK Linaculer           | Sispano
                    // PIK Personne qui invite | Invité

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    {
                        var withBlock1 = withBlock.Groupe;
                        withBlock1.Invitation = true;
                        withBlock1.Inviteur = separateData[0];
                        withBlock1.Inviter = separateData[1];
                    }

                    if (separateData[0].ToLower() == withBlock.Personnage.NomDuPersonnage.ToLower)
                        EcritureMessage("[Dofus]", "Tu invites " + separateData[1] + " à rejoindre ton groupe...", Color.Green);
                    else
                        EcritureMessage("[Dofus]", separateData[0] + " t'invite à rejoindre son groupe." + Constants.vbCrLf + "Acceptes-tu ?", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Invitation", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Rejoint(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // PCK Linaculer
                    // PCK nom

                    {
                        var withBlock1 = withBlock.Groupe;
                        withBlock1.Invitation = false;
                        withBlock1.Groupe = true;
                    }

                    EcritureMessage("[Dofus]", "Tu viens de rejoindre le groupe de " + Strings.Mid(data, 4) + ".", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Rejoint", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Erreur(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // PIE a
                    // PIE n Linaculer

                    withBlock.Groupe.Invitation = false;

                    switch (Strings.Mid(data, 4, 1))
                    {
                        case "a":
                            {
                                EcritureMessage("[Dofus]", "Impossible, ce joueur fait déjà partie d'un groupe.", Color.Red);
                                break;
                            }

                        case "n":
                            {
                                EcritureMessage("[Dofus]", Strings.Mid(data, 5) + " n'est pas connecté ou n'existe pas.", Color.Red);
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Erreur", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Chef(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // PL 1234567
                    // PL id chef

                    withBlock.Groupe.Chef = Strings.Mid(data, 3);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Chef", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Fin(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // PR

                    withBlock.Groupe.Invitation = false;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Fin", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Ajoute(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // PM+ 1234567   ; Linaculer ; 91         ; -1       ; -1       ; -1       ;     , 9aa    , 9a9  ,          ,          ; 111        , 111     ; 4      ; 203          ; 104         ; 0 |Next
                    // PM+ Id Unique ; Nom       ; Id Classe  ; Couleur1 ; Couleur2 ; Couleur3 ; Cac , Coiffe , Cape , Familier , Bouclier ; Pdv actuel , Pdv Max ; Niveau ; Initiative   ; Prospection ; ? |

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    for (var i = 0; i <= separateData.Length - 1; i++)
                    {
                        string[] separate = Strings.Split(separateData[i], ";");

                        if (!withBlock.Groupe.Membre.ContainsKey(separate[0]))
                        {
                            Groupe_Variable.Information newGroupe = new Groupe_Variable.Information();

                            {
                                var withBlock1 = newGroupe;
                                withBlock1.ID = separate[0]; // IdUnique
                                withBlock1.Nom = separate[1]; // Nom
                                withBlock1.ClasseSexe = separate[2]; // IdClasse
                                withBlock1.Couleur1 = "&H" + separate[3]; // Couleur1
                                withBlock1.Couleur2 = "&H" + separate[4]; // Couleur2
                                withBlock1.Couleur3 = "&H" + separate[5]; // Couleur3

                                {
                                    var withBlock2 = withBlock1.Equipement;
                                    string[] separateInfo = Strings.Split(separate[6], ",");

                                    if (separateInfo[0] != null)
                                        withBlock2.Cac = Convert.ToInt64(separateInfo[0], 16);

                                    if (separateInfo[1] != null)
                                    {
                                        string[] separateObvijevan = Strings.Split(separateInfo[1], "~");

                                        withBlock2.Chapeau.ID = Convert.ToInt64(separateObvijevan[0], 16);

                                        if (separateInfo[1].Contains('~'))
                                        {
                                            withBlock2.Chapeau.Niveau = Convert.ToInt64(separateObvijevan[1], 16);
                                            withBlock2.Chapeau.Forme = Convert.ToInt64(separateObvijevan[2], 16);
                                        }
                                    }
                                    else
                                        withBlock2.Chapeau = new Map_Variable.Information();

                                    if (separateInfo[2] != null)
                                    {
                                        string[] separateObvijevan = Strings.Split(separateInfo[2], "~");

                                        withBlock2.Cape.ID = Convert.ToInt64(separateObvijevan[0], 16);

                                        if (separateInfo[2].Contains('~'))
                                        {
                                            withBlock2.Cape.Niveau = Convert.ToInt64(separateObvijevan[1], 16);
                                            withBlock2.Cape.Forme = Convert.ToInt64(separateObvijevan[2], 16);
                                        }
                                    }
                                    else
                                        withBlock2.Cape = new Map_Variable.Information();

                                    if (separateInfo[3] != null)
                                        withBlock2.Familier = Convert.ToInt64(separateInfo[3], 16);

                                    if (separateInfo[4] != null)
                                        withBlock2.Bouclier = Convert.ToInt64(separateInfo[4], 16);
                                }

                                {
                                    var withBlock2 = withBlock1.Vitaliter;
                                    withBlock2.Actuelle = Strings.Split(separate[7], ",")(0);
                                    withBlock2.Maximum = Strings.Split(separate[7], ",")(1);
                                    withBlock2.Pourcentage = withBlock2.Actuelle / (double)withBlock2.Maximum * 100;
                                }

                                withBlock1.Niveau = separate[8]; // Niveau
                                withBlock1.Initiative = separate[9]; // Initiative
                                withBlock1.Prospection = separate[10]; // Prospection
                            }

                            withBlock.Groupe.Membre.Add(separate[0], newGroupe);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Ajoute", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Supprime(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // PM- 01234567
                    // PM- Id Unique

                    int idUnique = Strings.Mid(data, 4);

                    if (withBlock.Groupe.Membre.ContainsKey(idUnique))
                    {
                        EcritureMessage("[Groupe]", "Le joueur " + withBlock.Groupe.Membre(idUnique).Nom + " a quitté le groupe.", Color.Red);

                        withBlock.Groupe.Membre.Remove(idUnique);
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Supprime", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Modifie(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // PM~ 1234567   ; Linaculer ; 91         ; -1       ; -1       ; -1       ;     , 9aa    , 9a9  ,          ,          ; 107        , 111     ; 4      ; 195        ; 104         ; 0 
                    // PM~ Id Unique ; Nom       ; Id Classe  ; Couleur1 ; Couleur2 ; Couleur3 ; Cac , Coiffe , Cape , Familier , Bouclier ; Pdv actuel , Pdv Max ; Niveau ; Initiative ; Prospection ; ? 

                    string[] separate = Strings.Split(Strings.Mid(data, 4), ";");

                    if (withBlock.Groupe.Membre.ContainsKey(separate[0]))
                    {
                        {
                            var withBlock1 = withBlock.Groupe.Membre(separate[0]);
                            withBlock1.ID = separate[0]; // IdUnique
                            withBlock1.Nom = separate[1]; // Nom
                            withBlock1.ClasseSexe = separate[2]; // IdClasse
                            withBlock1.Couleur1 = "&H" + separate[3]; // Couleur1
                            withBlock1.Couleur2 = "&H" + separate[4]; // Couleur2
                            withBlock1.Couleur3 = "&H" + separate[5]; // Couleur3

                            {
                                var withBlock2 = withBlock1.Equipement;
                                string[] separateInfo = Strings.Split(separate[6], ",");

                                if (separateInfo[0] != null)
                                    withBlock2.Cac = Convert.ToInt64(separateInfo[0], 16);

                                if (separateInfo[1] != null)
                                {
                                    string[] separateObvijevan = Strings.Split(separateInfo[1], "~");

                                    withBlock2.Chapeau.ID = Convert.ToInt64(separateObvijevan[0], 16);

                                    if (separateInfo[1].Contains('~'))
                                    {
                                        withBlock2.Chapeau.Niveau = Convert.ToInt64(separateObvijevan[1], 16);
                                        withBlock2.Chapeau.Forme = Convert.ToInt64(separateObvijevan[2], 16);
                                    }
                                }
                                else
                                    withBlock2.Chapeau = new Map_Variable.Information();

                                if (separateInfo[2] != null)
                                {
                                    string[] separateObvijevan = Strings.Split(separateInfo[2], "~");

                                    withBlock2.Cape.ID = Convert.ToInt64(separateObvijevan[0], 16);

                                    if (separateInfo[2].Contains('~'))
                                    {
                                        withBlock2.Cape.Niveau = Convert.ToInt64(separateObvijevan[1], 16);
                                        withBlock2.Cape.Forme = Convert.ToInt64(separateObvijevan[2], 16);
                                    }
                                }
                                else
                                    withBlock2.Cape = new Map_Variable.Information();

                                if (separateInfo[3] != null)
                                    withBlock2.Familier = Convert.ToInt64(separateInfo[3], 16);

                                if (separateInfo[4] != null)
                                    withBlock2.Bouclier = Convert.ToInt64(separateInfo[4], 16);
                            }

                            {
                                var withBlock2 = withBlock1.Vitaliter;
                                withBlock2.Actuelle = Strings.Split(separate[7], ",")(0);
                                withBlock2.Maximum = Strings.Split(separate[7], ",")(1);
                                withBlock2.Pourcentage = withBlock2.Actuelle / (double)withBlock2.Maximum * 100;
                            }

                            withBlock1.Niveau = separate[8]; // Niveau
                            withBlock1.Initiative = separate[9]; // Initiative
                            withBlock1.Prospection = separate[10]; // Prospection
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Modifie", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Quitte(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // PV 1234567
                    // PV Id joueur

                    if (data == "PV")
                        EcritureMessage("[Dofus]", "Tu as quitté ton groupe.", Color.Green);
                    else if (withBlock.Groupe.Membre.ContainsKey(Strings.Mid(data, 3)))
                        EcritureMessage("[Dofus]", withBlock.Groupe.Membre(Strings.Mid(data, 3)).Nom + " vient de t'exclure du groupe.", Color.Green);
                    else
                        EcritureMessage("[Dofus]", "Tu as quitté ton groupe.", Color.Green);

                    withBlock.Groupe = new Groupe_Variable.Base();
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Quitte", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Suivez_Tous(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // PFK 1234567
                    // PFK id Unique

                    if (data == "PFK")
                        withBlock.Groupe.ID = -1;
                    else
                        withBlock.Groupe.ID = Strings.Mid(data, 4);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Suivez_Tous", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Suivre_Coordonnees(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // IC
                    // IC  -23 | 34  | 2 | 1234567 
                    // IC  Map | Map | ? | Id Unique Suivi
                    // Map = [-23,34]

                    {
                        var withBlock1 = withBlock.Groupe;
                        if (data != "IC")
                        {
                            string[] separate = Strings.Split(Strings.Mid(data, 3), "|");

                            withBlock1.Coordonnees = separate[0] + "," + separate[1];

                            if (withBlock1.Membre.ContainsKey(separate[3]))
                                EcritureMessage("[Dofus]", withBlock1.Membre(separate[3]).Nom + " se trouve sur la map [" + separate[0] + "," + separate[1] + "].", Color.Green);
                        }
                        else
                            withBlock1.Coordonnees = "";
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Suivre_Coordonnees", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
