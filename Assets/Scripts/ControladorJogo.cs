using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJogo : MonoBehaviour
{
    public Inimigo Inimigo;
    public Personagem Personagem;

    void Update()
    {
        if (this.Inimigo.PontosDeVida <= 0)
        {
            SceneManager.LoadScene("Vitoria");
        }

        if (this.Personagem.PontosDeVida <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }
    }
}
