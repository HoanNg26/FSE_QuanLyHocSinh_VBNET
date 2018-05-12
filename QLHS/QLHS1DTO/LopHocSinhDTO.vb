Public Class LopHocSinhDTO
    Private iMaLop As Integer
    Private strMSHS As String
    'Private iMaHocKy As Integer

    Public Sub New()
        iMaLop = 0
        strMSHS = String.Empty
    End Sub
    Public Sub New(iMaLop As Integer, strMSHS As String)
        Me.iMaLop = iMaLop
        Me.strMSHS = strMSHS
        'Me.iMaHocKy = iMaHocKy
    End Sub
    'Public Sub New(iMaLop As Integer, strMSHS As String, iMaHocKy As Integer)
    '    Me.iMaLop = iMaLop
    '    Me.strMSHS = strMSHS
    '    Me.iMaHocKy = iMaHocKy
    'End Sub
    Public Property MaLop As Integer
        Get
            Return iMaLop
        End Get
        Set(value As Integer)
            iMaLop = value
        End Set
    End Property

    Public Property MSHS As String
        Get
            Return strMSHS
        End Get
        Set(value As String)
            strMSHS = value
        End Set
    End Property

    'Public Property MaHocKy As Integer
    '    Get
    '        Return iMaHocKy
    '    End Get
    '    Set(value As Integer)
    '        iMaHocKy = value
    '    End Set
    'End Property
End Class
