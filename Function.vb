Imports System.Data.SqlClient
Imports System.Data
Public Class Class1
    Public Function LoadKhachHang() As DataSet
        Dim ChuoiKetNoi As String = "Data Source=CHIP-PC;Initial Catalog=QLBH;Integrated Security=True"
        Dim Conn As SqlConnection = New SqlConnection(ChuoiKetNoi)
        Dim LoadKH As New SqlDataAdapter("select MAKH as 'Mã KH' ,TENKH as 'Tên KH', DIACHI as 'Địa chỉ', SDT as 'SĐT', EMAIL from KHACHHANG", Conn)
        Dim DB As New DataSet
        Conn.Open()
        LoadKH.Fill(DB)
        Conn.Close()
        Return DB
    End Function
    Public Function LoadSanPham() As DataSet
        Dim ChuoiKetNoi As String = "Data Source=CHIP-PC;Initial Catalog=QLBH;Integrated Security=True"
        Dim Conn As SqlConnection = New SqlConnection(ChuoiKetNoi)
        Dim LoadSP As New SqlDataAdapter("select SANPHAM.MASP as 'Mã SP',SANPHAM.TENSP as 'Tên SP', LOAISANPHAM.MALOAI as 'Mã Loại', LOAISANPHAM.TENLOAI as 'Tên Loại',SANPHAM.SOLUONG as 'Số lượng' from SANPHAM inner join LOAISANPHAM on SANPHAM.MASP = LOAISANPHAM.MASP", Conn)
        Dim DB As New DataSet
        Conn.Open()
        LoadSP.Fill(DB)
        Conn.Close()
        Return DB
    End Function
End Class