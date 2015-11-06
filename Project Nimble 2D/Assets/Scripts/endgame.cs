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
        //exitText = exitText.GetComponent<Button>();
        PlayAgainText = PlayAgainText.GetComponent<Button>();
        //gameOver.enabled = true;
        quitMenu.enabled = false;
    }
    public void exitPress()
    {
        Application.LoadLevel("single-multi");
    }


    public void LoadScene()
    {
        Application.LoadLevel("Nimble 2D");
    }

}
