namespace SampleMauiApp.ViewControls.Common;
public partial class LoadingIndicator : VerticalStackLayout
{
    // バインド可能なプロパティを定義

    /// <summary>
    /// IsBusyのバインド可能なプロパティ
    /// </summary>
    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
        "IsBusy", // プロパティ名
        typeof(bool), // データ型
        typeof(LoadingIndicator), // 所有者の型
        false, // デフォルト値
        BindingMode.OneWay, // バインディングモード
        null,
        SetIsBusy); // プロパティが変更されたときの処理

    /// <summary>
    /// IsBusyプロパティのゲッターとセッター
    /// </summary>
    public bool IsBusy
    {
        get => (bool)this.GetValue(IsBusyProperty);
        set => this.SetValue(IsBusyProperty, value);
    }
    /// <summary>
    /// IsBusyプロパティが変更されたときの処理
    /// </summary>
    /// <param name="bindable"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    private static void SetIsBusy(BindableObject bindable, object oldValue, object newValue)
    {
        LoadingIndicator control = bindable as LoadingIndicator;

        control.IsVisible = (bool)newValue;
        control.actIndicator.IsRunning = (bool)newValue;
    }

    /// <summary>
    /// LoadingTextのバインド可能なプロパティ
    /// </summary>
    public static readonly BindableProperty LoadingTextProperty = BindableProperty.Create(
        "LoadingText",
        typeof(string),
        typeof(LoadingIndicator),
        string.Empty,
        BindingMode.OneWay,
        null,
        SetLoadingText);

    public string LoadingText
    {
        get => (string)this.GetValue(LoadingTextProperty);
        set => this.SetValue(LoadingTextProperty, value);
    }
    private static void SetLoadingText(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as LoadingIndicator).lblLoadingText.Text = (string)newValue;
    }

    public LoadingIndicator()
    {
        InitializeComponent();
    }
}