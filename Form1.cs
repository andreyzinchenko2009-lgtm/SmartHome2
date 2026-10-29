using System;
using System.Windows.Forms;

namespace SmartHome
{
    // ФОРМА 1 - вітання
    public partial class Form1 : Form
    {
        Label labelTitle;
        Label labelName;
        TextBox textBoxName;
        Button buttonStart;

        public Form1()
        {
            // налаштування вікна
            this.Text = "Smart Home";
            this.Size = new System.Drawing.Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;

            // назва програми
            labelTitle = new Label();
            labelTitle.Text = "Майстер налаштування Smart Home";
            labelTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            labelTitle.Location = new System.Drawing.Point(20, 20);
            labelTitle.AutoSize = true;
            this.Controls.Add(labelTitle);

            // підпис
            labelName = new Label();
            labelName.Text = "Ім'я замовника:";
            labelName.Location = new System.Drawing.Point(20, 80);
            labelName.AutoSize = true;
            this.Controls.Add(labelName);

            // поле для імені
            textBoxName = new TextBox();
            textBoxName.Location = new System.Drawing.Point(150, 77);
            textBoxName.Width = 200;
            this.Controls.Add(textBoxName);

            // кнопка
            buttonStart = new Button();
            buttonStart.Text = "Почати налаштування";
            buttonStart.Location = new System.Drawing.Point(100, 130);
            buttonStart.Size = new System.Drawing.Size(170, 35);
            buttonStart.Click += buttonStart_Click;
            this.Controls.Add(buttonStart);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // перевіряємо чи не порожнє поле
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Введіть ім'я замовника!");
            }
            else
            {
                Form2 f2 = new Form2(textBoxName.Text, this);
                f2.Show();
                this.Hide();
            }
        }

        // цей метод викличе Form3, щоб очистити поле
        public void ClearFields()
        {
            textBoxName.Clear();
        }
    }
}