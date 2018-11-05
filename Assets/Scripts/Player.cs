using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private readonly int _speed = 7;
    [SerializeField] public GameController GameController;
	
	void Update ()
	{
	    transform.position += 
	        new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * _speed * Time.deltaTime;
	}

    void OnTriggerEnter(Collider other)
    {
        CheckForInput(other);
    }

    void OnTriggerStay(Collider other)
    {
        CheckForInput(other);
    }

    /*
     * Together with the OnCollisionStay function, this causes the player object to NOT rotate in 3D.
     * The rotation can cause the collider to be out of place an thus the won't collide with the notes.
    */
    void OnCollisionEnter(Collision col)
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0);
        GetComponent<Rigidbody>().drag = 100000;
    }
    void OnCollisionStay(Collision col)
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0);
    }

    void CheckForInput(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (other.gameObject.CompareTag("Note"))
            {
                PlayNote note = (PlayNote)other.gameObject.GetComponent(typeof(PlayNote));
                note.Play();
                GameController.Check(other.gameObject);
            }

            if (other.gameObject.CompareTag("UI") && other.gameObject.name.Equals("Quit_Note"))
            {
                GameController.EndGame();
            }
        }
    }
}
