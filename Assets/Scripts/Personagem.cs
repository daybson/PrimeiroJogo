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

    public float VelocidadeRotacao;

    public float VelocidadeMovimento;

    void Update()
    {
        //Obtem o movimento horizontal do mouse
        var orientacaoY = Input.GetAxis("Mouse X");
        if (orientacaoY != 0)
        {
            //Calcula a quantidade de rotação/s gerada pelo movimento do mouse
            var rotacaoDelta = Quaternion.Euler(0, orientacaoY * this.VelocidadeRotacao * Time.deltaTime, 0);

            //Aplica a rotação ao rigidbody multiplicando a rotação atual pela delta, ou seja, combinando as duas
            this.rigidbody.MoveRotation(this.rigidbody.rotation * rotacaoDelta);
        }


        //Obtem entrada do usuário com teclado nos eixos vertical e horizontal
        var entradaEixosMovimento = new Vector3(Input.GetAxis("Horizontal"),
                                                0,
                                                Input.GetAxis("Vertical"));

        //Se usuário pressionou algum eixo
        if(entradaEixosMovimento != Vector3.zero)
        {
            //Converte a entrada do eixo de movimento do espaço global para espaço local do personagem
            entradaEixosMovimento = transform.TransformDirection(entradaEixosMovimento);

            //Escalona o eixo de input do usuário pela velocidade/s
            var movimentoDelta = entradaEixosMovimento * this.VelocidadeMovimento * Time.deltaTime;

            //Soma o deslocamento gerado com a posição atual, gerando a nova posição
            this.rigidbody.MovePosition(this.rigidbody.position + movimentoDelta);
        }

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
