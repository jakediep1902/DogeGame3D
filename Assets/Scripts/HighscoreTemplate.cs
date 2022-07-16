using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTemplate : MonoBehaviour
{
    public Text txtPos;
    public Text txtName;
    public Text txtScore;
    private void Start()
    {
        txtPos.text = "???";
        txtName.text = "???";
        txtScore.text = "???";
    }
}
