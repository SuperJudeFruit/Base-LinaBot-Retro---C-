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

namespace Guilde_Variable
{
    public class Base
    {
        public int Niveau = -1;
        public MinMax Experience = new MinMax();
        public bool Guilde = false;
        public bool Invitation = false;
        public string Nom = "";
        public string Inviteur = "";
        public string Inviter = "";
        public Dictionary<string, Membre> Membre = new Dictionary<string, Membre>();
        public Percepteur Percepteur = new Percepteur();
        public Dictionary<string, Enclos> Enclos = new Dictionary<string, Enclos>();
        public Dictionary<string, Maison> Maison = new Dictionary<string, Maison>();
    }

    public class Membre
    {
        public string Classe = "";
        public string Nom = "";
        public int ID = -1;
        public string Rang = "";
        public int Rang_Chiffre = -1;
        public Droit Droit = new Droit();
        public int Droit_Chiffre = -1;
        public MinMax Experience = new MinMax();
        public int Niveau = -1;
        public string Alignement = "";
        public bool Connecter = false;
        public string DerniereConnection = "";
    }

    public class Droit
    {
        public bool GererLesBoosts = false;
        public bool GererLesDroits = false;
        public bool InviterDeNouveauxMembres = false;
        public bool Bannir = false;
        public bool GererLesRepartitionsXP = false;
        public bool GererSaRepartitionXP = false;
        public bool GererLesRangs = false;
        public bool PoserUnPercepteur = false;
        public bool CollecterSurUnPercepteur = false;
        public bool UtiliserLesEnclos = false;
        public bool AmenagerLesEnclos = false;
        public bool GererLesMonturesDesAutresMembres = false;
    }

    public class Percepteur
    {
        public int PointsDeVie = -1;
        public int BonusAuxDommages = -1;
        public int Prospection = -1;
        public int Sagesse = -1;
        public int Pods = -1;
        public int NombreDePercepteur = -1;
        public int ResteARepartir = -1;
        public int ActuellementPercepteur = -1;
        public int CoutPourPoserPercepteur = -1;

        // Spell
        public int ArmureAqueuse = -1;
        public int ArmureIncandescente = -1;
        public int ArmureTerrestre = -1;
        public int ArmureVenteuse = -1;
        public int Flamme = -1;
        public int Cyclone = -1;
        public int Vague = -1;
        public int Rocher = -1;
        public int MotSoignant = -1;
        public int Desenvoutement = -1;
        public int CompulsionDeMasse = -1;
        public int Destabilisation = -1;
    }

    public class Enclos
    {
        public int MapID = -1;
        public string Position = "";
        public MinMax Dragodinde = new MinMax();
    }

    public class Maison
    {
        public bool MaisonVisiblePourGuilde = false;
        public bool BlasonVisiblePourGuilde = false;
        public bool BlasonVisiblePourToutMonde = false;
        public bool AccesAutoriserMembreGuilde = false;
        public bool AccesInterditNonMembreGuilde = false;
        public bool AccesCoffresAutoriseMembreGuilde = false;
        public bool AccesCoffresInterditNonMembreGuilde = false;
        public bool TeleportationAutoriser = false;
        public bool ReposAutoriser = false;

        public int ID = -1;
        public string Prorietaire = "";
        public string Position = "";
        public string Competence = "";
    }
}
