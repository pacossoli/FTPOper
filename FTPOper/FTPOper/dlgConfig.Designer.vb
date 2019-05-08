<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgConfig
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txPuerto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txProxy = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chProxy = New System.Windows.Forms.CheckBox()
        Me.btVerPass = New System.Windows.Forms.Button()
        Me.txFTPpassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txFTPuser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txFTPserver = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbFolderInfo = New System.Windows.Forms.Label()
        Me.txRemoteFolder = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btDefaultConfig = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 274)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txPuerto)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txProxy)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.chProxy)
        Me.GroupBox1.Controls.Add(Me.btVerPass)
        Me.GroupBox1.Controls.Add(Me.txFTPpassword)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txFTPuser)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txFTPserver)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 125)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configurar FTP"
        '
        'txPuerto
        '
        Me.txPuerto.Enabled = False
        Me.txPuerto.Location = New System.Drawing.Point(331, 96)
        Me.txPuerto.Name = "txPuerto"
        Me.txPuerto.Size = New System.Drawing.Size(70, 20)
        Me.txPuerto.TabIndex = 11
        Me.txPuerto.Text = "8080"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(284, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Puerto:"
        '
        'txProxy
        '
        Me.txProxy.Enabled = False
        Me.txProxy.Location = New System.Drawing.Point(58, 96)
        Me.txProxy.Name = "txProxy"
        Me.txProxy.Size = New System.Drawing.Size(220, 20)
        Me.txProxy.TabIndex = 9
        Me.txProxy.Text = "proxy.ejemplo.com"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Servidor:"
        '
        'chProxy
        '
        Me.chProxy.AutoSize = True
        Me.chProxy.Location = New System.Drawing.Point(9, 76)
        Me.chProxy.Name = "chProxy"
        Me.chProxy.Size = New System.Drawing.Size(77, 17)
        Me.chProxy.TabIndex = 7
        Me.chProxy.Text = "Usar Proxy"
        Me.chProxy.UseVisualStyleBackColor = True
        '
        'btVerPass
        '
        Me.btVerPass.Location = New System.Drawing.Point(370, 42)
        Me.btVerPass.Name = "btVerPass"
        Me.btVerPass.Size = New System.Drawing.Size(31, 19)
        Me.btVerPass.TabIndex = 6
        Me.btVerPass.Text = "Ver"
        Me.btVerPass.UseVisualStyleBackColor = True
        '
        'txFTPpassword
        '
        Me.txFTPpassword.Location = New System.Drawing.Point(249, 42)
        Me.txFTPpassword.Name = "txFTPpassword"
        Me.txFTPpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txFTPpassword.Size = New System.Drawing.Size(115, 20)
        Me.txFTPpassword.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(179, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Contraseña:"
        '
        'txFTPuser
        '
        Me.txFTPuser.Location = New System.Drawing.Point(58, 42)
        Me.txFTPuser.Name = "txFTPuser"
        Me.txFTPuser.Size = New System.Drawing.Size(115, 20)
        Me.txFTPuser.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Usuario:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Servidor:"
        '
        'txFTPserver
        '
        Me.txFTPserver.Location = New System.Drawing.Point(58, 19)
        Me.txFTPserver.Name = "txFTPserver"
        Me.txFTPserver.Size = New System.Drawing.Size(343, 20)
        Me.txFTPserver.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbFolderInfo)
        Me.GroupBox2.Controls.Add(Me.txRemoteFolder)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 146)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 119)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Configurar carpeta remota"
        '
        'lbFolderInfo
        '
        Me.lbFolderInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbFolderInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFolderInfo.Location = New System.Drawing.Point(13, 46)
        Me.lbFolderInfo.Name = "lbFolderInfo"
        Me.lbFolderInfo.Size = New System.Drawing.Size(387, 70)
        Me.lbFolderInfo.TabIndex = 5
        Me.lbFolderInfo.Text = "Label9"
        '
        'txRemoteFolder
        '
        Me.txRemoteFolder.Location = New System.Drawing.Point(73, 21)
        Me.txRemoteFolder.Name = "txRemoteFolder"
        Me.txRemoteFolder.Size = New System.Drawing.Size(327, 20)
        Me.txRemoteFolder.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(-3, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 30)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Carpeta contenedora"
        '
        'btDefaultConfig
        '
        Me.btDefaultConfig.Location = New System.Drawing.Point(12, 282)
        Me.btDefaultConfig.Name = "btDefaultConfig"
        Me.btDefaultConfig.Size = New System.Drawing.Size(82, 21)
        Me.btDefaultConfig.TabIndex = 3
        Me.btDefaultConfig.Text = "Default"
        Me.btDefaultConfig.UseVisualStyleBackColor = True
        '
        'dlgConfig
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 315)
        Me.Controls.Add(Me.btDefaultConfig)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgConfig"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuracion general"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txFTPserver As TextBox
    Friend WithEvents txPuerto As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txProxy As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chProxy As CheckBox
    Friend WithEvents btVerPass As Button
    Friend WithEvents txFTPpassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txFTPuser As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lbFolderInfo As Label
    Friend WithEvents txRemoteFolder As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btDefaultConfig As Button
End Class
