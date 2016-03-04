Public Class frmDieuKhien
    Private Sub ThôngTinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThôngTinToolStripMenuItem.Click
        frmKhachHang.Show()
    End Sub

    Private Sub CâpNhâtToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CâpNhâtToolStripMenuItem1.Click
        frmCapNhatKH.Show()
    End Sub

    Private Sub ThôngTinToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ThôngTinToolStripMenuItem1.Click
        frmSanPham.Show()
    End Sub

    Private Sub CâpNhâtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CâpNhâtToolStripMenuItem.Click
        frmCapNhatSP.Show()
    End Sub

End Class