using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QueryMaster;

namespace ESGSSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string ip = "";
        ushort port = 0;
        string rconpw = "";
        Server server = ServerQuery.GetServerInstance(EngineType.Source, "", 0);
        Logs logs = null;
        
        private void button4_Click(object sender, EventArgs e)
        {
            ip = textBox1.Text;
            port = Convert.ToUInt16(textBox2.Text);
            rconpw = textBox3.Text;

            Server server = ServerQuery.GetServerInstance(EngineType.Source, ip, port);
            logs = server.GetLogs(port);
            ServerInfo info = server.GetInfo();
            textBox5.AppendText(textBox5.Text + "n/ Current map: " + info.Map);

        }
        //logs.Say += new EventHandler<ChatEventArgs>(logs_Say);
        private void textBox1_TextChanged(object sender, EventArgs e)
        { 

        }
        public void rconcmd(string cmd)
        {
            Rcon rcon = server.GetControl(rconpw);
            if (rcon == null)
            {
                //msgbox.Show("Invalis PW");
            }
            else
            {
            //send server commmand
            string serverResponse= rcon.SendCommand("cmd");
            }           
        }
        public void say(string msg)
        {
            rconcmd("say [ESGS] " + msg);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            rconcmd("exec esl5on5");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rconcmd("changelevel " + textBox4.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            say("Match Started!");
            while (true)
            {

            }
        }
    }
}
