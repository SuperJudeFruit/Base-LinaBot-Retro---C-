using System;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Recolte
{
    static class Recolte
    {
        public static void Information(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // GA0 ; 501     ; 0123456   ; 35         , 18800
                    // GA0 ; Récolte ; ID Joueur ; Cellule ID , Temps en milliseconde

                    string[] separateData = Strings.Split(data, ";");

                    int idPlayer = separateData[2]; // 0123456

                    string send = Strings.Mid(separateData[0], 3); // GA0

                    separateData = Strings.Split(separateData[3], ","); // 35,18800

                    if (idPlayer == withBlock.Personnage.ID)
                    {
                        withBlock.Recolte.Recolte = true;
                        withBlock.Personnage.EnInteraction = true;

                        withBlock.Personnage.InteractionCellule = separateData[0];
                        withBlock.Recolte.Numero += 1;

                        EcritureMessage("(Bot)", "Temps de récolte : " + separateData[1].Length == 4 ? Strings.Mid(separateData[1], 1, 1) : Strings.Mid(separateData[1], 1, 2) + " Seconde(s)", Color.Lime);
                        EcritureMessage("(Bot)", "Récolte n° " + withBlock.Recolte.Numero, Color.Lime);

                        Wait(separateData[1], "GKK" + send, separateData[0]);
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Recolte_Information", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        private async static void Wait(int pause, string envoie, string cellule)
        {
            {
                var withBlock = Bot;
                try
                {
                    await Task.Delay(pause);

                    if (withBlock.Mitm.Send(envoie,
                    {
                        "GDF|" + cellule + ";3;0",
                        "GDF|" + cellule + ";4;0"
                    }))
                    {
                        withBlock.Personnage.EnInteraction = false;
                        withBlock.Recolte.Recolte = false;
                    }
                    else
                        Echec(cellule);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Recolte_Wait", envoie + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Echec(string cellule)
        {
            {
                var withBlock = Bot;
                try
                {
                    if (withBlock.Map.Interaction.ContainsKey(cellule))
                    {
                        withBlock.Map.Interaction(cellule).Disponible = false;

                        EcritureMessage("(Bot)", "Impossible de récolter.", Color.Red);
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Recolte_Echec", ex.Message);
                }
            }
        }

        public static void Drop(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // IQ 1234567   | 2
                    // IQ ID Joueur | Quantité

                    string[] separate = Strings.Split(Strings.Mid(data, 3), "|");

                    if (separate[0] == withBlock.Personnage.ID)
                        EcritureMessage("[Dofus]", "Vous avez obtenue " + separate[1] + " récolte(s).", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Recolte_Drop", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
