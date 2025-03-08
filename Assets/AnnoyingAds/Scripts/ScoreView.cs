using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ScoreView : MonoBehaviour
{
    // Ссылка на UI элемент для отображения счета
    [SerializeField] private TextMeshProUGUI _scoreText;
    // Продолжительность анимации изменения счета
    [SerializeField] private float _animationDuration = 0.5f;
    // Стандартный цвет текста (например, белый)
    [SerializeField] private Color _defaultColor = Color.white;

    // Текущий счет
    private int _currentScore = 0;
    public int CurrentScore => _currentScore;
    /// <summary>
    /// Обновляет счет с анимацией изменения числа, масштабирования и изменения цвета.
    /// При увеличении счет анимируется зелёным, при уменьшении – красным.
    /// </summary>
    /// <param name="newScore">Новое значение счета</param>
    public void UpdateScore(int newScore)
    {
        // Определяем, увеличился или уменьшился счет
        bool scoreIncreased = newScore > _currentScore;
        bool scoreDecreased = newScore < _currentScore;

        // Выбираем целевой цвет в зависимости от изменения счета
        Color targetColor = _defaultColor;
        if (scoreIncreased)
        {
            targetColor = Color.green;
        }
        else if (scoreDecreased)
        {
            targetColor = Color.red;
        }

        // Создаем последовательность анимаций
        Sequence sequence = DOTween.Sequence();

        // Мгновенно устанавливаем цвет текста в целевой (красный или зелёный)
        sequence.Insert(0, DOTween.To(() => _scoreText.color, x => _scoreText.color = x, targetColor, 0f));

        // Анимируем числовое значение: перебор значений от текущего до нового
        sequence.Insert(0, DOTween.To(() => _currentScore, x =>
        {
            _currentScore = x;
            _scoreText.text = _currentScore.ToString();
        }, newScore, _animationDuration).SetEase(Ease.OutExpo));

        // Анимация масштабирования: сначала увеличиваем, затем возвращаем к нормальному размеру
        sequence.Insert(0, _scoreText.transform.DOScale(1.2f, _animationDuration / 2).SetEase(Ease.OutExpo));
        sequence.Insert(_animationDuration / 2, _scoreText.transform.DOScale(1f, _animationDuration / 2).SetEase(Ease.OutExpo));

        // После основной анимации плавно возвращаем цвет к стандартному
        sequence.Append(_scoreText.DOColor(_defaultColor, _animationDuration / 2));
    }
}
