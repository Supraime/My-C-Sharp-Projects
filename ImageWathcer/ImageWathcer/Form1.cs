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


namespace ImageWathcer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DirectoryImage directoryImage = new DirectoryImage(); // Создаем экземпляр класса обработки действий
        List<Bitmap> myList = new List<Bitmap>(); // Лист с изображениями
        List<string> strName = new List<string>(); // Лист с названиями изображений
        private void button1_Click(object sender, EventArgs e) // Кнопка выбора папки
        {
            myList = directoryImage.GetImages(); // Получаем лист с Bitmap 
            strName = directoryImage.GetImagesNames(); // Получаем лист с названиями изображений
            listBox1.Items.Clear(); // Зачищаем список от старых данных
            pictureBox1.Image = pictureBox1.InitialImage; // Сбрасываем изображение
            if (myList.Count == 0) // Если в выбранной папке отсутствуют изображения
            {
                nameImgLabel.Text = "Нет доступных изображений";
            }
            else
            {
                nameImgLabel.Text = "";
            }
            int i = 1;
            foreach(string str in strName) // Пробегаем по листу с названиями изображений
            {
                listBox1.Items.Add("Image "+i);
                i++;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) // Событие вызываемое при выборе строки в ListBox
        {
            pictureBox1.Image = myList[listBox1.SelectedIndex]; // Отображаем выбранное изображение в PictureBox
            nameImgLabel.Text = strName[listBox1.SelectedIndex]; // Отображаем название выбранного изображения в Label
        }
    }
}
