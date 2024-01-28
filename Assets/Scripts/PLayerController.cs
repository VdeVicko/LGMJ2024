using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PLayerController : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("MENU");
    }
}