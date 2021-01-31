using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicTrigger : MonoBehaviour
{
    public AK.Wwise.Event playMusic;
    public AK.Wwise.Switch musicSwitch;
    public AK.Wwise.State musicState;
    public GameObject character;

    public UnityEvent unityEvent = new UnityEvent();

    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        unityEvent.Invoke();
    }

    public void PlayMusic()
    {
        playMusic.Post(character);
    }

    public void SetSwitch()
    {
        musicSwitch.SetValue(character);
    }

    public void SetState()
    {
        musicState.SetValue();
    }

}
