using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shop : MonoBehaviour, IPointerClickHandler
{
    // Shop
    public int Shop1Prize;
    public TextMeshProUGUI Shop1Text;

    public int Shop2Prize;
    public TextMeshProUGUI Shop2Text;

    // Amount
    public TextMeshProUGUI Amount1Text;
    public int Amount1;
    public float Amount1Profit;

    public TextMeshProUGUI Amount2Text;
    public int Amount2;
    public float Amount2Profit;

    private Frog _frog;

    public void Start()
    {
        _frog = FindObjectOfType<Frog>(); 
    }
    public void Update()
    {
        // Shop
        Shop1Text.text = "Tire 1: " + Shop1Prize + " $";
        Shop2Text.text = "Tire 2: " + Shop2Prize + " $";

        // Amount
        Amount1Text.text = "Tire 1: " + Amount1 + " arts $: " + Amount1Profit + "/s";
        Amount2Text.text = "Tire 2: " + Amount2 + " arts $: " + Amount2Profit + "/s";
    }
    public void Shop1()
    {
        if (_frog.CurrentScore >= Shop1Prize)
        {
            _frog.CurrentScore -= Shop1Prize;
            Amount1 += 1;
            Amount1Profit += 1;
            _frog.PerSecondPlus += 1;
            Shop1Prize += 25;
        }
    }
    public void HitPowerUP1()
    {
        _frog.HitPower += 1;
    }

    public void Shop2()
    {
        if (_frog.CurrentScore >= Shop2Prize)
        {
            _frog.CurrentScore -= Shop2Prize;
            Amount2 += 1;
            Amount2Profit += 5;
            _frog.PerSecondPlus += 5;
            Shop2Prize += 125;
        }
    }

    public void HitPowerUP2()
    {
        _frog.HitPower += 5;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

}
