using TMPro;
using UnityEngine;

namespace Homeworks.PresentationModel.Scripts.Views
{
    public sealed class CharacterExperienceView : MonoBehaviour
    {
        [SerializeField] private RectTransform _progressIndicator;
        [SerializeField] private TextMeshProUGUI _progressText;
        [SerializeField] private TextMeshProUGUI _levelText;

        public void SetProgressIndicator(float progress)
        {
            _progressIndicator.localScale = new Vector2(progress, 1f);
        }

        public void SetProgressText(string text)
        {
            _progressText.text = text;
        }

        public void SetLevel(string text)
        {
            _levelText.text = text;
        }

    }
    
}