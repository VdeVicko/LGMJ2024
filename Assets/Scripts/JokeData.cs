using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct JokeData 
{
    public int JokeId;

    public string Title;
    public string Text;

    public float Duration;
    public float Funny;
    public float Acidity;
    public string Theme;
    public string Reference;



    public JokeData(
        int jokeId, 
        string title,
        string text,
        float duration,
        float funny,
        float acidity,
        string theme,
        string reference 
        )
    {
        JokeId = jokeId;

        Title = title;
        Text = text;

        Duration = duration;
        Funny = funny;
        Acidity = acidity;
        Theme = theme;
        Reference = reference;
    }

}
