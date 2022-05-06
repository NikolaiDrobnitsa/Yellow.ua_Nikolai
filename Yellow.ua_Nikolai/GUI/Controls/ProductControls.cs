using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yellow.ua_Nikolai.GUI.Controls
{
    public partial class ProductControls : UserControl
    {
        int id_collection;
        public ProductControls(int id, string name, int price, string info, string image)
        {
            InitializeComponent();
            //NameProductLabel.Text = $"NAME: {name}";
            //PriceLabel.Text = $"Price: {price.ToString()}₴";
            //InfoLabel.Text = $"Information: {info}";
            //ManufactureLabel.Text = $"Manufacture: {manufacture}";
            //this.id_collection = id;
            label1.Text = name;
            label2.Text = $"{price} грн";
            pictureBox1.BackgroundImage = Image.FromFile(image);
            this.id_collection = id;
        }
    }
}
