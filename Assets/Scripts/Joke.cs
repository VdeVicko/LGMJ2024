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



public class Joke : MonoBehaviour
{
    public bool OnPressed = false;
    private Vector3 velocity = Vector3.zero;
    private RectTransform MyRT;
    public int value = 0;
   
    float duration;
    float bitingHumor;
    float inteligence ;
    float happines;
    string theme;
    Image image;

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
    }
    public void Update()
    {
        if(OnPressed )
        {
            MyRT.anchoredPosition3D = Vector3.SmoothDamp(MyRT.anchoredPosition3D, MyRT.anchoredPosition3D - new Vector3(130, 0, 0), ref velocity, 0.1f);

            
        }

        if(MyRT.anchoredPosition3D.x < -304f)
        {
            Destroy(gameObject);
        }

    }
    public void Interaction()
    {
        value = 1;
        OnPressed = true;
    }
}