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

namespace Groupe_Function
{
    static class Groupe_Function
    {
        public static bool Invite(string nom)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Groupe.Invitation == false)
                    {
                        if (withBlock.Groupe.Membre.Count < 8)
                            return withBlock.Mitm.Send("PI" + nom,
                            {
                                "PIK"
                            },
                            {
                                "PIEa",
                                "PIEn"
                            });
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Function_Invite", ex.Message);
                }

                return withBlock.Groupe.Invitation;
            }
        }

        public static bool Refuse()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Groupe.Invitation)
                        return withBlock.Mitm.Send("PR",
                        {
                            "PR"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Function_Refuse", ex.Message);
                }

                return withBlock.Groupe.Invitation;
            }
        }

        public static bool Arrete()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Groupe.Invitation)
                        return withBlock.Mitm.Send("PR",
                        {
                            "PR"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Function_Arrete", ex.Message);
                }

                return withBlock.Groupe.Invitation;
            }
        }

        public static bool Accepte()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Groupe.Invitation)
                        return withBlock.Mitm.Send("PA",
                        {
                            "PCK"
                        },
                        {
                            "PR"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Function_Accepte", ex.Message);
                }

                return withBlock.Groupe.Groupe;
            }
        }

        public static bool Quitte()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Groupe.Groupe)
                        return withBlock.Mitm.Send("PV",
                        {
                            "PV"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Function_Quitte", ex.Message);
                }

                return !withBlock.Groupe.Groupe;
            }
        }

        public static bool SuivezMoiTous()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Groupe.Groupe)
                        return withBlock.Mitm.Send("PG+" + withBlock.Personnage.ID,
                        {
                            "PFK",
                            "Im052"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Function_SuivezMoiTous", ex.Message);
                }

                return false;
            }
        }

        public static bool ArretezTousDeMeSuivre()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Groupe.Groupe)
                        return withBlock.Mitm.Send("PG-" + withBlock.Personnage.ID,
                        {
                            "PFK",
                            "Im053",
                            "IC"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Function_ArretezTousDeMeSuivre", ex.Message);
                }

                return false;
            }
        }

        public static bool SuivreLeDeplacement(string nomID)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Groupe.Groupe)
                    {
                        foreach (Groupe_Variable.Information pair in CopyGroupe(withBlock.Groupe.Membre).Values)
                        {
                            if (pair.Nom.ToLower == nomID.ToLower() || pair.ID == nomID)
                                return withBlock.Mitm.Send("PF+" + pair.ID,
                                {
                                    "IC",
                                    "PFK"
                                });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Function_SuivreLeDeplacement", ex.Message);
                }

                return false;
            }
        }

        public static bool NePlusSuivreLeDeplacement(string nomID)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Groupe.Groupe)
                    {
                        foreach (Groupe_Variable.Information pair in CopyGroupe(withBlock.Groupe.Membre).Values)
                        {
                            if (pair.Nom.ToLower == nomID.ToLower() || pair.ID == nomID)
                                return withBlock.Mitm.Send("PF-" + pair.ID,
                                {
                                    "IC",
                                    "PFK"
                                });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Function_NePlusSuivreLeDeplacement", ex.Message);
                }

                return false;
            }
        }

        public static bool SuivezLeTous(string nomID)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Groupe.Groupe)
                    {
                        foreach (Groupe_Variable.Information pair in CopyGroupe(withBlock.Groupe.Membre).Values)
                        {
                            if (pair.Nom.ToLower == nomID.ToLower() || pair.ID == nomID)
                                return withBlock.Mitm.Send("PG+" + pair.ID,
                                {
                                    "IC",
                                    "PFK"
                                });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Function_SuivezLeTous", ex.Message);
                }

                return false;
            }
        }

        public static bool ArretezTousDeLeSuivre(string nomID)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Groupe.Groupe)
                    {
                        foreach (Groupe_Variable.Information pair in CopyGroupe(withBlock.Groupe.Membre).Values)
                        {
                            if (pair.Nom.ToLower == nomID.ToLower() || pair.ID == nomID)
                                return withBlock.Mitm.Send("PG-" + pair.ID,
                                {
                                    "IC",
                                    "PFK"
                                });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Function_ArretezTousDeLeSuivre", ex.Message);
                }

                return false;
            }
        }

        public static bool Exclure(string nomID)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Groupe.Groupe)
                    {
                        foreach (Groupe_Variable.Information pair in CopyGroupe(withBlock.Groupe.Membre).Values)
                        {
                            if (pair.Nom.ToLower == nomID.ToLower() || pair.ID == nomID)
                                return withBlock.Mitm.Send("PV" + pair.ID,
                                {
                                    "PM-",
                                    "PV"
                                });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Groupe_Function_Exclure", ex.Message);
                }

                return false;
            }
        }

        private delegate void DlgF();
        public static Dictionary<int, Groupe_Variable.Information> CopyGroupe(Dictionary<int, Groupe_Variable.Information> dico)
        {
            Dictionary<int, Groupe_Variable.Information> newDico = new Dictionary<int, Groupe_Variable.Information>();

            try
            {
                foreach (KeyValuePair<int, Groupe_Variable.Information> pair in dico)

                    newDico.Add(pair.Key, pair.Value);
            }
            catch (Exception ex)
            {
            }

            return newDico;
        }
    }
}
