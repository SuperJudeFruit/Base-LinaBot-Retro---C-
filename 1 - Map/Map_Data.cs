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

namespace Map
{
    namespace Chargement
    {
        static class Map_Chargement
        {
            public static void Base(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GDM | 534    | 0706131721 | 755220465939692F276671264132675c756345246c4b463b43427a3a4d38556e3c722a356362224e343d3423333e722c3f3a7a4e23553555672c733d602062454e3d474b20633c6335763e63682c43554937222f79333f253235346863387a287039474d4070302532357d586327675668752a3b6a24622962426e78787373512c5853515626536239367320643c53 
                        // GDM | ID Map | Indice     | Clef

                        string[] separateData = Strings.Split(data, "|");

                        withBlock.Map.Deplacement = false;
                        withBlock.Map.Bloque.Set();

                        withBlock.Combat = new Combat_Variable.Base();
                        withBlock.Defi = new Defi_Variable.Base();
                        withBlock.Map = new Map_Variable.Base();
                        withBlock.Enclos = new Enclos_Variable.Base();

                        withBlock.Maison.Map.Clear();

                        withBlock.Map.ID = separateData[1];

                        Information(separateData[1], separateData[2], separateData[3]);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Map_Chargement_Base", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            private static void Information(string idMap, string indice, string clef)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        withBlock.Map.Bas = null;
                        withBlock.Map.Droite = null;
                        withBlock.Map.Gauche = null;
                        withBlock.Map.Haut = null;

                        // Si le dossier map n'existe pas, alors je le créer
                        if (!System.IO.Directory.Exists("Maps"))
                            System.IO.Directory.CreateDirectory("Maps");

                        // Si le fichier de la map n'existe pas alors je le créer et ajoute les infos dedans.
                        if (!System.IO.File.Exists("Maps/" + idMap + "_" + indice + "X.txt"))
                        {
                            SwfUnpacker Unpacker = new SwfUnpacker();
                            Unpacker.SwfUnpack(idMap + "_" + indice + "X.swf");
                        }

                        // Je lis le fichier voulu. 
                        System.IO.StreamReader mapReader = new System.IO.StreamReader("Maps/" + idMap + "_" + indice + "X.txt");
                        string[] mapData = Strings.Split(mapReader.ReadLine(), "|");
                        mapReader.Close();

                        withBlock.Map.Largeur = mapData[2];
                        withBlock.Map.Hauteur = mapData[3];

                        // Je prépare le nécessaire pour décrypt la map et connaitre se qu'il se trouve dessus.
                        string preparedKey = PrepareKey(clef);
                        withBlock.Map.Handler = UncompressMap(DecypherData(mapData[1], preparedKey, Convert.ToInt64(Checksum(preparedKey), 16) * 2));
                        withBlock.Map.Coordonnees = VarMap(idMap);

                        int count = withBlock.Map.Handler.Length - 1;
                        int num = 0;

                        // J'obtient les cellules qui me permet de changer de map via les soleils.
                        for (int i = 1; i <= withBlock.Map.Handler.Length - 1; i++)
                        {
                            if ((withBlock.Map.Handler(i).movement > 0))
                            {
                                if ((withBlock.Map.Handler(i).layerObject1Num == 1030) || (withBlock.Map.Handler(i).layerObject2Num == 1030) || (withBlock.Map.Handler(i).layerObject2Num == 4088) || (withBlock.Map.Handler(i).layerObject1Num == 4088))
                                {
                                    int x = getX(i, withBlock.Map.Largeur);
                                    int y = getY(i, withBlock.Map.Largeur);
                                    if (x - 1 == y || x - 2 == y)
                                    {
                                        if (withBlock.Map.Gauche == null/* TODO Change to default(_) if this is not a reference type */ )
                                            withBlock.Map.Gauche = i;// Gauche
                                    }
                                    else if (x - (withBlock.Map.Largeur + withBlock.Map.Hauteur) + 5 == y || x - (withBlock.Map.Largeur + withBlock.Map.Hauteur) + 5 == y - 1)
                                        withBlock.Map.Droite = i; // Droite
                                    else if (y + x == (withBlock.Map.Largeur + withBlock.Map.Hauteur) - 1 || y + x == (withBlock.Map.Largeur + withBlock.Map.Hauteur) - 2 || (y + x == (withBlock.Map.Largeur + withBlock.Map.Hauteur)))
                                    {
                                        if (withBlock.Map.Bas == null/* TODO Change to default(_) if this is not a reference type */ )
                                            withBlock.Map.Bas = i;// Bas
                                    }
                                    else if (y <= 0)
                                    {
                                        y = Math.Abs(y);
                                        if (x - y < 3)
                                        {
                                            if (withBlock.Map.Haut == null/* TODO Change to default(_) if this is not a reference type */ )
                                                withBlock.Map.Haut = i;// Haut
                                        }
                                    }
                                }
                            }
                        }

                        Interaction(withBlock.Map.Handler);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Map_Chargement_Information", ex.Message);
                    }
                }
            }

