using System;
using System.Collections.Generic;
using AnnoyingAds.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdCardView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _sendAddButton;
    private AdCard _config;

    public void DrawCard(AdCard adCard)
    {
        _image.sprite = adCard.image;
        _text.text = adCard.text;
        _config = adCard;
    }

    private void OnEnable()
    {
        _sendAddButton.onClick.AddListener(Send);
    }

    private void OnDisable()
    {
        _sendAddButton.onClick.RemoveListener(Send);
    }

    private void Send()
    {
        GameEvents.SendAd(_config);
    }
}