using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageWathcer
{
    public class DirectoryImage // Класс обработки действий
    {
        List<Bitmap> myList = new List<Bitmap>(); // Лист Bitmap c изображениями из папки
        List<string> strName = new List<string>(); // Лист String с названиями изображений
        public List<Bitmap> GetImages() // Класс возвращает массив картинок из выбранной папки
        {
            using (var dialog = new FolderBrowserDialog()) // Создаем диалог выбора папки
                if (dialog.ShowDialog() == DialogResult.OK) // Вызываем диалог и проверяем выбрана ли папка
                {
                    myList.Clear(); // Предварительно очищаем массивы от старых записей
                    strName.Clear();
 
                    DirectoryInfo directoryInfo = new DirectoryInfo(dialog.SelectedPath); // Получаем инрформацию по выбранной папке
                    foreach (var file in directoryInfo.GetFiles()) // Проходим по файлам внутри выбранной папки
                    {
                        // Получаем расширение файла и проверяем подходит ли оно
                        if (Path.GetExtension(file.FullName) == ".jpg" || Path.GetExtension(file.FullName) == ".png" || Path.GetExtension(file.FullName) == ".jpeg")
                        {
                            myList.Add(new Bitmap(file.FullName)); // Если расширение подошло, создаём Bitmap и добавляем его в массив
                            strName.Add(file.Name); // Заносим название картинки в массив
                        }
                    }
                }

            return myList;
        }
        public List<string> GetImagesNames() // Класс возвращает массив названий картинок из выбранной папки
        {
            return strName;
        }
    }
}
