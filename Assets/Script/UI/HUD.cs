using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    private float ChickenLife;
    private float SaveChickenLife;
    private bool FirstHit;
    public Image MaskBack;
    public Image MaskFill;
    public Image Back;
    public Image Fill;
    public Text CoinsText1;
    public Text CoinsText2;
    public Text TowersText1;
    public Text TowersText2;
    public Text TowersMaxText1;
    public Text TowersMaxText2;
    public Text ScoreText1;
    public Text ScoreText2;
    public GameManager Game_Manager;
    public GameObject Lifebar;
    private Animator Lifebar_Animator;
    private int Coins;
    private int Towers;
    private int MaxTowers;
    private int Score;

    // Start is called before the first frame update
    void Start()
    {
        SaveChickenLife = ChickenLife;
        Lifebar_Animator = Lifebar.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Coins = Game_Manager.coins;
        Towers = Game_Manager.towers.Count;
        MaxTowers = Game_Manager.maxTower;
        Score = Game_Manager.score;

        CoinsText1.text = Coins.ToString();
        CoinsText2.text = Coins.ToString();
        TowersText1.text = Towers.ToString();
        TowersText2.text = Towers.ToString();
        TowersMaxText1.text = MaxTowers.ToString();
        TowersMaxText2.text = MaxTowers.ToString();
        ScoreText1.text = Score.ToString();
        ScoreText2.text = Score.ToString();

        ChickenLife = Game_Manager.GetChickenLife();
        MaskBack.rectTransform.anchoredPosition = new Vector3(180, (ChickenLife * -540) - 4);
        Back.rectTransform.anchoredPosition = new Vector3(60, (ChickenLife * 540) - 540);
        MaskFill.rectTransform.anchoredPosition = new Vector3(180, ChickenLife * -540);
        Fill.rectTransform.anchoredPosition = new Vector3(60, (ChickenLife * 540) -540);

        if (SaveChickenLife != ChickenLife)
        {
           if (FirstHit == true)
            {
                Lifebar_Animator.SetTrigger("Hit");
                SaveChickenLife = ChickenLife;
            } else
            {
                SaveChickenLife = ChickenLife;
                FirstHit = true;
            }
            
        }
    }
}
