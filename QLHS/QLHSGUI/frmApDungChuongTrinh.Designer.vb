<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmApDungChuongTrinh
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvListApDung = New System.Windows.Forms.DataGridView()
        Me.btnXacNhan = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbKhoi = New System.Windows.Forms.ComboBox()
        Me.cbHocKy = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbNamHoc = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbChuongTrinh = New System.Windows.Forms.ComboBox()
        CType(Me.dgvListApDung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "Danh sách Lớp:"
        '
        'dgvListApDung
        '
        Me.dgvListApDung.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvListApDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListApDung.Location = New System.Drawing.Point(26, 116)
        Me.dgvListApDung.MultiSelect = False
        Me.dgvListApDung.Name = "dgvListApDung"
        Me.dgvListApDung.RowHeadersVisible = False
        Me.dgvListApDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListApDung.Size = New System.Drawing.Size(580, 325)
        Me.dgvListApDung.TabIndex = 84
        '
        'btnXacNhan
        '
        Me.btnXacNhan.Location = New System.Drawing.Point(269, 457)
        Me.btnXacNhan.Name = "btnXacNhan"
        Me.btnXacNhan.Size = New System.Drawing.Size(93, 23)
        Me.btnXacNhan.TabIndex = 83
        Me.btnXacNhan.Text = "Xác Nhận"
        Me.btnXacNhan.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(146, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Khối:"
        '
        'cbKhoi
        '
        Me.cbKhoi.FormattingEnabled = True
        Me.cbKhoi.Location = New System.Drawing.Point(195, 12)
        Me.cbKhoi.Name = "cbKhoi"
        Me.cbKhoi.Size = New System.Drawing.Size(125, 21)
        Me.cbKhoi.TabIndex = 77
        '
        'cbHocKy
        '
        Me.cbHocKy.FormattingEnabled = True
        Me.cbHocKy.Location = New System.Drawing.Point(333, 50)
        Me.cbHocKy.Name = "cbHocKy"
        Me.cbHocKy.Size = New System.Drawing.Size(153, 21)
        Me.cbHocKy.TabIndex = 81
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "Năm Học:"
        '
        'cbNamHoc
        '
        Me.cbNamHoc.FormattingEnabled = True
        Me.cbNamHoc.Location = New System.Drawing.Point(87, 50)
        Me.cbNamHoc.Name = "cbNamHoc"
        Me.cbNamHoc.Size = New System.Drawing.Size(153, 21)
        Me.cbNamHoc.TabIndex = 79
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(266, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Học Kỳ:"
        '
        'cbChuongTrinh
        '
        Me.cbChuongTrinh.FormattingEnabled = True
        Me.cbChuongTrinh.Location = New System.Drawing.Point(436, 459)
        Me.cbChuongTrinh.Name = "cbChuongTrinh"
        Me.cbChuongTrinh.Size = New System.Drawing.Size(125, 21)
        Me.cbChuongTrinh.TabIndex = 87
        Me.cbChuongTrinh.Visible = False
        '
        'frmApDungChuongTrinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 501)
        Me.Controls.Add(Me.cbChuongTrinh)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvListApDung)
        Me.Controls.Add(Me.btnXacNhan)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbKhoi)
        Me.Controls.Add(Me.cbHocKy)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbNamHoc)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmApDungChuongTrinh"
        Me.Text = "Áp dụng chương trình"
        CType(Me.dgvListApDung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvListApDung As DataGridView
    Friend WithEvents btnXacNhan As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cbKhoi As ComboBox
    Friend WithEvents cbHocKy As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbNamHoc As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbChuongTrinh As ComboBox
End Class
