Imports System.Net
Imports System.IO
Imports FluentFTP
Imports FluentFTP.FtpProgress
Imports FluentFTP.Proxy
Imports System.ComponentModel

''' <summary>
''' Cada vez que el programa se inicia, se crea un archivo de logueo con el siguiente formato: log_yyyymmdd_hhmmss 'NO ESTA IMPLEMENTADO
''' 
''' A pesar de que el software se deberia usar una vez al mes
''' puede darse el caso de que se quieran subir mas archivos en el mes o 
''' se haya perdido conexion y deba reiniciarse el proceso.
''' Por lo tanto se propone el siguiente funcionaminto:
''' Al seleccionar la carpeta que contienen los recibos del mes, los mismo se suben al servidor FTP y se guardan en un directorio *VER NOTA1
''' cuyo nombre tendra el siguiente formato: yyyymm (AñoMes) de esa forma
''' si queren agregar mas archivos, siempre y cuando sean del mismo mes, se agregan solos a la misma carpeta
''' Ademas, facilita volver a subir archivos si se perdio la conexion a internet y se quieren volver a subir archivos
''' En definitiva, el usuario cuenta con un mes de tiempo para poder subir archivos dentro de la misma carpeta.
''' 
''' no se como funciona la libreria de proxy
''' no se como funciona la libreria de progreso, si bien ya tengo implementado eso, pero quiero la otra
''' 
''' NOTA1
''' antes de subir los archivos en crudo, vamos a hacer una carpeta temporal (o no) donde guarden los archivos encripados
''' y esa carpeta es la que se sube
''' por lo tanto va a cambiar la variable localPath
''' o podemos hacer otra que sea localPathEncrypted
''' 
''' PROCESO DE ENCRIPTACION
''' Cuando el usuario selecciona una carpeta o un archivo, la lista de archivos se guarda en fileList, tomamos ese path y se lo pasamos a la funcion que encripta
''' la funcion que encripta, toma una archivo de ese path, lo encripta y lo guarda en otra carpeta
''' esa carpeta es la que se sube
''' La lista de archivos: fileList tiene solo los nombres de los archivos
''' por lo tanto, podemos usar esa misma lista para encriptar y subir
''' solo hay que cambiar el path de donde se lee
''' si encriptamos leemos del localPath
''' si subimos leemos del localPathEncrypted
''' </summary>
''' 


Public Class main

    'Paths
    Dim localPath As String                                 'direccion en disco rigido local
    Dim localPathEncrypted As String
    Dim localPathReports As String = "C:\_reports\"
    Dim localPathReportsTemp As String = "C:\_reports_temp\"
    Dim clienteFTP As FtpClient

    'variables para archivos
    Dim fileList As List(Of String) = New List(Of String)   'almacena todos los archivos de una carpeta
    Dim fileCount As Integer                                'almacena la cantidad de archivos de la carpeta o seleccionados
    Dim fileSize As Integer                                 'almacena el tamaño de todos los archivos o del archivo

    'error handling
    Dim errorType As Integer    '0 ninguno; 1=login incorrect; 2=error de subida de archivo

    'objeto para la clase de encriptación
    Dim objCODEC As New CODEControl.CODEControl


    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Control.CheckForIllegalCrossThreadCalls = False

        'solo vamos a usar el mes
        fechaActual = DateTime.Now.ToString("yyyyMM")

        resetParameters()

        'activar servicio de logueo de interaccion con el servidor
        'FTPLogService()

        LoadConfig()

        remoteFolder = remoteFolder & "_" & fechaActual      'entonces la carpeta se llama: lo que puso el usuario _ 20190508_1752

        txInfoRemoteDir.Text = "/" & remoteFolder

    End Sub




    Private Sub main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If clearEncryptedFiles() = True Then
            End
        End If
    End Sub


    '###################################################
    '#################-----BOTONES-----#################
    '###################################################


    Private Sub txInfoRemoteDir_TextChanged(sender As Object, e As EventArgs) Handles txInfoRemoteDir.TextChanged
        remoteFolder = txInfoRemoteDir.Text
    End Sub


    Private Sub btSelectFolder_Click(sender As Object, e As EventArgs) Handles btSelectFolder.Click
        rchInfo.Clear()

        fileList.Clear()

        resetParameters()

        createTempFolder()

        'si cancela la pantalla
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        localPath = FolderBrowserDialog1.SelectedPath & "\"                 'obtengo el path del directorio seleccionado

        Dim file As New DirectoryInfo(localPath)                           'info del directorio

        fileCount = file.GetFiles.Count                                    'contamos la cantidad de archivos

        'listamos todos los archivos y sumamos el tamaño de cada uno
        For Each item In file.GetFiles
            fileList.Add(item.ToString)
            Dim aux As New FileInfo(localPath & item.ToString)      'info de cada archivo
            fileSize = fileSize + aux.Length
        Next

        'textos
        Dim str1 As String = "Ruta de origen: " 'localPath
        Dim str2 As String = "Cantidad de archivos: " 'fileCount
        Dim str3 As String = "Tamaño total a subir: " ' fileSize

        rchInfo.AppendText(str1 & vbCrLf & localPath & vbCrLf & str2 & fileCount & vbCrLf & str3 & Math.Round(fileSize / 1000000, 2) & "MB")
        rchInfo.SelectionProtected = True

        'recien activamos el boton de subir
        btUpload.Enabled = True
        btUpload.Text = "Subir archivos"

        ProgressBar1.Maximum = fileCount - 1
    End Sub


    Private Sub btSelectFile_Click(sender As Object, e As EventArgs) Handles btSelectFile.Click
        rchInfo.Clear()

        fileList.Clear()

        resetParameters()

        OpenFileDialog1.Filter = "Archivos .pdf | *.pdf"

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim aux As String = OpenFileDialog1.FileName        'obtiene full path del archivo 

        Dim file As New FileInfo(aux)                      'obtiene toda la info de ese archivo
        localPath = file.DirectoryName & "\"               'obtengo solo el path del directorio de donde esta el archivo
        fileList.Add(file.Name)                            'usamos la misma estructura que para multiples archivos
        fileSize = file.Length                             'tamaño del archivo
        fileCount = 1                                       'porque hay un solo archivo seleccionado

        Dim str1 As String = "Path del archivo de origen: " 'localPath
        Dim str2 As String = "Tamaño total a subir: " ' fileSize

        rchInfo.AppendText(str1 & vbCrLf & localPath & fileList(0).ToString & vbCrLf & str2 & Math.Round(fileSize / 1000, 2) & "kB")
        rchInfo.SelectionProtected = True

        'recien activamos el boton de subir
        btUpload.Enabled = True
        btUpload.Text = "Subir archivo"

        ProgressBar1.Maximum = 1
    End Sub


    Private Sub btConfig_Click(sender As Object, e As EventArgs) Handles btConfig.Click
        Dim dialogConfig As New dlgConfig

        dialogConfig.ShowDialog()

        LoadConfig()

        remoteFolder = remoteFolder & "_" & fechaActual

        txInfoRemoteDir.Text = "/" & remoteFolder

    End Sub


    Private Sub btUpload_Click(sender As Object, e As EventArgs) Handles btUpload.Click
        'bloqueamos los botones mientras se suben archivos
        btSelectFolder.Enabled = False
        btSelectFile.Enabled = False
        btUpload.Enabled = False

        lbSubiendo.Text = "Conectando..."

        bgw.RunWorkerAsync()

    End Sub


    Private Sub btReportes_Click(sender As Object, e As EventArgs) Handles btReportes.Click
        Dim filesInRemoteFolder() As FtpListItem

        clienteFTP = New FtpClient(FTPserver)

        clienteFTP.Credentials = New NetworkCredential(FTPuser, FTPpassword)   'cargamos las credenciales

        Try
            clienteFTP.Connect()

            filesInRemoteFolder = clienteFTP.GetListing(reportPath, FtpListOption.Recursive)

            For Each file In filesInRemoteFolder
                clienteFTP.DownloadFile(localPathReportsTemp & file.Name, file.FullName)
                desencriptarContenido(localPathReportsTemp, file.Name)
            Next

            Directory.Delete(localPathReportsTemp, True)

        Catch ex As Exception
            errorType = 1   'error de login
            Exit Sub
        End Try

        Dim result As DialogResult = MsgBox("Precione Aceptar para ver la carpeta de resultados", MsgBoxStyle.OkOnly, "Descarga finalizada")
        If result = DialogResult.OK Then
            Process.Start("explorer.exe", localPathReports)
        End If

    End Sub



    '#################################################################
    '#################-----FUNCIONES PRINCIPALES-----#################
    '#################################################################


    Private Sub mainFunction()

        'Conexión
        'Dim cliente As New FtpClient(FTPserver)
        clienteFTP = New FtpClient(FTPserver)

        clienteFTP.Credentials = New NetworkCredential(FTPuser, FTPpassword)   'cargamos las credenciales

        Try
            clienteFTP.Connect()

        Catch ex As Exception
            errorType = 1   'error de login
            bgw.CancelAsync()
            Exit Sub
        End Try

        'creamos carpeta en el servidor remoto
        remotePath = remoteFolder & "/"
        clienteFTP.CreateDirectory(remotePath)

        clienteFTP.RetryAttempts = 2

        'loop que recorre la lista de archivos, encripta uno y lo sube, and so
        Dim i As Integer
        Try
            For i = 0 To fileList.Count - 1

                'encript
                encryptFile(i)

                'upload
                uploadFile(i)

                bgw.ReportProgress(i)
            Next

        Catch ex As Exception
            Debug.Print(ex.ToString)
            'en caso de que no se pueda subir algun archivo
            errorType = 2
            bgw.CancelAsync()
            clearEncryptedFiles()
            Exit Sub
        End Try


        clienteFTP.Disconnect()

        errorType = 0   'no error
    End Sub


    Private Sub encryptFile(i As Integer)
        'recibo como parámetro la posición i del nombre de archivo que esta en la lista fileList
        'luego, le agrego el resto del path y encripto
        'C/ftpopertemp/fileList(i)
        Dim path As String = localPath & fileList(i)
        Dim data() As Byte = File.ReadAllBytes(path)    'leo el archivo
        Dim dataEncrypt() As Byte = objCODEC.Encrypt(data) 'encripto todo
        'ahora ese dataEncrypt lo tengo que tirar dentro de un archivo
        File.WriteAllBytes(localPathEncrypted & fileList(i).ToString(), dataEncrypt)
    End Sub


    Private Sub uploadFile(i As Integer)
        'FtpExist.Append verifica si existe, si existe y le faltan datos, los sube el archivo de nuevo.
        'FtpVerify.Retry reintenta subir un archivo cuando no coinciden los hash, pero el servidor debe soportar hash
        'antes del upload, tengo que implementar mi función de encriptacion de pdf
        clienteFTP.UploadFile(localPathEncrypted & fileList(i).ToString, remotePath & fileList(i).ToString, FtpExists.Append, True, FtpVerify.Retry)
    End Sub




    Private Sub bgw_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgw.DoWork

        mainFunction()

    End Sub


    Private Sub bgw_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgw.ProgressChanged

        'lbSubiendo.Visible = True

        ProgressBar1.Value = e.ProgressPercentage
        lbPorcentaje.Text = "Total: " & e.ProgressPercentage & " de " & fileCount & " (" & Math.Round((ProgressBar1.Value * 100 / ProgressBar1.Maximum), 0) & "%)"

        lbPorcentaje.Update()
        ProgressBar1.Update()

        lbSubiendo.Text = "Subiendo..."
        lbSubiendo.Update()

    End Sub


    Private Sub bgw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted

        'los volvemos a habilitar una vez terminado el proceso
        btSelectFolder.Enabled = True
        btSelectFile.Enabled = True
        btUpload.Enabled = False

        Select Case errorType
            Case 0 'no error
                rchStatus.BackColor = Color.Green
                lbPorcentaje.Text = "Total: " & fileCount & " de " & fileCount & " (100%)"

                Dim str1 As String = "Proceso finalizado con exito"
                Dim str2 As String = "Total archivos subidos con exito: "
                Dim str3 As String = "Directorio destino: "
                Dim str4 As String = "-----------########-----------"

                ProgressBar1.Value = ProgressBar1.Maximum
                ProgressBar1.Update()

                rchStatus.Text = str4 & vbCrLf & str1 & vbCrLf & str2 & fileCount & vbCrLf & str3 & remotePath & vbCrLf & str4

                lbSubiendo.Text = "Finalizado"
            Case 1
                rchStatus.BackColor = Color.Orange
                rchStatus.Text = "Error login: Usuario y/o Contraseña incorrectos"

            Case 2 'error en uploadMain

                rchStatus.BackColor = Color.Red
                rchStatus.Text = "Error al subir archivo: Por favor, verifique su conexión a internet" & vbCrLf &
                    "O intente subir los archivos nuevamente en otro momento." & vbCrLf &
                    "Si el problema persiste, contacte a su proveedor de internet o al soporte técnico adecuado"
        End Select

        clearEncryptedFiles()

    End Sub


    '############################################################
    '#################-----FUNCIONES VARIAS-----#################
    '############################################################


    Private Sub rchInfo_SelectionChanged(sender As Object, e As EventArgs) Handles rchInfo.SelectionChanged
        rchInfo.Select(rchInfo.SelectionStart, 0)
    End Sub


    Private Sub resetParameters()
        lbPorcentaje.Text = ""
        rchStatus.Text = ""
        rchStatus.BackColor = SystemColors.Control

        ProgressBar1.Minimum = 0
        ProgressBar1.Value = 0

        btUpload.Enabled = False
        lbSubiendo.Text = ""
    End Sub


    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        Dim frmAbout As New frmAbout
        frmAbout.ShowDialog()
    End Sub





    Private Function clearEncryptedFiles() As Boolean
        Try
            Directory.Delete(localPathEncrypted, True)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub decryptFile(path As String)

        Dim data() As Byte = File.ReadAllBytes(path)    'leo el archivo
        Dim dataEncrypt() As Byte = objCODEC.Decrypt(data)

        'ahora ese dataEncrypt lo tengo que tirar dentro de un archivo
        File.WriteAllBytes("C:\recuperado.pdf", dataEncrypt)
        'en si, es la función, solo que no esta terminada
    End Sub


    Private Sub desencriptarContenido(path As String, fileName As String)
        Dim archivo As StreamReader
        Dim linea As String
        Dim str As String = ""

        archivo = File.OpenText(path & fileName)

        While Not archivo.EndOfStream
            linea = archivo.ReadLine()
            str = str & objCODEC.Decrypt(linea) & vbCrLf
        End While

        If Not Directory.Exists(localPathReports) Then
            MkDir(localPathReports)
        End If

        File.WriteAllText(localPathReports & fileName, str)

        archivo.Close()

    End Sub


    Private Sub createTempFolder()
        localPathEncrypted = "C:/_ftpopertemp/"

        MkDir(localPathEncrypted)
        SetAttr(localPathEncrypted, FileAttribute.Hidden)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim path As String = "C:\pdf1.pdf"
        Dim data() As Byte = File.ReadAllBytes(path)    'leo el archivo

        'Dim dataEncrypt() As Byte = Encrypt(data, Ekey) 'encripto todo
        Dim dataEncrypt() As Byte = objCODEC.Encrypt(data)
        'ahora ese dataEncrypt lo tengo que tirar dentro de un archivo
        File.WriteAllBytes("C:\pdf1_encr.pdf", dataEncrypt)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim path As String = "C:\DownloadReport_201907.txt"
        Dim data() As Byte = File.ReadAllBytes(path)    'leo el archivo
        Dim data2 As String = File.ReadAllText(path)
        data2 = data2.Replace(vbCrLf, "")
        'Dim dataEncrypt() As Byte = Decrypt(data, Ekey) 'encripto todo
        'Dim dataEncrypt() As Byte = objCODEC.Decrypt(data)
        Dim decryptedStr As String = objCODEC.Decrypt(data2)

        'ahora ese dataEncrypt lo tengo que tirar dentro de un archivo
        'File.WriteAllBytes("C:\recuperado.txt", dataEncrypt)
        File.WriteAllText("C:\recuperado.txt", decryptedStr)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clienteFTP = New FtpClient(FTPserver)

        clienteFTP.Credentials = New NetworkCredential(FTPuser, FTPpassword)   'cargamos las credenciales

        clienteFTP.Connect()
        Dim server As FtpServer
        server = clienteFTP.ServerType
        Dim rta As Boolean = clienteFTP.RecursiveList

        'Dim files() As FtpListItem

        'funcion
        Dim folders() As FtpListItem
        Dim files() As FtpListItem
        folders = clienteFTP.GetListing("/ucp")

        For Each item In folders
            Dim aux As String = item.FullName
            files = clienteFTP.GetListing(aux)
        Next


    End Sub



End Class