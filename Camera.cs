using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public GameObject bird;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(bird.gameObject.transform.position.x+3, -0.17f, -10f);

	}
}
