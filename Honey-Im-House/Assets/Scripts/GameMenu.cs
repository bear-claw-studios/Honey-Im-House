using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public Canvas quitMenu, optionsMenu, settingsMenu;

    public RectTransform optionsMenuTransform;
    public float menuSizePercentage = 0.5f; //Should not exceed 1

    public TrackBallTouch theHouse;

    // Start is called before the first frame update
    void Start()
    {
        quitMenu.enabled = false;
        optionsMenu.enabled = false;
        settingsMenu.enabled = false;
        theHouse = FindObjectOfType<TrackBallTouch>();
    }

    public void Return()
    {
        quitMenu.enabled = false;
        theHouse.ExitedMenu();
    }

    public void QuitSelected()
    {
        Debug.Log("Quit Pressed");
        quitMenu.enabled = true;
        theHouse.MenuSelected();
    }

    public void OptionsSelected()
    {
        optionsMenu.enabled = true;
        theHouse.MenuSelected();
    }

    public void SettingsSelected()
    {
        settingsMenu.enabled = true;
        theHouse.MenuSelected();
    }

    public void ExitSettings()
    {
        settingsMenu.enabled = false;
        theHouse.ExitedMenu();
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
