using System;
using AnnoyingAds.Scripts;
using UnityEngine;

public class AdCardEvaluator : MonoBehaviour
{
    [SerializeField] private PersonSwitcher _personSwitcher;
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private AudioSource _audioLose;
    [SerializeField] private AudioSource _audioWin;
    
    private void OnEnable()
    {
        GameEvents.OnSendAd += OnSendAdd;
    }

    private void OnDisable()
    {
        GameEvents.OnSendAd -= OnSendAdd;
    }

    private void OnSendAdd(AdCard adCard)
    {
        int pointsChange = 0;

        foreach (string positiveTag in adCard._positiveTags)
        {
            if (Array.Exists(_personSwitcher.CurrentPerson._tags, tag => tag.Equals(positiveTag)))
            {
                pointsChange += 10;
                _audioWin.Play();
                Debug.Log("Найден положительный тег: " + positiveTag + " => +10 очков");
            }
        }

        foreach (string negativeTag in adCard._negativeTags)
        {
            if (Array.Exists(_personSwitcher.CurrentPerson._tags, tag => tag.Equals(negativeTag)))
            {
                pointsChange -= 10;
                _audioLose.Play();
                Debug.Log("Найден отрицательный тег: " + negativeTag + " => -10 очков");
            }
        }

        int newScore = _scoreView.CurrentScore + pointsChange;
        _scoreView.UpdateScore(newScore);
        GameEvents.NextPerson();
        Debug.Log("Обработана рекламная карточка. Изменение очков: " + pointsChange + ", Текущий счёт: " + _scoreView.CurrentScore);
    }
}