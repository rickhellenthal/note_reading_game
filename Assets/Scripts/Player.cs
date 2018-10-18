using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _speed = 7;
    private GameController gameController;

	// Use this for initialization
	void Start ()
	{
	    gameController = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    this.transform.position += 
	        new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * this._speed * Time.deltaTime;
	}

    void OnTriggerEnter(Collider other)
    {
        this.CheckForInput(other);
    }

    void OnTriggerStay(Collider other)
    {
        this.CheckForInput(other);
    }

    void CheckForInput(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            PlayNote note = (PlayNote)other.gameObject.GetComponent(typeof(PlayNote));
            note.Play();
            gameController.Check(other.gameObject);
        }
    }
}
