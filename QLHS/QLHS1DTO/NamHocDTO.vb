Public Class NamHocDTO
    Private iMaNamHoc As Integer
    Private strNamHoc As String
    Private iTTNamHoc As Integer
    Public Sub New()
        iMaNamHoc = 0
        strNamHoc = String.Empty
    End Sub
    Public Sub New(iMaNamHoc As Integer, strNamHoc As String, iTTNamHoc As Integer)
        Me.iMaNamHoc = iMaNamHoc
        Me.strNamHoc = strNamHoc
        Me.iTTNamHoc = iTTNamHoc
    End Sub
    Public Property MaNamHoc As Integer
        Get
            Return iMaNamHoc
        End Get
        Set(value As Integer)
            iMaNamHoc = value
        End Set
    End Property

    Public Property NamHoc As String
        Get
            Return strNamHoc
        End Get
        Set(value As String)
            strNamHoc = value
        End Set
    End Property

    Public Property TTNamHoc As Integer
        Get
            Return iTTNamHoc
        End Get
        Set(value As Integer)
            iTTNamHoc = value
        End Set
    End Property
End Class
