using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

   
public class Chiste : MonoBehaviour
{
    public int value = 0;
    Vector3 posInitial;
    private SpriteRenderer sprite ;
    public float duration;
    float bitingHumor;
    float inteligence ;
    float happines;
    string theme;
    

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        posInitial = transform.position;
    }

    public void Interaction()
    {
        Destroy(gameObject);
         value = 1;
    }
}
