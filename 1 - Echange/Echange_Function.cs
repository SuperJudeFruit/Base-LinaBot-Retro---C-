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

namespace Echange_Function
{
    static class Echange_Function
    {
        public static bool Invite(string nom)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Echange.Invitation == false && withBlock.Echange.Echange == false)
                    {
                        foreach (KeyValuePair<int, Map_Variable.Entite> pair in withBlock.Map.Entite)
                        {
                            if (pair.Value.Nom.ToLower == nom.ToLower())
                                return withBlock.Mitm.Send("ER1|" + pair.Key,
                                {
                                    "ERK"
                                },
                                {
                                    "EREO"
                                });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Function_Invite", ex.Message);
                }

                return withBlock.Echange.Invitation;
            }
        }

        public static bool Refuse()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Echange.Invitation)
                        return withBlock.Mitm.Send("EV",
                        {
                            "EV"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Function_Refuse", ex.Message);
                }

                return !withBlock.Echange.Invitation;
            }
        }

        public static bool Arrete()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Echange.Echange)
                        return withBlock.Mitm.Send("EV",
                        {
                            "EV"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Function_Arrete", ex.Message);
                }

                return !withBlock.Echange.Echange;
            }
        }

        public static bool Accepte()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Echange.Invitation)
                        return withBlock.Mitm.Send("EA",
                        {
                            "ECK1"
                        },
                        {
                            "EV"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Function_Accepte", ex.Message);
                }

                return withBlock.Echange.Echange;
            }
        }

        public static bool Kamas(string quantite)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (quantite > withBlock.Personnage.Kamas)
                        quantite = withBlock.Personnage.Kamas;

                    return withBlock.Mitm.Send("EMG" + quantite,
                    {
                        "EMKG",
                        "EsKG"
                    });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Function_Kamas", ex.Message);
                }

                return false;
            }
        }

        public static bool Valide()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Echange.Echange && withBlock.Echange.Moi.Valider == false)
                        return withBlock.Mitm.Send("EK",
                        {
                            "EK1"
                        },
                        {
                            "EK0"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Echange_Function_Valide", ex.Message);
                }

                return withBlock.Echange.Moi.Valider;
            }
        }
    }
}
