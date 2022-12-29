using System;
using Microsoft.VisualBasic;

namespace Interaction
{
    static class Interaction
    {
        public static void Information(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // GDF | 206     ; 3    ; 0
                    // GDF | Cellule ; Etat ; Utilisation                

                    string[] separateData = Strings.Split(data, "|");

                    for (var i = 1; i <= separateData.Length - 1; i++)
                    {
                        string[] separate = Strings.Split(separateData[i], ";");

                        if (withBlock.Interaction.ContainsKey(separate[0]))
                        {
                            {
                                var withBlock1 = withBlock.Interaction(separate[0]);
                                withBlock1.Disponible = separate[2];

                                switch (separate[1]) // State now
                                {
                                    case 2 // In Cut
                                   :
                                        {
                                            withBlock1.Etat = "En Utilisation";
                                            break;
                                        }

                                    case 3:
                                    case 4 // Cut
                             :
                                        {
                                            withBlock1.Disponible = "Indisponible";
                                            break;
                                        }

                                    default:
                                        {
                                            withBlock1.Disponible = "Disponible";

                                            EcritureMessage("(Bot)", "L'état de la ressource '" + withBlock1.Nom + "' est inconnu, cellid : " + separate[0] + " Etat : " + separate[1], Color.Red);
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Interaction_Information", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
