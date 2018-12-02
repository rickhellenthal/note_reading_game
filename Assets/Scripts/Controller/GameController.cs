using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using TMPro;
using UnityEngine;
using View;
using Random = UnityEngine.Random;


namespace Controller
{
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

        /*
	 * Based on the settings the user can change in the Main Menu, specific types of notes are loaded and added to
     * a list. Then the function NextNote() is called.
	 */
        void Start ()
        {
            LoadNotes();
            NextNote();
        }

        /*
	 * This causes the timer to count down, when it reaches zero, the function EndGame() is called.
	 */
        void Update()
        {
            _timer -= Time.deltaTime;
            TimerText.text = "Time left: " + Math.Round(_timer);
            if (_timer <= 0)
            {
                EndGame();
            }
        }

        /*
	 * This retrieves a random note from the list of notes, sets it as the note to play, and
     * displays the assignment to the user. 
	 */
        public void NextNote()
        {
            Note randomNote = _noteList[Random.Range(0, _noteList.Count)];
            _noteToPlay = randomNote;
            NoteToPlayImg.sprite = _noteToPlay.Sprite;
        }

        /*
     * This is called from the Player script. Here the note the player played is validated.
     * If a note is lit up (green or red) and thus _isWaiting, the function ends.
     */
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
                if (!_noteHasBeenPlayedWrong) CrossSceneInfo.NumberOfAssignmentsCorrect += 1;
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

        /*
     * This makes the game wait one second before doing anything.
     * After the wait the lit up note is set back to its original color.
     * Based on the nextNote parameter, the NextNote() function is called or not.
     */
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

        /*
     * This function is called when the game is supposed to end.
     * It sets the score in the CrossSceneInfo and loads the EndGame scene.
     */
        public void EndGame()
        {
            CrossSceneInfo.ScoreAchieved = Score.GetScore();
            SceneController.LoadEndGame();
        }
        
