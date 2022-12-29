namespace Connexion_Variable
{
    public class Base
    {
        public event EventConnexionEventHandler EventConnexion;

        public delegate void EventConnexionEventHandler(string choix, object value);

        private bool _Connecter = false;
        private bool _Connexion = false;
        private bool _Authentification = false;

        public bool Connecter
        {
            get
            {
                return _Connecter;
            }

            set
            {
                _Connecter = value;

                EventConnexion?.Invoke("Connecter", value);
            }
        }

        public bool Connexion
        {
            get
            {
                return _Connexion;
            }

            set
            {
                _Connexion = value;

                EventConnexion?.Invoke("Connexion", value);
            }
        }

        public bool Authentification
        {
            get
            {
                return _Authentification;
            }

            set
            {
                _Authentification = value;

                EventConnexion?.Invoke("Authentification", value);
            }
        }
    }
}
