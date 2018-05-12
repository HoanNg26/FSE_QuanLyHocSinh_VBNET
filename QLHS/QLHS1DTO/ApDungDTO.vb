Public Class ApDungDTO
    Private iMaLop As Integer
    Private strTenLop As String
    Private iMaCT As Integer
    Private strTenCT As String
    Private dtNgayApDung As DateTime

    Public Sub New()
        Me.iMaLop = 0
        Me.strTenLop = String.Empty
        Me.iMaCT = 0
        Me.strTenCT = String.Empty
        Me.dtNgayApDung = DateTime.Now
    End Sub
    Public Sub New(iMaLop As Integer, strTenLop As String, iMaCT As Integer, strTenCT As String, dtNgayApDung As DateTime)
        Me.iMaLop = iMaLop
        Me.strTenLop = strTenLop
        Me.iMaCT = iMaCT
        Me.strTenCT = strTenCT
        Me.dtNgayApDung = dtNgayApDung
    End Sub

    Public Sub New(iMaLop As Integer, iMaCT As Integer, dtNgayApDung As DateTime)
        Me.iMaLop = iMaLop
        Me.strTenLop = String.Empty
        Me.iMaCT = iMaCT
        Me.strTenCT = String.Empty
        Me.dtNgayApDung = dtNgayApDung
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
    Public Property MaCT As Integer
        Get
            Return iMaCT
        End Get
        Set(value As Integer)
            iMaCT = value
        End Set
    End Property

    Public Property TenCT As String
        Get
            Return strTenCT
        End Get
        Set(value As String)
            strTenCT = value
        End Set
    End Property

    Public Property NgayApDung As Date
        Get
            Return dtNgayApDung
        End Get
        Set(value As Date)
            dtNgayApDung = value
        End Set
    End Property
End Class
