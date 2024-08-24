using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace micompilador_ACC
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> variablesConTipoDato = new Dictionary<string, string>();
        private Dictionary<string, string> variablesConValor = new Dictionary<string, string>();
        private Dictionary<string, string> variableTranslations = new Dictionary<string, string>();
        private string archivooriginal = "C:\\MyCompilerProgram\\LenguajeOriginal.txt";
        private string archivotraducido = "C:\\MyCompilerProgram\\LenguajeTraducido.txt";
        private string archivoseleccionado;
        private string UbicacionAyuda = "C:\\MyCompilerProgram\\Ayuda.txt";
        private string ejemplos = "C:\\MyCompilerProgram\\ejemplos.txt";

        public Form1()
        {
            InitializeComponent();
            // Inicializar el diccionario con las traducciones de nombres de variables
            variableTranslations.Add("entero", "Integer");
            variableTranslations.Add("cadena", "String");
            variableTranslations.Add("booleano", "Boolean");
            variableTranslations.Add("smallint", "Byte");
            archivoseleccionado = "C:\\MyCompilerProgram\\LenguajeOriginal.txt";
            lst_Errores.Columns.Add("Fila", 50);
            lst_Errores.Columns.Add("Error", 600);
            lst_Errores.View = View.Details;
            lst_Errores.FullRowSelect = true;
            lst_Errores.GridLines = true;
            leerLenguajeOriginal();
        }

        private void leerLenguajeOriginal()
        {
            StreamReader fileLenguajeOriginal = new StreamReader(archivoseleccionado);
            string linea = fileLenguajeOriginal.ReadLine();
            this.lstlenguajeoriginal.Items.Clear();
            int i = 0;
            while (linea != null)
            {
                i++;
                this.lstlenguajeoriginal.Items.Add(i + " - " + linea);
                linea = fileLenguajeOriginal.ReadLine();
            }
            fileLenguajeOriginal.Close();
        }

        private void leerLenguajeTraducido()
        {
            StreamReader fileLenguajeTraducido = new StreamReader(archivotraducido);
            string linea = fileLenguajeTraducido.ReadLine();
            List<string> declaraciones = new List<string>();
            this.lstlenguajetraducido.Items.Clear();

            bool ejecucion_correcta = false;
            if (Convert.ToInt16(TxtNoTraducido.Text) == 0)
            {
                ejecucion_correcta = true;
            }
            string ContenidoAImprimir = "";
            int i = 0;
            bool  AceptacionIf = true;
            while (linea != null)
            {
                i++;
                string[] contenido = linea.Split();
                this.lstlenguajetraducido.Items.Add(i + " - "+linea);
                if (!ejecucion_correcta)
                {
                    linea = fileLenguajeTraducido.ReadLine();
                }
                else
                {
                    if (variablesConTipoDato.ContainsKey(contenido[0]))
                    {
                        var ElDato = variablesConTipoDato.FirstOrDefault(x => x.Key.Contains(contenido[0])).Value;

                        if (ElDato == "entero" || ElDato == "smallint")
                        {
                            string valTemp = "";
                            for (int z = 2; z < contenido.Length; z++)
                            {
                                if (variablesConTipoDato.ContainsKey(contenido[z]))
                                    valTemp += variablesConValor[contenido[z]];
                                else
                                    valTemp += contenido[z];
                            }
                            // 2 + 2
                            DataTable dt = new DataTable();
                            var resultado = dt.Compute(valTemp, "");
                            variablesConValor[contenido[0]] = resultado.ToString();
                        }
                        else if (ElDato == "booleano")
                        {
                            variablesConValor[contenido[0]] = contenido[2];
                        }
                        else if (ElDato == "cadena")
                        {
                            string valTemp = contenido[2];
                            for (int z = 3; z < contenido.Length; z++)
                            {
                                valTemp += " " + contenido[z];
                            }
                            variablesConValor[contenido[0]] = valTemp.Substring(1, valTemp.Length - 2) + "\n";
                        }
                    }
                    else if (contenido[0] == "msgBox(")
                    {
                        if (!AceptacionIf)
                        {
                            linea = fileLenguajeTraducido.ReadLine();
                            continue;
                        }
                        string ultimo1 = contenido[contenido.Length - 2];
                        if (contenido[1][0] == '\"' && ultimo1[ultimo1.Length - 1] == '\"')
                        {
                            string temp1 = contenido[1];
                            for (int z = 2; z < contenido.Length - 1; z++)
                            {
                                temp1 += " " + contenido[z];
                            }
                            ContenidoAImprimir += temp1.Substring(1, temp1.Length - 2) + "\n";
                        }
                        else if (variablesConTipoDato.ContainsKey(contenido[1]))
                            ContenidoAImprimir += variablesConValor[contenido[1]] + "\n";
                    }
                    else if (contenido[0] == "If")
                    {
                        string tempExp = "";
                        for (int x = 1; x<contenido.Length; x++)
                        {
                            tempExp += contenido[x];
                        }
                        DataTable table = new DataTable();
                        bool resultado = (bool)table.Compute(tempExp, "");
                        if (resultado)
                        {
                            AceptacionIf = true;
                        }
                        else{ AceptacionIf = false; }
                    }
                    else if (contenido[0] == "End" && contenido[1] == "if")
                    {
                        AceptacionIf = true;
                       
                    }
                    linea = fileLenguajeTraducido.ReadLine();
                }
            }
            fileLenguajeTraducido.Close();
            if (ejecucion_correcta)
            {
                try
                {
                    DisplayContent(ContenidoAImprimir);
                }
                catch { }
            }
        }

        private bool EsLaListaOriginal = false;
        #region nada
        private void lstOriginal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EsLaListaOriginal == true)
            {
                int selectedIndex = lstlenguajeoriginal.SelectedIndex;
                if (selectedIndex < lstlenguajetraducido.Items.Count && selectedIndex >= 0)
                {
                    lstlenguajetraducido.ClearSelected();
                    lstlenguajetraducido.SetSelected(selectedIndex, true);
                }
            }
        }

        private void lstTraducido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EsLaListaOriginal == false)
            {
                int selectedIndex = lstlenguajetraducido.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < lstlenguajeoriginal.Items.Count)
                {
                    lstlenguajeoriginal.ClearSelected();
                    lstlenguajeoriginal.SetSelected(selectedIndex, true);
                }
            }
        }

        private void lstTraducido_MouseClick(object sender, MouseEventArgs e)
        {
            EsLaListaOriginal = false;
        }

        private void lstOriginal_MouseClick(object sender, MouseEventArgs e)
        {
            EsLaListaOriginal = true;
        }

        private void lenguajeOriginalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //// Ruta del archivo
            //string rutaArchivo = "C:\\MyCompilerProgram\\lenguajeoriginal.txt";

            //try
            //{
            //    // Abre el archivo en modo de lectura
            //    using (StreamReader sr = new StreamReader(rutaArchivo))
            //    {
            //        // Lee el contenido del archivo y lo imprime en la consola
            //        string contenido = sr.ReadToEnd();
            //        Console.WriteLine("Contenido del archivo:\n" + contenido);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error al abrir el archivo: " + ex.Message);
            //}

            Process.Start("notepad.exe", archivooriginal);
        }

        private void lenguajeTraducidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //// Ruta del archivo
            //string rutaArchivo = "C:\\MyCompilerProgram\\lenguajetraducido.txt";

            //try
            //{
            //    // Abre el archivo en modo de lectura
            //    using (StreamReader sr = new StreamReader(rutaArchivo))
            //    {
            //        // Lee el contenido del archivo y lo imprime en la consola
            //        string contenido = sr.ReadToEnd();
            //        Console.WriteLine("Contenido del archivo:\n" + contenido);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error al abrir el archivo: " + ex.Message);
            //}

            Process.Start("notepad.exe", archivotraducido);
        }
     
        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rutaArchivoPDF = @"C:\MyCompilerProgram\Palabras_reservadas.pdf";
            try
            {
                Process proceso = new Process();
                proceso.StartInfo.FileName = rutaArchivoPDF;
                proceso.Start();
                proceso.WaitForExit();
                proceso.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("Error al abrir el archivo de PDF: " + ex.Message); }
        }

        private void ejemplosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivoseleccionado = "C:\\MyCompilerProgram\\ejemplos.txt";
            //leerLenguajeOriginal();
            btnCompilar_Click(sender, e);
        }

        private void ejemplo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivoseleccionado = "C:\\MyCompilerProgram\\U2\\Ejemplo1.txt";
            //leerLenguajeOriginal();
            btnCompilar_Click(sender, e);
        }

        private void ejemplo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivoseleccionado = @"C:\MyCompilerProgram\U2\Ejemplo2.txt";
            //leerLenguajeOriginal();
            btnCompilar_Click(sender, e);
        }

        private void ejemplo3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivoseleccionado = "C:\\MyCompilerProgram\\U2\\Ejemplo3.txt";
            //leerLenguajeOriginal();
            btnCompilar_Click(sender, e);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var acercaDeForm = new Form())
            {
                acercaDeForm.Text = "Acerca de";
                acercaDeForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                acercaDeForm.MaximizeBox = false;
                acercaDeForm.MinimizeBox = false;
                try
                {
                    var pictureBox = new PictureBox
                    {
                        Image = Image.FromFile("C:\\MyCompilerProgram\\UAMRR_Logotipo_2022.png"),
                        Location = new Point(20, 20),
                        Size = new Size(200, 53)
                    };
                    var UAMRRLabel = new Label
                    {
                        Text = "Unidad Académica Multidisciplinaria Reynosa Rodhe",
                        Location = new Point(20, 90),
                        AutoSize = true
                    };
                    var desarrolladorLabel = new Label
                    {
                        Text = "Desarrollador: Brandon Reyes De La Cruz",
                        Location = new Point(20, 120),
                        AutoSize = true
                    };
                    var materiaLabel = new Label
                    {
                        Text = "Materia: Programación de Sistemas de Base II",
                        Location = new Point(20, 150),
                        AutoSize = true
                    };
                    var semestreLabel = new Label
                    {
                        Text = "Noveno semestre ISC",
                        Location = new Point(20, 180),
                        AutoSize = true
                    };
                    acercaDeForm.Controls.Add(pictureBox);
                    acercaDeForm.Controls.Add(UAMRRLabel);
                    acercaDeForm.Controls.Add(desarrolladorLabel);
                    acercaDeForm.Controls.Add(materiaLabel);
                    acercaDeForm.Controls.Add(semestreLabel);
                }
                catch (Exception ex)
                { MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                acercaDeForm.ShowDialog();
            }
        }

        #endregion
        private void btnCompilar_Click(object sender, EventArgs e)
        {
            StreamReader archivoLenguajeOriginal = new StreamReader(archivoseleccionado);
            StreamWriter lenguajeTraducido = new StreamWriter(archivotraducido);
            int LineasCorrectas = 0, LineasIncorrectas = 0;
            string linea, variableNombre = "", variableTipo = "", operacion = "";
            lst_Errores.Items.Clear();
            int NumLinea = 0;
            while ((linea = archivoLenguajeOriginal.ReadLine()) != null)
            {

                NumLinea++;

                // Ignorar las líneas que solo contienen espacios en blanco o son vacías
                if (String.IsNullOrWhiteSpace(linea))
                {
                    //continue; // Salta al siguiente ciclo del bucle
                    lenguajeTraducido.WriteLine("");
                    continue;

                }

                string[] datos = linea.Split();
                if (datos.Length == 1)
                {
                    switch (datos[0])
                    {
                        case "inicioclase":
                            lenguajeTraducido.WriteLine("Public Class");
                            LineasCorrectas++;
                            break;
                        case "iniciofuncion":
                            lenguajeTraducido.WriteLine("Private Sub Form1_Load(sender As Object, e As EventArgs)Handles MyBase.Load");
                            LineasCorrectas++;
                            break;
                        case "finfuncion":
                            lenguajeTraducido.WriteLine("End Sub");
                            LineasCorrectas++;
                            break;
                        case "finclase":
                            lenguajeTraducido.WriteLine("End Class");
                            LineasCorrectas++;
                            break;
                        case "DoInicio":
                            lenguajeTraducido.WriteLine("Do");
                            LineasCorrectas++;
                            break;
                        case "else":
                            lenguajeTraducido.WriteLine("Else");
                            LineasCorrectas++;
                            break;
                        case "finif":
                            lenguajeTraducido.WriteLine("End if");
                            LineasCorrectas++;
                            break;
                        case "finswitch":
                            lenguajeTraducido.WriteLine("End Select");
                            LineasCorrectas++;
                            break;
                        case "finfor":
                            lenguajeTraducido.WriteLine("Next");
                            LineasCorrectas++;
                            break;
                        case "finwhile":
                            lenguajeTraducido.WriteLine("End While");
                            LineasCorrectas++;
                            break;
                        //messagebox
                        //case "messagebox":
                        //    lenguajeTraducido.WriteLine("msgBox()");
                        //    break;
                        case "writeline":
                            lenguajeTraducido.WriteLine("Console.WriteLine()");
                            LineasCorrectas++;
                            break;
                        default:
                            string[] msg = new string[2];
                            msg[0] = NumLinea.ToString();
                            msg[1] = "Error Lexico: Compilador no reconoce la instruccion"; // Syn 5
                            this.lst_Errores.Items.Add(new ListViewItem(msg));

                            // Si no se encuentra una traducción, escribir No se logro encontrar traduccion
                            lenguajeTraducido.WriteLine("Linea incorrecta");
                            LineasIncorrectas++;
                            break;
                    }
                }
                else if (datos.Length >= 2)
                {
                    switch (datos[0])
                    {
                        case "declara":

                            if (datos.Length == 3)
                            {
                                variableNombre = datos[1];
                                variableTipo = datos[2];
                                if (variableNombre == string.Empty)
                                {
                                    string[] msg = new string[2];
                                    msg[0] = NumLinea.ToString();
                                    msg[1] = "Error sintexis: Falta declarar el nombre de la variable"; // Syn 4
                                    this.lst_Errores.Items.Add(new ListViewItem(msg));

                                    lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                    LineasIncorrectas++;
                                    continue;
                                }

                                if (variableNombre == "inicioclase" || variableNombre == "iniciofuncion" || variableNombre == "finfuncion" || variableNombre == "else" ||
                                    variableNombre == "finclase" || variableNombre == "DoInicio" || variableNombre == "finswitch" || variableNombre == "finif" ||
                                    variableNombre == "finfor" || variableNombre == "finwhile")
                                {

                                    string[] msg = new string[2];
                                    msg[0] = NumLinea.ToString();
                                    msg[1] = "Error Semantico: No se puede tener nombres de palabras reservadas en las variables"; // Syn 2
                                    this.lst_Errores.Items.Add(new ListViewItem(msg));

                                    lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                    LineasIncorrectas++;
                                    continue;
                                }
                                // Traducir el tipo de variable si existe en el diccionario
                                if (variableTranslations.ContainsKey(variableTipo))
                                {
                                    variableTipo = variableTipo;
                                    lenguajeTraducido.WriteLine($"Dim {variableNombre} As {variableTipo}");
                                    LineasCorrectas++;
                                    variablesConTipoDato[variableNombre] = variableTipo;
                                    variablesConValor[variableNombre] = "";
                                }
                                else
                                {
                                    string[] msg = new string[2];
                                    msg[0] = NumLinea.ToString();
                                    msg[1] = "Error sintexis: Falta el tipo de dato"; // Syn 2
                                    this.lst_Errores.Items.Add(new ListViewItem(msg));

                                    lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                    LineasIncorrectas++;
                                    continue;

                                }
                            }
                            else if (datos.Length > 3)
                            {
                                string[] msg = new string[2];
                                msg[0] = NumLinea.ToString();
                                msg[1] = "Error de sintaxis: Tienes simbolos demas"; // Sem 1
                                this.lst_Errores.Items.Add(new ListViewItem(msg));
                                lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                LineasIncorrectas++;
                            }
                            else
                            {
                                string[] msg = new string[2];
                                msg[0] = NumLinea.ToString();
                                msg[1] = "Error de sintaxis:  Syntaxis incompleta"; // Syn 3
                                this.lst_Errores.Items.Add(new ListViewItem(msg));
                                lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                LineasIncorrectas++;
                            }

                            break;

                        case "coloca":
                            string tipoDato = "";
                            if (datos.Length < 4)
                            {
                                // Error:
                                string[] msg = new string[2];
                                msg[0] = NumLinea.ToString();
                                msg[1] = "Error de sintaxis:  Syntaxis incompleta"; // Syn 3
                                this.lst_Errores.Items.Add(new ListViewItem(msg));

                                lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                LineasIncorrectas++;
                                continue;
                            }
                            else if (datos.Length == 5)
                            {
                                // Error:
                                string[] msg = new string[2];
                                msg[0] = NumLinea.ToString();
                                msg[1] = "Error de sintaxis: Falta un simbolo"; // Syn 5
                                this.lst_Errores.Items.Add(new ListViewItem(msg));

                                lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                LineasIncorrectas++;
                                continue;
                            }

                            else if (datos.Length == 4 || datos.Length == 6)
                            {
                                variableNombre = datos[1];
                                string operadorAsignacion = datos[2];
                                string valorAsignado = datos[3];

                                if (datos[2] != "=")
                                {
                                    // Error:
                                    string[] msg = new string[2];
                                    msg[0] = NumLinea.ToString();
                                    msg[1] = "Error de sintaxis: No se encuentran simbolos de operacion/asignacion"; // Syn 3
                                    this.lst_Errores.Items.Add(new ListViewItem(msg));

                                    lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                    LineasIncorrectas++;
                                    continue;
                                }

                                if (!variablesConTipoDato.ContainsKey(variableNombre))
                                {
                                    string[] msg = new string[2];
                                    msg[0] = NumLinea.ToString();
                                    msg[1] = "Error semantico: Variable a asignar no inicializada"; // Syn 3
                                    this.lst_Errores.Items.Add(new ListViewItem(msg));

                                    lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                    LineasIncorrectas++; continue;
                                }
                                tipoDato = variablesConTipoDato[variableNombre];

                                if (datos.Length == 6)
                                {
                                    if (datos[4] != "+" && datos[4] != "-" && datos[4] != "*" && datos[4] != "/")
                                    {
                                        // Error:
                                        string[] msg = new string[2];
                                        msg[0] = NumLinea.ToString();
                                        msg[1] = "Error de sintaxis: Operacion invalida"; // Syn 3
                                        this.lst_Errores.Items.Add(new ListViewItem(msg));

                                        lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                        LineasIncorrectas++;
                                        continue;
                                    }
                                    string valorOperacion = datos[4];
                                    string valorAsignado2 = datos[5];

                                    if (
                                        (!variablesConTipoDato.ContainsKey(valorAsignado) && DatosCorrectos(tipoDato, valorAsignado) == false) ||
                                        (!variablesConTipoDato.ContainsKey(valorAsignado2) && DatosCorrectos(tipoDato, valorAsignado2) == false)
                                    )
                                    {
                                        string[] msg = new string[2];
                                        msg[0] = NumLinea.ToString();
                                        msg[1] = "Error semantico: El valor asignado no pertenece al respectivo tipo de dato de la variable"; // Syn 3
                                        this.lst_Errores.Items.Add(new ListViewItem(msg));

                                        lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                        LineasIncorrectas++; continue;

                                    }
                                    lenguajeTraducido.WriteLine($"{variableNombre} {operadorAsignacion} {valorAsignado} {valorOperacion} {valorAsignado2}");
                                    LineasCorrectas++;
                                }
                                else
                                {
                                    if (variablesConTipoDato.ContainsKey(valorAsignado) || DatosCorrectos(tipoDato, valorAsignado))
                                    {
                                        if (!variablesConTipoDato.ContainsKey(valorAsignado) && DatosCorrectos(tipoDato, valorAsignado) == false)
                                        {
                                            string[] msg = new string[2];
                                            msg[0] = NumLinea.ToString();
                                            msg[1] = "Error semantico: El valor asignado no pertenece al respectivo tipo de dato de la variable"; // Syn 3
                                            this.lst_Errores.Items.Add(new ListViewItem(msg));

                                            lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                            LineasIncorrectas++; continue;

                                        }
                                        lenguajeTraducido.WriteLine($"{variableNombre} {operadorAsignacion} {valorAsignado}");
                                        LineasCorrectas++;
                                    }
                                    else
                                    {
                                        string[] msg = new string[2];
                                        msg[0] = NumLinea.ToString();
                                        msg[1] = "Error semantico: El valor asignado no pertenece al respectivo tipo de dato de la variable"; // Syn 3
                                        this.lst_Errores.Items.Add(new ListViewItem(msg));
                                        lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                        LineasIncorrectas++;
                                        continue;
                                    }

                                }


                            }
                            else
                            {
                                // Error:
                                string[] msg = new string[2];
                                msg[0] = NumLinea.ToString();
                                msg[1] = "Error de sintaxis:  Tienes simbolos demas de lo permitido"; // Syn 3
                                this.lst_Errores.Items.Add(new ListViewItem(msg));

                                lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                LineasIncorrectas++;
                                continue;
                            }
                            break;
                        //if
                        // If 1 < 2
                        case "if":
                            variableNombre = datos[1];
                            variableTipo = datos[3];
                            if (datos[2] == "==" || datos[2] == "<" ||
                                datos[2] == ">" || datos[2] == ">=" ||
                                datos[2] == "<=" || datos[2] == "<>")
                            {
                                operacion = datos[2];
                                if (
                                    (variablesConTipoDato.ContainsKey(variableNombre) || variableNombre.All(char.IsDigit))
                                    &&
                                    (variablesConTipoDato.ContainsKey(datos[3]) || datos[3].All(char.IsDigit))
                                )
                                {
                                    lenguajeTraducido.WriteLine($"If {datos[1]} {operacion} {datos[3]}");
                                    LineasCorrectas++;
                                }
                                else
                                {
                                    string[] msg = new string[2];
                                    msg[0] = NumLinea.ToString();
                                    msg[1] = "Error Semantico: valores con tipo de dato que no corresponde"; // Syn 3
                                    this.lst_Errores.Items.Add(new ListViewItem(msg));
                                    LineasIncorrectas++;
                                    lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                }

                            }
                            else
                            {
                                string[] msg = new string[2];
                                msg[0] = NumLinea.ToString();
                                msg[1] = "Error de sintaxis: Faltan simbolos correctos"; // Syn 3
                                this.lst_Errores.Items.Add(new ListViewItem(msg));

                                LineasIncorrectas++;
                                lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                            }
                            break;

                        case "elseif":
                            variableNombre = datos[1];
                            variableTipo = datos[3];
                            if (datos[2] == "==" || datos[2] == "<" ||
                                datos[2] == ">" || datos[2] == ">-" ||
                                datos[2] == "<=" || datos[2] == "<>")
                            {
                                operacion = datos[2];
                                if (variablesConTipoDato.ContainsKey(variableNombre) && datos[3].All(char.IsDigit))
                                {
                                    lenguajeTraducido.WriteLine($"Else if {datos[1]} {operacion} {datos[3]}");
                                    LineasCorrectas++;
                                }
                                else
                                {
                                    string[] msg = new string[2];
                                    msg[0] = NumLinea.ToString();
                                    msg[1] = "Error Semantico: valores con tipo de dato que no corresponde"; // Syn 3
                                    this.lst_Errores.Items.Add(new ListViewItem(msg));
                                    LineasIncorrectas++;
                                    lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                }

                            }
                            else
                            {
                                string[] msg = new string[2];
                                msg[0] = NumLinea.ToString();
                                msg[1] = "Error Sintaxis: Simbolos incorrectos"; // Syn 3
                                this.lst_Errores.Items.Add(new ListViewItem(msg));
                                LineasIncorrectas++;
                                lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                            }
                            break;

                        case "imprime":
                            if (datos.Length == 2)
                            {
                                lenguajeTraducido.WriteLine("msgBox( " + datos[1] + " )");
                            }
                            else
                            {
                                LineasIncorrectas++;
                                lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                string[] msg = new string[2];
                                msg[0] = NumLinea.ToString();
                                msg[1] = "Error Sintaxis: Falta un valor"; // Sem 1
                                this.lst_Errores.Items.Add(new ListViewItem(msg));
                            }

                            break;
                        //for
                        case "for":
                            if (datos.Length == 8)
                            {
                                variableNombre = datos[1]; operacion = datos[2];
                                if (variablesConTipoDato.ContainsKey(variableNombre))
                                {
                                    if (operacion.Contains("de") == false || datos[4].Contains("al") == false || datos[6].Contains("paso") == false)
                                    {
                                        string[] msg = new string[2];
                                        msg[0] = NumLinea.ToString();
                                        msg[1] = "Error Sintaxis: Parametros incorrectos"; // Syn 3
                                        this.lst_Errores.Items.Add(new ListViewItem(msg));
                                        LineasIncorrectas++;
                                        lenguajeTraducido.WriteLine("No se logro encontrar traduccion");
                                        continue;
                                    }
                                    if (datos[3].All(char.IsDigit) == false || datos[5].All(char.IsDigit) == false || datos[7].All(char.IsDigit) == false)
                                    {
                                        string[] msg = new string[2];
                                        msg[0] = NumLinea.ToString();
                                        msg[1] = "Error Sintaxis: Falta valores numericos en el ciclo for";
                                        this.lst_Errores.Items.Add(new ListViewItem(msg));
                                        LineasIncorrectas++;
                                        lenguajeTraducido.WriteLine("No se logro encontrar traduccion");
                                        continue;
                                    }

                                    string variable = datos[1];
                                    string desdeStr = datos[3];
                                    string hastaStr = datos[5];

                                    if (int.TryParse(desdeStr, out int desde) && int.TryParse(hastaStr, out int hasta))
                                    {

                                        // Mostrar el resultado en la consola
                                        AllocConsole();
                                        for (int i = desde; i <= hasta; i++)
                                        {

                                            Console.WriteLine($"Iteraccion #: {i}");
                                            //Console.ReadLine();

                                        }
                                        FreeConsole();
                                    }

                                    lenguajeTraducido.WriteLine($"For {variableNombre} = {datos[3]} To {datos[5]} Step {datos[3]}");
                                    LineasCorrectas++;

                                }
                                else
                                {

                                    string[] msg = new string[2];
                                    msg[0] = NumLinea.ToString();
                                    msg[1] = "Error semantico: Sobrepasa la cantidad de simbolos"; // Sem 2
                                    this.lst_Errores.Items.Add(new ListViewItem(msg));

                                    lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                    LineasIncorrectas++;
                                }

                            }
                            else
                            {
                                string[] msg = new string[2];
                                msg[0] = NumLinea.ToString();
                                msg[1] = "Error Sintaxis: Simbolos incorrectos"; // Syn 3
                                this.lst_Errores.Items.Add(new ListViewItem(msg));
                                lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                LineasIncorrectas++;
                            }
                            break;

                        case "while":
                            if (datos.Length == 4)
                            {
                                string variableNombreWhile = datos[1];
                                string operacionWhile = datos[2];
                                string valorWhile = datos[3];

                                if (variablesConTipoDato.ContainsKey(variableNombreWhile))
                                {
                                    lenguajeTraducido.WriteLine($"While {variableNombreWhile} {operacionWhile} {valorWhile}");

                                    // Simulating a while loop in C# (replace with your logic)
                                    AllocConsole();
                                    int loopVarWhile = 0; // Initial value, replace with the appropriate initial value
                                    while (loopVarWhile <= 10) // Replace with your condition
                                    {
                                        Console.WriteLine($"Iteration #: {loopVarWhile}");
                                        loopVarWhile++; // Update the loop variable, replace with your logic
                                    }
                                    FreeConsole();

                                    LineasCorrectas++;
                                }
                                else
                                {
                                    // Error: Variable not declared
                                    string[] msg = new string[2];
                                    msg[0] = NumLinea.ToString();
                                    msg[1] = "Error Semantico: La variable en la condición no está declarada"; // Sem 3
                                    this.lst_Errores.Items.Add(new ListViewItem(msg));
                                    LineasIncorrectas++;
                                    lenguajeTraducido.WriteLine($"No se logró encontrar traducción");
                                }
                            }
                            else
                            {
                                // Error: Incorrect syntax
                                string[] msg = new string[2];
                                msg[0] = NumLinea.ToString();
                                msg[1] = "Error Sintaxis: Sintaxis incorrecta para la instrucción 'while'"; // Syn 3
                                this.lst_Errores.Items.Add(new ListViewItem(msg));
                                LineasIncorrectas++;
                                lenguajeTraducido.WriteLine($"No se logró encontrar traducción");
                            }
                            break;

                        //switch
                        //case
                        case "switch":
                            if (datos.Length == 2)
                            {
                                lenguajeTraducido.WriteLine("Select " + datos[1]);
                                LineasCorrectas++;
                            }
                            else
                            {
                                lenguajeTraducido.WriteLine("No se logro encontrar traduccion");
                                LineasIncorrectas++;
                            }
                            break;

                        case "case":
                            if (datos.Length == 2)
                            {
                                lenguajeTraducido.WriteLine("Case " + datos[1]);
                                LineasCorrectas++;
                            }
                            else
                            {
                                lenguajeTraducido.WriteLine("No se logro encontrar traduccion");
                                LineasIncorrectas++;
                            }
                            break;
                        //end switch

                        //do
                        //while
                        case "cerrardowhile":

                            //cerrardowhile x > 3
                            variableNombre = datos[1];
                            variableTipo = datos[3];
                            if (datos[2] == "==" || datos[2] == "<" ||
                                datos[2] == ">" || datos[2] == ">-" ||
                                datos[2] == "<=" || datos[2] == "<>")
                            {
                                if (
                                    (variablesConTipoDato.ContainsKey(datos[1]) || datos[1].All(char.IsDigit))
                                    &&
                                    (variablesConTipoDato.ContainsKey(datos[3]) || datos[3].All(char.IsDigit))

                                )
                                {
                                    operacion = datos[2];
                                    lenguajeTraducido.WriteLine($"Loop While {datos[1]} {operacion} {datos[3]}");
                                    LineasCorrectas++;
                                }
                                else
                                {
                                    string[] msg = new string[2];
                                    msg[0] = NumLinea.ToString();
                                    msg[1] = "Error Semantico: No se reconocen las variables y sus tipos de datos"; // Syn 2
                                    this.lst_Errores.Items.Add(new ListViewItem(msg));
                                    LineasIncorrectas++;
                                    lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                                }

                            }
                            else
                            {
                                string[] msg = new string[2];
                                msg[0] = NumLinea.ToString();
                                msg[1] = "Error Semantico: Los parametros no son correctos"; // Syn 2
                                this.lst_Errores.Items.Add(new ListViewItem(msg));
                                LineasIncorrectas++;
                                lenguajeTraducido.WriteLine($"No se logro encontrar traduccion");
                            }
                            break;

                        default:
                            string dato = datos[0];
                            if (dato == "inicioclase" || dato == "iniciofuncion" ||
                                dato == "finfuncion" || dato == "else" ||
                                dato == "finclase" || dato == "DoInicio" ||
                                dato == "finswitch" || dato == "finif" ||
                                dato == "finfor" || dato == "finwhile"
                            )
                            {
                                // Error de sintaxis
                                string[] msg = new string[2];
                                msg[0] = NumLinea.ToString();
                                msg[1] = "Error de sintaxis:  Tienes simbolos demas"; // Sem 1
                                this.lst_Errores.Items.Add(new ListViewItem(msg));
                            }
                            else
                            {
                                string[] msg = new string[2];
                                msg[0] = NumLinea.ToString();
                                msg[1] = "Error Lexico: El compilador no reconoce la instruccion"; // Lexi 1
                                this.lst_Errores.Items.Add(new ListViewItem(msg));
                            }

                            lenguajeTraducido.WriteLine("Linea incorrecta");
                            LineasIncorrectas++;
                            break;
                    }
                }
                else
                {
                    string[] msg = new string[2];
                    msg[0] = NumLinea.ToString();
                    msg[1] = "Error Lexico: No se reconoce la instruccion"; // Syn 3
                    this.lst_Errores.Items.Add(new ListViewItem(msg));
                    lenguajeTraducido.WriteLine("La linea esta vacia");
                    LineasIncorrectas++;
                }
            }
            archivoLenguajeOriginal.Close();
            lenguajeTraducido.Flush();
            lenguajeTraducido.Close();
            TextoTraducido.Text = LineasCorrectas.ToString();
            TxtNoTraducido.Text = LineasIncorrectas.ToString();
            leerLenguajeOriginal();
            leerLenguajeTraducido();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}