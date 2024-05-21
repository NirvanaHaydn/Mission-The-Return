using UnityEngine;


public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 6.0f;
    public Transform target;
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
        if((transform.position.y < -limitY) && v < 0) v = 0;
        if((transform.position.y > limitY) && v > 0) v = 0;

        float h = Input.GetAxis("Horizontal");
        if(transform.position.x < (target.position.x - limitX))
        {
            h = 0.5f;
        }

        Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other)
    {
        Blink();
    }
    void Blink()
    {
        foreach(Blinking b in blink)
        {
            b.Hit();
        }
    }

    

}
