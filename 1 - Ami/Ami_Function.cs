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

namespace Ami_Function
{
    public class Ami_Function
    {
        public bool Ouvre(string Valeur)
        {
            try
            {
                {
                    var withBlock = Bot;
                    switch (Valeur.ToLower())
                    {
                        case "ami":
                        case "amie":
                            {
                                return withBlock.Mitm.Send("FL",
                                {
                                    "FL"
                                });
                            }

                        case "ennemi":
                        case "ennemie":
                            {
                                return withBlock.Mitm.Send("iL",
                                {
                                    "iL"
                                });
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Ami_Function_Ouvre", ex.Message);
            }

            return false;
        }

        public bool Supprime(string pseudoNom, string choix)
        {
            try
            {
                {
                    var withBlock = Bot;
                    foreach (Ami_Variable.Information Pair in choix.ToLower().StartsWith("ami") ? Bot.Ami.Liste : Bot.Ennemi.Liste.Values)
                    {
                        if (Pair.Pseudo.ToLower == pseudoNom.ToLower() || Pair.Nom.ToLower == pseudoNom.ToLower())
                        {
                            switch (choix.ToLower())
                            {
                                case "ami":
                                case "amie":
                                    {
                                        return withBlock.Mitm.Send("FD*" + Pair.Pseudo,
                                        {
                                            "FDK"
                                        },
                                        {
                                            "FAEf"
                                        });
                                    }

                                case "ennemi":
                                case "ennemie":
                                    {
                                        return withBlock.Mitm.Send("iD*" + Pair.Pseudo,
                                        {
                                            "iDK"
                                        },
                                        {
                                            "iAEf"
                                        });
                                    }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Ami_Function_Supprime", ex.Message);
            }

            return false;
        }

        public bool Ajoute(string pseudoNom, string choix)
        {
            try
            {
                {
                    var withBlock = Bot;
                    switch (choix.ToLower())
                    {
                        case "ami":
                        case "amie":
                            {
                                return withBlock.Mitm.Send("FA" + pseudoNom,
                                {
                                    "FAEa",
                                    "FAK"
                                },
                                {
                                    "FAEf"
                                });
                            }

                        case "ennemi":
                        case "ennemie":
                            {
                                return withBlock.Mitm.Send("iA%" + pseudoNom,
                                {
                                    "iAEa",
                                    "iAK"
                                },
                                {
                                    "iAEf"
                                });
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Ami_Function_Ajoute", ex.Message);
            }

            return false;
        }

        public bool Information(string Nom)
        {
            try
            {
                return Bot.Mitm.Send("BW" + Nom,
                {
                    "BWK"
                },
                {
                    "BWE"
                });
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Ami_Function_Information", ex.Message);
            }

            return false;
        }

        public bool Rejoindre(string Nom)
        {
            try
            {
                return Bot.Mitm.Send("FJF" + Nom,
                {
                    "GDM"
                },
                {
                    "Im113",
                    "Im137"
                });
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Ami_Function_Rejoindre", ex.Message);
            }

            return false;
        }

        public bool Averti(bool Valeur)
        {
            try
            {
                return Bot.Mitm.Send("FO" + Valeur ? "+" : "-",
                {
                    "BN"
                });
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage, "Ami_Function_Averti", ex.Message);
            }

            return false;
        }
    }
}
