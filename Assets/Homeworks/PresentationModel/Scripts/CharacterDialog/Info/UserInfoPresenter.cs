using System;
using VContainer;
using VContainer.Unity;

namespace Lessons.Architecture.PM
{
    public sealed class UserInfoPresenter : IStartable, IDisposable
    {
        private readonly UserInfo _userInfo;
        private readonly UserInfoView _userInfoView;

        [Inject]
        public UserInfoPresenter(UserInfo userInfo, UserInfoView userInfoView)
        {
            _userInfo = userInfo;
            _userInfoView = userInfoView;
        }

        public void Start()
        {
            _userInfo.OnDescriptionChanged += _userInfoView.SetDescription;
            _userInfo.OnIconChanged += _userInfoView.SetIcon;
            _userInfo.OnNameChanged += _userInfoView.SetName;
        }

        public void Dispose()
        {
            _userInfo.OnDescriptionChanged -= _userInfoView.SetDescription;
            _userInfo.OnIconChanged -= _userInfoView.SetIcon;
            _userInfo.OnNameChanged -= _userInfoView.SetName;
        }
    }
}