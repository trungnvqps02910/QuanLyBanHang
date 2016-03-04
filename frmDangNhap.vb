Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Public Class frmDangNhap
    'Khai báo biến toàn cục để kết nối với CSDL
    Private _ConnectionString As String = ConfigurationSettings.AppSettings("MyConnectionString")
    Private conn As SqlConnection
    Private da As SqlDataAdapter

    'Định nghĩa hàm lấy dữ liệu đổ vào table
    Private Function getDataTable(sqlQuery As String) As DataTable
        Dim dTable As New DataTable
        conn = New SqlConnection(_ConnectionString)
        da = New SqlDataAdapter(sqlQuery, conn)
        Try
            conn.Open()
            da.Fill(dTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        Finally
            conn.Close()
        End Try
        Return dTable
    End Function

    'Định nghĩa hàm kiểm tra Use Pass có đúng hay không
    Private Function CheckLogin(user As String, pass As String)
        Dim sqlQuery As String = String.Format("select * from TaiKhoanDN WHERE TenDN = '{0}' and Pass = '{1}'", user, pass)
        Dim dTable As DataTable = getDataTable(sqlQuery)
        Return dTable.Rows.Count > 0
    End Function
    'Định nghĩa hàm kiểu tra Use Pass nhập vào có rổng hay không
    Private Function IsEmpty() As Boolean
        Return String.IsNullOrEmpty(Me.txtTaiKhoan.Text) OrElse String.IsNullOrEmpty(Me.txtMatKhau.Text)
    End Function

    Private Sub frmDangNhap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtTaiKhoan.Focus()
    End Sub

    Private Sub btnDangNhap_Click(sender As Object, e As EventArgs) Handles btnDangNhap.Click
        If IsEmpty() Then
            MessageBox.Show("Bạn chưa nhập tài khoản hoặc mật khẩu!")
        Else
            If CheckLogin(Me.txtTaiKhoan.Text.ToLower, Me.txtMatKhau.Text.ToLower) Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                MessageBox.Show("Chúc mừng bạn đã đăng nhập thành công")
                Me.Hide()
                frmDieuKhien.Show()
            Else
                MessageBox.Show("Tài khoản hoặc mật khẩu chưa đúng, vui lòng kiểm tra lại")
            End If
        End If
    End Sub

    Private Sub btnDong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDong.Click
        Dim ThongBao As DialogResult = New DialogResult()
        ThongBao = MessageBox.Show("Bạn thực sự muốn thoát khỏi phần mềm", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None)
        If ThongBao = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub
End Class
