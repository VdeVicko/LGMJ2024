using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Build;
using UnityEngine.Assertions.Must;

public class Game_Manager_Control : MonoBehaviour
{
    public float timer=0;
   
    public int State;
    public Chiste GenericJoke;
    class DiubleLinkedList<T>
    {
        private class nodo
        {
            public nodo next;
            public nodo previus;
            public T Value;
            public nodo(T t)
            {
                next = null;
                previus = null;
                Value = t;
            }

        }
        nodo Head = null;
        int lenght = 0;

        public void InsertAtEnd(T chiste)
        {
            nodo newNodo = new nodo(chiste);
            if(Head == null)
            {
                Head = newNodo;
                lenght++;
            }
            else
            {
                nodo tmp = Head;
                for(int i = 0; i < lenght; i++)
                {
                    if(tmp.next != null)
                    {
                        tmp = tmp.next;
                    }
                }
                tmp.next = newNodo;
                newNodo.previus = tmp;
                lenght++;
            }
        }
    }

    DiubleLinkedList<Chiste> mylist = new DiubleLinkedList<Chiste>();
    
    /*public IEnumerator TellJokerRoutinen(float duration)
    {
        yield return new WaitForSeconds(0);
        while(true)
        {
            Debug.Log("Alonso");
            yield return new WaitForSeconds(duration);
        }
    }*/
    public void Start()
    {
        //StartCoroutine(TellJokerRoutinen(2));
    }
    public void TellJoke()
    {
            FinishJoke();
    }
    
    public void FinishJoke()
    {
        timer++;
        State = 3;
        GenericJoke.value = 0;
    }

    private void Update()
    {
        if (GenericJoke.value > 0)
        {
            TellJoke();
        }
    }
}
