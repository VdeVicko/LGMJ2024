using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{

    [Header("OPCIONES")]
    public Slider volumeFX;
    public Slider volumeMaster;
   //MUTE
    public Toggle mute;
    // VOL....
    public AudioMixer mixer;
    //FX VOL..
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVolume;

    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject levelSelectPanel;

    // audio
    private void Awake()
    {
        volumeFX.onValueChanged.AddListener(ChangeVolumeFX);
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
    }
        // nivel
    public void PlayLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
      // quit
    public void ExitGame()
    {
        Debug.Log("saliendo");
        Application.Quit();
    }

    public void SetMute()
    {
        if (mute.isOn)
        {
            mixer.GetFloat("VolMaster", out lastVolume);
            mixer.SetFloat("VolMaster", -80);
        }
        else
            mixer.SetFloat("VolMaster", lastVolume);
    }


    public void OpenPanel(GameObject panel)
    {

        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);

        panel.SetActive(true);
        PlaySoundButton();
    }
    public void ChangeVolumeMaster(float v)
    {
        mixer.SetFloat("VolMaster", v);
    }
    public void ChangeVolumeFX(float v)
    {
        mixer.SetFloat("VolFX", v);
    }
    
    public void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }
}  
    


