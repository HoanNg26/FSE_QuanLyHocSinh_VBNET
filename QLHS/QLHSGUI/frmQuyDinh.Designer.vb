<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuyDinh
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
        Me.txtSoKhoiToiDa = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSoHKToiDa = New System.Windows.Forms.TextBox()
        Me.btnCapNhat = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtSoKhoiToiDa
        '
        Me.txtSoKhoiToiDa.Location = New System.Drawing.Point(171, 60)
        Me.txtSoKhoiToiDa.Name = "txtSoKhoiToiDa"
        Me.txtSoKhoiToiDa.Size = New System.Drawing.Size(131, 20)
        Me.txtSoKhoiToiDa.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Số Khối tối đa:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Số Học Kỳ tối đa:"
        '
        'txtSoHKToiDa
        '
        Me.txtSoHKToiDa.Location = New System.Drawing.Point(168, 106)
        Me.txtSoHKToiDa.Name = "txtSoHKToiDa"
        Me.txtSoHKToiDa.Size = New System.Drawing.Size(131, 20)
        Me.txtSoHKToiDa.TabIndex = 2
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(182, 155)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(75, 23)
        Me.btnCapNhat.TabIndex = 4
        Me.btnCapNhat.Text = "Cập Nhật"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'frmQuyDinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 262)
        Me.Controls.Add(Me.btnCapNhat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSoHKToiDa)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSoKhoiToiDa)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmQuyDinh"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thay đổi Quy Định"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSoKhoiToiDa As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSoHKToiDa As TextBox
    Friend WithEvents btnCapNhat As Button
End Class
