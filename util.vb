Imports System.Security.Cryptography
Imports System.Text
Public Class util
    Private Shared PASSWORD_KEY As String = "test"

    Private Shared rawSecretKey As Byte() = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}


    Public Shared Function Encrypt(ByVal dencryptedBase64 As String) As String
        Dim passwordKey As Byte() = encodeDigest(PASSWORD_KEY)
        Dim rijndael As RijndaelManaged = New RijndaelManaged()
        Dim encryptorTransform As ICryptoTransform = rijndael.CreateEncryptor(passwordKey, rawSecretKey)
        Dim plainTextBytes As Byte() = Encoding.ASCII.GetBytes(dencryptedBase64)
        Dim newClearData As Byte() = encryptorTransform.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length)
        Return Convert.ToBase64String(newClearData)
    End Function
    Public Shared Function Decrypt(ByVal encryptedBase64 As String) As String
        Dim passwordKey As Byte() = encodeDigest(PASSWORD_KEY)
        Dim rijndael As RijndaelManaged = New RijndaelManaged()
        Dim rijndaelDecryptor As ICryptoTransform = rijndael.CreateDecryptor(passwordKey, rawSecretKey)
        Dim newClearData As Byte() = rijndaelDecryptor.TransformFinalBlock(Convert.FromBase64String(encryptedBase64), 0, Convert.FromBase64String(encryptedBase64).Length)
        Return Encoding.ASCII.GetString(newClearData)
    End Function

    Private Shared Function encodeDigest(ByVal text As String) As Byte()
        Dim x As MD5CryptoServiceProvider = New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim data As Byte() = Encoding.ASCII.GetBytes(text)
        Return x.ComputeHash(data)
    End Function
End Class
