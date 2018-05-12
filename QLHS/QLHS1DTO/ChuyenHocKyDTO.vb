Public Class ChuyenHocKyDTO

    Private iMaKhoi As Integer
    Private iMaHocKy_FROM As Integer
    Private iMaHocKy_To As Integer

    Public Property MaKhoi As Integer
        Get
            Return iMaKhoi
        End Get
        Set(value As Integer)
            iMaKhoi = value
        End Set
    End Property

    Public Property MaHocKy_FROM As Integer
        Get
            Return iMaHocKy_FROM
        End Get
        Set(value As Integer)
            iMaHocKy_FROM = value
        End Set
    End Property

    Public Property MaHocKy_To As Integer
        Get
            Return iMaHocKy_To
        End Get
        Set(value As Integer)
            iMaHocKy_To = value
        End Set
    End Property
End Class
