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

namespace Metier_Function
{
    static class Metier_Function
    {
        public static bool Option(string nomID, bool payant, bool gratuitSurEchec, bool neFournitAucuneRessource, int nombreIngredientMinimum)
        {
            {
                var withBlock = Bot;
                try
                {
                    int numeroMetier = 0;
                    int NbrOption;

                    foreach (Metier_Variable.Base pair in withBlock.Metier.Values)
                    {
                        if (pair.Nom.ToLower == nomID.ToLower() || pair.ID == nomID)
                        {
                            if (payant)
                                NbrOption += 1;

                            if (gratuitSurEchec)
                                NbrOption += 2;

                            if (neFournitAucuneRessource)
                                NbrOption += 4;

                            return withBlock.Mitm.Send("JO" + numeroMetier + "|" + NbrOption + "|" + nombreIngredientMinimum,
                            {
                                "JO" + numeroMetier
                            });
                        }

                        numeroMetier += 1;
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Metier_Function_[Option]", ex.Message);
                }

                return false;
            }
        }

        public static bool Public(bool Activer)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (Activer)
                        return withBlock.Mitm.Send("EW+",
                        {
                            "EW+"
                        });
                    else
                        return withBlock.Mitm.Send("EW-",
                        {
                            "EW-"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Metier_Function_Public", ex.Message);
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
                    foreach (Metier_Variable.Base pair in withBlock.Metier.Values)
                    {
                        if (pair.Nom.ToLower == nomID.ToLower() || pair.ID == nomID)
                            return true;
                    }
                }
                catch (Exception ex)
                {
                }

                return false;
            }
        }

        public static int Niveau(string nomID)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Metier_Variable.Base pair in withBlock.Metier.Values)
                    {
                        if (pair.Nom.ToLower == nomID.ToLower() || pair.ID == nomID)
                            return pair.Niveau;
                    }
                }
                catch (Exception ex)
                {
                }

                return 0;
            }
        }
    }
}
