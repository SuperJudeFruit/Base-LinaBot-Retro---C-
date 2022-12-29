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

namespace Sort_Function
{
    static class Sort_Function
    {
        public static bool Up(string nomID)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (!Information.IsNumeric(nomID))
                    {
                        foreach (KeyValuePair<int, Sort_Variable.Information> pair in withBlock.Sort.Sort)
                        {
                            if (pair.Value.Nom.ToLower == nomID.ToLower() || pair.Key == nomID)
                            {
                                nomID = pair.Value.ID;

                                break;
                            }
                        }
                    }

                    if (withBlock.Sort.Sort.ContainsKey(nomID))
                    {
                        if (withBlock.Personnage.Niveau >= withBlock.Sort.Sort(nomID).NiveauRequisUp)
                        {
                            if (withBlock.Personnage.Capital_Sort >= withBlock.Sort.Sort(nomID).Niveau)
                                return withBlock.Mitm.Send("SB" + withBlock.Sort.Sort(nomID).ID,
                                {
                                    "SUK"
                                });
                        }
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Sort_Function_Up", ex.Message);
                }

                return false;
            }
        }

        public static bool Placement(string nomID, string barreSort)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (!Information.IsNumeric(nomID))
                    {
                        foreach (KeyValuePair<int, Sort_Variable.Information> pair in withBlock.Sort.Sort)
                        {
                            if (pair.Value.Nom.ToLower == nomID.ToLower() || pair.Key == nomID)
                            {
                                nomID = pair.Value.ID;

                                break;
                            }
                        }
                    }

                    if (withBlock.Sort.Sort.ContainsKey(nomID.ToLower()))
                        return withBlock.Mitm.Send("SM" + withBlock.Sort.Sort(nomID.ToLower()).ID + "|" + barreSort,
                        {
                            "BN"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Sort_Function_Placement", ex.Message);
                }

                return false;
            }
        }
    }
}
