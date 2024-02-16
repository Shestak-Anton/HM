using System;
using Lessons.Architecture.PM;
using Lessons.Architecture.PM.Views;
using VContainer.Unity;

namespace Homeworks.PresentationModel.Scripts.CharacterDialog.Stat
{
    public sealed class StatPresenter : IStartable, IDisposable
    {
        private readonly CharacterStat _characterStat;
        private readonly StatView _statView;

        public StatPresenter(CharacterStat characterStat, StatView statView)
        {
            _characterStat = characterStat;
            _statView = statView;
            
            _statView.SetStat(characterStat.MatToViewText());
        }

        public void Start()
        {
            _characterStat.OnValueChangedStr += _statView.SetStat;
        }

        public void Dispose()
        {
            _characterStat.OnValueChangedStr -= _statView.SetStat;
            _statView.DestroyStatView();
        }

        public bool AreStatEqual(CharacterStat characterStat)
        {
            return _characterStat == characterStat;
        }
    }
}