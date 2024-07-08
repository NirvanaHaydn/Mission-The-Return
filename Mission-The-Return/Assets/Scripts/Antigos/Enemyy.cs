using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyy : MonoBehaviour
{
    public int life = 2;
    Blinking[] blink;
    void Start()
    {
        blink = gameObject.gameObject.GetComponentsInChildren<Blinking>();
    }

    public void OnCollisionEnter(Collision other)
    {

        /*switch (other.gameObject.tag)
        {
            case "Player":
                Destroy(this.gameObject);
                HUDNova.instance.LoseLife();
                break;

            case "BulletPlayer":

                Destroy(other.gameObject);
                life--;
                Blink();
                if (life <= 0)
                {
                    HUDNova.instance.AddScore();
                    Destroy(gameObject);
                }
                break;
                

            
        }*/    

       if (other.gameObject.CompareTag("BulletPlayer"))
       {
            Destroy(other.gameObject);
            life--;
            Blink();
            if(life <= 0)
            {
                HUDNova.instance.AddScore();
                Destroy(gameObject);
            }
       }
       
    }
    void Blink()
    {
        foreach(Blinking b in blink)
        {
            b.Hit();

        }
    }
    public void Point()
    {
        life--;
        if(life <= 0)
        {
            HUDNova.instance.AddScore();
        }
    }
    
}
