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

namespace Caracteristique
{
    static class Caracteristique
    {
        public static void Information(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // As 93821075 ,92071000  ,95886000   |165888|10                                 |8                      |0~0,0,0,0,0,0|793       ,793        |10000         ,10000          |439       |100        |6      ,2            ,0      ,0        ,8       |3      ,0            ,0      ,0        ,3       |0         ,-15             ,0         ,0           |0,248,0,0|220,137,0,0|0,0,0,0|1,30,0,0|158,250,0,0 |0,0,0,0|1,0,0,0|0,0,0,0|0,0,0,0         |0,0,0,0 |0,0,0,0 |0,7,0,0|0,0,0,0      |0,0,0,0       |0,0,0,0        |0,5,0,0|0,0,0,0|55,34,0,0|55,34,0,0|0,4,0,0               |0,0,0,0                |0,0,0,0                   |0,0,0,0                    |0,5,0,0              |0,1,0,0               |0,0,0,0                  |0,0,0,0                   |0,10,0,0           |0,2,0,0             |0,0,0,0                |0,0,0,0                 |0,4,0,0            |0,0,0,0             |0,0,0,0                |0,0,0,0                 |0,3,0,0            |0,0,0,0             |0,0,0,0                |0,0,0,0                 |19
                    // As XP Actuel,Xp Minimum,XP Maximum |Kamas |Capital Caractéristiques disponible|Capital Sort disponible|Inconnu      |Pdv_Actuel,PDV_Maximum|Energie_Actuel,Energie_Maximum|Initiative|Prospection|PA_Base,PA_Equipement,PA_Dons,PA_Booste,PA_Total|PM_Base,PM_Equipement,PM_Dons,PM_Booste,PM_Total|Force_Base,Force_Equipement,Force_Dons,Force_Booste|Vitalité |Sagesse    |Chance |Agilité |Intelligence|PO     |Invoc  |Dommage|Dommage Physique|Maîtrise|%Dommage|Soin   |Dommage_Piège|%Dommage_Piège|Renvoie dommage|CC     |EC     |Esq PA   | Esq PM  |Résistance_Neutre_Fixe|%Résistance_Neutre_Fixe|pvp_Résistance_Neutre_Fixe|pvp_%Résistance_Neutre_Fixe|Résistance_Terre_Fixe|%Résistance_Terre_Fixe|pvp_Résistance_Terre_Fixe|pvp_%Résistance_Terre_Fixe|Résistance_Eau_Fixe|%Résistance_Eau_Fixe|pvp_Résistance_Eau_Fixe|pvp_%Résistance_Eau_Fixe|Résistance_Air_Fixe|%Résistance_Air_Fixe|pvp_Résistance_Air_Fixe|pvp_%Résistance_Air_Fixe|Résistance_Feu_Fixe|%Résistance_Feu_Fixe|pvp_Résistance_Feu_Fixe|pvp_%Résistance_Feu_Fixe|Inconnu

                    // data reçu :
                    // AsXp_Actuel,XP_Minimum,Xp_Maximum| = 0
                    // Kamas| = 1
                    // Capital Caractéristiques disponible| = 2
                    // Capital Sort disponible| = 3
                    // 0~0,0,0,0,0,0| = 4 (Inconnu)
                    // Pdv_Actuel,PDV_Maximum| = 5
                    // Energie_Actuel,Energie_Maximum| = 6
                    // Initiative_Actuel| = 7
                    // Prospection_Actuel| = 8

                    // PA_Base,PA_Equipement,PA_Dons,PA_Booste,PA_Total| = 9
                    // PM_Base,PM_Equipement,PM_Dons,PM_Booste,PM_Total| = 10

                    // Force_Base,Force_Equipement,Force_Dons,Force_Booste| = 11
                    // Vitalité_Base,Vitalité_Equipement,Vitalité_Dons,Vitalité_Booste| = 12
                    // Sagesse_Base,Sagesse_Equipement,Sagesse_Dons,Sagesse_Booste| = 13
                    // Chance_Base,Chance_Equipement,Chance_Dons,Chance_Booste| = 14
                    // Agilité_Base,Agilité_Equipement,Agilité_Dons,Agilité_Booste| = 15
                    // Intelligence_Base,Intelligence_Equipement,Intelligence_Dons,Intelligence_Booste| = 16

                    // PO_Base,PO_Equipement,PO_Dons,PO_Booste| = 17
                    // Invocation_Base,Invocation_Equipement,Invocation_Dons,Invocation_Booste| = 18
                    // Dommage_Base,Dommage_Equipement,Dommage_Dons,Dommage_Booste| = 19
                    // Dommage_Physique_Base,Dommage_Physique_Equipement,Dommage_Physique_Dons,Dommage_Physique_Booste| = 20
                    // Maîtrise_Base,Maîtrise_Equipement,Maîtrise_Dons,Maîtrise_Booste| = 21
                    // %Dommage_Base,%Dommage_Equipement,%Dommage_Dons,%Dommage_Booste| = 22
                    // Soin_Base,Soin_Equipement,Soin_Dons,Soin_Booste| = 23
                    // Dommage_Piège_Base,Dommage_Piège_Equipement,Dommage_Piège_Dons,Dommage_Piège_Booste| = 24
                    // %Dommage_Piège_Base,%Dommage_Piège_Equipement,%Dommage_Piège_Dons,%Dommage_Piège_Booste| = 25
                    // Renvoie_Dommage_Base,Renvoie_Dommage_Equipement,Renvoie_Dommage_Dons,Renvoie_Dommage_Booste| = 26

                    // Coups_Critiques_Base,Coups_Critiques_Equipement,Coups_Critiques_Dons,Coups_Critiques_Booste| = 27
                    // Echec_Critique_Base,Echec_Critique_Equipement,Echec_Critique_Dons,Echec_Critique_Booste| = 28

                    // Esquive_PA_Base,Esquive_PA_Equipement,Esquive_PA_Dons,Esquive_PA_Booste| = 29
                    // Esquive_PM_Base,Esquive_PM_Equipement,Esquive_PM_Dons,Esquive_PM_Booste| = 30

                    // Résistance_Neutre_Fixe_Base,Résistance_Neutre_Fixe_Equipement,Résistance_Neutre_Fixe_Dons,Résistance_Neutre_Fixe_Booste| = 31
                    // %Résistance_Neutre_Fixe_Base,%Résistance_Neutre_Fixe_Equipement,%Résistance_Neutre_Fixe_Dons,%Résistance_Neutre_Fixe_Booste| = 32
                    // Résistance_Neutre_Fixe_PVP_Base,Résistance_Neutre_Fixe_PVP_Equipement,Résistance_Neutre_Fixe_PVP_Dons,Résistance_Neutre_Fixe_PVP_Booste| = 33
                    // %Résistance_Neutre_Fixe_PVP_Base,%Résistance_Neutre_Fixe_PVP_Equipement,%Résistance_Neutre_Fixe_PVP_Dons,%Résistance_Neutre_Fixe_PVP_Booste| = 34

                    // Résistance_Terre_Fixe_Base,Résistance_Terre_Fixe_Equipement,Résistance_Terre_Fixe_Dons,Résistance_Terre_Fixe_Booste| = 35
                    // %Résistance_Terre_Fixe_Base,%Résistance_Terre_Fixe_Equipement,%Résistance_Terre_Fixe_Dons,%Résistance_Terre_Fixe_Booste| = 36
                    // Résistance_Terre_Fixe_PVP_Base,Résistance_Terre_Fixe_PVP_Equipement,Résistance_Terre_Fixe_PVP_Dons,Résistance_Terre_Fixe_PVP_Booste| = 37
                    // %Résistance_Terre_Fixe_PVP_Base,%Résistance_Terre_Fixe_PVP_Equipement,%Résistance_Terre_Fixe_PVP_Dons,%Résistance_Terre_Fixe_PVP_Booste| = 38

                    // Résistance_Eau_Fixe_Base,Résistance_Eau_Fixe_Equipement,Résistance_Eau_Fixe_Dons,Résistance_Eau_Fixe_Booste| = 39
                    // %Résistance_Eau_Fixe_Base,%Résistance_Eau_Fixe_Equipement,%Résistance_Eau_Fixe_Dons,%Résistance_Eau_Fixe_Booste| = 40
                    // Résistance_Eau_Fixe_PVP_Base,Résistance_Eau_Fixe_PVP_Equipement,Résistance_Eau_Fixe_PVP_Dons,Résistance_Eau_Fixe_PVP_Booste| = 41
                    // %Résistance_Eau_Fixe_PVP_Base,%Résistance_Eau_Fixe_PVP_Equipement,%Résistance_Eau_Fixe_PVP_Dons,%Résistance_Eau_Fixe_PVP_Booste| = 42

                    // Résistance_Air_Fixe_Base,Résistance_Air_Fixe_Equipement,Résistance_Air_Fixe_Dons,Résistance_Air_Fixe_Booste| = 43
                    // %Résistance_Air_Fixe_Base,%Résistance_Air_Fixe_Equipement,%Résistance_Air_Fixe_Dons,%Résistance_Air_Fixe_Booste| = 44
                    // Résistance_Air_Fixe_PVP_Base,Résistance_Air_Fixe_PVP_Equipement,Résistance_Air_Fixe_PVP_Dons,Résistance_Air_Fixe_PVP_Booste| = 45
                    // %Résistance_Air_Fixe_PVP_Base,%Résistance_Air_Fixe_PVP_Equipement,%Résistance_Air_Fixe_PVP_Dons,%Résistance_Air_Fixe_PVP_Booste| = 46

                    // Résistance_Feu_Fixe_Base,Résistance_Feu_Fixe_Equipement,Résistance_Feu_Fixe_Dons,Résistance_Feu_Fixe_Booste| = 47
                    // %Résistance_Feu_Fixe_Base,%Résistance_Feu_Fixe_Equipement,%Résistance_Feu_Fixe_Dons,%Résistance_Feu_Fixe_Booste| = 48
                    // Résistance_Feu_Fixe_PVP_Base,Résistance_Feu_Fixe_PVP_Equipement,Résistance_Feu_Fixe_PVP_Dons,Résistance_Feu_Fixe_PVP_Booste| = 49
                    // %Résistance_Feu_Fixe_PVP_Base,%Résistance_Feu_Fixe_PVP_Equipement,%Résistance_Feu_Fixe_PVP_Dons,%Résistance_Feu_Fixe_PVP_Booste| = 50

                    // 73 = 51 (Inconnu)

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), "|");
                    string[] separate;

