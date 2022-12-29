﻿using System;
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

public static class Variable
{
    public static Compte Bot = new Compte();







    public delegate void DlgSub();

    public delegate void DlgPlayer(int index, string data);
    public delegate void DlgPlayerAll();
    public delegate void DlgFPlayer(int index, string data);
    public delegate void DlgFPlayerAll();

    public static string PathMitm;
    public static string PathHost;







    public static int Compteur_Compte;
    public static List<string> ListOfBotName = new List<string>();

    internal static Dictionary<string, ClassServeur> VarServeur = new Dictionary<string, ClassServeur>();
    public static Dictionary<int, Dictionary<int, Sort_Variable.Information>> VarSort = new Dictionary<int, Dictionary<int, Sort_Variable.Information>>();
    public static Dictionary<int, sItems> VarItems = new Dictionary<int, sItems>();
    public static Dictionary<int, string> VarQuête = new Dictionary<int, string>();
    public static Dictionary<int, string> VarMap = new Dictionary<int, string>();
    public static Dictionary<int, sInteraction> VarInteraction = new Dictionary<int, sInteraction>();
    public static Dictionary<int, sInteraction> VarRecolte = new Dictionary<int, sInteraction>();
    public static Dictionary<int, Dictionary<int, sMobs>> VarMobs = new Dictionary<int, Dictionary<int, sMobs>>();
    public static Dictionary<int, string> VarPnj = new Dictionary<int, string>();
    public static Dictionary<int, string> VarPnjRéponse = new Dictionary<int, string>();
    public static Dictionary<int, sMaison> VarMaison = new Dictionary<int, sMaison>();
    public static Dictionary<int, sMetier> VarMetier = new Dictionary<int, sMetier>();
    public static Dictionary<int, sFamilier> VarFamilier = new Dictionary<int, sFamilier>();
    public static Dictionary<string, Dictionary<string, string[]>> VarCaractéristique = new Dictionary<string, Dictionary<string, string[]>>();
    public static Dictionary<string, sPersonnage> VarPersonnage = new Dictionary<string, sPersonnage>();
    public static Dictionary<int, string> VarItemsCategorieNom = new Dictionary<int, string>()
    {
        {
            2,
            "Arc"
        },
        {
            3,
            "Baguette"
        },
        {
            4,
            "Baton"
        },
        {
            0,
            "Inconnu"
        }
    };
    public static Dictionary<int, string> VarDragodindeId = new Dictionary<int, string>()
    {
        {
            1,
            "Amande Sauvage"
        },
        {
            3,
            "Ebene"
        },
        {
            6,
            "Rousse Sauvage"
        },
        {
            9,
            "Ebene et Ivoire"
        },
        {
            10,
            "Rousse"
        },
        {
            11,
            "Ivoire et Rousse"
        },
        {
            12,
            "Ebene et Rousse"
        },
        {
            15,
            "Turquoise"
        },
        {
            16,
            "Ivoire"
        },
        {
            17,
            "Indigo"
        },
        {
            18,
            "Doree"
        },
        {
            19,
            "Pourpre"
        },
        {
            20,
            "Amande"
        },
        {
            21,
            "Emeraude"
        },
        {
            22,
            "Orchidee"
        },
        {
            23,
            "Prune"
        },
        {
            33,
            "Amande et Doree"
        },
        {
            34,
            "Amande et Ebene"
        },
        {
            35,
            "Amande et Emeraude"
        },
        {
            36,
            "Amande et Indigo"
        },
        {
            37,
            "Amande et Ivoire"
        },
        {
            38,
            "Amande et Rousse"
        },
        {
            39,
            "Amande et Turquoise"
        },
        {
            40,
            "Amande et Orchidee"
        },
        {
            41,
            "Amande et Pourpre"
        },
        {
            42,
            "Doree et Ebene"
        },
        {
            43,
            "Doree et Emeraude"
        },
        {
            44,
            "Doree et Indigo"
        },
        {
            45,
            "Doree et Ivoire"
        },
        {
            46,
            "Doree et Rousse"
        },
        {
            47,
            "Doree et Turquoise"
        },
        {
            48,
            "Doree et Orchidee"
        },
        {
            49,
            "Doree et Pourpre"
        },
        {
            50,
            "Ebene et Emeraude"
        },
        {
            51,
            "Ebene et Indigo"
        },
        {
            52,
            "Ebene et Turquoise"
        },
        {
            53,
            "Ebene et Orchidee"
        },
        {
            54,
            "Ebene et Pourpre"
        },
        {
            55,
            "Emeraude et Indigo"
        },
        {
            56,
            "Emeraude et Ivoire"
        },
        {
            57,
            "Emeraude et Rousse"
        },
        {
            58,
            "Emeraude et Turquoise"
        },
        {
            59,
            "Emeraude et Orchidee"
        },
        {
            60,
            "Emeraude et Pourpre"
        },
        {
            61,
            "Indigo et Ivoire"
        },
        {
            62,
            "Indigo et Rousse"
        },
        {
            63,
            "Indigo et Turquoise"
        },
        {
            64,
            "Indigo et Orchidee"
        },
        {
            65,
            "Indigo et Pourpre"
        },
        {
            66,
            "Ivoire et Turquoise"
        },
        {
            67,
            "Ivoire et Orchidee"
        },
        {
            68,
            "Ivoire et Pourpre"
        },
        {
            69,
            "Turquoise et Rousse"
        },
        {
            70,
            "Orchidee et Rousse"
        },
        {
            71,
            "Pourpre et Rousse"
        },
        {
            72,
            "Turquoise et Orchidee"
        },
        {
            73,
            "Turquoise et Pourpre"
        },
        {
            74,
            "Doree Sauvage"
        },
        {
            76,
            "Orchidee et Pourpre"
        },
        {
            77,
            "Prune et Amande"
        },
        {
            78,
            "Prune et Doree"
        },
        {
            79,
            "Prune et Ebene"
        },
        {
            80,
            "Prune et Emeraude"
        },
        {
            82,
            "Prune et Indigo"
        },
        {
            83,
            "Prune et Ivoire"
        },
        {
            84,
            "Prune et Rousse"
        },
        {
            85,
            "Prune et Turquoise"
        },
        {
            86,
            "Prune et Orchidee"
        },
        {
            87,
            "Prune et Pourpre"
        },
        {
            88,
            "En Armure"
        },
        {
            89,
            "a Plumes"
        }
    };
    public static List<int> Liste_Archimonstre = new List<int>() { 2354, 2336, 2310, 2315, 2316, 2357, 2312, 2341, 2342, 2344, 2345, 2347, 2327, 2574, 2343, 2355, 2356, 2323, 2348, 2393, 2313, 2352, 2487, 2522, 2332, 2317, 2520, 2371, 2331, 2286, 2402, 2318, 2293, 2294, 2358, 2314, 2494, 2541, 2292, 2301, 2353, 2427, 2431, 2302, 2399, 2400, 2396, 2401, 2430, 2334, 2549, 2349, 2325, 2298, 2304, 2397, 2411, 2324, 2378, 2295, 2548, 2437, 2346, 2338, 2340, 2272, 2297, 2532, 2413, 2484, 2333, 2533, 2542, 2296, 2416, 2403, 2440, 2277, 2335, 2417, 2424, 2425, 2426, 2326, 2529, 2329, 2486, 2379, 2376, 2305, 2321, 2436, 2416, 2309, 2521, 2280, 2281, 2282, 2283, 2276, 2404, 2405, 2406, 2407, 2408, 2432, 2615, 2421, 2339, 2299, 2385, 2319, 2439, 2350, 2285, 2465, 2415, 2557, 2558, 2559, 2560, 2328, 2392, 2311, 2498, 2308, 2420, 2384, 2391, 2433, 2493, 2508, 2525, 2539, 2540, 2585, 2289, 2573, 2320, 2322, 2423, 2442, 2568, 2517, 2616, 2524, 2575, 2582, 2583, 2584, 2279, 2389, 2438, 2592, 2422, 2556, 2359, 2593, 2502, 2507, 2505, 2506, 2590, 2581, 2273, 2589, 2555, 2369, 2368, 2451, 2367, 2453, 2459, 2455, 2457, 2527, 2287, 2510, 2591, 2351, 2434, 2419, 2538, 2377, 2372, 2450, 2449, 2513, 2516, 2509, 2518, 2275, 2588, 2554, 2466, 2467, 2563, 2468, 2545, 2579, 2561, 2547, 2428, 2474, 2476, 2473, 2475, 2472, 2503, 2580, 2337, 2598, 2571, 2572, 2448, 2447, 2446, 2445, 2461, 2497, 2412, 2543, 2306, 2511, 2388, 2414, 2482, 2495, 2515, 2271, 2270, 2386, 2429, 2577, 2398, 2464, 2452, 2562, 2550, 2546, 2360, 2565, 2519, 2514, 2528, 2534, 2363, 2307, 2566, 2569, 2361, 2544, 2454, 2456, 2458, 2460, 2278, 2512, 2526, 2462, 2567, 2531, 2383, 2300, 2587, 2570, 2382, 2381, 2578, 2553, 2303, 2601, 2552, 2370, 2469, 2373, 2551, 2600, 2471, 2374, 2597, 2614, 2564, 2483, 2477, 2470 };

