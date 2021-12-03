using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{

    public void CambiarScena(string nombre)
    {
        print("cambiando a la escena" + nombre);
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        print("Salir del juego");
        Application.Quit();

    }
}