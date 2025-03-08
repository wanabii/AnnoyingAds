using System.Collections;
using System.Dynamic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _ageValue;
    [SerializeField] private TextMeshProUGUI _parametrs;
    
    [Header("Type Setting")]
    [SerializeField] private TextMeshProUGUI _frase;
    [SerializeField] private Button _typeButton;
    [SerializeField] private float _typeSpeed = 0.05f;
    
    private Person _config;

    public void DrawPerson(Person config)
    {
        _config = config;
        _image.sprite = config.image;
        _name.text = config.name;
        _ageValue.text = config.age.ToString();
        _parametrs.text = config.parametrs;
        _frase.text = "";
    }
    
    private void OnEnable()
    {
        if(_typeButton != null)
            _typeButton.onClick.AddListener(OnTypeButtonClicked);
    }

    private void OnDisable()
    {
        if(_typeButton != null)
            _typeButton.onClick.RemoveListener(OnTypeButtonClicked);
    }

    private void OnTypeButtonClicked()
    {
        Debug.Log("Click");
        StartCoroutine(TypeText(_config.text));
    }

    private IEnumerator TypeText(string fullText)
    {
        _frase.text = "";
        foreach (char letter in fullText)
        {
            _frase.text += letter;
            // Подождать 0.05 секунд (можно настроить скорость)
            yield return new WaitForSeconds(_typeSpeed);
        }
    }
}
