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
using AServerQuery;

namespace ESGSSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           //logs.Say += new EventHandler<ChatEventArgs>(logs_Say);
        }
        //var listener = new LogListener();
        string ip = "";
        ushort port = 0;
        string rconpw = "";
        Server server = null;
        Logs logs = null;

        
        private void button4_Click(object sender, EventArgs e)
        {
            ip = textBox1.Text;
            port = Convert.ToUInt16(textBox2.Text);
            rconpw = textBox3.Text;

            server = ServerQuery.GetServerInstance(EngineType.Source, ip, port);
            logs = server.GetLogs(port);
            QueryMaster.ServerInfo info = server.GetInfo();
            sendLog("Current Map: " + info.Map);
            button4.Enabled = false;

        }
        //logs.Say += new EventHandler<ChatEventArgs>(logs_Say);
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        public void sendLog(string msg)
        {
            textBox5.AppendText("\n" + msg);
        }
        public void rconcmd(string cmd)
        {
            Rcon rcon = server.GetControl(rconpw);
            if (rcon == null)
            {
                MessageBox.Show("Invalid PW");
            }
            else
            {
            //send server commmand
            string serverResponse= rcon.SendCommand(cmd);
                sendLog("RCON Command " + cmd + "has sent");
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
            MessageBox.Show("DEBUG 1");
            saylisten();

        }
        public void saylisten()
        {
            while(true)
            {
                logs.Say += new EventHandler<ChatEventArgs>(logs_Say);
            }
            

        }
        static void logs_Say(object sender, ChatEventArgs e)
        {
            MessageBox.Show("DEBUG 2");
            //sendLog("Sender :");
            Console.WriteLine("\tName : " + e.Player.Name);
            Console.WriteLine("\tUid : " + e.Player.Uid);
            Console.WriteLine("\tWonid : " + e.Player.WonId);
            Console.WriteLine("\tTeam : " + e.Player.Team);
            Console.WriteLine("Message : " + e.Message);
            Console.WriteLine("Timestamp : " + e.Timestamp);
            
            if(e.Message == "!ready")
            {

            }
          
        }
        //logs.Say += new EventHandler<ChatEventArgs>(logs_Say);

    }
}