        public void LoadNotes() {
            const string leftPath = "Images/Notes/LeftHand/";
            const string rightPath = "Images/Notes/RightHand/";
            
            if (CrossSceneInfo.ClefSetting == 0 || CrossSceneInfo.ClefSetting == 2)
            {
                _noteList.Add(new Note("R01_C_Note", "C_Note", Resources.Load<Sprite>(rightPath + "R01_C_Note")));
                _noteList.Add(new Note("R02_D_Note", "D_Note", Resources.Load<Sprite>(rightPath + "R02_D_Note")));
                _noteList.Add(new Note("R03_E_Note", "E_Note", Resources.Load<Sprite>(rightPath + "R03_E_Note")));
                _noteList.Add(new Note("R04_F_Note", "F_Note", Resources.Load<Sprite>(rightPath + "R04_F_Note")));
                _noteList.Add(new Note("R05_G_Note", "G_Note", Resources.Load<Sprite>(rightPath + "R05_G_Note")));
                _noteList.Add(new Note("R06_A_Note", "A_Note", Resources.Load<Sprite>(rightPath + "R06_A_Note")));
                _noteList.Add(new Note("R07_B_Note", "B_Note", Resources.Load<Sprite>(rightPath + "R07_B_Note")));
                _noteList.Add(new Note("R08_C1_Note", "C_Note", Resources.Load<Sprite>(rightPath + "R08_C1_Note")));
                _noteList.Add(new Note("R09_D1_Note", "D_Note", Resources.Load<Sprite>(rightPath + "R09_D1_Note")));
                _noteList.Add(new Note("R10_E1_Note", "E_Note", Resources.Load<Sprite>(rightPath + "R10_E1_Note")));
                _noteList.Add(new Note("R11_F1_Note", "F_Note", Resources.Load<Sprite>(rightPath + "R11_F1_Note")));
                _noteList.Add(new Note("R12_G1_Note", "G_Note", Resources.Load<Sprite>(rightPath + "R12_G1_Note")));
                _noteList.Add(new Note("R13_A1_Note", "A_Note", Resources.Load<Sprite>(rightPath + "R13_A1_Note")));
    
                if (CrossSceneInfo.IncludeSharpNotes)
                {
                    _noteList.Add(new Note("R01_Cs_Note", "Cs_Note", Resources.Load<Sprite>(rightPath + "R01_Cs_Note")));
                    _noteList.Add(new Note("R02_Ds_Note", "Ds_Note", Resources.Load<Sprite>(rightPath + "R02_Ds_Note")));
                    _noteList.Add(new Note("R03_Es_Note", "F_Note", Resources.Load<Sprite>(rightPath + "R03_Es_Note")));
                    _noteList.Add(new Note("R04_Fs_Note", "Fs_Note", Resources.Load<Sprite>(rightPath + "R04_Fs_Note")));
                    _noteList.Add(new Note("R05_Gs_Note", "Gs_Note", Resources.Load<Sprite>(rightPath + "R05_Gs_Note")));
                    _noteList.Add(new Note("R06_As_Note", "As_Note", Resources.Load<Sprite>(rightPath + "R06_As_Note")));
                    _noteList.Add(new Note("R07_Bs_Note", "C_Note", Resources.Load<Sprite>(rightPath + "R07_Bs_Note")));
                    _noteList.Add(new Note("R08_C1s_Note", "Cs_Note", Resources.Load<Sprite>(rightPath + "R08_C1s_Note")));
                    _noteList.Add(new Note("R09_D1s_Note", "Ds_Note", Resources.Load<Sprite>(rightPath + "R09_D1s_Note")));
                    _noteList.Add(new Note("R10_E1s_Note", "F_Note", Resources.Load<Sprite>(rightPath + "R10_E1s_Note")));
                    _noteList.Add(new Note("R11_F1s_Note", "Fs_Note", Resources.Load<Sprite>(rightPath + "R11_F1s_Note")));
                    _noteList.Add(new Note("R12_G1s_Note", "Gs_Note", Resources.Load<Sprite>(rightPath + "R12_G1s_Note")));
                    _noteList.Add(new Note("R13_A1s_Note", "As_Note", Resources.Load<Sprite>(rightPath + "R13_A1s_Note")));
                }
    
                if (CrossSceneInfo.IncludeFlatNotes)
                {
                    _noteList.Add(new Note("R01_Cb_Note", "B_Note", Resources.Load<Sprite>(rightPath + "R01_Cb_Note")));
                    _noteList.Add(new Note("R02_Db_Note", "Cs_Note", Resources.Load<Sprite>(rightPath + "R02_Db_Note")));
                    _noteList.Add(new Note("R03_Eb_Note", "Ds_Note", Resources.Load<Sprite>(rightPath + "R03_Eb_Note")));
                    _noteList.Add(new Note("R04_Fb_Note", "E_Note", Resources.Load<Sprite>(rightPath + "R04_Fb_Note")));
                    _noteList.Add(new Note("R05_Gb_Note", "Fs_Note", Resources.Load<Sprite>(rightPath + "R05_Gb_Note")));
                    _noteList.Add(new Note("R06_Ab_Note", "Gs_Note", Resources.Load<Sprite>(rightPath + "R06_Ab_Note")));
                    _noteList.Add(new Note("R07_Bb_Note", "As_Note", Resources.Load<Sprite>(rightPath + "R07_Bb_Note")));
                    _noteList.Add(new Note("R08_C1b_Note", "B_Note", Resources.Load<Sprite>(rightPath + "R08_C1b_Note")));
                    _noteList.Add(new Note("R09_D1b_Note", "Cs_Note", Resources.Load<Sprite>(rightPath + "R09_D1b_Note")));
                    _noteList.Add(new Note("R10_E1b_Note", "Ds_Note", Resources.Load<Sprite>(rightPath + "R10_E1b_Note")));
                    _noteList.Add(new Note("R11_F1b_Note", "E_Note", Resources.Load<Sprite>(rightPath + "R11_F1b_Note")));
                    _noteList.Add(new Note("R12_G1b_Note", "Fs_Note", Resources.Load<Sprite>(rightPath + "R12_G1b_Note")));
                    _noteList.Add(new Note("R13_A1b_Note", "Gs_Note", Resources.Load<Sprite>(rightPath + "R13_A1b_Note")));
                }
            }

            if (CrossSceneInfo.ClefSetting == 1 || CrossSceneInfo.ClefSetting == 2)
            {
                _noteList.Add(new Note("L01_E_Note", "E_Note", Resources.Load<Sprite>(leftPath + "L01_E_Note")));
                _noteList.Add(new Note("L02_F_Note", "F_Note", Resources.Load<Sprite>(leftPath + "L02_F_Note")));
                _noteList.Add(new Note("L03_G_Note", "G_Note", Resources.Load<Sprite>(leftPath + "L03_G_Note")));
                _noteList.Add(new Note("L04_A_Note", "A_Note", Resources.Load<Sprite>(leftPath + "L04_A_Note")));
                _noteList.Add(new Note("L05_B_Note", "B_Note", Resources.Load<Sprite>(leftPath + "L05_B_Note")));
                _noteList.Add(new Note("L06_C_Note", "C_Note", Resources.Load<Sprite>(leftPath + "L06_C_Note")));
                _noteList.Add(new Note("L07_D_Note", "D_Note", Resources.Load<Sprite>(leftPath + "L07_D_Note")));
                _noteList.Add(new Note("L08_E1_Note", "E_Note", Resources.Load<Sprite>(leftPath + "L08_E1_Note")));
                _noteList.Add(new Note("L09_F1_Note", "F_Note", Resources.Load<Sprite>(leftPath + "L09_F1_Note")));
                _noteList.Add(new Note("L10_G1_Note", "G_Note", Resources.Load<Sprite>(leftPath + "L10_G1_Note")));
                _noteList.Add(new Note("L11_A1_Note", "A_Note", Resources.Load<Sprite>(leftPath + "L11_A1_Note")));
                _noteList.Add(new Note("L12_B1_Note", "B_Note", Resources.Load<Sprite>(leftPath + "L12_B1_Note")));
                _noteList.Add(new Note("L13_C1_Note", "C_Note", Resources.Load<Sprite>(leftPath + "L13_C1_Note")));

                if (CrossSceneInfo.IncludeSharpNotes)
                {
                    _noteList.Add(new Note("L01_Es_Note", "F_Note", Resources.Load<Sprite>(leftPath + "L01_Es_Note")));
                    _noteList.Add(new Note("L02_Fs_Note", "Fs_Note", Resources.Load<Sprite>(leftPath + "L02_Fs_Note")));
                    _noteList.Add(new Note("L03_Gs_Note", "Gs_Note", Resources.Load<Sprite>(leftPath + "L03_Gs_Note")));
                    _noteList.Add(new Note("L04_As_Note", "As_Note", Resources.Load<Sprite>(leftPath + "L04_As_Note")));
                    _noteList.Add(new Note("L05_Bs_Note", "C_Note", Resources.Load<Sprite>(leftPath + "L05_Bs_Note")));
                    _noteList.Add(new Note("L06_Cs_Note", "Cs_Note", Resources.Load<Sprite>(leftPath + "L06_Cs_Note")));
                    _noteList.Add(new Note("L07_Ds_Note", "Ds_Note", Resources.Load<Sprite>(leftPath + "L07_Ds_Note")));
                    _noteList.Add(new Note("L08_E1s_Note", "F_Note",
                        Resources.Load<Sprite>(leftPath + "L08_E1s_Note")));
                    _noteList.Add(
                        new Note("L09_F1s_Note", "Fs_Note", Resources.Load<Sprite>(leftPath + "L09_F1s_Note")));
                    _noteList.Add(
                        new Note("L10_G1s_Note", "Gs_Note", Resources.Load<Sprite>(leftPath + "L10_G1s_Note")));
                    _noteList.Add(
                        new Note("L11_A1s_Note", "As_Note", Resources.Load<Sprite>(leftPath + "L11_A1s_Note")));
                    _noteList.Add(new Note("L12_B1s_Note", "C_Note",
                        Resources.Load<Sprite>(leftPath + "L12_B1s_Note")));
                    _noteList.Add(
                        new Note("L13_C1s_Note", "Cs_Note", Resources.Load<Sprite>(leftPath + "L13_C1s_Note")));
                }

                if (CrossSceneInfo.IncludeFlatNotes)
                {
                    _noteList.Add(new Note("L01_Eb_Note", "Ds_Note", Resources.Load<Sprite>(leftPath + "L01_Eb_Note")));
                    _noteList.Add(new Note("L02_Fb_Note", "E_Note", Resources.Load<Sprite>(leftPath + "L02_Fb_Note")));
                    _noteList.Add(new Note("L03_Gb_Note", "Fs_Note", Resources.Load<Sprite>(leftPath + "L03_Gb_Note")));
                    _noteList.Add(new Note("L04_Ab_Note", "Gs_Note", Resources.Load<Sprite>(leftPath + "L04_Ab_Note")));
                    _noteList.Add(new Note("L05_Bb_Note", "As_Note", Resources.Load<Sprite>(leftPath + "L05_Bb_Note")));
                    _noteList.Add(new Note("L06_Cb_Note", "B_Note", Resources.Load<Sprite>(leftPath + "L06_Cb_Note")));
                    _noteList.Add(new Note("L07_Db_Note", "Cs_Note", Resources.Load<Sprite>(leftPath + "L07_Db_Note")));
                    _noteList.Add(
                        new Note("L08_E1b_Note", "Ds_Note", Resources.Load<Sprite>(leftPath + "L08_E1b_Note")));
                    _noteList.Add(new Note("L09_F1b_Note", "E_Note",
                        Resources.Load<Sprite>(leftPath + "L09_F1b_Note")));
                    _noteList.Add(
                        new Note("L10_G1b_Note", "Fs_Note", Resources.Load<Sprite>(leftPath + "L10_G1b_Note")));
                    _noteList.Add(
                        new Note("L11_A1b_Note", "Gs_Note", Resources.Load<Sprite>(leftPath + "L11_A1b_Note")));
                    _noteList.Add(
                        new Note("L12_B1b_Note", "As_Note", Resources.Load<Sprite>(leftPath + "L12_B1b_Note")));
                    _noteList.Add(new Note("L13_C1b_Note", "B_Note",
                        Resources.Load<Sprite>(leftPath + "L13_C1b_Note")));
                }
            }
        }
    }
}

