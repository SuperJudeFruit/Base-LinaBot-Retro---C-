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

namespace Tchat
{
    static class Tchat
    {
        public static void Canal(string data)
        {
            {
                var withBlock = Bot;

                // cC +                *#%!$:?pi^
                // cC Active/Désactive Canaux

                try
                {
                    bool @checked = Strings.Mid(data, 3, 1);

                    Tchat_Variable.Canaux newCanaux = withBlock.Tchat.Canaux;

                    {
                        var withBlock1 = newCanaux;
                        for (var i = 3; i <= data.Length - 1; i++)
                        {
                            switch (data[i])
                            {
                                case "i" // Information
                               :
                                    {
                                        withBlock1.Information = @checked;
                                        break;
                                    }

                                case "*" // Communs/Défaut
                         :
                                    {
                                        withBlock1.Commun = @checked;
                                        break;
                                    }

                                case "#":
                                case "$":
                                case "p" // groupe/privée/équipe
                         :
                                    {
                                        withBlock1.GroupeEquipeMP = @checked;
                                        break;
                                    }

                                case "%" // guilde
                         :
                                    {
                                        withBlock1.Guilde = @checked;
                                        break;
                                    }

                                case "!" // alignement
                         :
                                    {
                                        withBlock1.Alignement = @checked;
                                        break;
                                    }

                                case "?" // recrutement
                         :
                                    {
                                        withBlock1.Recrutement = @checked;
                                        break;
                                    }

                                case ":" // Commerce
                         :
                                    {
                                        withBlock1.Commerce = @checked;
                                        break;
                                    }

                                case "e" // Evenement
                         :
                                    {
                                        withBlock1.Evenement = @checked;
                                        break;
                                    }
                            }
                        }
                    }

                    withBlock.Tchat.Canaux = newCanaux;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage + "_" + withBlock.Personnage.Serveur, "Tchat_Canal", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Information(string data)
        {
            {
                var withBlock = Bot;

                // Im 1165
                // Im Numéro du texte a affiché

                try
                {
                    data = Strings.Mid(data, 3);

                    Tchat_Variable.Information newInformation = new Tchat_Variable.Information();

                    {
                        var withBlock1 = newInformation;
                        if (data.Contains(';'))
                        {
                            string[] Separation = Strings.Split(data, ";");

                            switch (Separation[0])
                            {
                                case "1202" // Im1201;[Seydlex] 
                               :
                                    {
                                        withBlock1.Canal = "[Modérateur]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Attention un modérateur vous surveille : " + Separation[1] + ".";
                                        break;
                                    }

                                case "1184" // Im1184;Linaculer
                         :
                                    {
                                        withBlock1.Canal = "[Combat]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = Separation[1] + " vient de se reconnecter en combat.";
                                        break;
                                    }

                                case "1171" // Im1171;1~9~19
                         :
                                    {
                                        Separation = Strings.Split(Separation[1], "~");

                                        withBlock1.Canal = "[Combat]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Impossible de lancer ce sort : Vous avez une portée de " + Separation[0] + " à " + Separation[1] + " et vous visez à " + Separation[2] + " !";
                                        break;
                                    }

                                case "1170" // Im1170;0~4
                         :
                                    {
                                        Separation = Strings.Split(Separation[1], "~");

                                        withBlock1.Canal = "[Combat]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Vous avez '" + Separation[0] + "' PA, hors il vous en faut minimum '" + Separation[1] + "' PA pour lancer ce sort.";
                                        break;
                                    }

                                case "1168" // Im1168;1
                         :
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Vous ne pouvez pas poser plus de " + Separation[1] + " percepteur(s) par zone.";
                                        break;
                                    }

                                case "1167" // Im1167;54
                         :
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Vous ne pouvez pas poser de percepteur ici avant " + Separation[1] + " minutes.";
                                        break;
                                    }

                                case "1139" // Im1139;5
                         :
                                    {
                                        withBlock1.Canal = "[Percepteur]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Attention, la fenêtre d'échange se fermera automatiquement dans " + Separation[1] + " minutes.";
                                        break;
                                    }

                                case "1111" // Im1111;3
                         :
                                    {
                                        withBlock1.Canal = "[Dragodinde]";
                                        withBlock1.Couleur = Color.Fuchsia;
                                        withBlock1.Message = "A peine entrée dans l'étable, votre monture s'accroupit et commence à mettre bas. Après quelques instants, vous pouvez constater que tout s'est bien passé. Vous voilà responsable de " + Separation[1] + " nouvelle(s) monture(s).";
                                        break;
                                    }

                                case "0188" // "Im0188;player"
                         :
                                    {
                                        withBlock1.Canal = "[Combat]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Et comme d'habitude, c'est à " + Separation[1] + " que l'on doit cet exploit...";
                                        break;
                                    }

                                case "0157" // Im0157;6
                         :
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Ce canal n'est accessible en diffusion aux abonnés qu'à partir du niveau " + Separation[1];
                                        break;
                                    }

                                case "0153" // Im0153;xx.xxx.xx.xx
                         :
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Votre adresse IP actuelle est : " + Separation[1] + ".";
                                        break;
                                    }

                                case "0152":
                                    {

                                        // Im0152; 2019  ~ 06   ~ 27   ~ 7     ~ 19     ~ xx.xxx.xx.xx
                                        // Im0152; Année ~ Mois ~ Jour ~ Heure ~ Minute ~ IP

                                        Separation = Strings.Split(Separation[1], "~");

                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Précédente connexion sur votre compte effectuée le : " + Separation[2] + "/" + Separation[1] + "/" + Separation[0] + " à " + Separation[3] + ":" + Separation[4] + " via l'adresse IP  : " + Separation[5];
                                        break;
                                    }

                                case "0143":
                                    {

                                        // Im0143;Linaculer (<b><a href="asfunction:onHref,ShowPlayerPopupMenu,Linacular">Linaculeur</a></b>) 

                                        Separation = Strings.Split(Separation[1], " (<b><a href=\"\"asfunction: onHref, ShowPlayerPopupMenu, Linacular\"\">");
                                        string V_Nom_De_Compte = Separation[0];
                                        Separation = Strings.Split(Separation[1], "</a></b>)");

                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Le joueur : " + V_Nom_De_Compte + "(" + Separation[0] + ") vient de se connecter.";
                                        break;
                                    }

                                case "0115":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Ce canal est restreint pour améliorer sa lisibilité. Vous pourrez envoyer un nouveau message dans " + Separation[1] + " secondes. Ceci ne vous autorise cependant pas pour autant à surcharger ce canal.";
                                        break;
                                    }

                                case "128" // Im128;Linaculer
                         :
                                    {
                                        withBlock1.Canal = "[Combat]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "En attente du joueur " + Separation[1] + "...";
                                        break;
                                    }

                                case "120":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Cet emplacement de stockage est déjà utilisé.";
                                        break;
                                    }

                                case "116":
                                    {

                                        // Im116;[Seydlex]~Bot tchatJoueur

                                        Separation = Strings.Split(Separation[1], "~");

                                        withBlock1.Canal = "[Modérateur]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Vous avez été banni par " + Separation[0] + ". Motif : " + Separation[2];
                                        break;
                                    }

                                case "115":
                                    {

                                        // Im115;16 heures, 43 minutes, 43 secondes

                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Pour des raisons de maintenances, le serveur va être redémarré dans " + Separation[1];
                                        break;
                                    }

                                case "092":
                                    {

                                        // Im092;50

                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Vous avez récupéré " + Separation[1] + " points d'énergie en vous reposant.";
                                        break;
                                    }

                                case "065":
                                    {

                                        // Im065; 300         ~ 2598     ~ 2598     ~ 1
                                        // Im065; Kamas gagné ~ ID Objet ~ ID Objet ~ Quantité

                                        Separation = Strings.Split(Separation[1], "~");

                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Votre compte en banque a été crédité de " + Separation[0] + " kamas suite à la vente de '" + VarItems(Separation[1]).Nom + "' (x " + Separation[3] + ").";
                                        break;
                                    }

                                case "056":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Quête terminée : " + VarQuête(Separation[1]);
                                        break;
                                    }

                                case "055":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Quête mise à jour : " + VarQuête(Separation[1]);
                                        break;
                                    }

                                case "054":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Nouvelle quête : " + VarQuête(Separation[1]);
                                        break;
                                    }

