using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;


[CreateAssetMenu(fileName = "Shop Data", menuName = "Scriptable Object/Shop", order = int.MaxValue)]
public class Shop : ScriptableObject
{
    [SerializeField]
    private float Lv1;
    public float lv1 { get { return lv1; } }
    [SerializeField]
    private float Lv2;
    public float lv2 { get { return lv2; } }
    [SerializeField]
    private float Lv3;
    public float lv3 { get { return lv3; } }
    [SerializeField]
    private float Lv4;
    public float lv4 { get { return lv4; } }
    [SerializeField]
    private float Lv5;
    public float lv5 { get { return lv5; } }
}
