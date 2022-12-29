using System;
using Microsoft.VisualBasic;

namespace Option
{
    namespace Charger
    {
        static class Charger
        {
            public static void Initialiser()
            {
                if (System.IO.File.Exists(Application.StartupPath + @"Compte\Option\" + Bot.Personnage.NomDuPersonnage + "_" + Bot.Personnage.Serveur + ".txt"))
                {
                    System.IO.StreamReader swLecture = new System.IO.StreamReader(Application.StartupPath + @"Compte\Option\" + Bot.Personnage.NomDuPersonnage + "_" + Bot.Personnage.Serveur + ".txt");

                    while (!swLecture.EndOfStream)
                    {
                        string Ligne = swLecture.ReadLine();

                        if (Ligne != "")
                        {
                            string[] separation = Strings.Split(Ligne, "|");

                            switch (separation[0])
                            {
                                case "DLL":
                                    {
                                        Dll(separation[1]);
                                        break;
                                    }
                            }
                        }
                    }

                    swLecture.Close();
                }
            }

            private static void Dll(string Ligne)
            {
                string[] separationDLL = Strings.Split(Ligne, ";");

                for (var i = 0; i <= separationDLL.Length - 1; i++)
                {
                    if (LinaBot.Dll.DllAll.ContainsKey(separationDLL[i]))
                    {
                        {
                            var withBlock = LinaBot.Dll.DllAll(separationDLL[i]);
                            withBlock.monType.GetMethod("Main").Invoke(Activator.CreateInstance(withBlock.monType),
                            {
                                LinaBot
                            });
                        }
                    }
                }
            }

            private static void Proxy()
            {
                {
                    var withBlock = Bot;
                    withBlock.Proxy.Active = false;
                    withBlock.Proxy.Identifiant = "";
                    withBlock.Proxy.MotDePasse = "";
                    withBlock.Proxy.IP = "";
                    withBlock.Proxy.Port = "";
                }
            }
        }
    }

    namespace Sauvegarder
    {
        static class Sauvegarder
        {
            public static void Initialiser()
            {
                string Ligne = DLL() + Constants.vbCrLf;

                System.IO.StreamWriter swEcriture = new System.IO.StreamWriter(Application.StartupPath + @"Compte\Option/" + Bot.Personnage.NomDuPersonnage + "_" + Bot.Personnage.Serveur + ".txt");

                swEcriture.Write(Ligne);

                swEcriture.Close();
            }

            private static string DLL()
            {
                string Ligne = "DLL|";

                {
                    var withBlock = Bot;
                    foreach (string pair in LinaBot.Dll_Liste)

                        Ligne += pair + ";";
                }

                return Ligne;
            }
        }
    }
}
