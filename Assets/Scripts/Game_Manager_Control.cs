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
    const float DEFAUlT_SHOW_DURATION = 20;
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
    public Animator ComedianShowResultAnimatior;
    public TMP_Text JokeText;
    public RawImage JokeImage;
    public GameObject GamePlayUI;
    public GameObject ResultUI;

    public TMP_Text ResultShow;
    public TMP_Text ResultHaters;
    public TMP_Text ResultLovers;



    private float jokemeter;
    JokeData currentJokeData;
    private float showTime;


    private float showResult = 0;
    private float hatters = 0;
    private float lovers = 0;



    public void Start()
    {
        GamePlayUI.SetActive(false);
        ResultUI.SetActive(false);


        TrantitionInit(cam1, cam2);

        Invoke("Initialize", 0.1f);
    }

    void Initialize()
    {
        SetupNPCs();

        ComedianRoutine.MyGM = this;

        showTime = DEFAUlT_SHOW_DURATION;

        StartCoroutine(WaitIntroAnimation());
    }

    public IEnumerator WaitIntroAnimation()
    {
        yield return new WaitForSeconds(3f);
        ComedianShowResultAnimatior.SetFloat("showResult", 0);

        GamePlayUI.SetActive(true);


        StartCoroutine(WaitUILoad());
    }

    public IEnumerator WaitUILoad()
    {
        yield return new WaitForSeconds(.1f);

        SetupJokeButtons();
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
        jokeButton.moving = true;
        Debug.Log("Nueva broma obtenida: " + newJoke.JokeId.ToString());

        // Ejecutar animacion de contar .
        JokeText.text = currentJokeData.Text;
        JokeText.enabled = true;
        JokeImage.enabled = true;
        ComedianRoutine.TellJoke(currentJokeData);
    }

    public void ProcessTellJokeCompleted()
    {
        Debug.Log("ProcessTellJokeCompleted " + currentJokeData.JokeId.ToString());

        JokeText.enabled = false;
        JokeImage.enabled = false;

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

        // Reducir tiempo
        showTime -= currentJokeData.Duration;
        Debug.Log(showTime);
        // Evaluar si terminóel show
        if (showTime <= 0.1f || jokemeter <= -100)
        {
            FinishShow();
        }
    }

    void FinishShow()
    {
        Debug.Log("FinishShow");

        if (jokemeter < 0)
        {
            showResult = -1;
        }
        else if (jokemeter > 50)
        {
            showResult = 2;
        }
        else
        {
            showResult = 1;
        }

        if (ComedianShowResultAnimatior)
            ComedianShowResultAnimatior.SetFloat("showResult", showResult);

        foreach(var npc  in NPCs)
        {
            if (npc.CurrentHappiness < 0) hatters++;
            if (npc.CurrentHappiness > 0) lovers++;
        }

        StartCoroutine(WaitResultAnimation());
    }



    public IEnumerator WaitResultAnimation()
    {
        yield return new WaitForSeconds(3f);
        ComedianShowResultAnimatior.SetFloat("showResult", 0);

        GamePlayUI.SetActive(false);

        TrantitionInit(cam2, cam1);
    }





    public void TrantitionInit(CinemachineVirtualCamera a, CinemachineVirtualCamera b)
    {
        b.Priority = a.Priority + 1;
    }
}