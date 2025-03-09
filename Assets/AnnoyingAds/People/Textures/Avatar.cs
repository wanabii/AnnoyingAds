using UnityEngine;
using System.IO;

public class AvatarCapture : MonoBehaviour
{
    public Camera avatarCamera;
    public RenderTexture renderTexture;

    [ContextMenu("Capture Avatar")]
    public void CaptureAvatar()
    {
        if (avatarCamera == null || renderTexture == null)
        {
            Debug.LogError("❌ Камера или RenderTexture не установлены!");
            return;
        }

        // Устанавливаем RenderTexture как активный
        RenderTexture activeRT = RenderTexture.active;
        RenderTexture.active = renderTexture;

        // Создаем Texture2D из RenderTexture
        Texture2D avatarTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);
        avatarTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        avatarTexture.Apply();

        // Создаем папку Screenshots, если её нет
        string folderPath = "Assets/Screenshots";
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Генерируем имя файла
        string filePath = $"{folderPath}/avatar_{System.DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";

        // Сохраняем текстуру в PNG
        File.WriteAllBytes(filePath, avatarTexture.EncodeToPNG());

        // Освобождаем ресурсы
        RenderTexture.active = activeRT;
        DestroyImmediate(avatarTexture);

        Debug.Log($"✅ Аватар сохранен: {filePath}");

        // Обновляем ассеты в редакторе
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}