using System;
using System.Collections.Generic;
using System.Linq;
using Homeworks.PresentationModel.Scripts.CharacterDialog.Stat;
using VContainer;
using VContainer.Unity;

namespace Lessons.Architecture.PM.Presenters
{
    public sealed class CharacterStatsListPresenter : IStartable, IDisposable
    {
        private readonly CharacterInfo _characterInfo;
        private readonly Func<CharacterStat, StatPresenter> _statFactory;

        private readonly List<StatPresenter> _presenters = new();

        [Inject]
        public CharacterStatsListPresenter(CharacterInfo characterInfo, Func<CharacterStat, StatPresenter> statFactory)
        {
            _characterInfo = characterInfo;
            _statFactory = statFactory;
        }

        public void Start()
        {
            _characterInfo.OnStatAdded += OnStatAdded;
            _characterInfo.OnStatRemoved += OnStatRemoved;
        }

        public void Dispose()
        {
            _characterInfo.OnStatAdded -= OnStatAdded;
            _characterInfo.OnStatRemoved -= OnStatRemoved;
        }

        private void OnStatAdded(CharacterStat characterStat)
        {
            var statPresenter = _statFactory.Invoke(characterStat);
            _presenters.Add(statPresenter);
        }

        private void OnStatRemoved(CharacterStat characterStat)
        {
            foreach (var statPresenter in _presenters.Where(statPresenter => statPresenter.AreStatEqual(characterStat)))
            {
                statPresenter.Dispose();
            }

            _presenters.RemoveAll(presenter => presenter.AreStatEqual(characterStat));
        }
    }
}