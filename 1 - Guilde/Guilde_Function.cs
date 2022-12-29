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

namespace Guilde_Function
{
    static class Guilde_Function
    {
        public static bool Ouvre()
        {
            {
                var withBlock = Bot;
                try
                {
                    return withBlock.Mitm.Send("gIG",
                    {
                        "gIG",
                        "gS"
                    });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Ouvre", ex.Message);
                }

                return false;
            }
        }

        public static bool Membres()
        {
            {
                var withBlock = Bot;
                try
                {
                    return withBlock.Mitm.Send("gIM",
                    {
                        "gIM"
                    });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Membres", ex.Message);
                }

                return false;
            }
        }

        public static bool Personnalisation()
        {
            {
                var withBlock = Bot;
                try
                {
                    return withBlock.Mitm.Send("gIB",
                    {
                        "gIB"
                    });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Personnalisation", ex.Message);
                }

                return false;
            }
        }

        public static bool Percepteurs()
        {
            {
                var withBlock = Bot;
                try
                {
                    return withBlock.Mitm.Send("gIT",
                    {
                        "gIT"
                    });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Percepteurs", ex.Message);
                }

                return false;
            }
        }

        public static bool Enclos()
        {
            {
                var withBlock = Bot;
                try
                {
                    withBlock.Mitm.Send("gITV");

                    return withBlock.Mitm.Send("gIF",
                    {
                        "gIF"
                    });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Enclos", ex.Message);
                }

                return false;
            }
        }

        public static bool Maisons()
        {
            {
                var withBlock = Bot;
                try
                {
                    return withBlock.Mitm.Send("gIH",
                    {
                        "gIH"
                    });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Maisons", ex.Message);
                }

                return false;
            }
        }



        public static bool Exclure(string nom)
        {
            {
                var withBlock = Bot;
                try
                {
                    return withBlock.Mitm.Send("gK" + nom,
                    {
                        "gKK"
                    });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Exclure", ex.Message);
                }

                return false;
            }
        }

        public static bool Invite(string nom)
        {
            {
                var withBlock = Bot;
                try
                {
                    withBlock.Guilde.Inviter = nom;

                    return withBlock.Mitm.Send("gJR" + nom,
                    {
                        "gJR"
                    });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Invite", ex.Message);
                }

                return false;
            }
        }

        public static bool Refuse()
        {
            {
                var withBlock = Bot;
                try
                {
                    return withBlock.Mitm.Send("gJE" + withBlock.Guilde.Inviteur,
                    {
                        "gJE"
                    });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Refuse", ex.Message);
                }

                return false;
            }
        }

        public static bool Rang(string membre, string _Rang)
        {
            {
                var withBlock = Bot;
                try
                {
                    string[] rangActuel = new[] { "a l'essai", "meneur", "bras droit", "tresorier", "protecteur", "artisan", "reserviste", "gardien", "eclaireur", "espion", "diplomate", "secretaire", "tueur de familiers", "braconnier", "chercheur de tresor", "voleur", "initie", "assassin", "gouverneur", "muse", "conseiller", "elu", "guide", "mentor", "recruteur", "eleveur", "marchand", "apprenti", "bourreau", "mascotte", "penitent", "tueur de percepteurs", "deserteur", "traitre", "boulet", "larbin", "a l'essai" };

                    for (var i = 0; i <= rangActuel.Length - 1; i++)
                    {
                        if (rangActuel[i] == _Rang.ToLower())
                        {
                            foreach (Guilde_Variable.Membre pair in withBlock.Guilde.Membre.Values)
                            {
                                if (pair.Nom.ToLower == membre.ToLower())
                                {
                                    withBlock.Mitm.Send("gP" + pair.ID + "|" + i + "|" + pair.Experience.Pourcentage + "|" + pair.Droit_Chiffre);

                                    return true;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Rang", ex.Message);
                }

                return false;
            }
        }

        public static bool Experience(string membre, string valeur)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Guilde_Variable.Membre pair in withBlock.Guilde.Membre.Values)
                    {
                        if (pair.Nom.ToLower == membre.ToLower())
                        {
                            withBlock.Mitm.Send("gP" + pair.ID + "|" + pair.Rang_Chiffre + "|" + valeur + "|" + pair.Droit_Chiffre);

                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Experience", ex.Message);
                }

                return false;
            }
        }

        public static bool Droits(string membre, string _Droits, bool Active)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Guilde_Variable.Membre pair in withBlock.Guilde.Membre.Values)
                    {
                        if (pair.Nom.ToLower == membre.ToLower())
                        {
                            withBlock.Mitm.Send("gP" + pair.ID + "|" + pair.Rang_Chiffre + "|" + pair.Experience.Pourcentage + "|" + ReturnDroit(pair.Droit, _Droits, Active));

                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Droits", ex.Message);
                }

                return false;
            }
        }

