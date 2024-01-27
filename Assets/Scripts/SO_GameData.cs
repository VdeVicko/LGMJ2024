using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


struct JokeData
{
    public int JokeId;

    public string Text;

    public JokeData(int jokeId, string text)
    {
        JokeId = jokeId;
        Text = text;
    }
   
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public Joke CurrentJoke = null;
    public float Score = 0;
    public float HappinessTotal = 0;
    public float IrritationTotal = 0;
    public float SuccessTotal = 0;
    public float indictment = 0;
    public float Popularity = 0;


    public JokeData GetNewRandomJoke()
    {
        int rnd = Random.Range(0, jokes.Length);

        return jokes[rnd];
    }

    JokeData[] jokes = new JokeData[] {
        new(1, "Broma 1" ),
        new(2, "Broma 2" )
    };



}
