using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewerApp
{
    public partial class Form1 : Form
    {
        int nbrimage=0;
        int compteur = 0;
        //pour stocker les chemins des images que l'utilisateurs va choisir à chaque
        string[] listimages = new string[20];
        private void clear_image()
        {
             int i = 0, j;
             for (; i < this.nbrimage; i++)
             {
                 if (this.listimages[i] == pictureBox1.ImageLocation)
                 {
                     for (j = i; j < this.nbrimage - 1; j++)
                         this.listimages[j] = this.listimages[j + 1];
                     this.nbrimage--;
                 }
             }
             //si aprés suppression il reste aucun image
            if (nbrimage == 0) 
                pictureBox1.Image = null;
            else
            { //si aprés suppression il reste 1 seule image
                if (nbrimage == 1)
                    pictureBox1.Load(listimages[0]);
                else //si aprés suppression il reste plusieurs images
                    pictureBox1.Load(listimages[compteur]);
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listimages[nbrimage] =(openFileDialog1.FileName);
                nbrimage++;
                if (nbrimage == 1)
                    pictureBox1.Load(listimages[compteur]);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            if(nbrimage > 0)
            {
                clear_image();
                MessageBox.Show("picture deleted successfuly !! ");
            }
            else
                MessageBox.Show("Any picture to deleted !");

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
           if(nbrimage > 0)
           {
                compteur--;
                if (compteur < 0) compteur = 0;
                pictureBox1.Load(listimages[compteur]);
           }
            else
                MessageBox.Show("You should select a picture !!!");
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (nbrimage > 0)
            {
                compteur++;
                if (compteur >= nbrimage) compteur = nbrimage-1;
                pictureBox1.Load(listimages[compteur]);
            }
            else
                MessageBox.Show("You should select a picture !!!");
        }
    }
}
