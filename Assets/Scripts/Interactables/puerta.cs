using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour {
    [SerializeField] private GameObject enterPanel;

    public GameObject jugador;
    public string escena;
    public GameObject getJugador()
    {
        return jugador;
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
        float dist = Vector3.Distance(this.transform.position, jugador.transform.position);
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
            jugador.GetComponent<Player>().Entrar(this);
        }
    }
}
