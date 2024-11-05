using OpenQA.Selenium.DevTools.V129.Page;
using System;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using static AutoReport.Form1;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoReport
{
    public partial class Form1 : Form
    {
        static string ServerPath = "Server_2.xml";
        static string ProgramPath = "Programmverzeichnis.xml";

        private ServerCollection serverCollection;
        private Programmverzeichnis programmverzeichnis;

        //Listen von Auswahlm�glichkeiten
        string[] Programmtypen = {"Backprogramm", "Reinigungsprogramm", "Verbindungstest"};
        string[] Zyklentypen = {"taeglich", "woechentlich", "14taegig", "monatlich", "jaehrlich"};
        string[] ExchangeServer = { "file4you", "Wiesheu_ftp", "Aldi_Secure" };

        public Form1()
        {
            InitializeComponent();

            serverCollection = new ServerCollection();
            programmverzeichnis = new Programmverzeichnis();

            // Aus der XML-Datei lesen
            try
            {
                serverCollection = DeserializeServerFromXml(ServerPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occur during XML Serialization :{ex.Message}");
            }

            try
            {
                programmverzeichnis = DeserializeProgrammFromXml(ProgramPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occur during XML Serialization :{ex.Message}");
            }


            //Beispielliste von Servern erstellen
            /*
            serverCollection.Servers.Add(new Server
            {
                Adresse = "localhost:876/Login",
                Reporttyp = "Backprogramm",
                Zyklus = "woechentlich",
                Startdatum = new DateTime(2024, 06, 01),
                Ausgabeziel = "file4you"
            });
            serverCollection.Servers.Add(new Server
            {
                Adresse = "localhost:876/Login",
                Reporttyp = "Backprogramm",
                Zyklus = "woechentlich",
                Startdatum = new DateTime(2024, 06, 01),
                Ausgabeziel = "file4you"
            });

            // Speichern in eine XML-Datei
            try
            {
            SerializeServerToXml(ServerPath, serverCollection);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occur during XML Serialization :{ex.Message}");
            }
            */

            /*
            //Beispielliste von Programmen erstellen
            programmCollection.Programms.Add(new Programm
            {
                Programmname = "Backprogramm",
                Schritte = new List<Schritt> // Adding steps to the Schritte list
                {
                    new Schritt
                    {
                        Schrittart = "URL_aufrufen",
                        Schrittdetail = "Backprogramm",
                        Text = "woechentlich",
                        Waittime = 1,
                        Schrittcheck = "file4you"
                    }
                }
            });
            programmCollection.Programms.Add(new Programm
            {
                Programmname = "localhost:876/Login",
                Schritte = new List<Schritt> // Adding steps to the Schritte list
                {
                    new Schritt
                    {
                        Schrittart = "URL_aufrufen",
                        Schrittdetail = "Backprogramm",
                        Text = "woechentlich",
                        Waittime = 1,
                        Schrittcheck = "file4you"
                    }
                }
            });

            // Speichern in eine XML-Datei
            try
            {
            SerializeProgrammToXml(ProgramPath, programmCollection);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occur during XML Serialization :{ex.Message}");
            }
            */
            
            
        }


        // Methode zum Server Deserialisieren
        public static ServerCollection DeserializeServerFromXml(string ServerPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ServerCollection));
            using (FileStream fs = new FileStream(ServerPath, FileMode.Open))
            {
                return (ServerCollection)serializer.Deserialize(fs);
            }
        }


        // Methode zum Server Serialisieren
        public static void SerializeServerToXml(string ServerPath, ServerCollection serverCollection)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ServerCollection));
            using (FileStream fs = new FileStream(ServerPath, FileMode.Create))
            {
                serializer.Serialize(fs, serverCollection);
            }
            MessageBox.Show($"Server wurden in '{ServerPath}' gespeichert.");
        }

        // Methode zum Programm Deserialisieren
        public static Programmverzeichnis DeserializeProgrammFromXml(string ProgramPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Programmverzeichnis));
            using (FileStream fs = new FileStream(ProgramPath, FileMode.Open))
            {
                return (Programmverzeichnis)serializer.Deserialize(fs);
            }
        }

        // Methode zum Programm Serialisieren
        public static void SerializeProgrammToXml(string ProgrammPath, Programmverzeichnis programmCollection)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Programmverzeichnis));
            using (FileStream fs = new FileStream(ProgrammPath, FileMode.Create))
            {
                serializer.Serialize(fs, programmCollection);
            }
            MessageBox.Show($"Server wurden in '{ProgramPath}' gespeichert.");
        }
        

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Form2button2_Click(object sender, EventArgs e, ComboBox Form2comboBox)
        {
            Form Form3 = new Form();
            Form3.Size = new Size(180, 130);
            Form3.Show();

            Label Form3lbl = new Label();
            Form3lbl.Text = "Programmname";
            Form3lbl.Location = new Point(5, 5);
            Form3.Controls.Add(Form3lbl);

            TextBox Form3tbx = new TextBox();
            Form3tbx.Size = new Size(150, 25);
            Form3tbx.Location = new Point(5, 30);
            Form3.Controls.Add(Form3tbx);

            Button Form3btn1 = new Button();
            Form3btn1.Text = "Speichern";
            Form3btn1.Location = new Point(5, 60);
            Form3.Controls.Add(Form3btn1);
            Form3btn1.Click += new EventHandler(Form3btn1_Click);

            void Form3btn1_Click(object sender, EventArgs e)
            {
                //Programmname zu Liste und Form2combobox hinzuf�gen
                if (!string.IsNullOrEmpty(Form3tbx.Text))
                {
                    //Form2comboBox.Items.Add(Form3tbn.Text);
                    var server = new Server()
                    {
                        Adresse = Form3tbx.Text,
                        //Adresse = "localhost:876/Login",
                        Reporttyp = "",
                        Zyklus = "",
                        Startdatum = new DateTime(2024, 06, 01),
                        Ausgabeziel = ""
                    };

                    try
                    {
                        var serializer = new XmlSerializer(typeof(Server));
                        using (var writer = new StreamWriter("Programmverzeichnis.xml"))
                        {
                            serializer.Serialize(writer, server);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Exception occur during XML Serialization :{ex.Message}");
                    }
                }
                Form3.Close();
            }

            Button Form3btn2 = new Button();
            Form3btn2.Text = "Abbrechen";
            Form3btn2.Location = new Point(80, 60);
            Form3.Controls.Add(Form3btn2);
            Form3btn2.Click += new EventHandler(Form3btn2_Click);

            void Form3btn2_Click(object sender, EventArgs e)
            {
                Form3.Close();
            }
        }
        //private void button3_Click(object sender, EventArgs e)
        private void btn_edit_Click(object sender, EventArgs e)
        {
            Form Form2 = new Form(); //Deine 2. Form
            Form2.Size = new Size(816, 489);
            Form2.Show();

            Button Form2btn = new Button();
            Form2btn.Text = "Speichern";
            Form2btn.Location = new Point(5, 5);
            Form2.Controls.Add(Form2btn);

            ComboBox Form2comboBox = new ComboBox();
            Form2comboBox.Size = new Size(116, 23);
            //Form2comboBox f�llen
            Form2comboBox.Location = new Point(5, 50);
            Form2.Controls.Add(Form2comboBox);

            Button Form2button2 = new Button();
            Form2button2.Size = new Size(25, 25);
            Form2button2.Location = new Point(150, 50);
            Form2button2.Text = "+";
            //Form2button2.Click += new EventHandler(Form2button2_Click,);
            Form2button2.Click += (s, args) => Form2button2_Click(s, args, Form2comboBox);



            Form2.Controls.Add(Form2button2);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GroupBox groupbox_main = new GroupBox();
            groupbox_main.Location = new Point(12, 28);
            groupbox_main.Size = new Size(776, 410);
            this.Controls.Add(groupbox_main);

            Button btn_edit = new Button();
            btn_edit.Location = new Point(5, 20);
            btn_edit.Size = new Size(75, 25);
            btn_edit.Text = "edit Skripts";
            btn_edit.Click += btn_edit_Click;
            groupbox_main.Controls.Add(btn_edit);

            Button btn_add = new Button();
            btn_add.Location = new Point(5, 50);
            btn_add.Size = new Size(25, 25);
            btn_add.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Bold);
            btn_add.Text = "+";
            btn_add.Click += btn_add_Click;
            groupbox_main.Controls.Add(btn_add);

            // 
            // vScrollBar1
            // 
            VScrollBar vScrollBar_Serv = new VScrollBar();
            vScrollBar_Serv.Location = new Point(756, 9);
            vScrollBar_Serv.Name = "vScrollBar1";
            vScrollBar_Serv.Size = new Size(17, 414);
            groupbox_main.Controls.Add(vScrollBar_Serv);
            //vScrollBar_Serv.Scroll += vScrollBarServ_Scroll;

            /*
            // Display the program name and steps
            foreach (var programm in programmverzeichnis.Programme)
            {
                MessageBox.Show($"Programmname: {programm.Programmname}");

                foreach (var schritt in programm.Schritte)
                {
                    MessageBox.Show($"Schrittart: {schritt.Schrittart}, Schrittdetail: {schritt.Schrittdetail}, " +
                                    $"Text: {schritt.Text}, Waittime: {schritt.Waittime}, Schrittcheck: {schritt.Schrittcheck}");
                }
            }
            */

            //fuer jeden Eintrag in "Server" eine Combobox gef�llt mit dropboxen erstellen und dropboxen setzen
            foreach (var server in serverCollection.Servers)
            {
                ///////////diesen gesamten Block ich eine Funktion Ueberfuehren!!!!------------------------------------------------------------------------------------------------------------
                GroupBox programmGroupBox = new GroupBox();
                programmGroupBox.Text = server.Adresse;
                programmGroupBox.Size = new Size(740, 60);
                programmGroupBox.Location = new Point(10, btn_add.Location.Y); //btn_add.Location = new Point(5, 50);
                btn_add.Location = (new Point(btn_add.Location.X, btn_add.Location.Y + 60));
                groupbox_main.Controls.Add(programmGroupBox);

                //programmeGroupbox fuellen

                // 
                // checkBox1
                // 
                CheckBox chbx = new CheckBox();
                chbx.AutoSize = true;
                chbx.Location = new Point(7, 25);
                //chbx.Name = "checkBox1";
                chbx.Size = new Size(15, 14);
                chbx.TabIndex = 5;
                chbx.UseVisualStyleBackColor = true;
                // chbx.CHECKED_CHANGED += ?????
                // 
                // comboBox_Rep_Typ
                // 
                TextBox tbx_Serv_Adr = new TextBox();
                tbx_Serv_Adr.Location = new Point(43, 20);
                tbx_Serv_Adr.Size = new Size(116, 23);
                tbx_Serv_Adr.Text = server.Adresse.ToString();
                //cbx_Serv_Adr.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                // 
                // comboBox_Rep_Typ
                // 
                ComboBox cbx_Rep_Typ = new ComboBox();
                cbx_Rep_Typ.FormattingEnabled = true;
                cbx_Rep_Typ.Location = new Point(165, 20);
                cbx_Rep_Typ.Name = "comboBox_Rep_Typ";
                cbx_Rep_Typ.Size = new Size(116, 23);
                //Programmtypen hinzuf�gen
                cbx_Rep_Typ.Items.AddRange(Programmtypen);
                cbx_Rep_Typ.SelectedItem = server.Reporttyp.ToString();
                //Programm aus xml vorauswaehlen

                //cbx_Rep_Typ.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
                // 
                // comboBox_zykl
                // 
                ComboBox cbx_zykl = new ComboBox();
                cbx_zykl.FormattingEnabled = true;
                cbx_zykl.Location = new Point(287, 20);
                cbx_zykl.Size = new Size(116, 23);
                cbx_zykl.Items.AddRange(Zyklentypen);
                cbx_zykl.SelectedItem = server.Zyklus;
                //cbx_zykl.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
                // 
                // comboBox_dd
                // 
                ComboBox cbx_dd = new ComboBox();
                cbx_dd.FormattingEnabled = true;
                cbx_dd.Location = new Point(409, 20);
                cbx_dd.Size = new Size(46, 23);
                for (int day = 1; day <= 31; day++)
                {
                    cbx_dd.Items.Add(day.ToString("D2")); // "D2" format to ensure two digits
                }
                cbx_dd.SelectedItem = server.Startdatum.Day.ToString("D2");
                //cbx_dd.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
                // 
                // comboBox_mm
                // 
                ComboBox cbx_mm = new ComboBox();
                cbx_mm.FormattingEnabled = true;
                cbx_mm.Location = new Point(461, 20);
                cbx_mm.Size = new Size(46, 23);
                for (int month = 1; month <= 12; month++)
                {
                    cbx_mm.Items.Add(month.ToString("D2")); // "D2" format to ensure two digits
                }
                cbx_mm.SelectedItem = server.Startdatum.Month.ToString("D2");
                //cbx_mm.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
                // 
                // comboBox_jjjj
                // 
                ComboBox cbx_jjjj = new ComboBox();
                cbx_jjjj.FormattingEnabled = true;
                cbx_jjjj.Location = new Point(513, 20);
                cbx_jjjj.Size = new Size(80, 23);
                for (int year = 2000; year <= 2100; year++)
                {
                    cbx_jjjj.Items.Add(year.ToString("D4")); // Ensures the year is four digits
                }
                cbx_jjjj.SelectedItem = server.Startdatum.Year.ToString("D4");
                //cbx_jjjj.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
                // 
                // comboBox_Ausg_Pfad
                // 
                ComboBox cbx_Ausg_Pfad = new ComboBox();
                cbx_Ausg_Pfad.FormattingEnabled = true;
                cbx_Ausg_Pfad.Location = new Point(599, 20);
                cbx_Ausg_Pfad.Size = new Size(100, 23);
                cbx_Ausg_Pfad.Items.AddRange(ExchangeServer);
                cbx_Ausg_Pfad.SelectedItem = server.Ausgabeziel;
                //cbx_Ausg_Pfad.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
                // 
                // button2
                // 
                Button btnX = new Button();
                btnX.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                btnX.Location = new Point(710, 20);
                btnX.Name = "button2";
                btnX.Size = new Size(25, 25);
                btnX.TabIndex = 7;
                btnX.Text = "X";
                btnX.UseVisualStyleBackColor = true;
                // 
                // groupBox1
                // 
                programmGroupBox.Controls.Add(chbx);
                programmGroupBox.Controls.Add(tbx_Serv_Adr);
                programmGroupBox.Controls.Add(cbx_Rep_Typ);
                programmGroupBox.Controls.Add(cbx_zykl);
                programmGroupBox.Controls.Add(cbx_dd);
                programmGroupBox.Controls.Add(cbx_mm);
                programmGroupBox.Controls.Add(cbx_jjjj);
                programmGroupBox.Controls.Add(cbx_Ausg_Pfad);
                programmGroupBox.Controls.Add(btnX);

            }
        }
        private void add_server(object sender, EventArgs e)
        {
            //den gesamten Block hier einfuegen???---------------------------------------------------------------------
        }
    }

    [XmlRoot("Server")]
    public class Server
    {
        [XmlElement("Adresse")]
        public string Adresse { get; set; }
        [XmlElement("Reporttyp")]
        public string Reporttyp { get; set; }
        [XmlElement("Zyklus")]
        public string Zyklus { get; set; }
        [XmlElement("Startdatum")]
        public DateTime Startdatum { get; set; }
        [XmlElement("Ausgabeziel")]
        public string Ausgabeziel { get; set; }
    }

    // Container-Klasse fuer die Liste von Programm-Objekten
    [XmlRoot("ServerCollection")]
    public class ServerCollection
    {
        [XmlElement("Server")]
        public List<Server> Servers { get; set; } = new List<Server>();
    }

    [XmlRoot("Programmverzeichnis")]
    public class Programmverzeichnis
    {
        [XmlElement("Programm")]
        public List<Programm> Programme { get; set; } = new List<Programm>();
    }

    public class Programm
    {
        [XmlElement("Programmname")]
        public string Programmname { get; set; }

        [XmlElement("Schritt")]
        public List<Schritt> Schritte { get; set; } = new List<Schritt>(); // Initialize the list
    }

    public class Schritt
    {
        [XmlElement("Schrittart")]
        public string Schrittart { get; set; }

        [XmlElement("Schrittdetail")]
        public string Schrittdetail { get; set; }

        [XmlElement("Text")]
        public string Text { get; set; }

        [XmlElement("Waittime")]
        public int Waittime { get; set; }

        [XmlElement("Schrittcheck")]
        public string Schrittcheck { get; set; }
    }

    /*
    Selenuimtestprogramm:

    using static System.Net.Mime.MediaTypeNames;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

//Infos: https://www.toolsqa.com/selenium-c-sharp/

IWebDriver EdgeDriver = new EdgeDriver();

EdgeDriver.Url = "https://de.wikipedia.org";
EdgeDriver.Manage().Window.Maximize();
//EdgeDriver.Manage().Timeouts().ImplicitWait(TimeSpan.FromSeconds(10));
Thread.Sleep(1000);

//try!!!!!
EdgeDriver.FindElement(By.Name("search")).SendKeys("Bitcoin" + Keys.Enter);
Thread.Sleep(1000);
//EdgeDriver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div/div/div/div/div[1]/div/span/a/h3")).Click();
Thread.Sleep(1000);

/*
(By.Id("submit")
(By.Name("firstname")
(By.TagName("button"))
(By.XPath("Element XPATHEXPRESSION"))



IWebElement parentElement = driver.FindElement(By.ClassName("button"));
	IWebElement childElement = parentElement.FindElement(By.Id("submit"));
	childElement.Submit();



IWebElement element = driver.FindElement(By.LinkText("Partial Link Test"));
	element.Clear();

	//Or can be identified as 
	IWebElement element = driver.FindElement(By.PartialLinkText("Partial");
	element.Clear();



    Console.WriteLine("Succsess!");
//EdgeDriver.FindElement(By.XPath"//*[@data-tab-key").Click();

Thread.Sleep(10000);
//Console.ReadLine();
EdgeDriver.Quit();
    */

}
