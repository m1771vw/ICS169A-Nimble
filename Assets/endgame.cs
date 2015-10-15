using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class endgame : MonoBehaviour
{
    public Canvas quitMenu;
    public Button PlayAgainText;
    public Button exitText;
    public Text gameOver;
    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        exitText = exitText.GetComponent<Button>();
        PlayAgainText = PlayAgainText.GetComponent<Button>();
        //gameOver.enabled = true;
        quitMenu.enabled = false;
    }
    public void exitPress()
    {
        quitMenu.enabled = true;
        gameOver.enabled = false;
        exitText.enabled = false;
        PlayAgainText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        exitText.enabled = true;
        PlayAgainText.enabled = true;
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
