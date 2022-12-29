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

namespace Zaap_Function
{
    static class Zaap_Function
    {
        public static bool Utiliser()
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Interaction_Variable.Base pair in withBlock.Map.Interaction.Values)
                    {
                        if (pair.Nom == "Zaap")
                        {
                            return withBlock.Mitm.Send("GA500" + pair.Cellule + ";114",
                            {
                                "WC",
                                "Im024"
                            });

                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Zaap_Function_Utiliser", ex.Message);
                }

                return false;
            }
        }

        public static bool Sauvegarder()
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Interaction_Variable.Base pair in withBlock.Map.Interaction.Values)
                    {
                        if (pair.Nom == "Zaap")
                            return withBlock.Mitm.Send("GA500" + pair.Cellule + ";44",
                            {
                                "Im06"
                            });
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Zaap_Function_Sauvegarder", ex.Message);
                }

                return false;
            }
        }

        public static bool Destination(string map)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Personnage.EnInteraction)
                    {
                        if (!Information.IsNumeric(map))
                        {
                            foreach (KeyValuePair<int, string> pair in VarMap)
                            {
                                if (pair.Value == map)
                                {
                                    if (withBlock.ZaapI.ContainsKey(pair.Key))
                                    {
                                        map = pair.Key;

                                        break;
                                    }
                                }
                            }
                        }

                        if (withBlock.ZaapI.ContainsKey(map))
                        {
                            if (withBlock.Personnage.Kamas >= withBlock.ZaapI(map))
                                return withBlock.Mitm.Send("WU" + map,
                                {
                                    "GDM",
                                    "WV"
                                });
                            else
                                EcritureMessage("(Bot)", "Vous avez pas asse de kamas pour utiliser le zaap, kamas requis : " + withBlock.ZaapI(map), Color.Red);
                        }
                        else
                            EcritureMessage("(Bot)", "Le bot n'a pas trouvé la map voulu dans les maps enregistré du Zaap.", Color.Red);
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Zaap_Function_Destination", ex.Message);
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
                    if (withBlock.Personnage.EnInteraction)
                        return withBlock.Mitm.Send("WV",
                        {
                            "WV"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Zaap_Function_Quitte", ex.Message);
                }

                return false;
            }
        }
    }
}
