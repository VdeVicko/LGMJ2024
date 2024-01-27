using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routine : MonoBehaviour
{
    Animator animator;
    bool tellingJoke;
    float duration;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TellJoke(JokeData jokedata)
    {
        //duration = jokedata.duration;
        tellingJoke = true;
    }
}
