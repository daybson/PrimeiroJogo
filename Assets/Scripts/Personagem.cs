using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public Transform transformMira;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projetil = (GameObject)Instantiate(Resources.Load("Prefabs/Projetil"));
            projetil.transform.position = this.transformMira.position;
            projetil.transform.forward = this.transformMira.forward;
        }
    }
}
