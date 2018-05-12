Public Class MonHocDTO
    Private iMaMonHoc As Integer
    Private strMonHoc As String
    Public Sub New()
        iMaMonHoc = 0
        strMonHoc = String.Empty
    End Sub
    Public Sub New(iMaMonHoc As Integer, strMonHoc As String)
        Me.iMaMonHoc = iMaMonHoc
        Me.strMonHoc = strMonHoc
    End Sub
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
End Class
