using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float Velocidade;

    void Update()
    {
        transform.Translate(transform.forward * this.Velocidade * Time.deltaTime, Space.World);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
