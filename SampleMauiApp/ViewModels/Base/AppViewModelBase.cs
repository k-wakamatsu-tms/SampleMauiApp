using CommunityToolkit.Mvvm.Input;
using Maui.Apps.Framework.MVVM;

namespace SampleMauiApp.ViewModels.Base;

/// <summary>
/// アプリケーションのViewModelの基底クラス
/// </summary>
public partial class AppViewModelBase : ViewModelBase
{
    public INavigation NavigationService { get; set; }
    public Page PageService { get; set; }

    protected IApiService _appApiService { get; set; }

    public AppViewModelBase(IApiService appApiService) : base()
    {
        _appApiService = appApiService;
    }

    /// <summary>
    /// 戻る
    /// </summary>
    /// <returns></returns>
    [RelayCommand]
    private async Task NavigateBack() =>
        await NavigationService.PopAsync();

    /// <summary>
    /// モーダルを閉じる
    /// </summary>
    /// <returns></returns>
    [RelayCommand]
    private async Task CloseModal() =>
        await NavigationService.PopModalAsync();
}
