using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly int _speed = 7;
    [SerializeField] public GameController GameController;

    /*
     * This checks for user input on the horizontal and vertical axis, so if the arrow keys or WASD is pressed.
     * Based on this, the player object moves.
     */
    void Update ()
	{
	    transform.position += 
	        new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * _speed * Time.deltaTime;
	}

    /*
     * The piano keys collision boxes are triggers, whenever the player enters or stays in this collider the game checks
     * for input.
     */
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
     * The rotation can cause the collider to be out of place an thus the player won't collide with the notes.
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

    /*
     * Checks for player input (Enter key, or de space bar). If the player is currently colliding with a note,
     * the note is played and the Check() function from the GameController is called.
     *
     * If the user is currently colliding with the Quit_Note, the game stops.
     */
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
