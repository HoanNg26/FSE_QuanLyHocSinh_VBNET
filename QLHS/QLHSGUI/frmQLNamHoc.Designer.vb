<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQLNamHoc
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
        Me.txtMaNamHoc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTenNamHoc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvDanhSachNamHoc = New System.Windows.Forms.DataGridView()
        CType(Me.dgvDanhSachNamHoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(295, 311)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(75, 23)
        Me.btnXoa.TabIndex = 29
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(175, 311)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(75, 23)
        Me.btnCapNhat.TabIndex = 28
        Me.btnCapNhat.Text = "Cập Nhật"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'txtMaNamHoc
        '
        Me.txtMaNamHoc.Location = New System.Drawing.Point(175, 207)
        Me.txtMaNamHoc.Name = "txtMaNamHoc"
        Me.txtMaNamHoc.ReadOnly = True
        Me.txtMaNamHoc.Size = New System.Drawing.Size(133, 20)
        Me.txtMaNamHoc.TabIndex = 27
        Me.txtMaNamHoc.WordWrap = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(93, 214)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Mã Năm Học:"
        '
        'txtTenNamHoc
        '
        Me.txtTenNamHoc.Location = New System.Drawing.Point(175, 254)
        Me.txtTenNamHoc.Name = "txtTenNamHoc"
        Me.txtTenNamHoc.Size = New System.Drawing.Size(222, 20)
        Me.txtTenNamHoc.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(93, 261)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Tên Năm Học:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(71, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Danh sách Năm học:"
        '
        'dgvDanhSachNamHoc
        '
        Me.dgvDanhSachNamHoc.AllowUserToAddRows = False
        Me.dgvDanhSachNamHoc.AllowUserToDeleteRows = False
        Me.dgvDanhSachNamHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDanhSachNamHoc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDanhSachNamHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDanhSachNamHoc.Location = New System.Drawing.Point(74, 34)
        Me.dgvDanhSachNamHoc.MultiSELECT = False
        Me.dgvDanhSachNamHoc.Name = "dgvDanhSachNamHoc"
        Me.dgvDanhSachNamHoc.ReadOnly = True
        Me.dgvDanhSachNamHoc.RowHeadersVisible = False
        Me.dgvDanhSachNamHoc.SELECTionMode = System.Windows.Forms.DataGridViewSELECTionMode.FullRowSELECT
        Me.dgvDanhSachNamHoc.Size = New System.Drawing.Size(386, 150)
        Me.dgvDanhSachNamHoc.TabIndex = 22
        '
        'frmQLNamHoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 381)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnCapNhat)
        Me.Controls.Add(Me.txtMaNamHoc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTenNamHoc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDanhSachNamHoc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmQLNamHoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quản lý Năm Học"
        CType(Me.dgvDanhSachNamHoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnXoa As Button
    Friend WithEvents btnCapNhat As Button
    Friend WithEvents txtMaNamHoc As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTenNamHoc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvDanhSachNamHoc As DataGridView
End Class
