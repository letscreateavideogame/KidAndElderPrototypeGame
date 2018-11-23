using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 600;
    bool hasPlayer = false;
    bool beingCarried = false;
    bool ReleaseButton = true;
    //public AudioClip[] soundToPlay;
    //private AudioSource audio;
    public int dmg;
    private bool touched = false;

    void Start()
    {
       // audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 2.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        if (hasPlayer && Input.GetMouseButtonDown(0) && beingCarried == false)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
            ReleaseButton = false;
        }
        if (Input.GetMouseButtonUp(0) && beingCarried == true)
        {
            ReleaseButton = true;
        }
        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetMouseButtonDown(0) && ReleaseButton == true)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
                //RandomAudio();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }
    //void RandomAudio()
    //{
       // if (audio.isPlaying)
      //  {
        //    return;
       // }
       // audio.clip = soundToPlay[Random.Range(0, soundToPlay.Length)];
       // audio.Play();

   // }
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}