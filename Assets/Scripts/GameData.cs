using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{

    public int GameInteger { get; set; }
    public string GameString { get; set; }

    [SerializeField]
    private Text textInteger;

    public void GenerateNewData()
    {
        GameInteger = Random.Range(1, 300);
        //GameString = System.Convert.ToBase64String(System.BitConverter.GetBytes(inputString));
        ShowData();
    }

    public void ShowData()
    {
        textInteger.text = GameInteger.ToString();
    }
    
   
}
