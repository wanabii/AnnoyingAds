using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // Чувствительность мыши
    public float _sensitivity = 2f;
    // Максимальный угол для вертикального поворота
    public float _maxVerticalAngle = 80f;
    public float _maxHorizontalAngle = 80f;

    // Вспомогательная переменная для накопления вертикального поворота
    private float _verticalRotation = 0f;
    private float _horizontalRotation = 0f;

    void Start()
    {
        // Блокируем курсор и скрываем его
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Update()
    {
        Cursor.visible = true;

        // Получаем движение мыши по осям X и Y
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity;
        
        // Поворот камеры вокруг вертикальной оси (ось Y)
        _horizontalRotation += mouseX;
        _horizontalRotation = Mathf.Clamp(_horizontalRotation, -_maxHorizontalAngle, _maxHorizontalAngle);
        

        // Накопление вертикального поворота и его ограничение
        _verticalRotation -= mouseY;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -_maxVerticalAngle, _maxVerticalAngle);
        
        // Применяем ограниченный вертикальный поворот
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.y = _horizontalRotation;
        currentRotation.x = _verticalRotation;
        
        currentRotation.z = 0;
        
        transform.localEulerAngles = currentRotation;
    }
}

