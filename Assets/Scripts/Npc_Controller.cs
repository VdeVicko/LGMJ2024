using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

public class Npc_Controller : MonoBehaviour
{
   
    public Game_Manager_Control GM;
    private SpriteRenderer sprite;
    public int ResistanceCount = 4;
    float Humor;
    float ResistBitingHumor;
    public string[] References;
    public int[] Resistance;
    // Enfermedad, Religion,C,D

    void Start()
    {
        Resistance = new int[ResistanceCount];
    }
    private void Update()
    {
        if(GM.State == 3)
        {
            Reaction();
        }
    }

    void Reaction()
    {
        Debug.Log("Pipo React :O");
    }
}
     
   

