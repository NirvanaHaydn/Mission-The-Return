using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;
    public bool enabledOnPlay = false;
    public float delay;
    public AudioSource sound;

    void Start()
    {
        if (enabledOnPlay)
        {
            StartSpawner(delay);
        }
        sound = GetComponent<AudioSource>();
    }
    public void StartSpawner(float s)
    {
        InvokeRepeating("Spawn", 0, s);
    }
    void Spawn()
    {
        Instantiate(obj, transform.position, transform.rotation);
        if(sound != null) sound.Play();
    }
}
