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

namespace Guilde
{
    static class Guilde
    {
        public static void Information(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // gS LinaculerBot     | a | 0 | i | 8fsdgj | 0 
                    // gS Nom de la guilde | ? | ? | ? | ?      | ?

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");

                    {
                        var withBlock1 = withBlock.Guilde;
                        withBlock1.Guilde = true;

                        withBlock1.Nom = separateData[0];

                        if (withBlock1.Invitation)
                        {
                            withBlock1.Invitation = false;

                            EcritureMessage("[Dofus]", "Tu viens d'intégrer la guilde " + separateData[0], Color.Green);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Information", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Experience(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // gIG 0 | 5      | 28000   | 30271        | 48000
                    // gIG ? | Niveau | exp min | exp actuelle | exp max

                    string[] separate = Strings.Split(data, "|");

                    {
                        var withBlock1 = withBlock.Guilde;
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
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Experience", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Recrutement(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // gJR Linaculer
                    // gJR Nom

                    withBlock.Guilde.Invitation = true;

                    withBlock.Guilde.Inviteur = withBlock.Personnage.ID;

                    EcritureMessage("[Dofus]", "Tu invites " + Strings.Mid(data, 4) + " à rejoindre ta guilde...", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Recrutement", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Invitation(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // gJr 1234567 | Linaculer | [Ankama]
                    // gJr ID      | Nom       | Nom Guilde

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    {
                        var withBlock1 = withBlock.Guilde;
                        withBlock1.Invitation = true;

                        withBlock1.Inviteur = separateData[0];
                    }

                    EcritureMessage("[Dofus]", separateData[1] + " t'invite à rejoindre sa guilde (" + separateData[2] + ") acceptes-tu ?", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Invitation", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Refuse(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // gJE 1234567
                    // gJE id

                    {
                        var withBlock1 = withBlock.Guilde;
                        withBlock1.Invitation = false;
                        withBlock1.Inviteur = "";
                        withBlock1.Inviter = "";
                    }

                    EcritureMessage("[Dofus]", Strings.Mid(data, 4) + " refuse d'intégrer ta guilde.", Color.Red);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Refuse", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Accepte(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // gJKa Linaculer
                    // gJKa nom

                    {
                        var withBlock1 = withBlock.Guilde;
                        withBlock1.Invitation = false;
                        withBlock1.Inviteur = "";
                        withBlock1.Inviter = "";
                    }

                    EcritureMessage("[Dofus]", Strings.Mid(data, 4) + " accepte d'intégrer ta guilde.", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Accepte", data + Constants.vbCrLf + ex.Message);
                }
            }
        }



        public static void Exclut(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // gKK

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    if (separateData[0].ToLower() == withBlock.Personnage.NomDuPersonnage.ToLower)
                        EcritureMessage("[Dofus]", "Tu as banni " + separateData[1] + " de ta guilde.", Color.Green);
                    else
                        EcritureMessage("[Dofus]", "Tu es banni de la guilde.", Color.Green);
                }

                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Exclut", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Ajoute(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // gIM+ 1234567  ; Linaculer ; 60     ; 81     ; 2    ; 0        ; 0   ; 29694 ; 1        ; 0          ; 0                  | Next
                    // gIM+ IdUnique ; Nom       ; Niveau ; Classe ; Rang ; XpGagnée , %Xp ; Droit ; Connecté ; Alignement ; Dernière connexion | 

                    string[] rangActuel = new[] { "A l'essai", "Meneur", "Bras Droit", "Trésorier", "Protecteur", "Artisan", "Réserviste", "Gardien", "Eclaireur", "Espion", "Diplomate", "Secrétaire", "Tueur de familiers", "Braconnier", "Chercheur de trésor", "Voleur", "Initié", "Assassin", "Gouverneur", "Muse", "Conseiller", "Elu", "Guide", "Mentor", "Recruteur", "Eleveur", "Marchand", "Apprenti", "Bourreau", "Mascotte", "Pénitent", "Tueur de Percepteurs", "Déserteur", "Traître", "Boulet", "Larbin", "A l'essai" };

                    {
                        var withBlock1 = withBlock.Guilde;
                        withBlock1.Membre.Clear();

                        string[] separateData = Strings.Split(data, "|");

                        for (var i = 0; i <= separateData.Length - 1; i++)
                        {
                            string[] separate = Strings.Split(separateData[i], ";");

                            Guilde_Variable.Membre NewJoueur = new Guilde_Variable.Membre();

                            {
                                var withBlock2 = NewJoueur;
                                withBlock2.ID = separate[0];
                                withBlock2.Nom = separate[1];
                                withBlock2.Niveau = separate[2];
                                withBlock2.Classe = GuildeClasseAlignement(separate[3]);
                                withBlock2.Rang = rangActuel[separate[4]];
                                withBlock2.Rang_Chiffre = separate[4];

                                {
                                    var withBlock3 = withBlock2.Experience;
                                    withBlock3.Actuelle = separate[5];
                                    withBlock3.Pourcentage = separate[6];
                                }

                                withBlock2.Connecter = separate[8];
                                withBlock2.Alignement = GuildeClasseAlignement(separate[9]);
                                withBlock2.DerniereConnection = separate[10] == -1 ? "Dernière connexion il y a moins d'un jour" : "";
                                withBlock2.Droit = GuildeDroits(separate[1], separate[7]);
                                withBlock2.Droit_Chiffre = separate[7];
                            }

                            withBlock1.Membre.Add(separate[1], NewJoueur);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Ajoute", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        private static string GuildeClasseAlignement(int Valeur)
        {
            try
            {
                switch (Valeur)
                {
                    case 0:
                        {
                            return "Neutre"; // Neutre
                        }

                    case 1:
                        {
                            return "Brakmarien";
                        }

                    case 2:
                        {
                            return "Bontarien";
                        }

                    case 10:
                    case 11:
                        {
                            return "Feca";
                        }

                    case 20:
                    case 21:
                        {
                            return "Osamodas";
                        }

                    case 30:
                    case 31:
                        {
                            return "Enutrof";
                        }

                    case 40:
                    case 41:
                        {
                            return "Sram";
                        }

                    case 50:
                    case 51:
                        {
                            return "Xelor";
                        }

                    case 60:
                    case 61:
                        {
                            return "Ecaflip";
                        }

                    case 70:
                    case 71:
                        {
                            return "Eniripsa";
                        }

                    case 80:
                    case 81:
                        {
                            return "Iop";
                        }

                    case 90:
                    case 91:
                        {
                            return "Cra";
                        }

                    case 100:
                    case 101:
                        {
                            return "Sadida";
                        }

                    case 110:
                    case 111:
                        {
                            return "Sacrieur";
                        }

                    case 120:
                    case 121:
                        {
                            return "Pandawa";
                        }

                    default:
                        {
                            return Valeur;
                        }
                }
            }
            catch (Exception ex)
            {
                ErreurFichier("unknow", "", ex.Message);
            }

            return Valeur;
        }

        private static Guilde_Variable.Droit GuildeDroits(string Name_Joueur, int Information)
        {
            {
                var withBlock = Bot;
                Guilde_Variable.Droit newRights = new Guilde_Variable.Droit();
                int[] Valeur = new[] { 16384, 8192, 4096, 512, 256, 128, 64, 32, 16, 8, 4, 2 };

                try
                {
                    {
                        var withBlock1 = newRights;
                        if (Information == 1)
                        {
                            withBlock1.GererLesBoosts = true;
                            withBlock1.GererLesDroits = true;
                            withBlock1.InviterDeNouveauxMembres = true;
                            withBlock1.Bannir = true;
                            withBlock1.GererLesRepartitionsXP = true;
                            withBlock1.GererSaRepartitionXP = true;
                            withBlock1.GererLesRangs = true;
                            withBlock1.PoserUnPercepteur = true;
                            withBlock1.CollecterSurUnPercepteur = true;
                            withBlock1.UtiliserLesEnclos = true;
                            withBlock1.AmenagerLesEnclos = true;
                            withBlock1.GererLesMonturesDesAutresMembres = true;
                        }
                        else
                            for (var i = 0; i <= 11; i++)
                            {
                                if (Information >= Valeur[i])
                                {
                                    switch (Information)
                                    {
                                        case 16384:
                                            {
                                                withBlock1.GererLesBoosts = true;
                                                break;
                                            }

                                        case 8192:
                                            {
                                                withBlock1.GererLesDroits = true;
                                                break;
                                            }

                                        case 4096:
                                            {
                                                withBlock1.InviterDeNouveauxMembres = true;
                                                break;
                                            }

                                        case 512:
                                            {
                                                withBlock1.Bannir = true;
                                                break;
                                            }

                                        case 256:
                                            {
                                                withBlock1.GererLesRepartitionsXP = true;
                                                break;
                                            }

                                        case 128:
                                            {
                                                withBlock1.GererSaRepartitionXP = true;
                                                break;
                                            }

                                        case 64:
                                            {
                                                withBlock1.GererLesRangs = true;
                                                break;
                                            }

                                        case 32:
                                            {
                                                withBlock1.PoserUnPercepteur = true;
                                                break;
                                            }

                                        case 16:
                                            {
                                                withBlock1.CollecterSurUnPercepteur = true;
                                                break;
                                            }

                                        case 8:
                                            {
                                                withBlock1.UtiliserLesEnclos = true;
                                                break;
                                            }

                                        case 4:
                                            {
                                                withBlock1.AmenagerLesEnclos = true;
                                                break;
                                            }

                                        case 2:
                                            {
                                                withBlock1.GererLesMonturesDesAutresMembres = true;
                                                break;
                                            }
                                    }

                                    Information -= Valeur[i];
                                }
                            }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_mdlGuilde_GuildeDroits", ex.Message);
                }

                return newRights;
            }
        }

        public static void Supprime(int data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // gIM- Linaculer
                    // gIM- nom du joueur

                    string nom = Strings.Mid(data, 5);

                    if (withBlock.Guilde.Membre.ContainsKey(nom))
                        withBlock.Guilde.Membre.Remove(nom);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Supprime", data + Constants.vbCrLf + ex.Message);
                }
            }
        }



        public static void Personnalisation(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // gIB1 |0|200|2|1000|100|0|1|5|1020|462;0|461;0|460;0|459;0|458;0|457;0|456;0|455;0|454;0|453;0|452;0|451;0
                    // gIB1 |                   ?

                    Guilde_Variable.Percepteur NewGuildePercepteur = new Guilde_Variable.Percepteur();

                    string[] separateData = Strings.Split(data, "|");

                    {
                        var withBlock1 = NewGuildePercepteur;
                        withBlock1.NombreDePercepteur = separateData[0];
                        withBlock1.ActuellementPercepteur = separateData[1];
                        withBlock1.PointsDeVie = separateData[2];
                        withBlock1.BonusAuxDommages = separateData[3];
                        withBlock1.Pods = separateData[4];
                        withBlock1.Prospection = separateData[5];
                        withBlock1.Sagesse = separateData[6];

                        withBlock1.ResteARepartir = separateData[8];
                        withBlock1.CoutPourPoserPercepteur = separateData[9];

                        withBlock1.ArmureAqueuse = Strings.Split(separateData[21], ";")(1);
                        withBlock1.ArmureIncandescente = Strings.Split(separateData[20], ";")(1);
                        withBlock1.ArmureTerrestre = Strings.Split(separateData[19], ";")(1);
                        withBlock1.ArmureVenteuse = Strings.Split(separateData[18], ";")(1);
                        withBlock1.Flamme = Strings.Split(separateData[17], ";")(1);
                        withBlock1.Cyclone = Strings.Split(separateData[16], ";")(1);
                        withBlock1.Vague = Strings.Split(separateData[15], ";")(1);
                        withBlock1.Rocher = Strings.Split(separateData[14], ";")(1);
                        withBlock1.MotSoignant = Strings.Split(separateData[13], ";")(1);
                        withBlock1.Desenvoutement = Strings.Split(separateData[12], ";")(1);
                        withBlock1.CompulsionDeMasse = Strings.Split(separateData[11], ";")(1);
                        withBlock1.Destabilisation = Strings.Split(separateData[10], ";")(1);
                    }

                    withBlock.Guilde.Percepteur = NewGuildePercepteur;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Personnalisation", data + Constants.vbCrLf + ex.Message);
                }
            }
        }



        public static void Percepteur_Pose(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // gTS 12 , 28 | 8840   | -15   | 6     | Name
                    // gTS ?  , ?  | Map ID | Pos X | Pos Y | Nom du poseur

                    string[] separateData = Strings.Split(data, "|");

                    EcritureMessage("[Dofus]", "Le percepteur [Name] a été posé en (" + separateData[2] + ", " + separateData[3] + ") par " + separateData[4], Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Percepteur_Pose", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Percepteur(string data)
        {
            {
                var withBlock = Bot;
                try
                {
                }

                // gITM+ 2ki ; b , 28 , Linaculer1    , 1516232486517 ,   , 0 , 0 ; 2ki ; 0 
                // gITM+     ; ? , ?  , Nom du poseur , ?             , ? , ? , ? ; ?   ; ?

                // Inconnu actuellement

                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Percepteur", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Percepteur_Echec(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // gHEy

                    EcritureMessage("[Dofus]", "Impossible de poser le percepteur maintenant, il doit se reposer.", Color.Red);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Percepteur_Echec", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Percepteur_Retire(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // gTR m , f | 8858   | -17   | 7     | Name
                    // gTR ? , ? | Map ID | Pos X | Pos Y | Nom du joueur qui retire

                    string[] separateData = Strings.Split(data, "|");

                    EcritureMessage("[Dofus]", "Le percepteur [Name] en (" + separateData[2] + ", " + separateData[3] + ") a été retiré par " + separateData[4], Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Percepteur_Retire", data + Constants.vbCrLf + ex.Message);
                }
            }
        }



        public static void Enclos(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // gIF3 | 9999   ; 2           ; 2      ;  
                    // gIF3 | Map ID ; DD actuelle ; DD max ; ?

                    withBlock.Guilde.Enclos.Clear();

                    string[] separateData = Strings.Split(data, "|");

                    for (var i = 1; i <= separateData.Length - 1; i++)
                    {
                        string[] separate = Strings.Split(separateData[i], ";");

                        Guilde_Variable.Enclos newEnclos = new Guilde_Variable.Enclos();

                        {
                            var withBlock1 = newEnclos;
                            withBlock1.MapID = separate[0];
                            withBlock1.Position = VarMap(separate[0]);

                            {
                                var withBlock2 = withBlock1.Dragodinde;
                                withBlock2.Actuelle = separate[1];
                                withBlock2.Maximum = separate[2];
                            }
                        }

                        withBlock.Guilde.Enclos.Add(separate[0], newEnclos);
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Enclos", data + Constants.vbCrLf + ex.Message);
                }
            }
        }



        public static void Maison(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // gIH+ 999 ; Linaculer   ; 666,66 ;            ; 499    |
                    // ID  ; proriétaire ; Pos    ; compétence ; Droits | Next

                    withBlock.Guilde.Maison.Clear();

                    string[] separateData = Strings.Split(Strings.Mid(data, 5), "|");

                    for (var i = 0; i <= separateData.Length - 1; i++)
                    {
                        string[] separate = Strings.Split(separateData[i], ";");

                        int[] Valeur = new[] { 256, 128, 64, 32, 16, 8, 4, 2, 1 };

                        Guilde_Variable.Maison newMaison = new Guilde_Variable.Maison();

                        {
                            var withBlock1 = newMaison;
                            for (var a = 0; a <= 8; a++)
                            {
                                if (System.Convert.ToInt32(separate[4]) >= Valeur[a])
                                {
                                    switch (Valeur[a])
                                    {
                                        case 256 // 256 =  Repos autorisé aux membres de la guilde dans cette maison
                                       :
                                            {
                                                withBlock1.ReposAutoriser = true;
                                                break;
                                            }

                                        case 128 // 128 = Téléportation autorisée vers cette maison
                                 :
                                            {
                                                withBlock1.TeleportationAutoriser = true;
                                                break;
                                            }

                                        case 64 // 64 = Accès aux coffres interdit aux non-membres de la guilde
                                 :
                                            {
                                                withBlock1.AccesCoffresInterditNonMembreGuilde = true;
                                                break;
                                            }

                                        case 32 // 32 = Accès aux coffres autorisé aux membres de la guilde
                                 :
                                            {
                                                withBlock1.AccesCoffresAutoriseMembreGuilde = true;
                                                break;
                                            }

                                        case 16 // 16 = Accès interdit aux non-membres de la guilde
                                 :
                                            {
                                                withBlock1.AccesInterditNonMembreGuilde = true;
                                                break;
                                            }

                                        case 8 // 8 = Accès autorisé aux membres de la guilde
                                 :
                                            {
                                                withBlock1.AccesAutoriserMembreGuilde = true;
                                                break;
                                            }

                                        case 4 // 4 = Blason Visible pour tout le monde
                                 :
                                            {
                                                withBlock1.BlasonVisiblePourToutMonde = true;
                                                break;
                                            }

                                        case 2 // 2 = Blason Visible pour la guilde
                                 :
                                            {
                                                withBlock1.BlasonVisiblePourGuilde = true;
                                                break;
                                            }

                                        case 1 // 1 = Maison Visible pour la guilde.
                                 :
                                            {
                                                withBlock1.MaisonVisiblePourGuilde = true;
                                                break;
                                            }
                                    }

                                    separate[4] = System.Convert.ToInt32(separate[4]) - Valeur[a];
                                }
                            }

                            withBlock1.ID = separate[0];
                            withBlock1.Prorietaire = separate[1];
                            withBlock1.Position = separate[2];
                            withBlock1.Competence = separate[3];
                        }

                        withBlock.Guilde.Maison.Add(separate[1], newMaison);
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Maison", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
