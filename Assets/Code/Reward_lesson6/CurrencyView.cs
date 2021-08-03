using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{

    private const string WoodKey = nameof(WoodKey);
    private const string DiamondKey = nameof(DiamondKey);

    public static CurrencyView Instance { get; set; }

    [SerializeField]
    private TMP_Text _woodCount;

    [SerializeField]
    private TMP_Text _diamondCount;

    private int Wood
    {
        get => PlayerPrefs.GetInt(WoodKey, 0);
        set => PlayerPrefs.SetInt(WoodKey, value);
    }

    private int Diamonds
    {
        get => PlayerPrefs.GetInt(DiamondKey, 0);
        set => PlayerPrefs.SetInt(DiamondKey, value);
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        RefreshText();
    }
    public void AddWood(int value)
    {
        Wood += value;
        RefreshText();
    }

    public void AddDiamonds(int value)
    {
        Diamonds += value;
        RefreshText();
    }
    private void RefreshText()
    {
        _woodCount.text = Wood.ToString();
        _diamondCount.text = Diamonds.ToString();
    }

}
