using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Door : MonoBehaviour
{
    public int index;
    public AK.Wwise.Event doorSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
                {
            doorSound.Post(gameObject);
            SceneManager.LoadScene(index);
        }
    }

    public void MainMenuEnd() 
    {
        SceneManager.LoadScene(0);
    }
}
