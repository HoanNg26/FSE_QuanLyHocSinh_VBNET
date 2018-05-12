<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQLMonHoc
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
        Me.btnXoa = New System.Windows.Forms.Button()
        Me.btnCapNhat = New System.Windows.Forms.Button()
        Me.txtMaMonHoc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTenMonHoc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvDanhSachMônHoc = New System.Windows.Forms.DataGridView()
        CType(Me.dgvDanhSachMônHoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(309, 442)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(75, 23)
        Me.btnXoa.TabIndex = 37
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(189, 442)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(75, 23)
        Me.btnCapNhat.TabIndex = 36
        Me.btnCapNhat.Text = "Cập Nhật"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'txtMaMonHoc
        '
        Me.txtMaMonHoc.Location = New System.Drawing.Point(189, 338)
        Me.txtMaMonHoc.Name = "txtMaMonHoc"
        Me.txtMaMonHoc.ReadOnly = True
        Me.txtMaMonHoc.Size = New System.Drawing.Size(133, 20)
        Me.txtMaMonHoc.TabIndex = 35
        Me.txtMaMonHoc.WordWrap = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(107, 345)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Mã Môn Học:"
        '
        'txtTenMonHoc
        '
        Me.txtTenMonHoc.Location = New System.Drawing.Point(189, 385)
        Me.txtTenMonHoc.Name = "txtTenMonHoc"
        Me.txtTenMonHoc.Size = New System.Drawing.Size(222, 20)
        Me.txtTenMonHoc.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(107, 392)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Tên Môn Học:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(101, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Danh sách Môn Học:"
        '
        'dgvDanhSachMônHoc
        '
        Me.dgvDanhSachMônHoc.AllowUserToAddRows = False
        Me.dgvDanhSachMônHoc.AllowUserToDeleteRows = False
        Me.dgvDanhSachMônHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDanhSachMônHoc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDanhSachMônHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDanhSachMônHoc.Location = New System.Drawing.Point(103, 38)
        Me.dgvDanhSachMônHoc.MultiSELECT = False
        Me.dgvDanhSachMônHoc.Name = "dgvDanhSachMônHoc"
        Me.dgvDanhSachMônHoc.ReadOnly = True
        Me.dgvDanhSachMônHoc.RowHeadersVisible = False
        Me.dgvDanhSachMônHoc.SELECTionMode = System.Windows.Forms.DataGridViewSELECTionMode.FullRowSELECT
        Me.dgvDanhSachMônHoc.Size = New System.Drawing.Size(386, 281)
        Me.dgvDanhSachMônHoc.TabIndex = 30
        '
        'frmQLMonHoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 478)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnCapNhat)
        Me.Controls.Add(Me.txtMaMonHoc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTenMonHoc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDanhSachMônHoc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmQLMonHoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quản lý Môn Học"
        CType(Me.dgvDanhSachMônHoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnXoa As Button
    Friend WithEvents btnCapNhat As Button
    Friend WithEvents txtMaMonHoc As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTenMonHoc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvDanhSachMônHoc As DataGridView
End Class
