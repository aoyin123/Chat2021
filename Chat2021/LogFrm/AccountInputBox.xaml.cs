using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chat2021.LogFrm
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        string str = "123";
        List<string> stringList = new List<string>() { "", "", "" };
        public UserControl1()
        {
            InitializeComponent();
            SetSelectionAllOnGotFocus(pwdTextBox);
            //pwdTextBox.SetBinding(TextBox.TextProperty, new Binding("/") { Source = stringList });
            //userNameTextBox.SetBinding(TextBox.TextProperty, new Binding("/Length") { Source = stringList, Mode = BindingMode.OneWay });
            //textBox.SetBinding(TextBox.TextProperty, new Binding("/[2]") { Source = stringList, Mode = BindingMode.OneWay });
        }

        private void QQIconMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DownIconMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void LockIconMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void KeyBoardIconMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void userNameLine_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void userNameTextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void userNameTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            userNameTextBox.Clear();

        }
        public void SetSelectionAllOnGotFocus(TextBox textbox)
        {
            MouseButtonEventHandler _OnPreviewMouseDown = (sender, e) =>
            {
                TextBox box = e.Source as TextBox;
                box.Focus();
                e.Handled = true;
            };
            RoutedEventHandler _OnLostFocus = (sender, e) =>
            {
                TextBox box = e.Source as TextBox;
                box.PreviewMouseDown += _OnPreviewMouseDown;
            };
            RoutedEventHandler _OnGotFocus = (sender, e) =>
            {
                TextBox box = e.Source as TextBox;
                box.SelectAll();
                box.PreviewMouseDown -= _OnPreviewMouseDown;
            };

            textbox.PreviewMouseDown += _OnPreviewMouseDown;
            textbox.LostFocus += _OnLostFocus;
            textbox.GotFocus += _OnGotFocus;
        }

    }

    /// <summary>
    /// 当 TextBoxBase获得焦点的时候，自动全部选择文字。附加属性为SelectAllWhenGotFocus，类型为bool.
    /// </summary>
    public class TextBoxAutoSelectHelper
    {
        public static readonly DependencyProperty SelectAllWhenGotFocusProperty = DependencyProperty.RegisterAttached("SelectAllWhenGotFocus",
                            typeof(bool), typeof(TextBoxAutoSelectHelper),
                            new FrameworkPropertyMetadata((bool)false, new PropertyChangedCallback(OnSelectAllWhenGotFocusChanged)));

        public static bool GetSelectAllWhenGotFocus(TextBoxBase d)
        {
            return (bool)d.GetValue(SelectAllWhenGotFocusProperty);
        }
        public static void SetSelectAllWhenGotFocus(TextBoxBase d, bool value)
        {
            d.SetValue(SelectAllWhenGotFocusProperty, value);
        }

        private static void OnSelectAllWhenGotFocusChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
        {
            if (dependency is TextBoxBase tBox)
            {
                var isSelectedAllWhenGotFocus = (bool)e.NewValue;
                if (isSelectedAllWhenGotFocus)
                {
                    tBox.PreviewMouseDown += TextBoxPreviewMouseDown;
                    tBox.GotFocus += TextBoxOnGotFocus;
                    tBox.LostFocus += TextBoxOnLostFocus;
                }
                else
                {
                    tBox.PreviewMouseDown -= TextBoxPreviewMouseDown;
                    tBox.GotFocus -= TextBoxOnGotFocus;
                    tBox.LostFocus -= TextBoxOnLostFocus;
                }
            }
        }
        private static void TextBoxOnGotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBoxBase tBox)
            {
                tBox.SelectAll();
                tBox.PreviewMouseDown -= TextBoxPreviewMouseDown;
            }

        }
        private static void TextBoxPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBoxBase tBox)
            {
                tBox.Focus();
                e.Handled = true;
            }
        }

        private static void TextBoxOnLostFocus(object sender, RoutedEventArgs e)
        {

            if (sender is TextBoxBase tBox)
            {
                tBox.PreviewMouseDown += TextBoxPreviewMouseDown;
            }

        }
    }
}
