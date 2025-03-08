using UnityEngine;
using UnityEngine.UI;

public class CenterRayClick : MonoBehaviour
{
    // Ссылка на основную камеру, через которую будем проводить raycast.
    // Назначьте её в инспекторе.
    public Camera mainCamera;

    // Максимальная дистанция луча
    public float maxDistance = 100f;
    [SerializeField] private Image cursorImage;

    [SerializeField] private Sprite DefaultCursor;
    [SerializeField] private Sprite HoverCursor;
    
    
    void Update()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        // Преобразуем точку центра экрана в луч, исходящий из камеры
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        // Проводим raycast с заданной максимальной дистанцией
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Проверяем, есть ли на столкнувшемся объекте компонент Button
            Button btn = hit.collider.GetComponent<Button>();
            Debug.Log(btn);
            if (btn != null)
            {
                cursorImage.sprite = HoverCursor;
            }
            else
            {
                cursorImage.sprite = DefaultCursor;

            }
        }
        else
        {
            cursorImage.sprite = DefaultCursor;

        }
    }
}