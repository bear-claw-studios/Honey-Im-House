using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public Canvas quitMenu;

    // Start is called before the first frame update
    void Start()
    {
        quitMenu.enabled = false;
    }

    public void Return()
    {
        quitMenu.enabled = false;
    }

    public void QuitSelected()
    {
        Debug.Log("Quit Pressed");
        quitMenu.enabled = true;
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        Return();
    }
}
