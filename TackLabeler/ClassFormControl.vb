''' <summary>
''' フォーム内容が変更されたかどうか確認クラス
''' </summary>
''' <remarks></remarks>
Public Class ClassFormControl
    Public Event EditStatusChanged(ByVal Edited As Boolean)
    Dim _TargetFrm As Windows.Forms.Form = Nothing
    Dim _Flg As Boolean = False
    Dim _Title As String = ""
    ''' <summary>
    ''' 描写ターゲットフォーム
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    WriteOnly Property TargetForm() As Windows.Forms.Form
        Set(ByVal value As Windows.Forms.Form)
            _TargetFrm = value
            _Title = _TargetFrm.Text
            For Each Item As Control In GetAllControls(_TargetFrm)
                Select Case True
                    Case TypeOf (Item) Is NumericUpDown '数字入力
                        Dim Obj As NumericUpDown = DirectCast(Item, NumericUpDown)
                        AddHandler Obj.ValueChanged, AddressOf ValueChanged
                    Case TypeOf (Item) Is TextBox 'テキストボックス
                        Dim Obj As TextBox = DirectCast(Item, TextBox)
                        AddHandler Obj.TextChanged, AddressOf ValueChanged
                    Case TypeOf (Item) Is ComboBox 'コンボボックス
                        Dim Obj As ComboBox = DirectCast(Item, ComboBox)
                        AddHandler Obj.SelectedIndexChanged, AddressOf ValueChanged
                    Case TypeOf (Item) Is CheckBox 'チェックボックス
                        Dim Obj As CheckBox = DirectCast(Item, CheckBox)
                        AddHandler Obj.CheckedChanged, AddressOf ValueChanged
                End Select
            Next
        End Set
    End Property
    Private Sub ValueChanged(sender As Object, e As EventArgs)
        _Flg = True
        Call DrawAster()
    End Sub
    Public Function GetAllControls(ByVal top As Control) As Control()
        Dim buf As ArrayList = New ArrayList
        For Each c As Control In top.Controls
            buf.Add(c)
            buf.AddRange(GetAllControls(c))
        Next
        Return CType(buf.ToArray(GetType(Control)), Control())
    End Function
    ' ''' <summary>
    ' ''' 表示タイトル
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Property Title() As String
    '    Get
    '        Return _Title
    '    End Get
    '    Set(ByVal value As String)
    '        _Title = value
    '        Call DrawAster()
    '    End Set
    'End Property
    ''' <summary>
    ''' 変更スイッチ
    ''' </summary>
    ''' <value>TRUE:変更された</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Edited() As Boolean
        Get
            Return _Flg
        End Get
        Set(ByVal value As Boolean)
            _Flg = value
            RaiseEvent EditStatusChanged(value)
            Call DrawAster()
        End Set
    End Property
    ''' <summary>
    ''' 変更されたかどうか確認メソッド
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsEdited() As Boolean
        Return _Flg
    End Function
    ''' <summary>
    ''' 変更をフォームのタイトルに描写する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DrawAster()
        If _Flg Then
            _TargetFrm.Text = _Title & " (*)"
        Else
            _TargetFrm.Text = _Title
        End If
    End Sub
    Public Sub New()

    End Sub

End Class
