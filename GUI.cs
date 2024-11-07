using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_GUI
{
    public partial class Form1 : Form
    {
        private GroupBox mainGroupBox;
        private Panel scrollablePanel;
        private Button addGroupBoxButton;
        private List<GroupBox> groupBoxList;
        private int groupBoxCount = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeDynamicComponents();
        }

        private void InitializeDynamicComponents()
        {
            // Initialize the main GroupBox that holds the scrollable Panel
            mainGroupBox = new GroupBox
            {
                Text = "Active Address (Server) Report",
                Dock = DockStyle.Fill
            };
            Controls.Add(mainGroupBox);

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

        private void AddSmallGroupBox()
        {
            // Create a new small GroupBox
            GroupBox smallGroupBox = new GroupBox
            {
                Text = $"Cycle {++groupBoxCount}",
                Width = scrollablePanel.Width - 40,
                Height = 80,
                Top = 20 + groupBoxList.Count * 90
            };

            // Create CheckBox
            CheckBox checkBox = new CheckBox
            {
                Left = 10,
                Top = 30,
                Width = 30
            };

            // Create ComboBox
            ComboBox comboBox = new ComboBox
            {
                Left = checkBox.Right + 10,
                Top = 25,
                Width = 80
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

        private void DeleteSmallGroupBox(GroupBox groupBox)
        {
            // Remove the groupbox from the scrollable panel and the list
            scrollablePanel.Controls.Remove(groupBox);
            groupBoxList.Remove(groupBox);

            // Dispose to free up resources
            groupBox.Dispose();

            // Update positions of remaining groupboxes
            UpdateGroupBoxPositions();
        }

        private void UpdateGroupBoxPositions()
        {
            // Rearrange groupboxes vertically
            for (int i = 0; i < groupBoxList.Count; i++)
            {
                groupBoxList[i].Top = 20 + i * 90;
            }
        }
    }
}
