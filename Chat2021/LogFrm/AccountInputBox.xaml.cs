using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class UserControl1 : System.Windows.Controls.UserControl
    {

        private string str = "123";
        private List<string> stringList = new List<string>() { "", "", "" };
        private Color color = Color.FromRgb(0x0a,0xC0,0xFF);
        private System.Windows.Media.SolidColorBrush rr = new System.Windows.Media.SolidColorBrush(Colors.Blue);
        private SolidColorBrush red;
        //private bool IsMemPwd = true;   
        //private bool IsAutoLog = true;
        CIsMenPwd cIsMenPwd = new CIsMenPwd() { IsMemPwd = true };
        CAutoLogin cAutoLogin = new CAutoLogin() { IsAutoLogin = true };
        TestData testData = new TestData() { Numbers = false };
        

        Color colors = Colors.Black;
        public UserControl1()
        {
            InitializeComponent();
            SetSelectionAllOnGotFocus(userNameTextBox);
            red = new SolidColorBrush(color);
            autoLogCheckBox.DataContext = testData;
            memPwdCheckBox.DataContext = testData;
            pwdTbx.DataContext = testData;
            //this.Background = red;

            //pwdTextBox.SetBinding(TextBox.TextProperty, new Binding("/") { Source = stringList });
            //userNameTextBox.SetBinding(TextBox.TextProperty, new Binding("/Length") { Source = stringList, Mode = Bindi         .OneWay });            
            //textBox.SetBinding(TextBox.TextProperty, new Binding("/[2]") { Source = stringList, Mode = BindingMode.OneWay });         
            //logBtn.SetBinding(logBtn.Background, new Binding() {Path = .,ElementName
            System.Windows.Data.Binding binding = new System.Windows.Data.Binding();//创建Binding实例
            binding.Source = red;//指定数据源
            binding.Path = new PropertyPath(".");//指定访问路径 })
            logBtn.SetBinding(System.Windows.Controls.Button.BackgroundProperty, binding);
            logBtn.SetBinding(System.Windows.Controls.Button.BorderBrushProperty, binding);

            //Binding bind2 = new Binding();
            //bind2.Source = IsMemPwd;
            //bind2.Path = new PropertyPath(".");
            //memPwdCheckBox.SetBinding(CheckBox.IsCheckedProperty, bind2);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
            //Binding bind3 = new Binding();
            //bind3.Source = IsAutoLog;
            //bind3.Path = new PropertyPath(".");
            //autoLogCheckBox.SetBinding(CheckBox.IsCheckedProperty, bind3);

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


        }
        public void SetSelectionAllOnGotFocus(System.Windows.Controls.TextBox textbox)
        {
            MouseButtonEventHandler _OnPreviewMouseDown = (sender, e) =>
            {
                System.Windows.Controls.TextBox box = e.Source as System.Windows.Controls.TextBox;
                box.Focus();
                e.Handled = true;
            };
            RoutedEventHandler _OnLostFocus = (sender, e) =>
            {
                System.Windows.Controls.TextBox box = e.Source as System.Windows.Controls.TextBox;
                box.PreviewMouseDown += _OnPreviewMouseDown;
            };
            RoutedEventHandler _OnGotFocus = (sender, e) =>
            {
                System.Windows.Controls.TextBox box = e.Source as System.Windows.Controls.TextBox;
                box.SelectAll();
                box.PreviewMouseDown -= _OnPreviewMouseDown;
            };

            textbox.PreviewMouseDown += _OnPreviewMouseDown;
            textbox.LostFocus += _OnLostFocus;
            textbox.GotFocus += _OnGotFocus;
        }

        private void VisualBrush_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            VisualBrush visualBrush = (VisualBrush)sender;
            
        }

        private void pwdTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            userNameTextBox.Background = Brushes.White;
            
        }

        
        private void memPwdCheckBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        
        private void autoLogCheckBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        public static explicit operator System.Windows.Forms.Control(UserControl1 v)
        {
            throw new NotImplementedException();
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

        public static bool GetSelectAllWhenGotFocus(System.Windows.Controls.Primitives.TextBoxBase d)
        {
            return (bool)d.GetValue(SelectAllWhenGotFocusProperty);
        }
        public static void SetSelectAllWhenGotFocus(System.Windows.Controls.Primitives.TextBoxBase d, bool value)
        {
            d.SetValue(SelectAllWhenGotFocusProperty, value);
        }

        private static void OnSelectAllWhenGotFocusChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
        {
            if (dependency is System.Windows.Controls.Primitives.TextBoxBase tBox)
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
            if (sender is System.Windows.Controls.Primitives.TextBoxBase tBox)
            {
                tBox.SelectAll();
                tBox.PreviewMouseDown -= TextBoxPreviewMouseDown;
            }

        }
        private static void TextBoxPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is System.Windows.Controls.Primitives.TextBoxBase tBox)
            {
                tBox.Focus();
                e.Handled = true;
            }
        }

        private static void TextBoxOnLostFocus(object sender, RoutedEventArgs e)
        {

            if (sender is System.Windows.Controls.Primitives.TextBoxBase tBox)
            {
                tBox.PreviewMouseDown += TextBoxPreviewMouseDown;
            }

        }
    }

    public class CIsMenPwd : INotifyPropertyChanged
    {
        private bool _IsMemPwd;
        public bool IsMemPwd
        {
            get
            {
                return _IsMemPwd;
            }
            set
            {
                _IsMemPwd = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsMemPwd"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class CAutoLogin : INotifyPropertyChanged
    {
        private bool _IsAutoLogin;
        public bool IsAutoLogin
        {
            get
            {
                return _IsAutoLogin;
            }
            set
            {
                _IsAutoLogin = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsAutoLogin"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class TestData : INotifyPropertyChanged
    {
        private bool _Number;
        public bool Numbers
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Numbers"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class test1 : INotifyPropertyChanged
    {
        private bool _test;
        public bool Test
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Numbers"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}