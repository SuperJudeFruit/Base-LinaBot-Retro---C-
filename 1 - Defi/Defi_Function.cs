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

namespace Defi_Function
{
    public class Defi_Function
    {
        public bool Annule()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Defi.Invitation)
                        return withBlock.Mitm.Send("GQ",
                        {
                            "GE",
                            "GV",
                            "GDM"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Defi_Function_Annule", ex.Message);
                }
            }

            return false;
        }

        public bool Abandonne()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Defi.Combat)
                        return withBlock.Mitm.Send("GQ",
                        {
                            "GE",
                            "GV",
                            "GDM"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Defi_Function_Abandonne", ex.Message);
                }
            }

            return false;
        }

        public bool Refuse()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Defi.Invitation)
                        return withBlock.Mitm.Send("GA902" + withBlock.Defi.ID,
                        {
                            "GA;902"
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Defi_Function_Refuse", ex.Message);
                }
            }

            return false;
        }

        public bool Accepte()
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Defi.Invitation)
                        return withBlock.Mitm.Send("GA901" + withBlock.Defi.ID,
                        {
                            "GA;901;" + withBlock.Personnage.ID.ToString + ";" + withBlock.Defi.ID.ToString
                        });
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Defi_Function_Accepte", ex.Message);
                }
            }

            return false;
        }

        public bool Invite(string nom)
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Map_Variable.Entite pair in withBlock.Map.Entite.Values)
                    {
                        if (pair.Nom.ToLower == nom.ToLower())
                            return withBlock.Mitm.Send("GA900" + pair.IDUnique,
                            {
                                "GA;900;" + withBlock.Personnage.ID.ToString + ";" + pair.IDUnique.ToString
                            });// Défi reçu.
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Defi_Function_Invite", ex.Message);
                }
            }

            return false;
        }
    }
}
