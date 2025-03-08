using System;

namespace AnnoyingAds.Scripts
{
    public class GameEvents
    {
        public static event Action<AdCard> OnSendAd;
        public static event Action OnDayEnd;

        public static event Action OnNextPerson;
        
        public static void SendAd(AdCard adCard)
        {
            OnSendAd?.Invoke(adCard);
        }

        public static void DayEnd()
        {
            OnDayEnd?.Invoke();
        }

        public static void NextPerson()
        {
            OnNextPerson?.Invoke();
        }
    }
}