                    withBlock.Caracteristique.Capital = separateData[2];
                    // .Sort.Capital = separateData(3)

                    {
                        var withBlock1 = withBlock.Personnage;
                        withBlock1.Kamas = separateData[1];

                        separate = Strings.Split(separateData[5], ",");
                        withBlock1.Regeneration = System.Convert.ToDouble(separate[0]) / (double)System.Convert.ToDouble(separate[1]) * 100;

                        {
                            var withBlock2 = withBlock1.Experience;
                            separate = Strings.Split(separateData[0], ",");

                            withBlock2.Minimum = separate[1];
                            withBlock2.Maximum = separate[2];
                            withBlock2.Actuelle = separate[0];
                            withBlock2.Pourcentage = (separate[0] - separate[1]) / (separate[2] - separate[1]) * 100;
                        }

                        {
                            var withBlock2 = withBlock1.Vitaliter;
                            separate = Strings.Split(separateData[5], ",");

                            withBlock2.Maximum = separate[1];
                            withBlock2.Actuelle = separate[0] < 0 ? 0 : separate[0];
                            withBlock2.Pourcentage = separate[0] < 0 ? 0 : separate[0] / (double)separate[1] * 100;
                        }

                        {
                            var withBlock2 = withBlock1.Energie;
                            separate = Strings.Split(separateData[6], ",");

                            withBlock2.Maximum = separate[1];
                            withBlock2.Actuelle = separate[0];
                            withBlock2.Pourcentage = separate[0] < 0 ? 0 : separate[0] / (double)separate[1] * 100;
                        }
                    }

