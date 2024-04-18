using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.VersionControl.Asset;
public enum MoneyUnit
{
    None,
    Thousand,
    Million,
    Billion,
    Trillion,
    Quadrillion,
    Quintillion,
    Sextillion,
    Septillion,
    Octillion,
    Nonillion,
    Decillion,
    Undecillion,
    Duodecillion,
    Tredecillion,
    Quattuordecillion,
    Quindecillion,
    Sexdecillion,
    Septendecillion,
    Octodecillion,
    Novemdecillion,
    Vigintillion,
    Unvigintillion,
    Duovigintillion,
    Tresvigintillion,
    Quattuorvigintillion,
    Quinquavigintillion,
}
public class Shop : MonoBehaviour, IPointerClickHandler
{
    public static Shop Instance { get; private set; }

    // TouchShop
    public float Shop1Prize;
    public TextMeshProUGUI Shop1Text;

    public float Shop2Prize;
    public TextMeshProUGUI Shop2Text;

    public float Shop3Prize;
    public TextMeshProUGUI Shop3Text;

    public float Shop4Prize;
    public TextMeshProUGUI Shop4Text;

    public float Shop5Prize;
    public TextMeshProUGUI Shop5Text;

    public float Shop6Prize;
    public TextMeshProUGUI Shop6Text;

    public float Shop7Prize;
    public TextMeshProUGUI Shop7Text;

    // Amount
    public TextMeshProUGUI Amount1Text;
    public int Amount1;
    public float Amount1HitPower;

    public TextMeshProUGUI Amount2Text;
    public int Amount2;
    public float Amount2HitPower;

    public TextMeshProUGUI Amount3Text;
    public int Amount3;
    public float Amount3HitPower;

    public TextMeshProUGUI Amount4Text;
    public int Amount4;
    public float Amount4HitPower;

    public TextMeshProUGUI Amount5Text;
    public int Amount5;
    public float Amount5HitPower;

    public TextMeshProUGUI Amount6Text;
    public int Amount6;
    public float Amount6HitPower;

    public TextMeshProUGUI Amount7Text;
    public int Amount7;
    public float Amount7HitPower;

    // ItemShop
    public float ItemShop1Prize;
    public TextMeshProUGUI ItemShop1Text;

    public float ItemShop2Prize;
    public TextMeshProUGUI ItemShop2Text;

    public float ItemShop3Prize;
    public TextMeshProUGUI ItemShop3Text;

    // ItemAmount
    public TextMeshProUGUI ItemAmount1Text;
    public int ItemAmount1;

    public TextMeshProUGUI ItemAmount2Text;
    public int ItemAmount2;

    public TextMeshProUGUI ItemAmount3Text;
    public int ItemAmount3;

    // DamageUI
    public TextMeshProUGUI AllDamageText;
    public TextMeshProUGUI AllPerSecondPowerText;

    public float AutoAttack = 60f;
    private bool isAutoAttack = false;

