

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB1_B
{
    public partial class Glasaj : System.Web.UI.Page
    {

        String[] professors = { "Goce Trajkovski", "Damjan Mancevski", "Aleksandra Karanikova" };
        String[] subjects = { "Kalkulus", "Vizualno Programiranje", "Veb Dizajn" };
        String[] credits = { "5", "6", "6" };



        private void clear()
        {
            lbSubject.SelectedIndex = -1;
            lbCredit.SelectedIndex = -1;
            professorName.Text = "";
            tbSubject.Text = "";
            tbCredit.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 0; i < 3; i++)
                {
                    lbSubject.Items.Add(new ListItem(subjects[i], professors[i]));
                    lbCredit.Items.Add(new ListItem(credits[i], credits[i]));
                }
            }
        }


        protected void subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbCredit.SelectedIndex = lbSubject.SelectedIndex;
            professorName.Text = "Проф. д-р " + lbSubject.SelectedValue;
        }

        protected void addNewSubject_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbSubject.Text) && !string.IsNullOrWhiteSpace(tbCredit.Text))
            {
                        lbSubject.Items.Add(new ListItem(tbSubject.Text, "John Doe"));
                        lbCredit.Items.Add(new ListItem(tbCredit.Text, tbCredit.Text));
                        clear();
                }
        }   

        protected void removeSubject_Click(object sender, EventArgs e)
        {

            /*
            if (!string.IsNullOrWhiteSpace(tbSubject.Text) && !string.IsNullOrWhiteSpace(tbCredit.Text))
            {
                ListItem listItemSubject = lbSubject.Items.FindByText(tbSubject.Text);
                ListItem listItemCredit = lbCredit.Items.FindByText(tbCredit.Text);

                lbSubject.Items.Remove(listItemSubject);
                lbCredit.Items.Remove(listItemCredit);

                lbSubject.SelectedIndex = -1;
                lbCredit.SelectedIndex = -1;
                professorName.Text = "";
            }
            */

            if (!string.IsNullOrWhiteSpace(tbSubject.Text))
            {
                    ListItem listItemSubject = lbSubject.Items.FindByText(tbSubject.Text);
             
                    Console.WriteLine(lbSubject.Items.IndexOf(listItemSubject));
              
                    lbCredit.Items.RemoveAt(lbSubject.Items.IndexOf(listItemSubject));
                    lbSubject.Items.Remove(listItemSubject);

                    clear();      
            }
        }

        protected void addSubject_Click(object sender, EventArgs e)
        {
            if (lbSubject.SelectedItem != null)
            {
                Response.Redirect("UspeshnoGlasanje.aspx");
            }
        }


    }
}


