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

namespace Connexion_Function
{
    static class Connexion_Function
    {
        public static bool Connexion(string nomDeCompte, string motDePasse, string serveur, string nomDuPersonnage)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Connexion.Connecter == false && withBlock.Connexion.Connexion == false && withBlock.Connexion.Authentification == false)
                    {
                        {
                            var withBlock1 = withBlock.Personnage;
                            withBlock1.NomDeCompte = nomDeCompte;
                            withBlock1.MotDePasse = motDePasse;
                            withBlock1.Serveur = serveur;
                            withBlock1.NomDuPersonnage = nomDuPersonnage;
                        }

                        withBlock.Mitm.CreateSocketAuthentification(withBlock.Socket_Authentification, VarServeur("Authentification").IP, VarServeur("Authentification").Port, withBlock.Proxy);

                        return true;
                    }
                }
                catch (Exception ex)
                {
                }

                return false;
            }
        }

        public static bool Deconnexion()
        {
            {
                var withBlock = Bot.Connexion;
                try
                {
                    if (withBlock.Connecter)
                    {
                        Bot.Socket.Connexion_Game(false);

                        Task.Delay(5000).Wait();

                        return withBlock.Connecter;
                    }

                    if (withBlock.Connexion)
                    {
                        Bot.Socket.Connexion_Game(false);

                        Task.Delay(5000).Wait();

                        return withBlock.Connexion;
                    }

                    if (withBlock.Authentification)
                    {
                        Bot.Socket_Authentification.Connexion_Game(false);

                        Task.Delay(5000).Wait();

                        return withBlock.Authentification;
                    }
                }
                catch (Exception ex)
                {
                }

                return false;
            }
        }

        public static bool Cadeau(string ID_Nom, string Nom_ID_Personnage)
        {
            try
            {
                {
                    var withBlock = Bot;

                    // AG  1                 | 123456789
                    // AG  2                 | 123456789
                    // AG Numéro de l'objet | Id Personnage
                    // recv : BN AGK AAK 
                    foreach (KeyValuePair<string, Item_Variable.Information> pair in withBlock.Personnage.Cadeau)
                    {
                        if (pair.Value.Nom.ToLower == ID_Nom.ToLower() || pair.Value.IdObjet == ID_Nom)
                            return withBlock.Mitm.Send("AG" + pair.Key + "|" + withBlock.Personnage.ID,
                            {
                                "AGK",
                                "AAK"
                            });
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }
    }
}
