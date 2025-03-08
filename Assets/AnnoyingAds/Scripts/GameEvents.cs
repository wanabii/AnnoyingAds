using System;

namespace AnnoyingAds.Scripts
{
    public class GameEvents
    {
        public static event Action<AdCard> OnSendAd;
        public static event Action OnDayEnd;
        
        public static void SendAd(AdCard adCard)
        {
            OnSendAd?.Invoke(adCard);
        }

        public static void DayEnd()
        {
            OnDayEnd?.Invoke();
        }
    }
}