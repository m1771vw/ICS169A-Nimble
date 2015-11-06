using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class single_multi : MonoBehaviour
{
    public Canvas quitMenu;
    public Button PlaySingle;
    public Button exitText;
    public Button PlayMulti;

    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        exitText = exitText.GetComponent<Button>();
        PlaySingle = PlaySingle.GetComponent<Button>();
        PlayMulti = PlayMulti.GetComponent<Button>();
        quitMenu.enabled = false;
    }
    public void exitPress()
    {
        quitMenu.enabled = true;
        exitText.enabled = false;
        PlaySingle.enabled = false;
        PlayMulti.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        exitText.enabled = true;
        PlaySingle.enabled = true;
        PlayMulti.enabled = true;
    }
    public void SinglePress()
    {
        Application.LoadLevel("startscreen");
    }
    public void MultiPress()
    {
        Application.LoadLevel("startscreen");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
