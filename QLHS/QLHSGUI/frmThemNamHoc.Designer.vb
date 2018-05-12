<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThemNamHoc
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMaNamHoc = New System.Windows.Forms.TextBox()
        Me.txtNamHoc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnNhap = New System.Windows.Forms.Button()
        Me.btnNhapVanDong = New System.Windows.Forms.Button()
        Me.txtKhoaThu = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mã Năm Học:"
        '
        'txtMaNamHoc
        '
        Me.txtMaNamHoc.Location = New System.Drawing.Point(150, 35)
        Me.txtMaNamHoc.Name = "txtMaNamHoc"
        Me.txtMaNamHoc.ReadOnly = True
        Me.txtMaNamHoc.Size = New System.Drawing.Size(157, 20)
        Me.txtMaNamHoc.TabIndex = 1
        '
        'txtNamHoc
        '
        Me.txtNamHoc.Location = New System.Drawing.Point(150, 71)
        Me.txtNamHoc.Name = "txtNamHoc"
        Me.txtNamHoc.Size = New System.Drawing.Size(199, 20)
        Me.txtNamHoc.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(64, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tên Năm Học:"
        '
        'btnNhap
        '
        Me.btnNhap.Location = New System.Drawing.Point(150, 146)
        Me.btnNhap.Name = "btnNhap"
        Me.btnNhap.Size = New System.Drawing.Size(75, 23)
        Me.btnNhap.TabIndex = 4
        Me.btnNhap.Text = "Nhập"
        Me.btnNhap.UseVisualStyleBackColor = True
        '
        'btnNhapVanDong
        '
        Me.btnNhapVanDong.Location = New System.Drawing.Point(252, 146)
        Me.btnNhapVanDong.Name = "btnNhapVanDong"
        Me.btnNhapVanDong.Size = New System.Drawing.Size(97, 23)
        Me.btnNhapVanDong.TabIndex = 17
        Me.btnNhapVanDong.Text = "Nhập và Đóng"
        Me.btnNhapVanDong.UseVisualStyleBackColor = True
        '
        'txtKhoaThu
        '
        Me.txtKhoaThu.Location = New System.Drawing.Point(150, 102)
        Me.txtKhoaThu.Name = "txtKhoaThu"
        Me.txtKhoaThu.ReadOnly = True
        Me.txtKhoaThu.Size = New System.Drawing.Size(157, 20)
        Me.txtKhoaThu.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(64, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Khóa Thứ:"
        '
        'frmThemNamHoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 196)
        Me.Controls.Add(Me.txtKhoaThu)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnNhapVanDong)
        Me.Controls.Add(Me.btnNhap)
        Me.Controls.Add(Me.txtNamHoc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMaNamHoc)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmThemNamHoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thêm Năm Học"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtMaNamHoc As TextBox
    Friend WithEvents txtNamHoc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnNhap As Button
    Friend WithEvents btnNhapVanDong As Button
    Friend WithEvents txtKhoaThu As TextBox
    Friend WithEvents Label3 As Label
End Class
