using System;
using System.Windows.Forms;
//using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using TextQueue;

namespace TTSCs
{
 
    public class CrunchKeyEvents : Form
    {

        public TextQueue theTQ;
        public string Language;
        //List<string> CharList = new List<string>();
        string NumString;
        private System.ComponentModel.IContainer components;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;

        int LastSentPos = 0;
        public delegate void AnswerGiven(string message);
        // Define an Event based on the above Delegate
        public event AnswerGiven theAnswer;

        public CrunchKeyEvents()
        {
            InitializeComponent();

            //this.listView1.Select(); 
            this.KeyUp += new KeyEventHandler(OnKeypress);

            ///this.listView1.Items.Add("HEJ");
            //this.listView1.Focus();

        }

        public void PrepareToSend()
        {

        }
        void SendTextToQueue(string s,string l)
        {
            theTQ.AddJob(" " + s + " ", l);
                
        }
        public void PutToDisplay(TextSelecter s)
        {
                //this.toolTip1.Show(
 //           this.toolTip1.SetToolTip(this,s.sText);
                this.Text = s.sText;
        }
        public void OnKeypress(object sender, KeyEventArgs e)
        {

            //MessageBox.Show(e.KeyCode.ToString(), "Your input");

            
            if (e.KeyValue>95 && e.KeyValue<106)
            {
                string strValue = System.Convert.ToString(e.KeyValue-96);
                SendTextToQueue(" " + strValue + " ", "eng");
                SendTextToQueue(" " + strValue + " ", "swe");
                NumString = NumString + strValue;
            }
            else if ((e.KeyValue > 47 && e.KeyValue < 58))
            {
                string strValue = System.Convert.ToString(e.KeyValue - 48);
                SendTextToQueue(" " + strValue + " ", "eng");
                SendTextToQueue(" " + strValue + " ", "swe");
                NumString = NumString + strValue;
            }
            else if (e.KeyValue > 64 && e.KeyValue < 91)
            {
                char cValue = System.Convert.ToChar(e.KeyValue);
                string strValue = cValue.ToString();
                SendTextToQueue(" " + strValue + " ", "eng");
                theAnswer(strValue);

            }
            else if (e.KeyValue == 221)
            {
                //string strValue = System.Convert.ToChar(e.KeyValue).ToString();
                SendTextToQueue(" å ", "eng");
                SendTextToQueue(" å ", "swe");
                theAnswer("å");
            }
            else if (e.KeyValue == 222)
            {
                SendTextToQueue(" ä ", "eng");
                SendTextToQueue(" ä ", "swe");
                theAnswer("ä");
            }
            else if (e.KeyValue == 192)
            {
                SendTextToQueue(" ö ", "eng");
                SendTextToQueue(" ö ", "swe");
                theAnswer("ö");
            }




            switch (e.KeyValue) 
            {
                case (13):
                    if (NumString.Length > 0)
                    {
                        theAnswer(NumString);
                        NumString = "";
                    }
                    break;
                /*case (65):
                    theAnswer("a");
                    break;
                case (84):
                    theAnswer("t");
                    break;
                case (77):
                    theAnswer("m");
                    break;*/
                case (27): /*ESC*/
                    SendTextToQueue(" Du tryckte på ESCAPE-knappen - Ny är det slut! ","swe");
                    SendTextToQueue(" You pressed ESCAPE Button - Bye Bye ","eng");
                    Program.KillApp();
                    break;
            }


        }
        public void OnResultCheck()
        {

        }


        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Instruktioner:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "t - multiplikation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "a  - abc";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "p - addition";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 33);
            this.label5.TabIndex = 4;
            this.label5.Text = "m - minus";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(331, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 33);
            this.label6.TabIndex = 9;
            this.label6.Text = "m - minus";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(331, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 33);
            this.label7.TabIndex = 8;
            this.label7.Text = "p - addition";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(331, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 33);
            this.label8.TabIndex = 7;
            this.label8.Text = "a - abc";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(331, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(220, 33);
            this.label9.TabIndex = 6;
            this.label9.Text = "t - multiplication";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(331, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 33);
            this.label10.TabIndex = 5;
            this.label10.Text = "Instructions:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(223, 33);
            this.label11.TabIndex = 10;
            this.label11.Text = "c - configuration";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(331, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(223, 33);
            this.label12.TabIndex = 11;
            this.label12.Text = "c - configuration";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(331, 248);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(235, 33);
            this.label13.TabIndex = 13;
            this.label13.Text = "ESC - Quit game";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 248);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(282, 33);
            this.label14.TabIndex = 12;
            this.label14.Text = "ESC - Avsluta spelet";
            // 
            // CrunchKeyEvents
            // 
            this.ClientSize = new System.Drawing.Size(625, 339);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CrunchKeyEvents";
            this.Text = "Hello";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CrunchKeyEvents_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CrunchKeyEvents_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string totta = e.ToString;
            Language = "swe";
            theTQ.AddJob("cmd:setlang:eng","eng");  
            //theTQ.
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CrunchKeyEvents_Load_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
