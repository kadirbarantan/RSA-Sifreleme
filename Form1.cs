using System;
using System.Numerics;
using System.Windows.Forms;

namespace RSA_Example
{
    public partial class Form1 : Form
    {
        BigInteger n, ee, d, phi, p, q;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            // Public key al
            n = BigInteger.Parse(txtN.Text);
            ee = BigInteger.Parse(txtE.Text);

            // p ve q brute force ile bul
            for (BigInteger i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    p = i;
                    q = n / i;
                    break;
                }
            }

            // phi hesapla
            phi = (p - 1) * (q - 1);

            // d brute force ile bul
            for (BigInteger i = 1; i < phi; i++)
            {
                if ((i * ee) % phi == 1)
                {
                    d = i;
                    break;
                }
            }

            // sonucu göster
            txtD.Text = d.ToString();
            txtPrivate.Text = "(" + n + ", " + d + ")";
        }
    }
}