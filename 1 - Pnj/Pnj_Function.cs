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

namespace Pnj_Function
{
    namespace Dialogue
    {
        static class Pnj_Function_Dialogue
        {
            public static bool Parler(string nomID)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.Parler == false)
                        {
                            foreach (Map_Variable.Entite Pair in withBlock.Map.Entite.Values)
                            {
                                if (Pair.Nom.ToLower == nomID.ToLower() || Pair.ID == nomID)
                                {
                                    return withBlock.Mitm.Send("DC" + Pair.IDUnique,
                                    {
                                        "DCK",
                                        "DCE"
                                    }); // Déjà en dialogue.

                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Parler", ex.Message);
                    }

                    return withBlock.Pnj.Parler;
                }
            }

            public static bool Reponse(string phrase)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.Parler)
                        {
                            if (phrase.ToLower().StartsWith("terminer la discussion"))
                                return QuitteDialogue();

                            if (withBlock.Pnj.Reponse.Count > 0)
                            {
                                for (var i = 0; i <= withBlock.Pnj.Reponse.Count - 1; i++)
                                {
                                    if (phrase.ToLower() == VarPnjRéponse(withBlock.Pnj.Reponse(i)).ToLower)
                                    {
                                        EcritureMessage("(Bot)", "Réponse : " + VarPnjRéponse(withBlock.Pnj.Reponse(i)), Color.Orange);

                                        return withBlock.Mitm.Send("DR" + withBlock.Pnj.IdReponse + "|" + withBlock.Pnj.Reponse(i),
                                        {
                                            "DQ",
                                            "DV",
                                            "DR"
                                        }); // ?
                                    }
                                }
                            }
                            else
                                return QuitteDialogue();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    return false;
                }
            }

            public static bool QuitteDialogue()
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.Parler)
                            return withBlock.Mitm.Send("DV",
                            {
                                "DV"
                            });// Fin du dialogue
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "QuitteDialogue", ex.Message);
                    }

                    return !withBlock.Pnj.Parler;
                }
            }
        }
    }

    namespace AcheterVendre
    {
        static class Pnj_Function_AcheterVendre
        {
            public static bool AcheterVendre(string nomID)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.AcheterVendre == false)
                        {
                            foreach (Map_Variable.Entite Pair in withBlock.Map.Entite.Values)
                            {
                                if (Pair.Nom.ToLower == nomID.ToLower() || Pair.ID == nomID)
                                    return withBlock.Mitm.Send("ER0|" + Pair.IDUnique,
                                    {
                                        "ECK10"
                                    });// Reçoit les informations de l'HDV
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    return false;
                }
            }

            public static bool Quitte()
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.AcheterVendre)
                            return withBlock.Mitm.Send("EV",
                            {
                                "EV"
                            });// a quitté le mode "acheter/vendre" du Pnj.
                    }
                    catch (Exception ex)
                    {
                    }

                    return !withBlock.Pnj.AcheterVendre;
                }
            }

            public static bool Vend(string nomID, int quantite)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.AcheterVendre)
                        {
                            foreach (Item_Variable.Information pair in withBlock.Inventaire.Item.Values)
                            {
                                if (pair.Nom.ToLower == nomID.ToLower() || pair.IdObjet == nomID || nomID.ToLower() == "all")
                                {
                                    if (quantite > pair.Quantiter)
                                        quantite = pair.Quantiter;

                                    return withBlock.Mitm.Send("ES" + pair.IdUnique + "|" + quantite,
                                    {
                                        "ESK"
                                    }); // Item Vendu.
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    return false;
                }
            }

            public static bool Achete(string nomID, int quantite)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.AcheterVendre)
                        {
                            foreach (KeyValuePair<int, Pnj_Variable.Acheter_Vendre> pair in withBlock.Pnj.AcheterVendre_Item)
                            {
                                if (pair.Value.ID == nomID || VarItems(pair.Key).Nom.ToLower == nomID.ToLower())
                                    return withBlock.Mitm.Send("EB" + pair.Key + "|" + quantite,
                                    {
                                        "EBK"
                                    },
                                    {
                                        "Im172"
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
    }

    namespace Vendre
    {
        static class Pnj_Function_Vendre
        {
            public static bool Vendre(string nomID)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.Vendre == false)
                        {
                            foreach (Map_Variable.Entite Pair in withBlock.Map.Entite.Values)
                            {
                                if (Pair.Nom.ToLower == nomID.ToLower() || Pair.ID == nomID)
                                    return withBlock.Mitm.Send("ER10|" + Pair.IDUnique,
                                    {
                                        "ECK10"
                                    });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    return withBlock.Pnj.Vendre;
                }
            }

            public static bool Quitte()
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.Vendre)
                            return withBlock.Mitm.Send("EV",
                            {
                                "EV"
                            });
                    }
                    catch (Exception ex)
                    {
                    }

                    return !withBlock.Pnj.Vendre;
                }
            }

            public static bool Vend(string nomID, int quantite, int prix)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        foreach (Item_Variable.Information Pair in withBlock.Inventaire.Item.Values)
                        {
                            if (Pair.Nom.ToLower == nomID.ToLower() || Pair.IdObjet.ToString == nomID)
                            {
                                if (Pair.Equipement == "")
                                {
                                    if (quantite > System.Convert.ToInt32(Pair.Quantiter))
                                    {
                                        EcritureMessage("(Bot)", "Vous n'avez pas asse de quantiter pour vendre.", Color.Red);

                                        return false;
                                    }

                                    prix = quantite * prix;

                                    if (((prix / (double)100) * withBlock.Pnj.Hdv_Vendre.Taxe) > withBlock.Personnage.Kamas)
                                    {
                                        EcritureMessage("(Bot)", "Vous n'avez pas asse de kamas pour payer la taxe !", Color.Gray);

                                        return false;
                                    }

                                    EcritureMessage("(Bot)", "Vente de l'item " + Pair.Nom + " x " + quantite + "au prix de : " + (prix * quantite), Color.Gray);

                                    switch (quantite)
                                    {
                                        case 1:
                                            {
                                                quantite = 1;
                                                break;
                                            }

                                        case 10:
                                            {
                                                quantite = 2;
                                                break;
                                            }

                                        case 100:
                                            {
                                                quantite = 3;
                                                break;
                                            }
                                    }

                                    withBlock.Mitm.Send("EMO+" + Pair.IdUnique + "|" + quantite + "|" + prix);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    return false;
                }
            }

            public static bool Retirer(string nomID, string quantite)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        foreach (Pnj_Variable.Item Pair in withBlock.Pnj.Hdv_Vendre.Liste.Item.Values)
                        {
                            if (Pair.Nom.ToLower == nomID.ToLower() || Pair.IdObjet.ToString == nomID)
                            {
                                if (quantite > Pair.Quantiter)
                                    quantite = Pair.Quantiter;

                                EcritureMessage("(Bot)", "Retire l'item " + Pair.Nom + " x " + quantite, Color.Lime);

                                return withBlock.Mitm.Send("EMO-" + Pair.IDUnique + "|" + quantite);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    return false;
                }
            }

            public static bool Selectionne(string nomID)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        foreach (Pnj_Variable.Item Pair in withBlock.Pnj.Hdv_Vendre.Liste.Item.Values)
                        {
                            if (Pair.Nom.ToLower == nomID.ToLower() || Pair.IdObjet.ToString == nomID)
                            {
                                EcritureMessage("(Bot)", "Sélection de l'item " + Pair.Nom, Color.Lime);


                                return withBlock.Mitm.Send("EHP" + Pair.IdObjet);
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
    }

    namespace Acheter
    {
        static class Pnj_Function_Acheter
        {
            public static bool Acheter(string nomID)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.Acheter == false)
                        {
                            foreach (Map_Variable.Entite Pair in withBlock.Map.Entite.Values)
                            {
                                if (Pair.Nom.ToLower == nomID.ToLower() || Pair.ID == nomID)
                                    return withBlock.Mitm.Send("ER11|" + Pair.IDUnique,
                                    {
                                        "ECK11"
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

            public static bool Quitte()
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.Acheter)
                            return withBlock.Mitm.Send("EV",
                            {
                                "EV"
                            });

                        return withBlock.Pnj.Acheter;
                    }
                    catch (Exception ex)
                    {
                    }

                    return false;
                }
            }

            public static bool Recherche(string nomID)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.Acheter)
                        {
                            foreach (sItems pair in VarItems.Values)
                            {
                                if (pair.ID.ToString == nomID || pair.Nom.ToLower == nomID.ToLower())
                                {
                                    if (withBlock.Mitm.Send("EHS" + pair.Catégorie + "|" + pair.ID,
                                    {
                                        "EHL"
                                    }))
                                        return withBlock.Mitm.Send("EHP" + pair.ID,
                                        {
                                            "EHl"
                                        });

                                    return false;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    return false;
                }
            }

            public static bool Achete(string nomID, int quantite, int prix)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        foreach (Pnj_Variable.Item pair in withBlock.Pnj.Hdv_Acheter.Liste.Item.Values)
                        {
                            if (pair.Nom.ToLower == nomID.ToLower() || pair.IdObjet == nomID)
                            {
                                if (quantite >= 100)
                                {
                                    if (withBlock.Personnage.Kamas >= pair.Prix.x100)
                                        return withBlock.Mitm.Send("EHB" + pair.IDUnique + "|3|" + pair.Prix.x100,
                                        {
                                            "EBK"
                                        });
                                }

                                if (quantite >= 10)
                                {
                                    if (withBlock.Personnage.Kamas >= pair.Prix.x10)
                                        return withBlock.Mitm.Send("EHB" + pair.IDUnique + "|2|" + pair.Prix.x10,
                                        {
                                            "EBK"
                                        });
                                }

                                if (quantite >= 1)
                                {
                                    if (withBlock.Personnage.Kamas >= pair.Prix.x1)
                                        return withBlock.Mitm.Send("EHB" + pair.IDUnique + "|1|" + pair.Prix.x1,
                                        {
                                            "EBK"
                                        });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    return false;
                }
            }

            public static bool Selectionne(string nomID)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.Acheter)
                        {
                            foreach (sItems pair in VarItems.Values)
                            {
                                if (pair.ID.ToString == nomID || pair.Nom.ToLower == nomID.ToLower())
                                {
                                    if (withBlock.Mitm.Send("EHP" + pair.Catégorie))
                                        return withBlock.Mitm.Send("EHl" + pair.Catégorie);


                                    return false;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    return false;
                }
            }

            public static bool Categorie(string nomID)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.Acheter)
                        {
                            foreach (sItems pair in VarItems.Values)
                            {
                                if (pair.ID.ToString == nomID || pair.Nom.ToLower == nomID.ToLower())
                                    return withBlock.Mitm.Send("EHT" + RetourneItemNomIdCategorie(pair.ID, "categorie"));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "PnjSelectionneCategorie", ex.Message);
                    }

                    return false;
                }
            }
        }
    }

    namespace Echange
    {
        static class Pnj_Function_Echange
        {
            public static bool Echanger(string nomID)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock.Pnj.Echange == false)
                        {
                            foreach (Map_Variable.Entite Pair in withBlock.Map.Entite.Values)
                            {
                                if (Pair.Nom.ToLower == nomID.ToLower() || Pair.ID == nomID)
                                    return withBlock.Mitm.Send("ER2|" + Pair.IDUnique,
                                    {
                                        "ECK2"
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
    }
}
