﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public GameObject Personagem;
    public float VelocidadeMovimento;
    public int PontosDeVida;

    void Start()
    {
        this.Personagem = GameObject.FindGameObjectWithTag("Player");
        this.PontosDeVida = 3;
    }


    void Update()
    {
        Vector3 posicaoNoPlano = new Vector3(this.Personagem.transform.position.x, 
            transform.position.y, 
            this.Personagem.transform.position.z);
        transform.LookAt(posicaoNoPlano);

        transform.Translate(this.transform.forward * this.VelocidadeMovimento * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Projetil"))
        {
            this.PontosDeVida -= 1;
        }
    }
}
