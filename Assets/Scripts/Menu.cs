using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartB()
    {
        SceneManager.LoadScene("0");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