            private static void Interaction(Cell[] spritesHandler)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        withBlock.Map.Interaction.Clear();

                        // id sprite | nom action | nom item , id action

                        for (int i = 1; i <= 1000; i++)
                        {
                            if (VarInteraction.ContainsKey(spritesHandler[i].layerObject2Num))
                            {
                                Interaction_Variable.Base newInteraction = new Interaction_Variable.Base();

                                {
                                    var withBlock1 = newInteraction;
                                    withBlock1.Sprite = spritesHandler[i].layerObject2Num.ToString;

                                    withBlock1.Cellule = i.ToString();

                                    withBlock1.Nom = VarInteraction(spritesHandler[i].layerObject2Num).Name.ToLower;

                                    withBlock1.Disponible = true;

                                    withBlock1.Action = VarInteraction(spritesHandler[i].layerObject2Num).DicoInteraction;
                                }

                                withBlock.Map.Interaction.Add(i.ToString(), newInteraction);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Map_Chargement_Interaction", ex.Message);
                    }
                }
            }
        }
    }

    namespace Information
    {
        static class Map_Information
        {
            public static void Entite_Ajoute(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        string[] separateData = Strings.Split(data, "|+");

                        for (var i = 1; i <= separateData.Length - 1; i++)
                        {
                            string[] separate = Strings.Split(separateData[i], ";");

                            Map_Variable.Entite newMap = new Map_Variable.Entite();
                            Combat_Variable.Entite newCombat = new Combat_Variable.Entite();

                            {
                                var withBlock1 = newMap;
                                withBlock1.Cellule = separate[0];
                                withBlock1.IDUnique = separate[3];
                                withBlock1.Orientation = separate[1];
                                withBlock1.Categorie = separate[5];

                                switch (separate[5])
                                {
                                    case -1:
                                    case -2 // Mobs (en combat)
                                   :
                                        {

                                            // GM|+ 369     ; 1           ; 0 ; -1        ; 149     ; -2      ; 1571^95 ; 2          ; -1 ; -1 ; -1 ; 0 , 0 , 0 , 0 ; 18       ; 5  ; 3  ; 1 
                                            // GM|+ Cellule ; Orientation ; ? ; id Unique ; Id Mobs ; indice  ; ?       ; Level mobs ; ?  ; ?  ; ?  ; ? , ? , ? , ? ; Vitalité ; PA ; PM ; ? 

                                            withBlock1.Nom = VarMobs(separate[4])(System.Convert.ToInt32(separate[7] - 1)).Nom;
                                            withBlock1.Niveau = VarMobs(separate[4])(System.Convert.ToInt32(separate[7] - 1)).Niveau;
                                            withBlock1.ID = separate[4];

                                            {
                                                var withBlock2 = newCombat;
                                                withBlock2.Vitalite = separate[12];
                                                withBlock2.PA = separate[13];
                                                withBlock2.PM = separate[14];
                                                withBlock2.Resistance.Neutre = VarMobs(separate[4])(separate[7] - 1).RésistanceNeutre;
                                                withBlock2.Resistance.Terre = VarMobs(separate[4])(separate[7] - 1).RésistanceTerre;
                                                withBlock2.Resistance.Feu = VarMobs(separate[4])(separate[7] - 1).RésistanceFeu;
                                                withBlock2.Resistance.Eau = VarMobs(separate[4])(separate[7] - 1).RésistanceEau;
                                                withBlock2.Resistance.Air = VarMobs(separate[4])(separate[7] - 1).RésistanceAir;
                                                withBlock2.Esquive.PA = VarMobs(separate[4])(separate[7] - 1).EsquivePA;
                                                withBlock2.Esquive.PM = VarMobs(separate[4])(separate[7] - 1).EsquivePM;
                                            }

                                            break;
                                        }

                                    case -3 // Mobs (Hors combat)
                             :
                                        {

                                            // GM|+ 439     ; 5           ; 21      ; -2     ; 198     , 241     ; -3     ;1135^110,1138^100 ; 36 , 32 ; -1       , -1       , -1       ;0,0,0,0;-1,-1,-1;0,0,0,0; 
                                            // GM|+ Cellule ; Orientation ; Etoile% ; ID Map ; ID Mobs , Id Mobs ; Entité ;                  ; Lv , Lv ; Couleur1 , Couleur2 , Couleur3 ;?,?,?,?;Couleur1,etc... 

                                            withBlock1.Nom = Map_Function.NomMobs(separate[4]);
                                            withBlock1.ID = separate[4];
                                            withBlock1.Niveau = separate[7];
                                            withBlock1.Etoile = separate[2];
                                            break;
                                        }

                                    case -4 // Pnj-------------------
                             :
                                        {

                                            // GM|+ 152     ; 3           ; 0        ;-1      ; 100    ; -4     ; 9048^100 ; 0  ; -1 ; -1 ; e7b317 ;   ,   ,   ,   ,   ;   ; 0 |
                                            // GM|+ Cellule ; Orientation ; Etoiles% ; ID Map ; ID PNJ ; Entité ; ?        ; Lv ; ?  ; ?  ; ?      ; ? , ? , ? , ? , ? ; ? ; ? | Next PNJ

                                            withBlock1.Nom = VarPnj(separate[4]);
                                            withBlock1.Niveau = separate[7];
                                            withBlock1.ID = separate[4];
                                            withBlock1.Etoile = separate[2];
                                            withBlock1.IDUnique = separate[3];
                                            withBlock1.Classe = "Pnj";
                                            break;
                                        }

                                    case -5 // Mode marchand
                             :
                                        {

                                            // GM|+ 412     ; 3           ; 0       ; -82    ; Blackarne ; -5     ; 60^100        ; 0  ; 0 ; -1 ; 22e4 , 27c7   , 22ac , 1cf7     , 27c6     ; Awesomes   ; c , 77f73 , 1m , 5w3r4 ; 0
                                            // GM|+ Cellule ; Orientation ; Etoiles ; ID Map ; Nom       ; Entité ; Classe + sexe ; Lv ; ? ; ?  ; Cac  , Coiffe , Cape , Familier , Bouclier ; Nom guilde ; ? , ?     , ?  , ?     ; ID Sprite Sac du mode marchand

                                            // ID Sprite Sac (se que le marchand vend) 
                                            // 0 = Tout
                                            // 1 = Equipement
                                            // 2 = Divers
                                            // 3 = Ressource

                                            withBlock1.Nom = separate[4];
                                            withBlock1.Classe = Map_Function.ClasseJoueur(separate[6]);
                                            withBlock1.Sexe = Map_Function.SexeJoueur(separate[6]);
                                            withBlock1.Guilde = separate[11];
                                            withBlock1.ModeMarchand = true;
                                            withBlock1.ID = separate[13];

                                            {
                                                var withBlock2 = withBlock1.Equipement;
                                                string[] separateEquipement = Strings.Split(separate[10], ",");

                                                if (separateEquipement[0] != null)
                                                    withBlock2.Cac = VarItems(Convert.ToInt64(separateEquipement[0], 16)).ID;

                                                {
                                                    var withBlock3 = withBlock2.Chapeau;
                                                    if (separateEquipement[1].Contains('~'))
                                                    {
                                                        string[] separateObvijevan = Strings.Split(separateEquipement[1], "~");

                                                        withBlock3.ID = VarItems(Convert.ToInt64(separateObvijevan[0], 16)).ID;
                                                        withBlock3.Niveau = Convert.ToInt64(separateObvijevan[1], 16);
                                                        withBlock3.Forme = Convert.ToInt64(separateObvijevan[2], 16);
                                                    }
                                                    else if (separateEquipement[1] != null)
                                                        withBlock3.ID = VarItems(Convert.ToInt64(separateEquipement[1], 16)).ID;
                                                }

                                                {
                                                    var withBlock3 = withBlock2.Cape;
                                                    if (separateEquipement[2].Contains('~'))
                                                    {
                                                        string[] separateObvijevan = Strings.Split(separateEquipement[2], "~");

                                                        withBlock3.ID = VarItems(Convert.ToInt64(separateObvijevan[0], 16)).ID;
                                                        withBlock3.Niveau = Convert.ToInt64(separateObvijevan[1], 16);
                                                        withBlock3.Forme = Convert.ToInt64(separateObvijevan[2], 16);
                                                    }
                                                    else if (separateEquipement[2] != null)
                                                        withBlock3.ID = VarItems(Convert.ToInt64(separateEquipement[2], 16)).ID;
                                                }

                                                if (separateEquipement[3] != null)
                                                    withBlock2.Familier = VarItems(Convert.ToInt64(separateEquipement[3], 16)).ID;

                                                if (separateEquipement[4] != null)
                                                    withBlock2.Bouclier = VarItems(Convert.ToInt64(separateEquipement[4], 16)).ID;
                                            }

                                            break;
                                        }

                                    case -6 // Percepteur
                             :
                                        {

                                            // GM|+ 383     ; 1 ; 0      ; -14    ; 2l , 3d ; -6     ; 6000^110 ; 66 ; The Chosen Few ; 8 , n2bh , 1 , 9zldr
                                            // GM|+ Cellule ; ? ; Etoile ; ID Map ; Nom     ; Entité ; Sprite   ; Lv ; Nom Guilde     ; ? , ?    , ? , ?

                                            withBlock1.Nom = separate[4];
                                            withBlock1.IDUnique = separate[3];
                                            withBlock1.Classe = separate[5];
                                            withBlock1.Niveau = separate[7];
                                            withBlock1.Etoile = separate[2];
                                            withBlock1.Guilde = separate[8];
                                            break;
                                        }

                                    case -9 // Dragodinde
                             :
                                        {
                                            break;
                                        }

                                    case -10 // Prisme
                           :
                                        {
                                            break;
                                        }

                                    case object _ when separate[5] > 0 // Joueur
                           :
                                        {

                                            // Hors Combat
                                            // GM|+ 156     ; 7           ; 0 ; 0123456   ; Linaculer ; 9       ; 90^100      ; 0                          ; 0          , 0 , 0 , 1234567           ; -1       ; -1       ; -1       ;     , 2412~16~7                  , 2411~17~15               ,          ,          ; 0   ;   ;   ;           ;                 ; 0 ;    ;   | Next tchatJoueur
                                            // GM|~ 300     ; 1           ; 0 ; 0123456   ; linaculer ; 9       ; 90^100      ; 0                          ; 0          , 0 , 0 , 1234567           ; 0        ; 1eeb13   ; 0        ; b4  , 2412~16~18                 , 2411~17~19               ,          ,          ; 1   ;   ;   ; Chernobil ; f,9zldr,x,6k26u ; 0 ; 88 ;
                                            // GM|+ Cellule ; Orientation ; ? ; Id Unique ; Nom       ; ID Race ; Classe+sexe ; Combat (Equipe bleu/rouge) ; Alignement , ? , ? , ID Unique + Level ; Couleur1 ; Couleur2 ; Couleur3 ; Cac , Coiffe (ID Objet~Lv~Forme) , Cape (ID Objet~Lv~Forme) , Familier , Bouclier ; ?   ; ? ; ? ; Guilde    ; ?               ; ? ; ?  ; ?  

                                            // En combat 
                                            // GM|+ 105     ; 1           ; 0 ; 0123456   ; Linaculer ; 9       ; 90^100      ; 0                          ; 99 ; 0          , 0 , 0 , 1234567           ; -1       ; -1       ; -1       ; 241 , 1bea                       , 6ab                      ,          ,          ; 672      ; 7  ; 3  ; 0           ; 1          ; 0        ; 2         ; 0        ; 77         ; 77         ; 0 ;   ;                         
                                            // GM|+ Cellule ; Orientation ; ? ; Id Unique ; Nom       ; ID Race ; Classe+sexe ; Combat (Equipe bleu/rouge) ; Lv ; Alignement , ? , ? , ID Unique + Level ; Couleur1 ; Couleur2 ; Couleur3 ; Cac , Coiffe (ID Objet~Lv~Forme) , Cape (ID Objet~Lv~Forme) , Familier , Bouclier ; Vitalité ; PA ; PM ; %Rés neutre ; %Rés Terre ; %Rés feu ; %Rés Eau  ; %Res air ; Esquive PA ; Esquive PM ; ? ; ? ; ? 
                                            // GM|~ = Sur une dragodinde

                                            string[] calculLevel;
                                            string[] separateEquipement;

                                            if (Bot.Combat.Combat)
                                            {
                                                separateEquipement = Strings.Split(separate[13], ",");
                                                calculLevel = Strings.Split(separate[9], ",");
                                            }
                                            else
                                            {
                                                separateEquipement = Strings.Split(separate[12], ",");
                                                calculLevel = Strings.Split(separate[8], ",");
                                            }

                                            withBlock1.Nom = separate[4];
                                            withBlock1.ModeMarchand = false;

                                            withBlock1.Sexe = Map_Function.SexeJoueur(separate[6]);
                                            withBlock1.Classe = Map_Function.ClasseJoueur(separate[6]);

                                            if (Bot.Combat.Combat)
                                            {
                                                withBlock1.Alignement = Map_Function.AlignementJoueur(calculLevel[0]);
                                                withBlock1.Niveau = separate[8];

                                                {
                                                    var withBlock2 = newCombat;
                                                    withBlock2.Vitalite = separate[14];
                                                    withBlock2.PA = separate[15];
                                                    withBlock2.PM = separate[16];
                                                    withBlock2.Resistance.Neutre = separate[17];
                                                    withBlock2.Resistance.Terre = separate[18];
                                                    withBlock2.Resistance.Feu = separate[19];
                                                    withBlock2.Resistance.Eau = separate[20];
                                                    withBlock2.Resistance.Air = separate[21];
                                                    withBlock2.Esquive.PA = separate[22];
                                                    withBlock2.Esquive.PM = separate[23];
                                                    withBlock2.Equipe = separate[7];
                                                }
                                            }
                                            else
                                            {
                                                withBlock1.Alignement = Map_Function.AlignementJoueur(calculLevel[0]);
                                                withBlock1.Guilde = separate[16];
                                                withBlock1.Niveau = System.Convert.ToInt32(calculLevel[3]) - System.Convert.ToInt32(separate[3]);
                                            }

                                            {
                                                var withBlock2 = withBlock1.Equipement;
                                                if (separateEquipement[0] != null)
                                                    withBlock2.Cac = VarItems(Convert.ToInt64(separateEquipement[0], 16)).ID;

                                                {
                                                    var withBlock3 = withBlock2.Chapeau;
                                                    if (separateEquipement[1].Contains('~'))
                                                    {
                                                        string[] separateObvijevan = Strings.Split(separateEquipement[1], "~");

                                                        withBlock3.ID = VarItems(Convert.ToInt64(separateObvijevan[0], 16)).ID;
                                                        withBlock3.Niveau = Convert.ToInt64(separateObvijevan[1], 16);
                                                        withBlock3.Forme = Convert.ToInt64(separateObvijevan[2], 16);
                                                    }
                                                    else if (separateEquipement[1] != null)
                                                        withBlock3.ID = VarItems(Convert.ToInt64(separateEquipement[1], 16)).ID;
                                                }

                                                {
                                                    var withBlock3 = withBlock2.Cape;
                                                    if (separateEquipement[2].Contains('~'))
                                                    {
                                                        string[] separateObvijevan = Strings.Split(separateEquipement[2], "~");

                                                        withBlock3.ID = VarItems(Convert.ToInt64(separateObvijevan[0], 16)).ID;
                                                        withBlock3.Niveau = Convert.ToInt64(separateObvijevan[1], 16);
                                                        withBlock3.Forme = Convert.ToInt64(separateObvijevan[2], 16);
                                                    }
                                                    else if (separateEquipement[2] != null)
                                                        withBlock3.ID = VarItems(Convert.ToInt64(separateEquipement[2], 16)).ID;
                                                }

                                                if (separateEquipement[3] != null)
                                                    withBlock2.Familier = VarItems(Convert.ToInt64(separateEquipement[3], 16)).ID;

                                                if (separateEquipement[4] != null)
                                                    withBlock2.Bouclier = VarItems(Convert.ToInt64(separateEquipement[4], 16)).ID;
                                            }

                                            break;
                                        }
                                }
                            }

                            if (withBlock.Map.Entite.ContainsKey(separate[3]))
                                withBlock.Map.Entite(separate[3]) = newMap;
                            else
                                withBlock.Map.Entite.Add(separate[3], newMap);

                            if (withBlock.Combat.Combat)
                            {
                                if (withBlock.Combat.Entite.ContainsKey(separate[3]))
                                    withBlock.Combat.Entite(separate[3]) = newCombat;
                                else
                                    withBlock.Combat.Entite.Add(separate[3], newCombat);
                            }

                            if (separate[3] == withBlock.Personnage.ID)
                            {
                                withBlock.Map.StopDeplacement = false;
                                withBlock.Map.Deplacement = false;
                                withBlock.Map.Bloque.Set();
                                withBlock._Send = "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Map_Information_Entite_Ajoute", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Entite_Supprime(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GM|- 1234567
                        // GM|- Id Unique

                        string idUnique = Strings.Mid(data, 5);

                        if (withBlock.Map.Entite.ContainsKey(idUnique))
                            withBlock.Map.Entite.Remove(idUnique);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Map_Information_Entite_Supprime", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Entite_Deplacement(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA  ; 1 ; -1            ; adxfcB
                        // GA0 ; 1 ; -1            ; adxfcB
                        // GA  ; ? ; ID entité Map ; Path

                        string[] separateData = Strings.Split(data, ";");

                        int cellule = ReturnLastCell(Strings.Mid(separateData[3], separateData[3].Length - 1, 2));

                        if (withBlock.Map.Entite.ContainsKey(separateData[2]))
                            withBlock.Map.Entite(separateData[2]).Cellule = cellule;

                        if (separateData[2] == withBlock.Personnage.ID.ToString)
                        {
                            withBlock.Map.Bloque.Reset();

                            withBlock.Map.Deplacement = true;

                            // Mettre ici le temps d'attente avant de pouvoir se deplacer a nouveau
                            // Temps de déplacement entre le point A et B.
                            Task.Run(() => ActionDeplacement(cellule));
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Map_Information_Entite_Deplacement", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            private static void ActionDeplacement(int cellule)
            {
                {
                    var withBlock = Bot;
                    try
                    {
                        if (withBlock._Send != "")
                        {
                            withBlock.Mitm.Send(withBlock._Send);

                            withBlock._Send = "";
                        }
                    }

                    // Ici calcul du temps a attendre avant de pouvoir bouger à nouveau.

                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "PauseDeplacement", ex.Message);
                    }
                }
            }

            public static void Entite_Escalier(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA1 ; 4             ; 01234567  ; 76543210 , 342
                        // GA1 ; Teleportation ; ID Joueur ; ID_Cible , Cellule

                        string[] separateData = Strings.Split(data, ";");

                        string[] separate = Strings.Split(separateData[3], ",");

                        if (withBlock.Map.Entite.ContainsKey(separate[0]))
                            withBlock.Map.Entite(separate[0]).Cellule = separate[1];

                        if (separate[0] == withBlock.Personnage.ID)
                        {
                            withBlock.Mitm.Send("GKK1");
                            withBlock.Map.Deplacement = false;
                            withBlock.Map.Bloque.Set();
                        }
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Map_Information_Entite_Escalier", data + Constants.vbCrLf + ex.Message);
                    }
                }
            } // Sufokia > escalié

            public static void Entite_Teleportation(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA ; 4             ; 01234567  ; 76543210 , 342
                        // GA ; Teleportation ; ID Joueur ; ID_Cible , Cellule

                        string[] separateData = Strings.Split(data, ";");

                        string[] separate = Strings.Split(separateData[3], ",");

                        if (withBlock.Map.Entite.ContainsKey(separate[0]))
                            withBlock.Map.Entite(separate[0]).Cellule = separate[1];
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Map_Information_Entite_Teleportation", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Objet_Ajoute(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GDO+ 358     ; 7596     ; 1                          ; 1500              ; 1500           |
                        // GDO+ Cellule ; Id Objet ; Information supplémentaire ; Résistance actuel ; Résistance Max | Next

                        string[] separateData = Strings.Split(Strings.Mid(data, 5), "|");

                        for (var i = 0; i <= separateData.Length - 1; i++)
                        {
                            string[] separate = Strings.Split(separateData[i], ";");

                            Map_Variable.Objet newMap = new Map_Variable.Objet();

                            {
                                var withBlock1 = newMap;
                                withBlock1.Cellule = separate[0];

                                withBlock1.IdUnique = separate[1];

                                withBlock1.Nom = VarItems(separate[1]).Nom;

                                if (separate[2] == "1")
                                {
                                    withBlock1.Resistance.Minimum = separate[3];
                                    withBlock1.Resistance.Maximum = separate[4];
                                }
                            }

                            withBlock.Map.Objet.Add(separate[0], newMap);
                        }
                    }

                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Map_Information_Objet_Ajoute", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Objet_Supprime(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GDO- 123 
                        // GDO- Cellule

                        int id = Strings.Mid(data, 5);

                        if (withBlock.Map.Objet.ContainsKey(id))
                            withBlock.Map.Objet.Remove(id);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Map_Information__Objet_Supprime", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Orientation(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // eD 2594870   | 7 
                        // eD Id Unique | Orientation

                        string[] separationData = Strings.Split(Strings.Mid(data, 3), "|");

                        if (withBlock.Map.Entite.ContainsKey(separationData[0]))
                            withBlock.Map.Entite(separationData[0]).Orientation = separationData[1];
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Map_Information_Orientation", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Agression(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // GA ; 906 ; 123456789    ; 987654321
                        // GA ; 906 ; Id agresseur ; id Agressé

                        string[] separateData = Strings.Split(data, ";");

                        EcritureMessage("[Dofus]", withBlock.Map.Entite(separateData[2]).Nom + " agresse " + withBlock.Map.Entite(separateData[3]).Nom, Color.Green);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Map_Information_Agression", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }

            public static void Assis_Debout(string data)
            {
                {
                    var withBlock = Bot;
                    try
                    {

                        // eUK Id Joueur | 1
                        // eUK Id Joueur | Assis/Debout

                        string[] separateData = Strings.Split(Strings.Mid(data, 4), "|");

                        if (withBlock.Map.Entite.ContainsKey(separateData[0]))
                            withBlock.Map.Entite(separateData[0]).Assis = separateData[1] != "0";

                        if (separateData[0] == withBlock.Personnage.ID)
                            EcritureMessage("[Dofus]", "Vous êtes assis, votre régénération de point de vie augmente.", Color.Green);
                    }
                    catch (Exception ex)
                    {
                        ErreurFichier(withBlock.Personnage.NomDuPersonnage, "Map_Information_Assis_Debout", data + Constants.vbCrLf + ex.Message);
                    }
                }
            }
        }
    }

    static class Map_Function
    {
        public static string NomMobs(string name)
        {
            string resultat = "";

            try
            {
                string[] separateName = Strings.Split(name, ",");


                for (var i = 0; i <= separateName.Length - 1; i++)

                    resultat += VarMobs(separateName[i])(0).Nom + " , ";
            }
            catch (Exception ex)
            {
            }

            return resultat;
        }

        public static string ClasseJoueur(string Information)
        {
            try
            {
                string[] Classe = new[] { "Feca", "Osamodas", "Enutrof", "Sram", "Xelor", "Ecaflip", "Eniripsa", "Iop", "Cra", "Sadida", "Sacrieur", "Pandawa" };
                string[] separate = Strings.Split(Information, "^"); // 90^100
                int Résultat = Strings.Mid(separate[0], 1, Strings.Len(separate[0]) - 1); // 90

                if (Résultat < 12)
                    return Classe[Résultat - 1];
            }
            catch (Exception ex)
            {
            }

            return "Inconnu";
        }

        public static string SexeJoueur(string Information)
        {
            try
            {
                string[] sexe = new[] { "Homme", "Femme" };
                string[] separate = Strings.Split(Information, "^"); // 90^100

                int number = Strings.Mid(separate[0], Strings.Len(separate[0]), Strings.Len(separate[0]) - 1);

                return number > 1 ? "Inconnu" : sexe[number];
            }
            catch (Exception ex)
            {
            }

            return "Inconnu";
        }

        public static string AlignementJoueur(string numero)
        {
            try
            {
                string[] Alignement = new[] { "Neutre", "Bontarien", "Brakmarien" };

                return Alignement[numero];
            }
            catch (Exception ex)
            {
            }

            return "Inconnu";
        }
    }
}
