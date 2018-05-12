<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChuyenLop
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
        Me.btnChuyenHS = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbKhoi = New System.Windows.Forms.ComboBox()
        Me.cbHocKy = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbNamHoc = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvListHS_FROM = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbLop_FROM = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbLop_To = New System.Windows.Forms.ComboBox()
        Me.dgvListHS_To = New System.Windows.Forms.DataGridView()
        Me.btnFROMTo = New System.Windows.Forms.Button()
        Me.btnToFROM = New System.Windows.Forms.Button()
        CType(Me.dgvListHS_FROM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListHS_To, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnChuyenHS
        '
        Me.btnChuyenHS.Location = New System.Drawing.Point(357, 480)
        Me.btnChuyenHS.Name = "btnChuyenHS"
        Me.btnChuyenHS.Size = New System.Drawing.Size(125, 23)
        Me.btnChuyenHS.TabIndex = 68
        Me.btnChuyenHS.Text = "Chuyển Học Sinh"
        Me.btnChuyenHS.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(308, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Khối:"
        '
        'cbKhoi
        '
        Me.cbKhoi.FormattingEnabled = True
        Me.cbKhoi.Location = New System.Drawing.Point(357, 12)
        Me.cbKhoi.Name = "cbKhoi"
        Me.cbKhoi.Size = New System.Drawing.Size(125, 21)
        Me.cbKhoi.TabIndex = 0
        '
        'cbHocKy
        '
        Me.cbHocKy.FormattingEnabled = True
        Me.cbHocKy.Location = New System.Drawing.Point(461, 50)
        Me.cbHocKy.Name = "cbHocKy"
        Me.cbHocKy.Size = New System.Drawing.Size(153, 21)
        Me.cbHocKy.TabIndex = 63
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(157, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Năm Học:"
        '
        'cbNamHoc
        '
        Me.cbNamHoc.FormattingEnabled = True
        Me.cbNamHoc.Location = New System.Drawing.Point(215, 50)
        Me.cbNamHoc.Name = "cbNamHoc"
        Me.cbNamHoc.Size = New System.Drawing.Size(153, 21)
        Me.cbNamHoc.TabIndex = 61
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(394, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Học Kỳ:"
        '
        'dgvListHS_FROM
        '
        Me.dgvListHS_FROM.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvListHS_FROM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListHS_FROM.Location = New System.Drawing.Point(30, 123)
        Me.dgvListHS_FROM.MultiSELECT = False
        Me.dgvListHS_FROM.Name = "dgvListHS_FROM"
        Me.dgvListHS_FROM.RowHeadersVisible = False
        Me.dgvListHS_FROM.SELECTionMode = System.Windows.Forms.DataGridViewSELECTionMode.FullRowSELECT
        Me.dgvListHS_FROM.Size = New System.Drawing.Size(357, 325)
        Me.dgvListHS_FROM.TabIndex = 69
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Từ Lớp:"
        '
        'cbLop_FROM
        '
        Me.cbLop_FROM.FormattingEnabled = True
        Me.cbLop_FROM.Location = New System.Drawing.Point(91, 96)
        Me.cbLop_FROM.Name = "cbLop_FROM"
        Me.cbLop_FROM.Size = New System.Drawing.Size(153, 21)
        Me.cbLop_FROM.TabIndex = 70
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(454, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Sang Lớp:"
        '
        'cbLop_To
        '
        Me.cbLop_To.FormattingEnabled = True
        Me.cbLop_To.Location = New System.Drawing.Point(512, 96)
        Me.cbLop_To.Name = "cbLop_To"
        Me.cbLop_To.Size = New System.Drawing.Size(153, 21)
        Me.cbLop_To.TabIndex = 73
        '
        'dgvListHS_To
        '
        Me.dgvListHS_To.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvListHS_To.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListHS_To.Location = New System.Drawing.Point(451, 123)
        Me.dgvListHS_To.MultiSELECT = False
        Me.dgvListHS_To.Name = "dgvListHS_To"
        Me.dgvListHS_To.ReadOnly = True
        Me.dgvListHS_To.RowHeadersVisible = False
        Me.dgvListHS_To.SELECTionMode = System.Windows.Forms.DataGridViewSELECTionMode.FullRowSELECT
        Me.dgvListHS_To.Size = New System.Drawing.Size(357, 325)
        Me.dgvListHS_To.TabIndex = 72
        '
        'btnFROMTo
        '
        Me.btnFROMTo.Location = New System.Drawing.Point(393, 200)
        Me.btnFROMTo.Name = "btnFROMTo"
        Me.btnFROMTo.Size = New System.Drawing.Size(52, 23)
        Me.btnFROMTo.TabIndex = 75
        Me.btnFROMTo.Text = ">"
        Me.btnFROMTo.UseVisualStyleBackColor = True
        '
        'btnToFROM
        '
        Me.btnToFROM.Location = New System.Drawing.Point(393, 265)
        Me.btnToFROM.Name = "btnToFROM"
        Me.btnToFROM.Size = New System.Drawing.Size(52, 23)
        Me.btnToFROM.TabIndex = 76
        Me.btnToFROM.Text = "<"
        Me.btnToFROM.UseVisualStyleBackColor = True
        '
        'frmChuyenLop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 556)
        Me.Controls.Add(Me.btnToFROM)
        Me.Controls.Add(Me.btnFROMTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbLop_To)
        Me.Controls.Add(Me.dgvListHS_To)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbLop_FROM)
        Me.Controls.Add(Me.dgvListHS_FROM)
        Me.Controls.Add(Me.btnChuyenHS)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbKhoi)
        Me.Controls.Add(Me.cbHocKy)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbNamHoc)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmChuyenLop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chuyển Lớp"
        CType(Me.dgvListHS_FROM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListHS_To, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnChuyenHS As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cbKhoi As ComboBox
    Friend WithEvents cbHocKy As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbNamHoc As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvListHS_FROM As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents cbLop_FROM As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbLop_To As ComboBox
    Friend WithEvents dgvListHS_To As DataGridView
    Friend WithEvents btnFROMTo As Button
    Friend WithEvents btnToFROM As Button
End Class
