using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routine : MonoBehaviour
{
    public float timer;
    Animator animator;
    float duration;
    bool startjoke;
    public Game_Manager_Control MyGM;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startjoke)
        {
            timer++;
        }
        if (timer > duration)
        {
            animator.SetBool("tellingJoke", false);
            startjoke = false;
            timer = 0;
        }
    }

    public void TellJoke(JokeData jokedata)
    {
        startjoke = true;
        duration = jokedata.Duration;
        animator.SetBool("tellingJoke", true);
        StartCoroutine(JokeTime(duration));
        StopCoroutine(JokeTime(duration));
    }
    public IEnumerator JokeTime(float duration)
    {
        animator.SetBool("PunchLine", true);
        yield return new WaitForSeconds(duration);
        animator.SetBool("PunchLine", false);
        MyGM.ProcessTellJokeCompleted();
       
    }
}