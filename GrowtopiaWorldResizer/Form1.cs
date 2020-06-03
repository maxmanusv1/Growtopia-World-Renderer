using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.Runtime.CompilerServices;

namespace GrowtopiaWorldResizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        string mainlink = "https://s3.amazonaws.com/world.growtopiagame.com/";
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }
         
        private void Owner_AdminBul()
        {
            PictureBox[] boxes = { pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10};
            ArrayList list = new ArrayList();
            try
            {
                const float limit = 0.7f;
                WebClient client = new WebClient();
                client.DownloadFile(mainlink + textBox1.Text.ToLower() + ".png", "testxdd.png");

                Bitmap bitmap = new Bitmap("testxdd.png");
                Rectangle rectangle1 = new Rectangle(0, 865, 1600, 95);
                Image Assagisinial = bitmap.Clone(rectangle1, bitmap.PixelFormat);
                Clipboard.SetImage(Assagisinial);
                bitmap.Dispose();
                
                Bitmap owner = new Bitmap(Clipboard.GetImage());
                Rectangle rectangle2 = new Rectangle(15, 0, 100, 95);
                Image owner2 = owner.Clone(rectangle2, owner.PixelFormat);
                //  Clipboard.SetImage(owner2);
                pictureBox2.Image = owner2;
                owner.Dispose();
                Bitmap admin = new Bitmap(Clipboard.GetImage());
                Rectangle rectangle;
                Image adminn;
              //  bool dondur = true;
                  for (int i = 120; i < 1400; i += 120)
                   {
                        rectangle = new Rectangle(i, 0, 120, 95);
                        adminn = admin.Clone(rectangle, admin.PixelFormat);
                        list.Add(adminn);
                        
                        /*  for (int z = 0; z < 8; z++)
                          {


                              if (z == 0)
                              {
                                  boxes[z].Image = adminn;
                              }

                            else 
                              {
                                  if (boxes[z].Image != boxes[z].Image)
                                  {
                                      boxes[z].Image = adminn;
                                  }
                                  else
                                  {
                                      dondur = false;
                                  }
                              }


                          } */
                  }
               
                    for (int z = 0; z < boxes.Length; z++)
                    {
                         if (z == 0)
                         {
                                boxes[z].Image = (Image)list[z];
                         }
                         else
                         {
                             if ((list[z] != list[z - 1]))
                             {
                                boxes[z].Image = (Image)list[z];
                             }
                             else
                             {
                                
                             }
                         }
                        
                    }
               
               

                admin.Dispose();
                //File.Delete("testxddd.png");
                 File.Delete("testxdd.png");
               Clipboard.Clear();
                //Clipboard.SetImage(Assagisinial);

                //    pictureBox1.Image = Clipboard.GetImage();
            }
            catch 
            {
                
                
            }
           
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                Thread thread = new Thread(WorldGetir);
                thread.IsBackground = true;
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();

                Thread thread2 = new Thread(Owner_AdminBul);
                thread2.IsBackground = true;
                thread2.SetApartmentState(ApartmentState.STA);
                thread2.Start();
                button1.Enabled = false;
                timer1.Enabled = true;
                
            }
            else
            {
                MessageBox.Show("You need to fill textbox to search a world!");
            }
           
        }
        private void WorldGetir()
        {
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(mainlink + textBox1.Text.ToLower() + ".png", "testxd.png");
                Rectangle rectangle = new Rectangle(0, 0, 1600, 870);
                Bitmap bitmap = new Bitmap("testxd.png");
                Image kirp = bitmap.Clone(rectangle, bitmap.PixelFormat);
                bitmap.Dispose();
                // Clipboard.SetImage(kirp);
                pictureBox1.Image = kirp;
               // Clipboard.Clear();
                File.Delete("testxd.png");
                textBox1.Text = null;
            }
            catch (Exception ee)
            {

                MessageBox.Show("World not found! ");
                Clipboard.SetText(ee.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            button1.Enabled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