                                case "053":
                                    {

                                        // Im053;Linaculer

                                        withBlock1.Canal = "[Groupe]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = Separation[1] + " ne suit plus votre déplacement.";
                                        break;
                                    }

                                case "052":
                                    {

                                        // Im052;Linaculer

                                        withBlock1.Canal = "[Groupe]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = Separation[1] + " suit votre déplacement.";
                                        break;
                                    }

                                case "045":
                                    {

                                        // Im045;50

                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Tu as gagné " + Separation[1] + " kamas.";
                                        break;
                                    }

                                case "036":
                                    {

                                        // Im036;Linaculer

                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = Separation[1] + " vient de rejoindre le combat en spectateur.";
                                        break;
                                    }

                                case "034":
                                    {

                                        // Im034;60 

                                        // Comptes(index).Combat.EnCombat = False

                                        withBlock1.Canal = "[Familier]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Tu as perdu " + Separation[1] + " points d'énergie.";
                                        break;
                                    }

                                case "022":
                                    {

                                        // Im022;1~1568

                                        Separation = Strings.Split(Separation[1], "~");

                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Tu as perdu " + Separation[0] + " '" + VarItems(Separation[1]).Nom + "'.";
                                        break;
                                    }

                                case "020":
                                    {

                                        // Im022;481

                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Tu as dû donner " + Separation[1] + " kamas pour pouvoir accéder à ce coffre.";
                                        break;
                                    }

