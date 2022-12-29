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

namespace Sort
{
    static class Sort
    {
        public static void Ajoute(string data)
        {
            {
                var withBlock = Bot;
                try
                {

                    // SL 179     ~ 5     ~ b                    ; Next Sort
                    // SL Id Sort ~ Level ~ Position Bar de sort ; 

                    string[] separateData = Strings.Split(Strings.Mid(data, 3), ";");

                    for (var i = 0; i <= separateData.Length - 2; i++)
                    {
                        string[] separate = Strings.Split(separateData[i], "~");

                        Sort_Variable.Information newSort = new Sort_Variable.Information();

                        if (VarSort.ContainsKey(separate[0]) && VarSort(separate[0]).ContainsKey(separate[1]))
                        {
                            {
                                var withBlock1 = newSort;
                                withBlock1.ID = separate[0];
                                withBlock1.Niveau = separate[1];
                                withBlock1.Nom = VarSort(separate[0])(separate[1]).Nom.ToLower;
                                withBlock1.PO.Minimum = VarSort(separate[0])(separate[1]).PO.Minimum;
                                withBlock1.PO.Maximum = VarSort(separate[0])(separate[1]).PO.Maximum;
                                withBlock1.PA = VarSort(separate[0])(separate[1]).PA;
                                withBlock1.NombreLancerParTour = VarSort(separate[0])(separate[1]).NombreLancerParTour;
                                withBlock1.NombreLancerParTourParJoueur = VarSort(separate[0])(separate[1]).NombreLancerParTourParJoueur;
                                withBlock1.NombreToursEntreDeuxLancers = VarSort(separate[0])(separate[1]).NombreToursEntreDeuxLancers;
                                withBlock1.POModifiable = VarSort(separate[0])(separate[1]).POModifiable;
                                withBlock1.LigneDeVue = VarSort(separate[0])(separate[1]).LigneDeVue;
                                withBlock1.LancerEnLigne = VarSort(separate[0])(separate[1]).LancerEnLigne;
                                withBlock1.CelluleLibre = VarSort(separate[0])(separate[1]).CelluleLibre;
                                withBlock1.ECFiniTour = VarSort(separate[0])(separate[1]).ECFiniTour;
                                withBlock1.Zone.Minimum = VarSort(separate[0])(separate[1]).Zone.Minimum;
                                withBlock1.Zone.Maximum = VarSort(separate[0])(separate[1]).Zone.Maximum;
                                withBlock1.ZoneEffet = VarSort(separate[0])(separate[1]).ZoneEffet;
                                withBlock1.NiveauRequisUp = VarSort(separate[0])(separate[1]).NiveauRequisUp;
                                withBlock1.SortClasse = VarSort(separate[0])(separate[1]).SortClasse;
                                withBlock1.Definition = VarSort(separate[0])(separate[1]).Definition.ToLower;
                                withBlock1.BarreSort = separate[2];
                            }
                        }

                        withBlock.Sort.Ajoute = newSort;
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Sort_Ajoute", data + Constants.vbCrLf + ex.Message);
                }
            }
        }


        public static void Up(string data)
        {
            {
                var withBlock = Bot;

                // SUK 142     ~ 4      ~ B
                // SUK id sort ~ Niveau ~ barre de sort

                try
                {
                    string[] separateData = Strings.Split(Strings.Mid(data, 4), "~");

                    Sort_Variable.Information newSort = new Sort_Variable.Information();

                    if (VarSort.ContainsKey(separateData[0]) && VarSort(separateData[0]).ContainsKey(separateData[1]))
                    {
                        {
                            var withBlock1 = newSort;
                            withBlock1.ID = separateData[0];
                            withBlock1.Niveau = separateData[1];
                            withBlock1.Nom = VarSort(separateData[0])(separateData[1]).Nom;
                            withBlock1.PO.Minimum = VarSort(separateData[0])(separateData[1]).PO.Minimum;
                            withBlock1.PO.Maximum = VarSort(separateData[0])(separateData[1]).PO.Maximum;
                            withBlock1.PA = VarSort(separateData[0])(separateData[1]).PA;
                            withBlock1.NombreLancerParTour = VarSort(separateData[0])(separateData[1]).NombreLancerParTour;
                            withBlock1.NombreLancerParTourParJoueur = VarSort(separateData[0])(separateData[1]).NombreLancerParTourParJoueur;
                            withBlock1.NombreToursEntreDeuxLancers = VarSort(separateData[0])(separateData[1]).NombreToursEntreDeuxLancers;
                            withBlock1.POModifiable = VarSort(separateData[0])(separateData[1]).POModifiable;
                            withBlock1.LigneDeVue = VarSort(separateData[0])(separateData[1]).LigneDeVue;
                            withBlock1.LancerEnLigne = VarSort(separateData[0])(separateData[1]).LancerEnLigne;
                            withBlock1.CelluleLibre = VarSort(separateData[0])(separateData[1]).CelluleLibre;
                            withBlock1.ECFiniTour = VarSort(separateData[0])(separateData[1]).ECFiniTour;
                            withBlock1.Zone.Minimum = VarSort(separateData[0])(separateData[1]).Zone.Minimum;
                            withBlock1.Zone.Maximum = VarSort(separateData[0])(separateData[1]).Zone.Maximum;
                            withBlock1.ZoneEffet = VarSort(separateData[0])(separateData[1]).ZoneEffet;
                            withBlock1.NiveauRequisUp = VarSort(separateData[0])(separateData[1]).NiveauRequisUp;
                            withBlock1.SortClasse = VarSort(separateData[0])(separateData[1]).SortClasse;
                            withBlock1.Definition = VarSort(separateData[0])(separateData[1]).Definition;
                            withBlock1.BarreSort = "";
                        }
                    }

                    if (separateData[1] == "1")
                    {
                        withBlock.Sort.Ajoute = newSort;
                        EcritureMessage("[Dofus]", "Tu as appris le sort " + newSort.Nom, Color.Green);
                    }
                    else
                    {
                        withBlock.Sort.Modifie = newSort;
                        EcritureMessage("[Dofus]", "Le sort '" + newSort.Nom + " est désormais niveau : " + separateData[1] + ".", Color.Green);
                    }
                }
                catch (Exception ex)
                {
                    ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Sort_Up", ex.Message);
                }
            }
        }
    }
}
