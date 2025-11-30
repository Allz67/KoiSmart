using KoiSmart.Models;
using KoiSmart.Views.Components;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KoiSmart.Views.Components
{
    public partial class CardTransaksi : UserControl
    {
        public RiwayatTransaksi DataTrx { get; private set; }
        public event EventHandler OnViewDetails;

        public CardTransaksi()
        {
            InitializeComponent();
            WireUpClickEvents();
        }

        public void SetData(RiwayatTransaksi trx)
        {
            if (trx == null) return;
            DataTrx = trx;

            string noTransaksi = "TRX-" + trx.IdTransaksi.ToString("D5");
            string tanggal = trx.Tanggal.ToString("dd MMM yyyy, HH:mm");
            LblTanggal.Text = $"{noTransaksi}   |   {tanggal}";

            LblStatus.Text = trx.Status.ToUpper();
            SetStatusColor(trx.Status);

            LblTotal.Text = "Rp " + trx.TotalBelanja.ToString("N0");
            FlpBarang.Controls.Clear();

            foreach (var item in trx.Items)
            {
                CardTransaksiItem cardAnak = new CardTransaksiItem();
                cardAnak.SetData(item);
                cardAnak.Width = this.Width - 25;

                FlpBarang.Controls.Add(cardAnak);
                AttachClickRecursive(cardAnak);
            }
        }

        private void WireUpClickEvents()
        {
            AttachClickRecursive(this);
        }
        private void AttachClickRecursive(Control ctrl)
        {
            if (ctrl == null) return;
            ctrl.Click -= TriggerDetail;
            ctrl.Click += TriggerDetail;
            foreach (Control child in ctrl.Controls)
            {
                AttachClickRecursive(child);
            }
        }
        private void TriggerDetail(object sender, EventArgs e)
        {
            OnViewDetails?.Invoke(this, EventArgs.Empty);
        }

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