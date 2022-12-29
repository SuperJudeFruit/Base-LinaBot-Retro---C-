using System;

public class FunctionPersonnage
{
    public int Energie(string choix)
    {
        try
        {
            {
                var withBlock = Bot;
                {
                    var withBlock1 = withBlock.Personnage.Energie;
                    switch (choix.ToLower())
                    {
                        case "actuelle":
                        case "actuel":
                            {
                                return withBlock1.Actuelle;
                            }

                        case "maximum":
                            {
                                return withBlock1.Maximum;
                            }

                        case "pr":
                        case "%":
                            {
                                return withBlock1.Pourcentage;
                            }

                        default:
                            {
                                return 0;
                            }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErreurFichier(Bot.Personnage.NomDuPersonnage + "_" + Bot.Personnage.Serveur, "FunctionCaracteristique_Energie", ex.Message);
        }

        return 0;
    }

    public int Niveau()
    {
        try
        {
            {
                var withBlock = Bot;
                return withBlock.Personnage.Niveau;
            }
        }
        catch (Exception ex)
        {
            ErreurFichier(Bot.Personnage.NomDuPersonnage + "_" + Bot.Personnage.Serveur, "FunctionCaracteristique_Niveau", ex.Message);
        }

        return 0;
    }

    public int Experience(string choix)
    {
        try
        {
            {
                var withBlock = Bot;
                {
                    var withBlock1 = withBlock.Personnage.Experience;
                    switch (choix.ToLower())
                    {
                        case "minimum":
                            {
                                return withBlock1.Minimum;
                            }

                        case "actuelle":
                        case "actuel":
                            {
                                return withBlock1.Actuelle;
                            }

                        case "maximum":
                            {
                                return withBlock1.Maximum;
                            }

                        case "pr":
                        case "%":
                            {
                                return withBlock1.Pourcentage;
                            }

                        default:
                            {
                                return 0;
                            }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErreurFichier(Bot.Personnage.NomDuPersonnage + "_" + Bot.Personnage.Serveur, "FunctionCaracteristique_Experience", ex.Message);
        }

        return 0;
    }

    public int PointDeVie(string choix)
    {
        try
        {
            {
                var withBlock = Bot;
                {
                    var withBlock1 = withBlock.Personnage.Vitaliter;
                    switch (choix.ToLower())
                    {
                        case "actuelle":
                        case "actuel":
                            {
                                return withBlock1.Actuelle;
                            }

                        case "maximum":
                            {
                                return withBlock1.Maximum;
                            }

                        case "pr":
                        case "%":
                            {
                                return withBlock1.Pourcentage;
                            }

                        default:
                            {
                                return 0;
                            }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErreurFichier(Bot.Personnage.NomDuPersonnage + "_" + Bot.Personnage.Serveur, "FunctionCaracteristique_PointDeVie", ex.Message);
        }

        return 0;
    }
}
