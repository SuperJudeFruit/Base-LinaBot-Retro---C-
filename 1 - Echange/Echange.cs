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

namespace Echange
{
    static class Echange
    {
        public static void Reception(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // ERK 1234567    | 7654321     | 1
                    // ERK Id Lanceur | Id Receveur | ?

                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                    withBlock.Echange.Invitation = true;

                    if (separateData[0] != withBlock.Personnage.ID)
                    {
                        withBlock.Echange.ID = separateData[0];
                        EcritureMessage("[Dofus]", withBlock.Map.Entite(separateData[0]).Nom + " te propose de faire un échange. acceptes-tu ?", Color.Green);
                    }
                    else
                        EcritureMessage("[Dofus]", "En Attente de la réponse de " + withBlock.Map.Entite(separateData[1]).Nom + " pour un échange...", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Reception", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Impossible(string data)
        {
            try
            {

                // EREO

                EcritureMessage("[Dofus]", "Ce joueur est déjà en échange.", Color.Green);
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Echange_Impossible", data + Constants.vbCrLf + ex.Message);
            }
        }

        public static void Accepter(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // ECK 1
                    // ECK Echange avec un joueur

                    {
                        var withBlock1 = withBlock.Echange;
                        withBlock1.Echange = true;
                        withBlock1.Invitation = false;
                        withBlock1.Interaction = "Joueur";
                        withBlock1.ID = -1;
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Accepter", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Annuler(string data)
        {
            try
            {

                // EV

                Bot.Echange = new Echange_Variable.Base();

                EcritureMessage("[Dofus]", "Echange annulé.", Color.Red);
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Echange_Annuler", data + Constants.vbCrLf + ex.Message);
            }
        }

        public static void Effectuer(string data)
        {
            try
            {

                // EVa

                Bot.Echange = new Echange_Variable.Base();

                EcritureMessage("[Dofus]", "Echange effectué.", Color.Green);
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Echange_Effectuer", data + Constants.vbCrLf + ex.Message);
            }
        }

        public static void Validation(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // EK 1      1234567
                    // EK 1 ou 0 Id perso

                    if (Strings.Mid(data, 4) == withBlock.Personnage.ID)
                        withBlock.Echange.Moi.Valider = Strings.Mid(data, 3, 1);
                    else
                        withBlock.Echange.Lui.Valider = Strings.Mid(data, 3, 1);
                }

                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Validation", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}

namespace Echange_Lui
{
    static class Echange_Lui
    {
        public static void Ajoute(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // EmKO+ 40514824  | 1        | 7659     |
                    // EmKO+ Id Unique | Quantité | Id Objet | Caractéristique

                    string[] separateData = Strings.Split(Strings.Mid(data, 6), "|");

                    Item_Variable.Information newItem = new Item_Variable.Information();

                    {
                        var withBlock1 = newItem;
                        withBlock1.IdObjet = separateData[2];

                        withBlock1.IdUnique = separateData[0];

                        withBlock1.Nom = VarItems(Convert.ToInt64(separateData[2])).Nom;

                        withBlock1.Quantiter = separateData[1];

                        withBlock1.Caracteristique = Item.Caracteristique(separateData[3], separateData[2]);

                        withBlock1.CaracteristiqueBrute = separateData[3];

                        withBlock1.Categorie = VarItems(withBlock1.IdObjet).Catégorie;

                        withBlock1.Equipement = "";
                    }

                    if (withBlock.Echange.Lui.Inventaire.Existe(separateData[0]))
                        withBlock.Echange.Lui.Inventaire.Modifie = newItem;
                    else
                        withBlock.Echange.Lui.Inventaire.Ajoute = newItem;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Lui_Ajoute", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Supprime(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // EmKO- 40420233
                    // EmKO- Id Unique

                    string idUnique = Strings.Mid(data, 6);

                    if (withBlock.Echange.Lui.Inventaire.Existe(idUnique))
                        withBlock.Echange.Lui.Inventaire.Supprimer = idUnique;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Lui_Supprime", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Kamas(string data)
        {
            try
            {


                // EmKG 5
                // EmKG Kamas

                Bot.Echange.Lui.Kamas = Strings.Mid(data, 5);
            }

            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Echange_Lui_Kamas", data + Constants.vbCrLf + ex.Message);
            }
        }
    }
}

namespace Echange_Moi
{
    static class Echange_Moi
    {
        public static void Ajoute(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // EMKO+ 40420233  | 20 
                    // EMKO+ Id Unique | Quantité

                    string[] separateData = Strings.Split(Strings.Mid(data, 6), "|");

                    Item_Variable.Information newItem = withBlock.Inventaire.Item(separateData[0]);

                    newItem.Quantiter = separateData[1];

                    if (withBlock.Echange.Moi.Inventaire.Existe(separateData[0]))
                        withBlock.Echange.Moi.Inventaire.Modifie = newItem;
                    else
                        withBlock.Echange.Moi.Inventaire.Ajoute = newItem;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Moi_Ajoute", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Supprime(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // EMKO- 40420233
                    // EMKO- Id Unique

                    string idUnique = Strings.Mid(data, 6);

                    if (withBlock.Echange.Moi.Inventaire.Existe(idUnique))
                        withBlock.Echange.Moi.Inventaire.Supprimer = idUnique;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Moi_Supprime", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Kamas(string data)
        {
            try
            {

                // Echange
                // EMKG 5
                // EMKG kamas

                Bot.Echange.Moi.Kamas = Strings.Mid(data, 5);
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Echange_Moi_Kamas", data + Constants.vbCrLf + ex.Message);
            }
        }
    }
}

namespace Echange_Banque
{
    static class Echange_Moi_Banque
    {
        public static void Ajoute(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // EsKO+ 78415959  | 2        | 393      |
                    // EsKO+ Id Unique | Quantité | Id Objet | Caracteristique

                    string[] separateData = Strings.Split(Strings.Mid(data, 6), "|");

                    Item_Variable.Information newItem = new Item_Variable.Information();

                    {
                        var withBlock1 = newItem;
                        withBlock1.IdObjet = separateData[2];

                        withBlock1.IdUnique = separateData[0];

                        withBlock1.Nom = VarItems(separateData[2]).Nom;

                        withBlock1.Quantiter = separateData[1];

                        withBlock1.Caracteristique = Item.Caracteristique(separateData[3], separateData[2]);

                        withBlock1.CaracteristiqueBrute = separateData[3];

                        withBlock1.Categorie = VarItems(withBlock1.IdObjet).Catégorie;

                        withBlock1.Equipement = "";
                    }

                    if (withBlock.Echange.Moi.Inventaire.Existe(separateData[0]))
                        withBlock.Echange.Moi.Inventaire.Modifie = newItem;
                    else
                        withBlock.Echange.Moi.Inventaire.Ajoute = newItem;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Banque_Ajoute", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Supprime(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // EsKO- 78415959 
                    // EsKO- Id Unique 

                    string idUnique = Strings.Mid(data, 6);

                    if (withBlock.Echange.Moi.Inventaire.Existe(idUnique))
                        withBlock.Echange.Moi.Inventaire.Supprimer = idUnique;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Banque_Supprime", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Kamas(string data)
        {
            try
            {

                // Banque/Coffre
                // EsKG 5
                // EsKG kamas

                Bot.Echange.Moi.Kamas = Strings.Mid(data, 5);
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Echange_Banque_Kamas", data + Constants.vbCrLf + ex.Message);
            }
        }
    }
}
