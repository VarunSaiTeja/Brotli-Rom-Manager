Public Class Unpack
    Dim unpacker As New Process
    Dim command As String
    Dim Comp As Integer = 0
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Main.Show()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Main.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Brotli|*.br"

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Button2.Visible = True
            Button2.Select()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            Button3.Visible = True
            Button3.Select()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        command = "--decompress --in " + """" + OpenFileDialog1.FileName + """" + " --out " + """" + FolderBrowserDialog1.SelectedPath + "\system.new.dat" + """"
        unpacker.StartInfo.FileName = "brotli.exe"
        unpacker.StartInfo.Arguments = command
        unpacker.StartInfo.UseShellExecute = False
        unpacker.StartInfo.CreateNoWindow = True
        unpacker.Start()
        Me.Hide()
        Timer1.Start()
        UnpackLoad.Show()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If unpacker.HasExited = True Then
            UnpackLoad.Close()
            Me.Close()
            Main.Show()
            Timer1.Stop()

        End If
    End Sub
End Class