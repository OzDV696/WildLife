using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public void EndGame()
    {
        Debug.Log("GameOver");
        Invoke("Restart", 2f);
        //Restart();
    }

    public void Finished()
    {
        Debug.Log("Haz Ganado!");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
