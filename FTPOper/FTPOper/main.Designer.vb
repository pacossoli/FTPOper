<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.btUpload = New System.Windows.Forms.Button()
        Me.bgw = New System.ComponentModel.BackgroundWorker()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txInfoRemoteDir = New System.Windows.Forms.TextBox()
        Me.btConfig = New System.Windows.Forms.Button()
        Me.rchInfo = New System.Windows.Forms.RichTextBox()
        Me.btSelectFolder = New System.Windows.Forms.Button()
        Me.btSelectFile = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lbPorcentaje = New System.Windows.Forms.Label()
        Me.lbSubiendo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rchStatus = New System.Windows.Forms.RichTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btReportes = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btUpload
        '
        Me.btUpload.Location = New System.Drawing.Point(282, 260)
        Me.btUpload.Name = "btUpload"
        Me.btUpload.Size = New System.Drawing.Size(110, 46)
        Me.btUpload.TabIndex = 0
        Me.btUpload.Text = "Subir archivos"
        Me.btUpload.UseVisualStyleBackColor = True
        '
        'bgw
        '
        Me.bgw.WorkerReportsProgress = True
        Me.bgw.WorkerSupportsCancellation = True
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txInfoRemoteDir)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 116)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(379, 50)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Directorio remoto"
        '
        'txInfoRemoteDir
        '
        Me.txInfoRemoteDir.Location = New System.Drawing.Point(6, 19)
        Me.txInfoRemoteDir.Name = "txInfoRemoteDir"
        Me.txInfoRemoteDir.Size = New System.Drawing.Size(367, 20)
        Me.txInfoRemoteDir.TabIndex = 1
        '
        'btConfig
        '
        Me.btConfig.Location = New System.Drawing.Point(282, 312)
        Me.btConfig.Name = "btConfig"
        Me.btConfig.Size = New System.Drawing.Size(110, 26)
        Me.btConfig.TabIndex = 6
        Me.btConfig.Text = "Configurar"
        Me.btConfig.UseVisualStyleBackColor = True
        '
        'rchInfo
        '
        Me.rchInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rchInfo.Location = New System.Drawing.Point(132, 26)
        Me.rchInfo.Name = "rchInfo"
        Me.rchInfo.ReadOnly = True
        Me.rchInfo.Size = New System.Drawing.Size(260, 72)
        Me.rchInfo.TabIndex = 8
        Me.rchInfo.Text = ""
        '
        'btSelectFolder
        '
        Me.btSelectFolder.Location = New System.Drawing.Point(12, 26)
        Me.btSelectFolder.Name = "btSelectFolder"
        Me.btSelectFolder.Size = New System.Drawing.Size(114, 33)
        Me.btSelectFolder.TabIndex = 9
        Me.btSelectFolder.Text = "Seleccionar carpeta"
        Me.btSelectFolder.UseVisualStyleBackColor = True
        '
        'btSelectFile
        '
        Me.btSelectFile.Location = New System.Drawing.Point(12, 65)
        Me.btSelectFile.Name = "btSelectFile"
        Me.btSelectFile.Size = New System.Drawing.Size(114, 33)
        Me.btSelectFile.TabIndex = 10
        Me.btSelectFile.Text = "Seleccionar archivo"
        Me.btSelectFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(129, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Informacion"
        Me.Label1.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.SystemColors.Control
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 201)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(379, 26)
        Me.ProgressBar1.TabIndex = 13
        '
        'lbPorcentaje
        '
        Me.lbPorcentaje.Location = New System.Drawing.Point(170, 185)
        Me.lbPorcentaje.Name = "lbPorcentaje"
        Me.lbPorcentaje.Size = New System.Drawing.Size(156, 13)
        Me.lbPorcentaje.TabIndex = 13
        Me.lbPorcentaje.Text = "%"
        '
        'lbSubiendo
        '
        Me.lbSubiendo.AutoSize = True
        Me.lbSubiendo.Location = New System.Drawing.Point(103, 185)
        Me.lbSubiendo.Name = "lbSubiendo"
        Me.lbSubiendo.Size = New System.Drawing.Size(59, 13)
        Me.lbSubiendo.TabIndex = 14
        Me.lbSubiendo.Text = "subiendo..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 185)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Progreso general:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 240)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Resultado:"
        '
        'rchStatus
        '
        Me.rchStatus.BackColor = System.Drawing.SystemColors.Control
        Me.rchStatus.Location = New System.Drawing.Point(13, 260)
        Me.rchStatus.Name = "rchStatus"
        Me.rchStatus.Size = New System.Drawing.Size(263, 78)
        Me.rchStatus.TabIndex = 18
        Me.rchStatus.Text = ""
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Right
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(325, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(77, 385)
        Me.MenuStrip1.TabIndex = 19
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(64, 19)
        Me.AcercaDeToolStripMenuItem.Text = "Acerca de"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(445, 153)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 32)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(447, 209)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 31)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btReportes
        '
        Me.btReportes.Location = New System.Drawing.Point(13, 353)
        Me.btReportes.Name = "btReportes"
        Me.btReportes.Size = New System.Drawing.Size(379, 26)
        Me.btReportes.TabIndex = 22
        Me.btReportes.Text = "Bajar archivos de reportes de descargas"
        Me.btReportes.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(453, 252)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 27)
        Me.Button3.TabIndex = 23
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 385)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btReportes)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.rchStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbSubiendo)
        Me.Controls.Add(Me.lbPorcentaje)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btSelectFile)
        Me.Controls.Add(Me.btSelectFolder)
        Me.Controls.Add(Me.rchInfo)
        Me.Controls.Add(Me.btConfig)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btUpload)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FTPOper for UCP"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btUpload As Button
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btConfig As Button
    Friend WithEvents rchInfo As RichTextBox
    Friend WithEvents btSelectFolder As Button
    Friend WithEvents btSelectFile As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lbPorcentaje As Label
    Friend WithEvents lbSubiendo As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents rchStatus As RichTextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AcercaDeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents txInfoRemoteDir As TextBox
    Friend WithEvents btReportes As Button
    Friend WithEvents Button3 As Button
End Class
