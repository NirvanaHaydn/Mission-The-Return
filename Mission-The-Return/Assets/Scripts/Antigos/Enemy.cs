using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyState state;
    public Waypoints target;
    public float speed;
    void Start()
    {
        //estado inicial
    }
    void FixedUpdate()
    {
        state?.Process();
    }
}
