using System;
using Microsoft.VisualBasic;

namespace Enclos
{
    static class Enclos
    {
        public static void Information(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // Rp 12345    ; 0             ; 2               ; 2               ; Lenculer de bot ; i      , 5      , a      , 9srth
                    // Rp id enclo ; Prix de vente ; Nbr DD ou objet ; Nbr DD ou objet ; Guilde          ; Blason , Blason , Blason , Blason

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), ";");

                    {
                        var withBlock1 = withBlock.Enclos;
                        withBlock1.ID = separateData[0];
                        withBlock1.Prix = separateData[1];
                        withBlock1.Dragodinde = separateData[2];
                        withBlock1.Objet = separateData[3];
                        withBlock1.Guilde = separateData[4];
                        withBlock1.Blason = separateData[5];
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Enclos_mdlEnclos_GiEncloMap", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
