using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class PlayerNovo : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 6.0f;
    const float limitY = 4.0f;
    const float limitX = 8.0f;
    public float energy = 10.0f;
    public float life = 15.0f;
    public Transform target;
    public GameObject shield;
    Blinking[] blink;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        blink = gameObject.GetComponentsInChildren<Blinking>();
        shield.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision other)
    {
        Blink();

        switch (other.gameObject.tag)
        {
            case "LifeOrb":
                Destroy(other.gameObject);
                MoreLife();
                GameControllerSingleton.instance.UpdateScore(15);
                break;

            case "ShieldOrb":
                
                Destroy(other.gameObject);
                Energy();
                break;

            case "Asteroid":
                
                Destroy(other.gameObject);
                LoseEnergy();
                if (shield == false)
                {
                    LoseLife();
                }
                if(life <= 0)
                {
                    HUDNova.instance.ShowGameOver();
                }
                break;

        }

    }
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        if ((transform.position.y < -limitY) && v < 0) v = 0;
        if ((transform.position.y > limitY) && v > 0) v = 0;

        float h = Input.GetAxis("Horizontal");
        if (transform.position.x < (target.position.x - limitX))
        {
            h = 0.5f;
        }

        Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * speed * Time.deltaTime;
    }
    
    public void Energy()
    {
       
       
            shield.SetActive(true);
            energy++;
        
       
       
        
    }
    public void LoseEnergy()
    {
        shield.SetActive(false);
        energy--;

    }
    public void LoseLife()
    {
        if (shield == false)
        {
            life--;
        }
    }
    public void MoreLife()
    {
        shield.SetActive(true);
        life++;
    }
    void Blink()
    {
        foreach (Blinking b in blink)
        {
            b.Hit();
            shield.SetActive(false);
        }
    }
}
