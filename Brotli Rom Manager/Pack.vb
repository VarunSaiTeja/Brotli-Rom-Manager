Public Class Pack
    Dim packer As New Process
    Dim command As String

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Main.Show()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Main.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Dat|*.dat"
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
        command = "--in " + """" + OpenFileDialog1.FileName + """" + " --out " + """" + FolderBrowserDialog1.SelectedPath + "\system.new.dat.br" + """" + " --quality 0"

        packer.StartInfo.FileName = "brotli.exe"
        packer.StartInfo.Arguments = command
        packer.StartInfo.UseShellExecute = False
        packer.StartInfo.CreateNoWindow = True
        packer.Start()
        Me.Hide()
        Timer1.Start()
        PackLoad.Show()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If packer.HasExited = True Then
            PackLoad.Close()
            Me.Close()
            Main.Show()
            Timer1.Stop()

        End If
    End Sub
End Class