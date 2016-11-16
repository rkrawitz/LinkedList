using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace VisualLinkedList
{
    public partial class frmLinkedListManip : Form
    {
        LinkedList.FirstNameListManip manipFirstName = new LinkedList.FirstNameListManip();
        LinkedList.LastNameListManip manipLastName = new LinkedList.LastNameListManip();

        public frmLinkedListManip()
        {
            InitializeComponent();
        }

        private void LinkedListManip_Load(object sender, EventArgs e)
        {
            lblFirstName.Height = txtFirstName.Height;
            lblFirstName.Top = txtFirstName.Top;
            lblFirstName.Left = txtFirstName.Left - lblFirstName.Width - 5;

            btnAddNode.Height = btnRemoveNode.Height;
            btnFindNode.Height = btnRemoveNode.Height;

            btnFindNode.Left = (this.Width / 2) - (btnFindNode.Width / 2);
            btnAddNode.Left = btnFindNode.Left - btnAddNode.Width - 25;
            btnRemoveNode.Left = btnFindNode.Right + 25;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Length < 1 || txtLastName.Text.Length < 1)
                lblOutput.Text = "you must put a name in the 'first name' box in order to add a node";
            else
            {
                lblOutput.Text = manipFirstName.manipTheList('1', txtFirstName.Text, txtLastName.Text);
                lblOutput.Text += " " + manipLastName.manipTheList('1', txtFirstName.Text, txtLastName.Text);
            }

                blankBoxes();
       }//end btnAddNode_Click()

        private void btnFindNode_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Length < 1)
                lblOutput.Text = "you must put a name in the 'first name' box in order locate that node";
            else
            {
                lblOutput.Text = manipFirstName.manipTheList('2', txtFirstName.Text, txtLastName.Text);

                blankBoxes();
            }

            txtFirstName.Focus();
        }

        private void btnRemoveNode_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Length < 1)
                lblOutput.Text = "you must put a name in the 'first name' box in order remove that node";
            else
            {
                lblOutput.Text = manipFirstName.manipTheList('3', txtFirstName.Text, txtLastName.Text);
                lblOutput.Text += manipLastName.manipTheList('3', txtFirstName.Text, txtLastName.Text);

                blankBoxes();
            }

            txtFirstName.Focus();
        }

        private void btnFirstNameDisplay_Click(object sender, EventArgs e)
        {
            ArrayList list;
            DisplyByFirstName show = new DisplyByFirstName(manipFirstName.headFirstName);
            String message = "";

            list = show.displayTheListNames();

            foreach (String s in list)
            {
                message += s + "\n";
            }

            lblOutput.Text = message;

            blankBoxes();

            txtFirstName.Focus();
        }//end btnFirstNameDisplay_Click()

        private void blankBoxes()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";

            txtFirstName.Focus();
        }

        private void btnLastNameDisplay_Click(object sender, EventArgs e)
        {
            ArrayList list;
            DisplyByLastName show = new DisplyByLastName(manipLastName.headLastName);
            String message = "";

            list = show.displayTheListNames();

            foreach (String s in list)
            {
                message += s + "\n";
            }

            lblOutput.Text = message;

            blankBoxes();

            txtFirstName.Focus();
        }
    }
}
