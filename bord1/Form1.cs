//im функция отриовка картин если отрисовать все то кидать лист по другому тоже лист но рисовать последний эл!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace bord1
{
    public partial class Form2 : Form
    {
        bool small = true;
        int posX = SystemInformation.PrimaryMonitorSize.Width - 190;
        int posY = SystemInformation.PrimaryMonitorSize.Height - 80;
        //int count = 0;
        Image glavnoe;
        ListBox listui = null;
        TextBox stringimage=null;
            TextBox stringexe = null;
            TextBox stringname = null;
        Label a1lable = new Label();
        Button addui = null;
        int cursX = 0;
        int cursY = 0;
        List<A> glavnlist = new List<A>();

        //StreamWriter writer = new StreamWriter("BD.txt");




       // [BrowsableAttribute(false)]
       // public event CancelEventHandler Closing;
        public Form2()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(posX, posY);
          
            Opacity = .75;
            TopMost = true;
            InitializeComponent();
          
            start();

            /*  // Create a new form.
              Form form2 = new Form();
              // Set the text displayed in the caption.
              form2.Text = "My Form";
              // Set the opacity to 75%.
              form2.Opacity = .75;
              // Size the form to be 300 pixels in height and width.
              form2.Size = new Size(300, 300);
              // Display the form in the center of the screen.
              form2.StartPosition = FormStartPosition.CenterScreen;

              // Display the form as a modal dialog box.
              //form2.ShowDialog();
              //this.Controls.Add(form2);
              */

            
            

        }



        private void panel1_Click(object sender, EventArgs e)
        {
            cursY = Cursor.Position.Y;
            cursX = Cursor.Position.X;
            if (listui != null)
            {
                listui.Dispose();
                listui = null;
            }
            if (a1lable != null)
                a1lable.Dispose();
            // if ((sender is Panel) && ((MouseEventArgs)e).Button == MouseButtons.Right)
            if ((sender is Panel) && ((MouseEventArgs)e).Button == MouseButtons.Right)
            {
               
                if (listui != null)
                {
                    listui.Dispose();
                    listui = null;
                }
                if (listui == null)
                {
                    
                    listui = new ListBox();
                 
                    listui.Left = Cursor.Position.X - SystemInformation.PrimaryMonitorSize.Width + 190;
                    
                    listui.Top = Cursor.Position.Y;
                    
                   // listui.Items.Add("открыть");
                    listui.Items.Add("добавить");
                    listui.SelectedIndexChanged += inedxchange;
                 
                    panel1.Controls.Add(listui);
                }



            }
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            if (!small)
            {
               
                if (Cursor.Position.X < SystemInformation.PrimaryMonitorSize.Width - 190)
                {
                    this.Height = 40;
                    this.Width = 190;
                    this.Location = new Point(SystemInformation.PrimaryMonitorSize.Width - 190, SystemInformation.PrimaryMonitorSize.Height - 80);
                    posX = this.Left;
                    posY = Top;
                    small = true;
                    // if (listui != null)
                    //{

                    //  listui.Dispose();
                    //  listui = null;
                    // }
                    List<Control> contr = new List<Control>();
                   foreach (Control i in panel1.Controls)
                    {
                        contr.Add(i);
                    }
                   for(int i= contr.Count-1; i>=0;--i)
                    {
                        contr[i].Dispose();
                    }
                }
            }
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            //int a1 = Cursor.Position.X;
            //int a2 = Cursor.Position.Y;
            if (small)
            {
                small = false;

                this.Height = SystemInformation.PrimaryMonitorSize.Height - 40;
                this.Width = 190;
                this.Top = 0;
                this.Left = SystemInformation.PrimaryMonitorSize.Width - 190;
                posX = SystemInformation.PrimaryMonitorSize.Width - 190;
                posY = 0;
                Button a3 = new Button();
                a3.Text = "вкл";
                a3.Click += blockvkl;
                a3.Left = panel1.Right - 70;
                a3.Top = panel1.Bottom - 30;
                panel1.Controls.Add(a3);
                im_add_bord(glavnlist, 1);
            }

        }
        private void blockvkl(object sender, EventArgs e)
        {
            this.TopMost =! this.TopMost;
            //if(this.TopMost)
              //  a3.Text = "вкл";

        }
        private void picClick(object sender, EventArgs e)
        {
            if(listui!=null)
            {
                listui.Dispose();
                listui = null;
            }
            if (a1lable != null)
                a1lable.Dispose();
            if ((sender is PictureBox) && ((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                listui = new ListBox();

                listui.Left = Cursor.Position.X - SystemInformation.PrimaryMonitorSize.Width + 190;

                listui.Top = Cursor.Position.Y;
                cursY = Cursor.Position.Y;
                cursX = Cursor.Position.X;

                // listui.Items.Add("открыть");
                listui.Items.Add("открыть");
                listui.Items.Add("удалить");
                listui.Items.Add("свойства");
                listui.SelectedIndexChanged += inedxchange;

                panel1.Controls.Add(listui);
                listui.BringToFront();
            }
        }
        private void inedxchange(object sender, EventArgs e)
        {
            ListBox a = sender as ListBox;
            if (a.Items[0] == "добавить")
            {
                switch (a.SelectedIndex)
                {
                    /* case 0:
                         listui.Dispose();
                         listui = null;
                         Open1(null, null);
                         //мб сделать еще функцию внутреннюю

                         break;*/

                    case 0://добавить
                        listui.Dispose();
                        listui = null;
                        add_bord();


                        break;
                   
                }
            }
            else
            {
                if (a.Items[0] == "открыть")
                {
                    switch (a.SelectedIndex)
                    {
                         case 0://открыть
                             listui.Dispose();
                             listui = null;
                             Open1(null, null);
                             //мб сделать еще функцию внутреннюю

                             break;

                        case 1://удалить
                            listui.Dispose();
                            listui = null;
                            delete1();


                            break;
                        case 2://свойства
                            listui.Dispose();
                            listui = null;
                            
                            int res1 = checkKvadrat(cursX - this.Left, cursY);
                            a1lable = new Label();
                            a1lable.Text = "путь до exe:"+glavnlist[res1-1].put+"    "+ "имя:"+ glavnlist[res1 - 1].name+"     "+"путь до image:"+ glavnlist[res1 - 1].kartinkastr+"          by zsuz";
                            a1lable.Left = 90;
                            a1lable.Top = this.Bottom - 110;
                            a1lable.Width = 100;
                            a1lable.Height = 80;
                            panel1.Controls.Add(a1lable);
                            //im_add_bord(glavnlist,1);


                            break;

                    }
                    }
                }
        }
        private void delete1()//object a)
        {
           


            int res = checkKvadrat(cursX - this.Left, cursY);
            glavnlist.RemoveAt(res - 1);
            //add_bord();
            List<Control> contr = new List<Control>();
            foreach (Control i in panel1.Controls)
            {
                contr.Add(i);
            }
            for (int i = contr.Count - 1; i >= 0; --i)
            {
                contr[i].Dispose();
            }
            im_add_bord(glavnlist, 1);
        }
        private void Open1(object sender, EventArgs e)
        {
            
            //int ryad1 = 0;
           // int nomer1 = 0;
           if(sender!=null)
            {
                cursY = Cursor.Position.Y;
                cursX = Cursor.Position.X;
            }

            int res = checkKvadrat(cursX-this.Left,cursY);
            if(res!=-1)
            Process.Start(glavnlist[res - 1].put);
           


        }
        private int checkKvadrat(int a,int b)
        {
            int x = -1;
            int y = -1;
            if(a>=15&&a<=85)
            {
                x = 1;
            }
            if(a >= 105 && a <=175)
            {
                x = 2;
            }
            if (x >0)
            {
                int a1 = 0, a2 = 70;
                for (int i = 1; i < 10; ++i)
                {
                    if (b >= a1 && b <= a2)
                    {
                        y = i;
                        break;
                    }
                    a1 += 90;
                    a2 += 90;
                }

                if (y >= 0)
                    return (y - 1) * 2 + x;
                else
                    return -1;
            }
            return -1;
        }

        private void add1(object sender, EventArgs e)
        {
            
            glavnlist.Add(new A(stringexe.Text, Image.FromFile( stringimage.Text), stringname.Text, stringimage.Text));
            im_add_bord(glavnlist);



            stringimage.Dispose();
            stringexe.Dispose();
            stringname.Dispose();
            addui.Dispose();
        }


        
        
        private void start()
        {
            
            StreamReader reader = new StreamReader("BD.txt");
            //количество ярлыков картинка на фон
            string a = reader.ReadLine();
            string[] a1 = a.Split('#');
            int count = Convert.ToInt32(a1[0]);
            glavnoe = Image.FromFile(a1[1]);
           
            panel1.BackgroundImage = glavnoe;
            for (int i = 0; i < count; ++i)
            {
                a = reader.ReadLine();
                string[] a2 = a.Split('#');
                
                glavnlist.Add(new A(a2[0],Image.FromFile(a2[2]),a2[1],a2[2]));
                
                
            }
            //im_add_bord(glavnlist, 1);

            reader.Close();
        }
        private void add_bord()
        {

            

            //отрисовать 3 поля для заполнения
            stringimage = new TextBox();
            stringimage.Text = "путь до картинки";
             stringexe = new TextBox();
            stringexe.Text = "путь до объекта";
            stringname = new TextBox();
            stringname.Text = "имя объекта";
            addui = new Button();
            stringimage. Left = 0;
            stringimage.Top = this.Bottom - 80;
            stringexe.Left =0;
            stringexe.Top = this.Bottom - 60;
            stringname.Left = 0;
            stringname.Top = this.Bottom - 40;
            addui.Left = 0;
            addui.Top = this.Bottom - 20;
            addui.Click += add1;
            addui.Text = "добавить";
            panel1.Controls.Add(stringimage);
            panel1.Controls.Add(stringexe);
            panel1.Controls.Add(stringname);
            panel1.Controls.Add(addui);
        }

        private void im_add_bord(IEnumerable<A> a,int regim=0)
        {
            //regim==0 добавить кнопкой 1 штуку  ==1 отрисовать все
            int ryad = 0;
            PictureBox a1 = new PictureBox();
            //a1.Size = new Size(70, 70);
            //a1.SizeMode = PictureBoxSizeMode.StretchImage;
            //a1.Left = 0;
            //a1.Top = 0;
            if (regim == 0)
            {
                double tt = 0;
                a1 = new PictureBox();
                a1.Size = new Size(70, 70);
                a1.SizeMode = PictureBoxSizeMode.StretchImage;
                tt = (double)glavnlist.Count / 2;
                //ryad=(int)(tt+0.5);
                ryad = (int)((double)glavnlist.Count / 2+0.5)-1;
                a1.Image = ((List<A>)a)[a.Count() - 1].kartinka;
                //a1.Image = a.


                if (glavnlist.Count % 2 == 0)
                {
                    a1.Left = 105;
                    //отрисовать справа
                }
                else
                {
                    a1.Left = 15;
                    //отрисовать слева
                }
                a1.Top = ryad * 70 + ryad * 20;
                //еще событие клика и мб название
                a1.DoubleClick += Open1;
                a1.Click += picClick;
               // a1.Click += panel1_Click;
                panel1.Controls.Add(a1);
            }
            else
                if (regim == 1)
            {


                for (int i = 0; i < a.Count(); ++i)
                {
                    a1 = new PictureBox();
                    a1.Size = new Size(70, 70);
                    a1.SizeMode = PictureBoxSizeMode.StretchImage;
                    a1.Left = 15;
                    a1.Top = ryad * 70 + ryad * 20;
                    a1.Image = ((List<A>)a)[i].kartinka;
                    a1.DoubleClick += Open1;
                    a1.Click += picClick;
                    //a1.Click += panel1_Click;
                    panel1.Controls.Add(a1);
                    ++i;
                    if (i < a.Count())
                    {
                        a1 = new PictureBox();
                        a1.Size = new Size(70, 70);
                        a1.SizeMode = PictureBoxSizeMode.StretchImage;
                        a1.Left = 120;
                        a1.Top = ryad * 70 + ryad * 20;
                        a1.Image = ((List<A>)a)[i].kartinka;
                        a1.DoubleClick += Open1;
                        a1.Click += picClick;
                        // a1.Click += panel1_Click;
                        panel1.Controls.Add(a1);
                    }
                    ryad++;

                }
            }





        }



        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            StreamReader reader = new StreamReader("BD.txt");
            //количество ярлыков картинка на фон
            string a = reader.ReadLine();
            reader.Close();
            StreamWriter writer = new StreamWriter("BD.txt");
            writer.WriteLine(glavnlist.Count+"#"+a.Split('#')[1]);
            for(int i=0;i<glavnlist.Count;++i)
            {
                string temp = glavnlist[i].put+"#"+ glavnlist[i].name+"#"+ glavnlist[i].kartinkastr;
                writer.WriteLine(temp);

            }
            writer.Close();






        }
    }

    class A
    {
        public string put;
        public string name;
        public Image kartinka;
        public string kartinkastr;
        public A(string b,Image c,string d,string e)
        {
            put = b;
            kartinka = c;
            name = d;
            kartinkastr = e;
        }

    }
}
