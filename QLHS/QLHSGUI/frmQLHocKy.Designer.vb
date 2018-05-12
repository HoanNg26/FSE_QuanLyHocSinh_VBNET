<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQLHocKy
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
        Me.dgvListHocKy = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbNamHocFilter = New System.Windows.Forms.ComboBox()
        Me.txtMaHocKy = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTenHocKy = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvListHocKy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(291, 384)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(99, 23)
        Me.btnXoa.TabIndex = 39
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(168, 384)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(75, 23)
        Me.btnCapNhat.TabIndex = 38
        Me.btnCapNhat.Text = "Cập nhật"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'dgvListHocKy
        '
        Me.dgvListHocKy.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvListHocKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListHocKy.Location = New System.Drawing.Point(65, 80)
        Me.dgvListHocKy.MultiSELECT = False
        Me.dgvListHocKy.Name = "dgvListHocKy"
        Me.dgvListHocKy.ReadOnly = True
        Me.dgvListHocKy.RowHeadersVisible = False
        Me.dgvListHocKy.SELECTionMode = System.Windows.Forms.DataGridViewSELECTionMode.FullRowSELECT
        Me.dgvListHocKy.Size = New System.Drawing.Size(379, 190)
        Me.dgvListHocKy.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(111, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Năm Học:"
        '
        'cbNamHocFilter
        '
        Me.cbNamHocFilter.FormattingEnabled = True
        Me.cbNamHocFilter.Location = New System.Drawing.Point(168, 24)
        Me.cbNamHocFilter.Name = "cbNamHocFilter"
        Me.cbNamHocFilter.Size = New System.Drawing.Size(176, 21)
        Me.cbNamHocFilter.TabIndex = 25
        '
        'txtMaHocKy
        '
        Me.txtMaHocKy.Location = New System.Drawing.Point(168, 281)
        Me.txtMaHocKy.Name = "txtMaHocKy"
        Me.txtMaHocKy.ReadOnly = True
        Me.txtMaHocKy.Size = New System.Drawing.Size(162, 20)
        Me.txtMaHocKy.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(86, 288)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Mã Học Kỳ:"
        '
        'txtTenHocKy
        '
        Me.txtTenHocKy.Location = New System.Drawing.Point(168, 328)
        Me.txtTenHocKy.Name = "txtTenHocKy"
        Me.txtTenHocKy.Size = New System.Drawing.Size(222, 20)
        Me.txtTenHocKy.TabIndex = 41
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(86, 335)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Tên Học Kỳ:"
        '
        'frmQLHocKy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 454)
        Me.Controls.Add(Me.txtMaHocKy)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTenHocKy)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnCapNhat)
        Me.Controls.Add(Me.dgvListHocKy)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbNamHocFilter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmQLHocKy"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quản lý Học Kỳ"
        CType(Me.dgvListHocKy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnXoa As Button
    Friend WithEvents btnCapNhat As Button
    Friend WithEvents dgvListHocKy As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents cbNamHocFilter As ComboBox
    Friend WithEvents txtMaHocKy As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTenHocKy As TextBox
    Friend WithEvents Label2 As Label
End Class
