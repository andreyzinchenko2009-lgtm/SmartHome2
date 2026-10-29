using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartHome
{
    // ФОРМА 2 - вибір обладнання
    public partial class Form2 : Form
    {
        string customerName;
        Form1 form1;
        public bool canExit = true; // чи закривати програму при закритті вікна

        Label labelGreeting;

        GroupBox groupBoxController;
        RadioButton radioArduino;
        RadioButton radioEsp;
        RadioButton radioRaspberry;

        GroupBox groupBoxSensors;
        CheckBox checkTemp;
        CheckBox checkServo;
        CheckBox checkLcd;
        CheckBox checkKeypad;

        GroupBox groupBoxRooms;
        NumericUpDown numericRooms;

        Button buttonCalc;

        public Form2(string name, Form1 f1)
        {
            customerName = name;
            form1 = f1;

            this.Text = "Конфігуратор";
            this.Size = new System.Drawing.Size(420, 560);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += Form2_FormClosed;

            // привітання
            labelGreeting = new Label();
            labelGreeting.Text = "Проект для: " + customerName;
            labelGreeting.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            labelGreeting.Location = new System.Drawing.Point(20, 15);
            labelGreeting.AutoSize = true;
            this.Controls.Add(labelGreeting);

            // ---- Блок 1: контролер (RadioButton) ----
            groupBoxController = new GroupBox();
            groupBoxController.Text = "Тип контролера";
            groupBoxController.Location = new System.Drawing.Point(20, 50);
            groupBoxController.Size = new System.Drawing.Size(360, 110);
            this.Controls.Add(groupBoxController);

            radioArduino = new RadioButton();
            radioArduino.Text = "Arduino Uno - 500 грн";
            radioArduino.Location = new System.Drawing.Point(15, 20);
            radioArduino.AutoSize = true;
            radioArduino.Checked = true; // за замовчуванням
            groupBoxController.Controls.Add(radioArduino);

            radioEsp = new RadioButton();
            radioEsp.Text = "ESP8266 - 300 грн";
            radioEsp.Location = new System.Drawing.Point(15, 50);
            radioEsp.AutoSize = true;
            groupBoxController.Controls.Add(radioEsp);

            radioRaspberry = new RadioButton();
            radioRaspberry.Text = "Raspberry Pi - 2500 грн";
            radioRaspberry.Location = new System.Drawing.Point(15, 80);
            radioRaspberry.AutoSize = true;
            groupBoxController.Controls.Add(radioRaspberry);

            // ---- Блок 2: датчики (CheckBox) ----
            groupBoxSensors = new GroupBox();
            groupBoxSensors.Text = "Датчики та модулі";
            groupBoxSensors.Location = new System.Drawing.Point(20, 175);
            groupBoxSensors.Size = new System.Drawing.Size(360, 140);
            this.Controls.Add(groupBoxSensors);

            checkTemp = new CheckBox();
            checkTemp.Text = "Датчик температури TMP36 - 150 грн";
            checkTemp.Location = new System.Drawing.Point(15, 20);
            checkTemp.AutoSize = true;
            groupBoxSensors.Controls.Add(checkTemp);

            checkServo = new CheckBox();
            checkServo.Text = "Сервопривід для дверей - 200 грн";
            checkServo.Location = new System.Drawing.Point(15, 50);
            checkServo.AutoSize = true;
            groupBoxSensors.Controls.Add(checkServo);

            checkLcd = new CheckBox();
            checkLcd.Text = "LCD дисплей - 350 грн";
            checkLcd.Location = new System.Drawing.Point(15, 80);
            checkLcd.AutoSize = true;
            groupBoxSensors.Controls.Add(checkLcd);

            checkKeypad = new CheckBox();
            checkKeypad.Text = "Матрична клавіатура - 100 грн";
            checkKeypad.Location = new System.Drawing.Point(15, 110);
            checkKeypad.AutoSize = true;
            groupBoxSensors.Controls.Add(checkKeypad);

            // ---- Блок 3: кімнати (NumericUpDown) ----
            groupBoxRooms = new GroupBox();
            groupBoxRooms.Text = "Кількість кімнат (1000 грн за кімнату)";
            groupBoxRooms.Location = new System.Drawing.Point(20, 330);
            groupBoxRooms.Size = new System.Drawing.Size(360, 70);
            this.Controls.Add(groupBoxRooms);

            numericRooms = new NumericUpDown();
            numericRooms.Minimum = 1;
            numericRooms.Maximum = 5;
            numericRooms.Value = 1;
            numericRooms.Location = new System.Drawing.Point(15, 25);
            groupBoxRooms.Controls.Add(numericRooms);

            // ---- кнопка ----
            buttonCalc = new Button();
            buttonCalc.Text = "Розрахувати кошторис";
            buttonCalc.Location = new System.Drawing.Point(100, 430);
            buttonCalc.Size = new System.Drawing.Size(190, 40);
            buttonCalc.Click += buttonCalc_Click;
            this.Controls.Add(buttonCalc);
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            int sum = 0;
            List<string> items = new List<string>();

            // контролер
            if (radioArduino.Checked)
            {
                sum = sum + 500;
                items.Add("Arduino Uno - 500 грн");
            }
            if (radioEsp.Checked)
            {
                sum = sum + 300;
                items.Add("ESP8266 - 300 грн");
            }
            if (radioRaspberry.Checked)
            {
                sum = sum + 2500;
                items.Add("Raspberry Pi - 2500 грн");
            }

            // датчики
            if (checkTemp.Checked)
            {
                sum = sum + 150;
                items.Add("Датчик температури TMP36 - 150 грн");
            }
            if (checkServo.Checked)
            {
                sum = sum + 200;
                items.Add("Сервопривід для дверей - 200 грн");
            }
            if (checkLcd.Checked)
            {
                sum = sum + 350;
                items.Add("LCD дисплей - 350 грн");
            }
            if (checkKeypad.Checked)
            {
                sum = sum + 100;
                items.Add("Матрична клавіатура - 100 грн");
            }

            // кімнати
            int rooms = (int)numericRooms.Value;
            int roomsPrice = rooms * 1000;
            sum = sum + roomsPrice;
            items.Add("Проводка: кімнат " + rooms + " - " + roomsPrice + " грн");

            // відкриваємо третю форму
            Form3 f3 = new Form3(customerName, items, sum, form1, this);
            f3.Show();
            this.Hide();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (canExit == true)
            {
                Application.Exit();
            }
        }
    }
}