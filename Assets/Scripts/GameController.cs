using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameController : MonoBehaviour {
    private readonly List<Note> _noteList = new List<Note>();

    private Note _noteToPlay;
    [SerializeField] public SpriteRenderer NoteToPlayImg;
    [SerializeField] public Score Score;
    [SerializeField] public SceneController SceneController;
    [SerializeField] public TextMeshPro TimerText;
    
    private bool _noteHasBeenPlayedWrong;
    private bool _isWaiting;
    private float _timer = 60.0f;

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

        if (CrossSceneInfo.IncludeSharpNotes)
        {
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
        }

        if (CrossSceneInfo.IncludeFlatNotes)
        {
            _noteList.Add(new Note("R01_Cb_Note", "B_Note", Resources.Load<Sprite>(path + "R01_Cb_Note")));
            _noteList.Add(new Note("R02_Db_Note", "Cs_Note", Resources.Load<Sprite>(path + "R02_Db_Note")));
            _noteList.Add(new Note("R03_Eb_Note", "Ds_Note", Resources.Load<Sprite>(path + "R03_Eb_Note")));
            _noteList.Add(new Note("R04_Fb_Note", "E_Note", Resources.Load<Sprite>(path + "R04_Fb_Note")));
            _noteList.Add(new Note("R05_Gb_Note", "Fs_Note", Resources.Load<Sprite>(path + "R05_Gb_Note")));
            _noteList.Add(new Note("R06_Ab_Note", "Gs_Note", Resources.Load<Sprite>(path + "R06_Ab_Note")));
            _noteList.Add(new Note("R07_Bb_Note", "As_Note", Resources.Load<Sprite>(path + "R07_Bb_Note")));
            _noteList.Add(new Note("R08_C1b_Note", "B_Note", Resources.Load<Sprite>(path + "R08_C1b_Note")));
            _noteList.Add(new Note("R09_D1b_Note", "Cs_Note", Resources.Load<Sprite>(path + "R09_D1b_Note")));
            _noteList.Add(new Note("R10_E1b_Note", "Ds_Note", Resources.Load<Sprite>(path + "R10_E1b_Note")));
            _noteList.Add(new Note("R11_F1b_Note", "E_Note", Resources.Load<Sprite>(path + "R11_F1b_Note")));
            _noteList.Add(new Note("R12_G1b_Note", "Fs_Note", Resources.Load<Sprite>(path + "R12_G1b_Note")));
            _noteList.Add(new Note("R13_A1b_Note", "Gs_Note", Resources.Load<Sprite>(path + "R13_A1b_Note")));
        }

        NextNote();
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        TimerText.text = "Time left: " + Math.Round(_timer);
        if (_timer <= 0)
        {
            EndGame();
        }
    }

    public void NextNote()
    {
        Note randomNote = _noteList[Random.Range(0, _noteList.Count)];
        _noteToPlay = randomNote;
        NoteToPlayImg.sprite = _noteToPlay.Sprite;
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
            Score.UpdateScore(_noteHasBeenPlayedWrong);
            CrossSceneInfo.NumberOfAssignmentsCorrect += 1;
            _noteHasBeenPlayedWrong = false;

        }
        else
        {
            noteItShouldBe.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            CrossSceneInfo.NumberOfAssignmentsWrong += 1;
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

    public void EndGame()
    {
        CrossSceneInfo.ScoreAchieved = Score.GetScore();
        SceneController.LoadEndGame();
    }
}

public class Note
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Sprite Sprite { get; set; }

    public Note(string id, string name, Sprite sprite)
    {
        Id = id;
        Name = name;
        Sprite = sprite;
    }
}
