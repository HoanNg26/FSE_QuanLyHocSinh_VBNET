<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThemChuongTrinhHoc
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
        Me.cbLoaiDiem = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgvHTDG = New System.Windows.Forms.DataGridView()
        Me.dtpNgayTao = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTenCT = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnToFROM = New System.Windows.Forms.Button()
        Me.btnFROMTo = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvMonHocChuongTrinh = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvMonHoc = New System.Windows.Forms.DataGridView()
        Me.btnCapNhat = New System.Windows.Forms.Button()
        Me.btnThemLoaiDiem = New System.Windows.Forms.Button()
        CType(Me.dgvHTDG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMonHocChuongTrinh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMonHoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbLoaiDiem
        '
        Me.cbLoaiDiem.FormattingEnabled = True
        Me.cbLoaiDiem.Location = New System.Drawing.Point(776, 97)
        Me.cbLoaiDiem.Name = "cbLoaiDiem"
        Me.cbLoaiDiem.Size = New System.Drawing.Size(103, 21)
        Me.cbLoaiDiem.TabIndex = 118
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(645, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 13)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "Hình thức đánh giá Môn:"
        '
        'dgvHTDG
        '
        Me.dgvHTDG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvHTDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHTDG.Location = New System.Drawing.Point(642, 124)
        Me.dgvHTDG.MultiSelect = False
        Me.dgvHTDG.Name = "dgvHTDG"
        Me.dgvHTDG.RowHeadersVisible = False
        Me.dgvHTDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHTDG.Size = New System.Drawing.Size(272, 284)
        Me.dgvHTDG.TabIndex = 116
        '
        'dtpNgayTao
        '
        Me.dtpNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayTao.Location = New System.Drawing.Point(559, 24)
        Me.dtpNgayTao.Name = "dtpNgayTao"
        Me.dtpNgayTao.Size = New System.Drawing.Size(99, 20)
        Me.dtpNgayTao.TabIndex = 115
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(496, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "Ngày Tạo:"
        '
        'txtTenCT
        '
        Me.txtTenCT.Location = New System.Drawing.Point(246, 24)
        Me.txtTenCT.Name = "txtTenCT"
        Me.txtTenCT.Size = New System.Drawing.Size(214, 20)
        Me.txtTenCT.TabIndex = 113
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(135, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 13)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "Tên Chương Trình:"
        '
        'btnToFROM
        '
        Me.btnToFROM.Location = New System.Drawing.Point(252, 222)
        Me.btnToFROM.Name = "btnToFROM"
        Me.btnToFROM.Size = New System.Drawing.Size(52, 23)
        Me.btnToFROM.TabIndex = 111
        Me.btnToFROM.Text = "<"
        Me.btnToFROM.UseVisualStyleBackColor = True
        '
        'btnFROMTo
        '
        Me.btnFROMTo.Location = New System.Drawing.Point(252, 157)
        Me.btnFROMTo.Name = "btnFROMTo"
        Me.btnFROMTo.Size = New System.Drawing.Size(52, 23)
        Me.btnFROMTo.TabIndex = 110
        Me.btnFROMTo.Text = ">"
        Me.btnFROMTo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(313, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 13)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "Danh sách môn chương trình:"
        '
        'dgvMonHocChuongTrinh
        '
        Me.dgvMonHocChuongTrinh.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvMonHocChuongTrinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMonHocChuongTrinh.Location = New System.Drawing.Point(310, 80)
        Me.dgvMonHocChuongTrinh.MultiSelect = False
        Me.dgvMonHocChuongTrinh.Name = "dgvMonHocChuongTrinh"
        Me.dgvMonHocChuongTrinh.RowHeadersVisible = False
        Me.dgvMonHocChuongTrinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMonHocChuongTrinh.Size = New System.Drawing.Size(316, 410)
        Me.dgvMonHocChuongTrinh.TabIndex = 108
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Danh sách môn học:"
        '
        'dgvMonHoc
        '
        Me.dgvMonHoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvMonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMonHoc.Location = New System.Drawing.Point(8, 80)
        Me.dgvMonHoc.MultiSelect = False
        Me.dgvMonHoc.Name = "dgvMonHoc"
        Me.dgvMonHoc.ReadOnly = True
        Me.dgvMonHoc.RowHeadersVisible = False
        Me.dgvMonHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMonHoc.Size = New System.Drawing.Size(240, 410)
        Me.dgvMonHoc.TabIndex = 106
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(410, 516)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(125, 23)
        Me.btnCapNhat.TabIndex = 105
        Me.btnCapNhat.Text = "Cập Nhật"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'btnThemLoaiDiem
        '
        Me.btnThemLoaiDiem.Location = New System.Drawing.Point(882, 95)
        Me.btnThemLoaiDiem.Name = "btnThemLoaiDiem"
        Me.btnThemLoaiDiem.Size = New System.Drawing.Size(31, 23)
        Me.btnThemLoaiDiem.TabIndex = 136
        Me.btnThemLoaiDiem.Text = "+"
        Me.btnThemLoaiDiem.UseVisualStyleBackColor = True
        '
        'frmThemChuongTrinhHoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 561)
        Me.Controls.Add(Me.btnThemLoaiDiem)
        Me.Controls.Add(Me.cbLoaiDiem)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvHTDG)
        Me.Controls.Add(Me.dtpNgayTao)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTenCT)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnToFROM)
        Me.Controls.Add(Me.btnFROMTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgvMonHocChuongTrinh)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvMonHoc)
        Me.Controls.Add(Me.btnCapNhat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmThemChuongTrinhHoc"
        Me.Text = "Thêm Chương Trình Học"
        CType(Me.dgvHTDG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMonHocChuongTrinh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMonHoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbLoaiDiem As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dgvHTDG As DataGridView
    Friend WithEvents dtpNgayTao As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTenCT As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnToFROM As Button
    Friend WithEvents btnFROMTo As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvMonHocChuongTrinh As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvMonHoc As DataGridView
    Friend WithEvents btnCapNhat As Button
    Friend WithEvents btnThemLoaiDiem As Button
End Class
