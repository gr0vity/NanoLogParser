Imports System.Text

Public Class Parser

    Public Function MainParser(ByVal logPath As String)
        Dim rootHashes As List(Of Roots) = ParseLog(logPath)
        Return FormatLines(rootHashes)
    End Function


    Private Function ParseLog(ByVal logPath As String)
        '// Example : Blocks of 3
        '[2018-06-19 07:59:00.590919]: Vote tally for root EFFA83930622E3382C2A6225B02F3775D29F7ACB66BC966A36EA9B2D68B57F5D
        '[2018-06-19 07:59:00.590919]: Block CE60306CE16CB5747761668B61FB2BBB0111ECEB2AE9544F6B97F3E8296D3F89 weight 62760938652018138618517505923027737748
        '[2018-06-19 07:59:00.590919]: Block CE60306CE16CB5747761668B61FB2BBB0111ECEB2AE9544F6B97F3E8296D3F89 weight 2995797432616901947492720726502205412

        Dim allLines As String() = IO.File.ReadAllLines(logPath)
        Dim i As Integer = 0
        Dim add As Boolean = False

        Dim lstRoot As New List(Of Roots)
        Dim root As New Roots
        For Each line In allLines
            If add = True Then
                If i > 0 Then
                    If line.Contains(" Rolling back") Then
                        root.rolledBack = "ROLLED_BACK"
                        Continue For
                    End If
                    root.blocks.Add(New Roots.Block With {.hash = line.Split(" ")(3),
                                                          .weight = (Single.Parse(line.Split(" ")(5)) / (1.33 * 10 ^ 38)) * 100,
                                                          .dateString = line.Substring(0, 28)})
                    i -= 1
                    If i = 0 Then lstRoot.Add(root)
                End If
            End If
            If line.Contains("Vote tally for root") Then
                root = New Roots
                root.root = line.Split(" ")(6)
                add = True
                i = 2
            End If
        Next
        Return lstRoot
    End Function

    Private Function FormatLines(ByVal lstRoot As List(Of Roots)) As String
        Dim sb As New StringBuilder
        Dim gRoots = lstRoot.GroupBy(Function(x) x.root).OrderByDescending(Function(x) x.Count)
        sb.AppendLine(New String("ˉ", 80))
        sb.AppendLine(" NANO Node Vote Tallies → Grouped by [Root Hash] → Sorted by [Timestamp]")
        sb.AppendLine(New String("ˍ", 80))
        For Each group In gRoots '// Group by ROOT HASH
            sb.AppendLine(String.Format("{0,5}x ROOT: {1}", group.Count, group.Key))
            Dim addLine As Boolean = True

            For Each forkGroup In group.GroupBy(Function(x) String.Join("", x.blocks.Select((Function(b) b.hash)))) '// Group by FORK BLOCKS (usually always the same)
                For Each rootBlock In forkGroup
                    If addLine Then '//
                        sb.AppendLine(String.Format(" MAIN BLOCK: {1,64} {0} FORK BLOCK: {2,64}",
                                                vbCrLf,
                                                rootBlock.blocks(0).hash,
                                                rootBlock.blocks(1).hash))
                        sb.AppendLine(String.Format("{0,14}  | {1,14}  | {2,30}", "MAIN BLOCK", "FORK BLOCK", "TIMESTAMP"))
                    End If
                    sb.AppendLine(String.Format("{0,14}% | {1,14}% | {2,30}", rootBlock.blocks(0).weight.ToString("0.00"), rootBlock.blocks(1).weight.ToString("0.00"), rootBlock.blocks(0).dateString))
                    addLine = False
                Next
                addLine = True
            Next
            addLine = True
            sb.AppendLine(New String("-", 80))
            sb.AppendLine(New String("-", 80))
        Next
        Return sb.ToString()
    End Function




    '// Parser Structure
    Public Class Roots
        Sub New()
            _blocks = New List(Of Block)
        End Sub
        Private _root As String
        Public Property root() As String
            Get
                Return _root
            End Get
            Set(ByVal value As String)
                _root = value
            End Set
        End Property
        Private _blocks As List(Of Block)
        Public Property blocks() As List(Of Block)
            Get
                Return _blocks
            End Get
            Set(ByVal value As List(Of Block))
                _blocks = value
            End Set
        End Property
        Private _rolledBack As String
        Public Property rolledBack() As String
            Get
                Return _rolledBack
            End Get
            Set(ByVal value As String)
                _rolledBack = value
            End Set
        End Property


        Partial Class Block
            Private _hash As String
            Public Property hash() As String
                Get
                    Return _hash
                End Get
                Set(ByVal value As String)
                    _hash = value
                End Set
            End Property
            Private _weight As Single
            Public Property weight() As Single
                Get
                    Return _weight
                End Get
                Set(ByVal value As Single)
                    _weight = value
                End Set
            End Property
            Private _dateString As String
            Public Property dateString() As String
                Get
                    Return _dateString
                End Get
                Set(ByVal value As String)
                    _dateString = value
                End Set
            End Property
            Private _rolledBack As String
        End Class
    End Class
End Class
