using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController acInstance;

    public AudioSource audioSource;
    public AudioClip RotateClip;
    public AudioClip DownClip;
    public AudioClip EarnClip;
    // Start is called before the first frame update
    void Awake()
    {
        if (acInstance == null)
            acInstance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRotateSound()
    {
        //audioSource.PlayOneShot(RotateClip);
        AudioSource.PlayClipAtPoint(RotateClip, this.transform.position);
    }

    public void PlayDownSound()
    {
        audioSource.PlayOneShot(DownClip);
    }

    public void PlayEarnSound()
    {
        audioSource.PlayOneShot(EarnClip);
    }

}
