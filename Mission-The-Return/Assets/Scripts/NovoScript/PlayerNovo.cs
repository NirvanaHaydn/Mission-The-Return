using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class PlayerNovo : MonoBehaviour
{
    public static PlayerNovo player;  
    Rigidbody rb;
    public float speed = 6.0f;
    const float limitY = 4.0f;
    const float limitX = 8.0f;
    public float energy = 20.0f;
    public float life = 50.0f;
    public Image lifePlayer;
    public Transform target;
    public GameObject shield;
    Blinking[] blink;

    private void Start()
    {
        player = this;
        rb = GetComponent<Rigidbody>();
        blink = gameObject.GetComponentsInChildren<Blinking>();
        shield.gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision other)
    {
        Blink();

        switch (other.gameObject.tag)
        {
            case "LifeOrb":
                Destroy(other.gameObject);
                MoreLife();
                //HUDNova.instance.AddLife();
                break;

            case "ShieldOrb":
                
                Destroy(other.gameObject);
                Energy();
                
                break;

            case "Asteroid":
                
                Destroy(other.gameObject);
                LoseEnergy();
                /*if (shield == false)
                {
                    LoseLife();
                    GameController.instance.SetDamage(2);
                }
                if(life <= 0)
                {
                    HUDNova.instance.ShowGameOver();
                }*/
                break;

        }
        if (other.gameObject.CompareTag("LifeOrb"))
        {
            Destroy(other.gameObject);
            MoreLife();
            
        }
        /*if (other.gameObject.CompareTag("Asteroid"))
        {
            Destroy (other.gameObject);
            LoseEnergy();
            life--;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {

        }
        if (other.gameObject.CompareTag("ShieldOrb"))
        {

        }*/

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
              
    }
    public void LoseEnergy()
    {
        shield.SetActive(false);
        /*energy--;
        if(energy <= 0)
        {
            life--;
        }*/
        HUDNova.instance.LoseLife();
    }
    public void LoseLife()
    {
        if (shield == false)
        {
            /*life = life--;
            lifePlayer.fillAmount = life;
            if(life <= 0)
            {*/
                HUDNova.instance.ShowGameOver();
            //}
        }
    }
    public void MoreLife()
    {
        /*shield.SetActive(true);
        life = life++;
        lifePlayer.fillAmount = life;
        if (life >= 20.0f)
        {*/
            HUDNova.instance.AddLife();
        //}

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
