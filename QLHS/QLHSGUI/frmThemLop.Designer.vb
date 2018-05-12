<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThemLop
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
        Me.btnNhapVaDong = New System.Windows.Forms.Button()
        Me.btnNhap = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbKhoi = New System.Windows.Forms.ComboBox()
        Me.txtMaLop = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTenLop = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbTuHocKy = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbNamHoc = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnNhapVaDong
        '
        Me.btnNhapVaDong.Location = New System.Drawing.Point(273, 192)
        Me.btnNhapVaDong.Name = "btnNhapVaDong"
        Me.btnNhapVaDong.Size = New System.Drawing.Size(112, 23)
        Me.btnNhapVaDong.TabIndex = 31
        Me.btnNhapVaDong.Text = "Nhập và Đóng"
        Me.btnNhapVaDong.UseVisualStyleBackColor = True
        '
        'btnNhap
        '
        Me.btnNhap.Location = New System.Drawing.Point(144, 192)
        Me.btnNhap.Name = "btnNhap"
        Me.btnNhap.Size = New System.Drawing.Size(75, 23)
        Me.btnNhap.TabIndex = 30
        Me.btnNhap.Text = "Nhập"
        Me.btnNhap.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(95, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Khối:"
        '
        'cbKhoi
        '
        Me.cbKhoi.FormattingEnabled = True
        Me.cbKhoi.Location = New System.Drawing.Point(144, 55)
        Me.cbKhoi.Name = "cbKhoi"
        Me.cbKhoi.Size = New System.Drawing.Size(197, 21)
        Me.cbKhoi.TabIndex = 28
        '
        'txtMaLop
        '
        Me.txtMaLop.Location = New System.Drawing.Point(144, 93)
        Me.txtMaLop.Name = "txtMaLop"
        Me.txtMaLop.ReadOnly = True
        Me.txtMaLop.Size = New System.Drawing.Size(162, 20)
        Me.txtMaLop.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Mã Lớp:"
        '
        'txtTenLop
        '
        Me.txtTenLop.Location = New System.Drawing.Point(144, 140)
        Me.txtTenLop.Name = "txtTenLop"
        Me.txtTenLop.Size = New System.Drawing.Size(241, 20)
        Me.txtTenLop.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Tên Lớp:"
        '
        'cbTuHocKy
        '
        Me.cbTuHocKy.FormattingEnabled = True
        Me.cbTuHocKy.Location = New System.Drawing.Point(294, 16)
        Me.cbTuHocKy.Name = "cbTuHocKy"
        Me.cbTuHocKy.Size = New System.Drawing.Size(91, 21)
        Me.cbTuHocKy.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(86, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Năm Học"
        '
        'cbNamHoc
        '
        Me.cbNamHoc.FormattingEnabled = True
        Me.cbNamHoc.Location = New System.Drawing.Point(144, 16)
        Me.cbNamHoc.Name = "cbNamHoc"
        Me.cbNamHoc.Size = New System.Drawing.Size(77, 21)
        Me.cbNamHoc.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(243, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Học Kỳ:"
        '
        'frmThemLop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 255)
        Me.Controls.Add(Me.cbTuHocKy)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbNamHoc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnNhapVaDong)
        Me.Controls.Add(Me.btnNhap)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbKhoi)
        Me.Controls.Add(Me.txtMaLop)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTenLop)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmThemLop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thêm Lớp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnNhapVaDong As Button
    Friend WithEvents btnNhap As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents cbKhoi As ComboBox
    Friend WithEvents txtMaLop As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTenLop As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbTuHocKy As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbNamHoc As ComboBox
    Friend WithEvents Label4 As Label
End Class
