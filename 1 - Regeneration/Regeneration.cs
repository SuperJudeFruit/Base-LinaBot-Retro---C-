using System;
using Microsoft.VisualBasic;

namespace Regeneration
{
    static class Regeneration
    {
        public static void Restaure(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // ILF 1
                    // ILF Nbr de pdv récupèré

                    EcritureMessage("[Dofus]", "Tu as retrouvé " + Strings.Mid(data, 4) + " points de vie.", Color.Green);

                    {
                        var withBlock1 = withBlock.Personnage.Vitaliter;
                        int Vitalité = withBlock1.Actuelle + System.Convert.ToInt32(Strings.Mid(data, 4));

                        if (Vitalité > withBlock1.Maximum)
                            withBlock1.Actuelle = withBlock1.Maximum;
                        else
                            withBlock1.Actuelle = Vitalité;
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Regeneration_Restaure", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Seconde(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // ILS 2000
                    // ILS Temps à attendre pour 1 pdv

                    EcritureMessage("[Dofus]", "Votre personnage récupére 1 point de vie toutes les " + Strings.Mid(data, 4, 1) + " seconde(s).", Color.Green);

                    {
                        var withBlock1 = LinaBot;
                        withBlock1.Timer_Regeneration.Enabled = false;
                        withBlock1.Timer_Regeneration.Interval = Strings.Mid(data, 4);
                        withBlock1.Timer_Regeneration.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Regeneration_Seconde", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
