using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoReport
{
    internal class D_GUI
    {
        public class DynamicComponentInitializer
        {
            private Form form;
            private GroupBox mainGroupBox;
            private Panel scrollablePanel;
            private Button addGroupBoxButton;
            private List<GroupBox> groupBoxList;
            private int groupBoxCount = 0;

            private System.Windows.Forms.Button button_Edit;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.Label label5;
            private System.Windows.Forms.Label label6;
            private System.Windows.Forms.Label label7;

            public DynamicComponentInitializer(Form form)
            {
                this.form = form;
                InitializeDynamicComponents();
            }

            private void InitializeDynamicComponents()
            {
                button_Edit = new System.Windows.Forms.Button();
                label1 = new System.Windows.Forms.Label();
                label2 = new System.Windows.Forms.Label();
                label3 = new System.Windows.Forms.Label();
                label4 = new System.Windows.Forms.Label();
                label5 = new System.Windows.Forms.Label();
                label6 = new System.Windows.Forms.Label();
                label7 = new System.Windows.Forms.Label();

                //Button btn_edit = new Button();
                button_Edit.Location = new Point(5, 5);
                button_Edit.Size = new Size(75, 25);
                button_Edit.Text = "edit Skripts";
                button_Edit.Click += button_Edit_Click;
                
                // Initialize label properties
                label1.AutoSize = true;
                label1.Location = new Point(12, 40);
                label1.Name = "label1";
                label1.Size = new Size(40, 15);
                label1.TabIndex = 9;
                label1.Text = "Active";

                label2.AutoSize = true;
                label2.Location = new Point(64, 40);
                label2.Name = "label2";
                label2.Size = new Size(91, 15);
                label2.TabIndex = 10;
                label2.Text = "Adresse (Server)";

                label3.AutoSize = true;
                label3.Location = new Point(186, 40);
                label3.Name = "label3";
                label3.Size = new Size(59, 15);
                label3.TabIndex = 11;
                label3.Text = "Reporttyp";

                label4.AutoSize = true;
                label4.Location = new Point(432, 40);
                label4.Name = "label4";
                label4.Size = new Size(123, 15);
                label4.TabIndex = 12;
                label4.Text = "Startdatum dd.mm.jjjj";

                label5.AutoSize = true;
                label5.Location = new Point(299, 40);
                label5.Name = "label5";
                label5.Size = new Size(41, 15);
                label5.TabIndex = 13;
                label5.Text = "Zyklus";

                label6.AutoSize = true;
                label6.Location = new Point(633, 40);
                label6.Name = "label6";
                label6.Size = new Size(70, 15);
                label6.TabIndex = 14;
                label6.Text = "Ausgabeziel";

                label7.AutoSize = true;
                label7.Location = new Point(728, 40);
                label7.Name = "label7";
                label7.Size = new Size(51, 15);
                label7.TabIndex = 15;
                label7.Text = "Löschen";

                // Add labels to form controls
                form.Controls.Add(button_Edit);
                form.Controls.Add(label7);
                form.Controls.Add(label6);
                form.Controls.Add(label5);
                form.Controls.Add(label4);
                form.Controls.Add(label3);
                form.Controls.Add(label2);
                form.Controls.Add(label1);


                groupBoxList = new List<GroupBox>();

                // Initialize the main GroupBox that holds the scrollable Panel
                mainGroupBox = new GroupBox
                {
                    //Text = "Active Address (Server) Report",
                    //Dock = DockStyle.Fill

                    //12, 28
                    Location = new Point(10, 50), // Position the GroupBox with some space at the top
                    Size = new Size(form.ClientSize.Width - 20, form.ClientSize.Height - 60), // Adjust size as needed
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom

                };
                form.Controls.Add(mainGroupBox);

                // Create a scrollable Panel inside the main GroupBox
                scrollablePanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true // Enable vertical scrolling
                };
                mainGroupBox.Controls.Add(scrollablePanel);

                // Button to add new small groupboxes, positioned inside the scrollable Panel
                addGroupBoxButton = new Button
                {
                    Text = "Add",
                    Dock = DockStyle.Bottom
                };
                addGroupBoxButton.Click += (sender, e) => AddSmallGroupBox();
                scrollablePanel.Controls.Add(addGroupBoxButton);

                // List to hold references to dynamically created groupboxes
                groupBoxList = new List<GroupBox>();

            }

            private void button_Edit_Click(object sender, EventArgs e)
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

            protected void Form2button2_Click(object sender, EventArgs e, ComboBox Form2comboBox)
            {
                Form Form3 = new Form();
                Form3.Size = new Size(180, 130);
                Form3.Show();


                //Label Form3lbl = new Label();
                System.Windows.Forms.Label Form3lbl = new System.Windows.Forms.Label();
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

                        /*
                        Error ProgramPath and programmverzeichnis________________________________________________________________________________________________________________
                        try
                        {
                            XmlHelper.SerializeProgrammToXml(ProgramPath, programmverzeichnis);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error during XML Serialization: {ex.Message}");
                        }
                        */

                        /*
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
                        */




                    }
                    Form3.Close();
                }
            }

                void AddSmallGroupBox()
            {
                // Create a new small GroupBox___________________________________________________________________________________________Hier ordnen!
                GroupBox smallGroupBox = new GroupBox
                {
                    Text = $"Cycle {++groupBoxCount}",
                    Width = scrollablePanel.Width - 40,
                    Height = 60,
                    Top = 20 + groupBoxList.Count * 90
                };

                // Create CheckBox
                CheckBox checkBox = new CheckBox
                {
                    Left = 10,
                    Top = 30,
                    Width = 20,
                    Height = 20
                };

                // Create ComboBox
                ComboBox comboBox = new ComboBox
                {
                    Left = checkBox.Right + 10,
                    Top = 25,
                    Width = 116
                };
                // Populate ComboBox with items (example data)
                comboBox.Items.AddRange(new string[] { "Option1", "Option2", "Option3" });

                // Create TextBoxes
                TextBox[] textBoxes = new TextBox[4];
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    textBoxes[i] = new TextBox
                    {
                        Left = comboBox.Right + 10 + (i * 60),
                        Top = 25,
                        Width = 50
                    };
                }

                // Create Delete Button
                Button deleteButton = new Button
                {
                    Text = "Del",
                    Left = textBoxes[3].Right + 10,
                    Top = 25,
                    Width = 40
                };
                deleteButton.Click += (sender, e) => DeleteSmallGroupBox(smallGroupBox);

                // Add controls to small GroupBox
                smallGroupBox.Controls.Add(checkBox);
                smallGroupBox.Controls.Add(comboBox);
                foreach (var textBox in textBoxes)
                {
                    smallGroupBox.Controls.Add(textBox);
                }
                smallGroupBox.Controls.Add(deleteButton);

                // Add small GroupBox to the scrollable panel
                scrollablePanel.Controls.Add(smallGroupBox);
                groupBoxList.Add(smallGroupBox);

                UpdateGroupBoxPositions();
            }

            void DeleteSmallGroupBox(GroupBox groupBox)
            {
                // Remove the groupbox from the scrollable panel and the list
                scrollablePanel.Controls.Remove(groupBox);
                groupBoxList.Remove(groupBox);

                // Dispose to free up resources
                groupBox.Dispose();

                // Update positions of remaining groupboxes
                UpdateGroupBoxPositions();
            }

            void UpdateGroupBoxPositions()
            {
                // Rearrange groupboxes vertically
                for (int i = 0; i < groupBoxList.Count; i++)
                {
                    groupBoxList[i].Top = 20 + i * 90;
                }
            }
        }
    }
}
