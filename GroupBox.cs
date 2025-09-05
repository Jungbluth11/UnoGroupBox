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
        get => (DataTemplate)GetValue(HeaderTemplateProperty);
        set => SetValue(HeaderTemplateProperty, value);
    }

    public static readonly DependencyProperty HeaderTemplateProperty =
        DependencyProperty.Register(nameof(HeaderTemplate), typeof(DataTemplate), typeof(GroupBox), new PropertyMetadata(null));

    public GroupBox()
    {
        DefaultStyleKey = typeof(GroupBox);
    }

}
