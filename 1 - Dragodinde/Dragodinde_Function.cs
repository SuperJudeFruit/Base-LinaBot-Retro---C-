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

namespace Dragodinde_Function
{
    public class Dragodinde_Function
    {
        public bool Monte()
        {
            try
            {
                {
                    var withBlock = Bot;
                    if (withBlock.Dragodinde.Monter == false)
                        return withBlock.Mitm.Send("Rr",
                        {
                            "Rr+"
                        });
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public bool Descend()
        {
            try
            {
                {
                    var withBlock = Bot;
                    if (withBlock.Dragodinde.Monter == true)
                        return withBlock.Mitm.Send("Rr",
                        {
                            "Rr-"
                        });
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public bool XP(int Valeur)
        {
            try
            {
                {
                    var withBlock = Bot;
                    if (withBlock.Dragodinde.Equiper.Montable)
                        return withBlock.Mitm.Send("Rx" + Valeur,
                        {
                            "Rx"
                        });
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public static bool Nom(string _Nom)
        {
            try
            {
                if (_Nom != "")
                    return Bot.Mitm.Send("Rn" + _Nom,
                    {
                        "Rn"
                    });
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public bool Libere()
        {
            try
            {
                {
                    var withBlock = Bot;
                    if (withBlock.Dragodinde.Equiper.IdUnique > -1)
                        return withBlock.Mitm.Send("Rf",
                        {
                            "Re-",
                            "Rx0"
                        });
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public bool Castre()
        {
            try
            {
                {
                    var withBlock = Bot;
                    if (withBlock.Dragodinde.Equiper.IdUnique > -1)
                        return withBlock.Mitm.Send("Rc",
                        {
                            "Re+"
                        });
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public bool Inventaire()
        {
            try
            {
                {
                    var withBlock = Bot;
                    if (withBlock.Dragodinde.Equiper.IdUnique > -1)
                        return withBlock.Mitm.Send("ER15|",
                        {
                            "ECK15"
                        });
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        private Dragodinde_Variable.Information Information(int IdUnique)
        {
            try
            {
                {
                    var withBlock = Bot;
                    Dictionary<int, Item_Variable.Information> newInventaire = withBlock.Inventaire.Item;

                    if (newInventaire.ContainsKey(IdUnique))
                    {
                        withBlock.Mitm.Send(newInventaire[IdUnique].Caracteristique.Dragodinde.IdUnique,
                        {
                            "Rd"
                        });

                        return withBlock.Dragodinde.Information;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return new Dragodinde_Variable.Information();
        }


        public bool Etable_Equipe(string nomIDType)
        {
            try
            {
                {
                    var withBlock = Bot;
                    foreach (KeyValuePair<int, Dragodinde_Variable.Information> pair in withBlock.Dragodinde.Etable)
                    {
                        if (pair.Value.ID.ToString == nomIDType || pair.Value.Type.ToLower == nomIDType.ToLower() || pair.Value.Nom.ToLower == nomIDType.ToLower())
                            return withBlock.Mitm.Send("Erg" + pair.Key,
                            {
                                "Re+",
                                "Ee-"
                            });
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public bool Etable_Enclos(string nomIDType)
        {
            try
            {
                {
                    var withBlock = Bot;
                    foreach (KeyValuePair<int, Dragodinde_Variable.Information> pair in withBlock.Dragodinde.Etable)
                    {
                        if (pair.Value.ID.ToString == nomIDType || pair.Value.Type.ToLower == nomIDType.ToLower() || pair.Value.Nom.ToLower == nomIDType.ToLower())
                            return withBlock.Mitm.Send("Efp" + pair.Key,
                            {
                                "Ef+",
                                "Ee-"
                            });
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public bool Etable_Echanger(string nomIDType)
        {
            try
            {
                {
                    var withBlock = Bot;
                    foreach (KeyValuePair<int, Dragodinde_Variable.Information> pair in withBlock.Dragodinde.Etable)
                    {
                        if (pair.Value.ID.ToString == nomIDType || pair.Value.Type.ToLower == nomIDType.ToLower() || pair.Value.Nom.ToLower == nomIDType.ToLower())
                            return withBlock.Mitm.Send("Erc" + pair.Key,
                            {
                                "OAKO",
                                "Ee-"
                            });
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }



        public bool Equipe_Etable(string nomIDType)
        {
            try
            {
                {
                    var withBlock = Bot;
                    if (withBlock.Dragodinde.Equiper.ID.ToString == nomIDType || withBlock.Dragodinde.Equiper.Type.ToLower == nomIDType.ToLower() || withBlock.Dragodinde.Equiper.Nom.ToLower == nomIDType.ToLower())
                        return withBlock.Mitm.Send("Erp" + withBlock.Dragodinde.Equiper.IdUnique,
                        {
                            "Re-",
                            "Ee+"
                        });
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }



        public bool Enclos_Etable(string nomIDType)
        {
            try
            {
                {
                    var withBlock = Bot;
                    foreach (KeyValuePair<int, Dragodinde_Variable.Information> pair in withBlock.Dragodinde.Enclos)
                    {
                        if (pair.Value.ID.ToString == nomIDType || pair.Value.Type.ToLower == nomIDType.ToLower() || pair.Value.Nom.ToLower == nomIDType.ToLower())
                            return withBlock.Mitm.Send("Efg" + pair.Key,
                            {
                                "Ee+"
                            });
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }



        public bool Echange_Etable(string nomIDType)
        {
            try
            {
                {
                    var withBlock = Bot;
                    foreach (KeyValuePair<int, Item_Variable.Information> pair in withBlock.Inventaire.Item)
                    {
                        if (pair.Value.IdObjet.ToString == nomIDType.ToLower() || pair.Value.IdUnique.ToString == nomIDType.ToLower() || pair.Value.Caracteristique.Dragodinde.Nom.ToLower == nomIDType.ToLower() || pair.Value.Nom.ToLower == nomIDType.ToLower())
                            return withBlock.Mitm.Send("ErC" + pair.Key,
                            {
                                "Ee+"
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