    private Frog _frog;
    private float itemHitPower;
    public bool HasTouchPowerDoubledItem;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void Start()
    {
        _frog = FindObjectOfType<Frog>();
    }
    public void Update()
    {
        // Shop
        Shop1Text.text = "상점 1: " + FormatMoney(Shop1Prize) + " $";
        Shop2Text.text = "상점 2: " + FormatMoney(Shop2Prize) + " $";
        Shop3Text.text = "상점 3: " + FormatMoney(Shop2Prize) + " $";
        Shop4Text.text = "상점 4: " + FormatMoney(Shop2Prize) + " $";
        Shop5Text.text = "상점 5: " + FormatMoney(Shop2Prize) + " $";
        Shop6Text.text = "상점 6: " + FormatMoney(Shop2Prize) + " $";
        Shop7Text.text = "상점 7: " + FormatMoney(Shop2Prize) + " $";

        // Amount
        Amount1Text.text = "업그레이드 수 +" + Amount1 + " " + " 공격력 +" + FormatMoney(Amount1HitPower) + " ";
        Amount2Text.text = "업그레이드 수 +" + Amount2 + " " + " 공격력 +" + FormatMoney(Amount2HitPower) + " ";
        Amount3Text.text = "업그레이드 수 +" + Amount2 + " " + " 공격력 +" + FormatMoney(Amount2HitPower) + " ";
        Amount4Text.text = "업그레이드 수 +" + Amount2 + " " + " 공격력 +" + FormatMoney(Amount2HitPower) + " ";
        Amount5Text.text = "업그레이드 수 +" + Amount2 + " " + " 공격력 +" + FormatMoney(Amount2HitPower) + " ";
        Amount6Text.text = "업그레이드 수 +" + Amount2 + " " + " 공격력 +" + FormatMoney(Amount2HitPower) + " ";
        Amount7Text.text = "업그레이드 수 +" + Amount2 + " " + " 공격력 +" + FormatMoney(Amount2HitPower) + " ";

        // ItemShop
        ItemShop1Text.text = "총 공격력 X 2 " + FormatMoney(ItemShop1Prize) + " $";
        ItemShop2Text.text = "초당 공격력 +1: " + FormatMoney(ItemShop2Prize) + " $";
        ItemShop3Text.text = "총 공격력 2배 자동공격 1분: " + FormatMoney(ItemShop3Prize) + " $";

        // ItemAmount
        ItemAmount1Text.text = "업그레이드 수+" + ItemAmount1;
        ItemAmount2Text.text = "업그레이드 수+" + ItemAmount2 + " " + " 초당공격력 " + FormatMoney(_frog.PerSecondPlus);


        AllDamageText.text = "총 공격력 : " + FormatMoney(_frog.HitPower);
        AllPerSecondPowerText.text = "초당 공격력 : " + FormatMoney(_frog.PerSecondPlus);

    }
    public string FormatMoney(float money)
    {
        MoneyUnit unit = MoneyUnit.None;
        while (money >= 1000f && unit < MoneyUnit.Quinquavigintillion)
        {
            money /= 1000f;
            unit++;
        }

        return $"{money:F2} {GetMoneyUnitString(unit)}";
    }
    private string GetMoneyUnitString(MoneyUnit unit)
    {
        switch (unit)
        {
            case MoneyUnit.None: return "";
            case MoneyUnit.Thousand: return "a";
            case MoneyUnit.Million: return "b";
            case MoneyUnit.Billion: return "c";
            case MoneyUnit.Trillion: return "d";
            case MoneyUnit.Quadrillion: return "e";
            case MoneyUnit.Quintillion: return "f";
            case MoneyUnit.Sextillion: return "g";
            case MoneyUnit.Septillion: return "h";
            case MoneyUnit.Octillion: return "i";
            case MoneyUnit.Nonillion: return "j";
            case MoneyUnit.Decillion: return "k";
            case MoneyUnit.Undecillion: return "l";
            case MoneyUnit.Duodecillion: return "m";
            case MoneyUnit.Tredecillion: return "n";
            case MoneyUnit.Quattuordecillion: return "o";
            case MoneyUnit.Quindecillion: return "p";
            case MoneyUnit.Sexdecillion: return "q";
            case MoneyUnit.Septendecillion: return "r";
            case MoneyUnit.Octodecillion: return "s";
            case MoneyUnit.Novemdecillion: return "t";
            case MoneyUnit.Vigintillion: return "u";
            case MoneyUnit.Unvigintillion: return "v";
            case MoneyUnit.Duovigintillion: return "w";
            case MoneyUnit.Tresvigintillion: return "x";
            case MoneyUnit.Quattuorvigintillion: return "y";
            case MoneyUnit.Quinquavigintillion: return "z";
            default: return "";
        }
    }
    public void Shop1()
    {
        if (_frog.CurrentScore >= Shop1Prize)
        {
            _frog.CurrentScore -= Shop1Prize; // 돈 지불
            Amount1 += 1;                // 업그레이드 수
                    
            if (Amount1 > 1) // 처음에 샀을 때는 Amount1HitPower가 증가하도록
            {
                Amount1HitPower += 50;    // 텍스트 공격
            }
            _frog.HitPower += 50;     // 터치 공격
           

            Shop1Prize *= 1.5f;
        }
    }
    public void Shop2()
    {
        if (_frog.CurrentScore >= Shop2Prize)
        {
            _frog.CurrentScore -= Shop2Prize;
            Amount2 += 1;

            if (Amount2 > 1) // 처음에 샀을 때는 Amount1HitPower가 증가하도록
            {
                Amount2HitPower += 100;    // 텍스트 공격
            }
            _frog.HitPower += 100;     // 터치 공격

            Shop2Prize *= 1.5f;
        }
    }
    public void ItemShop1()
    {
        if (_frog.CurrentScore >= ItemShop1Prize)
        {
            // 가격 마이너스
            _frog.CurrentScore -= ItemShop1Prize;

            // 2배 아이템 사용시 파워2배 올리기
            _frog.HitPower *= 2;
            
            ItemAmount1 += 1;
            ItemShop1Prize *= 50;

            HasTouchPowerDoubledItem = true;
        }
    }

    public void ItemShop2()
    {
        if (_frog.CurrentScore >= ItemShop2Prize)
        {
            _frog.CurrentScore -= ItemShop2Prize;
            _frog.PerSecondPlus += 1000;    // 초당 공격
            ItemAmount2 += 1;
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
        for (int i = 0; i < AutoAttack; i++)
        {
            _frog.CurrentScore += CalculateTotalDamage() * 2;

            yield return new WaitForSeconds(1);
        }

        isAutoAttack = false;
    }
    private float CalculateTotalDamage()
    {
        return _frog.HitPower + itemHitPower;
    }

}
