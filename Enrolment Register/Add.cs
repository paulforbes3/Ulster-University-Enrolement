using System;
using System.Globalization;
using System.Windows.Forms;

namespace Enrolment_Register
{
    public partial class Add : Form
    {

        public Add()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // .NET Directive for proper management of date strings
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime checkDate;

            // Build Student object from form input and add to List structure
            try
            {
                // Check date format
                // An exception will be thrown if it's an invalid format.
                checkDate = DateTime.ParseExact(txtDOB.Text, "yyyyMMdd", provider);

                // Check for input values from text boxes on form
                if (txtName.Text == "") // replace "true" with input validation checks
                {
                    MessageBox.Show("Record cannot be added unless all values supplied");
                    return;
                }
                else if (txtAddress.Text =="") // replace "true" with input validation checks
                {
                    MessageBox.Show("Record cannot e added unless all values supplied");
                    return;

                }
                else if (cboGender.Text == "")
                {
                    MessageBox.Show("Error in gender value");
                    return;
                }
                else
                {
                    // Create new student object and add to s_List
                    Student newstudent = new Student();
                    newstudent.Name = txtName.Text;
                    newstudent.Dob = txtDOB.Text;
                    newstudent.Address = txtAddress.Text;
                    newstudent.Gender = cboGender.Text;
                    e_Data.s_List.Add(newstudent);

                    // close Form
                    this.Hide();
                   
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid date format in Student");
                return;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
