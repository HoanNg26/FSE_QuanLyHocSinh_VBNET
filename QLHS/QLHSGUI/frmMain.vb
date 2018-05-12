
Imports System.Configuration

Public Class frmMain

    Private ConnectionString As String
    Private Sub LoạiHọcSinhToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoạiHọcSinhToolStripMenuItem.Click
        Dim frm As frmThemLoaiHocSinhGUI = New frmThemLoaiHocSinhGUI()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ThêmHọcSinhToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmHọcSinhToolStripMenuItem.Click
        Dim frmhs As frmThemHocSinh = New frmThemHocSinh()
        frmhs.MdiParent = Me
        frmhs.Show()
    End Sub

    Private Sub XemDanhSáchHọcSinhToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XemDanhSáchHọcSinhToolStripMenuItem.Click
        Dim frm As frmQLHocSinh = New frmQLHocSinh()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Read ConnectionString value from App.config file
        ConnectionString = ConfigurationManager.AppSettings("ConnectionString")


    End Sub

    Private Sub XemDanhSáchLoạiHọcSinhToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XemDanhSáchLoạiHọcSinhToolStripMenuItem.Click
        Dim frm As frmQLLoaiHocSinh = New frmQLLoaiHocSinh()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ThêmNămHọcToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmNămHọcToolStripMenuItem.Click
        Dim frm As frmThemNamHoc = New frmThemNamHoc()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLýNămHọcToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýNămHọcToolStripMenuItem.Click
        Dim frm As frmQLNamHoc = New frmQLNamHoc()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ThêmKhốiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmKhốiToolStripMenuItem.Click
        Dim frm As frmThemKhoi = New frmThemKhoi()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLýKhốiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýKhốiToolStripMenuItem.Click
        Dim frm As frmQLKhoi = New frmQLKhoi()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ThêmLoạiĐiểmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmLoạiĐiểmToolStripMenuItem.Click
        Dim frm As frmThemLoaiDiem = New frmThemLoaiDiem()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLýLoạiĐiểmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýLoạiĐiểmToolStripMenuItem.Click
        Dim frm As frmQLLoaiDiem = New frmQLLoaiDiem()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ThêmHọcKỳToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmHọcKỳToolStripMenuItem.Click

        Dim frm As frmThemHocKy = New frmThemHocKy()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLýHọcKỳToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýHọcKỳToolStripMenuItem.Click
        Dim frm As frmQLHocKy = New frmQLHocKy()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ThêmLớpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmLớpToolStripMenuItem.Click
        Dim frm As frmThemLop = New frmThemLop()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLýLớpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýLớpToolStripMenuItem.Click
        Dim frm As frmQLLop = New frmQLLop()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ChuyểnHọcKỳToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChuyểnHọcKỳToolStripMenuItem.Click
        Dim frm As frmChuyenHocKy = New frmChuyenHocKy()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ChuyểnLênLớpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChuyểnLênLớpToolStripMenuItem1.Click

    End Sub

    Private Sub ChuyểnLớpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChuyểnLớpToolStripMenuItem.Click
        Dim frm As frmChuyenLop = New frmChuyenLop()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuyĐịnhToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuyĐịnhToolStripMenuItem.Click
        Dim frm As frmQuyDinh = New frmQuyDinh()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLýLoạiĐiểmToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QuảnLýLoạiĐiểmToolStripMenuItem1.Click
        Dim frm As frmQLLoaiDiem = New frmQLLoaiDiem()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub LoạiĐiểmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoạiĐiểmToolStripMenuItem.Click
        Dim frm As frmThemLoaiDiem = New frmThemLoaiDiem()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ThêmĐiểmSốToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmĐiểmSốToolStripMenuItem.Click
        Dim frm As frmNhapDiemTheoMon = New frmNhapDiemTheoMon()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ThêmMônHọcToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ThêmMônHọcToolStripMenuItem.Click
        Dim frm As frmThemMonHoc = New frmThemMonHoc()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLýMônHọcToolStripMenuItem_Click_2(sender As Object, e As EventArgs) Handles QuảnLýMônHọcToolStripMenuItem.Click
        Dim frm As frmQLMonHoc = New frmQLMonHoc()
        frm.MdiParent = Me
        frm.Show()
    End Sub


    Private Sub ThêmChươngTrìnhHọcToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmChươngTrìnhHọcToolStripMenuItem.Click
        Dim frm As frmThemChuongTrinhHoc = New frmThemChuongTrinhHoc()
        frm.MdiParent = Me
        frm.Show()
        'frmThemChuongTrinhHoc
    End Sub

    Private Sub QuảnLýChươngTrìnhToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýChươngTrìnhToolStripMenuItem.Click
        Dim frm As frmQuanLyChuongTrinh = New frmQuanLyChuongTrinh()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ÁpDụngChươngTrìnhToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÁpDụngChươngTrìnhToolStripMenuItem.Click
        Dim frm As frmApDungChuongTrinh = New frmApDungChuongTrinh()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click

    End Sub

    Private Sub BáoCáoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BáoCáoToolStripMenuItem.Click

    End Sub

    Private Sub NhậpĐiểmTheoLoạiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NhậpĐiểmTheoLoạiToolStripMenuItem.Click
        Dim frm As frmNhapDiemTheoLoai = New frmNhapDiemTheoLoai()
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class
