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



public class Joke : MonoBehaviour
{
    public int JokeId;
    public int id;
    public bool OnPressed = false;
    private Vector3 velocity = Vector3.zero;
    private RectTransform MyRT;
    public int value = 0;
    private TMP_Text text;
   
    float duration;
    float bitingHumor;
    float inteligence ;
    float happines;
    string theme;

    public Joke(float _Duration, float _BitingHumor, float _Inteligence, float _Happines, string _Theme)
    {
        this.duration = _Duration;
        this.bitingHumor = _BitingHumor;
        this.inteligence = _Inteligence;
        this.happines = _Happines;
        this.theme = _Theme;
    }

    public void Start()
    {
        MyRT = GetComponent<RectTransform>();
        text = GetComponentInChildren<TMP_Text>();
    }
    public void Update()
    {
        if(OnPressed )
        {
            MyRT.anchoredPosition3D = Vector3.SmoothDamp(MyRT.anchoredPosition3D, MyRT.anchoredPosition3D - new Vector3(-130, 0, 0), ref velocity, 0.1f);
        }

        if(MyRT.anchoredPosition3D.x < -304f)
        {
          
        }

    }
    public void Interaction()
    {
        value = 1;
        OnPressed = true;
    }

    public void ChangeJokeid(int jokeid)
    {
        id = jokeid;
        UpdateJoke();
    }

    void UpdateJoke()
    {
       ;
    }
}