using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float lifeplayer = 20;
    public float speed = 6.0f;
    public Transform target;
    public GameObject shield;
    private float shieldDuration = 2.0f; 
    private float shieldEndTime = 0.0f;
    const float limitY = 4.0f;
    const float limitX = 8.0f;
    Blinking[] blink;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        blink = gameObject.GetComponentsInChildren<Blinking>();
        
    }
    private void Update()
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

        if (shield.activeSelf)
        {
            shieldEndTime = Time.time + shieldDuration;
        }

        
        if (shield.activeSelf && Time.time < shieldEndTime)
        {
            
            return;
        }

        

    }

    private void OnCollisionEnter(Collision other)
    {


        Blink();

        switch (other.gameObject.tag)
        {
            case "LifeOrb":
                Destroy(other.gameObject);
                shield.SetActive(true);
                GameControllerSingleton.instance.UpdateScore(15); 
                break;

            case "ShieldOrb":
                Destroy(other.gameObject);
                shield.SetActive(true);
                lifeplayer++;
                break;

            case "EstrelaCarente":
                lifeplayer--;
                Destroy(other.gameObject);
                shield.SetActive(false);
                if(lifeplayer <= 0)
                {
                    HUDNovo.instance.ShowGameOver();
                }
                

                break;
                
        }

    
   
           /*Blink();

        if (other.gameObject.CompareTag("LifeOrb"))
        {
            Destroy(other.gameObject);
            shield.SetActive(true);
        }
        if (other.gameObject.CompareTag("ShieldOrb"))
        {
            Destroy(other.gameObject);
            shield.SetActive(true);
        }
        if (other.gameObject.CompareTag("EstrelaCarente"))
        {
            Destroy(other.gameObject);
            shield.SetActive(false);
            HUDSingleton.instance.LoseLife();
        }*/





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
