using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public KeyCode key;
    public GameObject obj;
    public AudioSource sound;
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Instantiate(obj, transform.position, transform.rotation);
            sound.Play();
        }
    }
}
