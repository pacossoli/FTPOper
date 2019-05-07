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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bgw = New System.ComponentModel.BackgroundWorker()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txInfoSourceSelected = New System.Windows.Forms.TextBox()
        Me.btSelectFolder = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbInfoFile = New System.Windows.Forms.Label()
        Me.btSelectFile = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btUpload
        '
        Me.btUpload.Location = New System.Drawing.Point(358, 298)
        Me.btUpload.Name = "btUpload"
        Me.btUpload.Size = New System.Drawing.Size(111, 30)
        Me.btUpload.TabIndex = 0
        Me.btUpload.Text = "Subir "
        Me.btUpload.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(293, 307)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'bgw
        '
        Me.bgw.WorkerReportsProgress = True
        Me.bgw.WorkerSupportsCancellation = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txInfoSourceSelected)
        Me.GroupBox1.Controls.Add(Me.btSelectFolder)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(463, 86)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Subir múltiples archivos"
        '
        'txInfoSourceSelected
        '
        Me.txInfoSourceSelected.BackColor = System.Drawing.SystemColors.Control
        Me.txInfoSourceSelected.Enabled = False
        Me.txInfoSourceSelected.Location = New System.Drawing.Point(6, 22)
        Me.txInfoSourceSelected.Multiline = True
        Me.txInfoSourceSelected.Name = "txInfoSourceSelected"
        Me.txInfoSourceSelected.ReadOnly = True
        Me.txInfoSourceSelected.Size = New System.Drawing.Size(373, 58)
        Me.txInfoSourceSelected.TabIndex = 1
        '
        'btSelectFolder
        '
        Me.btSelectFolder.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btSelectFolder.Location = New System.Drawing.Point(385, 22)
        Me.btSelectFolder.Name = "btSelectFolder"
        Me.btSelectFolder.Size = New System.Drawing.Size(72, 38)
        Me.btSelectFolder.TabIndex = 0
        Me.btSelectFolder.Text = "Seleccionar carpeta"
        Me.btSelectFolder.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbInfoFile)
        Me.GroupBox2.Controls.Add(Me.btSelectFile)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 133)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(463, 67)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Subir un archivo"
        '
        'lbInfoFile
        '
        Me.lbInfoFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbInfoFile.Location = New System.Drawing.Point(6, 20)
        Me.lbInfoFile.Name = "lbInfoFile"
        Me.lbInfoFile.Size = New System.Drawing.Size(373, 37)
        Me.lbInfoFile.TabIndex = 1
        Me.lbInfoFile.Text = "Label2"
        '
        'btSelectFile
        '
        Me.btSelectFile.Location = New System.Drawing.Point(385, 20)
        Me.btSelectFile.Name = "btSelectFile"
        Me.btSelectFile.Size = New System.Drawing.Size(72, 38)
        Me.btSelectFile.TabIndex = 0
        Me.btSelectFile.Text = "Seleccionar archivo"
        Me.btSelectFile.UseVisualStyleBackColor = True
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 376)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btUpload)
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "main"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btUpload As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btSelectFolder As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lbInfoFile As Label
    Friend WithEvents btSelectFile As Button
    Friend WithEvents txInfoSourceSelected As TextBox
End Class
