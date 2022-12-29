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

namespace Maison_Function
{
    static class Maison_Function
    {
        public static bool Fermer()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Maison.Ouverture)
                        return withBlock.Mitm.Send("EV",
                        {
                            "EV"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Function_Fermer", ex.Message);
                }

                return false;
            }
        }

        public static bool Acheter(int Prix)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (KeyValuePair<string, Maison_Variable.Maison> pair in withBlock.Maison.Map)
                    {
                        if (pair.Value.Prix <= Prix && withBlock.Personnage.Kamas >= pair.Value.Prix)
                            return withBlock.Mitm.Send("hB" + pair.Value.Prix,
                            {
                                "hP" + pair.Key + "|" + withBlock.Personnage.Pseudo,
                                "hL+" + pair.Key,
                                "hBK" + pair.Key
                            });
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Function_Acheter", ex.Message);
                }

                return false;
            }
        }

        public static bool Vendre(int Prix)
        {
            {
                var withBlock = Bot;
                try
                {
                    return withBlock.Mitm.Send("hS" + Prix,
                    {
                        "hSK"
                    });
                }

                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Function_Vendre", ex.Message);
                }

                return false;
            }
        }

        public static bool Code_Change(string Code)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (Code == "")
                        Code = "-";

                    return withBlock.Mitm.Send("KK1|" + Code,
                    {
                        "KKK"
                    });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Function_Code_Change", ex.Message);
                }

                return false;
            }
        }

        public static bool Parametre_Guilde()
        {
            {
                var withBlock = Bot;
                try
                {
                    return withBlock.Mitm.Send("hG",
                    {
                        "hG" + withBlock.Maison.Personnelle.ID
                    });
                }

                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Function_Parametre_Guilde", ex.Message);
                }

                return false;
            }
        }

        public static bool Parametre_Gestion(bool Active)
        {
            {
                var withBlock = Bot;
                try
                {
                    return withBlock.Mitm.Send("hG" + Active ? "+" : "-",
                    {
                        "hG" + withBlock.Maison.Personnelle.ID + ";" + withBlock.Guilde.Nom
                    });
                }

                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Function_Parametre_Gestion", ex.Message);
                }

                return false;
            }
        }

        public static bool Parametre_Droits(string Droits)
        {
            {
                var withBlock = Bot;
                try
                {
                    int resultat = 0;

                    string[] separate = Strings.Split(Droits, "|");

                    for (var i = 0; i <= separate.Length - 1; i++)
                    {
                        string[] separateDroits = Strings.Split(separate[i], " = ");

                        switch (separateDroits[0].ToLower())
                        {
                            case "pour les membres de la guilde":
                                {
                                    resultat += 2;
                                    break;
                                }

                            case "pour les autres":
                                {
                                    resultat += 4;
                                    break;
                                }

                            case "autoriser l'acces aux membres de la guilde sans code (maison)":
                                {
                                    resultat += 8;
                                    break;
                                }

                            case "interdire l'acces aux non-membres de la guilde (maison)":
                                {
                                    resultat += 16;
                                    break;
                                }

                            case "autoriser l'acces aux membres de la guilde sans code (coffre)":
                                {
                                    resultat += 32;
                                    break;
                                }

                            case "interdire l'acces aux non-membres de la guilde (coffre)":
                                {
                                    resultat += 64;
                                    break;
                                }

                            case "autoriser les membres de la guilde a se teleporter dans la maison":
                                {
                                    resultat += 128;
                                    break;
                                }

                            case "autoriser les membres de la guilde a se reposer dans la maison":
                                {
                                    resultat += 256;
                                    break;
                                }
                        }
                    }

                    return withBlock.Mitm.Send("hG" + resultat,
                    {
                        "BN"
                    });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Function_Parametre_Droits", ex.Message);
                }

                return false;
            }
        }

        public static bool Code_Porte(string Code)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Maison.Ouverture)
                        return withBlock.Mitm.Send("KK0|" + Code,
                        {
                            "GDM"
                        },
                        {
                            "KKE"
                        });
                }

                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Function_Code_Porte", ex.Message);
                }

                return false;
            }
        }

        public static bool Code_Coffre(string Code)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Maison.Ouverture)
                        return withBlock.Mitm.Send("KK0|" + Code,
                        {
                            "ECK5"
                        },
                        {
                            "KKE",
                            "Im120"
                        });
                }

                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Maison_Function_Code_Coffre", ex.Message);
                }

                return false;
            }
        }
    }
}