                    Caracteristique_Variable.Caracteristiques newCaracteristiqueAvancee = new Caracteristique_Variable.Caracteristiques();

                    {
                        var withBlock1 = newCaracteristiqueAvancee;
                        {
                            var withBlock2 = withBlock1.Primaire;
                            {
                                var withBlock3 = withBlock2.Initiative;
                                separate = Strings.Split(separateData[7], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Prospection;
                                separate = Strings.Split(separateData[8], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.PA;
                                separate = Strings.Split(separateData[9], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.PM;
                                separate = Strings.Split(separateData[10], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Force;
                                separate = Strings.Split(separateData[11], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Vitalite;
                                separate = Strings.Split(separateData[12], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Sagesse;
                                separate = Strings.Split(separateData[13], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Chance;
                                separate = Strings.Split(separateData[14], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Agilite;
                                separate = Strings.Split(separateData[15], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Intelligence;
                                separate = Strings.Split(separateData[16], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Portee;
                                separate = Strings.Split(separateData[17], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Maximum_De_Creatures_Invocables;
                                separate = Strings.Split(separateData[18], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }
                        }

                        {
                            var withBlock2 = withBlock1.Bonus;
                            {
                                var withBlock3 = withBlock2.Degats;
                                separate = Strings.Split(separateData[19], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Degats_Physiques;
                                separate = Strings.Split(separateData[20], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Maitrise_Arme;
                                separate = Strings.Split(separateData[21], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Dommages_PR;
                                separate = Strings.Split(separateData[22], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Soins;
                                separate = Strings.Split(separateData[23], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Pieges;
                                separate = Strings.Split(separateData[24], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Pieges_PR;
                                separate = Strings.Split(separateData[25], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Renvoi_De_Dommages;
                                separate = Strings.Split(separateData[26], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Coups_Critiques;
                                separate = Strings.Split(separateData[27], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.Echecs_Critiques;
                                separate = Strings.Split(separateData[28], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }
                        }

                        {
                            var withBlock2 = withBlock1.Esquive;
                            {
                                var withBlock3 = withBlock2.PA;
                                separate = Strings.Split(separateData[29], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }

                            {
                                var withBlock3 = withBlock2.PM;
                                separate = Strings.Split(separateData[30], ",");

                                withBlock3.Base = separate[0];
                                withBlock3.Equipement = separate.Length > 1 ? separate[1] : "0";
                                withBlock3.Dons = separate.Length > 1 ? separate[2] : "0";
                                withBlock3.Boost = separate.Length > 1 ? separate[3] : "0";
                                withBlock3.Total = withBlock3.Base + withBlock3.Equipement + withBlock3.Dons + withBlock3.Boost;
                            }
                        }

                        {
                            var withBlock2 = withBlock1.Resistance;
                            {
                                var withBlock3 = withBlock2.Combat;
                                {
                                    var withBlock4 = withBlock3.Neutre;
                                    {
                                        var withBlock5 = withBlock4.Fixe;
                                        separate = Strings.Split(separateData[31], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }

                                    {
                                        var withBlock5 = withBlock4.Pourcentage;
                                        separate = Strings.Split(separateData[32], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }
                                }

                                {
                                    var withBlock4 = withBlock3.Terre;
                                    {
                                        var withBlock5 = withBlock4.Fixe;
                                        separate = Strings.Split(separateData[35], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }

                                    {
                                        var withBlock5 = withBlock4.Fixe;
                                        separate = Strings.Split(separateData[36], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }
                                }

                                {
                                    var withBlock4 = withBlock3.Eau;
                                    {
                                        var withBlock5 = withBlock4.Fixe;
                                        separate = Strings.Split(separateData[39], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }

                                    {
                                        var withBlock5 = withBlock4.Pourcentage;
                                        separate = Strings.Split(separateData[40], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }
                                }

                                {
                                    var withBlock4 = withBlock3.Air;
                                    {
                                        var withBlock5 = withBlock4.Fixe;
                                        separate = Strings.Split(separateData[43], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }

                                    {
                                        var withBlock5 = withBlock4.Pourcentage;
                                        separate = Strings.Split(separateData[44], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }
                                }

                                {
                                    var withBlock4 = withBlock3.Feu;
                                    {
                                        var withBlock5 = withBlock4.Fixe;
                                        separate = Strings.Split(separateData[47], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }

                                    {
                                        var withBlock5 = withBlock4.Pourcentage;
                                        separate = Strings.Split(separateData[48], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }
                                }
                            }

                            {
                                var withBlock3 = withBlock2.PvP;
                                {
                                    var withBlock4 = withBlock3.Neutre;
                                    {
                                        var withBlock5 = withBlock4.Fixe;
                                        separate = Strings.Split(separateData[33], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }

                                    {
                                        var withBlock5 = withBlock4.Pourcentage;
                                        separate = Strings.Split(separateData[34], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }
                                }

                                {
                                    var withBlock4 = withBlock3.Terre;
                                    {
                                        var withBlock5 = withBlock4.Fixe;
                                        separate = Strings.Split(separateData[37], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }

                                    {
                                        var withBlock5 = withBlock4.Fixe;
                                        separate = Strings.Split(separateData[38], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }
                                }

                                {
                                    var withBlock4 = withBlock3.Eau;
                                    {
                                        var withBlock5 = withBlock4.Fixe;
                                        separate = Strings.Split(separateData[41], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }

                                    {
                                        var withBlock5 = withBlock4.Pourcentage;
                                        separate = Strings.Split(separateData[42], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }
                                }

                                {
                                    var withBlock4 = withBlock3.Air;
                                    {
                                        var withBlock5 = withBlock4.Fixe;
                                        separate = Strings.Split(separateData[45], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }

                                    {
                                        var withBlock5 = withBlock4.Pourcentage;
                                        separate = Strings.Split(separateData[46], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }
                                }

                                {
                                    var withBlock4 = withBlock3.Feu;
                                    {
                                        var withBlock5 = withBlock4.Fixe;
                                        separate = Strings.Split(separateData[49], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }

                                    {
                                        var withBlock5 = withBlock4.Pourcentage;
                                        separate = Strings.Split(separateData[50], ",");

                                        withBlock5.Base = separate[0];
                                        withBlock5.Equipement = separate.Length > 1 ? separate[1] : "0";
                                        withBlock5.Dons = separate.Length > 1 ? separate[2] : "0";
                                        withBlock5.Boost = separate.Length > 1 ? separate[3] : "0";
                                        withBlock5.Total = withBlock5.Base + withBlock5.Equipement + withBlock5.Dons + withBlock5.Boost;
                                    }
                                }
                            }
                        }
                    }

                    withBlock.Caracteristique.Avancee = newCaracteristiqueAvancee;
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "MdlCaracteristique_Caracteristique", data + Constants.vbCrLf + ex.Message);
                }
            }
        }

        public static void Up_Echec(string data)
        {
            {
                var withBlock = Bot;
                try
                {


                    // ABE
                    // Echec

                    EcritureMessage("[Dofus]", "Impossible de up la caractéristique.", Color.Red);
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "MdlCaracteristique_GiCaracteristiqueUpEchec", data + Constants.vbCrLf + ex.Message);
                }
            }
        }
    }
}
