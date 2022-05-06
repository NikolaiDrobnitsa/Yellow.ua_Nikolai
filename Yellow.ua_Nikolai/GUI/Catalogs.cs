using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yellow.ua_Nikolai.GUI.Controls;
using Yellow.ua_Nikolai.Model;

namespace Yellow.ua_Nikolai.GUI
{
    public partial class Catalogs : Form
    {

        public Catalogs()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 400, y = 80;
            Model1 model = new Model1();
            foreach (var item in model.Yellows)
            {

                this.Controls.Add(new ProductControls(item.id, item.Name, item.Price, item.Info, item.Image) { Location = new Point(x, y) });

                x += 250;
                if (x/250 >= 5)
                {
                    y += 280;
                    x = 400;
                }

            }
        }
    }
}
