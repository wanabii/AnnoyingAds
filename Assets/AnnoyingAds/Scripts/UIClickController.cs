using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIClickController : MonoBehaviour
{
    // Ссылка на компонент GraphicRaycaster на вашем Canvas
    public GraphicRaycaster graphicRaycaster;
    // Ссылка на EventSystem
    public EventSystem eventSystem;
    
    // Центр экрана, где будет имитироваться указатель
    private Vector2 centerScreen;

    void Start()
    {
        // Если используете заблокированный курсор
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        centerScreen = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    void Update()
    {
        // Обработка нажатия левой кнопки мыши
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Создаем объект данных для события указателя с позицией в центре экрана
            PointerEventData pointerData = new PointerEventData(eventSystem);
            pointerData.position = centerScreen;

            // Raycast по UI-элементам
            List<RaycastResult> results = new List<RaycastResult>();
            graphicRaycaster.Raycast(pointerData, results);

            // Если найден хотя бы один UI-элемент
            if (results.Count > 0)
            {
                // Здесь можно обработать первый найденный элемент или перебрать все
                foreach (RaycastResult result in results)
                {
                    // Вызываем событие клика
                    ExecuteEvents.Execute(result.gameObject, pointerData, ExecuteEvents.pointerClickHandler);
                    Debug.Log("UI Element clicked: " + result.gameObject.name);
                }
            }
        }
    }
}

