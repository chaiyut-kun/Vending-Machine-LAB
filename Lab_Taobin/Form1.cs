using Lab_Taobin.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Taobin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            spinner_gif.Visible = false;
            redcode_label.Visible = false;
            Admin_function();
            Show_material();
        }

        // asset 
        Coffee_Machine Tao_Loi = new Coffee_Machine();
        bool makeable;
        double[] material ;
        bool open_close = true , red_code = false;
        // end of asset 



        // Menu

        private void Black_Coffee_button_Click(object sender, EventArgs e)
        {
            //Black coffee 
            makeable = Tao_Loi.make_BlackCoffee();
            Manage_Menu(makeable, "กาแฟดำ", Properties.Resources.black_coffee);
            Show_material();

        }
        private void Latte_button_Click(object sender, EventArgs e)
        {

            // Latte
            makeable = Tao_Loi.make_Latte();
            Manage_Menu(makeable , "ลาเต้" , Properties.Resources.Latte);

            Show_material();

        }
        private void Mocha_button_Click(object sender, EventArgs e)
        {
            //Mocca
            makeable = Tao_Loi.make_Mocca();
            Manage_Menu(makeable ,"มอคค่า", Properties.Resources.Mocha);

            Show_material();

        }
        private void Chocolate_button_Click(object sender, EventArgs e)
        {
            makeable = Tao_Loi.make_HotChocolate();
            Manage_Menu(makeable, "ช็อคโกแล็ตร้อน" , Properties.Resources.Hot_chocolate);

            Show_material();
        }
            
            // Manage menu
            public async void Manage_Menu(bool Make_menu, string menu_name, System.Drawing.Bitmap picture)
        {
            /*
                ฟังก์ชันในการชงเครื่องดื่มโดยถ้าหากวัตถุดิบเพียงพอ Make_menu ที่รับเข้ามาจะเป็น true
            */

            waiting();
            await Task.Delay(500);            
            if (Make_menu)
            {
                picture_show.Image =  picture;
                MessageBox.Show(String.Format("Menu {0} ของท่านได้แล้วครับ",menu_name),"Successfully!");
                red_code = true;
            } 
            else
            {
                picture_show.Image = Properties.Resources.sorry;
                MessageBox.Show("ขออภัยตู้เต้าลอยของเรามีวัตถุดิบไม่เพียงพอต่อความต้องการของท่าน"
                                        , "Sorry Temporarily out of service");
                red_code = false;
                RedCode();
            }
            waiting();
        }
            // end Manage menu
        //end of Menu


        //Admin Function
        public void RedCode()
        {
            /* function นี้จะทำงานก็ต่อเมื่อวัตถุดิบไม่พอ
                จะแสดง label redcode_label
             */
            if (!red_code)
            {
                redcode_label.Visible = true;
            }
            else
            {
                redcode_label.Visible = false;
            }
        }
        public async void waiting()
        {
            /*
                function นี้จะทำงานเมื่อมีการชงเครื่องดื่มต่างๆ จะมี waiting spinner (GIF) แสดงผล    
            */

            open_close = !open_close;
            spinner_gif.Visible = open_close;
            spinner_gif.Enabled = open_close;

            Latte_button.Visible = !open_close;
            Black_Coffee_button.Visible = !open_close;
            Mocha_button.Visible = !open_close;
            Chocolate_button.Visible = !open_close;
        }
        public void Show_material()
        {
            /*
                แสดงวัตถุดิบที่คงเหลือ
            */

            water_box.Text = $"{ Tao_Loi.water }";
            coffee_box.Text = $"{ Tao_Loi.coffee }";
            milk_box.Text = $"{ Tao_Loi.milk }";
            choco_box.Text = $"{ Tao_Loi.chocolate }";


        }
        public void Admin_function()
        {
            /*
                ฟังก์ชันเปิดปิดปุ่ม Admin
            */

            open_close = !open_close;

            water_updown.Visible = open_close;
            water_label.Visible = open_close;

            coffee_label.Visible = open_close;
            coffee_updown.Visible = open_close;

            choco_label.Visible = open_close;
            choco_updown.Visible = open_close;

            milk_label.Visible = open_close;
            milk_updown.Visible = open_close;

            Submit_button.Visible = open_close;

            Welcome_label.Visible = open_close;
            Please_label.Visible = open_close;
        }
        private void Administrator_button_Click(object sender, EventArgs e)
        {

            Admin_function();

        }
        private void Submit_button_Click(object sender, EventArgs e)
        {
            /*
                ปุ่ม submit ที่เมื่อทำการเติมวัตถุุดิบเรียบร้อยแล้ว
            */

            material = new decimal[]
            { water_updown.Value, coffee_updown.Value, milk_updown.Value, choco_updown.Value }
            .Select(s => (double)s).ToArray();
            water_updown.Value = coffee_updown.Value = milk_updown.Value = choco_updown.Value = 0;
            red_code = true;

            Tao_Loi.increase_material(material[0], material[1], material[2], material[3]);
            Admin_function();
            MessageBox.Show("เติมวัตถุดิบสำเร็จแล้ว!","Successfully!");
            RedCode();
            Show_material();

        }
        //end fAdmin Function


        //ยังไม่ได้ใช้
        public void LabelMn(Label label, int[] xy_locate, string text)
        {

            label.Text = text;
            label.Location = new Point(xy_locate[0], xy_locate[1]);

        }
        public void ButtonMn(NumericUpDown button, int[] xy_locate, int[] size)
        {
            button.Location = new Point(xy_locate[0], xy_locate[1]);
            button.Size = new Size(size[0], size[1]);


        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void choco_label_Click(object sender, EventArgs e)
        {

        }
    }
}
