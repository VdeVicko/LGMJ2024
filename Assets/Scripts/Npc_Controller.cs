using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

public class Npc_Controller : MonoBehaviour
{
    //public struct JokeResponce
    //{

   // };

    //JokeResponce currentJokeResponce;


    
    public Game_Manager_Control GM;
    private SpriteRenderer sprite;

    private NPCData data;
    public float CurrentJokeResponce = 0;
    private float CurrentHappiness = 0;
    private float CurrentAcidityResistance = 0;
    private int[] currentThemeResistances;



    //float Humor;
    //float ResistBitingHumor;

    //public string[] References;
    //public int[] Resistance;
    // Enfermedad, Religion,C,D





    void Start()
    {
       


        //Resistance = new int[ResistanceCount];
    }
    private void Update()
    {
        if(GM.State == 3)
        {
            Reaction();
        }
    }

    public IEnumerator LaughJumps()
    {
        while(true)
        {
            Laugh();
            yield return new WaitForSeconds(1.5f);
        }
    }
    void Reaction()
    {
        int reaction = 2;
        Debug.Log("Pipo React :O");
        switch(reaction)
        {
            case 1:
                Idle();
                break;
            case 2:
            
                Laugh();
                break;
            case 3:
                Complain();
                break;
            default:
                Debug.Log("Error");
                break;

        }
        GM.State = 0;
    }

    void Laugh()
    {
      //  rb.AddForce(transform.up * Happiness,ForceMode.Impulse);
    }

    void Complain()
    {

    }

    void Idle()
    {

    }

    public void SetData(NPCData newData)
    {
        data = newData;

        CurrentAcidityResistance = data.AcidityResistance;

        currentThemeResistances = (int[])data.ThemeRecistance.Clone();
    }

    public NPCData GetData()
    {
        return data;
    }



    public void ProcessJoke(JokeData jokeData)
    {
        Debug.Log("ProcessJoke joke=" + jokeData.JokeId.ToString() + " public=" + data.Id);

        List<string> references = new List<string>(data.KnowReferences);

        bool unknowReference = jokeData.Reference.Length == 0 ? true : references.Contains(jokeData.Reference);

        float themeResistance = 0;

        if (jokeData.ThemeId < currentThemeResistances.Length)
        {
            themeResistance = currentThemeResistances[jokeData.ThemeId] > 0 ? 1 : (currentThemeResistances[jokeData.ThemeId] < 0 ? -1 : 0);

            currentThemeResistances[jokeData.ThemeId]--;
        }


        float acidityResistance = CurrentAcidityResistance > jokeData.Acidity ? 1 : (CurrentAcidityResistance < jokeData.Acidity ? -1 : 0);

        CurrentAcidityResistance -= jokeData.Acidity;

        int resistanceSig = themeResistance < 0 && acidityResistance < 0 ? -1 : 1;


        CurrentJokeResponce = (float)jokeData.Funny * data.GeneralHumor * (unknowReference ? 0 : 1) * themeResistance * acidityResistance * resistanceSig;
        Debug.Log(jokeData.Funny.ToString() + "*" + data.GeneralHumor.ToString() + "*(" + (unknowReference ? "0" : "1") + ")*" + themeResistance.ToString() + "*" + acidityResistance.ToString() + "*" + resistanceSig.ToString());

        CurrentHappiness += CurrentJokeResponce > 0 ? 1 : (CurrentJokeResponce < 0 ? -1 : 0);

    }

}