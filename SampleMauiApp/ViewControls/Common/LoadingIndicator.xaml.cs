namespace SampleMauiApp.ViewControls.Common;
public partial class LoadingIndicator : VerticalStackLayout
{
    // �o�C���h�\�ȃv���p�e�B���`

    /// <summary>
    /// IsBusy�̃o�C���h�\�ȃv���p�e�B
    /// </summary>
    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
        "IsBusy", // �v���p�e�B��
        typeof(bool), // �f�[�^�^
        typeof(LoadingIndicator), // ���L�҂̌^
        false, // �f�t�H���g�l
        BindingMode.OneWay, // �o�C���f�B���O���[�h
        null,
        SetIsBusy); // �v���p�e�B���ύX���ꂽ�Ƃ��̏���

    /// <summary>
    /// IsBusy�v���p�e�B�̃Q�b�^�[�ƃZ�b�^�[
    /// </summary>
    public bool IsBusy
    {
        get => (bool)this.GetValue(IsBusyProperty);
        set => this.SetValue(IsBusyProperty, value);
    }
    /// <summary>
    /// IsBusy�v���p�e�B���ύX���ꂽ�Ƃ��̏���
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
    /// LoadingText�̃o�C���h�\�ȃv���p�e�B
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