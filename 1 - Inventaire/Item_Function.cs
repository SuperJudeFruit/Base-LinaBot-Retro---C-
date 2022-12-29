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

namespace Item_Function
{
    static class Item_Function
    {
        public static bool Supprime(string nomID, int quantite = 999999)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Item_Variable.Information Pair in withBlock.Inventaire.Item.Values)
                    {
                        if (Pair.Nom.ToLower == nomID.ToLower() || Pair.IdObjet.ToString == nomID || Pair.IdUnique.ToString == nomID)
                        {
                            if (Pair.Equipement == "")
                            {
                                if (quantite > Pair.Quantiter)
                                    quantite = Pair.Quantiter;

                                EcritureMessage("(Bot)", "Suppression de l'item " + Pair.Nom + " x " + quantite, Color.Lime);

                                return withBlock.Mitm.Send("Od" + Pair.IdUnique + "|" + quantite,
                                {
                                    "OR",
                                    "OQ"
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

        public static bool Retire(string nomID, int quantite = 999999)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Item_Variable.Information Pair in withBlock.Echange.Moi.Inventaire.Item.Values)
                    {
                        if (Pair.Nom.ToLower == nomID.ToLower() || Pair.IdObjet.ToString == nomID || Pair.IdUnique.ToString == nomID)
                        {
                            if (Pair.Equipement == "")
                            {
                                if (quantite > Pair.Quantiter)
                                    quantite = Pair.Quantiter;

                                EcritureMessage("(Bot)", "Retire l'item " + Pair.Nom + " x " + quantite, Color.Lime);

                                return withBlock.Mitm.Send("EMO-" + Pair.IdUnique + "|" + quantite,
                                {
                                    "OQ",
                                    "EsKO-",
                                    "EMKO-",
                                    "OAKO"
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

        public static bool Depose(string nomID, int quantite = 999999)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Item_Variable.Information Pair in withBlock.Inventaire.Item.Values)
                    {
                        if (Pair.Nom.ToLower == nomID.ToLower() || Pair.IdObjet.ToString == nomID || Pair.IdUnique.ToString == nomID || nomID.ToLower() == "all")
                        {
                            if (Pair.Equipement == "")
                            {
                                if (quantite > Pair.Quantiter)
                                    quantite = Pair.Quantiter;

                                EcritureMessage("(Bot)", "Dépose l'item " + Pair.Nom + " x " + quantite, Color.Lime);

                                return withBlock.Mitm.Send("EMO+" + Pair.IdUnique + "|" + quantite,
                                {
                                    "OR",
                                    "OQ",
                                    "EMKO+",
                                    "EsKO+"
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

        public static bool Existe(string nomID)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Item_Variable.Information Pair in withBlock.Inventaire.Item.Values)
                    {
                        if (Pair.Nom.ToLower == nomID.ToLower() || Pair.IdObjet.ToString == nomID || Pair.IdUnique.ToString == nomID)
                            return true;
                    }
                }
                catch (Exception ex)
                {
                }

                return false;
            }
        }

        public static bool Equipe(string nomID, int numero)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Item_Variable.Information Pair in withBlock.Inventaire.Item.Values)
                    {
                        if (Pair.Nom.ToLower == nomID.ToLower() || Pair.IdUnique.ToString == nomID || Pair.IdObjet.ToString == nomID)
                        {
                            if (Pair.Equipement == "")
                                return withBlock.Mitm.Send("OM" + Pair.IdUnique + "|" + numero,
                                {
                                    "OM",
                                    "OCO"
                                });
                            else
                                return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                return false;
            }
        }

        public static bool Desequipe(string nomID, int numero)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Item_Variable.Information Pair in withBlock.Inventaire.Item.Values)
                    {
                        if (Pair.Nom.ToLower == nomID.ToLower() || Pair.IdUnique.ToString == nomID || Pair.IdObjet.ToString == nomID)
                        {
                            if (Pair.Equipement != "" && Pair.Equipement == numero)
                            {
                                EcritureMessage("(Bot)", "Déséquipe l'item : " + Pair.Nom, Color.Lime);

                                return withBlock.Mitm.Send("OM" + Pair.IdUnique + "|-1",
                                {
                                    "OM"
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

        public static bool Jette(string nomID, int quantité = 999999)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Item_Variable.Information Pair in withBlock.Inventaire.Item.Values)
                    {
                        if (Pair.Nom.ToLower == nomID.ToLower() || Pair.IdObjet.ToString == nomID || Pair.IdUnique.ToString == nomID)
                        {
                            if (Pair.Equipement == "")
                            {
                                if (quantité > Pair.Quantiter)
                                    quantité = Pair.Quantiter;

                                EcritureMessage("(Bot)", "Jette l'item " + Pair.Nom + " x " + quantité, Color.Lime);

                                return withBlock.Mitm.Send("OD" + Pair.IdUnique + "|" + quantité,
                                {
                                    "OR",
                                    "OQ",
                                    "GDO+"
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

        public static bool Utilise(string nomID)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Item_Variable.Information Pair in withBlock.Inventaire.Item.Values)
                    {
                        if (Pair.Nom.ToLower == nomID.ToLower() || Pair.IdObjet.ToString == nomID || Pair.IdUnique.ToString == nomID)
                        {
                            EcritureMessage("(Bot)", "Utilisation de l'item " + Pair.Nom, Color.Lime);

                            return withBlock.Mitm.Send("OU" + Pair.IdUnique + "|",
                            {
                                "OQ",
                                "OR",
                                "GDM"
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
