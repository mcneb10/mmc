using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Model_Creator
{
    public partial class Form1 : Form
    {
        int mode = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox b = (ComboBox)sender;
            switch(b.SelectedItem.ToString())
            {
                case "Item default":
                    mode = 1;
                    break;
                case "Item block parent":
                    mode = 2;
                    break;
                case "Block default":
                    mode = 3;
                    break;
                default:
                    Console.WriteLine("An error has occured");
                    break;
            }
            switch(mode)
            {
                case 2:
                    textBox3.Enabled = false;
                    textBox2.Enabled = true;
                    Refresh();
                    break;
                default:
                    textBox3.Enabled = true;
                    textBox2.Enabled = false;
                    Refresh();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string product = "an error has occured";
            if(mode == 2)
                product = ("{" + "\n" + '"' + "parent" + '"' + ": " + '"' + textBox1.Text + ":block/" + textBox2.Text + '"' + "\n" + "}").ToString();

            File.WriteAllText(textBox4.Text + ".json", @product);
        }
    }
}
