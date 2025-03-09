using UnityEngine;

public class RemoveStartmenu : MonoBehaviour
{

    [SerializeField] private Canvas _bigScreen;
    [SerializeField] private Canvas _smallScreen;
    [SerializeField] private Canvas _bigScreenOFF;
    [SerializeField] private Canvas _smallScreenOFF;


    public void StartGame()
    {
        _smallScreen.gameObject.SetActive(true);
        _bigScreen.gameObject.SetActive(true);
    
        _bigScreenOFF.gameObject.SetActive(false);
        _smallScreenOFF.gameObject.SetActive(false);
    }
    
    
    
    
}
