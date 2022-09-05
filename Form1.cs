using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeReview_MSMQ_Chatbot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myTimer.Tick += new EventHandler(Callback);
            //使timer可用  
            myTimer.Enabled = true;
            //時間間隔  
            myTimer.Interval = 10000;//10s
        }
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        Task task = new Task();
        string messageReceiveQueuePath = @".\Private$\chatbox";
        MessageQueue mq = new MessageQueue();
        delegate void mydelegate();
        private void Callback(object sender, EventArgs e)
        {
            //目前時間
            textBoxTimer.Text = DateTime.Now.ToLongTimeString().ToString();
            WatchQueue();
            //peekMessageQueuing();
            //listenQueue();
        }
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string messageContent = textBoxSendContent.Text;
            textBoxReceiveContent.Text += "[I say]: " + task.sendMessageQueuing(messageContent) + "\r\n";
            //textBoxReceiveContent.Text += "\r\n";
            //textBoxReceiveContent.Text += DateTime.Now.ToLongTimeString().ToString() + "\r\n";
        }

        private void buttonReceiveMessage_Click(object sender, EventArgs e)
        {
            if (task.peekMessageQueuing() > 0)
            {
                textBoxReceiveContent.Text += task.receiveMessageQueuing() + "\r\n";
                Console.WriteLine(task.peekMessageQueuing());
            }
            else
            {
                MessageBox.Show("Queue is empty!");
            }
        }
        void WatchQueue()
        {
            if (task.peekMessageQueuing() > 0)
            {
                mq.Path = messageReceiveQueuePath;
                //var queue = new MessageQueue(messageQueuePath);
                mq.Formatter = new XmlMessageFormatter(new string[] { "System.String" });
                mq.ReceiveCompleted += Queue_ReceiveCompleted;
                mq.BeginReceive();
                Console.WriteLine("Receive End!");
            }
            else if (task.peekMessageQueuing() < 0)
            {
                Console.WriteLine("Queue is empty");
                //MessageBox.Show("Queue is empty or Queue upper limit!");
            }
        }
        private void Queue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            Console.WriteLine(e.Message.Body.ToString() + "_" + e.Message.Id);

            if (this.InvokeRequired)
            {
                mydelegate d = new mydelegate(DataWatched);
                this.Invoke(d);
                mq.BeginReceive();
                Thread.Sleep(5000);
            }
            void DataWatched()
            {
                textBoxReceiveContent.Text += "[You say]: " + e.Message.Body.ToString() + "-" + DateTime.Now.ToLongTimeString().ToString() +"\r\n";

            }
        }
    }
}
