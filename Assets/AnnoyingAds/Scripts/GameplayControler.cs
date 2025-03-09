using AnnoyingAds.Scripts;
using UnityEngine;

public class GameplayControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject _endScreen;

    
    void OnEnable()
    {
          GameEvents.OnDayEnd += GameEnd;
    }

    // Update is called once per frame
    void OnDisable()
    {
        GameEvents.OnDayEnd -= GameEnd;
    }
    
    public void GameEnd()
    {
        _endScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
}
