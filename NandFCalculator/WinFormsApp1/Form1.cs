using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Calculator calculator = new Calculator();
        string current_number = ""; // menyimpan angka dari input pengguna
        bool AssignClicked = false; // menandai apakah tombol = sudah ditekan atau belum
        public Form1()
        {
            InitializeComponent();
        }
        // jika tombol angka di klik
        private void Number_Clicked(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            // menghapus angka dilayar jika dilayar angka 0 atau setelah diklik tanda =
            if(textBox_Result.Text == "0" || AssignClicked)
            {
                if(AssignClicked)
                {
                    textBox_Result.Clear();
                    AssignClicked = false;
                }
                else if(clicked.Text != ",")
                {
                    textBox_Result.Clear();
                }
            }
            if (current_number.Contains(",") && clicked.Text.Equals(","))
            {
                MessageBox.Show("Operasi tidak valid.");
            }
            // Mengubah tulisan di layar dan menyimpan angka ke current_number
            else if (clicked.Text.Equals("( - )"))
            {
                textBox_Result.Text = textBox_Result.Text + "-";
                current_number = current_number + "-";
            }
            else
            {
                textBox_Result.Text = textBox_Result.Text + clicked.Text;
                current_number = current_number + clicked.Text;
            }
            // Tombol yang terakhir di tekan bukan tombol operator, 
            // maka isOperation = false
            calculator.SetStateOperation(false);
        }
        // Jika tombol operator diklik
        // TODO: Yang paham materi Exception, bisa tambahin exc kalo 
        // pengguna menginput button_operator secara tidak wajar :v
        private void Operator_Clicked(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;

            try
            {
                // percabangan jika user menekan tombol operator setelah tombol =
                if (AssignClicked)
                {
                    AssignClicked = false;
                    calculator.SetStateOperation(true);

                    // memasukkan nilai Ans ke operand 1
                    string temp = calculator.GetAns().ToString();
                    calculator.SetOperand1(temp);

                    // menyimpan operator
                    calculator.SignOperator(clicked.Text);

                    // Menampilkan operator ke layar
                    if (clicked.Text.Equals("mod"))
                    {
                        textBox_Result.Text = textBox_Result.Text + "%";
                    }
                    else
                    {
                        textBox_Result.Text = textBox_Result.Text + clicked.Text;
                    }
                }
                else if (!calculator.GetStateOperation() && current_number.Equals("") && clicked.Text.Equals("-"))
                //percabangan saat awal diinput negatif
                {
                    textBox_Result.Clear();
                    AssignClicked = false;
                    textBox_Result.Text = textBox_Result.Text + clicked.Text;
                    current_number = current_number + clicked.Text;
                }
                else if (calculator.GetStateOperation() && current_number.Equals("") && clicked.Text.Equals("-"))
                //percaabangan setelah tanda operasi lalu ada simbol negatif
                {
                    textBox_Result.Text = textBox_Result.Text + clicked.Text;
                    current_number = current_number + clicked.Text;
                }
                else
                {
                    // mengubah isOperation menjadi true karena tombol operator diklik
                    calculator.SetStateOperation(true);

                    // Menyimpan angka ke operand1
                    calculator.SetOperand1(current_number);
                    current_number = "";

                    // Menyimpan operator yang diklik ke operatorSign
                    calculator.SignOperator(clicked.Text);

                    // Menampilkan operator ke layar
                    if (clicked.Text.Equals("mod"))
                    {
                        textBox_Result.Text = textBox_Result.Text + "%";
                    }
                    else
                    {
                        textBox_Result.Text = textBox_Result.Text + clicked.Text;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void asignButton(object sender, EventArgs e)
        {
            if (!AssignClicked)
            {
                try
                {
                    AssignClicked = true;

                    // Menyimpan angka ke operand 2
                    calculator.SetOperand2(current_number);
                    current_number = "";

                    // Menghitung operasi
                    double temp = calculator.calculate();

                    // Menampilkan hasil operasi
                    textBox_Result.Clear();
                    textBox_Result.Text = temp.ToString();

                    //set state operation false
                    calculator.SetStateOperation(false);
                    //set ans
                    calculator.SetAns(temp.ToString());
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }
        private void AC_button(object sender, EventArgs e)
        {
            calculator.Reset();
            current_number = "";
            textBox_Result.Text = "0";
        }

        private void MC_Button(object sender, EventArgs e)
        //button mc untuk save ke queue
        {
            if (current_number.Equals(""))
            {
                if (calculator.GetAns() != 0)
                {
                    calculator.SetMemory(calculator.GetAns().ToString());
                    MessageBox.Show(calculator.GetAns().ToString() + " berhasil dimasukkan ke queue");
                }
                else
                {
                    MessageBox.Show("tidak ada yang di simpan");
                }

            }
            else
            {
                calculator.SetMemory(current_number);
                MessageBox.Show(current_number + " berhasil dimasukkan ke queue");
            }
        }

        private void MR_Button(object sender, EventArgs e)
        {
            if (calculator.isMemEmpty())
            {
                MessageBox.Show("Queue kosong");
            }
            else
            {
                string temp = calculator.GetMemory().ToString();
                textBox_Result.Text = textBox_Result.Text + temp;
                current_number = temp;
            }

        }
        private void buttonAns_Click(object sender, EventArgs e)
        {
            string temp = calculator.GetAns().ToString();
            if (AssignClicked)
            {
                textBox_Result.Clear();
                textBox_Result.Text = temp;
                AssignClicked = false;
            }
            else
            {
                textBox_Result.Text = textBox_Result.Text + temp;
            }
            current_number = temp;
        }
    }
}
