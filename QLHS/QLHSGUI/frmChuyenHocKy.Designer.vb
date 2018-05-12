<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChuyenHocKy
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbNamHoc = New System.Windows.Forms.ComboBox()
        Me.cbTuHocKy = New System.Windows.Forms.ComboBox()
        Me.cbSangHocKy = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbKhoi = New System.Windows.Forms.ComboBox()
        Me.btnThemLopVaChuyenHS = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Từ Học Kỳ:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(93, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Năm Học:"
        '
        'cbNamHoc
        '
        Me.cbNamHoc.FormattingEnabled = True
        Me.cbNamHoc.Location = New System.Drawing.Point(151, 48)
        Me.cbNamHoc.Name = "cbNamHoc"
        Me.cbNamHoc.Size = New System.Drawing.Size(153, 21)
        Me.cbNamHoc.TabIndex = 29
        '
        'cbTuHocKy
        '
        Me.cbTuHocKy.FormattingEnabled = True
        Me.cbTuHocKy.Location = New System.Drawing.Point(96, 89)
        Me.cbTuHocKy.Name = "cbTuHocKy"
        Me.cbTuHocKy.Size = New System.Drawing.Size(109, 21)
        Me.cbTuHocKy.TabIndex = 31
        '
        'cbSangHocKy
        '
        Me.cbSangHocKy.FormattingEnabled = True
        Me.cbSangHocKy.Location = New System.Drawing.Point(293, 89)
        Me.cbSangHocKy.Name = "cbSangHocKy"
        Me.cbSangHocKy.Size = New System.Drawing.Size(115, 21)
        Me.cbSangHocKy.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(214, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Sang Học Kỳ:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(118, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Khối:"
        '
        'cbKhoi
        '
        Me.cbKhoi.FormattingEnabled = True
        Me.cbKhoi.Location = New System.Drawing.Point(159, 10)
        Me.cbKhoi.Name = "cbKhoi"
        Me.cbKhoi.Size = New System.Drawing.Size(125, 21)
        Me.cbKhoi.TabIndex = 57
        '
        'btnThemLopVaChuyenHS
        '
        Me.btnThemLopVaChuyenHS.Location = New System.Drawing.Point(130, 132)
        Me.btnThemLopVaChuyenHS.Name = "btnThemLopVaChuyenHS"
        Me.btnThemLopVaChuyenHS.Size = New System.Drawing.Size(185, 23)
        Me.btnThemLopVaChuyenHS.TabIndex = 59
        Me.btnThemLopVaChuyenHS.Text = "Thêm Lớp và Chuyển Học Sinh"
        Me.btnThemLopVaChuyenHS.UseVisualStyleBackColor = True
        '
        'frmChuyenHocKy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 201)
        Me.Controls.Add(Me.btnThemLopVaChuyenHS)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbKhoi)
        Me.Controls.Add(Me.cbSangHocKy)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbTuHocKy)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbNamHoc)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmChuyenHocKy"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chuyển Học Kỳ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cbNamHoc As ComboBox
    Friend WithEvents cbTuHocKy As ComboBox
    Friend WithEvents cbSangHocKy As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbKhoi As ComboBox
    Friend WithEvents btnThemLopVaChuyenHS As Button
End Class
