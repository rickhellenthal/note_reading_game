using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private readonly int _speed = 7;
    private GameController _gameController;

	// Use this for initialization
	void Start ()
	{
	    _gameController = GameObject.Find("GameController").GetComponent<GameController>();
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

    /*
     * Together with the OnCollisionStay function, this causes the player object to NOT rotate in 3D.
     * The rotation can cause the collider to be out of place an thus the won't collide with the notes.
    */
    void OnCollisionEnter(Collision col)
    {
        this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0);
        this.GetComponent<Rigidbody>().drag = 100000;
    }
    void OnCollisionStay(Collision col)
    {
        this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0);
    }

    void CheckForInput(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (other.gameObject.CompareTag("Note"))
            {
                PlayNote note = (PlayNote)other.gameObject.GetComponent(typeof(PlayNote));
                note.Play();
                _gameController.Check(other.gameObject);
            }
        }
    }
}
