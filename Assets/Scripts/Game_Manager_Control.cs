using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Build;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class Game_Manager_Control : MonoBehaviour
{
    public float timer=0;
    public GameData gameData; 
    public int State;
    public Joke GenericJoke;
    class DoubleLinkedList<T>
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

        public void InsertAtEnd(T joke)
        {
            nodo newNodo = new nodo(joke);
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
 
    public void Start()
    {
        DoubleLinkedList<Joke> mylist = new DoubleLinkedList<Joke>();
    }

    public void TellJoke()
    {
        Debug.Log("Telling joke");
        FinishJoke();
    }
    
    public void FinishJoke()
    {
        timer++;
        State = 3;
        GenericJoke.value = 0;
        Debug.Log("Joke finished.");
    }

    private void Update()
    {
        if (GenericJoke.value > 0)
        {
            TellJoke();
        }
    }
}
