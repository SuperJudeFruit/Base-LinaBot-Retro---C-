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

namespace Combat
{
    static class Combat
    {
        public static void Entrer(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // GA ; 905 ; 3101697   ;
                    // GA ; Id  ; Id Joueur ; ?

                    string[] separateData = Strings.Split(data, ";");

                    if (separateData[2] == withBlock.Personnage.ID)
                    {
                        withBlock.Combat.Combat = true;

                        withBlock.Map.Entite.Clear();

                        EcritureMessage("[Combat]", "Vous êtes entré en combat.", Color.Sienna);
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Entrer", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Fin(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // GE29226|2521478|0|2;2521478  ;Linaculer;60     ;0               ;11655000;11712633  ;12450000;93; ; ;388~1,393~1,394~1    ;12         |joueur suivant
                    // ;ID UNIQUE;Nom      ;niveau ;0 = win 1 = lose;Exp Min ;Exp Actuel;Xp Max  ;? ;?;?;ID Objet+Quantité,etc;Kamas dropé

                    withBlock.Combat = new Combat_Variable.Base();
                    withBlock.Defi = new Defi_Variable.Base();
                    withBlock.Map = new Map_Variable.Base();

                    string[] separateData = Strings.Split(data, "|");

                    for (var i = 3; i <= separateData.Length - 1; i++)
                    {
                        string[] separate = Strings.Split(separateData[i], ";");

                        if (separate[1] == separateData[1])
                        {
                            {
                                var withBlock1 = withBlock.Drop;
                                withBlock1.Kamas += System.Convert.ToInt32(separate[12]);

                                switch (separate[4])
                                {
                                    case "0":
                                        {
                                            withBlock1.Gagne += 1;
                                            break;
                                        }

                                    case "1":
                                        {
                                            withBlock1.Perdu += 1;
                                            break;
                                        }
                                }

                                string[] separateItem = Strings.Split(separate[11], ",");

                                for (var a = 0; a <= separateItem.Length - 1; a++)
                                {
                                    separate = Strings.Split(separateItem[a], "~");

                                    if (withBlock1.Item.ContainsKey(separate[0]))
                                        withBlock1.Item(separate[0]) += separate[1];
                                    else
                                        withBlock1.Item.Add(separate[0], separate[1]);
                                }
                            }
                        }
                    }

                    EcritureMessage("[Dofus]", "Fin du combat.", Color.Sienna);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Fin", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Lancer(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // Indique l'épée et le tas de monstre (se qu'il contient)

                    // Gt -42                     | + 1234567   ; Linaculer ; 60 
                    // Gt -43                     | + -1        ; 63        ; 3      |+-2;63;2 
                    // Gt Id Unique Epee/Tas Mobs | + Id Unique ; Nom/ID    ; Niveau | Suivant

                    string[] separateData = Strings.Split(data, "|");
                    int id = Strings.Mid(separateData[0], 3, separateData[0].Length);

                    for (var i = 1; i <= separateData.Count() - 1; i++)
                    {
                        string[] separate = Strings.Split(separateData[i], ";");
                        Combat_Variable.Lancer newMapCombatLancer = new Combat_Variable.Lancer();

                        {
                            var withBlock1 = newMapCombatLancer;
                            withBlock1.idUnique = separate[0].Replace("+", "");
                            withBlock1.IdNom = separate[1];
                            withBlock1.Niveau = separate[2];
                        }

                        if (withBlock.Combat.Lancer.ContainsKey(id))
                            withBlock.Combat.Lancer(id).Add(newMapCombatLancer);
                        else
                            withBlock.Combat.Lancer.Add(id, new List<Combat_Variable.Lancer>() { newMapCombatLancer });
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Lancer", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Echec(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // GA ; 903 ; 1234567    ; f
                    // GA ; 903 ; Id Lanceur ; Cadenas/Groupe

                    string[] separateData = Strings.Split(data, ";");

                    switch (separateData[3])
                    {
                        case "f":
                            {
                                EcritureMessage("[Dofus]", "Impossible de rejoindre le combat car l'équipe est fermée (ou limitée au groupe du joueur principal).", Color.Red);
                                break;
                            }

                        case "p":
                            {
                                EcritureMessage("[Dofus]", "Action impossible sur cette carte.", Color.Red);
                                break;
                            }

                        default:
                            {
                                ErreurFichier(withBlock.Personnage.NomDuPersonnage, "GiMapAgressionEchec", data);
                                break;
                            }
                    }
                }

                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Echec", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Expulser(string data)
        {
            {
                var withBlock = Bot;
                try
                {
                }

                // GV

                // Si en SOCKET
                // .Mitm.Send("GC1")

                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Expulser", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }

    namespace Sort
    {
        static class Sort
        {
            public static void Normal(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA ; 300 ; 1234567    ; 61      , 148     , 902 , 5 , 31 , 2 , 1 
                        // GA ; 300 ; Id Lanceur ; Id Sort , Cellule , ?   , ? , ?  , ? , ?

                        string[] separateData = Strings.Split(data, ";");
                        string[] separateSort = Strings.Split(separateData[3], ",");

                        if (separateData[2] == withBlock.Personnage.ID)
                            withBlock.Combat.Echec = false;

                        if (VarSort.ContainsKey(separateSort[0]))
                            EcritureMessage("[Combat]", withBlock.Map.Entite(separateData[2]).Nom + " lance le sort : " + VarSort(separateSort[0]).Values(0).Nom + " sur la cellule : " + separateSort[1], Color.Sienna);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Sort_Normal", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void CoupCritique(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA ; 301 ; 1234567    ; 161
                        // GA ; 301 ; ID_Lanceur ; ID_Sort

                        string[] separateData = Strings.Split(data, ";");

                        if (separateData[2] == withBlock.Personnage.ID)
                        {
                            withBlock.Combat.Echec = false;
                            EcritureMessage("[Combat]", "Coup Critique !", Color.Sienna);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Sort_CoupCritique", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void EchecCritique(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA ; 302 ; 1234567    ; 161
                        // GA ; 302 ; ID_Lanceur ; ID_Sort

                        string[] separateData = Strings.Split(data, ";");

                        if (VarSort.ContainsKey(System.Convert.ToInt32(separateData[3])))
                        {
                            EcritureMessage("[Combat]", withBlock.Map.Entite(separateData[2]).Nom + " lance le sort : " + VarSort(separateData[3]).Values(0).Nom + ".", Color.Sienna);
                            EcritureMessage("[Combat]", "Echec Critique !", Color.Sienna);
                        }

                        if (separateData[2] == withBlock.Personnage.ID)
                            withBlock.Combat.Echec = true;
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Sort_EchecCritique", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }
        }
    }

    namespace Challenge
    {
        static class Challenge
        {
            public static void Information(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // Gd 2            ; 0 ;   ; 25 ; 5         ; 25    ; 5 
                        // Gd ID Challenge ; ? ; ? ; Xp ; Xp Groupe ; Butin ; Butin Groupe

                        string[] separateData = Strings.Split(Strings.Mid(data, 3), ";");

                        Combat_Variable.Challenge newCombat = new Combat_Variable.Challenge();

                        {
                            var withBlock1 = newCombat;
                            switch (separateData[0])
                            {
                                case "2":
                                    {
                                        withBlock1.Nom = "Statue";
                                        break;
                                    }

                                case "4":
                                    {
                                        withBlock1.Nom = "Sursis";
                                        break;
                                    }

                                case "17":
                                    {
                                        withBlock1.Nom = "Intouchable";
                                        break;
                                    }

                                case "24":
                                    {
                                        withBlock1.Nom = "Borne";
                                        break;
                                    }

                                case "31":
                                    {
                                        withBlock1.Nom = "Statue";
                                        break;
                                    }

                                case "38":
                                    {
                                        withBlock1.Nom = "Blitzkrieg";
                                        break;
                                    }

                                default:
                                    {
                                        withBlock1.Nom = "Inconnu";
                                        break;
                                    }
                            }

                            withBlock1.ID = separateData[0];
                            withBlock1.Rate = false;
                            withBlock1.Xp = separateData[3];
                            withBlock1.Xp_Groupe = separateData[4];
                            withBlock1.Butin = separateData[5];
                            withBlock1.Butin_Groupe = separateData[6];
                        }

                        if (withBlock.Combat.Challenge.ContainsKey(separateData[0]))
                            withBlock.Combat.Challenge(separateData[0]) = newCombat;
                        else
                            withBlock.Combat.Challenge.Add(separateData[0], newCombat);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Challenge_Information", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Reussi(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GdOK 41
                        // GdOK id Challenge

                        if (withBlock.Combat.Challenge.ContainsKey(Strings.Mid(data, 5)))
                            EcritureMessage("[Combat]", "Vous avez réussi le challenge : " + withBlock.Combat.Challenge(Strings.Mid(data, 5)).Nom, Color.Sienna);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Challenge_Reussi", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Echoue(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GdKO 23
                        // GdKO id Challenge

                        if (withBlock.Combat.Challenge.ContainsKey(Strings.Mid(data, 3)))
                        {
                            withBlock.Combat.Challenge(Strings.Mid(data, 3)).Rate = true;

                            EcritureMessage("[Combat]", "Challenge raté : " + withBlock.Combat.Challenge(Strings.Mid(data, 3)).Nom, Color.Sienna);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Challenge_Echoue", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }
        }
    }

    namespace Information
    {
        static class Information
        {
            public static void Mort(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA ; 103     ; 01234567 ; -5 
                        // GA ; ID Info ; ID Tueur ; ID Tué

                        withBlock.Combat.Pause += 1800;

                        string[] separateData = Strings.Split(data, ";");

                        if (withBlock.Combat.Entite.ContainsKey(separateData[3]))
                        {
                            withBlock.Combat.Entite(separateData[3]).Vivant = false;

                            EcritureMessage("[Combat]", withBlock.Map.Entite(separateData[3]).Nom + " est mort.", Color.Sienna);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Information_Mort", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void PointDeVie_Perdu(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {


                        // GA ; 100 ; 123456789  ; -1       , -3       , 2
                        // GA ; 100 ; 1234567    ; 7654321  , 50
                        // GA ; 100 ; Id Lanceur ; Id Cible , Quantité , ?

                        string[] separateData = Strings.Split(data, ";");
                        string[] separateInfo = Strings.Split(separateData[3], ",");

                        if (withBlock.Combat.Entite.ContainsKey(separateInfo[0]))
                        {
                            if (System.Convert.ToInt32(separateInfo[1]) < 0)
                            {
                                EcritureMessage("[Combat]", withBlock.Map.Entite(separateInfo[0]).Nom + " perd " + separateInfo[1] + " points de vie.", Color.Sienna);
                                withBlock.Combat.Entite(separateInfo[0]).Vitalite = System.Convert.ToInt32(withBlock.Combat.Entite(separateInfo[0]).Vitalite + separateInfo[1]);
                            }
                            else
                                EcritureMessage("[Dofus]", withBlock.Map.Entite(separateInfo[0]).Nom + " n'a rien subi.", Color.Sienna);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Information_PointDeVia_Perdu", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Tour_Actuel(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GTS 1234567   | 29000 
                        // GTS Id Unique | Temps restant

                        string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                        if (withBlock.Personnage.ID == separateData[0])
                            withBlock.Combat.MonTour = true;

                        if (withBlock.Combat.Entite.ContainsKey(separateData[0]))
                            withBlock.Combat.Entite(separateData[0]).NumeroTour += 1;
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Information_Tour_Actuel", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Tour_Passe(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                    }

                    // GTR -1
                    // GTR Id Joueur/mobs

                    // Si je suis en MITM
                    // .Mitm.Send("GT")

                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Information_Tour_Passe", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Tour_Passe_Entite(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GTF -1
                        // GTF Id Joueur/mobs

                        if (Strings.Mid(data, 4) == withBlock.Personnage.ID)
                            withBlock.Combat.MonTour = false;
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Information_Tour_Passe_Entite", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Action(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GAF 0  | 01234567 
                        // GAF Id | Id Entite

                        string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                        // Task.Delay(.Combat.Pause).Wait()

                        withBlock.Mitm.Send("GKK" + separateData[0]);

                        withBlock.Combat.Pause = 0;
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Information_Action", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Tour_Information(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GTM |-1         ; 0               ; 45         ; 5  ; 3  ; 330     ;   ; 45      | 1234567;0;145;6;3;309;;145  
                        // GTM | ID Unique ; Vivant=0/Mort=1 ; Pdv actuel ; PA ; PM ; Cellule ; ? ; Pdv Max | Next

                        string[] separateData = Strings.Split(data, "|");

                        for (var i = 1; i <= separateData.Length - 1; i++)
                        {
                            string[] separate = Strings.Split(separateData[i], ";");

                            if (withBlock.Combat.Entite.ContainsKey(separate[0]))
                            {
                                {
                                    var withBlock1 = withBlock.Combat.Entite(separate[0]);
                                    switch (separate[1])
                                    {
                                        case 0 // Vivant
                                       :
                                            {
                                                withBlock1.Vitalite = separate[2];
                                                withBlock1.PA = separate[3];
                                                withBlock1.PM = separate[4];

                                                withBlock1.Vivant = true;
                                                break;
                                            }

                                        case 1 // Mort
                                 :
                                            {
                                                withBlock1.Vivant = false;
                                                break;
                                            }
                                    }
                                }
                            }

                            if (withBlock.Map.Entite.ContainsKey(separate[0]))
                                withBlock.Map.Entite(separate[0]).Cellule = separate[1] == "0" ? separate[5] : -1;
                        }

                        withBlock.Mitm.Send("GT");
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Information_Tour_Information", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Tour_Ordre(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GTL | 1234567   | -1 
                        // GTL | Id Unique | Next

                        string[] separateData = Strings.Split(data, "|");

                        for (var i = 1; i <= separateData.Length - 1; i++)
                        {
                            if (withBlock.Combat.Entite.ContainsKey(separateData[i]))
                                withBlock.Combat.Entite(separateData[i]).OrdreTour = i;
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Information_Tour_Ordre", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }
        }
    }

    namespace PM
    {
        static class PM
        {
            public static void Perdu(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {


                        // GA ; 129 ; 1234567    ; -1       , 3
                        // GA ; 129 ; ID_Lanceur ; ID_Cible , Quantité  

                        string[] separateData = Strings.Split(data, ";");
                        string[] separateInfo = Strings.Split(separateData[3], ",");

                        if (withBlock.Map.Entite.ContainsKey(separateInfo[0]))
                        {
                            if (separateData[2] == separateInfo[0])
                                EcritureMessage("[Combat]", withBlock.Map.Entite(separateInfo[0]).Nom + " utilise " + separateInfo[1] + " PM.", Color.Sienna);
                            else
                                EcritureMessage("[Combat]", withBlock.Map.Entite(separateInfo[0]).Nom + " perd " + separateInfo[1] + " PM.", Color.Sienna);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_PM_Perdu", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Gagne(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {


                        // GA ; 128 ; 1234567    ; -1       , 3
                        // GA ; 128 ; ID_Lanceur ; ID_Cible , Quantité  

                        string[] separateData = Strings.Split(data, ";");
                        string[] separateInfo = Strings.Split(separateData[3], ",");

                        if (withBlock.Map.Entite.ContainsKey(separateInfo[0]))
                            EcritureMessage("[Combat]", withBlock.Map.Entite(separateInfo[0]).Nom + " gagne " + separateInfo[1] + " PM.", Color.Sienna);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_PM_Gagne", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Esquive(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {


                        // GA ; 309 ; -1         ; 1234567  , 1 
                        // GA ; 309 ; ID_Lanceur ; ID_Cible , Quantité  

                        string[] separateData = Strings.Split(data, ";");
                        string[] separateInfo = Strings.Split(separateData[3], ",");

                        if (withBlock.Map.Entite.ContainsKey(separateInfo[0]))
                            EcritureMessage("[Combat]", withBlock.Map.Entite(separateInfo[0]).Nom + " a esquivé la perte de " + separateInfo[1] + " PM.", Color.Sienna);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_PM_Esquive", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }
        }
    }

    namespace PO
    {
        static class PO
        {
            public static void Gagne(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA ; 117 ; 1234567    ; 7654321  , 1        , 2
                        // GA ; 117 ; ID_Lanceur ; ID_Cible , Quantité , Nbr tour

                        string[] separateData = Strings.Split(data, ";");
                        string[] separateInfo = Strings.Split(separateData[3], ",");

                        if (withBlock.Map.Entite.ContainsKey(separateInfo[0]))
                            EcritureMessage("[Combat]", withBlock.Map.Entite(separateInfo[0]).Nom + " gagne " + separateInfo[1] + " PO pendant " + separateInfo[2] + " tours.", Color.Sienna);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_PO_Gagne", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Perdu(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA ; 116 ; 1234567    ; -1       , 1        , 1
                        // GA ; 116 ; ID_Lanceur ; ID_Cible , Quantité , Nbr tour

                        string[] separateData = Strings.Split(data, ";");
                        string[] separate = Strings.Split(separateData[3], ",");

                        if (withBlock.Map.Entite.ContainsKey(separate[0]))
                            EcritureMessage("[Combat]", withBlock.Map.Entite(separate[0]).Nom + " : " + separate[1] + " à la portée (" + separate[2] + " tour).", Color.Sienna);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_PO_Perdu", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }
        }
    }

    namespace PA
    {
        static class PA
        {
            public static void Perdu(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA ; 102 ; -1         ; -1       , -5
                        // GA ; 102 ; ID_Lanceur ; ID_Cible , Quantité

                        string[] separateData = Strings.Split(data, ";");
                        string[] separateInfo = Strings.Split(separateData[3], ",");

                        if (withBlock.Map.Entite.ContainsKey(separateInfo[0]))
                            EcritureMessage("[Combat]", withBlock.Map.Entite(separateInfo[0]).Nom + " utilise " + separateInfo[1] + " PA.", Color.Sienna);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_PA_Utilise", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Gagne(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA ; 111 ; -1         ; -1       , -5
                        // GA ; 111 ; ID_Lanceur ; ID_Cible , Quantité

                        string[] separateData = Strings.Split(data, ";");
                        string[] separateInfo = Strings.Split(separateData[3], ",");

                        if (withBlock.Map.Entite.ContainsKey(separateInfo[0]))
                            EcritureMessage("[Combat]", withBlock.Map.Entite(separateInfo[0]).Nom + " gagne " + separateInfo[1] + " PA.", Color.Sienna);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_PA_Gagne", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Esquive(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA ; 308 ; -1         ; 1234567  , 1 
                        // GA ; 308 ; ID_Lanceur ; ID_Cible , Quantité  

                        string[] separateData = Strings.Split(data, ";");
                        string[] separateInfo = Strings.Split(separateData[3], ",");

                        if (withBlock.Map.Entite.ContainsKey(separateInfo[0]))
                            EcritureMessage("[Combat]", withBlock.Map.Entite(separateInfo[0]).Nom + " a esquivé la perte de " + separateInfo[1] + " PA.", Color.Sienna);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_PA_Esquive", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }
        }
    }

    namespace Etat
    {
        static class Etat_Combat
        {
            public static void Etat(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA ; 950 ; 7654321    ; 1234567  , 7       , 0
                        // GA ; 950 ; id Lanceur ; ID_Cible , Id Etat , nbr de tour ? 

                        string[] separateData = Strings.Split(data, ";");
                        string[] separateInfo = Strings.Split(separateData[3], ",");

                        if (withBlock.Combat.Entite.ContainsKey(separateInfo[0]))
                        {
                            switch (separateInfo[1])
                            {
                                case "3":
                                    {
                                        break;
                                    }

                                case "7":
                                    {
                                        withBlock.Combat.Entite(separateInfo[0]).Etat = "Pesanteur";
                                        EcritureMessage("[Combat]", withBlock.Map.Entite(separateInfo[0]).Nom + " entre dans l'état Pesanteur.", Color.Sienna);
                                        break;
                                    }

                                case "8":
                                    {
                                        withBlock.Combat.Entite(separateInfo[0]).Etat = "";
                                        break;
                                    }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Etat_Etat", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }
        }
    }

    namespace Preparation
    {
        static class Preparation
        {
            public static void En_Placement(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GIC | 1234567   ; 207     ; 1 
                        // GIC | Id unique ; Cellule ; Numéro equipe

                        string[] separateData = Strings.Split(data, "|");

                        separateData = Strings.Split(separateData[1], ";");

                        if (withBlock.Map.Entite.ContainsKey(separateData[0]))
                        {
                            withBlock.Map.Entite(separateData[0]).Cellule = separateData[1];
                            withBlock.Combat.Entite(separateData[0]).Equipe = separateData[2];
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Preparation_", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Temps_Preparation(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {


                        // GJK2 | 0 | 1 | 0 | 30000                                      | 4 
                        // GJK2 | ? | ? | ? | Temps restant avant que le combat se lance | ?

                        string[] separateData = Strings.Split(data, "|");

                        {
                            var withBlock1 = withBlock.Combat;
                            withBlock1.Combat = true;
                            withBlock1.Preparation = System.Convert.ToInt32(separateData[4]) >= 1;
                            withBlock1.Entite.Clear();
                        }

                        withBlock.Map.Entite.Clear();

                        EcritureMessage("[Combat]", "Il reste " + separateData[4] + " millisecondes avant que le combat se lance automatiquement.", Color.Sienna);
                    }

                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Preparation_Temps_Preparation", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Pret(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GR 1           3107486
                        // GR Prêt ou non Id Unique

                        int id = Strings.Mid(data, 4);

                        if (withBlock.Combat.Entite.ContainsKey(id))
                            withBlock.Combat.Entite(id).Pret = Strings.Mid(data, 3, 1) == "1";
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Preparation_Pret", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Placement_Case(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GP bfbubBbPbYcbcfct  | fBfPfXf1f_gdgOg2  | 0 
                        // GP Cellules Equipe 1 | Cellules equipé 2 | Indique l'équipe dans laquel vous êtes (couleur des cases)

                        string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");

                        {
                            var withBlock1 = withBlock.Combat;
                            withBlock1.Placement_Cellule.Clear();
                            withBlock1.Placement = true;

                            for (var i = 0; i <= 1; i++)
                            {
                                for (var a = 1; a <= separateData[i].Length; a += 2)
                                {
                                    if (withBlock1.Placement_Cellule.ContainsKey(i))
                                        withBlock1.Placement_Cellule(i).Add(ReturnLastCell(Strings.Mid(separateData[separateData[2]], a, 2)));
                                    else
                                        withBlock1.Placement_Cellule.Add(i, new List<int>(ReturnLastCell(Strings.Mid(separateData[separateData[2]], a, 2))));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Combat_Preparation_Placement_Case", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }
        }
    }
}
