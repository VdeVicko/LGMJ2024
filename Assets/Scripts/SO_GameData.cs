using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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


}
