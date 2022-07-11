using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController Instance;
    public BackGround backGround;
    public List<Cityzen> cityzens = new List<Cityzen>();
    public List<HighscoreTemplate> listHighscore = new List<HighscoreTemplate>(4);
    public GameObject pnlEndGame;
    public Button btnRestart;
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
    public Text txtPoint;
    private int gamePoint;
    
    AudioSource audio;

    public Text txtScore;
    private int score = 0;
    // Use this for initialization
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        AddCityzens();
        StartCoroutine(nameof(DelaySpawCityZenOnStart));
    }
    void Start () {
        Time.timeScale = 1;
        pnlEndGame.SetActive(false);
        //audio = gameObject.GetComponent<AudioSource>();

        

    }

    // Update is called once per frame
    void Update () {
	
	}
    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();

    }
    public void ButtonHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;

    }
    public void ButtonIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;

    }
    public void ButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;

    }
    
    public void StartGame()
    {
        
        SceneManager.LoadScene("Game");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void EndGame()       
    {
        //audio.Play();
        Invoke(nameof(StopGame), 2f);
    }
    public void StopGame()
    {
        Time.timeScale = 0;
        pnlEndGame.SetActive(true);
        backGround.SetMusic();
    }
    public void AddCityzens()
    {
        var arrCityzen = FindObjectsOfType<Cityzen>();
        cityzens.AddRange(arrCityzen);
        foreach (var item in cityzens)
        {
            item.gameObject.SetActive(false);
        }
    }
    IEnumerator DelaySpawCityZenOnStart()
    {
        yield return new WaitForSeconds(3f);
        foreach (var item in cityzens)
        {
            item.gameObject.SetActive(true);
            yield return new WaitForSeconds(10f);
            
        }
    }
    public void SetScore()
    {
        score++;
        txtScore.text = score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
    public void SetHighScore(Highscore highscore)
    {      
        for (int i = highscore.GetPos(); i < listHighscore.Count; i++)
        {
            listHighscore[i].txtPos.text = highscore.GetPos().ToString();
            listHighscore[i].txtScore.text = highscore.GetScore().ToString();
            listHighscore[i].txtName.text = highscore.GetName();
            break;
        }
    }
    //public void RestartGame(float delay =3f)
    //{
    //    Invoke(nameof(LoadScene), delay);
    //}
    //public void LoadScene()
    //{
    //    SceneManager.LoadScene("Game");
    //}
}
