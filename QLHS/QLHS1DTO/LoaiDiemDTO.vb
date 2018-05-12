Public Class LoaiDiemDTO
    Private iMaLoaiDiem As Integer
    Private strLoaiDiem As String
    Private iHeSoMacDinh As Integer
    Public Sub New()
        iMaLoaiDiem = 0
        strLoaiDiem = String.Empty
    End Sub
    Public Sub New(iMaLoaiDiem As Integer, strLoaiDiem As String, iHeSoMacDinh As Integer)
        Me.iMaLoaiDiem = iMaLoaiDiem
        Me.strLoaiDiem = strLoaiDiem
        Me.iHeSoMacDinh = iHeSoMacDinh
    End Sub
    Public Property MaLoaiDiem As Integer
        Get
            Return iMaLoaiDiem
        End Get
        Set(value As Integer)
            iMaLoaiDiem = value
        End Set
    End Property

    Public Property LoaiDiem As String
        Get
            Return strLoaiDiem
        End Get
        Set(value As String)
            strLoaiDiem = value
        End Set
    End Property

    Public Property HeSoMacDinh As Integer
        Get
            Return iHeSoMacDinh
        End Get
        Set(value As Integer)
            iHeSoMacDinh = value
        End Set
    End Property
End Class
