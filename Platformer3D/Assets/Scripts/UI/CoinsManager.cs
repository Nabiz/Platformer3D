using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    public TMP_Text textScore;
    public float coins;


    void Start()
    {
        coins = 0f;
        textScore.text = coins.ToString() + " COINS";
    }

    void Update()
    {
        textScore.text = coins.ToString() + " COINS";
    }


}