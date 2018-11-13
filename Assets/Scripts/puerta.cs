using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta1 : MonoBehaviour {

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
    }
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(this.transform.position, jugador.transform.position);
	    if(Input.GetKeyDown("space") && dist < 2.0)
        {
            print("Espace pressed");
            jugador.GetComponent<Player>().Entrar(this);
        }
    }
}
