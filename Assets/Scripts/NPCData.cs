using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NPCData
{
    const int THEME_QUANTITY = 8;

    public int Id;

    public float GeneralHumor;

    public int AcidityResistance;

    public int[] ThemeRecistance;

    public string[] KnowReferences;


    public NPCData(int id, float generalHumor, int acidityResistance, int[] themes, string[] references )
    { 
        Id = id;
        GeneralHumor = generalHumor;
        AcidityResistance = acidityResistance;
        ThemeRecistance = themes;
        KnowReferences = references;
    }

}
