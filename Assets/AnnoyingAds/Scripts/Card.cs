using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;
    private AdCard config;

    public void DrawCard(AdCard adCard)
    {
        _image.sprite = adCard.image;
        _text.text = adCard.text;
        config = adCard;
    }
}