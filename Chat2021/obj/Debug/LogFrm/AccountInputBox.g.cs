﻿#pragma checksum "..\..\..\LogFrm\AccountInputBox.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3796D170D0F830E5DAC11078B4868DCE505D2428DBB425C7FA827C1F0CC51FB7"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Chat2021.LogFrm;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Chat2021.LogFrm {
    
    
    /// <summary>
    /// UserControl1
    /// </summary>
    public partial class UserControl1 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 69 "..\..\..\LogFrm\AccountInputBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image chatPic;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\LogFrm\AccountInputBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image arrayPic;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\LogFrm\AccountInputBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image lockIcon;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\LogFrm\AccountInputBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image keyboardIcon;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\LogFrm\AccountInputBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\LogFrm\AccountInputBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pwdTbx;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\LogFrm\AccountInputBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox autoLogCheckBox;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\..\LogFrm\AccountInputBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox memPwdCheckBox;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\LogFrm\AccountInputBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label findPwdLabel;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\LogFrm\AccountInputBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Chat2021;component/logfrm/accountinputbox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\LogFrm\AccountInputBox.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.chatPic = ((System.Windows.Controls.Image)(target));
            
            #line 69 "..\..\..\LogFrm\AccountInputBox.xaml"
            this.chatPic.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.QQIconMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.arrayPic = ((System.Windows.Controls.Image)(target));
            
            #line 70 "..\..\..\LogFrm\AccountInputBox.xaml"
            this.arrayPic.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.DownIconMouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lockIcon = ((System.Windows.Controls.Image)(target));
            
            #line 71 "..\..\..\LogFrm\AccountInputBox.xaml"
            this.lockIcon.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.LockIconMouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.keyboardIcon = ((System.Windows.Controls.Image)(target));
            
            #line 72 "..\..\..\LogFrm\AccountInputBox.xaml"
            this.keyboardIcon.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.KeyBoardIconMouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.userNameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 73 "..\..\..\LogFrm\AccountInputBox.xaml"
            this.userNameTextBox.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.userNameTextBox_MouseDown);
            
            #line default
            #line hidden
            
            #line 73 "..\..\..\LogFrm\AccountInputBox.xaml"
            this.userNameTextBox.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.userNameTextBox_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.pwdTbx = ((System.Windows.Controls.TextBox)(target));
            
            #line 95 "..\..\..\LogFrm\AccountInputBox.xaml"
            this.pwdTbx.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.userNameTextBox_MouseDown);
            
            #line default
            #line hidden
            
            #line 95 "..\..\..\LogFrm\AccountInputBox.xaml"
            this.pwdTbx.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.userNameTextBox_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.autoLogCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 153 "..\..\..\LogFrm\AccountInputBox.xaml"
            this.autoLogCheckBox.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.autoLogCheckBox_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.memPwdCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 154 "..\..\..\LogFrm\AccountInputBox.xaml"
            this.memPwdCheckBox.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.memPwdCheckBox_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.findPwdLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.logBtn = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

