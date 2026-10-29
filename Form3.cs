using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartHome
{
    // ФОРМА 3 - кошторис
    public partial class Form3 : Form
    {
        Form1 form1;
        Form2 form2;
        bool canExit = true;

        Label labelTitle;
        TextBox textBoxList;
        Label labelTotal;
        Button buttonNew;
        Button buttonExit;

        public Form3(string name, List<string> items, int sum, Form1 f1, Form2 f2)
        {
            form1 = f1;
            form2 = f2;

            this.Text = "Кошторис";
            this.Size = new System.Drawing.Size(420, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += Form3_FormClosed;

            // заголовок
            labelTitle = new Label();
            labelTitle.Text = "Фінальний кошторис проекту: " + name;
            labelTitle.Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold);
            labelTitle.Location = new System.Drawing.Point(20, 15);
            labelTitle.AutoSize = true;
            this.Controls.Add(labelTitle);

            // список обладнання
            textBoxList = new TextBox();
            textBoxList.Multiline = true;
            textBoxList.ReadOnly = true;
            textBoxList.Location = new System.Drawing.Point(20, 50);
            textBoxList.Size = new System.Drawing.Size(360, 200);
            // кожен пункт з нового рядка
            string text = "";
            foreach (string item in items)
            {
                text = text + item + Environment.NewLine;
            }
            textBoxList.Text = text;
            this.Controls.Add(textBoxList);

            // загальна сума
            labelTotal = new Label();
            labelTotal.Text = "Разом до оплати: " + sum + " грн";
            labelTotal.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            labelTotal.Location = new System.Drawing.Point(20, 270);
            labelTotal.AutoSize = true;
            this.Controls.Add(labelTotal);

            // кнопка нове замовлення
            buttonNew = new Button();
            buttonNew.Text = "Оформити нове замовлення";
            buttonNew.Location = new System.Drawing.Point(20, 320);
            buttonNew.Size = new System.Drawing.Size(200, 40);
            buttonNew.Click += buttonNew_Click;
            this.Controls.Add(buttonNew);

            // кнопка вийти
            buttonExit = new Button();
            buttonExit.Text = "Вийти";
            buttonExit.Location = new System.Drawing.Point(240, 320);
            buttonExit.Size = new System.Drawing.Size(140, 40);
            buttonExit.Click += buttonExit_Click;
            this.Controls.Add(buttonExit);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            canExit = false;          // щоб програма не закрилась
            form2.canExit = false;
            form2.Close();            // закриваємо другу форму
            form1.ClearFields();      // очищаємо поле імені
            form1.Show();             // показуємо першу форму
            this.Close();             // закриваємо цю форму
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (canExit == true)
            {
                Application.Exit();
            }
        }
    }
}