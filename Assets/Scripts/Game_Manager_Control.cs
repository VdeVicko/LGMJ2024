using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Build;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class Game_Manager_Control : MonoBehaviour
{
    public float timer = 0;
    public GameData gameData;
    public int State;
    public Joke GenericJoke;

    public List<Joke> SelectableJokes;

    public List<Npc_Controller> NPCs;

    public void Start()
    {
        SetupNPCs();
    }

    public void FinishJoke()
    {
        timer++;
        State = 3;
        //GenericJoke.value = 0;
        Debug.Log("Joke finished.");
    }

    public void TellJoke()
    {
        Debug.Log("Telling joke");
        FinishJoke();
    }

    private void Update()
    {
        // Verificar cual fue precionado y mandar a procesar
        for (int i = 0; i < SelectableJokes.Count; i++)
        {
            if (SelectableJokes[i].OnPressed)
            {

                ProcessSelectedJokeButton(SelectableJokes[i]);
                
                // desactivar como seleccioando
                SelectableJokes[i].OnPressed = false;
            }
        }

    }



    void SetupNPCs()
    {
        gameData.GetNPCDataByLevel(0);

    }




    void ProcessSelectedJokeButton(Joke jokeButton)
    {
        Debug.Log("Broma elegida: " + jokeButton.JokeId.ToString());

        TellJoke();

        // Setear nuevos valores en botón
        JokeData newJoke = gameData.GetNewRandomJoke();

        Debug.Log("Nueva broma obtenida: " + newJoke.JokeId.ToString());

        // Mandar la nueva broma a los botones
        jokeButton.ChangeJokeid(newJoke.JokeId, newJoke.Text);

    }






}
