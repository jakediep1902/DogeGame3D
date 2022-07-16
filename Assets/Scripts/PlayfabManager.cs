using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using System;
using UnityEngine.UI;

public class PlayfabManager : MonoBehaviour
{
    GameController gameController;
    public static PlayfabManager Instance;
    public Text txtName;
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
    }
    public void UpdateScore()
    {
        Login();     
    }
    public void SaveScore()
    {
        Login();
    }
   public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "BestScore",
                    Value = score                 
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, UpdateScoreSuccess, UpdateError);
    }

    private void UpdateError(PlayFabError obj)
    {
        Debug.Log($"Error + {obj.ErrorMessage}");
    }

    private void UpdateScoreSuccess(UpdatePlayerStatisticsResult obj)
    {
        Debug.Log($"Save score success");       
        //GetLeaderBoard();      
    }   
    public void GetLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "BestScore",
            StartPosition = 0,
            MaxResultsCount = 4,
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    private void OnError(PlayFabError obj)
    {
        Debug.Log(obj.ErrorMessage);
    }

    private void OnLeaderboardGet(GetLeaderboardResult obj)
    {
        //Debug.Log($"Get Leaderboard Successful");
        SetHighscore(obj);
    }
    public void SetHighscore(GetLeaderboardResult result)
    {
        var info = result.Leaderboard;
        foreach (var item in info)
        {
            //Debug.Log($"Pos: {item.Position} : name: {item.DisplayName}  :  score: {item.StatValue}");
            Highscore highscore = new Highscore(item.Position, item.StatValue, item.DisplayName);
            gameController.SetHighScore(highscore);
        }
    }
    public void Login()
    {
        if(inputName.text=="")
        {
            var request = new LoginWithPlayFabRequest
            {
                Username = "Unknow",
                Password = "123123",
            };
            PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginError);
        }
        else
        {
            var request = new LoginWithPlayFabRequest
            {
                Username = inputName.text,
                Password = "123123",
            };
            PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginError);
        }      
    }
    public void Register()
    {
        var request1 = new RegisterPlayFabUserRequest
        {
            Username = inputName.text,
            Password = "123123",
            DisplayName = inputName.text,
            RequireBothUsernameAndEmail = false,
        };
        PlayFabClientAPI.RegisterPlayFabUser(request1, OnRegisted, OnRegisterError);

        //var request = new LoginWithCustomIDRequest
        //{
        //    CustomId = inputName.text,
        //    CreateAccount = true,                
        //};
        //PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginError);
    }

    private void OnRegisterError(PlayFabError obj)
    {
        
        Debug.Log($"Error " + obj.ErrorMessage);
    }

    private void OnRegisted(RegisterPlayFabUserResult obj)
    {
        //Debug.Log("Registed");
        SendLeaderboard(gameController.GetScore());
    }

    private void OnLoginError(PlayFabError obj)
    {
        Debug.Log(obj.ErrorMessage);
        Register();
    }

    private void OnLoginSuccess(LoginResult obj)
    {
        //Debug.Log($"Login success");
        SendLeaderboard(gameController.GetScore());
        GetLeaderBoard();        
    }
}
