using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private static List<string> list = new List<string>();
    private static GameObject text;
    private static string noteToPlay;

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

    public static void NextNote()
    {
        string randomNote = list[Random.Range(0, list.Count)];
        noteToPlay = randomNote;
        text.GetComponent<TextMesh>().text = randomNote;
    }

    public static void Check(GameObject notePlayed)
    {
        if (notePlayed.name.Equals(noteToPlay))
        {
            print("lekker pik");
            NextNote();
        }
        else
        {
            print("uiterst matig");
        }
    }

}
