using System;
using UnityEngine;

namespace AnnoyingAds.Scripts
{
    public class PersonSwitcher : MonoBehaviour
    {
        [SerializeField] private PersonList _personList;
        [SerializeField] private PersonView _personView;

        private int _currentIndex = 0;
        public Person CurrentPerson => _personList._list[_currentIndex];

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
            if (_personList != null && _personList._list != null && _personList._list.Count > 0)
            {
                _personView.DrawPerson(CurrentPerson);
            }
            else
            {
                Debug.LogWarning("Список персонажей пуст или не задан!");
            }
        }
        


        private void HandleNextPerson()
        {
            _currentIndex++;
            if (_currentIndex < _personList._list.Count)
            {
                _personView.DrawPerson(CurrentPerson);
            }
            else
            {
                GameEvents.DayEnd();
                Debug.Log("День завершен. Персонажи закончились.");
            }
        }
    }
}