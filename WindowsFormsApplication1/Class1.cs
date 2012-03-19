using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication1.ServiceReference1;

namespace WindowsFormsApplication1
{
    public class CallbackHandler : INetFilesServiceCallback
    {
        private Form1 form;

        public CallbackHandler(Form1 form)
        {
            this.form = form;
        }

        public void NewMessageReceive(string userNameFrom, string text)
        {
            form.GetListBox().Items.Add(userNameFrom + ": " + text);
        }
    }
}
