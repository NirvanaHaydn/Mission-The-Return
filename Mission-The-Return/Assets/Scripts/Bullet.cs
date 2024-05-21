using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30.0f;
    public float lifeTime = 2.0f;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<Item>();
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
