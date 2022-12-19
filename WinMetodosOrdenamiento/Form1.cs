using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WinMetodosOrdenamiento
{
    public partial class Form1 : Form
    {
        DataSet contenedor = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Thread mihilo = new Thread(
                    delegate()
                    {
                        CargarArchivo();
                        if (button1.InvokeRequired)
                        {
                            button1.Invoke(new MethodInvoker(delegate
                            {
                                button1.Enabled = true;
                            }));
                        }
                    }
                );
            mihilo.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Thread mihilo = new Thread(
                    delegate ()
                    {
                        
                        if (dataGridView1.InvokeRequired)
                        {
                            dataGridView1.Invoke(new MethodInvoker(delegate
                            {
                                MostrarArchivo();
                            }));
                        }
                        if (button2.InvokeRequired)
                        {
                            button2.Invoke(new MethodInvoker(delegate
                            {
                                button2.Enabled = true;
                            }));
                        }
                    }
                );
            mihilo.Start();
        }
        public void CargarArchivo()
        {
            contenedor.ReadXml(@"E:\PWA\datos.xml");
            MessageBox.Show("Datos cargados");
        }

        public void MostrarArchivo()
        {
            dataGridView1.DataSource = contenedor.Tables[0];
            MessageBox.Show("Tiene " + contenedor.Tables[0].Rows.Count + " total de registros");
        }


        public void ordenamientoBurbujaEnteros()
        {
            int[] numeros = new int[20];
            Random aleatorio = new Random();
            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = aleatorio.Next(50, 200) + 1;
            }
            int x = 0, indiceInicial = 0, indiceSiguiente = 0, temporal = 0;
            for (x = 0; x < numeros.Length; x++)
            {
                for (indiceInicial = 0; indiceInicial < numeros.Length - 1; indiceInicial++)
                {
                    indiceSiguiente = indiceInicial + 1;
                    if(numeros[indiceInicial] > numeros[indiceSiguiente])
                    {
                        temporal = numeros[indiceInicial];
                        numeros[indiceInicial] = numeros[indiceSiguiente];
                        numeros[indiceSiguiente] = temporal;
                    }
                }
            }
            int c = 0;
            listBox1.Items.Clear();
            for (c = 0; c < numeros.Length; c++)
            {
                listBox1.Items.Add(numeros[c]);
            }
        }
        public void ordenamientoBurbujaCadena()
        {
            DataTable cadenas_ = contenedor.Tables[0];
            int i = 0, IndiceInicial = 0;
            for (i = 0; i < cadenas_.Rows.Count; i++)
            {
                for (IndiceInicial = 0; IndiceInicial < cadenas_.Rows.Count - 1; IndiceInicial++)
                {
                    int indiceProxima = IndiceInicial + 1;
                    if ((cadenas_.Rows[IndiceInicial]["descripcion"].ToString().Trim()).CompareTo(cadenas_.Rows[indiceProxima]["descripcion"].ToString().Trim()) > 0)
                    {
                        string descrip = cadenas_.Rows[IndiceInicial]["descripcion"].ToString().Trim();
                        string sat = cadenas_.Rows[IndiceInicial]["sat_unimed"].ToString();
                        string simb = cadenas_.Rows[IndiceInicial]["simbolo"].ToString();
                        cadenas_.Rows[IndiceInicial]["descripcion"] = cadenas_.Rows[indiceProxima]["descripcion"];
                        cadenas_.Rows[IndiceInicial]["sat_unimed"] = cadenas_.Rows[indiceProxima]["sat_unimed"];
                        cadenas_.Rows[IndiceInicial]["simbolo"] = cadenas_.Rows[indiceProxima]["simbolo"];
                        cadenas_.Rows[indiceProxima]["descripcion"] = descrip;
                        cadenas_.Rows[indiceProxima]["sat_unimed"] = sat;
                        cadenas_.Rows[indiceProxima]["simbolo"] = simb;
                    }
                }
            }
        }

        public void ordenamientoShellSort()
        {
            DataTable cadenas = contenedor.Tables[0];
            int salto = 0;
            int sw = 0;
            int a = 0;
            salto = cadenas.Rows.Count / 2;
            while (salto > 0)
            {
                sw = 1;
                while (sw != 0)
                {
                    sw = 0;
                    a = 1;
                    while (a <= (cadenas.Rows.Count - salto))
                    {
                        if ((cadenas.Rows[a - 1]["descripcion"].ToString().Trim()).CompareTo((cadenas.Rows[(a - 1) + salto]["descripcion"].ToString().Trim())) > 0)
                        {
                            string descrip = cadenas.Rows[(a - 1) + salto]["descripcion"].ToString().Trim();
                            string sat = cadenas.Rows[(a - 1) + salto]["sat_unimed"].ToString();
                            string simb = cadenas.Rows[(a - 1) + salto]["simbolo"].ToString();

                            cadenas.Rows[(a - 1) + salto]["descripcion"] = cadenas.Rows[a - 1]["descripcion"].ToString();
                            cadenas.Rows[(a - 1) + salto]["sat_unimed"] = cadenas.Rows[a - 1]["sat_unimed"].ToString();
                            cadenas.Rows[(a - 1) + salto]["simbolo"] = cadenas.Rows[a - 1]["simbolo"].ToString();
                            cadenas.Rows[(a - 1)]["descripcion"] = descrip;
                            cadenas.Rows[(a - 1)]["sat_unimed"] = sat;
                            cadenas.Rows[(a - 1)]["simbolo"] = simb;

                            sw = sw - 1;
                        }
                        a++;
                    }
                }
                salto = salto / 2;
            }
        }

        public void ordenamientoEnterosShellSort()
        {
            int[] numeros = new int[20];
            Random aleatorio = new Random();
            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = aleatorio.Next(50, 200) + 1;
            }

            int salto = 0;
            int sw = 0;
            int a = 0;
            salto = numeros.Length / 2;
            while (salto > 0)
            {
                sw = 1;
                while (sw != 0)
                {
                    sw = 0;
                    a = 1;
                    while (a <= (numeros.Length - salto))
                    {
                        if (numeros[a - 1] > numeros[a - 1 + salto])
                        {
                            int temp = numeros[(a - 1) + salto];
                            numeros[(a - 1) + salto] = numeros[a - 1];
                            numeros[a - 1] = temp;
                            sw = sw - 1;
                        }
                        a++;
                    }
                }
                salto = salto / 2;
            }

            int c = 0;
            listBox2.Items.Clear();
            for (c = 0; c < numeros.Length; c++)
            {
                listBox2.Items.Add(numeros[c]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread mihilo = new Thread(
                    delegate ()
                    {
                        if (listBox1.InvokeRequired)
                        {
                            listBox1.Invoke(new MethodInvoker(delegate
                            {
                                ordenamientoBurbujaEnteros();
                            }));
                        }
                    }
                    );
                    mihilo.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button6.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            Thread mihilo = new Thread(
                    delegate ()
                    {
                        ordenamientoBurbujaCadena();
                        if (dataGridView1.InvokeRequired)
                        {
                            dataGridView1.Invoke(new MethodInvoker(delegate {
                                MessageBox.Show("Proceso terminado");
                            }));
                        }
                        if (button1.InvokeRequired)
                        {
                            button1.Invoke(new MethodInvoker(delegate
                            {
                                button1.Enabled = true;
                            }));
                        }
                        if (button2.InvokeRequired)
                        {
                            button2.Invoke(new MethodInvoker(delegate
                            {
                                button2.Enabled = true;
                            }));
                        }
                        if (button4.InvokeRequired)
                        {
                            button4.Invoke(new MethodInvoker(delegate
                            {
                                button4.Enabled = true;
                            }));
                        }
                        if (button6.InvokeRequired)
                        {
                            button6.Invoke(new MethodInvoker(delegate
                            {
                                button6.Enabled = true;
                            }));
                        }
                    }
                );
            mihilo.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread mihilo = new Thread(
                    delegate ()
                    {
                        if (listBox1.InvokeRequired)
                        {
                            listBox1.Invoke(new MethodInvoker(delegate
                            {
                                ordenamientoEnterosShellSort();
                            }));
                        }
                    }
                    );
            mihilo.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            Thread mihilo = new Thread(
                    delegate ()
                    {
                        ordenamientoShellSort();
                        if (dataGridView1.InvokeRequired)
                        {
                            dataGridView1.Invoke(new MethodInvoker(delegate {
                                MessageBox.Show("Proceso terminado");
                            }));
                        }
                        if (button1.InvokeRequired)
                        {
                            button1.Invoke(new MethodInvoker(delegate
                            {
                                button1.Enabled = true;
                            }));
                        }
                        if (button2.InvokeRequired)
                        {
                            button2.Invoke(new MethodInvoker(delegate
                            {
                                button2.Enabled = true;
                            }));
                        }
                        if (button6.InvokeRequired)
                        {
                            button6.Invoke(new MethodInvoker(delegate
                            {
                                button6.Enabled = true;
                            }));
                        }

                        if (button4.InvokeRequired)
                        {
                            button4.Invoke(new MethodInvoker(delegate
                            {
                                button4.Enabled = true;
                            }));
                        }
                    }
                );
            mihilo.Start();


        }
    }
}
