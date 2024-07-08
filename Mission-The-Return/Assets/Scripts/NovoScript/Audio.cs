 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public static Audio instance;
    public AudioMixer mixer;
    public Slider musicaVol;
    public Slider menuVol;
    public Slider efeitosVol;
    void Start()
    {
        instance = this;
    }

    public void MudarMusicaMusica()
    {
        mixer.SetFloat("musicaParam", musicaVol.value);
    }
    public void MudarMusicaMenu()
    {
        mixer.SetFloat("menuParam", menuVol.value);
    }
    public void MudarMusicaEfeitos()
    {
        mixer.SetFloat("efeitosParam", efeitosVol.value);
    }
}
