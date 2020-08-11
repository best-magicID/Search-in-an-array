using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Поиск_по_массиву
{
    public partial class Form1 : Form
    {
        public int pozition = 0, dlina_mass;
        Random rand = new Random();
        public int[] massiv;
        public int poisk;

        public Form1() // запуск проги
        {
            InitializeComponent();
            label2.Text = "";
            label5.Text = "";
            label7.Text = "";
            textBox1.HideSelection = false;
        }

        private void button1_Click(object sender, EventArgs e) // заполнить массив
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label2.Text = "";
            label5.Text = "";
            label7.Text = "";
            dlina_mass = 15;
            massiv = new int[dlina_mass];
            for (int i = 0; i < massiv.Length; i++) //вывод массива
            {
                massiv[i] = rand.Next(-99, 99);
                textBox1.Text += massiv[i] + "  ";
            }
        }

        private void button2_Click(object sender, EventArgs e) // последовательный поиск
        {
            label2.Text = ""; // счетчик
            label5.Text = ""; // искомое число
            label7.Text = ""; // отсортированный массив
            try
            {
                if (textBox1.Text.IndexOf(textBox2.Text, pozition) >= 0) //выделение элемента
                {
                    if (pozition <= textBox1.Text.Length)
                    {
                        textBox1.SelectionStart = textBox1.Text.IndexOf(textBox2.Text, pozition);
                        textBox1.SelectionLength = textBox2.Text.Length;
                        pozition = textBox1.SelectionStart + 1;
                    }
                }
                else
                {
                    pozition = 0;
                }

                int i;
                bool Flag = false;
                poisk = Convert.ToInt32(textBox2.Text);  

                for (i = 0; i < massiv.Length; i++)      //поиск элемента
                {
                    if (massiv[i] == poisk)
                    {
                        label2.Text = Convert.ToString(i + 1);
                        label5.Text = Convert.ToString(massiv[i]);
                        Flag = true;
                        break;
                    }
                }
                if (Flag == false)
                    MessageBox.Show("Данного числа нет в массиве", "", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Проверьте введенное значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void информацияОРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработал:\nПолчихин А.А.\n2019 год", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.SelectAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //textBox1.Text = "";
            //textBox2.Text = "";
            label2.Text = "";
            label5.Text = "";
            //label7.Text = "";
             int i = 0;
        }

        private void button3_Click(object sender, EventArgs e) //Бинарный поиск
        {
            label2.Text = "";
            label5.Text = "";
            label7.Text = "";
            try
            {
                int[] massiv_Bin = new int[dlina_mass];
                Array.Copy(massiv, massiv_Bin, 15);
               // massiv_Bin = massiv;
                Array.Sort(massiv_Bin);
                int poisk2 = Convert.ToInt32(textBox2.Text);

                for (int i1 = 0; i1 < massiv_Bin.Length; i1++) //поиск позиции
                {
                    if (massiv_Bin[i1] == poisk2)
                    {
                        label2.Text = Convert.ToString(i1+ 1);
                        break;
                    }
                }

                foreach (int elem in massiv_Bin) //показ сортированного массива
                {
                    label7.Text += elem + " ";
                }

                
                int left, right, seredina;
                left = 0;
                right = massiv_Bin.Length;

                bool flag2 = false;

                for (int i = 0; i < massiv_Bin.Length; i++) //бинарный поиск
                {
                    if (poisk == massiv_Bin.Max())
                    {
                        label5.Text = massiv_Bin.Max().ToString();
                        flag2 = true;
                        break;
                    }
                    if (poisk == massiv_Bin.Min())
                    {
                        label5.Text = massiv_Bin.Min().ToString();
                        flag2 = true;
                        break;
                    }
                    seredina = (left + right) / 2;
                    if (massiv_Bin[seredina] == poisk)
                    {
                        label5.Text =  massiv_Bin[seredina].ToString();
                        flag2 = true;
                        break;
                    }
                    else
                    {
                        if (poisk > massiv_Bin[seredina])
                            left = seredina + 1;
                        else
                            right = seredina ;
                    }
                }
                if (flag2 == false)
                    MessageBox.Show("Элемент не найден!", "", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Проверьте введенное значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
