using System;

namespace Caracteristique_Function
{
    class Caracteristique_Function
    {
        public bool Up(string Valeur)
        {
            try
            {
                {
                    var withBlock = Bot;
                    switch (Valeur.ToLower())
                    {
                        case "vitaliter":
                        case "vitalite":
                        case "vitalité":
                            {
                                return withBlock.Mitm.Send("AB11",
                                {
                                    "As"
                                },
                                {
                                    "ABE"
                                }); // Impossible de Up la caractéristique.
                            }

                        case "sagesse":
                            {
                                return withBlock.Mitm.Send("AB12",
                                {
                                    "As"
                                },
                                {
                                    "ABE"
                                }); // Impossible de Up la caractéristique.
                            }

                        case "force":
                            {
                                return withBlock.Mitm.Send("AB10",
                                {
                                    "As"
                                },
                                {
                                    "ABE"
                                }); // Impossible de Up la caractéristique.
                            }

                        case "chance":
                            {
                                return withBlock.Mitm.Send("AB13",
                                {
                                    "As"
                                },
                                {
                                    "ABE"
                                }); // Impossible de Up la caractéristique.
                            }

                        case "intelligence":
                            {
                                return withBlock.Mitm.Send("AB15",
                                {
                                    "As"
                                },
                                {
                                    "ABE"
                                }); // Impossible de Up la caractéristique.
                            }

                        case "agilité":
                        case "agiliter":
                        case "agilite":
                            {
                                return withBlock.Mitm.Send("AB14",
                                {
                                    "As"
                                },
                                {
                                    "ABE"
                                }); // Impossible de Up la caractéristique.
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                ErreurFichier(Bot.Personnage.NomDuPersonnage + "_" + Bot.Personnage.Serveur, "Caracteristique_Function_Up", ex.Message);
            }

            return false;
        }
    }
}
