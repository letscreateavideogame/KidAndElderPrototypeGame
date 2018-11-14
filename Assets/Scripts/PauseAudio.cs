using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : MonoBehaviour {
    AudioSource m_MyAudioSource;
    [SerializeField] private GameObject pausePanel;
    // Use this for initialization
    void Start () {
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("p"))
        {
            if (!pausePanel.activeInHierarchy)
            {

                m_MyAudioSource.Pause();
            }
            else
            {

                m_MyAudioSource.Play();
            }
        }
    }
}
