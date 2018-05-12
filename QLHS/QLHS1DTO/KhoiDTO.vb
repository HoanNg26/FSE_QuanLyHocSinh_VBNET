Public Class KhoiDTO
    Private iMaKhoi As Integer
    Private strKhoi As String
    Private iTTKhoi As Integer

    Public Sub New()
        iMaKhoi = 0
        strKhoi = String.Empty
    End Sub
    Public Sub New(iMaKhoi As Integer, strKhoi As String, iTTKhoi As Integer)
        Me.iMaKhoi = iMaKhoi
        Me.strKhoi = strKhoi
        Me.iTTKhoi = iTTKhoi
    End Sub
    Public Property MaKhoi As Integer
        Get
            Return iMaKhoi
        End Get
        Set(value As Integer)
            iMaKhoi = value
        End Set
    End Property

    Public Property Khoi As String
        Get
            Return strKhoi
        End Get
        Set(value As String)
            strKhoi = value
        End Set
    End Property

    Public Property TTKhoi As Integer
        Get
            Return iTTKhoi
        End Get
        Set(value As Integer)
            iTTKhoi = value
        End Set
    End Property
End Class
