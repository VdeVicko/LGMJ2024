using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Build;
using TMPro;
using Cinemachine;
using Unity.UI;
using UnityEngine.UI;

public class Game_Manager_Control : MonoBehaviour
{
    const float AVERAGE_RESPONCE_MULTIPLIER = 2.5f;
    public float timer = 0;
    public GameData gameData;
    public int State;
    public Image Image;

    //References
    public Routine ComedianRoutine;
    public TMP_Text JokeResponceText;
    
    public List<Joke> JokeButtons;
    public List<Npc_Controller> NPCs;
    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;

    public Slider JokemeterSlider;

    private float jokemeter;
    JokeData currentJokeData;

    public void Start()
    {
        TrantitionInit(cam1, cam2);
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

        //Obtener valores de broma y Setear nuevos valores en bot�n
        currentJokeData = jokeButton.GetJokeData();
        JokeData newJoke = gameData.GetNewRandomJoke();
        jokeButton.SetJokeData(newJoke);
        jokeButton.moving = true;
        Debug.Log("Nueva broma obtenida: " + newJoke.JokeId.ToString());

        // Ejecutar animacion de contar broma
        ComedianRoutine.TellJoke(currentJokeData);
    }

    public void ProcessTellJokeCompleted()
    {
        Debug.Log("ProcessTellJokeCompleted " + currentJokeData.JokeId.ToString());


        float totalResponce = 0;

        // Procesar broma por el publico
        foreach (var npc in NPCs)
        {
            npc.ProcessJoke(currentJokeData);
            npc.React();

            totalResponce += npc.CurrentJokeResponce;
        }

        float averageResponce = totalResponce * AVERAGE_RESPONCE_MULTIPLIER / NPCs.Count;

        Debug.Log("Respuesta general actual=" + totalResponce.ToString() + " promedio=" + averageResponce.ToString());

        jokemeter += averageResponce;

        //Actualizar chistometro
        JokemeterSlider.value = jokemeter; //JokeResponceText.text = jokemeter.ToString() + "/ 100";
        Debug.Log("Respuesta general total: " + jokemeter.ToString());

   }

    public void TrantitionInit(CinemachineVirtualCamera a, CinemachineVirtualCamera b)
    {
        b.Priority = a.Priority + 1;
    }
}