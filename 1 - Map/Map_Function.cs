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

namespace Map_Function
{
    public class Map_Function
    {
        public bool Deplacement(string celluleDirection)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Map.Deplacement == false)
                    {
                        var macell = withBlock.Map.Entite(withBlock.Personnage.ID).Cellule;

                        switch (celluleDirection.ToLower())
                        {
                            case "haut":
                                {
                                    celluleDirection = withBlock.Map.Haut;
                                    break;
                                }

                            case "bas":
                                {
                                    celluleDirection = withBlock.Map.Bas;
                                    break;
                                }

                            case "gauche":
                                {
                                    celluleDirection = withBlock.Map.Gauche;
                                    break;
                                }

                            case "droite":
                                {
                                    celluleDirection = withBlock.Map.Droite;
                                    break;
                                }
                        }

                        Pathfinding pather = new Pathfinding();
                        string path = pather.Pathing(celluleDirection);

                        if (path != "")
                        {
                            withBlock.Map.Bloque.Reset();

                            withBlock.Mitm.Send("GA001" + path,
                            {
                                "GA0;1;" + withBlock.Personnage.ID.ToString
                            },
                            {
                                "GA;0"
                            });
                        }

                        return withBlock.Map.Bloque.WaitOne(30000);
                    }
                }
                catch (Exception ex)
                {
                }

                return false;
            }
        }

        public bool ChangerOrientation(int index, string monOrientation)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Combat.Combat == false && withBlock.Recolte.Recolte == false)
                        return withBlock.Mitm.Send("eD" + Orientation(monOrientation),
                        {
                            "eD" + withBlock.Personnage.ID
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "ChangerOrientation", ex.Message);
                }

                return false;
            }
        }

        private static string Orientation(string choix)
        {
            try
            {
                switch (choix.ToLower())
                {
                    case "0":
                    case "est":
                        {
                            return Information.IsNumeric(choix) ? "est" : "0";
                        }

                    case "1":
                    case "sudest":
                        {
                            return Information.IsNumeric(choix) ? "sudest" : "1";
                        }

                    case "2":
                    case "sud":
                        {
                            return Information.IsNumeric(choix) ? "sud" : "2";
                        }

                    case "3":
                    case "sudouest":
                        {
                            return Information.IsNumeric(choix) ? "sudouest" : "3";
                        }

                    case "4":
                    case "ouest":
                        {
                            return Information.IsNumeric(choix) ? "ouest" : "4";
                        }

                    case "5":
                    case "nordouest":
                        {
                            return Information.IsNumeric(choix) ? "nordouest" : "5";
                        }

                    case "6":
                    case "nord":
                        {
                            return Information.IsNumeric(choix) ? "nord" : "6";
                        }

                    case "7":
                    case "nordest":
                        {
                            return Information.IsNumeric(choix) ? "nordest" : "7";
                        }

                    default:
                        {
                            return Information.IsNumeric(choix) ? "sud" : "2";
                        }
                }
            }
            catch (Exception ex)
            {
            }

            return "1";
        }

        public bool Agresser(int index, string nomIDJoueur)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Map_Variable.Entite pair in withBlock.Map.Entite.Values)
                    {
                        if (pair.Nom.ToLower == nomIDJoueur.ToLower() || pair.IDUnique.ToString == nomIDJoueur)
                            return withBlock.Mitm.Send("GA906" + pair.IDUnique,
                            {
                                "GA;906;" + withBlock.Personnage.ID + ";" + pair.IDUnique
                            },
                            {
                                "GA;906;" + withBlock.Personnage.ID + ";p"
                            });
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "FunctionMap_Agresser", ex.Message);
                }

                return false;
            }
        }
    }
}
