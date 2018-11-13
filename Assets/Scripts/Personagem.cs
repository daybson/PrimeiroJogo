using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public Transform transformMira;
    public Rigidbody rigidbody;
    public float VelocidadePulo;
    public int pulosMaximos;
    public int pulosContador;


    private void Start()
    {
        this.rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Realiza o pulo
        if (this.pulosContador < this.pulosMaximos && 
            Input.GetKeyDown(KeyCode.Space))
        {
            this.pulosContador++;
            this.rigidbody.AddForce(Vector3.up * this.VelocidadePulo, ForceMode.Impulse);
        }

        //Dispara Projétil
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projetil = (GameObject)Instantiate(Resources.Load("Prefabs/Projetil"));
            projetil.transform.position = this.transformMira.position;
            projetil.transform.forward = this.transformMira.forward;
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("plataforma"))
        {
            this.pulosContador = 0;
        }
    }
}
