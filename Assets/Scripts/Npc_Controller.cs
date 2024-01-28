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


    public Rigidbody rb;
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
        rb = gameObject.GetComponent<Rigidbody>(); 


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

        currentThemeResistances = data.ThemeRecistance;
    }

    public NPCData GetData()
    {
        return data;
    }



    public void ProcessJoke(JokeData jokeData)
    {
        Debug.Log("ProcessJoke joke=" + jokeData.JokeId.ToString() + " public=" + data.Id);

        List<string> references = new List<string>(data.KnowReferences);

        bool knowReference = jokeData.Reference.Length != 0 ? references.Contains(jokeData.Reference) : true;

        float themeResistance = 0;
        
        if (jokeData.ThemeId < currentThemeResistances.Length)
        {
            themeResistance = currentThemeResistances[jokeData.ThemeId];
             
            currentThemeResistances[jokeData.ThemeId]--;
        }


        float acidityResistance = CurrentAcidityResistance > jokeData.Acidity ? 1 : (CurrentAcidityResistance < jokeData.Acidity ? -1 : 0); 
        
        CurrentAcidityResistance -= jokeData.Acidity;

        int resistanceSig = themeResistance < 0 && acidityResistance < 0 ? -1 : 1;



        CurrentJokeResponce = (float)jokeData.Funny * data.GeneralHumor * (knowReference ? 1 : 0) * themeResistance * acidityResistance * resistanceSig;


        CurrentHappiness += CurrentJokeResponce > 0 ? 1 : (CurrentJokeResponce < 0 ? -1 : 0);

    }

}