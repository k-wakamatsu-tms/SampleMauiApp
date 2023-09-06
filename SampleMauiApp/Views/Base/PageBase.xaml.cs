using Maui.Apps.Framework.UI;

namespace SampleMauiApp.Views.Base;

public partial class PageBase : ContentPage
{
    public IList<Microsoft.Maui.IView> PageContent => PageContentGrid.Children;
    public IList<Microsoft.Maui.IView> PageIcons => PageIconsGrid.Children;

    protected bool IsBackButtonEnabled
    {
        set => NavigateBackButton.IsEnabled = value;
    }
    public string PageTitle
    {
        get => (string)GetValue(PageTitleProperty);
        set => SetValue(PageTitleProperty, value);
    }

    #region Bindable properties
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
               nameof(PageTitle),
                      typeof(string),
                             typeof(PageBase),
                                    string.Empty,
                                           defaultBindingMode: BindingMode.OneWay,
                                                  propertyChanged: OnPageTitleChanged);

    private static void OnPageTitleChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable != null && bindable is PageBase basePage)
        {
            basePage.TitleLabel.Text = (string)newValue;
            basePage.TitleLabel.IsVisible = true;
        }
    }
    #endregion
    public PageBase()
    {
        InitializeComponent();

        NavigationPage.SetHasNavigationBar(this, false);

        SetPageMode(PageMode.None);

        SetContentDisplayMode(ContentDisplayMode.NoNavigationBar);
    }
}