        private static int ReturnDroit(Guilde_Variable.Droit membre, string Droits, bool Active)
        {
            int valeur = 0;

            try
            {
                {
                    var withBlock = membre;
                    valeur += withBlock.GererLesBoosts == true ? 16384 : 0;
                    valeur += withBlock.GererLesDroits == true ? 8192 : 0;
                    valeur += withBlock.InviterDeNouveauxMembres == true ? 4096 : 0;
                    valeur += withBlock.Bannir == true ? 512 : 0;
                    valeur += withBlock.GererLesRepartitionsXP == true ? 256 : 0;
                    valeur += withBlock.GererSaRepartitionXP == true ? 128 : 0;
                    valeur += withBlock.GererLesRangs == true ? 64 : 0;
                    valeur += withBlock.PoserUnPercepteur == true ? 32 : 0;
                    valeur += withBlock.CollecterSurUnPercepteur == true ? 16 : 0;
                    valeur += withBlock.UtiliserLesEnclos == true ? 8 : 0;
                    valeur += withBlock.AmenagerLesEnclos == true ? 4 : 0;
                    valeur += withBlock.GererLesMonturesDesAutresMembres == true ? 2 : 0;

                    string[] separate = Strings.Split(Droits, " | ");

                    for (var i = 0; i <= separate.Length - 1; i++)
                    {
                        switch (separate[i].ToLower())
                        {
                            case "gerer les boosts":
                                {
                                    valeur += Active == true ? withBlock.GererLesBoosts == true ? 0 : 16384 : withBlock.GererLesBoosts == true ? -16384 : 0;
                                    break;
                                }

                            case "gerer les droits":
                                {
                                    valeur += Active == true ? withBlock.GererLesDroits == true ? 0 : 8192 : withBlock.GererLesDroits == true ? -8192 : 0;
                                    break;
                                }

                            case "inviter de nouveaux membres":
                                {
                                    valeur += Active == true ? withBlock.InviterDeNouveauxMembres == true ? 0 : 4096 : withBlock.InviterDeNouveauxMembres == true ? -4096 : 0;
                                    break;
                                }

                            case "bannir":
                                {
                                    valeur += Active == true ? withBlock.Bannir == true ? 0 : 512 : withBlock.Bannir == true ? -512 : 0;
                                    break;
                                }

                            case "gerer les repartitions d'xp":
                                {
                                    valeur += Active == true ? withBlock.GererLesRepartitionsXP == true ? 0 : 256 : withBlock.GererLesRepartitionsXP == true ? -256 : 0;
                                    break;
                                }

                            case "gerer sa repartition d'xp":
                                {
                                    valeur += Active == true ? withBlock.GererSaRepartitionXP == true ? 0 : 128 : withBlock.GererSaRepartitionXP == true ? -128 : 0;
                                    break;
                                }

                            case "gerer les rangs":
                                {
                                    valeur += Active == true ? withBlock.GererLesRangs == true ? 0 : 64 : withBlock.GererLesRangs == true ? -64 : 0;
                                    break;
                                }

                            case "poser un percepteur":
                                {
                                    valeur += Active == true ? withBlock.PoserUnPercepteur == true ? 0 : 32 : withBlock.PoserUnPercepteur == true ? -32 : 0;
                                    break;
                                }

                            case "collecter sur un percepteur":
                                {
                                    valeur += Active == true ? withBlock.CollecterSurUnPercepteur == true ? 0 : 16 : withBlock.CollecterSurUnPercepteur == true ? -16 : 0;
                                    break;
                                }

                            case "utiliser les enclos":
                                {
                                    valeur += Active == true ? withBlock.UtiliserLesEnclos == true ? 0 : 8 : withBlock.UtiliserLesEnclos == true ? -8 : 0;
                                    break;
                                }

                            case "amenager les enclos":
                                {
                                    valeur += Active == true ? withBlock.AmenagerLesEnclos == true ? 0 : 4 : withBlock.AmenagerLesEnclos == true ? -4 : 0;
                                    break;
                                }

                            case "gerer les montures des autres membres":
                                {
                                    valeur += Active == true ? withBlock.GererLesMonturesDesAutresMembres == true ? 0 : 2 : withBlock.GererLesMonturesDesAutresMembres == true ? -2 : 0;
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return valeur;
        }



        public static bool Up(string choix)
        {
            {
                var withBlock = Bot;
                try
                {
                    switch (choix.ToLower())
                    {
                        case "prospection":
                            {
                                if (withBlock.Guilde.Percepteur.Prospection < 500)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 1)
                                        return withBlock.Mitm.Send("gBp",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "sagesse":
                            {
                                if (withBlock.Guilde.Percepteur.Sagesse < 400)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 1)
                                        return withBlock.Mitm.Send("gBx",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "pods":
                            {
                                if (withBlock.Guilde.Percepteur.Pods < 5000)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 1)
                                        return withBlock.Mitm.Send("gBo",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "nombre de percepteur":
                            {
                                if (withBlock.Guilde.Percepteur.NombreDePercepteur < 50)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 10)
                                        return withBlock.Mitm.Send("gBk",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "armure aqueuse":
                            {
                                if (withBlock.Guilde.Percepteur.ArmureAqueuse < 5)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 5)
                                        return withBlock.Mitm.Send("gB451",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "armure incandescente":
                            {
                                if (withBlock.Guilde.Percepteur.ArmureIncandescente < 5)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 5)
                                        return withBlock.Mitm.Send("gB452",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "armure terrestre":
                            {
                                if (withBlock.Guilde.Percepteur.ArmureTerrestre < 5)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 5)
                                        return withBlock.Mitm.Send("gB453",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "armure venteuse":
                            {
                                if (withBlock.Guilde.Percepteur.ArmureVenteuse < 5)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 5)
                                        return withBlock.Mitm.Send("gB454",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "flamme":
                            {
                                if (withBlock.Guilde.Percepteur.Flamme < 5)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 5)
                                        return withBlock.Mitm.Send("gB455",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "cyclone":
                            {
                                if (withBlock.Guilde.Percepteur.Cyclone < 5)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 5)
                                        return withBlock.Mitm.Send("gB456",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "vague":
                            {
                                if (withBlock.Guilde.Percepteur.Vague < 5)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 5)
                                        return withBlock.Mitm.Send("gB457",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "rocher":
                            {
                                if (withBlock.Guilde.Percepteur.Rocher < 5)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 5)
                                        return withBlock.Mitm.Send("gB458",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "mot soignant":
                            {
                                if (withBlock.Guilde.Percepteur.MotSoignant < 5)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 5)
                                        return withBlock.Mitm.Send("gB459",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "desenvoutement":
                            {
                                if (withBlock.Guilde.Percepteur.Desenvoutement < 5)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 5)
                                        return withBlock.Mitm.Send("gB460",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "compulsion de masse":
                            {
                                if (withBlock.Guilde.Percepteur.CompulsionDeMasse < 5)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 5)
                                        return withBlock.Mitm.Send("gB461",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }

                        case "destabilisation":
                            {
                                if (withBlock.Guilde.Percepteur.Destabilisation < 5)
                                {
                                    if (withBlock.Guilde.Percepteur.ResteARepartir >= 5)
                                        return withBlock.Mitm.Send("gB462",
                                        {
                                            "gIB"
                                        });
                                }

                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Up", ex.Message);
                }

                return false;
            }
        }

        public static bool Poser()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Personnage.Kamas >= withBlock.Guilde.Percepteur.CoutPourPoserPercepteur)
                        return withBlock.Mitm.Send("gH",
                        {
                            "gTS"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Poser", ex.Message);
                }

                return false;
            }
        }

        public static bool Retirer()
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Map_Variable.Entite pair in withBlock.Map.Entite.Values)
                    {
                        if (pair.Classe == "-6")
                            return withBlock.Mitm.Send("gF" + pair.IDUnique,
                            {
                                "gTR"
                            });
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Retirer", ex.Message);
                }

                return false;
            }
        }

        public static bool Relever()
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Map_Variable.Entite pair in withBlock.Map.Entite.Values)
                    {
                        if (pair.Classe == "-6")
                            return withBlock.Mitm.Send("ER8|-88" + pair.IDUnique,
                            {
                                "gTR"
                            });
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Relever", ex.Message);
                }

                return false;
            }
        }





        public static bool Enclos_Teleporter(string enclos)
        {
            {
                var withBlock = Bot;
                try
                {
                    return withBlock.Mitm.Send("gf" + enclos,
                    {
                        "GDM"
                    });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Enclos_Teleporter", ex.Message);
                }

                return false;
            }
        }



        public static bool Maisons_Teleporter(string maisons)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Guilde_Variable.Maison pair in withBlock.Guilde.Maison.Values)
                    {
                        if (pair.Prorietaire.ToLower == maisons.ToLower())
                            return withBlock.Mitm.Send("gh" + pair.ID,
                            {
                                "GDM"
                            });
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Guilde_Function_Maisons_Teleporter", ex.Message);
                }

                return false;
            }
        }
    }
}
