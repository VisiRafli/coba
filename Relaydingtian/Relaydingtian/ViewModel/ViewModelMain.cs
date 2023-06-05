using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;


namespace Relaydingtian.ViewModel
{
    class ViewModelMain : BaseViewModel
    {
        public string ipaddress { get; set; }
        public string relaynumber;
        public string status;
        

        public ICommand ButtonClickON { get; set; }
        public ICommand ButtonClickOFF { get; set; }
        public ICommand ButtonClickUpdate { get; set; }

        public ViewModelMain(Window window)
        {
            ipaddress = "";
            relaynumber = "1";
           
            
            GenerateCommands();
        }

        public void GenerateCommands()
        {
            ButtonClickON = new RelayCommand(() => ButtonON());
            ButtonClickOFF = new RelayCommand(() => ButtonOFF());
            ButtonClickUpdate = new RelayCommand(() => ButtonUpdate());
            
        }

        public void ButtonON()
        {
            
            status = "on";
            
            SendTcpPacket(relaynumber, status, ipaddress);
            RaisePropertyChanged("ButtonClickON");
        }

        public void ButtonOFF()
        {
            GetStatus(ipaddress);
            status = "off";
            SendTcpPacket(relaynumber, status, ipaddress);
            RaisePropertyChanged("ButtonClickOFF");
        }

        public void ButtonUpdate()
        {
            GetStatus(ipaddress);
            RaisePropertyChanged("ButtonClickUpdate");
        }

        public string GetStatus(string ipaddress)
        {
            try
            {
                
                Int32 port = 60001;
                TcpClient client = new TcpClient(ipaddress, port);

                Byte[] data = System.Text.Encoding.ASCII.GetBytes("00");

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                data = new Byte[256];

                String responseData = String.Empty;

                Int32 bytes = stream.Read(data, 0, data.Length);

                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

                stream.Close();

                client.Close();

                return responseData;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Fail to connect to relay board. Error details: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public bool SendTcpPacket(string relaynumber, string status, string ipaddress)
        {
            try
            {
                string text = "";
                Int32 port = 60001;
                TcpClient client = new TcpClient(ipaddress, port);

                if (relaynumber == "1")
                {
                    if (status == "on")
                    {
                        text = "11";
                    }
                    else
                    {
                        text = "21";
                    }

                }
                if (relaynumber == "2")
                {
                    if (status == "on")
                    {
                        text = "12";
                    }
                    else
                    {
                        text = "22";
                    }

                }
                if (relaynumber == "3")
                {
                    if (status == "on")
                    {
                        text = "13";
                    }
                    else
                    {
                        text = "23";
                    }

                }
                if (relaynumber == "4")
                {
                    if (status == "on")
                    {
                        text = "14";
                    }
                    else
                    {
                        text = "24";
                    }

                }
                if (relaynumber == "5")
                {
                    if (status == "on")
                    {
                        text = "15";
                    }
                    else
                    {
                        text = "25";
                    }

                }
                if (relaynumber == "6")
                {
                    if (status == "on")
                    {
                        text = "16";
                    }
                    else
                    {
                        text = "26";
                    }

                }
                if (relaynumber == "7")
                {
                    if (status == "on")
                    {
                        text = "17";
                    }
                    else
                    {
                        text = "27";
                    }

                }
                if (relaynumber == "8")
                {
                    if (status == "on")
                    {
                        text = "18";
                    }
                    else
                    {
                        text = "28";
                    }

                }
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(text);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                client.Close();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Fail to connect to relay board. Error details: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //test commit git, push ke main branch - rafli
            //test commit git, push ke new branch - rafli
            //buat perubahan di main, push -rafli
        }
    }
}
