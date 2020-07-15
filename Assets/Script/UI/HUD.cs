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
    public Text ToolTipText;
    public GameManager Game_Manager;
    public GameObject Lifebar;
    public GameObject ToolTip;
    public GameObject Upgrade;
    public GameObject IconTower;
    public GameObject IconCannon;
    public GameObject IconWizard;
    public Text UpgradePrice;
    public Text UpgradeDescription;
    private Animator Lifebar_Animator;
    private Animator Upgrade_Animator;
    public Animator Dead;
    private int Coins;
    private int Towers;
    private int MaxTowers;
    private int Score;
    private bool showUpgrade;
    
    // Start is called before the first frame update
    void Start()
    {
        SaveChickenLife = ChickenLife;
        Lifebar_Animator = Lifebar.GetComponent<Animator>();
        Upgrade_Animator = Upgrade.GetComponent<Animator>();
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
        if (ChickenLife < 0.2f && ChickenLife != 0)
        {
            ChickenLife = 0.1f + ChickenLife*0.1f;
        }
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
            if(ChickenLife<=0) Dead.SetBool("dead",true);
        }

        if (Game_Manager.IsInteractible() == true)
        {
            ToolTipText.text = "PLACE";
            ToolTip.SetActive(true);
            
        } else
        {
            if (Game_Manager.GetNearTower() == true)
            {
                ToolTipText.text = "TAKE";
                ToolTip.SetActive(true);
                
            } else
            {
                ToolTip.SetActive(false);
            }
        }

        if (Game_Manager.IsInteractible() && Game_Manager.TowerInteractible().existUpgrade && (Game_Manager.TowerInteractible().upgrade.price <= Game_Manager.coins) && !showUpgrade)
        {
            showUpgrade = true;
            Upgrade.SetActive(true);
            Upgrade_Animator.SetTrigger("Open");
            UpgradePrice.text = "" + Mathf.Floor(Game_Manager.TowerInteractible().upgrade.price);
            if (Game_Manager.TowerInteractible().name == "SimpleTower")
            {
                IconTower.SetActive(true);
                IconCannon.SetActive(false);
                IconWizard.SetActive(false);
                UpgradeDescription.text = "RATE OF FIRE x3";

            }
            else if (Game_Manager.TowerInteractible().name == "Cannon")
            {
                IconTower.SetActive(false);
                IconCannon.SetActive(true);
                IconWizard.SetActive(false);
                UpgradeDescription.text = "DAMAGE x2.5";

            }
            else if (Game_Manager.TowerInteractible().name == "Wizard")
            {
                IconTower.SetActive(false);
                IconCannon.SetActive(false);
                IconWizard.SetActive(true);
                UpgradeDescription.text = "EFFECT ZONE x2";

            }
        }

        else if ((!Game_Manager.IsInteractible() || !Game_Manager.TowerInteractible().existUpgrade) || (Game_Manager.TowerInteractible().upgrade.price > Game_Manager.coins) && showUpgrade)
        {
            showUpgrade = false;
            Upgrade.SetActive(false);

        }
    }

    public void OnUpgradeButtonClick()
    {
        Game_Manager.TowerInteractible().Upgrade();
    }
}
