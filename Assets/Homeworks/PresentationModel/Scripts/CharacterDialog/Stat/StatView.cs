using TMPro;
using UnityEngine;

namespace Lessons.Architecture.PM.Views
{
    public sealed class StatView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _statTextView;

        public void SetStat(string stat)
        {
            _statTextView.text = stat;
        }

        public void DestroyStatView()
        {
            Destroy(gameObject);
        }
    }
}