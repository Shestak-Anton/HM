using System;
using Homeworks.PresentationModel.Scripts.Views;
using Lessons.Architecture.PM;
using VContainer;
using VContainer.Unity;

namespace Homeworks.PresentationModel.Scripts.CharacterDialog.Experience
{
    public sealed class CharacterExperiencePresenter : IStartable, IDisposable
    {
        private readonly CharacterExperienceView _characterExperienceView;
        private readonly PlayerLevel _playerLevel;

        [Inject]
        public CharacterExperiencePresenter(CharacterExperienceView characterExperienceView, PlayerLevel playerLevel)
        {
            _characterExperienceView = characterExperienceView;
            _playerLevel = playerLevel;
            
            OnExperienceChanged(0);
        }

        public void Start()
        {
            _playerLevel.OnLevelUp += OnLevelUp;
            _playerLevel.OnExperienceChanged += OnExperienceChanged;
        }

        public void Dispose()
        {
            _playerLevel.OnLevelUp -= OnLevelUp;
            _playerLevel.OnExperienceChanged -= OnExperienceChanged;
        }

        private void OnLevelUp()
        {
            var levelStr = $"Level: {_playerLevel.CurrentLevel}";
            _characterExperienceView.SetLevel(levelStr);
            OnExperienceChanged(0);
        }

        private void OnExperienceChanged(int experience)
        {
            var experienceStr = $"{experience}/{_playerLevel.RequiredExperience}";
            _characterExperienceView.SetProgressText(experienceStr);

            var progress = MathF.Max(0.01f, experience / (float)_playerLevel.RequiredExperience);
            _characterExperienceView.SetProgressIndicator(progress);
        }
    }
}