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

namespace Interaction_Function
{
    static class Interaction_Function
    {
        public static bool Interaction(string nomInteraction, string action, string cellule = "")
        {
            {
                var withBlock = Bot;
                try
                {
                    foreach (Interaction_Variable.Base Pair in withBlock.Map.Interaction.Values)
                    {
                        if (Pair.Nom.ToLower == nomInteraction.ToLower())
                        {
                            if (Pair.Disponible)
                            {
                                foreach (KeyValuePair<string, int> PairValue in VarInteraction(Pair.Sprite).DicoInteraction)
                                {
                                    if (PairValue.Key.ToLower() == action.ToLower())
                                    {
                                        if (cellule == "")
                                            cellule = Pair.Cellule;

                                        Map_Function.Map_Function newDeplacement = new Map_Function.Map_Function();
                                        newDeplacement.Deplacement(cellule);

                                        return withBlock.Mitm.Send("GA500" + cellule + ";" + PairValue.Value,
                                        {
                                            "GA1;500;" + withBlock.Personnage.ID.ToString,
                                            "GA0;500;" + withBlock.Personnage.ID.ToString,
                                            "GDF|" + cellule + ";2;0",
                                            "Wc",
                                            "WC",
                                            "ECK16" // Enclos
                                        },
                                        {
                                            "GDF|" + cellule + ";3;0",
                                            "GDF|" + cellule + ";4;0",
                                            "BN",
                                            "GA;0"
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Interaction_Function_Interaction", ex.Message);
                }

                return false;
            }
        }

        public static bool Quitte(string choix)
        {
            {
                var withBlock = Bot;
                try
                {
                    switch (choix.ToLower())
                    {
                        default:
                            {
                                return withBlock.Mitm.Send("EV",
                                {
                                    "EV"
                                });
                            }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Interaction_Function_Quitte", ex.Message);
                }

                return false;
            }
        }
    }
}
