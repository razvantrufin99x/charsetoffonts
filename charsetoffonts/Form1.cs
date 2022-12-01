using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Text;

namespace charsetoffonts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Font font0;
        List<Label> lablesofchars = new List<Label>();
       //String c = "0123456789 abcdefghijklmnopqprstuvxzyw~!@#$%^&*()_+=-~}{][|\":;'\\?><,./ABCDEFGHIJKLMNOPQRSTUVXZYW";
       // String c = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
        String c = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿĀāĂăĄąĆćĈĉĊċČčĎďĐđĒēĔĕĖėĘęĚěĜĝĞğĠġĢģĤĥĦħĨĩĪīĬ";
        bool wasloaded = false;

        public void listallfonts()
        {
            using (InstalledFontCollection fontFamilies = new InstalledFontCollection())
            {
                // Iterate through all font families.
                int offset = 10;
                foreach (FontFamily family in fontFamilies.Families)
                {
                    try
                    {
                        // Create a label that will display text in this font.
                        Label fontLabel = new Label();
                        fontLabel.Text = family.Name;
                        fontLabel.Font = new Font(family, 14);
                        fontLabel.Left = 10;
                        fontLabel.Width = pnlFonts.Width;
                        fontLabel.Top = offset;
                        // Add the label to a scrollable Panel.
                        pnlFonts.Controls.Add(fontLabel);
                        offset += 30;
                        comboBox1.Items.Add(family.Name);
                    }
                    catch
                    {
                        // An error will occur if the selected font does
                        // not support normal style (the default used when
                        // creating a Font object). This problem can be
                        // harmlessly ignored.
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            font0 = fontDialog1.Font;

            for (int i = 0; i < lablesofchars.Count; i++)
            {
                lablesofchars[i].Font = font0;
            }
            Refresh();
        }

        public void loadall()
        {
            int k = -1;
            int len = c.Length;
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    try
                    {
                        k++;
                        Label lbl = new Label();
                        lbl.Text = "x";
                        lbl.Font = font0;
                        lablesofchars.Add(lbl);
                        lablesofchars[k].Text = c.Substring(k, 1);
                        Controls.Add(lablesofchars[k]);
                        lablesofchars[k].Top = i * 75 + 100;
                        lablesofchars[k].Left = j * 75 + 20;
                        lablesofchars[k].Width = 70;
                        lablesofchars[k].Height = 70;
                        lablesofchars[k].Show();
                        lablesofchars[k].BorderStyle = BorderStyle.FixedSingle;

                        Thread.Sleep(1);
                        Refresh();
                    }catch{}
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            font0 = this.Font;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (wasloaded == false)
            {
                loadall();
            }
            wasloaded = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Font f = new Font(font0.FontFamily,font0.Size+1);
            font0 = f;
            for (int i = 0; i < lablesofchars.Count; i++)
            {
                lablesofchars[i].Font = font0;
            }
            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Font f = new Font(font0.FontFamily, font0.Size - 1);
            font0 = f;
            for (int i = 0; i < lablesofchars.Count; i++)
            {
                lablesofchars[i].Font = font0;
            }
            Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
           
            for (int i = 0; i < 100 ; i++)
            {
                //ama adaugat fonturile cu butonul de mai jos
            }
            Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listallfonts();
            button6.Enabled = false;
        }

        public void changeandsetthisfontfromcombobox()
        {
        try
            {
                Font f = new Font(comboBox1.SelectedItem.ToString(), font0.Size);
                font0 = f;
                for (int i = 0; i < lablesofchars.Count; i++)
                {
                    lablesofchars[i].Font = font0;
                }
                Refresh();
            }
            catch { }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            changeandsetthisfontfromcombobox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeandsetthisfontfromcombobox();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lablesofchars.Count; i++)
            {
                lablesofchars[i].Top -= 20;
            }
            Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lablesofchars.Count; i++)
            {
                lablesofchars[i].Top += 20;
            }
            Refresh();
        }
    }
}
