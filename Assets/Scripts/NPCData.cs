using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NPCData
{
    public int Id;

    public int GeneralHumor;

    public int AcidityResistance;

    public List<string> KnowReferences;

    public int[] ThemeRecistance;



    public NPCData(int generalHumor, int acidityResistance)
    { 
        Id = 0;
        GeneralHumor = generalHumor;
        AcidityResistance = acidityResistance;
        KnowReferences = new List<string>();
        ThemeRecistance = new int[0];
    }

}
