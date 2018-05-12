Public Class LopDTO
    Private iMaLop As Integer
    Private strTenLop As String
    Private iMaKhoi As Integer
    Private iMaHocKy As Integer

    Public Sub New()
        iMaLop = 0
        strTenLop = String.Empty
        iMaKhoi = 0
        iMaHocKy = 0
    End Sub
    Public Sub New(iMaLop As Integer, strTenLop As String, iMaKhoi As Integer, iMaHocKy As Integer)
        Me.iMaLop = iMaLop
        Me.strTenLop = strTenLop
        Me.iMaKhoi = iMaKhoi
        Me.iMaHocKy = iMaHocKy
    End Sub
    Public Property MaLop As Integer
        Get
            Return iMaLop
        End Get
        Set(value As Integer)
            iMaLop = value
        End Set
    End Property

    Public Property TenLop As String
        Get
            Return strTenLop
        End Get
        Set(value As String)
            strTenLop = value
        End Set
    End Property
    Public Property MaKhoi As Integer
        Get
            Return iMaKhoi
        End Get
        Set(value As Integer)
            iMaKhoi = value
        End Set
    End Property

    Public Property MaHocKy As Integer
        Get
            Return iMaHocKy
        End Get
        Set(value As Integer)
            iMaHocKy = value
        End Set
    End Property
End Class
