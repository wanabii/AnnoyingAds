using System;
using UnityEngine;

namespace AnnoyingAds.Scripts
{
    public class PersonSwitcher : MonoBehaviour
    {
        [SerializeField] private PersonList _personList;
        [SerializeField] private PersonView _personView;
        
        private int _currentIndex = 0;
        private void Start()
        {
            if (_personList != null && _personList.list != null && _personList.list.Count > 0)
            {
                _personView.DrawPerson(_personList.list[_currentIndex]);
            }
            else
            {
                Debug.LogWarning("Список персонажей пуст или не задан!");
            }
        }
        
        private void OnEnable()
        {
            GameEvents.OnSendAd += OnSendAdHandler;
        }

        private void OnDisable()
        {
            GameEvents.OnSendAd -= OnSendAdHandler;
        }

        private void OnSendAdHandler(AdCard adCard)
        {
            _currentIndex++;
            if (_currentIndex < _personList.list.Count)
            {
                _personView.DrawPerson(_personList.list[_currentIndex]);
            }
            else
            {
                GameEvents.DayEnd();
                Debug.Log("День завершен. Персонажи закончились.");
            }
        }
    }
}