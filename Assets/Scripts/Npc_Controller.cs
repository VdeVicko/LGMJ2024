using JetBrains.Annotations;
using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Animator animator;

    private NPCData data;
    public float CurrentJokeResponce = 0;
    private float CurrentHappiness = 0;
    private float CurrentAcidityResistance = 0;
    private int[] currentThemeResistances;
    public float currentState;


    //float Humor;
    //float ResistBitingHumor;

    //public string[] References;
    //public int[] Resistance;
    // Enfermedad, Religion,C,D





    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        //Resistance = new int[ResistanceCount];
    }
    private void Update()
    {
       
            
        
    }

    public IEnumerator Animations()
    {
        yield return new WaitForSeconds(3f);
        animator.SetFloat("Reaction", 0f);
        StopCoroutine(Animations());
    }
    public void React()
    {
        StartCoroutine(Animations());
        currentState = CurrentJokeResponce;
        animator.SetFloat("Reaction", currentState);
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
        Debug.Log("ProcessJoke joke=" + jokeData.JokeId.ToString() + " participant=" + data.Id);

        List<string> references = new List<string>(data.KnowReferences);

        bool unknowReference = jokeData.Reference.Length == 0 ? false : references.Contains(jokeData.Reference);

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
        Debug.Log(" - " + jokeData.Funny.ToString() + "*" + data.GeneralHumor.ToString() + "*(" + (unknowReference ? "0" : "1") + ")*" + themeResistance.ToString() + "*" + acidityResistance.ToString() + "*" + resistanceSig.ToString());

        CurrentHappiness += CurrentJokeResponce > 0 ? 1 : (CurrentJokeResponce < 0 ? -1 : 0);

        Debug.Log(" - participant responce=" + CurrentJokeResponce.ToString() + " happines=" + CurrentHappiness.ToString());

    }
}