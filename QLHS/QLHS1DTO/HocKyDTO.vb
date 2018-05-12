Public Class HocKyDTO
    Private iMaHocKy As Integer
    Private strHocKy As String
    Private iMaNamHoc As Integer
    Private iTTHocKy As Integer
    Public Sub New()
        iMaHocKy = 0
        strHocKy = String.Empty
    End Sub
    Public Sub New(iMaHocKy As Integer, strHocKy As String, iTTHocKy As Integer, iMaNamHoc As Integer)
        Me.iMaHocKy = iMaHocKy
        Me.strHocKy = strHocKy
        Me.iTTHocKy = iTTHocKy
        Me.iMaNamHoc = iMaNamHoc
    End Sub
    Public Property MaHocKy As Integer
        Get
            Return iMaHocKy
        End Get
        Set(value As Integer)
            iMaHocKy = value
        End Set
    End Property

    Public Property HocKy As String
        Get
            Return strHocKy
        End Get
        Set(value As String)
            strHocKy = value
        End Set
    End Property
    Public Property MaNamHoc As Integer
        Get
            Return iMaNamHoc
        End Get
        Set(value As Integer)
            iMaNamHoc = value
        End Set
    End Property

    Public Property TTHocKy As Integer
        Get
            Return iTTHocKy
        End Get
        Set(value As Integer)
            iTTHocKy = value
        End Set
    End Property
End Class
