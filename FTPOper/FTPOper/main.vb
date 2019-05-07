Imports System.Net
Imports System.IO
Imports FluentFTP
Imports System.ComponentModel

Public Class main

    Dim user As String = "px000629"
    Dim pass As String = "XandroXi9j"
    Dim remotePath As String = "/recibos/"
    Dim localPath As String = "C:\recibos\"

    Dim fileList As List(Of String) = New List(Of String)
    Dim fileCount As Integer
    Dim fileSize As Integer

    Dim list1 As List(Of String) = New List(Of String)



    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 30

        Dim file_ As New DirectoryInfo(localPath)

        For Each item In file_.GetFiles
            list1.Add(localPath & item.ToString)
            'list1.Add(item.ToString)
        Next

        ProgressBar1.Maximum = list1.Count

    End Sub


    '###################################################
    '#################-----BOTONES-----#################
    '###################################################


    Private Sub btSelectFolder_Click(sender As Object, e As EventArgs) Handles btSelectFolder.Click
        txInfoSourceSelected.Text = ""
        fileList.Clear()

        'si cancela la pantalla
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        localPath = FolderBrowserDialog1.SelectedPath & "\"
        txInfoSourceSelected.Text = txInfoSourceSelected.Text & "Ruta de origen: " & vbCrLf & localPath & vbCrLf

        Dim file_ As New DirectoryInfo(localPath)   'info del directorio

        fileCount = file_.GetFiles.Count
        txInfoSourceSelected.Text = txInfoSourceSelected.Text & "Cantidad de archivos: " & fileCount & vbCrLf

        For Each item In file_.GetFiles
            fileList.Add(item.ToString)
            Dim aux As New FileInfo(localPath & item.ToString)      'info de cada archivo
            fileSize = fileSize + aux.Length
        Next

        txInfoSourceSelected.Text = txInfoSourceSelected.Text & "Tamaño total a subir: " & Math.Round(fileSize / 1000000, 2) & "MB"

    End Sub



    Private Sub btUpload_Click(sender As Object, e As EventArgs) Handles btUpload.Click

        'bgw.RunWorkerAsync()

        ftpfunc()

    End Sub


    Private Sub ftpfunc()

        Dim cliente As New FtpClient("ftp://ftp.carteled.com.ar")

        cliente.Credentials = New NetworkCredential(user, pass)

        cliente.Connect()
        cliente.CreateDirectory(remotePath)

        'For i As Integer = 0 To list1.Count - 1
        'Debug.Print(list1(i).ToString)
        'cliente.UploadFile(localPath & list1(i).ToString, remotePath & list1(i).ToString)
        'bgw.ReportProgress(i)
        'Next


        cliente.UploadFiles(list1, remotePath)

        'cliente.GetListing()

        cliente.Disconnect()

    End Sub





    Private Sub UpSingleFile()
        'Upload File to FTP site
        'Create Request To Upload File'
        Dim wrUpload As FtpWebRequest = DirectCast(WebRequest.Create("ftp://ftp.carteled.com.ar/pdf.pdf"), FtpWebRequest)

        'Specify Username & Password'
        wrUpload.Credentials = New NetworkCredential("px000629", "XandroXi9j")

        'Start Upload Process'
        wrUpload.Method = WebRequestMethods.Ftp.UploadFile

        'Locate File And Store It In Byte Array'
        Dim btfile() As Byte = File.ReadAllBytes("c:\pdf.pdf")

        'Get File'
        Dim strFile As Stream = wrUpload.GetRequestStream()

        'Upload Each Byte'
        strFile.Write(btfile, 0, btfile.Length)

        'Close'
        strFile.Close()

        'Free Memory'
        strFile.Dispose()
    End Sub





    Private Sub bgw_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgw.DoWork
        '
        ftpfunc()


    End Sub

    Private Sub bgw_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgw.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        ProgressBar1.Update()

    End Sub

    Private Sub bgw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
        Label1.Text = "done"
    End Sub


End Class
