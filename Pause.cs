using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void Pausa()
    {
        Time.timeScale = 0f;
        if(Input.GetKeyDown(KeyCode.Space)) // si pulsamos el espacio volvemos a continuar
        {
            Time.timeScale = 1f; // lo volvemos a poner a 1
        }
    }
}
