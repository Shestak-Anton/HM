using Homeworks.PresentationModel.Scripts.CharacterDialog.Experience;
using Homeworks.PresentationModel.Scripts.CharacterDialog.Stat;
using Homeworks.PresentationModel.Scripts.Views;
using Lessons.Architecture.PM;
using Lessons.Architecture.PM.Presenters;
using Lessons.Architecture.PM.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

namespace Homeworks.PresentationModel.Scripts.DI
{
    public sealed class DialogLifetimeScope : LifetimeScope
    {
        [SerializeField] private UserInfo _userInfo;
        [SerializeField] private PlayerLevel _playerLevel;
        [SerializeField] private CharacterInfo _characterInfo;

        [SerializeField] private StatView _statViewPrefab;
        [SerializeField] private Transform _statContainer;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<UserInfoView>();
            builder.RegisterEntryPoint<UserInfoPresenter>();
            builder.RegisterInstance(_userInfo);

            builder.RegisterComponentInHierarchy<CharacterExperienceView>();
            builder.RegisterEntryPoint<CharacterExperiencePresenter>();
            builder.RegisterInstance(_playerLevel);

            builder.RegisterEntryPoint<CharacterStatsListPresenter>();
            builder.RegisterInstance(_characterInfo);
            
            builder.RegisterFactory<CharacterStat, StatPresenter>(container =>
            {
                return (stat) =>
                {
                    var view = container.Instantiate(_statViewPrefab, _statContainer);
                    return new StatPresenter(stat, view);
                };
            }, Lifetime.Scoped);
        }
    }
}