using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UdpDataSenderApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan IP, port ve mesaj bilgilerini al
            string ipAddress = ipTextBox.Text;
            int port = int.Parse(portTextBox.Text);
            string dataToSend = dataTextBox.Text;

            using (UdpClient udpClient = new UdpClient())
            {
                try
                {
                    // IP adresi ve port ile endpoint oluştur
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

                    // Mesajı byte array'e dönüştür
                    byte[] sendData = Encoding.UTF8.GetBytes(dataToSend);

                    // Veriyi gönder
                    await udpClient.SendAsync(sendData, sendData.Length, endPoint);

                }
                catch (Exception ex)
                {
                    // Hata mesajını göster
                    MessageBox.Show($"Veri gönderme sırasında hata oluştu: {ex.Message}");
                }
            }

        }
    }
}
