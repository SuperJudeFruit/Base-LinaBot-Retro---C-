using System;
using Microsoft.VisualBasic;

namespace Tchat_Function
{
    public class Tchat_Function
    {
        public bool Canal(string _canal, bool choix)
        {
            try
            {
                {
                    var withBlock = Bot;
                    string envoyer = "cC" + choix ? "+" : "-";

                    switch (_canal.ToLower())
                    {
                        case "information":
                            {
                                return withBlock.Mitm.Send(envoyer + "i",
                                {
                                    envoyer + "i"
                                }); // GoodData
                            }

                        case "communs":
                        case "commun":
                            {
                                return withBlock.Mitm.Send(envoyer + "*",
                                {
                                    envoyer + "*"
                                }); // GoodData
                            }

                        case "groupe":
                        case "equipe":
                        case "message privee":
                            {
                                return withBlock.Mitm.Send(envoyer + "#$p",
                                {
                                    envoyer + "#$p"
                                }); // GoodData
                            }

                        case "guilde":
                            {
                                return withBlock.Mitm.Send(envoyer + "%",
                                {
                                    envoyer + "%"
                                }); // GoodData
                            }

                        case "alignement":
                            {
                                return withBlock.Mitm.Send(envoyer + "!",
                                {
                                    envoyer + "!"
                                }); // GoodData
                            }

                        case "recrutement":
                            {
                                return withBlock.Mitm.Send(envoyer + "?",
                                {
                                    envoyer + "?"
                                }); // GoodData
                            }

                        case "commerce":
                            {
                                return withBlock.Mitm.Send(envoyer + ":",
                                {
                                    envoyer + ":"
                                }); // GoodData
                            }

                        case "evenement":
                            {
                                return withBlock.Mitm.Send(envoyer + ":",
                                {
                                    envoyer + ":"
                                }); // GoodData
                            }

                        default:
                            {
                                return false;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public bool Message(string canal, string _message)
        {
            try
            {
                {
                    var withBlock = Bot;
                    string joueur = Strings.Split(_message, " ")(0);

                    if (_message.ToLower().StartsWith("/w"))
                        _message = _message.Replace(joueur + " ", "");

                    switch (canal.ToLower())
                    {
                        case "/c":
                        case "commun" // Communs
                       :
                            {
                                return withBlock.Mitm.Send("BM*|" + _message + "|",
                                {
                                    "cMK|" + withBlock.Personnage.ID
                                },
                                {
                                    "BN"
                                });
                            }

                        case "/w":
                        case "/mp" // Message Privée
                       :
                            {
                                return withBlock.Mitm.Send("BM" + joueur + "|" + _message.Replace(joueur + " ", "") + "|",
                                {
                                    "cMKT" + withBlock.Personnage.ID
                                },
                                {
                                    "BN",
                                    "cMEf"
                                });
                            }

                        case "/p":
                        case "groupe" // Groupe
                       :
                            {
                                return withBlock.Mitm.Send("BM$|" + _message + "|",
                                {
                                    "cMK$" + withBlock.Personnage.ID
                                },
                                {
                                    "BN"
                                });
                            }

                        case "/g":
                        case "guilde" // Guilde
                       :
                            {
                                return withBlock.Mitm.Send("BM%|" + _message + "|",
                                {
                                    "cMK%" + withBlock.Personnage.ID
                                },
                                {
                                    "BN"
                                });
                            }

                        case "/r":
                        case "recrutement" // Recrutement
                       :
                            {
                                return withBlock.Mitm.Send("BM?|" + _message + "|",
                                {
                                    "cMK?" + withBlock.Personnage.ID
                                },
                                {
                                    "BN"
                                });
                            }

                        case "/b":
                        case "commerce" // Commerce
                       :
                            {
                                return withBlock.Mitm.Send("BM:|" + _message + "|",
                                {
                                    "cMK:" + withBlock.Personnage.ID
                                },
                                {
                                    "BN"
                                });
                            }

                        case "/a":
                        case "alignement" // Alignement
                       :
                            {
                                return withBlock.Mitm.Send("BM!|" + _message + "|",
                                {
                                    "cMK!" + withBlock.Personnage.ID
                                },
                                {
                                    "BN",
                                    "cMEA",
                                    "Im0106",
                                    "Im0115;"
                                });
                            }

                        default:
                            {
                                return false;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }
    }
}
