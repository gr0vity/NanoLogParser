<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddLogs
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnAddLogs = New System.Windows.Forms.Button()
        Me.rtbParseResult = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'btnAddLogs
        '
        Me.btnAddLogs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddLogs.Location = New System.Drawing.Point(13, 13)
        Me.btnAddLogs.Name = "btnAddLogs"
        Me.btnAddLogs.Size = New System.Drawing.Size(659, 25)
        Me.btnAddLogs.TabIndex = 0
        Me.btnAddLogs.Text = "Add Log File"
        Me.btnAddLogs.UseVisualStyleBackColor = True
        '
        'rtbParseResult
        '
        Me.rtbParseResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbParseResult.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbParseResult.Location = New System.Drawing.Point(13, 42)
        Me.rtbParseResult.Name = "rtbParseResult"
        Me.rtbParseResult.Size = New System.Drawing.Size(659, 457)
        Me.rtbParseResult.TabIndex = 1
        Me.rtbParseResult.Text = ""
        '
        'AddLogs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 511)
        Me.Controls.Add(Me.rtbParseResult)
        Me.Controls.Add(Me.btnAddLogs)
        Me.Name = "AddLogs"
        Me.Text = "Nano Vote Tally Stats"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddLogs As Button
    Friend WithEvents rtbParseResult As RichTextBox
End Class
