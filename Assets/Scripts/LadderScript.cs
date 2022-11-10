using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{

	[SerializeField] Transform controller;
	[SerializeField] float speed = 3.2f;
	[SerializeField] PlayerMovement playerMovement;
	bool onLadder = false;
	

    // Start is called before the first frame update
    void Start()
    {
		onLadder = false;
    }

	private void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			onLadder=true;
			playerMovement.enabled=false;
			Debug.Log("On ladder!");
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			onLadder=false;
			Debug.Log("Off ladder!");
			playerMovement.enabled = true;
		}
	}

	// Update is called once per frame
	void Update()
    {
        if(onLadder && Input.GetKey(KeyCode.W))
		{
			controller.transform.position += Vector3.up / speed;
			Debug.Log("Going UP ladder!");
		}
		else if(!onLadder && Input.GetKey(KeyCode.S))
		{
			controller.transform.position += Vector3.down / speed;
			Debug.Log("Going DOWN ladder!");
		}
    }
}
