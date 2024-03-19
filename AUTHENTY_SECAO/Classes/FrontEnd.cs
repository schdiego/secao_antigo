using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AUTHENTY_SECAO
{
    class FrontEnd
    {
        static char separador = Convert.ToChar(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        public static void conferirTbox_Leave(TextBox tBox, string mensagem, string arred, bool isInt, bool aceptZero, bool aceptMinus)
        {
            //define separador
            char separador2 = '.';
            if (separador == ',')
            {
                separador2 = '.';
            }
            else
            {
                separador2 = ',';
            }

            int espaco = tBox.Text.Count(s => s == ' ');

            if (espaco > 0)
            {
                tBox.Text = tBox.Text.Replace(" ", "");
            }

            int ponto = tBox.Text.Count(s => s == separador2);
            if (ponto > 0)
            {
                tBox.Text = tBox.Text.Replace(separador2.ToString(), separador.ToString());
            }
            int virgula = tBox.Text.Count(s => s == separador);

            if (virgula > 0 && isInt == true)
            {
                MessageBox.Show("Somente números inteiros", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tBox.BackColor = Color.Red;
                tBox.Focus();
            }
            else
            {
                if (virgula > 1)
                {
                    MessageBox.Show("Somente uma vírgula", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tBox.BackColor = Color.Red;
                    tBox.Focus();
                }
                else
                {
                    if (aceptZero == true)
                    {
                        if (string.IsNullOrEmpty(tBox.Text))
                        {
                            MessageBox.Show("Inserir algum número", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tBox.BackColor = Color.Red;
                            tBox.Focus();
                        }
                        else
                        {

                            if (Regex.IsMatch(tBox.Text, "[^0-9,.]") && aceptMinus == false)
                            {
                                MessageBox.Show("Por favor, apenas números positivos", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tBox.BackColor = Color.Red;
                                tBox.Focus();
                            }
                            else if(Regex.IsMatch(tBox.Text, "[^0-9,.-]") && aceptMinus == true)
                            {
                                MessageBox.Show("Por favor, apenas números", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tBox.BackColor = Color.Red;
                                tBox.Focus();
                                
                            }
                            else
                            {
                                if (tBox.Text != "0")
                                {
                                    if (tBox.Text == "00" || tBox.Text == "000" || tBox.Text == "0000" || tBox.Text == "00000" || tBox.Text == "000000" || tBox.Text == "0000000" || tBox.Text == "00000000" || tBox.Text == "000000000" || tBox.Text == "0000000000" || tBox.Text == "00000000000")
                                    {
                                        tBox.Text = "0";
                                        conferirTbox_Leave(tBox, mensagem, arred, isInt, aceptZero, aceptMinus);
                                    }
                                    else
                                    {
                                        tBox.Text = tBox.Text.TrimStart('0');
                                        tBox.Text = Convert.ToDouble(tBox.Text).ToString(arred);

                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(tBox.Text) || tBox.Text == "0")
                        {
                            MessageBox.Show(mensagem, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tBox.BackColor = Color.Red;
                            tBox.Focus();
                        }
                        else
                        {
                            if (Regex.IsMatch(tBox.Text, "[^0-9,.]") && aceptMinus == false)
                            {
                                MessageBox.Show("Por favor, apenas números positivos", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tBox.BackColor = Color.Red;
                                tBox.Focus();
                            }
                            else if (Regex.IsMatch(tBox.Text, "[^0-9,.-]") && aceptMinus == true)
                            {
                                MessageBox.Show("Por favor, apenas números", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tBox.BackColor = Color.Red;
                                tBox.Focus();
                            }
                            else
                            {
                                if (tBox.Text == "00" || tBox.Text == "000" || tBox.Text == "0000" || tBox.Text == "00000" || tBox.Text == "000000" || tBox.Text == "0000000" || tBox.Text == "00000000" || tBox.Text == "000000000" || tBox.Text == "0000000000" || tBox.Text == "00000000000")
                                {
                                    tBox.Text = "0";
                                    conferirTbox_Leave(tBox, mensagem, arred, isInt, aceptZero, aceptMinus);
                                }
                                else
                                {
                                    tBox.Text = tBox.Text.TrimStart('0');
                                    tBox.Text = Convert.ToDouble(tBox.Text).ToString(arred);

                                }
                            }
                        }
                    }

                }
            }

        }

        public static void conferirTbox_TextChange(TextBox tBox)
        {
            tBox.BackColor = Color.White;


        }
        public static void Tbox_PressEnter(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }

        }

        public static void conferirTabela_Leave(DataGridView dataGrid, string text, int rowIndex, int columnIndex, string mensagem, string arred, bool isInt, bool aceptZero, bool showMessage)
        {

            int espaco = text.Count(s => s == ' ');
            if (espaco > 0)
            {
                text = text.Replace(" ", "");
            }
            int ponto = text.Count(s => s == '.');
            if (ponto > 0)
            {
                text = text.Replace(".", ",");
            }
            int virgula = text.Count(s => s == ',');

            if (virgula > 0 && isInt == true)
            {
                MessageBox.Show("Somente números inteiros", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                dataGrid.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.OrangeRed;
                dataGrid.CurrentCell = dataGrid.Rows[rowIndex].Cells[columnIndex];
            }
            else
            {
                if (virgula > 1)
                {
                    MessageBox.Show("Somente uma vírgula", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGrid.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.OrangeRed;
                    dataGrid.CurrentCell = dataGrid.Rows[rowIndex].Cells[columnIndex];
                }
                else
                {
                    if (aceptZero == true)
                    {
                        if (string.IsNullOrEmpty(text))
                        {
                            MessageBox.Show("Inserir algum número", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGrid.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.OrangeRed;
                        }
                        else
                        {
                            if (Regex.IsMatch(text, "[^0-9,]"))
                            {
                                MessageBox.Show("Por favor, apenas números", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dataGrid.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.OrangeRed;
                            }
                            else
                            {
                                if (text != "0")
                                {
                                    if (text == "00" || text == "000" || text == "0000" || text == "00000" || text == "000000" || text == "0000000" || text == "00000000" || text == "000000000" || text == "0000000000" || text == "00000000000")
                                    {
                                        text = "0";
                                        conferirTabela_Leave(dataGrid, text, rowIndex, columnIndex, mensagem, arred, isInt, aceptZero, showMessage);
                                    }
                                    else
                                    {
                                        text = text.TrimStart('0');
                                        text = Convert.ToDouble(text).ToString(arred);

                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(text) || text == "0")
                        {
                            if (showMessage == true)
                            {
                                MessageBox.Show(mensagem, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            dataGrid.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.OrangeRed;
                        }
                        else
                        {
                            if (Regex.IsMatch(text, "[^0-9,]"))
                            {
                                MessageBox.Show("Por favor, apenas números", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dataGrid.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.OrangeRed;
                            }
                            else
                            {
                                if (text == "00" || text == "000" || text == "0000" || text == "00000" || text == "000000" || text == "0000000" || text == "00000000" || text == "000000000" || text == "0000000000" || text == "00000000000")
                                {
                                    text = "0";
                                    conferirTabela_Leave(dataGrid, text, rowIndex, columnIndex, mensagem, arred, isInt, aceptZero, showMessage);
                                }
                                else
                                {
                                    text = text.TrimStart('0');
                                    text = Convert.ToDouble(text).ToString(arred);

                                }
                            }
                        }
                    }

                }
            }

            dataGrid.Rows[rowIndex].Cells[columnIndex].Value = text;
            dataGrid.CurrentCell = dataGrid.Rows[rowIndex].Cells[columnIndex];
            dataGrid.Rows[rowIndex].Cells[columnIndex].Selected = true;
        }


    }
}
