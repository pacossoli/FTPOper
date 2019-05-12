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
        Me.btUpload = New System.Windows.Forms.Button()
        Me.bgw = New System.ComponentModel.BackgroundWorker()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbInfoRemoteDir = New System.Windows.Forms.Label()
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
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btUpload
        '
        Me.btUpload.Location = New System.Drawing.Point(282, 266)
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
        Me.GroupBox3.Controls.Add(Me.lbInfoRemoteDir)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 122)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(379, 55)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Directorio remoto"
        '
        'lbInfoRemoteDir
        '
        Me.lbInfoRemoteDir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbInfoRemoteDir.Location = New System.Drawing.Point(6, 21)
        Me.lbInfoRemoteDir.Name = "lbInfoRemoteDir"
        Me.lbInfoRemoteDir.Size = New System.Drawing.Size(367, 21)
        Me.lbInfoRemoteDir.TabIndex = 0
        '
        'btConfig
        '
        Me.btConfig.Location = New System.Drawing.Point(282, 318)
        Me.btConfig.Name = "btConfig"
        Me.btConfig.Size = New System.Drawing.Size(110, 26)
        Me.btConfig.TabIndex = 6
        Me.btConfig.Text = "Configurar"
        Me.btConfig.UseVisualStyleBackColor = True
        '
        'rchInfo
        '
        Me.rchInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rchInfo.Location = New System.Drawing.Point(132, 32)
        Me.rchInfo.Name = "rchInfo"
        Me.rchInfo.ReadOnly = True
        Me.rchInfo.Size = New System.Drawing.Size(260, 72)
        Me.rchInfo.TabIndex = 8
        Me.rchInfo.Text = ""
        '
        'btSelectFolder
        '
        Me.btSelectFolder.Location = New System.Drawing.Point(12, 32)
        Me.btSelectFolder.Name = "btSelectFolder"
        Me.btSelectFolder.Size = New System.Drawing.Size(114, 33)
        Me.btSelectFolder.TabIndex = 9
        Me.btSelectFolder.Text = "Seleccionar carpeta"
        Me.btSelectFolder.UseVisualStyleBackColor = True
        '
        'btSelectFile
        '
        Me.btSelectFile.Location = New System.Drawing.Point(12, 71)
        Me.btSelectFile.Name = "btSelectFile"
        Me.btSelectFile.Size = New System.Drawing.Size(114, 33)
        Me.btSelectFile.TabIndex = 10
        Me.btSelectFile.Text = "Seleccionar archivo"
        Me.btSelectFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(129, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Informacion"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.SystemColors.Control
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 207)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(379, 26)
        Me.ProgressBar1.TabIndex = 13
        '
        'lbPorcentaje
        '
        Me.lbPorcentaje.Location = New System.Drawing.Point(170, 191)
        Me.lbPorcentaje.Name = "lbPorcentaje"
        Me.lbPorcentaje.Size = New System.Drawing.Size(156, 13)
        Me.lbPorcentaje.TabIndex = 13
        Me.lbPorcentaje.Text = "%"
        '
        'lbSubiendo
        '
        Me.lbSubiendo.AutoSize = True
        Me.lbSubiendo.Location = New System.Drawing.Point(103, 191)
        Me.lbSubiendo.Name = "lbSubiendo"
        Me.lbSubiendo.Size = New System.Drawing.Size(59, 13)
        Me.lbSubiendo.TabIndex = 14
        Me.lbSubiendo.Text = "subiendo..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 191)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Progreso general:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Resultado:"
        '
        'rchStatus
        '
        Me.rchStatus.BackColor = System.Drawing.SystemColors.Control
        Me.rchStatus.Location = New System.Drawing.Point(13, 266)
        Me.rchStatus.Name = "rchStatus"
        Me.rchStatus.Size = New System.Drawing.Size(263, 78)
        Me.rchStatus.TabIndex = 18
        Me.rchStatus.Text = ""
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 354)
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
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FTPOper for UCP"
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btUpload As Button
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lbInfoRemoteDir As Label
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
End Class
