
Imports System.ComponentModel
Imports System.Runtime.Remoting
Imports System.Windows.Forms.Layout

Public Class Form1
    Private Sub Form1_Load(e As EventArgs, sender As Object) Handles MyBase.Load

    End Sub

    Public Const PROCESS_VM_READ = &H10
    Public Const TH32CS_SNAPPROCESS = &H2
    Public Const MEM_COMMIT = 4096
    Public Const PAGE_READWRITE = 4
    Public Const PROCESS_CREATE_THREAD = (&H2)
    Public Const PROCESS_VM_OPERATION = (&H8)
    Public Const PROCESS_VM_WRITE = (&H20)
    Dim DLLFileName As String
    Public Declare Function ReadProcessMemory Lib "kernel32" (
ByVal hProcess As Integer,
ByVal lpBaseAddress As Integer,
ByVal lpBuffer As String,
ByVal nSize As Integer,
ByRef lpNumberOfBytesWritten As Integer) As Integer

    Public Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (
ByVal lpLibFileName As String) As Integer

    Public Declare Function VirtualAllocEx Lib "kernel32" (
ByVal hProcess As Integer,
ByVal lpAddress As Integer,
ByVal dwSize As Integer,
ByVal flAllocationType As Integer,
ByVal flProtect As Integer) As Integer

    Public Declare Function WriteProcessMemory Lib "kernel32" (
ByVal hProcess As Integer,
ByVal lpBaseAddress As Integer,
ByVal lpBuffer As String,
ByVal nSize As Integer,
ByRef lpNumberOfBytesWritten As Integer) As Integer

    Public Declare Function GetProcAddress Lib "kernel32" (
ByVal hModule As Integer, ByVal lpProcName As String) As Integer

    Private Declare Function GetModuleHandle Lib "Kernel32" Alias "GetModuleHandleA" (
ByVal lpModuleName As String) As Integer

    Public Declare Function CreateRemoteThread Lib "kernel32" (
ByVal hProcess As Integer,
ByVal lpThreadAttributes As Integer,
ByVal dwStackSize As Integer,
ByVal lpStartAddress As Integer,
ByVal lpParameter As Integer,
ByVal dwCreationFlags As Integer,
ByRef lpThreadId As Integer) As Integer

    Public Declare Function OpenProcess Lib "kernel32" (
ByVal dwDesiredAccess As Integer,
ByVal bInheritHandle As Integer,
ByVal dwProcessId As Integer) As Integer

    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (
ByVal lpClassName As String,
ByVal lpWindowName As String) As Integer

    Private Declare Function CloseHandle Lib "kernel32" Alias "CloseHandleA" (
ByVal hObject As Integer) As Integer


    Dim ExeName As String = IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath)
    Private _Timer1 As Object

    Public Function GetTimer11() As Object
        Return _Timer1
    End Function

    Public Sub SetTimer11(AutoPropertyValue As Object)
        _Timer1 = AutoPropertyValue
    End Sub

    Public Sub New(components As IContainer, button1 As Button, button2 As Button, button3 As Button, button4 As Button, dLLs As ListBox, label1 As Label, textBox1 As TextBox, radioButton1 As RadioButton, radioButton2 As RadioButton, checkBox1 As CheckBox, button5 As Button, dLLFileName As String, exeName As String, Timer1 As Object, openFileDialog1 As Object)
        Me.components = components
        Me.Button1 = button1
        Me.Button2 = button2
        Me.Button3 = button3
        Me.Button4 = button4
        Me.DLLs = dLLs
        Me.Label1 = label1
        Me.TextBox1 = textBox1
        Me.RadioButton1 = radioButton1
        Me.RadioButton2 = radioButton2
        Me.CheckBox1 = checkBox1
        Me.Button5 = button5
        Me.DLLFileName = dLLFileName
        Me.ExeName = exeName
        _Timer1 = Timer1
        Me.OpenFileDialog1 = openFileDialog1
    End Sub

    Public Property OpenFileDialog1 As Object

    Public Overrides Property AllowDrop As Boolean
        Get
            Return MyBase.AllowDrop
        End Get
        Set(value As Boolean)
            MyBase.AllowDrop = value
        End Set
    End Property

    Public Overrides Property Anchor As AnchorStyles
        Get
            Return MyBase.Anchor
        End Get
        Set(value As AnchorStyles)
            MyBase.Anchor = value
        End Set
    End Property

    Public Overrides Property AutoScrollOffset As Point
        Get
            Return MyBase.AutoScrollOffset
        End Get
        Set(value As Point)
            MyBase.AutoScrollOffset = value
        End Set
    End Property

    Public Overrides ReadOnly Property LayoutEngine As LayoutEngine
        Get
            Return MyBase.LayoutEngine
        End Get
    End Property

    Public Overrides Property BackgroundImage As Image
        Get
            Return MyBase.BackgroundImage
        End Get
        Set(value As Image)
            MyBase.BackgroundImage = value
        End Set
    End Property

    Public Overrides Property BackgroundImageLayout As ImageLayout
        Get
            Return MyBase.BackgroundImageLayout
        End Get
        Set(value As ImageLayout)
            MyBase.BackgroundImageLayout = value
        End Set
    End Property

    Protected Overrides ReadOnly Property CanRaiseEvents As Boolean
        Get
            Return MyBase.CanRaiseEvents
        End Get
    End Property

    Public Overrides Property ContextMenu As ContextMenu
        Get
            Return MyBase.ContextMenu
        End Get
        Set(value As ContextMenu)
            MyBase.ContextMenu = value
        End Set
    End Property

    Public Overrides Property ContextMenuStrip As ContextMenuStrip
        Get
            Return MyBase.ContextMenuStrip
        End Get
        Set(value As ContextMenuStrip)
            MyBase.ContextMenuStrip = value
        End Set
    End Property

    Public Overrides Property Cursor As Cursor
        Get
            Return MyBase.Cursor
        End Get
        Set(value As Cursor)
            MyBase.Cursor = value
        End Set
    End Property

    Protected Overrides ReadOnly Property DefaultCursor As Cursor
        Get
            Return MyBase.DefaultCursor
        End Get
    End Property

    Protected Overrides ReadOnly Property DefaultMargin As Padding
        Get
            Return MyBase.DefaultMargin
        End Get
    End Property

    Protected Overrides ReadOnly Property DefaultMaximumSize As Size
        Get
            Return MyBase.DefaultMaximumSize
        End Get
    End Property

    Protected Overrides ReadOnly Property DefaultMinimumSize As Size
        Get
            Return MyBase.DefaultMinimumSize
        End Get
    End Property

    Protected Overrides ReadOnly Property DefaultPadding As Padding
        Get
            Return MyBase.DefaultPadding
        End Get
    End Property

    Public Overrides Property Dock As DockStyle
        Get
            Return MyBase.Dock
        End Get
        Set(value As DockStyle)
            MyBase.Dock = value
        End Set
    End Property

    Protected Overrides Property DoubleBuffered As Boolean
        Get
            Return MyBase.DoubleBuffered
        End Get
        Set(value As Boolean)
            MyBase.DoubleBuffered = value
        End Set
    End Property

    Public Overrides ReadOnly Property Focused As Boolean
        Get
            Return MyBase.Focused
        End Get
    End Property

    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(value As Font)
            MyBase.Font = value
        End Set
    End Property

    Public Overrides Property ForeColor As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(value As Color)
            MyBase.ForeColor = value
        End Set
    End Property

    Public Overrides Property RightToLeft As RightToLeft
        Get
            Return MyBase.RightToLeft
        End Get
        Set(value As RightToLeft)
            MyBase.RightToLeft = value
        End Set
    End Property

    Protected Overrides ReadOnly Property ScaleChildren As Boolean
        Get
            Return MyBase.ScaleChildren
        End Get
    End Property

    Public Overrides Property Site As ISite
        Get
            Return MyBase.Site
        End Get
        Set(value As ISite)
            MyBase.Site = value
        End Set
    End Property

    Protected Overrides ReadOnly Property ShowKeyboardCues As Boolean
        Get
            Return MyBase.ShowKeyboardCues
        End Get
    End Property

    Protected Overrides ReadOnly Property ShowFocusCues As Boolean
        Get
            Return MyBase.ShowFocusCues
        End Get
    End Property

    Protected Overrides Property ImeModeBase As ImeMode
        Get
            Return MyBase.ImeModeBase
        End Get
        Set(value As ImeMode)
            MyBase.ImeModeBase = value
        End Set
    End Property

    Public Overrides ReadOnly Property DisplayRectangle As Rectangle
        Get
            Return MyBase.DisplayRectangle
        End Get
    End Property

    Public Overrides Property BindingContext As BindingContext
        Get
            Return MyBase.BindingContext
        End Get
        Set(value As BindingContext)
            MyBase.BindingContext = value
        End Set
    End Property

    Protected Overrides ReadOnly Property CanEnableIme As Boolean
        Get
            Return MyBase.CanEnableIme
        End Get
    End Property

    Public Overrides Property AutoScaleBaseSize As Size
        Get
            Return MyBase.AutoScaleBaseSize
        End Get
        Set(value As Size)
            MyBase.AutoScaleBaseSize = value
        End Set
    End Property

    Public Overrides Property AutoScroll As Boolean
        Get
            Return MyBase.AutoScroll
        End Get
        Set(value As Boolean)
            MyBase.AutoScroll = value
        End Set
    End Property

    Public Overrides Property AutoSize As Boolean
        Get
            Return MyBase.AutoSize
        End Get
        Set(value As Boolean)
            MyBase.AutoSize = value
        End Set
    End Property

    Public Overrides Property AutoValidate As AutoValidate
        Get
            Return MyBase.AutoValidate
        End Get
        Set(value As AutoValidate)
            MyBase.AutoValidate = value
        End Set
    End Property

    Public Overrides Property BackColor As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(value As Color)
            MyBase.BackColor = value
        End Set
    End Property

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Return MyBase.CreateParams
        End Get
    End Property

    Protected Overrides ReadOnly Property DefaultImeMode As ImeMode
        Get
            Return MyBase.DefaultImeMode
        End Get
    End Property

    Protected Overrides ReadOnly Property DefaultSize As Size
        Get
            Return MyBase.DefaultSize
        End Get
    End Property

    Public Overrides Property MaximumSize As Size
        Get
            Return MyBase.MaximumSize
        End Get
        Set(value As Size)
            MyBase.MaximumSize = value
        End Set
    End Property

    Public Overrides Property MinimumSize As Size
        Get
            Return MyBase.MinimumSize
        End Get
        Set(value As Size)
            MyBase.MinimumSize = value
        End Set
    End Property

    Public Overrides Property RightToLeftLayout As Boolean
        Get
            Return MyBase.RightToLeftLayout
        End Get
        Set(value As Boolean)
            MyBase.RightToLeftLayout = value
        End Set
    End Property

    Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
        Get
            Return MyBase.ShowWithoutActivation
        End Get
    End Property

    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            MyBase.Text = value
        End Set
    End Property

    Private Sub Inject()
        On Error GoTo 1 ' If error occurs, app will close without any error messages
        GetTimer11().Stop()
        Dim TargetProcess As Process() = NewMethod()


        Dim Rtn As Integer
        Dim LoadLibParamAdr As Integer
        LoadLibParamAdr = VirtualAllocEx(TargetProcessHandle, 0, dwSize:=TargetBufferSize, flAllocationType:=MEM_COMMIT, flProtect:=PAGE_READWRITE)
        Rtn = WriteProcessMemory(TargetProcessHandle, LoadLibParamAdr, pszLibFileRemote, TargetBufferSize, 0)
        CreateRemoteThread(TargetProcessHandle, 0, 0, pfnStartAddr, LoadLibParamAdr, 0, 0)
        CloseHandle(TargetProcessHandle)
