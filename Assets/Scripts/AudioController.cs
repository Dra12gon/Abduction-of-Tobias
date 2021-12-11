using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public bool isMute = false;
    public Sprite Muted;
    public Sprite Unmute;
    public Button mutebutt;
    public AudioSource inside;
    public AudioSource outside;

    public void Mute()
    {
        if (isMute == false)
        {
            mutebutt.image.sprite = Muted;
            isMute = true;
            inside.volume = 0;
            outside.volume = 0;
        } else if (isMute == true)
        {
            mutebutt.image.sprite = Unmute;
            isMute = false;
            inside.volume = 1;
            outside.volume = 1;
        }
    }
}
