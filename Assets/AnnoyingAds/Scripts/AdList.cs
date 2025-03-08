using System;
using System.Collections.Generic;
using AnnoyingAds.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class AdList : MonoBehaviour
{
    [SerializeField] private AdCards _config;
    [SerializeField] private AdCardView[] _cards;
    private List<AdCard> _adCard;

    private void OnValidate()
    {
        if (_cards.Length <= 0)
        {
            throw new ArgumentException("Need Added Cards config");
        }
    }

    private void OnEnable()
    {
        GameEvents.OnNextPerson += HandleNextPerson;
    }

    private void OnDisable()
    {
        GameEvents.OnNextPerson -= HandleNextPerson;
    }
    private void Start()
    {
        Reroll();
      
    }

    private void HandleNextPerson()
    {
        Reroll();
    }

    public void Reroll()
    {
        var a = Random3Cards();
        for(int g = 0; g<3; g++)
        {
            _cards[g].DrawCard(a[g]);
        }
    }

 

    private void CopyAdCards()
    {
        _adCard = new List<AdCard>(_config._adCards);
    }


    List<AdCard> Random3Cards()
    {
        CopyAdCards();
        var cardsArray = new List<AdCard>();
        for (int i = 0; i < 3; i++)
        {
            var ind = Random.Range(0, _adCard.Count);
            cardsArray.Add(_adCard[ind]);
            _adCard.Remove(_adCard[ind]);
        }

        return cardsArray;
    }
    
    
    
}