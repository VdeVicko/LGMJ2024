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
    bool moving;
    GameData gameData;
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
        if (OnPressed || moving)
        {
            MyRT.anchoredPosition3D = Vector3.SmoothDamp(MyRT.anchoredPosition3D, MyRT.anchoredPosition3D - new Vector3(-130, 0, 0), ref velocity, 0.1f);
            moving = true;
        }

        if (MyRT.anchoredPosition3D.x > 304f)
        {
            UpdateJoke();
            moving = false;

        }

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
        text.text = data.Text;



    }

    public JokeData GetJokeData()
    {
        return data;
    }

    void UpdateJoke()
    {
        //  MyRT.position = Vector3.SmoothDamp(MyRT.anchoredPosition3D, ButtonPoint., ref velocity, 0.1f); ;

    }
}

