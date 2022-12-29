using System.Collections.Generic;

namespace Interaction_Variable
{
    public class Base
    {
        public int Cellule = -1;
        public int Sprite = -1;
        public string Nom = "";
        public bool Disponible = true;
        public string Etat = "";
        public Dictionary<string, int> Action = new Dictionary<string, int>();
    }
}
