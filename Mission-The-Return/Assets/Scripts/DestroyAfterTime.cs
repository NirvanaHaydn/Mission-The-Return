using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    
    public float lifeTime;
    private void Start()
    {

        Destroy(gameObject, lifeTime);
    }
}