1:      Me.Show()
    End Sub



    Private Function NewMethod() As Process()
        Return Process.GetProcessesByName(TextBox1.Text)
    End Function

    Private Function TargetBufferSize() As Integer
        Throw New NotImplementedException()
    End Function

    Private Function pszLibFileRemote() As Object
        Throw New NotImplementedException()
    End Function

    Private Function pfnStartAddr() As Integer
        Throw New NotImplementedException()
    End Function

    Private Function TargetProcessHandle() As Integer
        Throw New NotImplementedException()
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DLLs.Name = "DLLs"
        Button1.Text = "Browse"
        Label1.Text = "Waiting for Program to Start.."
        GetTimer11().Interval = 50
        GetTimer11().Start()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "DLL (*.dll) |*.dll"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For i As Integer = (DLLs.SelectedItems.Count - 1) To 0 Step -1
            DLLs.Items.Remove(DLLs.SelectedItems(i))
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DLLs.Items.Clear()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If IO.File.Exists(OpenFileDialog1.FileName) Then
            Dim TargetProcess As Process() = Process.GetProcessesByName(TextBox1.Text)
            If TargetProcess.Length = 0 Then

                Me.Label1.Text = ("Waiting for " + TextBox1.Text + ".exe")
            Else
                GetTimer11().Stop()
                Me.Label1.Text = "Successfully Injected!"
                Call Inject()
                If CheckBox1.Checked = True Then
                    End
                Else
                End If
            End If
        Else
        End If
    End Sub



    Private Sub NewMethod1()
        Me.Label1.Text = ("Waiting for " + TextBox1.Text + ".exe")
    End Sub

    Private Function GetTimer1() As Object
        Return GetTimer11()
    End Function


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Button4.Enabled = True
        GetTimer11().Enabled = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Button4.Enabled = False
        GetTimer11().Enabled = True
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        Return MyBase.Equals(obj)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function

    Public Overrides Function InitializeLifetimeService() As Object
        Return MyBase.InitializeLifetimeService()
    End Function

    Public Overrides Function CreateObjRef(requestedType As Type) As ObjRef
        Return MyBase.CreateObjRef(requestedType)
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Overrides Function GetService(service As Type) As Object
        Return MyBase.GetService(service)
    End Function

    Protected Overrides Function GetAccessibilityObjectById(objectId As Integer) As AccessibleObject
        Return MyBase.GetAccessibilityObjectById(objectId)
    End Function

    Public Overrides Function GetPreferredSize(proposedSize As Size) As Size
        Return MyBase.GetPreferredSize(proposedSize)
    End Function

    Protected Overrides Function CreateAccessibilityInstance() As AccessibleObject
        Return MyBase.CreateAccessibilityInstance()
    End Function

    Protected Overrides Sub DestroyHandle()
        MyBase.DestroyHandle()
    End Sub

    Protected Overrides Sub InitLayout()
        MyBase.InitLayout()
    End Sub

    Protected Overrides Function IsInputChar(charCode As Char) As Boolean
        Return MyBase.IsInputChar(charCode)
    End Function

    Protected Overrides Function IsInputKey(keyData As Keys) As Boolean
        Return MyBase.IsInputKey(keyData)
    End Function

    Protected Overrides Sub NotifyInvalidate(invalidatedArea As Rectangle)
        MyBase.NotifyInvalidate(invalidatedArea)
    End Sub

    Protected Overrides Sub OnAutoSizeChanged(e As EventArgs)
        MyBase.OnAutoSizeChanged(e)
    End Sub

    Protected Overrides Sub OnBackColorChanged(e As EventArgs)
        MyBase.OnBackColorChanged(e)
    End Sub

    Protected Overrides Sub OnBindingContextChanged(e As EventArgs)
        MyBase.OnBindingContextChanged(e)
    End Sub

    Protected Overrides Sub OnCausesValidationChanged(e As EventArgs)
        MyBase.OnCausesValidationChanged(e)
    End Sub

    Protected Overrides Sub OnContextMenuChanged(e As EventArgs)
        MyBase.OnContextMenuChanged(e)
    End Sub

    Protected Overrides Sub OnContextMenuStripChanged(e As EventArgs)
        MyBase.OnContextMenuStripChanged(e)
    End Sub

    Protected Overrides Sub OnCursorChanged(e As EventArgs)
        MyBase.OnCursorChanged(e)
    End Sub

    Protected Overrides Sub OnDockChanged(e As EventArgs)
        MyBase.OnDockChanged(e)
    End Sub

    Protected Overrides Sub OnForeColorChanged(e As EventArgs)
        MyBase.OnForeColorChanged(e)
    End Sub

    Protected Overrides Sub OnNotifyMessage(m As Message)
        MyBase.OnNotifyMessage(m)
    End Sub

    Protected Overrides Sub OnParentBackColorChanged(e As EventArgs)
        MyBase.OnParentBackColorChanged(e)
    End Sub

    Protected Overrides Sub OnParentBackgroundImageChanged(e As EventArgs)
        MyBase.OnParentBackgroundImageChanged(e)
    End Sub

    Protected Overrides Sub OnParentBindingContextChanged(e As EventArgs)
        MyBase.OnParentBindingContextChanged(e)
    End Sub

    Protected Overrides Sub OnParentCursorChanged(e As EventArgs)
        MyBase.OnParentCursorChanged(e)
    End Sub

    Protected Overrides Sub OnParentEnabledChanged(e As EventArgs)
        MyBase.OnParentEnabledChanged(e)
    End Sub

    Protected Overrides Sub OnParentFontChanged(e As EventArgs)
        MyBase.OnParentFontChanged(e)
    End Sub

    Protected Overrides Sub OnParentForeColorChanged(e As EventArgs)
        MyBase.OnParentForeColorChanged(e)
    End Sub

    Protected Overrides Sub OnParentRightToLeftChanged(e As EventArgs)
        MyBase.OnParentRightToLeftChanged(e)
    End Sub

    Protected Overrides Sub OnParentVisibleChanged(e As EventArgs)
        MyBase.OnParentVisibleChanged(e)
    End Sub

    Protected Overrides Sub OnPrint(e As PaintEventArgs)
        MyBase.OnPrint(e)
    End Sub

    Protected Overrides Sub OnTabIndexChanged(e As EventArgs)
        MyBase.OnTabIndexChanged(e)
    End Sub

    Protected Overrides Sub OnTabStopChanged(e As EventArgs)
        MyBase.OnTabStopChanged(e)
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
    End Sub

    Protected Overrides Sub OnClientSizeChanged(e As EventArgs)
        MyBase.OnClientSizeChanged(e)
    End Sub

    Protected Overrides Sub OnControlAdded(e As ControlEventArgs)
        MyBase.OnControlAdded(e)
    End Sub

    Protected Overrides Sub OnControlRemoved(e As ControlEventArgs)
        MyBase.OnControlRemoved(e)
    End Sub

    Protected Overrides Sub OnLocationChanged(e As EventArgs)
        MyBase.OnLocationChanged(e)
    End Sub

    Protected Overrides Sub OnDoubleClick(e As EventArgs)
        MyBase.OnDoubleClick(e)
    End Sub

    Protected Overrides Sub OnDragEnter(drgevent As DragEventArgs)
        MyBase.OnDragEnter(drgevent)
    End Sub

    Protected Overrides Sub OnDragOver(drgevent As DragEventArgs)
        MyBase.OnDragOver(drgevent)
    End Sub

    Protected Overrides Sub OnDragLeave(e As EventArgs)
        MyBase.OnDragLeave(e)
    End Sub

    Protected Overrides Sub OnDragDrop(drgevent As DragEventArgs)
        MyBase.OnDragDrop(drgevent)
    End Sub

    Protected Overrides Sub OnGiveFeedback(gfbevent As GiveFeedbackEventArgs)
        MyBase.OnGiveFeedback(gfbevent)
    End Sub

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)
    End Sub

    Protected Overrides Sub OnHelpRequested(hevent As HelpEventArgs)
        MyBase.OnHelpRequested(hevent)
    End Sub

    Protected Overrides Sub OnInvalidated(e As InvalidateEventArgs)
        MyBase.OnInvalidated(e)
    End Sub

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)
    End Sub

    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)
    End Sub

    Protected Overrides Sub OnKeyUp(e As KeyEventArgs)
        MyBase.OnKeyUp(e)
    End Sub

    Protected Overrides Sub OnLeave(e As EventArgs)
        MyBase.OnLeave(e)
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        MyBase.OnLostFocus(e)
    End Sub

    Protected Overrides Sub OnMarginChanged(e As EventArgs)
        MyBase.OnMarginChanged(e)
    End Sub

    Protected Overrides Sub OnMouseDoubleClick(e As MouseEventArgs)
        MyBase.OnMouseDoubleClick(e)
    End Sub

    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        MyBase.OnMouseClick(e)
    End Sub

    Protected Overrides Sub OnMouseCaptureChanged(e As EventArgs)
        MyBase.OnMouseCaptureChanged(e)
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnMouseHover(e As EventArgs)
        MyBase.OnMouseHover(e)
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnMove(e As EventArgs)
        MyBase.OnMove(e)
    End Sub

    Protected Overrides Sub OnQueryContinueDrag(qcdevent As QueryContinueDragEventArgs)
        MyBase.OnQueryContinueDrag(qcdevent)
    End Sub

    Protected Overrides Sub OnRegionChanged(e As EventArgs)
        MyBase.OnRegionChanged(e)
    End Sub

    Protected Overrides Sub OnPreviewKeyDown(e As PreviewKeyDownEventArgs)
        MyBase.OnPreviewKeyDown(e)
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overrides Sub OnChangeUICues(e As UICuesEventArgs)
        MyBase.OnChangeUICues(e)
    End Sub

    Protected Overrides Sub OnSystemColorsChanged(e As EventArgs)
        MyBase.OnSystemColorsChanged(e)
    End Sub

    Protected Overrides Sub OnValidating(e As CancelEventArgs)
        MyBase.OnValidating(e)
    End Sub

    Protected Overrides Sub OnValidated(e As EventArgs)
        MyBase.OnValidated(e)
    End Sub

    Public Overrides Function PreProcessMessage(ByRef msg As Message) As Boolean
        Return MyBase.PreProcessMessage(msg)
    End Function

    Protected Overrides Function ProcessKeyEventArgs(ByRef m As Message) As Boolean
        Return MyBase.ProcessKeyEventArgs(m)
    End Function

    Protected Overrides Function ProcessKeyMessage(ByRef m As Message) As Boolean
        Return MyBase.ProcessKeyMessage(m)
    End Function

    Public Overrides Sub ResetBackColor()
        MyBase.ResetBackColor()
    End Sub

    Public Overrides Sub ResetCursor()
        MyBase.ResetCursor()
    End Sub

    Public Overrides Sub ResetFont()
        MyBase.ResetFont()
    End Sub

    Public Overrides Sub ResetForeColor()
        MyBase.ResetForeColor()
    End Sub

    Public Overrides Sub ResetRightToLeft()
        MyBase.ResetRightToLeft()
    End Sub

    Public Overrides Sub Refresh()
        MyBase.Refresh()
    End Sub

    Public Overrides Sub ResetText()
        MyBase.ResetText()
    End Sub

    Protected Overrides Function SizeFromClientSize(clientSize As Size) As Size
        Return MyBase.SizeFromClientSize(clientSize)
    End Function

    Protected Overrides Sub OnImeModeChanged(e As EventArgs)
        MyBase.OnImeModeChanged(e)
    End Sub

    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
        MyBase.OnMouseWheel(e)
    End Sub

    Protected Overrides Sub OnRightToLeftChanged(e As EventArgs)
        MyBase.OnRightToLeftChanged(e)
    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        MyBase.OnPaintBackground(e)
    End Sub

    Protected Overrides Sub OnPaddingChanged(e As EventArgs)
        MyBase.OnPaddingChanged(e)
    End Sub

    Protected Overrides Function ScrollToControl(activeControl As Control) As Point
        Return MyBase.ScrollToControl(activeControl)
    End Function

    Protected Overrides Sub OnScroll(se As ScrollEventArgs)
        MyBase.OnScroll(se)
    End Sub

    Protected Overrides Sub OnAutoValidateChanged(e As EventArgs)
        MyBase.OnAutoValidateChanged(e)
    End Sub

    Protected Overrides Sub OnParentChanged(e As EventArgs)
        MyBase.OnParentChanged(e)
    End Sub

    Protected Overrides Sub SetVisibleCore(value As Boolean)
        MyBase.SetVisibleCore(value)
    End Sub

    Protected Overrides Sub AdjustFormScrollbars(displayScrollbars As Boolean)
        MyBase.AdjustFormScrollbars(displayScrollbars)
    End Sub

    Protected Overrides Function CreateControlsInstance() As Control.ControlCollection
        Return MyBase.CreateControlsInstance()
    End Function

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
    End Sub

    Protected Overrides Sub DefWndProc(ByRef m As Message)
        MyBase.DefWndProc(m)
    End Sub

    Protected Overrides Function ProcessMnemonic(charCode As Char) As Boolean
        Return MyBase.ProcessMnemonic(charCode)
    End Function

    Protected Overrides Sub OnActivated(e As EventArgs)
        MyBase.OnActivated(e)
    End Sub

    Protected Overrides Sub OnBackgroundImageChanged(e As EventArgs)
        MyBase.OnBackgroundImageChanged(e)
    End Sub

    Protected Overrides Sub OnBackgroundImageLayoutChanged(e As EventArgs)
        MyBase.OnBackgroundImageLayoutChanged(e)
    End Sub

    Protected Overrides Sub OnClosing(e As CancelEventArgs)
        MyBase.OnClosing(e)
    End Sub

    Protected Overrides Sub OnClosed(e As EventArgs)
        MyBase.OnClosed(e)
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
    End Sub

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        MyBase.OnFormClosed(e)
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
    End Sub

    Protected Overrides Sub OnDeactivate(e As EventArgs)
        MyBase.OnDeactivate(e)
    End Sub

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        MyBase.OnEnabledChanged(e)
    End Sub

    Protected Overrides Sub OnEnter(e As EventArgs)
        MyBase.OnEnter(e)
    End Sub

    Protected Overrides Sub OnFontChanged(e As EventArgs)
        MyBase.OnFontChanged(e)
    End Sub

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)
    End Sub

    Protected Overrides Sub OnHandleDestroyed(e As EventArgs)
        MyBase.OnHandleDestroyed(e)
    End Sub

    Protected Overrides Sub OnHelpButtonClicked(e As CancelEventArgs)
        MyBase.OnHelpButtonClicked(e)
    End Sub

    Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
        MyBase.OnLayout(levent)
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
    End Sub

    Protected Overrides Sub OnMaximizedBoundsChanged(e As EventArgs)
        MyBase.OnMaximizedBoundsChanged(e)
    End Sub

    Protected Overrides Sub OnMaximumSizeChanged(e As EventArgs)
        MyBase.OnMaximumSizeChanged(e)
    End Sub

    Protected Overrides Sub OnMinimumSizeChanged(e As EventArgs)
        MyBase.OnMinimumSizeChanged(e)
    End Sub

    Protected Overrides Sub OnInputLanguageChanged(e As InputLanguageChangedEventArgs)
        MyBase.OnInputLanguageChanged(e)
    End Sub

    Protected Overrides Sub OnInputLanguageChanging(e As InputLanguageChangingEventArgs)
        MyBase.OnInputLanguageChanging(e)
    End Sub

    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)
    End Sub

    Protected Overrides Sub OnMdiChildActivate(e As EventArgs)
        MyBase.OnMdiChildActivate(e)
    End Sub

    Protected Overrides Sub OnMenuStart(e As EventArgs)
        MyBase.OnMenuStart(e)
    End Sub

    Protected Overrides Sub OnMenuComplete(e As EventArgs)
        MyBase.OnMenuComplete(e)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
    End Sub

    Protected Overrides Sub OnRightToLeftLayoutChanged(e As EventArgs)
        MyBase.OnRightToLeftLayoutChanged(e)
    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Protected Overrides Function ProcessDialogChar(charCode As Char) As Boolean
        Return MyBase.ProcessDialogChar(charCode)
    End Function

    Protected Overrides Function ProcessKeyPreview(ByRef m As Message) As Boolean
        Return MyBase.ProcessKeyPreview(m)
    End Function

    Protected Overrides Function ProcessTabKey(forward As Boolean) As Boolean
        Return MyBase.ProcessTabKey(forward)
    End Function

    Protected Overrides Sub [Select](directed As Boolean, forward As Boolean)
        MyBase.Select(directed, forward)
    End Sub

    Protected Overrides Sub ScaleCore(x As Single, y As Single)
        MyBase.ScaleCore(x, y)
    End Sub

    Protected Overrides Function GetScaledBounds(bounds As Rectangle, factor As SizeF, specified As BoundsSpecified) As Rectangle
        Return MyBase.GetScaledBounds(bounds, factor, specified)
    End Function

    Protected Overrides Sub ScaleControl(factor As SizeF, specified As BoundsSpecified)
        MyBase.ScaleControl(factor, specified)
    End Sub

    Protected Overrides Sub SetBoundsCore(x As Integer, y As Integer, width As Integer, height As Integer, specified As BoundsSpecified)
        MyBase.SetBoundsCore(x, y, width, height, specified)
    End Sub

    Protected Overrides Sub SetClientSizeCore(x As Integer, y As Integer)
        MyBase.SetClientSizeCore(x, y)
    End Sub

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Protected Overrides Sub UpdateDefaultButton()
        MyBase.UpdateDefaultButton()
    End Sub

    Protected Overrides Sub OnResizeBegin(e As EventArgs)
        MyBase.OnResizeBegin(e)
    End Sub

    Protected Overrides Sub OnResizeEnd(e As EventArgs)
        MyBase.OnResizeEnd(e)
    End Sub

    Protected Overrides Sub OnStyleChanged(e As EventArgs)
        MyBase.OnStyleChanged(e)
    End Sub

    Public Overrides Function ValidateChildren() As Boolean
        Return MyBase.ValidateChildren()
    End Function

    Public Overrides Function ValidateChildren(validationConstraints As ValidationConstraints) As Boolean
        Return MyBase.ValidateChildren(validationConstraints)
    End Function

    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)
    End Sub
End Class
