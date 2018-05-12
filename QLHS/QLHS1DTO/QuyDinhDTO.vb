Public Class QuyDinhDTO
    Private iID As Integer
    Private iSoKhoiToiDa As Integer
    Private iSoHocKyToiDa As Integer

    Public Sub New()
        id = 0
        iSoKhoiToiDa = 0
        iSoHocKyToiDa = 0
    End Sub
    Public Sub New(id As Integer, iSoKhoiToiDa As Integer, iSoHocKyToiDa As Integer)
        Me.iID = id
        Me.iSoKhoiToiDa = iSoKhoiToiDa
        Me.iSoHocKyToiDa = iSoHocKyToiDa
    End Sub
    Public Property SoKhoiToiDa As Integer
        Get
            Return iSoKhoiToiDa
        End Get
        Set(value As Integer)
            iSoKhoiToiDa = value
        End Set
    End Property

    Public Property SoHocKyToiDa As Integer
        Get
            Return iSoHocKyToiDa
        End Get
        Set(value As Integer)
            iSoHocKyToiDa = value
        End Set
    End Property

    Public Property ID As Integer
        Get
            Return iID
        End Get
        Set(value As Integer)
            iID = value
        End Set
    End Property
End Class
