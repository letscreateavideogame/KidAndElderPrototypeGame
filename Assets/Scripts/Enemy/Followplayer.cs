using UnityEngine;

public class Followplayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

	// Use this for initialization

	// Update is called once per frame
	void Update () {
        transform.position = player.position + offset;
	}
}
