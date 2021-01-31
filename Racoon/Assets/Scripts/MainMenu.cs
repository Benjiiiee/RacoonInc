using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public AK.Wwise.Event uiBack;
    public AK.Wwise.Event uiHover;
    public AK.Wwise.Event uiSelect;
    public AK.Wwise.Event playMusic;
    public AK.Wwise.Switch switchMenu;
    public AK.Wwise.Event stopMusic;

    public void Start()
    {
        playMusic.Post(gameObject);
        switchMenu.SetValue(gameObject);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayUISelect()
    {
        uiSelect.Post(gameObject);
    }
    public void PlayUIHover()
    {
        uiHover.Post(gameObject);
    }
    public void PlayUIBack()
    {
        uiBack.Post(gameObject);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StopMusic()
    {
        stopMusic.Post(gameObject);
    }

}
