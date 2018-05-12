<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQLLop
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
        Me.txtMaLop = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTenLop = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnXoa = New System.Windows.Forms.Button()
        Me.btnCapNhat = New System.Windows.Forms.Button()
        Me.dgvListLop = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbKhoiFilter = New System.Windows.Forms.ComboBox()
        Me.cbTuHocKy = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbNamHoc = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.dgvListLop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtMaLop
        '
        Me.txtMaLop.Location = New System.Drawing.Point(124, 295)
        Me.txtMaLop.Name = "txtMaLop"
        Me.txtMaLop.ReadOnly = True
        Me.txtMaLop.Size = New System.Drawing.Size(162, 20)
        Me.txtMaLop.TabIndex = 54
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 302)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Mã Lớp:"
        '
        'txtTenLop
        '
        Me.txtTenLop.Location = New System.Drawing.Point(124, 342)
        Me.txtTenLop.Name = "txtTenLop"
        Me.txtTenLop.Size = New System.Drawing.Size(222, 20)
        Me.txtTenLop.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 349)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Tên Lớp:"
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(247, 386)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(99, 23)
        Me.btnXoa.TabIndex = 50
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(124, 386)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(75, 23)
        Me.btnCapNhat.TabIndex = 49
        Me.btnCapNhat.Text = "Cập nhật"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'dgvListLop
        '
        Me.dgvListLop.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvListLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListLop.Location = New System.Drawing.Point(40, 88)
        Me.dgvListLop.MultiSELECT = False
        Me.dgvListLop.Name = "dgvListLop"
        Me.dgvListLop.ReadOnly = True
        Me.dgvListLop.RowHeadersVisible = False
        Me.dgvListLop.SELECTionMode = System.Windows.Forms.DataGridViewSELECTionMode.FullRowSELECT
        Me.dgvListLop.Size = New System.Drawing.Size(328, 190)
        Me.dgvListLop.TabIndex = 48
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(87, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Khối:"
        '
        'cbKhoiFilter
        '
        Me.cbKhoiFilter.FormattingEnabled = True
        Me.cbKhoiFilter.Location = New System.Drawing.Point(124, 12)
        Me.cbKhoiFilter.Name = "cbKhoiFilter"
        Me.cbKhoiFilter.Size = New System.Drawing.Size(176, 21)
        Me.cbKhoiFilter.TabIndex = 46
        '
        'cbTuHocKy
        '
        Me.cbTuHocKy.FormattingEnabled = True
        Me.cbTuHocKy.Location = New System.Drawing.Point(255, 51)
        Me.cbTuHocKy.Name = "cbTuHocKy"
        Me.cbTuHocKy.Size = New System.Drawing.Size(91, 21)
        Me.cbTuHocKy.TabIndex = 60
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Năm Học"
        '
        'cbNamHoc
        '
        Me.cbNamHoc.FormattingEnabled = True
        Me.cbNamHoc.Location = New System.Drawing.Point(105, 51)
        Me.cbNamHoc.Name = "cbNamHoc"
        Me.cbNamHoc.Size = New System.Drawing.Size(77, 21)
        Me.cbNamHoc.TabIndex = 58
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(204, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Học Kỳ:"
        '
        'frmQLLop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 487)
        Me.Controls.Add(Me.cbTuHocKy)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbNamHoc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtMaLop)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTenLop)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnCapNhat)
        Me.Controls.Add(Me.dgvListLop)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbKhoiFilter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmQLLop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quản lý Lớp"
        CType(Me.dgvListLop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMaLop As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTenLop As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnXoa As Button
    Friend WithEvents btnCapNhat As Button
    Friend WithEvents dgvListLop As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents cbKhoiFilter As ComboBox
    Friend WithEvents cbTuHocKy As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbNamHoc As ComboBox
    Friend WithEvents Label6 As Label
End Class
