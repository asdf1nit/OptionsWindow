Imports System.Windows.Threading
Imports System.ComponentModel

Class MainWindow

    Implements INotifyPropertyChanged
    Public WithEvents frmCode As New Window1
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Shared showButtonsValue As Boolean

    Public Property ShowButtons() As Boolean
        Get
            Return showButtonsValue
        End Get
        Set(ByVal value As Boolean)
            showButtonsValue = value
            OnPropertyChanged1("ShowButtons")
        End Set
    End Property

    Protected Friend Sub OnPropertyChanged1(ByVal IsChecked As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(IsChecked))
    End Sub

    Private Sub Options_Window_Loaded(sender As Object, e As RoutedEventArgs) Handles Options_Window.Loaded

    End Sub

    Private Sub btnOSK_Click(sender As Object, e As RoutedEventArgs) Handles btnOSK.Click

        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start(osk)
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start(osk)
        End If
    End Sub

    Private Sub btnAppLoad_Click(sender As Object, e As RoutedEventArgs) Handles btnAppLoad.Click
        Try
            Process.Start("C:\Users\checkin\Google Drive\Scripts\AppLoad.exe")
        Catch exp As Exception
            MsgBox("Excetpion Thrown: " & vbCrLf & exp.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnTaskMngr_Click(sender As Object, e As RoutedEventArgs) Handles btnTaskMngr.Click
        Try
            Process.Start("C:\Windows\System32\taskmgr.exe")
        Catch exp As Exception
            MsgBox("Excetpion Thrown: " & vbCrLf & exp.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnRestart__Click(sender As Object, e As RoutedEventArgs) Handles btnRestart_.Click
        Try
            System.Diagnostics.Process.Start("shutdown", "-f -t 0 -r")
        Catch exp As Exception
            MsgBox("Excetpion Thrown: " & vbCrLf & exp.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnExplorer_Click(sender As Object, e As RoutedEventArgs) Handles btnExplorer.Click
        Try
            Process.Start("explorer")
        Catch exp As Exception
            MsgBox("Excetpion Thrown: " & vbCrLf & exp.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnPass_Click(sender As Object, e As RoutedEventArgs) Handles btnPass.Click

        If frmCode.IsActive = False Then
            Dim frmCode = New Window1
            frmCode.Owner = Me
            frmCode.Show()
        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As RoutedEventArgs) Handles btnExit.Click

        For Each prog As Process In Process.GetProcesses
            If prog.ProcessName = "OptionsWindow" Then
                prog.Kill()
            End If
        Next
        Me.Close()
    End Sub

    Public Function ChangeButtons(ByVal x As Boolean)
        showButtonsValue = True
        ShowButtons() = True
        OnPropertyChanged1("ShowButtons")
    End Function

    Private Sub btnPass_Copy_Click(sender As Object, e As RoutedEventArgs) Handles btnLock.Click
        showButtonsValue = False
        ShowButtons() = False
        OnPropertyChanged1("ShowButtons")
    End Sub
End Class
