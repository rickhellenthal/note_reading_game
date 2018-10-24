using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {
    private readonly List<Note> _noteList = new List<Note>();
    private bool _isWaiting;
    private Note _noteToPlay;
    private SpriteRenderer _noteToPlayImg;

    void Start () {
        _noteList.Add(new Note("R01_C_Note", "C_Note", Resources.Load<Sprite>("Images/Notes/R01_C_Note")));
        _noteList.Add(new Note("R02_D_Note", "D_Note", Resources.Load<Sprite>("Images/Notes/R02_D_Note")));
        _noteList.Add(new Note("R03_E_Note", "E_Note", Resources.Load<Sprite>("Images/Notes/R03_E_Note")));
        _noteList.Add(new Note("R04_F_Note", "F_Note", Resources.Load<Sprite>("Images/Notes/R04_F_Note")));
        _noteList.Add(new Note("R05_G_Note", "G_Note", Resources.Load<Sprite>("Images/Notes/R05_G_Note")));
        _noteList.Add(new Note("R06_A_Note", "A_Note", Resources.Load<Sprite>("Images/Notes/R06_A_Note")));
        _noteList.Add(new Note("R07_B_Note", "B_Note", Resources.Load<Sprite>("Images/Notes/R07_B_Note")));
        _noteList.Add(new Note("R08_C1_Note", "C_Note", Resources.Load<Sprite>("Images/Notes/R08_C1_Note")));
        _noteList.Add(new Note("R09_D1_Note", "D_Note", Resources.Load<Sprite>("Images/Notes/R09_D1_Note")));
        _noteList.Add(new Note("R10_E1_Note", "E_Note", Resources.Load<Sprite>("Images/Notes/R10_E1_Note")));
        _noteList.Add(new Note("R11_F1_Note", "F_Note", Resources.Load<Sprite>("Images/Notes/R11_F1_Note")));
        _noteList.Add(new Note("R12_G1_Note", "G_Note", Resources.Load<Sprite>("Images/Notes/R12_G1_Note")));
        _noteList.Add(new Note("R13_A1_Note", "A_Note", Resources.Load<Sprite>("Images/Notes/R13_A1_Note")));

        _noteToPlayImg = GameObject.FindGameObjectWithTag("NoteToPlay").GetComponent<SpriteRenderer>();
        NextNote();
    }

    public void NextNote()
    {
        Note randomNote = _noteList[Random.Range(0, _noteList.Count)];
        _noteToPlay = randomNote;
        _noteToPlayImg.sprite = _noteToPlay.Image;
    }

    public void Check(GameObject notePlayed)
    {
        GameObject noteItShouldBe = GameObject.Find(_noteToPlay.Name);
        bool nextNote = false;

        if (_isWaiting) { return; }

        if (notePlayed.name.Equals(_noteToPlay.Name))
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
        _isWaiting = true;
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

        _isWaiting = false;
    }
}

public class Note
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Sprite Image { get; set; }

    public Note(string id, string name, Sprite image)
    {
        this.Id = id;
        this.Name = name;
        this.Image = image;
    }
}
