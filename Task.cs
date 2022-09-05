using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Messaging;

namespace CodeReview_MSMQ_Chatbot
{
    public class Task
    {
        string messageSengQueuePath = @"FormatName:DIRECT=TCP:172.20.10.2\private$\chatbox";
        string messageReceiveQueuePath = @".\Private$\chatbox";
        public string sendMessageQueuing(string messageContent)
        {
            try
            {
                var queue = new MessageQueue(messageSengQueuePath);
                queue.Send(messageContent, "Label");
                Console.WriteLine("Send end!");
            }
            catch (MessageQueueException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return messageContent;
        }
        public string receiveMessageQueuing()
        {
            var queue = new MessageQueue(messageReceiveQueuePath);
            queue.Formatter = new XmlMessageFormatter(new string[] { "System.String" });

            System.Messaging.Message message = queue.Receive();
            Console.WriteLine(message.Body);
            String ms = message.Body.ToString() + "_" + message.Id;
            return ms;
        }
        public int peekMessageQueuing()
        {
            int currentMessageNumber = 0;
            var queue = new MessageQueue(messageReceiveQueuePath);
            queue.Formatter = new XmlMessageFormatter(new string[] { "System.String" });

            foreach (System.Messaging.Message message in queue)
            {
                //Console.WriteLine(message.Body);
                currentMessageNumber++;
            }
            return currentMessageNumber;
        }
    }
}
