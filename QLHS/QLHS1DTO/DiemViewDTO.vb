Public Class DiemViewDTO
    Private strMSHS As String
    Private iMaMonHoc As Integer
    Private strMonHoc As String
    Private iMaHTDG As Integer
    Private iMaLoaiDiem As Integer
    Private strLoaiDiem As String
    Private iHeSoDiem As Integer
    Private fDiem As Single
    Public Sub New()
        Me.strMSHS = String.Empty
        Me.iMaMonHoc = -1
        Me.strMonHoc = String.Empty
        Me.iMaHTDG = -1
        Me.iMaLoaiDiem = -1
        Me.strLoaiDiem = String.Empty
        Me.iHeSoDiem = 0
        Me.fDiem = -1
    End Sub

    Property MSHS() As String
        Get
            Return strMSHS
        End Get
        Set(ByVal Value As String)
            strMSHS = Value
        End Set
    End Property

    Public Property MaMonHoc As Integer
        Get
            Return iMaMonHoc
        End Get
        Set(value As Integer)
            iMaMonHoc = value
        End Set
    End Property

    Public Property MonHoc As String
        Get
            Return strMonHoc
        End Get
        Set(value As String)
            strMonHoc = value
        End Set
    End Property
    Public Property MaHTDG As Integer
        Get
            Return iMaHTDG
        End Get
        Set(value As Integer)
            iMaHTDG = value
        End Set
    End Property
    Public Property MaLoaiDiem As Integer
        Get
            Return iMaLoaiDiem
        End Get
        Set(value As Integer)
            iMaLoaiDiem = value
        End Set
    End Property

    Public Property TenLoaiDiem As String
        Get
            Return strLoaiDiem
        End Get
        Set(value As String)
            strLoaiDiem = value
        End Set
    End Property
    Public Property HeSoDiem As Integer
        Get
            Return iHeSoDiem
        End Get
        Set(value As Integer)
            iHeSoDiem = value
        End Set
    End Property
    Public Property Diem As Single
        Get
            Return fDiem
        End Get
        Set(value As Single)
            fDiem = value
        End Set
    End Property
    Public Function createDiemDTO() As DiemDTO
        Dim d = New DiemDTO()
        d.MaHTDG = Me.MaHTDG
        d.MSHS = Me.MSHS
        d.Diem = Me.Diem
        d.NgayCapNhat = DateTime.Now
        d.NgayNhap = DateTime.Now
        d.UserIdCapNhat = "admin"
        d.UserIdNhap = "admin"
        Return d
    End Function

End Class
