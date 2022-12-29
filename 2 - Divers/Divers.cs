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
using System.Net.Sockets;
using System.Net;
using Org.Mentalis.Network.ProxySocket;
using System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

public static class Divers
{
    private delegate void dlgDivers();
    private delegate void dlgFDivers();



    public static string ChiffreSeparation(string chiffre, string separateur)
    {
        string resultat = "";
        chiffre = Strings.StrReverse(chiffre);

        try
        {
            for (var i = 1; i <= chiffre.Length; i += 3)

                resultat += Strings.Mid(chiffre, i, 3) + separateur;
        }
        catch (Exception ex)
        {
        }

        return Strings.Mid(Strings.StrReverse(resultat), 2);
    }

    public static void ErreurFichier(string nomJoueur, string nomErreur, string erreur)
    {
        try
        {
            EcritureMessage("[Erreur]", "Une erreur est survenue, veuillez envoyez les fichiers qui se trouve dans le dossier 'Erreur' à l'administrateur.", Color.Red);

            // Si le dossier erreur n'existe pas, alors je le créer
            if (!System.IO.Directory.Exists(Application.StartupPath + @"\AllErreur"))
                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\AllErreur");

            // J'ouvre le fichier pour y écrire se que je souhaite
            System.IO.StreamWriter swEcriture = new System.IO.StreamWriter(Application.StartupPath + @"\AllErreur/" + nomJoueur + "_" + nomErreur + ".txt");

            swEcriture.WriteLine(erreur);

            // Puis je le ferme.
            swEcriture.Close();
        }
        catch (Exception ex)
        {
        }
    }

    public static void EcritureMessage(string indice, string message, Color couleur)
    {
        {
            var withBlock = Bot;
            try
            {
                if (LinaBot.InvokeRequired)
                    LinaBot.Invoke(new dlgDivers(() => EcritureMessage(indice, message, couleur)));
                else
                {
                    if (withBlock.Tchat.Message.Count > 500)
                        withBlock.Tchat.Message.Clear();

                    Tchat_Variable.Information newTchat = new Tchat_Variable.Information();

                    {
                        var withBlock1 = newTchat;
                        withBlock1.Nom_Joueur = "";
                        withBlock1.Item = "";
                        withBlock1.Id_Joueur = 0;
                        withBlock1.Canal = indice;
                        withBlock1.Message = message;
                        withBlock1.Couleur = couleur;
                        withBlock1.Heure = DateTime.TimeOfDay;
                    }

                    // With .FrmUser.RichTextBox_Tchat

                    // .SelectionColor = couleur
                    // .AppendText("[" & TimeOfDay & "] " & indice & " " & message & vbCrLf)
                    // .ScrollToCaret()

                    // End With

                    withBlock.Tchat.Message = newTchat;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    public static void EcritureMessageSocket(string indice, string message, Color couleur)
    {
        {
            var withBlock = Bot;
            try
            {
                if (LinaBot.InvokeRequired)
                    LinaBot.Invoke(new dlgDivers(() => EcritureMessageSocket(indice, message, couleur)));
                else
                {
                    Tchat_Variable.Information newInformations = new Tchat_Variable.Information();

                    {
                        var withBlock1 = newInformations;
                        withBlock1.Canal = indice;
                        withBlock1.Couleur = couleur;
                        withBlock1.Message = message;
                        withBlock1.Heure = DateTime.TimeOfDay;
                    }

                    withBlock.Console.Message = newInformations;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    public static string AsciiDecoder(string msg)
    {
        string msgFinal = "";

        try
        {
            int iMax = msg.Length;
            int i = 0;
            while ((i < iMax))
            {
                char caractC = msg[i];
                int caractI = Strings.Asc(caractC);
                int nbLettreCode = 1;
                if ((caractI & 128) == 0)
                    msgFinal += Strings.ChrW(caractI);
                else
                {
                    int temp = 64;
                    int codecPremLettre = 63;
                    while ((caractI & temp))
                    {
                        temp >>= 1;
                        codecPremLettre = codecPremLettre ^ temp;
                        nbLettreCode += 1;
                    }
                    codecPremLettre = codecPremLettre & 255;
                    int caractIFinal = caractI & codecPremLettre;
                    nbLettreCode -= 1;
                    i += 1;
                    while ((nbLettreCode != 0))
                    {
                        caractC = msg[i];
                        caractI = Strings.Asc(caractC);
                        caractIFinal <<= 6;
                        caractIFinal = caractIFinal | (caractI & 63);
                        nbLettreCode -= 1;
                        i += 1;
                    }
                    msgFinal += Strings.ChrW(caractIFinal);
                }
                i += nbLettreCode;
            }
        }
        catch (Exception ex)
        {
        }


        return msgFinal.Replace("%27", "'").Replace("%C3%A9", "é").Replace("%2C", ",").Replace("%3F", "?").Replace("%C3%A8", "é").Replace("%29", "]").Replace("%28", "[").Replace("%E2%80%99", "'");
    } // Provient de Maxoubot.

    public static Socket ProxySocketUtilisateur(string ipAnkama, int portAnkama, string proxyIP, int proxyPort, string nomUtilisateur, string motDePasse)
    {
        ProxySocket monProxy = new ProxySocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        {
            ProxyEndPoint = new IPEndPoint(IPAddress.Parse(proxyIP), proxyPort)
        };

        if (nomUtilisateur != "")
        {
            monProxy.ProxyUser = nomUtilisateur;
            monProxy.ProxyPass = motDePasse;
        }

        monProxy.ProxyType = ProxyTypes.Socks5;

        monProxy.Connect(ipAnkama, portAnkama);

        return monProxy;
    }


    /// <summary>
    ///     ''' Retourne l'ID ou la categorie de l'item.
    ///     ''' </summary>
    ///     ''' <param name="index">Indique le numéro du bot.</param>
    ///     ''' <param name="nomID">Le nom de l'item ou son ID.</param>
    ///     ''' <param name="choix">l'un des choix suivant : <br/>
    ///     ''' ID = Retourne l'ID de l'item.
    ///     ''' Categorie = Retourne la categorie de l'item.</param>
    ///     ''' <returns>
    ///     ''' Retourne l'ID ou la categorie selon le nom ou l'ID de l'item.
    ///     ''' </returns>
    public static string RetourneItemNomIdCategorie(string nomID, string choix)
    {
        {
            var withBlock = Bot;
            foreach (sItems pair in VarItems.Values)
            {
                if (pair.Nom.ToLower == nomID.ToLower() || pair.ID == nomID)
                {
                    switch (choix.ToLower())
                    {
                        case "id":
                            {
                                return pair.ID;
                            }

                        case "categorie":
                        case "categori":
                            {
                                return pair.Catégorie;
                            }
                    }
                }
            }
        }

        return "";
    }
}
