namespace UnoGroupBox;


public sealed partial class GroupBox : ContentControl
{
    public object Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(nameof(Header), typeof(object), typeof(GroupBox), new PropertyMetadata(null));

    public DataTemplate HeaderTemplate
    {
        get => (DataTemplate) GetValue(HeaderTemplateProperty);
        set => SetValue(HeaderTemplateProperty, value);
    }

    public static readonly DependencyProperty HeaderTemplateProperty =
        DependencyProperty.Register(nameof(HeaderTemplate), typeof(DataTemplate), typeof(GroupBox), new PropertyMetadata(null));

    public GroupBoxTheme Theme
    {
        get => (GroupBoxTheme) GetValue(ThemeProperty);
        set => SetValue(ThemeProperty, value);
    }

    public static readonly DependencyProperty ThemeProperty =
     DependencyProperty.Register(nameof(Theme), typeof(GroupBoxTheme?), typeof(GroupBox),
         new PropertyMetadata(null, OnThemeChanged));

    public GroupBox()
    {
        DefaultStyleKey = typeof(GroupBox);
    }

    private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is GroupBox gb)
        {
            string state = (GroupBoxTheme) e.NewValue == GroupBoxTheme.Material ? "Material" : "Fluent";

            gb.Loaded += (s, _) => VisualStateManager.GoToState(gb, state, true);
            VisualStateManager.GoToState(gb, state, true);
        }
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        ApplyTheme();
    }

    void ApplyTheme()
    {
        VisualStateManager.GoToState(this, Theme == GroupBoxTheme.Material ? "Material" : "Fluent", true);
    }
}
