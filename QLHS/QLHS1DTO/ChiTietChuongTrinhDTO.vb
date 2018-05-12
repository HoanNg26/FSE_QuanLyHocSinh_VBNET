Imports QLHS1DTO

Public Class ChiTietChuongTrinhDTO
    Private iMaMonHoc As Integer
    Private strTenMonHoc As String
    Private iHeSoMon As Integer

    Private iMaCTTT As Integer
    Private iMaCT As Integer

    Private lsHTDG As List(Of HinhThucDanhGiaDTO)
    Public Sub New()
        Me.iMaMonHoc = 0
        Me.strTenMonHoc = String.Empty
        Me.iHeSoMon = 1
        Me.iMaCTTT = 0
        Me.iMaCT = 0
        Me.lsHTDG = New List(Of HinhThucDanhGiaDTO)

    End Sub
    Public Sub New(iMaMonHoc As Integer, strTenMonHoc As String, iHeSoMon As Integer, iMaCTTT As Integer, iMaCT As Integer, lsHTDG As List(Of HinhThucDanhGiaDTO))
        Me.iMaMonHoc = iMaMonHoc
        Me.strTenMonHoc = strTenMonHoc
        Me.iHeSoMon = iHeSoMon
        Me.iMaCTTT = iMaCTTT
        Me.iMaCT = iMaCT
        Me.lsHTDG = lsHTDG
    End Sub
    Public Sub New(iMaCTTT As Integer, iMaMonHoc As Integer, iHeSoMon As Integer, iMaCT As Integer, lsHTDG As List(Of HinhThucDanhGiaDTO))
        Me.iMaMonHoc = iMaMonHoc
        Me.strTenMonHoc = String.Empty
        Me.iHeSoMon = iHeSoMon
        Me.iMaCTTT = iMaCTTT
        Me.iMaCT = iMaCT
        Me.lsHTDG = lsHTDG
    End Sub

    'Public Sub New(iMaCTTT As Integer, iHeSoMon As Integer, iMaCT As Integer, monhoc As MonHocDTO, lsHTDG As List(Of HinhThucDanhGiaDTO))
    '    Me.iMaMonHoc = monhoc.MaMonHoc
    '    Me.strTenMonHoc = monhoc.MonHoc
    '    Me.iHeSoMon = iHeSoMon
    '    Me.iMaCTTT = iMaCTTT
    '    Me.iMaCT = iMaCT
    '    Me.lsHTDG = lsHTDG
    'End Sub
    Public Property MaMonHoc As Integer
        Get
            Return iMaMonHoc
        End Get
        Set(value As Integer)
            iMaMonHoc = value
        End Set
    End Property

    Public Property TenMonHoc As String
        Get
            Return strTenMonHoc
        End Get
        Set(value As String)
            strTenMonHoc = value
        End Set
    End Property

    Public Property HeSoMon As Integer
        Get
            Return iHeSoMon
        End Get
        Set(value As Integer)
            iHeSoMon = value
        End Set
    End Property

    Public Property MaCTTT As Integer
        Get
            Return iMaCTTT
        End Get
        Set(value As Integer)
            iMaCTTT = value
        End Set
    End Property

    Public Property MaCT As Integer
        Get
            Return iMaCT
        End Get
        Set(value As Integer)
            iMaCT = value
        End Set
    End Property

    Public Property ListHTDG As List(Of HinhThucDanhGiaDTO)
        Get
            Return lsHTDG
        End Get
        Set(value As List(Of HinhThucDanhGiaDTO))
            lsHTDG = value
        End Set
    End Property


End Class
