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

namespace Pnj
{
    namespace Dialogue
    {
        static class Pnj_Dialogue
        {
            public static void Dialogue(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // DCK -2  
                        // DCK ID sur la map

                        withBlock.Pnj.Parler = true;

                        // J'affiche le nom du PNJ auquel je parle.
                        string idUnique = Strings.Mid(data, 4);

                        if (withBlock.Map.Entite.ContainsKey(idUnique))
                            EcritureMessage("[Dofus]", "Je parle actuellement avec " + withBlock.Map.Entite(idUnique).Nom, Color.Green);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_Dialogue_Dialogue", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Question_Reponse(string data)
            {
                {
                    var withBlock = Bot.Pnj;
                    try
                    {

                        // DQ 318        ; 449                                           |   259     ;    329    ;
                        // DQ ID Réponse ; Information à mettre dans le dialogue de base | Réponse 1 ; Réponse 2 ; etc....

                        withBlock.Reponse.Clear();
                        withBlock.IdReponse = 0;

                        data = Strings.Mid(data, 3);

                        string[] separateData = Strings.Split(data, "|");
                        string[] separate = Strings.Split(separateData[0], ";");

                        withBlock.IdReponse = separate[0];

                        if (data.Contains('|'))
                        {
                            separateData = Strings.Split(separateData[1], ";");

                            for (var i = 0; i <= separateData.Length - 1; i++)
                            {
                                withBlock.Reponse.Add(separateData[i]);

                                EcritureMessage("[Dofus]", i + 1 + ") " + VarPnjRéponse(separateData[i]), Color.Green);
                            }
                        }
                        else
                            EcritureMessage("(Bot)", "Il n'y a plus aucune réponse disponible pour ce Pnj.", Color.Green);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(Bot.Personnage.NomDuPersonnage, "Pnj_Dialogue_Question_Reponse", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Fin(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // DV

                        {
                            var withBlock1 = withBlock.Pnj;
                            withBlock1.Parler = false;
                            withBlock1.Reponse.Clear();
                            withBlock1.IdReponse = 0;
                        }

                        EcritureMessage("[Dofus]", "Fin du dialogue avec le Pnj.", Color.Green);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_Dialogue_Fin", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void En_Cours(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // DCE

                        {
                            var withBlock1 = withBlock.Pnj;
                            withBlock1.Parler = true;
                        }

                        EcritureMessage("[Dofus]", "Vous êtes déjà en dialogue.", Color.Red);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_Dialogue_En_Cours", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }
        }
    }

    namespace Acheter_Vendre
    {
        static class Pnj_Acheter_Vendre
        {
            public static void Information(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // EL 596      ; 60#1#4##1d4+0   | 1860;60#1#14##1d20+0 
                        // EL Id Objet ; Caractéristique | Item Suivant

                        string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");

                        for (var i = 0; i <= separateData.Length - 1; i++)
                        {
                            string[] separate = Strings.Split(separateData[i], ";");

                            Pnj_Variable.Acheter_Vendre newPnjAcheterVendre = new Pnj_Variable.Acheter_Vendre();

                            {
                                var withBlock1 = newPnjAcheterVendre;
                                withBlock1.ID = separate[0];
                                withBlock1.Caracteristique = Item.Caracteristique(separate[1], separate[0]);
                                withBlock1.CaracteristiqueBrute = separate[1];
                                withBlock1.Prix = 0;
                            }

                            withBlock.Pnj.AcheterVendre_Item.Add(separate[0], newPnjAcheterVendre);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_Acheter_Vendre_Information", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Achat(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // EBK

                        EcritureMessage("[Dofus]", "Achat effectué", Color.Green);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_Acheter_Vendre_Achat", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Vente(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // ESK

                        EcritureMessage("[Dofus]", "Vente effectuée", Color.Green);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_Acheter_Vendre_Vente", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }
        }
    }

    namespace HotelDeVente
    {
        static class Pnj_HotelDeVente
        {
            public static void AcheterVendre(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // ECK10 | 1            , 10            , 100            ; 2            , 3            , 4            ; 2.0      ; 1000            ; 20                ; -1 ; 350
                        // ECK10 | Quantité * 1 , Quantité * 10 , Quantité * 100 ; Id Catégorie , Id Catégorie , Id Catégorie ; Taxe (%) ; Niveau Max Item ; Nbr item vendable ; ?  ; Nbr heure Max


                        string[] separateData = Strings.Split(data, "|");
                        string[] separateInfo = Strings.Split(separateData[1], ";");

                        if (separateData[0] == "ECK10")
                            withBlock.Pnj.Vendre = true;
                        else
                            withBlock.Pnj.Acheter = true;

                        {
                            var withBlock1 = withBlock.Pnj.Vendre ? withBlock.Pnj.Hdv_Vendre : withBlock.Pnj.Hdv_Acheter;
                            string[] separate = Strings.Split(separateInfo[0], ",");

                            {
                                var withBlock2 = withBlock1.Quantiter;
                                withBlock2.x1 = separate[0];
                                withBlock2.x10 = separate[1];
                                withBlock2.x100 = separate[2];
                            }

                            separate = Strings.Split(separateInfo[1], ",");

                            withBlock1.Liste.Categorie.Clear();

                            for (var i = 0; i <= separate.Length - 1; i++)

                                withBlock1.Liste.Categorie.Add(separate[i]);

                            withBlock1.Taxe = separateInfo[2];
                            withBlock1.NiveauMax = separateInfo[3];
                            withBlock1.StockEnMagasin = separateInfo[4];
                            withBlock1.HeureMax = separateInfo[6];
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_HotelDeVente_AcheterVendre", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void PrixMoyen(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // EHP 180      | 4836469
                        // EHP Id Objet | Prix Moyen

                        string[] separateData = Strings.Split(data, "|");

                        if (withBlock.Pnj.Vendre)
                            withBlock.Pnj.Hdv_Vendre.PrixMoyen = separateData[1];
                        else
                            withBlock.Pnj.Hdv_Acheter.PrixMoyen = separateData[1];

                        EcritureMessage("[Dofus]", "Prix Moyen constaté dans cet hôtel : " + separateData[1] + " kamas/u.", Color.Green);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_HotelDeVente_PrixMoyen", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }
        }

        namespace Vendre
        {
            static class Pnj_HotelDeVente_Vendre
            {
                public static void Information(string data)
                {
                    {
                        var withBlock = Bot;
                        try
                        {

                            // EL 11759152  ; 100      ; 304      ;                 ; 10000 ; 1800          | 11803628;100;304;;10000;1800  
                            // EL Id Unique ; Quantité ; Id Objet ; Caractéristique ; Prix  ; Temps restant | Suivant

                            string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");

                            {
                                var withBlock1 = withBlock.Pnj.Hdv_Vendre.Liste.Item;
                                withBlock1.Clear();

                                for (var i = 1; i <= separateData.Length - 1; i++)
                                {
                                    string[] separate = Strings.Split(separateData[i], ";");

                                    Pnj_Variable.Item newHDV = new Pnj_Variable.Item();

                                    {
                                        var withBlock2 = newHDV;
                                        withBlock2.IDUnique = separate[0];
                                        withBlock2.Quantiter = separate[1];
                                        withBlock2.IdObjet = separate[2];
                                        withBlock2.Nom = VarItems(separate[2]).Nom;
                                        withBlock2.Caracteristique = Item.Caracteristique(separate[3], separate[2]);
                                        withBlock2.Prix.Actuelle = separate[4];
                                        withBlock2.TempsRestant = separate[5];
                                    }

                                    withBlock1.Add(separate[0], newHDV);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_HotelDeVente_Information", data + Constants.vbCrLf + ex.Message);
                        }
                    }
                }

                public static void Ajoute(string data)
                {
                    {
                        var withBlock = Bot;
                        try
                        {

                            // EmK+ 11759152  | 100      | 304      |          | 10000 | 1800 
                            // EmK+ id unique | quantité | id objet | caract ? | Prix  | Temps Restant

                            {
                                var withBlock1 = withBlock.Pnj.Hdv_Vendre.Liste.Item;
                                string[] separateData = Strings.Split(Strings.Mid(data, 5), "|");

                                Pnj_Variable.Item newHDV = new Pnj_Variable.Item();

                                {
                                    var withBlock2 = newHDV;
                                    withBlock2.IDUnique = separateData[0];
                                    withBlock2.Quantiter = separateData[1];
                                    withBlock2.IdObjet = separateData[2];
                                    withBlock2.Nom = VarItems(separateData[2]).Nom;
                                    withBlock2.Caracteristique = Item.Caracteristique(separateData[3], separateData[2]);
                                    withBlock2.Prix.Actuelle = separateData[4];
                                    withBlock2.TempsRestant = separateData[5];
                                }

                                withBlock1.Add(separateData[0], newHDV);
                            }
                        }
                        catch (Exception ex)
                        {
                            ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_HotelDeVente_Ajoute", data + Constants.vbCrLf + ex.Message);
                        }
                    }
                }

                public static void Supprime(string data)
                {
                    {
                        var withBlock = Bot;
                        try
                        {

                            // EmK- 11791321
                            // EmK- Id Unique

                            if (withBlock.Pnj.Hdv_Vendre.Liste.Item.ContainsKey(Strings.Mid(data, 5)))
                                withBlock.Pnj.Hdv_Vendre.Liste.Item.Remove(Strings.Mid(data, 5));
                        }
                        catch (Exception ex)
                        {
                            ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_HotelDeVente_Supprime", data + Constants.vbCrLf + ex.Message);
                        }
                    }
                }
            }
        }

        namespace Acheter
        {
            static class Pnj_HotelDeVente_Acheter
            {
                public static void Categorie(string data)
                {
                    {
                        var withBlock = Bot;
                        try
                        {

                            // EHL 2         | 829    ; 1351    ; etc...
                            // EHL Categorie | IdItem ; Id Item ; etc...

                            string[] separateData = Strings.Split(data, "|");

                            EcritureMessage("[Dofus]", "Vous avez sélectionner la catégorie : " + VarItemsCategorieNom(Strings.Mid(separateData[0], 4, separateData[0].Length)), Color.Green);

                            separateData = Strings.Split(separateData[1], ";");

                            {
                                var withBlock1 = withBlock.Pnj.Hdv_Acheter.Liste;
                                withBlock1.Item.Clear();

                                for (var i = 0; i <= separateData.Length - 1; i++)

                                    withBlock1.ID.Add(separateData[i]);
                            }
                        }
                        catch (Exception ex)
                        {
                            ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_HotelDeVente_Acheter_Categorie", data + Constants.vbCrLf + ex.Message);
                        }
                    }
                }

                public static void Information(string data)
                {
                    {
                        var withBlock = Bot;
                        try
                        {

                            // EHl 180      | 7335643   ; 6f#1###0d0+1,64#10#14##1d5+15 ; 4150000  ;           ;            | Suivant
                            // EHl ID Objet | Id Unique ; Caracteristique               ; Prix * 1 ; Prix * 10 ; Prix * 100 | Suivant

                            string[] separateData = Strings.Split(data, "|");

                            {
                                var withBlock1 = withBlock.Pnj.Hdv_Acheter.Liste.Item;
                                withBlock1.Clear();

                                for (var i = 1; i <= separateData.Length - 1; i++)
                                {
                                    string[] separate = Strings.Split(separateData[i], ";");

                                    Pnj_Variable.Item newHDV = new Pnj_Variable.Item();

                                    {
                                        var withBlock2 = newHDV;
                                        withBlock2.IDUnique = separate[0];
                                        withBlock2.Caracteristique = Item.Caracteristique(separate[1], Strings.Mid(separateData[0], 4));
                                        withBlock2.IdObjet = Strings.Mid(separateData[0], 4);
                                        withBlock2.Nom = VarItems(Strings.Mid(separateData[0], 4)).Nom;

                                        {
                                            var withBlock3 = withBlock2.Prix;
                                            withBlock3.x1 = separate[2];
                                            withBlock3.x10 = separate[3];
                                            withBlock3.x100 = separate[4];
                                        }
                                    }

                                    withBlock1.Add(separate[0], newHDV);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_HotelDeVente_Acheter_Information", data + Constants.vbCrLf + ex.Message);
                        }
                    }
                }

                public static void Recherche_Echoue(string data)
                {
                    {
                        var withBlock = Bot;
                        try
                        {
                            EcritureMessage("[Dofus]", "L'objet recherché n'est pas en vente dans cet hôtel des ventes.", Color.Red);
                        }
                        catch (Exception ex)
                        {
                            ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Pnj_HotelDeVente_Acheter_Recherche_Echoue", data + Constants.vbCrLf + ex.Message);
                        }
                    }
                }
            }
        }
    }
}
