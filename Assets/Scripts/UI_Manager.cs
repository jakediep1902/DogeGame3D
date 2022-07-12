using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
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
        btnSaveScore.onClick.AddListener(() =>
        {
            btnSaveScore.gameObject.SetActive(false);
            inputName.gameObject.SetActive(false);
        });
        btnUpdateScore.onClick.AddListener(() =>
        {
            btnUpdateScore.gameObject.SetActive(false);            
        });
    }
    
       
}
