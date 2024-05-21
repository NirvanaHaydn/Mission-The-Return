using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float minRotationSpeed = 10f; // Velocidade mínima de rotação
    public float maxRotationSpeed = 50f; // Velocidade máxima de rotação
    private Vector3 rotationAxis; // Eixo de rotação
    private float rotationSpeed; // Velocidade de rotação atual
    
    // Start is called before the first frame update
    void Start()
    {
        // Define um eixo de rotação aleatório
        rotationAxis = Random.onUnitSphere;
        // Define uma velocidade de rotação aleatória dentro do intervalo especificado
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotaciona o objeto em torno do eixo definido a uma velocidade aleatória
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
