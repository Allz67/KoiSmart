using KoiSmart.Models; // Akses RiwayatTransaksi
using KoiSmart.Views.Components; // Akses CardTransaksiItem
using System;
using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Windows.Forms;

namespace KoiSmart.Views.Components
{
    public partial class CardTransaksi : UserControl
    {
        // Property buat menyimpan data transaksi di kartu ini
        public RiwayatTransaksi DataTrx { get; private set; }

        // [ALGORITMA] Expose Event: Form lain akan mendengarkan event ini
        public event EventHandler OnViewDetails;

        public CardTransaksi()
        {
            InitializeComponent();

            // Panggil method untuk menyambungkan kabel klik ke semua komponen
            WireUpClickEvents();
        }

        // --- METHOD UTAMA: ISI DATA ---
        public void SetData(RiwayatTransaksi trx)
        {
            if (trx == null) return;
            DataTrx = trx; // Simpan data di properti publik

            // 1. ISI HEADER (No TRX + Tanggal)
            string noTransaksi = "TRX-" + trx.IdTransaksi.ToString("D5");
            string tanggal = trx.Tanggal.ToString("dd MMM yyyy, HH:mm");
            LblTanggal.Text = $"{noTransaksi}   |   {tanggal}";

            // Set Status
            LblStatus.Text = trx.Status.ToUpper();
            SetStatusColor(trx.Status);

            // 2. ISI FOOTER
            LblTotal.Text = "Rp " + trx.TotalBelanja.ToString("N0");

            // 3. ISI BODY (LOOPING ITEM BARANG)
            FlpBarang.Controls.Clear();

            foreach (var item in trx.Items)
            {
                CardTransaksiItem cardAnak = new CardTransaksiItem();
                cardAnak.SetData(item);

                // ATUR LEBAR ANAK (PENTING: Biar memanjang ke samping)
                // Kita kurangi dikit (misal 25px) biar ada margin/gak nabrak scrollbar
                cardAnak.Width = this.Width - 25;

                FlpBarang.Controls.Add(cardAnak);
            }
        }

        // --- LOGIC PENYAMBUNGAN KLIK (ALGORITMA EVENT DRIVEN) ---
        private void WireUpClickEvents()
        {
            // Subscribe permukaan UserControl utama dan Panel2 utamanya
            this.Click += TriggerDetail;
            PnlHeader.Click += TriggerDetail;
            PnlFooter.Click += TriggerDetail;
            FlpBarang.Click += TriggerDetail; // Container Item

            // NOTE: Kalau kamu punya panel lain yang menutupi permukaan, 
            // panel itu juga harus di-subscribe.
        }

        // Ini adalah pemicu utama yang akan memberitahu Form Utama (V_HalTransaksi)
        private void TriggerDetail(object sender, EventArgs e)
        {
            // Sinyal dikirim ke form utama
            OnViewDetails?.Invoke(this, EventArgs.Empty);
        }

        // Helper: Mengatur warna status
        private void SetStatusColor(string status)
        {
            if (status == "Pending") LblStatus.ForeColor = Color.Orange;
            else if (status == "Terkonfirmasi") LblStatus.ForeColor = Color.Blue;
            else if (status == "Selesai") LblStatus.ForeColor = Color.Green;
            else if (status == "Ditolak") LblStatus.ForeColor = Color.Red;
            else LblStatus.ForeColor = Color.Red;
        }
    }
}