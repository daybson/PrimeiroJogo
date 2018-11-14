using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public Transform transformMira;
    public Rigidbody rigidbody;
    public float ForcaPulo;
    public int PulosMaximos;
    public int PuloContador;

    void Update()
    {
        //Realiza o pulo
        if (this.PuloContador < this.PulosMaximos && Input.GetKeyDown(KeyCode.Space))
        {
            this.rigidbody.AddForce(Vector3.up * this.ForcaPulo, ForceMode.Impulse);
            this.PuloContador++;
        }

        //Dispara Projétil
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projetil = (GameObject)Instantiate(Resources.Load("Prefabs/Projetil"));
            projetil.transform.position = this.transformMira.position;
            projetil.transform.forward = this.transformMira.forward;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Piso"))
            this.PuloContador = 0;
    }
}
