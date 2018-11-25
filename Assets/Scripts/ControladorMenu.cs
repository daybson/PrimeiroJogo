using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{

    public void Jogar()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
