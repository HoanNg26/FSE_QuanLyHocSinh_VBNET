Public Class HinhThucDanhGiaDTO
    Private iMaHTDG As Integer
    Private iMaCTTT As Integer
    Private iMaLoaiDiem As Integer
    Private iHeSoDiem As Integer
    Private strTenLoaiDiem As String
    Public Sub New(iMaHTDG As Integer, iMaCTTT As Integer, iMaLoaiDiem As Integer, iHeSoDiem As Integer)
        Me.iMaHTDG = iMaHTDG
        Me.iMaCTTT = iMaCTTT
        Me.iMaLoaiDiem = iMaLoaiDiem
        Me.iHeSoDiem = iHeSoDiem
    End Sub
    Public Sub New(iMaHTDG As Integer, iMaCTTT As Integer, iMaLoaiDiem As Integer, iHeSoDiem As Integer, strTenLoaiDiem As String)
        Me.iMaHTDG = iMaHTDG
        Me.iMaCTTT = iMaCTTT
        Me.iMaLoaiDiem = iMaLoaiDiem
        Me.iHeSoDiem = iHeSoDiem
        Me.strTenLoaiDiem = strTenLoaiDiem
    End Sub
    Public Property MaCTTT As Integer
        Get
            Return iMaCTTT
        End Get
        Set(value As Integer)
            iMaCTTT = value
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

    Public Property HeSoDiem As Integer
        Get
            Return iHeSoDiem
        End Get
        Set(value As Integer)
            iHeSoDiem = value
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

    Public Property TenLoaiDiem As String
        Get
            Return strTenLoaiDiem
        End Get
        Set(value As String)
            strTenLoaiDiem = value
        End Set
    End Property
End Class