    struct sFamilier
    {
        public string Nom;
        public Dictionary<string, List<int>> Caracteristique;
        public int IntervalRepasMin;
        public int IntervalRepasMax;
        public int CapacitéNormal;
        public int CapacitéMax;
    }

    struct sMetier
    {
        public int ID;
        public string Nom;
        public Dictionary<int, sMetierAtelierRessource> AtelierRessource;
    }

    struct sMetierAtelierRessource
    {
        public int ID;
        public string Nom;
        public string Action;
    }

    struct sMaison
    {
        public string Nom;
        public string Map;
        public string CellulePorte;
        public string MapId;
    }

    struct sMobs
    {
        public int ID;
        public string Nom;
        public int Niveau;
        public int RésistanceNeutre;
        public int RésistanceTerre;
        public int RésistanceFeu;
        public int RésistanceEau;
        public int RésistanceAir;
        public int EsquivePA;
        public int EsquivePM;
    }

    struct sPersonnage
    {
        public int ID;
        public string Nom;
        public string Sexe;
    }

    struct sItems
    {
        public int ID;
        public string Nom;
        public int Catégorie;
        public int Pods;
    }

    struct sInteraction
    {
        public int IdSprite;
        public string Name;
        public Dictionary<string, int> DicoInteraction;
    }
}
