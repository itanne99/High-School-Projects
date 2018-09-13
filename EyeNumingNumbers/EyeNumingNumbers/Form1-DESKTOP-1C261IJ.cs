using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeNumingNumbers
{
    public partial class Form1 : Form
    {
        List<Button> numberButtons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < 210; i++)
            {
                numberButtons.Add(new Button());
                numberButtons.ElementAt(i).Name = "Button"+i;
            }
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
