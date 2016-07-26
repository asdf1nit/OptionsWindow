
Public Class Window1


    Dim parentWindow As MainWindow
    Private Sub buttonClose_Click(sender As Object, e As RoutedEventArgs) Handles buttonClose.Click
        Me.Close()
    End Sub

    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click
        If textBox.Text.Length < 4 Then
            textBox.AppendText("1")
        End If
    End Sub

    Private Sub button2_Click(sender As Object, e As RoutedEventArgs) Handles button2.Click
        If textBox.Text.Length < 4 Then
            textBox.AppendText("2")
        End If
    End Sub

    Private Sub button3_Click(sender As Object, e As RoutedEventArgs) Handles button3.Click
        If textBox.Text.Length < 4 Then
            textBox.AppendText("3")
        End If
    End Sub

    Private Sub button4_Click(sender As Object, e As RoutedEventArgs) Handles button4.Click
        If textBox.Text.Length < 4 Then
            textBox.AppendText("4")
        End If
    End Sub

    Private Sub button5_Click(sender As Object, e As RoutedEventArgs) Handles button5.Click
        If textBox.Text.Length < 4 Then
            textBox.AppendText("5")
        End If
    End Sub

    Private Sub button6_Click(sender As Object, e As RoutedEventArgs) Handles button6.Click
        If textBox.Text.Length < 4 Then
            textBox.AppendText("6")
        End If
    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        If textBox.Text.Length < 4 Then
            textBox.AppendText("7")
        End If
    End Sub

    Private Sub button8_Click(sender As Object, e As RoutedEventArgs) Handles button8.Click
        If textBox.Text.Length < 4 Then
            textBox.AppendText("8")
        End If
    End Sub

    Private Sub button9_Click(sender As Object, e As RoutedEventArgs) Handles button9.Click
        If textBox.Text.Length < 4 Then
            textBox.AppendText("9")
        End If
    End Sub

    Private Sub buttonEnter_Click(sender As Object, e As RoutedEventArgs) Handles buttonEnter.Click
        Dim p As New OptionsWindow.MainWindow
        If textBox.Text.Length = 4 Then

            If textBox.Text = "2147" Then
                p.ChangeButtons(True)
                p.checkBox.IsChecked = True
                Me.Close()

            ElseIf textBox.Text = "7853" Then

                p.Close()

                For Each prog As Process In Process.GetProcesses
                    If prog.ProcessName = "OptionsWindow" Then
                        prog.Kill()
                    End If
                Next
                Me.Close()
            Else
                textBox.Text = ""
                Threading.Thread.Sleep(2000)
            End If
        End If
    End Sub

    Private Sub buttonDel_Click(sender As Object, e As RoutedEventArgs) Handles buttonDel.Click
        With textBox
            If .Text.Length > 0 Then
                .Text = .Text.Trim().Substring(0, .Text.Length - 1)
            End If

        End With
    End Sub
End Class
