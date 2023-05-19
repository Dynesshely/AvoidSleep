using System;
using System.Windows;
using System.Windows.Controls;

namespace AvoidSleep.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        if (!Shell.IsLightTheme())
            ChangeTheme(true);
    }

    private bool state = false;

    private bool isLightTheme = true;

    private void ChangeTheme(bool toDarkTheme = true)
    {
        isLightTheme = !toDarkTheme;

        var uri = new Uri(
            $"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.{(toDarkTheme ? "Dark" : "Light")}.xaml"
        );

        Resources.MergedDictionaries.RemoveAt(0);
        Resources.MergedDictionaries.Insert(
            0,
            new ResourceDictionary()
            {
                Source = uri
            }
        );
    }

    private void Btn_State_Click(object sender, RoutedEventArgs e)
    {
        if (state)
        {
            state = false;

            (sender as Button)!.Content = "启用";

            Shell.RestoreForCurrentThread();
        }
        else
        {
            state = true;

            (sender as Button)!.Content = "关闭";

            Shell.PreventForCurrentThread(true);
        }
    }

    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        => Title = $"AvoidSleep - {Width} x {Height}";

    private void MenuItem_ResetWindowSize_Click(object sender, RoutedEventArgs e)
    {
        var tb1 = new TextBox()
        {
            MinWidth = 50,
            Margin = new Thickness(5, 0, 5, 0),
            Text = Height.ToString()
        };

        var tb2 = new TextBox()
        {
            MinWidth = 50,
            Margin = new Thickness(5, 0, 5, 0),
            Text = Width.ToString()
        };

        var wr = new WrapPanel()
        {
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Bottom,
            Margin = new Thickness(10)
        };

        var wr2 = new WrapPanel()
        {
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(10)
        };

        wr2.Children.Add(tb2);

        wr2.Children.Add(new TextBlock()
        {
            Text = "x",
            Margin = new Thickness(5, 0, 5, 0)
        });

        wr2.Children.Add(tb1);

        var btn_confirm = new Button()
        {
            Content = "确定",
            Margin = new Thickness(5, 0, 5, 0)
        };

        var btn_cancel = new Button()
        {
            Content = "取消",
            Margin = new Thickness(5, 0, 5, 0),
            Style = (Style)FindResource("MaterialDesignOutlinedButton")
        };

        wr.Children.Add(btn_cancel);
        wr.Children.Add(btn_confirm);

        var gr = new Grid();

        gr.Children.Add(wr);
        gr.Children.Add(wr2);

        var tmp_win = new Window()
        {
            Title = "重设窗口大小",
            Icon = Icon,
            Width = 270,
            Height = 140,
            ResizeMode = ResizeMode.NoResize,
            Content = gr,
            Owner = this,
            Top = Top + 50,
            Left = Left + (Width - 270) / 2
        };

        btn_cancel.Click += (x, y) =>
        {
            tmp_win.Close();
        };
        btn_confirm.Click += (x, y) =>
        {
            if (double.TryParse(tb1.Text, out var n_height) &&
                double.TryParse(tb2.Text, out var n_width))
            {
                Width = n_width;
                Height = n_height;
            }
            else
            {
                MessageBox.Show("请检查数据格式", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            tmp_win.Close();
        };

        tmp_win.ShowDialog();
    }

    private void MenuItem_ChangeTheme_Click(object sender, RoutedEventArgs e)
    {
        ChangeTheme(isLightTheme);
    }

    private void Btn_Temp_Click(object sender, RoutedEventArgs e) => Shell.ResetIdle(true);
}
