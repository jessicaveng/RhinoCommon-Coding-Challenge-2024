using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rhino;

namespace MyRhinoPlugin
{
  public partial class Form1 : Form
    {
        private Button createButton;
        private Button deleteLastButton;
        private Button deleteAllButton;
        private Label boxCountLabel;
        private int boxCount = 0;
        private List<Guid> boxIds = new List<Guid>();

        public Form1()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Box Manager";

            createButton = new Button
            {
                Text = "Create Box",
                Left = 10,
                Width = 150,
                Height = 50,
                Top = 10,
                BackColor = SystemColors.Control
            };
            createButton.Click += (sender, e) =>
            {
                MyRhinoCommand.CreateBox(RhinoDoc.ActiveDoc, boxIds, ref boxCount);
                createButton.BackColor = Color.LightGreen;
                deleteLastButton.BackColor = SystemColors.Control;
                deleteAllButton.BackColor = SystemColors.Control;
                UpdateBoxCount();
            };

            deleteLastButton = new Button
            {
                Text = "Delete Last Box",
                Left = 170,
                Width = 150,
                Height = 50,
                Top = 10,
                BackColor = SystemColors.Control
            };
            deleteLastButton.Click += (sender, e) =>
            {
                MyRhinoCommand.DeleteLastBox(RhinoDoc.ActiveDoc, boxIds, ref boxCount);
                deleteLastButton.BackColor = Color.LightSalmon;
                createButton.BackColor = SystemColors.Control;
                deleteAllButton.BackColor = SystemColors.Control;
                UpdateBoxCount();
            };

            deleteAllButton = new Button
            {
                Text = "Delete All Boxes",
                Left = 330,
                Width = 150,
                Height = 50,
                Top = 10,
                BackColor = SystemColors.Control
            };
            deleteAllButton.Click += (sender, e) =>
            {
                MyRhinoCommand.DeleteAllBoxes(RhinoDoc.ActiveDoc, boxIds, ref boxCount);
                deleteAllButton.BackColor = Color.LightCoral;
                createButton.BackColor = SystemColors.Control;
                deleteLastButton.BackColor = SystemColors.Control;
                UpdateBoxCount();
            };

            boxCountLabel = new Label
            {
                Text = "Box: 0",
                Left = 10,
                Top = 70,
                Width = 470,
                Font = new Font("Arial", 16, FontStyle.Bold)
            };

            this.Controls.Add(createButton);
            this.Controls.Add(deleteLastButton);
            this.Controls.Add(deleteAllButton);
            this.Controls.Add(boxCountLabel);
        }

        private void UpdateBoxCount()
        {
            boxCountLabel.Text = $"Box: {boxCount}";
        }
    }
}