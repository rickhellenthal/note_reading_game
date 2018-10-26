using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {
    private readonly List<Note> _noteList = new List<Note>();
    private bool _isWaiting;
    private Note _noteToPlay;
    private SpriteRenderer _noteToPlayImg;
    private Score _score;

    private bool _noteHasBeenPlayedWrong = false;

    void Start ()
    {
        string path = "Images/Notes/RightHand/";
        _noteList.Add(new Note("R01_C_Note", "C_Note", Resources.Load<Sprite>(path + "R01_C_Note")));
        _noteList.Add(new Note("R02_D_Note", "D_Note", Resources.Load<Sprite>(path + "R02_D_Note")));
        _noteList.Add(new Note("R03_E_Note", "E_Note", Resources.Load<Sprite>(path + "R03_E_Note")));
        _noteList.Add(new Note("R04_F_Note", "F_Note", Resources.Load<Sprite>(path + "R04_F_Note")));
        _noteList.Add(new Note("R05_G_Note", "G_Note", Resources.Load<Sprite>(path + "R05_G_Note")));
        _noteList.Add(new Note("R06_A_Note", "A_Note", Resources.Load<Sprite>(path + "R06_A_Note")));
        _noteList.Add(new Note("R07_B_Note", "B_Note", Resources.Load<Sprite>(path + "R07_B_Note")));
        _noteList.Add(new Note("R08_C1_Note", "C_Note", Resources.Load<Sprite>(path + "R08_C1_Note")));
        _noteList.Add(new Note("R09_D1_Note", "D_Note", Resources.Load<Sprite>(path + "R09_D1_Note")));
        _noteList.Add(new Note("R10_E1_Note", "E_Note", Resources.Load<Sprite>(path + "R10_E1_Note")));
        _noteList.Add(new Note("R11_F1_Note", "F_Note", Resources.Load<Sprite>(path + "R11_F1_Note")));
        _noteList.Add(new Note("R12_G1_Note", "G_Note", Resources.Load<Sprite>(path + "R12_G1_Note")));
        _noteList.Add(new Note("R13_A1_Note", "A_Note", Resources.Load<Sprite>(path + "R13_A1_Note")));
        
        _noteList.Add(new Note("R01_Cs_Note", "Cs_Note", Resources.Load<Sprite>(path + "R01_Cs_Note")));
        _noteList.Add(new Note("R02_Ds_Note", "Ds_Note", Resources.Load<Sprite>(path + "R02_Ds_Note")));
        _noteList.Add(new Note("R03_Es_Note", "F_Note", Resources.Load<Sprite>(path + "R03_Es_Note")));
        _noteList.Add(new Note("R04_Fs_Note", "Fs_Note", Resources.Load<Sprite>(path + "R04_Fs_Note")));
        _noteList.Add(new Note("R05_Gs_Note", "Gs_Note", Resources.Load<Sprite>(path + "R05_Gs_Note")));
        _noteList.Add(new Note("R06_As_Note", "As_Note", Resources.Load<Sprite>(path + "R06_As_Note")));
        _noteList.Add(new Note("R07_Bs_Note", "C_Note", Resources.Load<Sprite>(path + "R07_Bs_Note")));
        _noteList.Add(new Note("R08_C1s_Note", "Cs_Note", Resources.Load<Sprite>(path + "R08_C1s_Note")));
        _noteList.Add(new Note("R09_D1s_Note", "Ds_Note", Resources.Load<Sprite>(path + "R09_D1s_Note")));
        _noteList.Add(new Note("R10_E1s_Note", "F_Note", Resources.Load<Sprite>(path + "R10_E1s_Note")));
        _noteList.Add(new Note("R11_F1s_Note", "Fs_Note", Resources.Load<Sprite>(path + "R11_F1s_Note")));
        _noteList.Add(new Note("R12_G1s_Note", "Gs_Note", Resources.Load<Sprite>(path + "R12_G1s_Note")));
        _noteList.Add(new Note("R13_A1s_Note", "As_Note", Resources.Load<Sprite>(path + "R13_A1s_Note")));

        _noteToPlayImg = GameObject.FindGameObjectWithTag("NoteToPlay").GetComponent<SpriteRenderer>();
        _score = (Score)GameObject.Find("Score").gameObject.GetComponent(typeof(Score));
        NextNote();
    }

    public void NextNote()
    {
        Note randomNote = _noteList[Random.Range(0, _noteList.Count)];
        _noteToPlay = randomNote;
        _noteToPlayImg.sprite = _noteToPlay.Sprite;
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
            _score.UpdateScore(_noteHasBeenPlayedWrong);
            _noteHasBeenPlayedWrong = false;

        }
        else
        {
            noteItShouldBe.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            _noteHasBeenPlayedWrong = true;
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
    public Sprite Sprite { get; set; }

    public Note(string id, string name, Sprite sprite)
    {
        this.Id = id;
        this.Name = name;
        this.Sprite = sprite;
    }
}
