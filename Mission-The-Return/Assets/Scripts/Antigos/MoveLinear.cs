using UnityEngine;

public class MoveLinear : MonoBehaviour
{
    public float speed = 3.0f;
    public Vector3 dir;
    
    
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
