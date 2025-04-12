using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void IniciarJogo()
    {
        GameController.Init();
        SceneManager.LoadScene(1);
    }
}
