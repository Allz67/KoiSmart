using KoiSmart.Controllers;
using KoiSmart.Models;
using KoiSmart.Views.Components;

namespace KoiSmart.Views
{
    public partial class V_TransaksiPenjualan : Form
    {
        private TransaksiController _transController;

        public V_TransaksiPenjualan()
        {
            InitializeComponent();
            _transController = new TransaksiController();
            LoadTransaksiPenjualan();
        }

        private void LoadTransaksiPenjualan()
        {
            FlpTransPenjualan.Controls.Clear();

            List<RiwayatTransaksi> list = _transController.GetAllRiwayat();

            if (list == null || list.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Belum ada transaksi.";
                lblEmpty.AutoSize = true;
                lblEmpty.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblEmpty.Margin = new Padding(20);
                FlpTransPenjualan.Controls.Add(lblEmpty);
                return;
            }

            foreach (var trx in list)
            {
                CardTransaksi card = new CardTransaksi();
                card.SetData(trx);

                // optional: hook event to show detail
                card.OnViewDetails += (s, e) =>
                {
                    MessageBox.Show($"Detail Transaksi #{card.DataTrx.IdTransaksi}\nStatus: {card.DataTrx.Status}\nTotal: Rp {card.DataTrx.TotalBelanja:N0}",
                                    "Detail Transaksi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                // adjust width so cards fit
                card.Width = Math.Max(FlpTransPenjualan.Width - 30, 300);
                FlpTransPenjualan.Controls.Add(card);
            }
        }

        private void BtnTransaksiPenjualan_Click(object sender, EventArgs e)
        {

        }

        private void BtnHalamanUtama_Click(object sender, EventArgs e)
        {

        }
    }
}
