using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct JokeData 
{
    public int JokeId;

    public string Text;

    public JokeData(int jokeId, string text)
    {
        JokeId = jokeId;
        Text = text;
    }

}
