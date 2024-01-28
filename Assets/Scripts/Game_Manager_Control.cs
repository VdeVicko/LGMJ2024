using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Build;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;
using TMPro;

public class Game_Manager_Control : MonoBehaviour
{
    public float timer = 0;
    public GameData gameData;
    public int State;

    //References
    public Routine ComedianRoutine;
    public TMP_Text JokeResponceText;
    public List<Joke> JokeButtons;
    public List<Npc_Controller> NPCs;

    private float jokemeter;
    JokeData currentJokeData;

    public void Start()
    {
        Invoke("Initialize", 0.1f);
    }

    void Initialize()
    {
        SetupNPCs();

        SetupJokeButtons();

        ComedianRoutine.MyGM = this;
    }

    public void FinishJoke()
    {
        timer++;
        State = 3;
        //GenericJoke.value = 0;
    }

    public void TellJoke()
    {
        FinishJoke();
    }

    private void Update()
    {
        //if (!started) { Initialize(); started = true;}

        // Verificar cual fue precionado y mandar a procesar
        for (int i = 0; i < JokeButtons.Count; i++)
        {
            if (JokeButtons[i].OnPressed)
            {

                ProcessSelectedJokeButton(JokeButtons[i]);

                // desactivar como seleccioando
                JokeButtons[i].OnPressed = false;
            }
        }
    }

    void SetupNPCs()
    {
        NPCData[] npcData = gameData.GetNPCDataByLevel(0);

        int len = Math.Min(npcData.Length, NPCs.Count);
        
        for (int i = 0; i < len; i++)
        {
            if (NPCs[i]) 
                NPCs[i].SetData(npcData[i]);
        }
    }

    void SetupJokeButtons()
    {
        foreach (Joke jokeButton in JokeButtons)
        {
            JokeData newJoke = gameData.GetNewRandomJoke();

            jokeButton.SetJokeData(newJoke);
        }
    }

    void ProcessSelectedJokeButton(Joke jokeButton)
    {
        Debug.Log("Broma elegida: " + jokeButton.GetJokeData().JokeId.ToString());

        //Obtener valores de broma y Setear nuevos valores en botón
        currentJokeData = jokeButton.GetJokeData();
        JokeData newJoke = gameData.GetNewRandomJoke();
        jokeButton.SetJokeData(newJoke);
        Debug.Log("Nueva broma obtenida: " + newJoke.JokeId.ToString());

        // Ejecutar animacion de contar broma
        ComedianRoutine.TellJoke(currentJokeData);


    }

    public void ProcessTellJokeCompleted()
    {
        float totalResponce = 0;

        // Procesar broma por el publico
        foreach (var npc in NPCs)
        {
            npc.ProcessJoke(currentJokeData);

            totalResponce += npc.CurrentJokeResponce;
        }

        Debug.Log("Respuesta general actual: " + totalResponce.ToString());

        jokemeter += totalResponce;

        JokeResponceText.text = jokemeter.ToString() + "/" + "100";
        Debug.Log("Respuesta general total: " + jokemeter.ToString());
    }


}