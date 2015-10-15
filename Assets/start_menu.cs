using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class start_menu : MonoBehaviour
{
    public Canvas quitMenu;
    public Button Play;
    public Button exitText;

    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        exitText = exitText.GetComponent<Button>();
        Play = Play.GetComponent<Button>();
        quitMenu.enabled = false;
    }
    public void exitPress()
    {
        quitMenu.enabled = true;
        exitText.enabled = false;
        Play.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        exitText.enabled = true;
        Play.enabled = true;
    }
    public void LoadScene()
    {
        Application.LoadLevel("Scene1");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
