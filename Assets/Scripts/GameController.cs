using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {
    private List<Note> noteList = new List<Note>();
    private bool isWaiting;
    private Note noteToPlay;
    private SpriteRenderer noteToPlayImg;

    void Start () {
        noteList.Add(new Note("R01_C_Note", "C_Note", Resources.Load<Sprite>("Images/Notes/R01_C_Note")));
        noteList.Add(new Note("R02_D_Note", "D_Note", Resources.Load<Sprite>("Images/Notes/R02_D_Note")));
        noteList.Add(new Note("R03_E_Note", "E_Note", Resources.Load<Sprite>("Images/Notes/R03_E_Note")));
        noteList.Add(new Note("R04_F_Note", "F_Note", Resources.Load<Sprite>("Images/Notes/R04_F_Note")));
        noteList.Add(new Note("R05_G_Note", "G_Note", Resources.Load<Sprite>("Images/Notes/R05_G_Note")));
        noteList.Add(new Note("R06_A_Note", "A_Note", Resources.Load<Sprite>("Images/Notes/R06_A_Note")));
        noteList.Add(new Note("R07_B_Note", "B_Note", Resources.Load<Sprite>("Images/Notes/R07_B_Note")));
        noteList.Add(new Note("R08_C1_Note", "C_Note", Resources.Load<Sprite>("Images/Notes/R08_C1_Note")));
        noteList.Add(new Note("R09_D1_Note", "D_Note", Resources.Load<Sprite>("Images/Notes/R09_D1_Note")));
        noteList.Add(new Note("R10_E1_Note", "E_Note", Resources.Load<Sprite>("Images/Notes/R10_E1_Note")));
        noteList.Add(new Note("R11_F1_Note", "F_Note", Resources.Load<Sprite>("Images/Notes/R11_F1_Note")));
        noteList.Add(new Note("R12_G1_Note", "G_Note", Resources.Load<Sprite>("Images/Notes/R12_G1_Note")));
        noteList.Add(new Note("R13_A1_Note", "A_Note", Resources.Load<Sprite>("Images/Notes/R13_A1_Note")));

        noteToPlayImg = GameObject.FindGameObjectWithTag("NoteToPlay").GetComponent<SpriteRenderer>();
        NextNote();
    }

    public void NextNote()
    {
        Note randomNote = noteList[Random.Range(0, noteList.Count)];
        noteToPlay = randomNote;
        noteToPlayImg.sprite = noteToPlay.image;
    }

    public void Check(GameObject notePlayed)
    {
        GameObject noteItShouldBe = GameObject.Find(noteToPlay.name);
        bool nextNote = false;

        if (isWaiting) { return; }

        if (notePlayed.name.Equals(noteToPlay.name))
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

public class Note
{
    public string id { get; set; }
    public string name { get; set; }
    public Sprite image { get; set; }

    public Note(string id, string name, Sprite image)
    {
        this.id = id;
        this.name = name;
        this.image = image;
    }
}
