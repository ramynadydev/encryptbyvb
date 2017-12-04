Module Module1

    Sub Main()
        Console.WriteLine("enter your string to encrypt: ")
        Dim text As String = Console.ReadLine()
        Console.WriteLine(" string after encryption : " + util.Encrypt(text))
        Console.WriteLine("enter your string to decrypt: ")
        Dim texttodecrypt As String = Console.ReadLine()
        Console.WriteLine(" string after decryption : " + util.Decrypt(texttodecrypt))
        Console.ReadLine()

    End Sub

End Module
