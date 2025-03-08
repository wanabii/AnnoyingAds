using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Чувствительность мыши
    public float sensitivity = 2f;
    // Максимальный угол для вертикального поворота
    public float maxVerticalAngle = 80f;
    public float maxHorizontalAngle = 80f;

    // Вспомогательная переменная для накопления вертикального поворота
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    void Start()
    {
        // Блокируем курсор и скрываем его
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Получаем движение мыши по осям X и Y
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        
        // Поворот камеры вокруг вертикальной оси (ось Y)
        horizontalRotation += mouseX;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -maxHorizontalAngle, maxHorizontalAngle);
        

        // Накопление вертикального поворота и его ограничение
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalAngle, maxVerticalAngle);
        
        // Применяем ограниченный вертикальный поворот
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.y = horizontalRotation;
        currentRotation.x = verticalRotation;
        
        currentRotation.z = 0;
        
        transform.localEulerAngles = currentRotation;
    }
}

