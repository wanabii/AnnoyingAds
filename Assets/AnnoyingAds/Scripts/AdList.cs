using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class AdList : MonoBehaviour
{
    [SerializeField] private AdCards Config;
    [SerializeField] private Card[] _cards;
    private List<AdCard> _cardsArray;
    private List<AdCard> adCard;

    private void Start()
    {
        var a = Random3cards();
        for(int g = 0; g<3; g++)
        {
            _cards[g].DrawCard(a[g]);
        }
    }

    private void CopyAdCards()
    {
        adCard = new List<AdCard>(Config.adCards);
    }


    List<AdCard> Random3cards()
    {
        CopyAdCards();
        _cardsArray = new List<AdCard>();
        for (int i = 0; i < 3; i++)
        {
            var ind = Random.Range(0, adCard.Count);
            _cardsArray.Add(adCard[ind]);
            adCard.Remove(adCard[ind]);
        }

        return _cardsArray;
    }
    
    
    
}