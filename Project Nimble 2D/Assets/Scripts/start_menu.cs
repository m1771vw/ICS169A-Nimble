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
        Application.LoadLevel("single-multi");
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        exitText.enabled = true;
        Play.enabled = true;
    }
    public void LoadScene()
    {
        Application.LoadLevel("Nimble 2D");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OpenHighScore()
    {
        Application.LoadLevel("highscore");
    }
}
