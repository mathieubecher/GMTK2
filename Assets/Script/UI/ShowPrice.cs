using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class ShowPrice : MonoBehaviour
{
    public Text Price;
    public Color upgradable;
    public Color notUpgradable;
    public Text PriceBackground;
    public HUD gestor;

    private Animator _animator;
    public float speed = 200f;
    private float actualPrice = 0;
    private int gotToPrice = 0;
    private bool drawPrice;
    private float elapsed = 0;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (drawPrice && actualPrice < gotToPrice)
        {

            actualPrice += Time.deltaTime * speed;
            if (actualPrice > gotToPrice) actualPrice = gotToPrice;
            Price.text = ""+(int)Mathf.Ceil(actualPrice);
            PriceBackground.text = ""+ (int)Mathf.Ceil(actualPrice);
        }

        if (drawPrice && gestor.Game_Manager.IsInteractible() && gestor.Game_Manager.TowerInteractible().existUpgrade)
        {
            
            if (actualPrice <= gestor.Game_Manager.coins)
            {
                Price.color = upgradable;
            }
            else Price.color = notUpgradable;
            _animator.SetBool("enoughtcoins",gestor.Game_Manager.TowerInteractible().upgrade.price <= gestor.Game_Manager.coins);
        }
    }

    public void DrawPrice()
    {
        drawPrice = true;
        actualPrice = 0;
        gotToPrice = gestor.Game_Manager.TowerInteractible().upgrade.price;
    }

    public void BeginUpgrade()
    {
        _animator.SetBool("upgrade",true);
    }

    public void StopUpgrade()
    {
        _animator.SetBool("upgrade", false);
        drawPrice = false;
    }
}
