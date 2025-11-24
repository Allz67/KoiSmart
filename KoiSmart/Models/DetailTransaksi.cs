using KoiSmart.Models;

public class DetailTransaksi
{
    public int IdDetail { get; set; }
    public int IdTransaksi { get; set; }
    public int IdIkan { get; set; }
    public int JumlahPembelian { get; set; }
    public decimal Subtotal { get; set; }
}