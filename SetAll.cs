using UnityEngine;
using System.Collections;

public class SetAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
            {
                BroadcastMessage("CorrectColors");
            }
        if (Input.GetButtonDown("Fire2"))
            {
                BroadcastMessage("Start");
            }
	}
}
