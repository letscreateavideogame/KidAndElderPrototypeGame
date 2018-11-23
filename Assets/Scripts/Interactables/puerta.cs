using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour {
    [SerializeField] private GameObject enterPanel;

    public GameObject Player;
    public string escena;
    public GameObject getPlayer()
    {
        return Player;
    }

    public string getEscena()
    {
        return escena;
    }
	// Use this for initialization
	void Start () {
        enterPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(this.transform.position, Player.transform.position);
        //Debug.Log(dist);
        if (dist < 5f)
        {
            enterPanel.SetActive(true);
        } else {
            enterPanel.SetActive(false);
        }
	    if(Input.GetButtonDown("Jump") && dist < 5f)
        {
            Debug.Log("Espace pressed");
            Player.GetComponent<Player>().Entrar(this);
        }
    }
}
