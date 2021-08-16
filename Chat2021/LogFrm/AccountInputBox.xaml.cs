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
using Chat2021.Mysql;

namespace Chat2021.LogFrm
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : System.Windows.Controls.UserControl
    {

        private List<string> stringList = new List<string>() { "", "", "" };
        private Color color = Color.FromRgb(0x0a,0xC0,0xFF);
        private System.Windows.Media.SolidColorBrush rr = new System.Windows.Media.SolidColorBrush(Colors.Blue);
        private SolidColorBrush red;
        //private bool IsMemPwd = true;   
        //private bool IsAutoLog = true;
        //CIsMenPwd cIsMenPwd = new CIsMenPwd() { IsMemPwd = true };
        //CAutoLogin cAutoLogin = new CAutoLogin() { IsAutoLogin = true };
        IsRememberPwdData testData = new IsRememberPwdData() { Remember = false };
        WidthData widthData = new WidthData() { Width = "hello", H = 200.0 };
        CheckBoxData checkBoxData = new CheckBoxData() { AutoLog = false , Remember = false};
        KeyboardFrm keyboardFrm;

        double underLineWidth = 0;

        KeyboardFrm KeyboardFrm;
        Color colors = Colors.Black;
        public UserControl1()
        {
            InitializeComponent();


            SetSelectionAllOnGotFocus(userNameTextBox);
            red = new SolidColorBrush(color);
            autoLogCheckBox.DataContext = checkBoxData;
            memPwdCheckBox.DataContext = checkBoxData;
            pwdTbx.DataContext = testData;
            //line1.DataContext = widthData;
            //line1.Width = 200;
            
            //pp.Width = this.ActualWidth;
            //pp.X2 = this.ActualWidth;
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

            Binding bind = new Binding();
            bind.Source = widthData;
            bind.Path = new PropertyPath("_Width");

            //Binding bind2 = new Binding();
            //bind2.Source = IsMemPwd;
            //bind2.Path = new PropertyPath(".");
            //memPwdCheckBox.SetBinding(CheckBox.IsCheckedProperty, bind2);

            //Binding bind3 = new Binding();
            //bind3.Source = IsAutoLog;
            //bind3.Path = new PropertyPath(".");
            //autoLogCheckBox.SetBinding(CheckBox.IsCheckedProperty, bind3);

            
        }

        
        
        
        private void KeyBoardIconMouseDown(object sender, MouseButtonEventArgs e)
        {
            KeyboardFrm = new KeyboardFrm(pwdTbx);
            KeyboardFrm.Show();
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
  
        public static explicit operator System.Windows.Forms.Control(UserControl1 v)
        {
            throw new NotImplementedException();
        }

        private void InputBox_Loaded(object sender, RoutedEventArgs e)
        {
            underLineWidth = this.ActualWidth;
            BindingOperations.SetBinding(pwdUnderLine, Line.X2Property, new Binding { Source = underLineWidth, Path = new PropertyPath(".")});
            BindingOperations.SetBinding(pwdUnderLine, Line.WidthProperty, new Binding { Source = underLineWidth, Path = new PropertyPath(".") });
            BindingOperations.SetBinding(userNameUnderLine, Line.X2Property, new Binding { Source = underLineWidth, Path = new PropertyPath(".") });
            BindingOperations.SetBinding(userNameUnderLine, Line.WidthProperty, new Binding { Source = underLineWidth, Path = new PropertyPath(".") });
            BindingOperations.SetBinding(logBtn, Button.WidthProperty, new Binding { Source = underLineWidth, Path = new PropertyPath(".") });
            keyboardFrm = new KeyboardFrm(this.userNameTextBox);
            keyboardFrm.Location = new System.Drawing.Point(720, 590);
        }

        private void logBtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string userName = userNameTextBox.Text;
            string pwd = pwdTbx.Text;
            MysqlOperation.Query(userName, pwd);
        }

        private void keyboardIcon_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(false == keyboardFrm.Visible)
            {
                keyboardFrm.Show();
            }
            else
            {
                keyboardFrm.Hide();
            }
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

    //public class CIsMenPwd : INotifyPropertyChanged
    //{
    //    private bool _IsMemPwd;
    //    public bool IsMemPwd
    //    {
    //        get
    //        {
    //            return _IsMemPwd;
    //        }
    //        set
    //        {
    //            _IsMemPwd = value;
    //            if (this.PropertyChanged != null)
    //            {
    //                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsMemPwd"));
    //            }
    //        }
    //    }
    //    public event PropertyChangedEventHandler PropertyChanged;
    //}

    //public class CAutoLogin : INotifyPropertyChanged
    //{
    //    private bool _IsAutoLogin;
    //    public bool IsAutoLogin
    //    {
    //        get
    //        {
    //            return _IsAutoLogin;
    //        }
    //        set
    //        {
    //            _IsAutoLogin = value;
    //            if (this.PropertyChanged != null)
    //            {
    //                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsAutoLogin"));
    //            }
    //        }
    //    }
    //    public event PropertyChangedEventHandler PropertyChanged;
    //}

    public class IsRememberPwdData : INotifyPropertyChanged
    {
        private bool remember;
        public bool Remember
        {
            get
            {
                return remember;
            }
            set
            {
                remember = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Remember"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class CheckBoxData : INotifyPropertyChanged
    {
        private bool autoLog;
        public bool AutoLog
        {
            get
            {
                return autoLog;
            }
            set
            {
                autoLog = value;
                if(value == true)
                {
                    Remember = true;   
                }

                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("AutoLog"));
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Remember"));
                }
            }
        }

        private bool remember;
        public bool Remember
        {
            get
            {
                return remember;
            }
            set
            {
                remember = value;
                if(value == false)
                {
                    AutoLog = false;
                }
                if(this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Remember"));
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("AutoLog"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class WidthData : INotifyPropertyChanged
    {
        private string width;
        private double h;

        public double H
        {
            get
            {
                return h;
            }
            set
            {
                h = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("H"));
                }
            }
        }

        public string Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Width"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    

}