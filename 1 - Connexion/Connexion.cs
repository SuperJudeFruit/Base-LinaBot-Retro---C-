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

namespace Connexion
{
    static class Connexion
    {
        public static void Serveur_Authentification(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // HC trkzqijwpzvunfezdxdhhlmmgxxgsbqm 
                    // HC Clef Crypt Mdp 

                    {
                        var withBlock1 = withBlock.Connexion;
                        withBlock1.Connexion = false;
                        withBlock1.Connecter = false;
                        withBlock1.Authentification = true;
                    }

                    EcritureMessage("(Bot)", "Connecté au serveur d'authentification.", Color.Lime);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_Serveur_Authentification", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Serveur_Jeu(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // HG 

                    {
                        var withBlock1 = withBlock.Connexion;
                        withBlock1.Authentification = false;
                        withBlock1.Connecter = false;
                        withBlock1.Connexion = true;
                    }

                    withBlock.Mitm.Send("AT" + withBlock.Personnage.Ticket);

                    EcritureMessage("(Bot)", "Connecté au serveur de jeu, envoie du ticket.", Color.Lime);

                    Reset_Config_Xml();
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_Serveur_Jeu", ex.Message);
                }
            }
        }



        public static void FileAttente_Authentification(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // Af 82              | 272            | 0 |   | -1 
                    // Af Position actuel | sur X personne | ? | ? | ?

                    string[] separate = Strings.Split(Strings.Mid(data, 3), "|");

                    EcritureMessage("[Dofus]", "En attente de connexion sur le serveur..." + Constants.vbCrLf + "Position dans la file d'attente : " + separate[0], Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_FileAttente_Authentification", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void FileAttente_Jeu(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // Aq 1
                    // Aq Position dans la queu.

                    EcritureMessage("[Dofus]", "Connexion au serveur... ( Position dans la file d'attente : " + Strings.Mid(data, 3) + " )", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_FileAttente_Jeu", data + Constants.vbCrLf + ex.Message);
                }
            }
        }


        public static void Pseudo(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // Ad Linaculer
                    // Ad Pseudo du compte

                    withBlock.Personnage.Pseudo = Strings.Mid(data, 3);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_Pseudo", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Reception_Serveur(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // AH 601        ; 1            ; 75      ; 1       | 602;1;75;1
                    // AH ID_Serveur ; Etat_Serveur ; Inconnu ; Inconnu | Next

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");

                    for (var i = 0; i <= separateData.Length - 1; i++)
                    {
                        string[] separate = Strings.Split(separateData[i], ";");

                        if (separate[0] == VarServeur(withBlock.Personnage.Serveur).ID)
                        {
                            switch (separate[1])
                            {
                                case "0":
                                    {
                                        EcritureMessage("[Dofus]", "Serveur en maintenance ! Déconnexion.", Color.Red);

                                        withBlock.Socket_Authentification.Connexion_Game(false);

                                        withBlock.Mitm.Client.Close();
                                        break;
                                    }

                                case "1":
                                    {
                                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_Reception_Serveur", "Information Inconnu : 1" + Constants.vbCrLf + data);
                                        break;
                                    }

                                case "2" // En sauvegarde
                         :
                                    {
                                        EcritureMessage("[Dofus]", "Serveur en sauvegarde !", Color.Red);
                                        break;
                                    }

                                default:
                                    {
                                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_Reception_Serveur", data);
                                        break;
                                    }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_Reception_Serveur", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void QuestionSecrete(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // AQ Quel+est+mon+mod%C3%A8le+de+voiture+pr%C3%A9f%C3%A9r%C3%A9+%3F
                    // AQ Question secréte

                    if (data.Length > 2)
                    {

                        // Je prend tout se qui se trouve après le "AQ"
                        string Question = Strings.Mid(data, 3);

                        // Je remplace les "+" par un espace.
                        Question = Question.Replace("+", " ");

                        withBlock.Personnage.QuestionSecrete = AsciiDecoder(Question);

                        EcritureMessage("[Dofus]", "Question secréte : " + withBlock.Personnage.QuestionSecrete, Color.Green);
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_QuestionSecrete", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Selection_Serveur(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // AxK 758257142                  | 601        , 5                    |
                    // AxK Abonnement en milliseconde | Id Serveur , Nombre de personnage | Next

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    withBlock.Personnage.Abonnement = DateTime.DateAdd("s", separateData[0] / 1000, DateTime.Now);


                    if (separateData.Length > 1)
                    {
                        for (var i = 1; i <= separateData.Length - 1; i++)
                        {
                            string[] separateServeur = Strings.Split(separateData[i], ",");

                            if (VarServeur(withBlock.Personnage.Serveur).ID == separateServeur[0])
                            {
                                EcritureMessage("(Bot)", "Connexion au serveur : " + VarServeur(withBlock.Personnage.Serveur).Nom, Color.Lime);

                                withBlock.Mitm.Send("AX" + VarServeur(withBlock.Personnage.Serveur).ID);

                                return;
                            }
                        }

                        EcritureMessage("(Bot)", "Le serveur demander est introuvable, vérifier d'avoir bien créer un personnage en jeu avant de lancer le bot.", Color.Red);
                    }
                    else
                        EcritureMessage("(Bot)", "Aucun serveur détecté, déconnexion du bot.", Color.Red);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_Selection_Serveur", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Reception_Personnage(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // ALK 25487456210      | 4              | 1234567       ; Linaculer      ; 101    ; 90     ; -1       ; -1       ; -1       ; 48a , 1bea   , 1b0f , 1f40     , Bouclier ; 0 ; 601        ;   ;   ;   | Next personnage
                    // ALK Abonnement_Dofus | Nbr_Personnage | ID_Personnage ; Nom_Personnage ; Niveau ; Classe ; Couleur1 ; Couleur2 ; Couleur3 ; Cac , Coiffe , Cape , Familier , Bouclier ; ? ; ID_Serveur ; ? ; ? ; ? | Next

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    withBlock.Personnage.Abonnement = DateTime.Now.AddMilliseconds(separateData[0]);

                    if (separateData[1] != "0")
                    {
                        EcritureMessage("[Dofus]", "Réception des personnages. (" + separateData[1] + ")", Color.Green);

                        for (var i = 2; i <= separateData.Length - 1; i++)
                        {
                            string[] separate = Strings.Split(separateData[i], ";");

                            if (separate[1].ToLower() == withBlock.Personnage.NomDuPersonnage.ToLower)
                            {
                                {
                                    var withBlock1 = withBlock.Personnage;
                                    withBlock1.ID = separate[0];

                                    withBlock1.NomDuPersonnage = separate[1];

                                    withBlock1.Niveau = separate[2];

                                    withBlock1.ClasseSexe = separate[3];

                                    // Pour obtenir la couleur sur une var 'Color' = ColorTranslator.FromOle(.Couleur1)
                                    withBlock1.Couleur1 = "&H" + separate[4];
                                    withBlock1.Couleur2 = "&H" + separate[5];
                                    withBlock1.Couleur3 = "&H" + separate[6];

                                    string[] separateItem = Strings.Split(separate[7], ",");

                                    if (separate[7] != "null")
                                    {
                                        {
                                            var withBlock2 = withBlock1.Equipement;
                                            if (separateItem[0] != null)
                                                withBlock2.Cac = Convert.ToInt64(separateItem[0], 16);

                                            if (separateItem[1] != null)
                                            {
                                                string[] separateObvijevan = Strings.Split(separateItem[1], "~");

                                                withBlock2.Chapeau.ID = Convert.ToInt64(separateObvijevan[0], 16);

                                                if (separateItem[1].Contains('~'))
                                                {
                                                    withBlock2.Chapeau.Niveau = Convert.ToInt64(separateObvijevan[1], 16);
                                                    withBlock2.Chapeau.Forme = Convert.ToInt64(separateObvijevan[2], 16);
                                                }
                                            }
                                            else
                                                withBlock2.Chapeau = new Map_Variable.Information();

                                            if (separateItem[2] != null)
                                            {
                                                string[] separateObvijevan = Strings.Split(separateItem[2], "~");

                                                withBlock2.Cape.ID = Convert.ToInt64(separateObvijevan[0], 16);

                                                if (separateItem[2].Contains('~'))
                                                {
                                                    withBlock2.Cape.Niveau = Convert.ToInt64(separateObvijevan[1], 16);
                                                    withBlock2.Cape.Forme = Convert.ToInt64(separateObvijevan[2], 16);
                                                }
                                            }
                                            else
                                                withBlock2.Cape = new Map_Variable.Information();

                                            if (separateItem[3] != null)
                                                withBlock2.Familier = Convert.ToInt64(separateItem[3], 16);

                                            if (separateItem[4] != null)
                                                withBlock2.Bouclier = Convert.ToInt64(separateItem[4], 16);
                                        }
                                    }

                                    withBlock1.IDServeur = separate[9];
                                }

                                EcritureMessage("(Bot)", "Connexion au personnage : " + withBlock.Personnage.NomDuPersonnage, Color.Lime);

                                withBlock.Mitm.Send("AS" + withBlock.Personnage.ID);
                                withBlock.Mitm.Send("Af");

                                break;
                            }
                        }
                    }
                    else if (withBlock.Personnage.NomDuPersonnage.ToLower == "aleatoire")
                        withBlock.Mitm.Send("AP");
                    else
                        withBlock.Mitm.Send("AA" + withBlock.Personnage.NomDuPersonnage + "|" + withBlock.Personnage.Classe + "|" + withBlock.Personnage.Sexe + "|" + withBlock.Personnage.Couleur1 + "|" + withBlock.Personnage.Couleur2 + "|" + withBlock.Personnage.Couleur3);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_Reception_Personnage", data + Constants.vbCrLf + ex.Message);
                }
            }
        }


        public static void Serveur_Ip_Port_Ticket(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // AXK 98752:98 gr5   32tr9f
                    // AXK IP       Port  Ticket 

                    // AYK eratz.ankama-games.com ; 0123f45
                    // AYK Ip et Port             ; Ticket

                    EcritureMessage("(Bot)", "Récuperation de l'IP, Port et du Ticket.", Color.Lime);

                    string Ip = "";
                    string Port = "";

                    switch (Strings.Mid(data, 1, 3))
                    {
                        case "AXK":
                            {
                                withBlock.Personnage.Ticket = Strings.Mid(data, 15);

                                Ip = DecryptIP(Strings.Mid(data, 4, 8));
                                Port = DecryptPort(Strings.Mid(data, 12, 3));
                                break;
                            }

                        case "AYK":
                            {
                                string[] separateData = Strings.Split(Strings.Mid(data, 4), ";");

                                withBlock.Personnage.Ticket = separateData[1];

                                if (data.Contains(".com"))
                                {
                                    Ip = HostNameIP(Strings.Split(separateData[0], ":")(0));
                                    Port = Strings.Split(separateData[0], ":")(1);
                                }

                                break;
                            }
                    }

                    if (Ip != VarServeur(withBlock.Personnage.Serveur).IP || Port != VarServeur(withBlock.Personnage.Serveur).Port)
                        ReplaceIpPort(withBlock.Personnage.Serveur, Ip, Port);

                    withBlock.Socket = new All_CallBack(Ip, 443);

                    withBlock.Socket.Deconnexion += withBlock.Mitm.e_Deconnexion;
                    withBlock.Socket.Envoie += withBlock.Mitm.e_Envoi;
                    withBlock.Socket.Reception += withBlock.Mitm.E_Reception;
                }
                // .CreateSocketServeurJeu(.Socket, Ip, 443, .Proxy)

                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_Serveur_Ip_Port_Ticket", ex.Message);
                }
            }
        }

        private static string HostNameIP(string hostname)
        {
            {
                var withBlock = Bot;
                try
                {
                    System.Net.IPHostEntry hostname2 = System.Net.Dns.GetHostEntry(hostname);
                    System.Net.IPAddress[] ip = hostname2.AddressList;
                    return ip[0].ToString();
                }
                catch (Exception ex)
                {
                    ErreurFichier("All", "Connexion_HostNameIP", ex.Message);
                }
            }

            return 0;
        }

        private static void ReplaceIpPort(string Serveur, string Ip, string Port)
        {
            {
                var withBlock = Bot;
                try
                {
                    System.IO.StreamReader swLecture = new System.IO.StreamReader(Application.StartupPath + @"\Data/Serveur.txt");

                    string ligneFinal = "";

                    while (!swLecture.EndOfStream)
                    {
                        string Ligne = swLecture.ReadLine();

                        if (Ligne != "")
                        {
                            string[] separate = Strings.Split(Ligne, "|");

                            if (separate[0] == Serveur)
                                ligneFinal += Serveur + "|" + Ip + "|" + Port + "|" + VarServeur(Serveur).ID + Constants.vbCrLf;
                            else
                                ligneFinal += Ligne + Constants.vbCrLf;
                        }
                    }

                    swLecture.Close();



                    System.IO.StreamWriter swEcriture = new System.IO.StreamWriter(Application.StartupPath + @"\Data/Serveur.txt");

                    swEcriture.Write(ligneFinal);

                    swEcriture.Close();


                    ChargeServeur();
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_ReplaceIpPort", ex.Message);
                }
            }
        }


        // Maxoubot
        private static string DecryptIP(string IP_Crypt)
        {
            {
                var withBlock = Bot;
                string ipServeurJeu = "";

                try
                {
                    long i = 0;
                    long fois = 0;

                    while ((i < 8))
                    {
                        i += 1;
                        fois += 1;

                        int dat1 = Strings.Asc(Strings.Mid(IP_Crypt, i, 1)) - 48;

                        i += 1;

                        int dat2 = Strings.Asc(Strings.Mid(IP_Crypt, i, 1)) - 48;
                        string Dat3 = Conversion.Str((dat1 & 15) << 4 | dat2 & 15);

                        if (fois > 1)
                            ipServeurJeu += Strings.Mid(Dat3, 2);
                        else
                            ipServeurJeu += Dat3;

                        if (i < 8)
                            ipServeurJeu += ".";
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_DecryptIP", ex.Message);
                }

                return ipServeurJeu.Replace(" ", "");
            }
        }

        // Salesprendes
        private static char[] caracteres_array = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_' };

        private static int DecryptPort(char[] chars)
        {
            int port = 0;

            try
            {
                if (chars.Length != 3)
                    throw new ArgumentOutOfRangeException("Le port doit contenir au minimum 3 caractéres.");

                for (int i = 0; i <= 2 - 1; i++)

                    port += System.Convert.ToInt32((Math.Pow(64, 2 - i) * Get_Hash(chars[i])));

                port += Get_Hash(chars[2]);
            }
            catch (Exception ex)
            {
            }

            return port;
        }

        private static short Get_Hash(char ch)
        {
            try
            {
                for (short i = 0; i <= caracteres_array.Length - 1; i++)
                {
                    if (caracteres_array[i] == ch)
                        return i;
                }
            }
            catch (Exception ex)
            {
            }

            return 0;
        }



        public static void Version(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // AlEv 1.30.1 
                    // AlEv Version


                    System.IO.StreamReader swLecture = new System.IO.StreamReader(Application.StartupPath + @"\Data/Serveur.txt");

                    string ligneFinal = "";

                    while (!swLecture.EndOfStream)
                    {
                        string ligne = swLecture.ReadLine();

                        if (ligne != "")
                        {
                            string[] separate = Strings.Split(ligne, "|");

                            if (separate[0] == "Authentification")
                                ligneFinal += ligne.Replace(separate[3], Strings.Mid(data, 5) + "e") + Constants.vbCrLf;
                            else
                                ligneFinal += ligne + Constants.vbCrLf;
                        }
                    }

                    swLecture.Close();



                    // J'ouvre le fichier pour y écrire se que je souhaite
                    System.IO.StreamWriter swEcriture = new System.IO.StreamWriter(Application.StartupPath + @"\Data/Serveur.txt");

                    // J'écris dedans avant de le fermer.
                    swEcriture.WriteLine(ligneFinal);

                    // Puis je le ferme.
                    swEcriture.Close();


                    ChargeServeur();
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_Version", ex.Message);
                }
            }
        }

        public static void Erreur_Compte(string data)
        {
            {
                var withBlock = Bot;
                try
                {
                    switch (Strings.Mid(data, 4))
                    {
                        case "AlEa":
                            {
                                EcritureMessage("[Dofus]", "Déjà en connexion.", Color.Red);
                                break;
                            }

                        case "AlEb":
                            {
                                EcritureMessage("[Dofus]", "Votre compte à été banni.", Color.Red);
                                break;
                            }

                        case "AlEc":
                            {
                                EcritureMessage("[Dofus]", "Vous êtes déjà connécté au serveur du jeu.", Color.Red);
                                break;
                            }

                        case "AlEd":
                            {
                                EcritureMessage("[Dofus]", "Vous avez déconnecté une personne utilisant le compte.", Color.Red);
                                break;
                            }

                        case "AlEf":
                            {
                                EcritureMessage("[Dofus]", "Mauvais mot de passe.", Color.Red);
                                break;
                            }

                        case "AlEk":
                            {

                                // AlEk Jour | Heure | Minute

                                string[] Separation = Strings.Split(Strings.Mid(data, 5), "|");
                                ;/* Cannot convert MultiLineIfBlockSyntax, System.NotSupportedException: LikeExpression not supported!
   at ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitBinaryExpression(BinaryExpressionSyntax node)
   at Microsoft.CodeAnalysis.VisualBasic.Syntax.BinaryExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitBinaryExpression(BinaryExpressionSyntax node)
   at Microsoft.CodeAnalysis.VisualBasic.Syntax.BinaryExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
   at Microsoft.CodeAnalysis.VisualBasic.Syntax.ParenthesizedExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
   at Microsoft.CodeAnalysis.VisualBasic.Syntax.ParenthesizedExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitBinaryExpression(BinaryExpressionSyntax node)
   at Microsoft.CodeAnalysis.VisualBasic.Syntax.BinaryExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitBinaryExpression(BinaryExpressionSyntax node)
   at Microsoft.CodeAnalysis.VisualBasic.Syntax.BinaryExpressionSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitMultiLineIfBlock(MultiLineIfBlockSyntax node)
   at Microsoft.CodeAnalysis.VisualBasic.Syntax.MultiLineIfBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 

                            'Le like me permet de regarde si le résultat correspond à chaque séparation.
                            If "1" = Separation(0) Like (Separation(1) Like Separation(2)) Then

                                EcritureMessage("[Dofus]", "Compte invalide, si vous avez 1j 1h 1m, il s'agît d'une IP bannie définitivement" & vbCrLf & "il vous suffit de changer d'IP pour régler le problème.", Color.Red)

                            Else

                                EcritureMessage("[Dofus]", "Ton compte est invalide pendant " & Separation(0) & " Jour(s) " & Separation(1) & " Heure(s) " & Separation(2) & " Minute(s)'.", Color.Red)

                            End If

 */
                                break;
                            }

                        case "AlEn":
                            {
                                EcritureMessage("[Dofus]", "La connexion ne sait pas faite correctement.", Color.Red);
                                break;
                            }

                        case "AlEp":
                            {
                                EcritureMessage("[Dofus]", "Votre compte n'est pas valide.", Color.Red);
                                break;
                            }

                        case "AlEs":
                            {
                                EcritureMessage("[Dofus]", "Le Pseudo est déjà utilisé, veuillez en choisir un autre.", Color.Red);
                                break;
                            }

                        case "AlEv":
                            {
                                EcritureMessage("[Dofus]", "La version de DOFUS installée est invalide pour ce serveur. Pour accéder au jeu, la version '" + Strings.Mid(data, 5) + "' est nécessaire.", Color.Red);
                                break;
                            }

                        case "AlEw":
                            {
                                EcritureMessage("[Dofus]", "Le serveur est complet. (Vous n'étes donc plus abonnée)", Color.Red);
                                break;
                            }

                        default:
                            {
                                ErreurFichier("[Dofus - Compte]", "Unknow", data);
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_Erreur_Compte", ex.Message);
                }
            }
        }

        public static void Erreur_Serveur(string data)
        {
            {
                var withBlock = Bot;
                try
                {
                    switch (data)
                    {
                        case "AXEf":
                            {
                                EcritureMessage("[Dofus]", "Serveur : COMPLET" + Constants.vbCrLf + "Nombre maximum de joueurs atteint." + Constants.vbCrLf + @"Pour bénéficier d'un accès prioritaire aux serveurs, nous vous invitons à vous abonner.
                                            Vous pouvez également tenter de vous connecter sur un autre serveur. Vous pouvez également 
                                            télécharger et vous connecter sur les serveurs Dofus 2.0, qui proposent un plus grand nombre
                                            de place pour accueillir les joueurs !", Color.Red);

                                withBlock.Socket_Authentification.Connexion_Game(false);

                                withBlock.Mitm.Client.Close();
                                break;
                            }

                        case "AXEd":
                            {
                                EcritureMessage("[Dofus]", "Serveur : En sauvegarde.", Color.Red);
                                break;
                            }

                        case "ATE":
                            {
                                EcritureMessage("[Dofus]", "Connexion interrompue avec le serveur." + Constants.vbCrLf + "Votre connexion est trop lente ou instable.", Color.Red);

                                withBlock.Socket_Authentification.Connexion_Game(false);

                                withBlock.Mitm.Client.Close();
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Connexion_Erreur_Serveur", ex.Message);
                }
            }
        }

        public static void Cadeau(string data)
        {
            {
                var withBlock = Bot;

                // Ag 1 | 1     | Chienchien         | Avec+sous+peine+de+perdre+une+main. |   | 44390e4~6af~1~~320#0#0#a,7c#14###0d0+20; d'abord pdv 10 ensuite sagesse a 20
                // Ag ? | Ordre | Nom                | Description                         | ? | id unique etc...

                string[] separateData = Strings.Split(data, "|");
                string[] separateItem = Strings.Split(separateData[4], "~");

                Item_Variable.Information NewItem = new Item_Variable.Information();

                {
                    var withBlock1 = NewItem;
                    withBlock1.Nom = AsciiDecoder(separateData[2]);
                    withBlock1.Description = separateData[3];
                    withBlock1.IdObjet = Convert.ToInt64(separateItem[1], 16);
                    withBlock1.IdUnique = Convert.ToInt64(separateItem[0], 16);
                    withBlock1.Quantiter = Convert.ToInt64(separateItem[2], 16);
                    withBlock1.Caracteristique = Item.Caracteristique(separateItem[4], Convert.ToInt64(separateItem[1], 16));
                    withBlock1.CaracteristiqueBrute = separateItem[4];
                    withBlock1.Categorie = VarItems(withBlock1.IdObjet).Catégorie;

                    if (separateItem[3] != "")
                        withBlock1.Equipement = Convert.ToInt64(separateItem[3], 16);
                    else if (VarItems(Convert.ToInt64(separateItem[1], 16)).Catégorie == "24")
                        withBlock1.Equipement = "Quete";
                    else
                        withBlock1.Equipement = "";
                }

                if (withBlock.Personnage.Cadeau.ContainsKey(separateData[1]))
                    withBlock.Personnage.Cadeau(separateData[1]) = NewItem;
                else
                    withBlock.Personnage.Cadeau.Add(separateData[1], NewItem);
            }
        }
    }
}
