using System;
using System.Windows.Forms;

namespace Enrolment_Register
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // create variable to store the users search 
            // set boolean variable to default false 
            // if the user enters nothing into searchbox present an error 

            string studentName = txtName.Text;
            bool studentFound = false;
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a name");
            }
            else
            {
                // using a for loop to iterate over the list
                // if the users input matches a name in the list 
                // set boolean studentfound to true and display that it was found 
                // if the search does not match a name in the list then boolean remains false
                // and display that the name is not found 

                // reference https://stackoverflow.com/questions/36272707/search-specific-element-in-list-from-user-input
                // the reason i used an online resource to help with this is because the "index of" method shown in the slides 
                // gave me an error when trying to assign the users input as a variable , it also gave me an error when 
                // using txtname.txt without a variable name. i was unable to resolve this issue and so used this booleon
                // method instead.
                for (int i = 0; i < e_Data.s_List.Count; i++)
                {
                    if (e_Data.s_List[i].Name == studentName)
                    {
                        lblOutput.Text = studentName + "was found";
                        studentFound = true;
                    }
                    if (!studentFound)
                    {
                        lblOutput.Text = studentName + "was not found";
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
