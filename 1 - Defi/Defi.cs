using System;
using Microsoft.VisualBasic;

namespace Defi
{
    static class Defi
    {
        public static void Reception(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // GA ; 900 ; 1234567    ; 7654321
                    // GA ; 900 ; Id Lanceur ; Id Receveur

                    string[] separateData = Strings.Split(data, ";");

                    withBlock.Defi.ID = separateData[2];
                    withBlock.Defi.Invitation = true;

                    if (separateData[2] == withBlock.Personnage.ID)
                        EcritureMessage("[Dofus]", "Tu défie " + withBlock.Map.Entite(separateData[3]).Nom, Color.Green);
                    else if (separateData[3] == withBlock.Personnage.ID)
                        EcritureMessage("[Dofus]", withBlock.Map.Entite(separateData[2]).Nom + " te défie. acceptes-tu ?", Color.Green);
                    else
                    {
                        withBlock.Defi.ID = -1;
                        withBlock.Defi.Invitation = false;

                        EcritureMessage("[Dofus]", withBlock.Map.Entite(separateData[2]).Nom + " défie " + withBlock.Map.Entite(separateData[3]).Nom, Color.Green);
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Defi_Reception", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Refuser(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // GA ; 902 ; 1234567    ; 7654321
                    // GA ; 902 ; Id Lanceur ; Id Receveur

                    withBlock.Defi.ID = -1;
                    withBlock.Defi.Invitation = false;

                    EcritureMessage("[Dofus]", "Défi refusé.", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Defi_Refuser", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Accepter(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // GA ; 901 ; 1234567    ; 7654321
                    // GA ; 901 ; Id Lanceur ; Id Receveur

                    withBlock.Defi.Combat = true;
                    withBlock.Defi.Invitation = false;

                    EcritureMessage("[Dofus]", "Défi accepté.", Color.Green);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Defi_Accepter", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
