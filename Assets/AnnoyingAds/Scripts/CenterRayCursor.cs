using UnityEngine;
using UnityEngine.UI;

public class CenterRayClick : MonoBehaviour
{
    // Ссылка на основную камеру, через которую будем проводить raycast.
    // Назначьте её в инспекторе.
    public Camera _mainCamera;

    // Максимальная дистанция луча
    public float _maxDistance = 100f;
    [SerializeField] private Image _cursorImage;

    [SerializeField] private Sprite _defaultCursor;
    [SerializeField] private Sprite _hoverCursor;
    
    
    void Update()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        // Преобразуем точку центра экрана в луч, исходящий из камеры
        Ray ray = _mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        // Проводим raycast с заданной максимальной дистанцией
        if (Physics.Raycast(ray, out hit, _maxDistance))
        {
            // Проверяем, есть ли на столкнувшемся объекте компонент Button
            Button btn = hit.collider.GetComponent<Button>();
            Debug.Log(btn);
            if (btn != null)
            {
                _cursorImage.sprite = _hoverCursor;
            }
            else
            {
                _cursorImage.sprite = _defaultCursor;

            }
        }
        else
        {
            _cursorImage.sprite = _defaultCursor;

        }
    }
}