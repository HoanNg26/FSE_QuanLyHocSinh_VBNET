<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNhapDiemTheoLoai
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbMonHoc = New System.Windows.Forms.ComboBox()
        Me.dgvDiemHS = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbLop = New System.Windows.Forms.ComboBox()
        Me.btnNhapDiem = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbKhoi = New System.Windows.Forms.ComboBox()
        Me.cbHocKy = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbNamHoc = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbHTDG = New System.Windows.Forms.ComboBox()
        CType(Me.dgvDiemHS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(160, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Môn Học:"
        '
        'cbMonHoc
        '
        Me.cbMonHoc.FormattingEnabled = True
        Me.cbMonHoc.Location = New System.Drawing.Point(217, 105)
        Me.cbMonHoc.Name = "cbMonHoc"
        Me.cbMonHoc.Size = New System.Drawing.Size(129, 21)
        Me.cbMonHoc.TabIndex = 101
        '
        'dgvDiemHS
        '
        Me.dgvDiemHS.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvDiemHS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDiemHS.Location = New System.Drawing.Point(26, 132)
        Me.dgvDiemHS.MultiSelect = False
        Me.dgvDiemHS.Name = "dgvDiemHS"
        Me.dgvDiemHS.RowHeadersVisible = False
        Me.dgvDiemHS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDiemHS.Size = New System.Drawing.Size(532, 586)
        Me.dgvDiemHS.TabIndex = 100
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Lớp:"
        '
        'cbLop
        '
        Me.cbLop.FormattingEnabled = True
        Me.cbLop.Location = New System.Drawing.Point(57, 105)
        Me.cbLop.Name = "cbLop"
        Me.cbLop.Size = New System.Drawing.Size(94, 21)
        Me.cbLop.TabIndex = 98
        '
        'btnNhapDiem
        '
        Me.btnNhapDiem.Location = New System.Drawing.Point(217, 747)
        Me.btnNhapDiem.Name = "btnNhapDiem"
        Me.btnNhapDiem.Size = New System.Drawing.Size(125, 23)
        Me.btnNhapDiem.TabIndex = 96
        Me.btnNhapDiem.Text = "Nhập Điểm"
        Me.btnNhapDiem.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(188, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Khối:"
        '
        'cbKhoi
        '
        Me.cbKhoi.FormattingEnabled = True
        Me.cbKhoi.Location = New System.Drawing.Point(237, 23)
        Me.cbKhoi.Name = "cbKhoi"
        Me.cbKhoi.Size = New System.Drawing.Size(125, 21)
        Me.cbKhoi.TabIndex = 90
        '
        'cbHocKy
        '
        Me.cbHocKy.FormattingEnabled = True
        Me.cbHocKy.Location = New System.Drawing.Point(341, 61)
        Me.cbHocKy.Name = "cbHocKy"
        Me.cbHocKy.Size = New System.Drawing.Size(153, 21)
        Me.cbHocKy.TabIndex = 94
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Năm Học:"
        '
        'cbNamHoc
        '
        Me.cbNamHoc.FormattingEnabled = True
        Me.cbNamHoc.Location = New System.Drawing.Point(95, 61)
        Me.cbNamHoc.Name = "cbNamHoc"
        Me.cbNamHoc.Size = New System.Drawing.Size(153, 21)
        Me.cbNamHoc.TabIndex = 92
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(290, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Học Kỳ:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(368, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "HTDG:"
        '
        'cbHTDG
        '
        Me.cbHTDG.FormattingEnabled = True
        Me.cbHTDG.Location = New System.Drawing.Point(415, 108)
        Me.cbHTDG.Name = "cbHTDG"
        Me.cbHTDG.Size = New System.Drawing.Size(129, 21)
        Me.cbHTDG.TabIndex = 103
        '
        'frmNhapDiemTheoLoai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 782)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbHTDG)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbMonHoc)
        Me.Controls.Add(Me.dgvDiemHS)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbLop)
        Me.Controls.Add(Me.btnNhapDiem)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbKhoi)
        Me.Controls.Add(Me.cbHocKy)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbNamHoc)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmNhapDiemTheoLoai"
        Me.Text = "Nhập Điểm Theo Loại Điểm"
        CType(Me.dgvDiemHS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents cbMonHoc As ComboBox
    Friend WithEvents dgvDiemHS As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents cbLop As ComboBox
    Friend WithEvents btnNhapDiem As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cbKhoi As ComboBox
    Friend WithEvents cbHocKy As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbNamHoc As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbHTDG As ComboBox
End Class
