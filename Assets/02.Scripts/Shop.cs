using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shop : MonoBehaviour, IPointerClickHandler
{
    // Shop
    public float Shop1Prize;
    public TextMeshProUGUI Shop1Text;

    public float Shop2Prize;
    public TextMeshProUGUI Shop2Text;

    // Amount
    public TextMeshProUGUI Amount1Text;
    public int Amount1;
    public float Amount1HitPower;
    public float Amount1PerSecondPlus;

    public TextMeshProUGUI Amount2Text;
    public int Amount2;
    public float Amount2HitPower;
    public float Amount2PerSecondPlus;

    public TextMeshProUGUI AllDamageText;
    public TextMeshProUGUI AllPerSecondPowerText;

    private Frog _frog;

    public void Start()
    {
        _frog = FindObjectOfType<Frog>(); 
    }
    public void Update()
    {
        // Shop
        Shop1Text.text = "상점 1: " + Shop1Prize.ToString("F2") + " $";
        Shop2Text.text = "상점 2: " + Shop2Prize.ToString("F2") + " $";

        // Amount
        Amount1Text.text = "업그레이드 수 +" + Amount1 +" "+" 공격력 +" + Amount1HitPower + " "+" 초당 공격 +" + Amount1PerSecondPlus;
        Amount2Text.text = "업그레이드 수 +" + Amount2 +" "+" 공격력 +" + Amount2HitPower + " "+" 초당 공격 +" + Amount2PerSecondPlus;

        AllDamageText.text = "총 공격력 : " + _frog.HitPower;
        AllPerSecondPowerText.text = "초당 공격력 : " + _frog.PerSecondPlus;
    }
    public void Shop1()
    {
        if (_frog.CurrentScore >= Shop1Prize)
        {
            _frog.CurrentScore -= Shop1Prize;
            Amount1 += 1;                // 업그레이드 수
            Amount1HitPower += 2;        // 이미지 공격
            Amount1PerSecondPlus += 1;   // 이미지 초당 공격
            _frog.PerSecondPlus += 1;    // 초당 공격
            _frog.HitPower += 2;         // 터치 공격
            Shop1Prize *= 1.5f;
        }
    }
    public void Shop2()
    {
        if (_frog.CurrentScore >= Shop2Prize)
        {
            _frog.CurrentScore -= Shop2Prize;
            Amount2 += 1;
            Amount2HitPower += 5;
            Amount2PerSecondPlus += 3;
            _frog.PerSecondPlus += 3;
            _frog.HitPower += 5;
            Shop2Prize += 125;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

}
