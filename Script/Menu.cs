using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject main_panel, help_panel;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadNewScene()
    {
        SceneManager.LoadScene("Room");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Help()
    {
        Debug.Log("Help");
        main_panel.SetActive(false);
        help_panel.SetActive(true);
    }

    public void Back()
    {
        Debug.Log("Back");
        main_panel.SetActive(true);
        help_panel.SetActive(false);
    }

}
