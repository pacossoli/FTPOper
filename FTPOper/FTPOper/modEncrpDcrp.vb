Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module modEncrpDcrp
    Public key() As Byte = {}                                                  'aca guardamos los bytes correspondientes a la clave de encriptación
    Public IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}     'vector de inicializacion, podemos cambiar despues
    Public Ekey As String = "abcdefgh"





    ''' <summary>
    ''' http://devcity.net/PrintArticle.aspx?ArticleID=47
    ''' Codigo extraido de esa pagina
    ''' </summary>
    ''' <param name="stringToEncrypt"></param>
    ''' <param name="EncryptionKey"></param>
    ''' <returns></returns>
    Public Function Encrypt(ByVal stringToEncrypt As String, ByVal EncryptionKey As String) As String
        Try
            key = Encoding.UTF8.GetBytes(Left(EncryptionKey, 8))                                    'obtiene una cadena de bytes correspondientes a la clave de encriptacion
            Dim des As New DESCryptoServiceProvider()                                               'brinda acceso al servicio criptografico
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(stringToEncrypt)                  'obtiene una cadena de bytes correspondientes al texto que se quiere encriptar
            Dim ms As New MemoryStream()                                                            'stream de memoria
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write)    'crea un stream de criptografia con el encriptador en modo escritura y el destino es el stream de memoria
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function


    Public Function Encrypt(ByVal byteToEncrypt() As Byte, ByVal EncryptionKey As String) As Byte()
        Try
            key = Encoding.UTF8.GetBytes(Left(EncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider()
            Dim inputByteArray() As Byte = byteToEncrypt
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return ms.ToArray()
        Catch e As Exception
            'Return 0
        End Try
    End Function

    Public Function Decrypt(ByVal stringToDecrypt As String, ByVal EncryptionKey As String) As String
        Dim inputByteArray(stringToDecrypt.Length) As Byte                                              'obtiene la cantidad de bytes para decodificar
        Try
            key = Text.Encoding.UTF8.GetBytes(Left(EncryptionKey, 8))                                   'obtiene una cadena de bytes correspondientes a la clave de encriptacion
            Dim des As New DESCryptoServiceProvider()                                                   'brinda acceso al servicio criptografico
            inputByteArray = Convert.FromBase64String(stringToDecrypt)                                  'obtiene una cadena de bytes correspondientes al texto que se quiere desencriptar
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function


    Public Function Decrypt(ByVal byteToDecrypt() As Byte, ByVal EncryptionKey As String) As Byte()
        Dim inputByteArray(byteToDecrypt.Length) As Byte
        Try
            key = Text.Encoding.UTF8.GetBytes(Left(EncryptionKey, 8))                                   'obtiene una cadena de bytes correspondientes a la clave de encriptacion
            Dim des As New DESCryptoServiceProvider()                                                   'brinda acceso al servicio criptografico
            inputByteArray = byteToDecrypt                                  'obtiene una cadena de bytes correspondientes al texto que se quiere desencriptar
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return ms.ToArray()
        Catch e As Exception
            'Return e.Message
        End Try
    End Function

End Module
