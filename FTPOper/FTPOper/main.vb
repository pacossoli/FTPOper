Imports System.Net
Imports System.IO
Imports FluentFTP
Imports FluentFTP.FtpProgress
Imports FluentFTP.Proxy
Imports System.ComponentModel

''' <summary>
''' Cada vez que el programa se inicia, se crea un archivo de logueo con el siguiente formato: log_yyyymmdd_hhmmss
''' 
''' Como se espera que este programa sea utilizado una vez al mes
''' se propone el siguiente funcionaminto:
''' Al seleccionar la carpeta que contienen los recibos del mes, los mismo se suben al servidor FTP y se guardan en un directorio 
''' cuyo nombre tendra el siguiente formato: yyyymmdd_HHmm  (AñoMesDia_Hora(formato 24 horas)Minutos)
''' 
''' no se como funciona la libreria de proxy
''' no se como funciona la libreria de progreso, si bien ya tengo implementado eso, pero quiero la otra
''' </summary>
''' 


Public Class main

    'Paths
    Dim localPath As String             'direccion en disco rigido local

    'variables para archivos
    Dim fileList As List(Of String) = New List(Of String)   'almacena todos los archivos de una carpeta
    Dim fileCount As Integer                                'almacena la cantidad de archivos de la carpeta o seleccionados
    Dim fileSize As Integer                                 'almacena el tamaño de todos los archivos o del archivo

    'logueo de datos
    Dim logFileName As String

    'error handling
    Dim errorType As Integer    '0 ninguno; 1=login incorrect; 2=error de subida de archivo




    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Control.CheckForIllegalCrossThreadCalls = False

        fechaActual = DateTime.Now.ToString("yyyyMMdd_HHmm")

        resetParameters()

        'activar servicio de logueo de interaccion con el servidor
        'FTPLogService()

        LoadConfig()

        remoteFolder = remoteFolder & "_" & fechaActual      'entonces la carpeta se llama: lo que puso el usuario _ 20190508_1752

        lbInfoRemoteDir.Text = FTPserver & "/" & remoteFolder

    End Sub




    '###################################################
    '#################-----BOTONES-----#################
    '###################################################

    Private Sub btSelectFolder_Click(sender As Object, e As EventArgs) Handles btSelectFolder.Click
        rchInfo.Clear()

        fileList.Clear()

        resetParameters()

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

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim aux As String = OpenFileDialog1.FileName        'obtiene full path del archivo 

        Dim file As New FileInfo(aux)                      'obtiene toda la info de ese archivo
        localPath = file.DirectoryName & "\"               'obtengo solo el path del directorio de donde esta el archivo
        fileList.Add(file.Name)                             'usamos la misma estructura que para multiples archivos
        fileSize = file.Length                             'tamaño del archivo
        fileCount = 1

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
        'jds
        Dim dialogConfig As New dlgConfig

        dialogConfig.ShowDialog()

        LoadConfig()

        remoteFolder = remoteFolder & "_" & fechaActual

        lbInfoRemoteDir.Text = FTPserver & "/" & remoteFolder

    End Sub

    Private Sub btUpload_Click(sender As Object, e As EventArgs) Handles btUpload.Click
        'bloqueamos los botones mientras se suben archivos
        btSelectFolder.Enabled = False
        btSelectFile.Enabled = False
        btUpload.Enabled = False

        bgw.RunWorkerAsync()

    End Sub



    '#################################################################
    '#################-----FUNCIONES PRINCIPALRD-----#################
    '#################################################################


    Private Sub mainUpload()

        Dim cliente As New FtpClient(FTPserver)

        cliente.Credentials = New NetworkCredential(FTPuser, FTPpassword)   'cargamos las credenciales

        Try
            cliente.Connect()

        Catch ex As Exception
            errorType = 1   'error de login
            bgw.CancelAsync()
            Exit Sub
        End Try


        'creamos carpeta en el servidor remoto
        remotePath = remoteFolder & "/"
        cliente.CreateDirectory(remotePath)

        'loop que recorre la lista de archivos y sube uno por uno
        Dim i As Integer
        Try
            For i = 0 To fileList.Count - 1
                cliente.UploadFile(localPath & fileList(i).ToString, remotePath & fileList(i).ToString)

                bgw.ReportProgress(i)
            Next

        Catch ex As Exception
            Debug.Print(ex.ToString)
            'en caso de que no se pueda subir algun archivo
            errorType = 2
            bgw.CancelAsync()
            Exit Sub
        End Try


        cliente.Disconnect()

        errorType = 0   'no error
    End Sub


    Private Sub bgw_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgw.DoWork

        mainUpload()

    End Sub


    Private Sub bgw_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgw.ProgressChanged

        lbSubiendo.Visible = True

        ProgressBar1.Value = e.ProgressPercentage
        lbPorcentaje.Text = "Total: " & e.ProgressPercentage & " de " & fileCount & " (" & Math.Round((ProgressBar1.Value * 100 / ProgressBar1.Maximum), 0) & "%)"

        lbPorcentaje.Update()
        ProgressBar1.Update()

    End Sub


    Private Sub bgw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted

        'los volvemos a habilitar una vez terminado el proceso
        btSelectFolder.Enabled = True
        btSelectFile.Enabled = True
        btUpload.Enabled = False

        Select Case errorType
            Case 0
                lbPorcentaje.Text = "Total: " & fileCount & " de " & fileCount & " (100%)"

                Dim str1 As String = "Proceso finalizado con exito"
                Dim str2 As String = "Total archivos subidos: "
                Dim str3 As String = "Directorio destino: "
                Dim str4 As String = "-----------########-----------"

                lbStatus.Text = str4 & vbCrLf & str1 & vbCrLf & str2 & fileCount & vbCrLf & str3 & remotePath & vbCrLf & str4
                ProgressBar1.Value = ProgressBar1.Maximum

            Case 1
                lbStatus.Text = "Error login: Usuario y/o Contraseña incorrectos"

            Case 2
                lbStatus.Text = "Error al subir archivo: Por favor, verifique su conexión a internet" & vbCrLf &
                    "Si el problema persiste, contacte a su proveedor de internet o al soporte técnico adecuado"
        End Select


    End Sub


    '############################################################
    '#################-----FUNCIONES VARIAS-----#################
    '############################################################


    'esto vamos a ver ultimo
    Private Sub FTPLogService()

        FtpTrace.LogFunctions = True
        FtpTrace.LogIP = True
        FtpTrace.LogUserName = True
        FtpTrace.LogPassword = False 'pasar a false despues 

        FtpTrace.LogFunctions = True
        FtpTrace.AddListener(New TextWriterTraceListener(logFileName))       'despues poner ruta para el archivo log

    End Sub


    Private Sub rchInfo_SelectionChanged(sender As Object, e As EventArgs) Handles rchInfo.SelectionChanged
        rchInfo.Select(rchInfo.SelectionStart, 0)
    End Sub


    Private Sub resetParameters()
        lbPorcentaje.Text = ""
        lbStatus.Text = ""
        lbSubiendo.Visible = False

        ProgressBar1.Minimum = 0
        ProgressBar1.Value = 0

        btUpload.Enabled = False

    End Sub


End Class