Module Module1

    Sub Main()
        Console.WriteLine("EXIF reader version {0}", My.Application.Info.Version)
        Console.WriteLine("(c) Michal Valasek - Altair Communications, 2003-2006 | www.altaircom.net")
        Console.WriteLine()

        If Environment.GetCommandLineArgs.Length = 1 Then
            ' Show help
            Console.WriteLine("Syntax: exread.exe filename")
            Console.WriteLine("filename - name of image to process")
            Terminate()
        End If

        ' Get & check file name
        Dim FileName As String = ""
        Try
            FileName = Environment.GetCommandLineArgs()(1)
            If Not System.IO.File.Exists(FileName) Then Terminate("Error: File not found")
        Catch ex As Exception
            Terminate("Error: Can't read filename (expected as 1st argument)")
        End Try

        ' Display EXIF metadata
        Try
            Dim EW As New ExifWorks(FileName)
            Console.WriteLine(EW.ToString())
            EW.Dispose()
        Catch ex As Exception
            Terminate("Error: Expection while reading EXIF metadata: " & ex.Message)
        End Try
    End Sub

    Sub Terminate(Optional ByVal Reason As String = Nothing)
        If Not Reason Is Nothing Then Console.WriteLine(Reason)
        Environment.Exit(0)
    End Sub

End Module
