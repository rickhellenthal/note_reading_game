using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor;
using UnityEngine;


public class GameController : MonoBehaviour {
    private List<string> list = new List<string>();
    private GameObject text;
    private string noteToPlay;
    private bool isWaiting = false;

    // Use this for initialization
    void Start () {
		list.Add("C_Note");
        list.Add("Cs_Note");
	    list.Add("D_Note");
	    list.Add("Ds_Note");
	    list.Add("E_Note");
	    list.Add("F_Note");
	    list.Add("Fs_Note");
	    list.Add("G_Note");
	    list.Add("Gs_Note");
	    list.Add("A_Note");
	    list.Add("As_Note");
	    list.Add("B_Note");
        list.Add("C1_Note");

        text = GameObject.FindGameObjectWithTag("NoteToPlay");
        NextNote();
    }

    public void NextNote()
    {
        string randomNote = list[Random.Range(0, list.Count)];
        noteToPlay = randomNote;
        text.GetComponent<TextMeshPro>().text = randomNote;
    }

    public void Check(GameObject notePlayed)
    {
        GameObject noteItShouldBe = GameObject.Find(noteToPlay);
        bool nextNote = false;

        if (isWaiting) { return; }

        if (notePlayed.name.Equals(noteToPlay))
        {
            noteItShouldBe.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            nextNote = true;
        }
        else
        {
            noteItShouldBe.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }

        StartCoroutine(ReturnToOriginalColor(noteItShouldBe, nextNote));
    }

    IEnumerator ReturnToOriginalColor(GameObject noteItShouldBe, bool nextNote)
    {
        isWaiting = true;
        yield return new WaitForSeconds(1);
        Color originalColor = Color.white;
        if (noteItShouldBe.gameObject.name.Contains("s"))
        {
            originalColor = Color.black;
        }

        noteItShouldBe.GetComponent<Renderer>().material.SetColor("_Color", originalColor);
        if (nextNote)
        {
            NextNote();
        }

        isWaiting = false;
    }
}
