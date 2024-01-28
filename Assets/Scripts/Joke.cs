using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TreeEditor;
using TMPro;
using UnityEditor.Callbacks;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Unity.VisualScripting;
using System;

public class Joke : MonoBehaviour
{
    GameData gameData;

    int i = 0;
    bool moving;
    public int id;

    public bool OnPressed = false;
    private Vector3 velocity = Vector3.zero;
    private RectTransform MyRT;
    public int value = 0;

    private TMP_Text text;
    public GameObject ButtonPoint;

    private JokeData data;

    //public int JokeId;
    //float duration;
    //float bitingHumor;
    //float inteligence;
    //float happines;
    //string theme;
    
    public Joke(float _Duration, float _BitingHumor, float _Inteligence, float _Happines, string _Theme)
    {
        //this.duration = _Duration;
        //this.bitingHumor = _BitingHumor;
        //this.inteligence = _Inteligence;
        //this.happines = _Happines;
        //this.theme = _Theme;
    }

    public void Start()
    {

        MyRT = GetComponent<RectTransform>();
        text = GetComponentInChildren<TMP_Text>();
    }

    public void Update()
    {
       /* if (OnPressed)
        { 
            
            MyRT.anchoredPosition3D = Vector3.SmoothDamp(MyRT.anchoredPosition3D, MyRT.anchoredPosition3D - new Vector3(-130, 0, 0), ref velocity, 0.1f);
           
        }

        if (MyRT.anchoredPosition3D.x > 304f)
        {
            Invoke("UpdateJoke", 2f);
        } */
    }
    public void Interaction()
    {
        value = 1;
        OnPressed = true;
    }

    public void SetJokeData(JokeData newData)
    {
        data = newData;
        //id = newjokeid;
        text.text = data.Text.Substring(0, 60);
    }

    public JokeData GetJokeData()
    {
        return data;
    }

    void UpdateJoke()
    {
        //  MyRT.position = Vector3.SmoothDamp(MyRT.anchoredPosition3D, ButtonPoint., ref velocity, 0.1f); ;
        switch (id)
        {
            case 0:
                MyRT.position = new Vector3(-96.59f, 175.5356f,0);
                break;
            case 1:
                MyRT.position = new Vector3(-97.37094f, 67.18599f,0);
                break;
            case 2:
                MyRT.position = new Vector3(-96.59201f, -48.88022f,0);
                break;
            case 3:
                MyRT.position = new Vector3(-95.81305f, -155.5988f,0);
                break;
        }
    }

     public void SetupCanvas()
    {
        MyRT = GetComponent<RectTransform>();
        text = GetComponentInChildren<TMP_Text>();
    }
}