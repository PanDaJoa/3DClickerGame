using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.VersionControl.Asset;
public enum ShopType
{

}
public class Shop : MonoBehaviour, IPointerClickHandler
{
    // TouchShop
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

    // ItemShop
    public float ItemShop1Prize;
    public TextMeshProUGUI ItemShop1Text;

    public float ItemShop2Prize;
    public TextMeshProUGUI ItemShop2Text;

    public float ItemShop3Prize;
    public TextMeshProUGUI ItemShop3Text;
   
    // DamageUI
    public TextMeshProUGUI AllDamageText;
    public TextMeshProUGUI AllPerSecondPowerText;

    public float AutoAttack = 60f;
    private bool isAutoAttack = false;

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
        Amount1Text.text = "업그레이드 수 +" + Amount1 +" "+" 공격력 +" + Amount1HitPower + " ";
        Amount2Text.text = "업그레이드 수 +" + Amount2 +" "+" 공격력 +" + Amount2HitPower + " ";

        // ItemShop
        ItemShop1Text.text = "터치점수 X 2 " + ItemShop1Prize.ToString("F2") + " $";
        ItemShop2Text.text = "초당 공격력 +1: " + ItemShop2Prize.ToString("F2") + " $";    
        ItemShop3Text.text = "초당 터치공격력의 2배 자동공격 1분: "+ ItemShop3Prize.ToString("F2") + " $";


        AllDamageText.text = "총 공격력 : " + _frog.HitPower;
        AllPerSecondPowerText.text = "초당 공격력 : " + _frog.PerSecondPlus;

    }
    public void Shop1()
    {
        if (_frog.CurrentScore >= Shop1Prize)
        {
            _frog.CurrentScore -= Shop1Prize; // 돈 지불
            Amount1 += 1;                // 업그레이드 수
            Amount1HitPower += 2;        // 이미지 공격
            Amount1PerSecondPlus += 1;   // 이미지 초당 공격
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
            _frog.HitPower += 5;
            Shop2Prize += 125;
        }
    }
    public void ItemShop1()
    {
        if (_frog.CurrentScore >= ItemShop1Prize)
        {
            _frog.CurrentScore -= ItemShop1Prize; 
            _frog.HitPower *= 2;
            ItemShop1Prize *= 50;
        }
    }

    public void ItemShop2()
    {
        if (_frog.CurrentScore >= ItemShop2Prize)
        {
            _frog.CurrentScore -= ItemShop2Prize;
            _frog.PerSecondPlus += 1;    // 초당 공격
            ItemShop2Prize *= 5;
        }
    }
    public void ItemShop3()
    {
        if (!_frog) return;
        
        if (!isAutoAttack)
        {
            if ((_frog.CurrentScore >= ItemShop3Prize))
            {
                _frog.CurrentScore -= ItemShop3Prize;
                ItemShop3Prize *= 5;

                StartCoroutine(MoneyUP());

                isAutoAttack = true;

            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
    IEnumerator MoneyUP()
    {
        for(int i  = 0; i < AutoAttack; i++) 
        {
            _frog.CurrentScore += _frog.HitPower * 2;

            yield return new WaitForSeconds(1);
        }

        isAutoAttack = false;
    }

}
