using System.Linq.Expressions;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public float speed = 30.0f;
    //public float lifeTime = 2.0f;
    private void Start()
    {
        
        //Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
   
            HUDNova.instance.AddScore();
        }
        if (other.gameObject.CompareTag("ShieldOrb"))
        {
            PlayerNovo.player.Energy();
        }
        if (other.gameObject.CompareTag("LifeOrb"))
        {
            PlayerNovo.player.MoreLife();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            HUDNova.instance.AddScore();
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            HUDNova.instance.AddMore();
        }
        //other.gameObject.GetComponent<Enemyy>();

    }

    void Update()
    {
        //transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
