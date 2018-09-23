using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManiger : MonoBehaviour {
    public bool resetHighScore = false;
    public float time = 1f;
    public Transform objSpawn;
    public GameObject[] skral;
    public float speed = 1f;
    float spawnTime = 5f;
    public int skralPool = 10;
    List<GameObject> skrals;
    public TextMesh highscore;
    public TextMesh livetext;
    public TextMesh livescore;
    public int live = 3;
    string highScoreString;
    List<int> highScores = new List<int>();
    //public GameObject skralleMover;

    int score = 0;
	// Use this for initialization
	void Start ()
    {
        if (resetHighScore == true)
        {
            DeleteHighScore();
        }
        livetext.text = live.ToString();
        livescore.text = score.ToString();
        skrals = new List<GameObject>();
        for (int i = 0; i < skralPool; i++)
        {
            for (int f = 0; f < skral.Length; f++)
            {
                GameObject obj = (GameObject)Instantiate(skral[f]);
                obj.SetActive(false);
                skrals.Add(obj);
            }
        }
        StartCoroutine(Spawner());
        StartCoroutine(SpawnTimer());


        // Hvis vi finder vores Skralde High Score
        if(PlayerPrefs.HasKey("SkraldeScore"))
        {
            highscore.text = "";
            Debug.Log("SkraldeScore Found");

            //string s = PlayerPrefs.GetString("SkraldeScore");
            //string[] scoreString = s.Split(',');

            //int score;

            //for (int i = 0; i < scoreString.Length; i++)
            //{

            //    if(int.TryParse(scoreString[i], out score))
            //    {
            //        highScores.Add(score);
            //    }
            //    else
            //    {
            //        highScores.Add(0);
            //    }
            //}

            PopulateScoreListFromString();

            UpdateHighScoreDisplay();

        }
        // Hvis IKKE vi finder vores skralde high score
        else
        {
            // Reset vores high score TextMesh.text
            highscore.text = "";
            for (int i = 0; i < 10; i++)
            {
                // Sæt alle scores til 0 og smid dem i vores highScores liste
                highScores.Add(0);
            }

            string saveString = "";

            for (int i = 0; i < highScores.Count; i++)
            {
                // Opdatere spillets ingame highscore
                highscore.text += (i+1) + ". " + highScores[i];
                highscore.text += "\n";

                // Opdateres vores highscore save string
                saveString += highScores[i];

                if (i < highScores.Count - 1)
                    saveString += ",";

            }
            // Gem vores highscore string
            PlayerPrefs.SetString("SkraldeScore", saveString);
        }
       
    }
	
	

    // Slet highScore listen fra computeren
    void DeleteHighScore()
    {
        if (PlayerPrefs.HasKey("SkraldeScore"))
            PlayerPrefs.DeleteKey("SkraldeScore");
    }

    void PopulateScoreListFromString()
    {
        highscore.text = "";
        if (PlayerPrefs.HasKey("SkraldeScore"))
        {
            string s = PlayerPrefs.GetString("SkraldeScore");
            string[] scoreString = s.Split(',');

            int intScore;

            highScores.Clear();

            for (int i = 0; i < scoreString.Length; i++)
            {
                if (int.TryParse(scoreString[i], out intScore))
                {
                    highScores.Add(intScore);
                }
                else
                {
                    highScores.Add(0);
                }
            }
        }
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.B))
        {

        }
    }

    void UpdateHighScoreDisplay()
    {
        highscore.text = "";
        highScores.Sort();
        highScores.Reverse();

        for (int i = 0; i < highScores.Count; i++)
        {
            highscore.text += (i + 1) + ". " + highScores[i];
            highscore.text += "\n";
        }
    }


    // Tilføj player score til Highscoren //
    void AddPlayerScoreToHighScore(int _playerScore)
    {
        highscore.text = "";
        // tilføj playerens score til vores highscore liste
        highScores.Add(_playerScore);

        // sortere og flip listen - flip fordi vi gerne vil have det største tal øverst/først
        highScores.Sort();
        highScores.Reverse();

        // slet den sidste plads i highscoren - så vi bliver på 10
        highScores.RemoveAt(highScores.Count-1);
        
        

    }

    void SaveHighScore()
    {
        highscore.text = "";
        // Gem den nye liste
        string scoreToSave = "";

        for (int i = 0; i < highScores.Count; i++)
        {
            scoreToSave += highScores[i];

            if (i < highScores.Count - 1)
                scoreToSave += ",";

        }

        PlayerPrefs.SetString("SkraldeScore", scoreToSave);
    }

    void SaveHighScoreToClaud()
    {

    }

    // Find din HighScore Position
    int GetHighScorePosition(int _playerScore)
    { 
        int highScorePosition = -1;

        for (int i = 0; i < highScores.Count; i++)
        {
            if(highScores[i] == _playerScore)
            {
                highScorePosition = i + 1;
                break;
            }
        }

        return highScorePosition;
    }

    void Louse()
    {
        for (int i = 0; i < skrals.Count; i++)
        {
            if (skrals[i].activeInHierarchy)
            {
                skrals[i].SetActive(false);
            }
        }
    }

    IEnumerator Spawner()
    {
        for (int i = 0; i < skrals.Count; i++)
        {
            int skals = Random.Range(0, skrals.Count);
            if (!skrals[skals].activeInHierarchy)
            {
                //GameObject sm = Instantiate(skralleMover, objSpawn.transform.position, Quaternion.identity);
                skrals[skals].transform.position = objSpawn.position;
                skrals[skals].transform.rotation = objSpawn.rotation;
                skrals[skals].SetActive(true);
                skrals[skals].GetComponent<Rigidbody>().velocity = Vector3.zero;
                skrals[skals].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                //sm.GetComponent<TrashMover>().ParentTrashToMover(skrals[skals]);
                //skrals[skals].GetComponent<Rigidbody>().isKinematic = true;

                skrals[skals].AddComponent<TrashMoverPhysics>();
                skrals[skals].GetComponent<TrashMoverPhysics>().SetSpeed(speed);

                break;
            }
        }

        yield return new WaitForSecondsRealtime(spawnTime);
        StartCoroutine(Spawner());
    }
    
    IEnumerator SpawnTimer()
    {
        if (spawnTime >= 2f)
        {
            spawnTime -= 0.01f;
        }
        else
        {
            spawnTime /= 1.1f;
        }
        
        yield return new WaitForSecondsRealtime(time);
        StartCoroutine(SpawnTimer());
    }
    
    public void PointKeeper(int _point)
    {
        score += _point;
        livescore.text = score.ToString();
    }
    public void Live()
    {
        if (live > 1)
        {
            live -= 1;
            livetext.text = live.ToString();
        }
        else if (live == 1)
        {
            live -= 1;
            livetext.text = live.ToString();
            Louse();
            AddPlayerScoreToHighScore(score);
            SaveHighScore();
            PopulateScoreListFromString();
            UpdateHighScoreDisplay();
            StopAllCoroutines();
            
        }
    }
}
