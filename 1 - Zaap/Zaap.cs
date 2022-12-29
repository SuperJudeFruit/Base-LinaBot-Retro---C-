using System;
using Microsoft.VisualBasic;

namespace Zaap
{
    static class Zaap
    {
        public static void Information(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // WC 1242         | 3250  ; 450  | Next
                    // WC Mapid actuel | Mapid ; Prix | Next

                    withBlock.Personnage.EnInteraction = true;

                    withBlock.ZaapI.Clear();

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");

                    for (var i = 1; i <= separateData.Length - 1; i++)
                    {
                        string[] separate = Strings.Split(separateData[i], ";"); // 3250;450

                        if (!withBlock.ZaapI.ContainsKey(separate[0]))
                            withBlock.ZaapI.Add(separate[0], separate[1]);
                        else
                            withBlock.ZaapI(separate[0]) = separate[1];
                    }

                    EcritureMessage("[Dofus]", "Utilisation du Zaap en cours.", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Zaap_Information", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Ferme(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // WV

                    withBlock.Personnage.EnInteraction = false;

                    withBlock.ZaapI.Clear();
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Zaap_Ferme", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
