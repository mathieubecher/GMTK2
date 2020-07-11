using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfosGestor : MonoBehaviour
{
    private GameManager _manager;

    [SerializeField] private TextMeshProUGUI coins;
    [SerializeField] private TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        _manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SetCoints();
        SetScore();
    }

    void SetCoints()
    {
        coins.text = "Coins : " + _manager.coins;
    }

    void SetScore()
    {
        score.text = "Score : " + _manager.score;
    }
}
