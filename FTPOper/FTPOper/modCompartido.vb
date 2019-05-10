Imports System.IO

Module modCompartido


    Public ApplicationMainPath As String = Path.GetDirectoryName(Application.ExecutablePath)
    Private Const fileConfig = "\config\config.conf"

    'Config servidor FTP
    Public FTPserver As String
    Public FTPuser As String
    Public FTPpassword As String

    'Valores Default
    Private Const DefaultFTPServer = "ftp://ftp.carteled.com.ar"
    Private Const DefaultFTPuser = "ucptest@carteled.com.ar"
    Private Const DefaultFTPpassword = "UCPtest2019"
    Private Const DefaultRemoteFolder = "remoteFolder"
    'siguen...

    'not implemented yet
    Public proxy As String
    Public puerto As Integer


    'formato: raiz + remoteSubFolder + remoteFolder
    'para un user comun seria: /public_html/ucp/recibos_mes_tal
    'para un user admin seria: /ucp/recibos_mes_tal
    Public remotePath As String            'direccion en el servidor FTP remoteSubFolder + remoteFolder
    Public remoteFolder As String          'carpeta donde se van a guardar los archivos, debe ser creada en el momento con el nombre que se muestra en main

    Public fechaActual As String


    Public Sub LoadDefault()
        FTPserver = DefaultFTPServer
        FTPuser = DefaultFTPuser
        FTPpassword = DefaultFTPpassword

        remoteFolder = DefaultRemoteFolder

    End Sub

    Public Sub LoadConfig()
        Dim archivo As StreamReader
        Dim linea As String

        Dim path As String = ApplicationMainPath & fileConfig

        'estos es por si se quiere implementar una carga de valores default
        If Not File.Exists(path) Then
            'load config default
            LoadDefault()
            Exit Sub
        End If

        archivo = File.OpenText(path)

        Dim aux() As String

        While Not archivo.EndOfStream
            linea = archivo.ReadLine()
            aux = Split(linea, "=", -1)
            Select Case aux(0)
                Case "FTPserver"
                    FTPserver = aux(1)

                Case "FTPuser"
                    FTPuser = aux(1)

                Case "FTPpassword"
                    FTPpassword = aux(1)

                Case "remoteFolder"
                    remoteFolder = aux(1)

            End Select
        End While

        archivo.Close()
    End Sub

    Public Sub SaveConfig()
        Dim cadena As String

        cadena = "FTPserver=" & FTPserver & vbCrLf &
            "FTPuser=" & FTPuser & vbCrLf &
            "FTPpassword=" & FTPpassword & vbCrLf &
            "remoteFolder=" & remoteFolder & vbCrLf

        File.WriteAllText(ApplicationMainPath & fileConfig, cadena)

    End Sub


End Module
