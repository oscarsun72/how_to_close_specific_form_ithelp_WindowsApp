﻿Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim frm1 = Application.OpenForms("Form1")
        'frm1.Close() '不能關掉，因為是整個應用程式main()的入口，關掉Form1就等於結束應用程式了
        '除非在應用程式屬性中另外指派一個main()入口的物件（即在應用程式屬性中「啟動表單」的選項，不能設為Form1）
        '或在程式關閉模式，不要選擇「啟動表單關閉時」這個選項
        frm1.Visible = False
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Application.OpenForms.Count > 0 Then
            For Each f In Application.OpenForms
                If f.name = "Form1" Then
                    Dim frm1 = Application.OpenForms("Form1")
                    frm1.Visible = True
                End If
            Next f
        End If
    End Sub

    Private Sub Form2_DoubleClick(sender As Object, e As EventArgs) Handles MyBase.DoubleClick
        Dim frm1 = Application.OpenForms("Form1")
        frm1.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim opnfrm = Application.OpenForms
        For Each f In opnfrm
            If f.name <> Me.Name Then
                f.Close()
                If opnfrm.Count = 1 Then Exit For
            End If
        Next f
        Me.Close()
        'Application.Exit()'https://www.blueshop.com.tw/board/show.asp?subcde=BRD20190106120323AS3&fumcde=FUM20050124191756KKC
        'https://dotblogs.com.tw/ricochen/2010/01/18/13066
    End Sub
End Class