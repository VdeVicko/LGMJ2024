using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

public class Npc_Controller : MonoBehaviour
{
    public Rigidbody rb;
    public Game_Manager_Control GM;
    private SpriteRenderer sprite;

    public float Happiness;
    public int ResistanceCount = 4;
    float Humor;
    float ResistBitingHumor;

    public string[] References;
    public int[] Resistance;
    // Enfermedad, Religion,C,D

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Resistance = new int[ResistanceCount];
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

    }
}