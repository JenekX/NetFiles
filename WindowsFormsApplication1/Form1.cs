using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.ServiceReference1;
using System.ServiceModel;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        INetFilesService client = null;

        public Form1()
        {
            InitializeComponent();

            InstanceContext instanceContext = new InstanceContext(new CallbackHandler(this));
            //client = new NetFilesServiceClient(instanceContext);

            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            DuplexChannelFactory<INetFilesService> factory = new DuplexChannelFactory<INetFilesService>(instanceContext, binding);
            Uri adress = new Uri("net.tcp://astrakhan.chickenkiller.com:8000/NetFilesService");
            EndpointAddress endpoint = new EndpointAddress(adress.ToString());
            //Связь с сервером не устанавливается до тех пор, пока не будет вызван метод Join  
            client = factory.CreateChannel(endpoint);  
        }

        public ListBox GetListBox()
        {
            return listBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.Connect(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("for " + listBox2.Text + ":" + textBox3.Text);

            client.AddMessage(listBox2.Text, textBox3.Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Disconnect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(client.UserList());
        }
    }
}
