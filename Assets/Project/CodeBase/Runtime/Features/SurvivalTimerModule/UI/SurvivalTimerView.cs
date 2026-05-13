using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Features.SurvivalTimerModule.UI
{
    public class SurvivalTimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        private ISurvivalTimer _survivalTimer;

        [Inject]
        private void Construct(ISurvivalTimer survivalTimer) =>
            _survivalTimer = survivalTimer;

        private void OnEnable() =>
            _survivalTimer.Changed += UpdateTimerText;

        private void OnDisable() =>
            _survivalTimer.Changed -= UpdateTimerText;

        private void UpdateTimerText(float currentTime)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);
            _timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }
}