                                case "08":
                                    {

                                        // Im08;17293

                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Tu as gagné " + Separation[1] + " points d'expérience.";
                                        break;
                                    }

                                case "01":
                                    {

                                        // Im01;100

                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Tu as récupéré " + Separation[1] + " points de vie.";
                                        break;
                                    }

                                default:
                                    {
                                        withBlock1.Canal = "[Inconnu]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = data;

                                        ErreurFichier(Bot.Personnage.NomDeCompte, "GiDofusInformation", data);
                                        break;
                                    }
                            }
                        }
                        else
                            switch (data)
                            {
                                case "1183":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "La zone 'Incarnam' fonctionne sur plusieurs instances, pour éviter qu'un trop grand nombre de joueurs soient présent dans cette zone de petite taille. Ceci signifie qu'il existe plusieurs 'Incarnam' en parallèle, afin qu'il n'y ait pas plus d'un certain nombre de joueurs dans la même instance. Vous pouvez donc ne pas être dans le même 'Incarnam' que vos amis, pour les rejoindre, vous pouvez utiliser la liste d'amis, et vous retrouver instantanément à leurs côtés, à conditions qu'ils soient eux aussi dans Incarnam en dehors des grottes et donjons.";
                                        break;
                                    }

                                case "1177":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Vous avez trop d'objets dans votre inventaire, vous ne pouvez pas les voir tous. (1000 objets maximum)";
                                        break;
                                    }

                                case "1175":
                                    {
                                        withBlock1.Canal = "[Combat]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Impossible de lancer ce sort actuellement.\"";
                                        break;
                                    }

                                case "1174":
                                    {
                                        withBlock1.Canal = "[Combat]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Un obstacle géne le passage.";
                                        break;
                                    }

                                case "1165":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "La sauvegarde du serveur est terminée. L'accès au serveur est de nouveau possible. Merci de votre compréhension.";
                                        break;
                                    }

                                case "1164":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Une sauvegarde du serveur est en cours... Vous pouvez continuer de jouer, mais l'accès au serveur est temporairement bloqué. La connexion sera de nouveau possible d'ici quelques instants. Merci de votre patience.";
                                        break;
                                    }

                                case "1159":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Vous êtes à court de potion d'enclos de guilde.";
                                        break;
                                    }

                                case "1127":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Incarnam ne vous est plus accessible désormais, votre expérience fait de vous un aventurier apte à parcourir le monde sans continuer dans cette zone...";
                                        break;
                                    }

                                case "1120":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Impossible d'interagir avec votre percepteur sur la carte même où vous vous êtes connecté.";
                                        break;
                                    }

                                case "1117":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Impossible d'être sur une monture à l'intérieur d'une maison.";
                                        break;
                                    }

                                case "1105":
                                    {
                                        withBlock1.Canal = "[Dragodinde]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "L'étable est pleine. Vous ne pouvez conserver que 100 montures maximum.";
                                        break;
                                    }

                                case "1104":
                                    {
                                        withBlock1.Canal = "[Dragodinde]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Monture désignée invalide, trop de monture dans l'étable";
                                        break;
                                    }

                                case "1102":
                                    {
                                        withBlock1.Canal = "[Dragodinde]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Cellule cible invalide";
                                        break;
                                    }

                                case "0194":
                                    {
                                        withBlock1.Canal = "[Forgemagie]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "La magie n'a pas parfaitement fonctionné, une des caractéristiques de l'objet a baissé en puissance.";
                                        break;
                                    }

                                case "0183":
                                    {
                                        withBlock1.Canal = "[Forgemagie]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Malgré vos talents, la magie n'opère pas et vous sentez l'échec de la transformation.";
                                        break;
                                    }

                                case "0144":
                                    {
                                        withBlock1.Canal = "[Récolte]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Votre inventaire est plein. Votre récolte est perdue...";
                                        break;
                                    }

                                case "0143":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Le joueur : " + data + " vient de se connecter.";
                                        break;
                                    }

                                case "0118":
                                    {
                                        withBlock1.Canal = "[Craft]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Vous n'arrivez pas à assembler correctement les ingrédients, et vous n'arrivez pas à concevoir quoi que ce soit d'utilisable cette fois.";
                                        break;
                                    }

                                case "0117":
                                    {
                                        withBlock1.Canal = "[Forgemagie]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Malgré vos talents, la magie n'opère pas et vous sentez l'échec de la transformation, ainsi que la diminution de la puissance de l'objet..";
                                        break;
                                    }

                                case "0106" // Im0106
                         :
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Pour utiliser le canal d'alignement vous devez développer vos ailes à 3 ou plus, ou encore avoir choisi une spécialisation par les quêtes d'alignement (niveau de quêtes à partir de 20)";
                                        break;
                                    }

                                case "0104":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Demande d'aide annulée...";
                                        break;
                                    }

                                case "0103":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Demande d'aide signalée...";
                                        break;
                                    }

                                case "189":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Bienvenue sur Dofus, dans le Monde des douze !" + Constants.vbCrLf + "Rappel : prenez garde, il est interdit de transmettre votre identifiant de connexion ainsi que votre mot de passe.";
                                        break;
                                    }

                                case "172":
                                    {
                                        withBlock1.Canal = "[Hôtel de Vente]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Cet objet n'est plus disponible à ce prix. Quelqu'un a été plus rapide...";
                                        break;
                                    }

                                case "167":
                                    {
                                        withBlock1.Canal = "[Hôtel de Vente]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Vous ne pouvez pas mettre plus d'objets en vente actuellement...";
                                        break;
                                    }

                                case "165":
                                    {
                                        withBlock1.Canal = "[Hôtel de vente]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Vous ne disposez pas d'assez de kamas pour acquitter la taxe de mise en vente...";
                                        break;
                                    }

                                case "137":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Ton mari n'est pas connecté.";
                                        break;
                                    }

                                case "120":
                                    {
                                        withBlock1.Canal = "[Maison]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Cet emplacement de stockage est déjà utilisé.";
                                        break;
                                    }

                                case "118" // Im188
                         :
                                    {
                                        withBlock1.Canal = "[Familier]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Votre familier ne peut vous suivre tant que vous êtes sur votre monture...";
                                        break;
                                    }

                                case "113" // Im113
                         :
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Cette action n'est pas autorisée sur cette carte.";
                                        break;
                                    }

                                case "112":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Vous êtes trop chargé. Jetez quelques objets afin de pouvoir bouger.";
                                        break;
                                    }

                                case "096":
                                    {
                                        withBlock1.Canal = "[Combat]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "L'équipe accepte de nouveau des personnages supplémentaires.";
                                        break;
                                    }

                                case "095":
                                    {
                                        withBlock1.Canal = "[Combat]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "L'équipe n'accepte plus de personnages supplémentaires.";
                                        break;
                                    }

                                case "094":
                                    {
                                        withBlock1.Canal = "[Combat]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "L'équipe accepte les membres de tous les groupes.";
                                        break;
                                    }

                                case "093":
                                    {
                                        withBlock1.Canal = "[Combat]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "L'équipe n'accepte désormais que les membres du groupe du personnage principal.";
                                        break;
                                    }

                                case "068":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Lot acheté.";
                                        break;
                                    }

                                case "040":
                                    {
                                        withBlock1.Canal = "[Combat]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Le mode 'spectateur' est désactivé.";
                                        break;
                                    }

                                case "039":
                                    {
                                        withBlock1.Canal = "[Combat]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Le mode 'spectateur' est activé.";
                                        break;
                                    }

                                case "037":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Vous êtes désormais considéré comme absent.";
                                        break;
                                    }

                                case "032":
                                    {
                                        withBlock1.Canal = "[Familier]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Votre familier apprécie le repas.";
                                        break;
                                    }

                                case "031":
                                    {
                                        withBlock1.Canal = "[Familier]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Vous donnez à manger à votre familier famélique qui traînait comme un zombi. Il se force à manger mais la nourriture qu'il avale fait 3 fois son estomac et il se tord de douleur. Au moins il a mangé.";
                                        break;
                                    }

                                case "029":
                                    {
                                        withBlock1.Canal = "[Familier]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Vous donnez à manger à votre familier. Il semble qu'il avait très faim.";
                                        break;
                                    }

                                case "027":
                                    {
                                        withBlock1.Canal = "[Familier]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Vous donnez à manger à répétition à votre familier déjà obèse. Il avale quand même la ressource et fait une indigestion.";
                                        break;
                                    }

                                case "026":
                                    {
                                        withBlock1.Canal = "[Familier]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Vous donnez à manger à votre familier alors qu'il n'avait plus faim. Il se force pour vous faire plaisir.";
                                        break;
                                    }

                                case "025":
                                    {
                                        withBlock1.Canal = "[Familier]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Votre familier vous fait la fête !";
                                        break;
                                    }

                                case "153":
                                    {
                                        withBlock1.Canal = "[Familier]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = "Votre familier prend la ressource, la renifle un peu, ne semble pas convaincu et vous la rend.";
                                        break;
                                    }

                                case "024":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Tu viens de mémoriser un nouveau zaap.";
                                        break;
                                    }

                                case "06":
                                    {
                                        withBlock1.Canal = "[Dofus]";
                                        withBlock1.Couleur = Color.Green;
                                        withBlock1.Message = "Position sauvegardée.";
                                        break;
                                    }

                                default:
                                    {
                                        withBlock1.Canal = "[INCONNU]";
                                        withBlock1.Couleur = Color.Red;
                                        withBlock1.Message = data;

                                        ErreurFichier(Bot.Personnage.NomDeCompte, "GiDofusInformation", data);
                                        break;
                                    }
                            }
                    }

                    withBlock.Tchat.Message = newInformation;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage + "_" + withBlock.Personnage.Serveur, "Tchat_Information", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Message(string data)
        {
            {
                var withBlock = Bot;

                // cMK %     | 1234567   | Linaculer  | salut tout le monde |
                // cMK Canal | Id Joueur | Nom Joueur | Message             | Caractéristique des objets (Rien si aucun)

                try
                {
                    string[] separateData = Strings.Split(data, "|");

                    Tchat_Variable.Information newInformation = new Tchat_Variable.Information();

                    {
                        var withBlock1 = newInformation;
                        switch (Strings.Mid(data, 4, 1))
                        {
                            case "|":
                                {
                                    withBlock1.Canal = "[General]";
                                    withBlock1.Couleur = Color.Black;
                                    break;
                                }

                            case "$":
                                {
                                    withBlock1.Canal = "[Groupe]";
                                    withBlock1.Couleur = Color.Blue;
                                    break;
                                }

                            case "F":
                                {
                                    withBlock1.Canal = "[Privée de]";
                                    withBlock1.Couleur = Color.Blue;
                                    break;
                                }

                            case "T":
                                {
                                    withBlock1.Canal = "[Privée à]";
                                    withBlock1.Couleur = Color.Blue;
                                    break;
                                }

                            case "%":
                                {
                                    withBlock1.Canal = "[Guilde]";
                                    withBlock1.Couleur = Color.Violet;
                                    break;
                                }

                            case "!":
                                {
                                    withBlock1.Canal = "[Alignement]";
                                    withBlock1.Couleur = Color.Orange;
                                    break;
                                }

                            case "?":
                                {
                                    withBlock1.Canal = "[Recrutement]";
                                    withBlock1.Couleur = Color.DimGray;
                                    break;
                                }

                            case ":":
                                {
                                    withBlock1.Canal = "[Commerce]";
                                    withBlock1.Couleur = Color.Sienna;
                                    break;
                                }

                            case "e" // Evenement
                     :
                                {
                                    withBlock1.Canal = "[Evenement]";
                                    withBlock1.Couleur = Color.HotPink;
                                    break;
                                }
                        }

                        withBlock1.Id_Joueur = separateData[1];
                        withBlock1.Nom_Joueur = separateData[2];
                        withBlock1.Message = separateData[3]; // AsciiDecoder(separateData(3))
                        withBlock1.Item = separateData[4];

                        withBlock1.Heure = DateTime.TimeOfDay;
                    }

                    withBlock.Tchat.Message = newInformation;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage + "_" + withBlock.Personnage.Serveur, "Tchat_Message", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Erreur(string data)
        {
            {
                var withBlock = Bot;

                // cME X    
                // cME Canal

                try
                {
                    Tchat_Variable.Information newInformation = new Tchat_Variable.Information();

                    {
                        var withBlock1 = newInformation;
                        switch (Strings.Mid(data, 4, 1))
                        {
                            case "A" // cMEA
                           :
                                {
                                    withBlock1.Canal = "[Alignement]";
                                    withBlock1.Message = "Impossible d'utilise ce canal.";
                                    break;
                                }

                            case "f" // cMEf
                     :
                                {
                                    withBlock1.Canal = "[Dofus]";
                                    withBlock1.Message = "Le joueur " + Strings.Mid(data, 5) + " n'est pas connecté.";
                                    break;
                                }
                        }

                        withBlock1.Couleur = Color.Red;
                        withBlock1.Heure = DateTime.TimeOfDay;
                    }

                    withBlock.Tchat.Message = newInformation;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage + "_" + withBlock.Personnage.Serveur, "Tchat_Erreur", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
