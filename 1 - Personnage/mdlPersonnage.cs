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

static class mdlPersonnage
{
    public static void GiPersonnageNiveauUp(string data)
    {
        {
            var withBlock = Bot;
            try
            {

                // AN 2
                // AN Niveau

                withBlock.Personnage.Niveau = Strings.Mid(data, 3);

                EcritureMessage("[Dofus]", "Tu passes niveau " + Strings.Mid(data, 3) + Constants.vbCrLf + "Tu gagnes 5 points pour faire évoluer tes caractéristiques et 1 point pour tes sorts.", Color.Green);
            }
            catch (Exception ex)
            {
                ErreurFichier(withBlock.Personnage.NomDuPersonnage, "GiPersonnageNiveauUp", data + Constants.vbCrLf + ex.Message);
            }
        }
    }

    public static void GiPersonnageInformation(string data)
    {
        {
            var withBlock = Bot;
            try
            {

                // ASK | 1234567   | Linaculer  | 99    | 9         | 0       | 90            | -1       | -1       | -1       | 262c1bc        ~ 241      ~ 1         ~ 1                 ~ 64#2#4#0#1d3+1  , 7d#1#0#0#0d0+1 ; Next Item
                // ASK | ID Joueur | Nom Joueur | Level | Id Classe | Id Sexe | Classe + Sexe | Couleur1 | Couleur2 | Couleur3 | Id Unique Item ~ Id Objet ~ Quantity  ~ Number equipment  ~ Caractéristique , Caract Next    ; Item suivent

                string[] separateData = Strings.Split(data, "|");

                withBlock.Connexion.Connexion = false;
                withBlock.Connexion.Connecter = true;

                {
                    var withBlock1 = withBlock.Personnage;
                    withBlock1.ID = separateData[1];
                    withBlock1.NomDuPersonnage = separateData[2];
                    withBlock1.Niveau = separateData[3];
                    withBlock1.Classe = separateData[4];
                    withBlock1.Sexe = separateData[5];
                    withBlock1.ClasseSexe = separateData[6];
                    withBlock1.Couleur1 = "&H" + separateData[7];
                    withBlock1.Couleur2 = "&H" + separateData[8];
                    withBlock1.Couleur3 = "&H" + separateData[9];
                }

                // Form_LinaBot.TreeView_SelectedImageKey(index, separateData(6))

                EcritureMessage("[Dofus]", "Connecté au personnage '" + separateData[2] + "' (Niveau : " + separateData[3] + ")", Color.Green);
                EcritureMessage("[Dofus]", "Réception de l'inventaire.", Color.Green);
            }
            catch (Exception ex)
            {
                ErreurFichier(withBlock.Personnage.NomDuPersonnage, "GiPersonnageInformation", data + Constants.vbCrLf + ex.Message);
            }
        }
    }
}


namespace nsPersonnage
{
    public class Personnage
    {
        public event RaisePersonnageEventHandler RaisePersonnage;

        public delegate void RaisePersonnageEventHandler(string Choix, object value);

        public string NomDeCompte;
        public string MotDePasse;
        public string NomDuPersonnage;
        public string Serveur;



        public string Alignement = "";
        public int ID;
        public string Pseudo = "";
        public string QuestionSecrete = "";
        public DateTime Abonnement = DateTime.TimeOfDay;
        public string Ticket;
        public int Niveau;
        public int Classe;
        public int ClasseSexe;
        public int Sexe;
        public int IDServeur;
        public int Kamas;
        public int Regeneration;
        public int Capital_Sort;
        public bool Vivant = true;
        public bool EnInteraction;
        public string Couleur1, Couleur2, Couleur3;
        public int InteractionCellule;
        public MinMax Pods = new MinMax();

        public Dictionary<string, Item_Variable.Information> Cadeau = new Dictionary<string, Item_Variable.Information>();

        public Map_Variable.Equipement Equipement = new Map_Variable.Equipement();

        private MinMax _Experience = new MinMax();
        public MinMax Experience
        {
            get
            {
                return _Experience;
            }

            set
            {
                _Experience = value;
                RaisePersonnage?.Invoke("Experience", value);
            }
        }

        private MinMax _Energie = new MinMax();
        public MinMax Energie
        {
            get
            {
                return _Energie;
            }

            set
            {
                _Energie = value;
                RaisePersonnage?.Invoke("Energie", value);
            }
        }

        private MinMax _Vitaliter = new MinMax();
        public MinMax Vitaliter
        {
            get
            {
                return _Vitaliter;
            }

            set
            {
                _Vitaliter = value;
                RaisePersonnage?.Invoke("Vitaliter", value);
            }
        }
    }

    public class CStatut
    {
        public string Etat = "";
        public Color Couleur;
    }
}
