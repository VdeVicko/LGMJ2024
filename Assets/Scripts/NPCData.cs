using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NPCData
{
    public int Id;

    public int GeneralHumor;

    public int AcidityResistance;

    public int[] ThemeRecistance;

    public List<string> KnowReferences;


    public NPCData(int generalHumor, int acidityResistance, int[] themes, List<string> references )
    { 
        Id = 0;
        GeneralHumor = generalHumor;
        AcidityResistance = acidityResistance;
        ThemeRecistance = themes;
        KnowReferences = references;
    }

}
