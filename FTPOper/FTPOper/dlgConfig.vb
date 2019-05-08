Imports System.Windows.Forms



Public Class dlgConfig


    Private Sub dlgConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadConfig()
        Var2Tx()
        lbFolderInfo.Text = ""

    End Sub



    Private Sub btVerPass_MouseDown(sender As Object, e As MouseEventArgs) Handles btVerPass.MouseDown
        'mostrar contraseña
        txFTPpassword.PasswordChar = ""
    End Sub

    Private Sub btVerPass_MouseUp(sender As Object, e As MouseEventArgs) Handles btVerPass.MouseUp
        'ocultar contraseña
        txFTPpassword.PasswordChar = "*"
    End Sub



    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

        tx2Var()
        SaveConfig()

    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub btDefaultConfig_Click(sender As Object, e As EventArgs) Handles btDefaultConfig.Click
        LoadDefault()
        Var2Tx()
    End Sub


    Private Sub tx2Var()
        'pushVars saca de los textbox y los guarda en las variables
        FTPserver = txFTPserver.Text
        FTPuser = txFTPuser.Text
        FTPpassword = txFTPpassword.Text

        'not implemented yet
        proxy = txProxy.Text
        puerto = txPuerto.Text

        remoteFolder = txRemoteFolder.Text

    End Sub

    Private Sub Var2Tx()
        'pullVars saca de las variables y los escribe en los textbox
        txFTPserver.Text = FTPserver
        txFTPuser.Text = FTPuser
        txFTPpassword.Text = FTPpassword

        txRemoteFolder.Text = remoteFolder
    End Sub






    Private Sub chProxy_CheckedChanged(sender As Object, e As EventArgs) Handles chProxy.CheckedChanged
        If chProxy.Checked = True Then
            txProxy.Enabled = True
            txPuerto.Enabled = True
        Else
            txProxy.Enabled = False
            txPuerto.Enabled = False
            txProxy.Text = "proxy.ejemplo.com"
            txPuerto.Text = "8080"
        End If
    End Sub


    Private Sub txProxy_Click(sender As Object, e As EventArgs) Handles txProxy.Click
        txProxy.Text = ""
    End Sub

    Private Sub txProxy_LostFocus(sender As Object, e As EventArgs) Handles txProxy.LostFocus
        If txProxy.Text = "" Then   'si no escribimos nada...
            txProxy.Text = "proxy.ejemplo.com"
            chProxy.Checked = False
        Else
            'guardar en la variable
        End If
    End Sub



    Private Sub txPuerto_Click(sender As Object, e As EventArgs) Handles txPuerto.Click
        txPuerto.Text = ""
    End Sub

    Private Sub txPuerto_LostFocus(sender As Object, e As EventArgs) Handles txPuerto.LostFocus
        If txPuerto.Text = "" Then      'si no escribimos nada...
            txPuerto.Text = "8080"
            chProxy.Checked = False
        Else
            'guardar en la variable
        End If
    End Sub



    Private Sub txRemoteFolder_Click(sender As Object, e As EventArgs) Handles txRemoteFolder.Click
        '
        lbFolderInfo.Text = "El nombre que ingrese + fecha_hora será utilizado para crear una carpeta cada vez que suba archivos" & vbCrLf &
            "Puede ingresar sub carpetas (existentes o no) + / (barra). Ver ejemplo--->" & vbCrLf &
            txFTPserver.Text & "/" & txRemoteFolder.Text & "_" & fechaActual

    End Sub

    Private Sub txRemoteFolder_TextChanged(sender As Object, e As EventArgs) Handles txRemoteFolder.TextChanged
        lbFolderInfo.Text = "El nombre que ingrese + fecha_hora será utilizado para crear una carpeta cada vez que suba archivos" & vbCrLf &
            "Puede ingresar sub carpetas (existentes o no) + / (barra). Ver ejemplo--->" & vbCrLf &
            txFTPserver.Text & "/" & txRemoteFolder.Text & "_" & fechaActual

    End Sub
End Class
