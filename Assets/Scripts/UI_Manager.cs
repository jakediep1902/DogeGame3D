using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    GameController gameController;
    public static UI_Manager Instance;
    public Button btnSaveScore;
    public Button btnUpdateScore;
    public InputField inputName;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        gameController = GameController.Instance;
        btnSaveScore.onClick.AddListener(() =>
        {
            btnSaveScore.gameObject.SetActive(false);
            inputName.gameObject.SetActive(false);
            gameController.PlayAudioClip(gameController.clipBtn);
        });
        btnUpdateScore.onClick.AddListener(() =>
        {
            gameController.PlayAudioClip(gameController.clipBtn);
            btnUpdateScore.gameObject.SetActive(false);            
        });
    }
    
       
}
