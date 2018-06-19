Public Class AddLogs

    Private dialog As OpenFileDialog
    Private parser As Parser

    Public Sub New()
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        Me.dialog = New OpenFileDialog With {
            .Filter = "Log files (*.log, *.txt) | *.txt; *.log",
            .InitialDirectory = "%localappdata%/Raiblocks/Log",
            .Title = "Please select Nano log file."
        }
        Me.parser = New Parser


    End Sub


    Private Sub BtnAddLogs_Click(sender As Object, e As EventArgs) Handles btnAddLogs.Click
        If dialog.ShowDialog() = DialogResult.OK Then
            rtbParseResult.Text = Me.parser.MainParser(Me.dialog.FileName)
        End If
    End Sub
End Class
