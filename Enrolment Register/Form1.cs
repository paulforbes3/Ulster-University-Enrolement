using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Linq;

namespace Enrolment_Register
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // WRITTEN BY PAUL FORBES (B00806546) & AOIFE O'HANLON (B00805071)

        private void Form1_Load(object sender, EventArgs e)
        {
            // On form load, (a) list box is populated with list of students from StudentDetails.txt
            // and (b) course name and course lecturer are populated from CourseDetails.txt
            
            string courseRec, studentRec;
            string[] studentRecArray, courseRecArray;
            
            StreamReader CourseFile, StudentFile;
            CourseFile = File.OpenText(@"C:\temp\CourseDetails.txt");       // Do not change these file locations
            StudentFile = File.OpenText(@"C:\temp\StudentDetails.txt");     // Do not change these file locations

            while ( CourseFile.EndOfStream == false)
            {
                // read file details into array and use split to seperate elements
                // assign correct elements to global named variables
                // add variable data to listbox
                courseRec = CourseFile.ReadLine();
                courseRecArray = courseRec.Split(',');
                e_Data.courseName = courseRecArray[0];
                e_Data.courseLecturer = courseRecArray[1];
                lstStudents.Items.Add(e_Data.courseName + "," + e_Data.courseLecturer);
            }
            
            while (StudentFile.EndOfStream == false)
            {
                // read file details into array and use split to seperate elements
                // create new student class object called student details
                // assign correct elements to student class named variables
                studentRec = StudentFile.ReadLine();
                studentRecArray = studentRec.Split(',');
                Student studentDetails = new Student();
                studentDetails.Name = studentRecArray[0];
                studentDetails.Dob = studentRecArray[1];
                studentDetails.Address = studentRecArray[2];
                studentDetails.Gender = studentRecArray[3];

                

                // populate list with items from student details 
                // Create new student object and add data from studentRecArray to object
                e_Data.s_List.Add(studentDetails);
            }
            
            
            
            // call refresh listboz method to populate the listbox 
            RefreshListBox();

            CourseFile.Close();
            StudentFile.Close();

        }
       

        private void RefreshListBox()
        {
            // clear list box and iterate over student list using foreach 
            // add to row variable data from student class 
            // add row to listbox to populate it with data 
            string row = "";
            lstStudents.Items.Clear();
            foreach (Student s in e_Data.s_List)
            {
                row = s.Name + "," + s.Dob + "," + s.Address + "," + s.Gender;
                lstStudents.Items.Add(row);
            }
           
            // refresh listbox using each Student s in e_Data.s_List
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // create instance of the Add form class and display
            // refresh listbox after student is added
            Add add = new Add();
            add.ShowDialog();
            RefreshListBox();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // declare variables row and remove_name 
            // create array named details[]
            // if no index is selected them show error message 
            // if index selected then row equals selected item
            // elements seperated using split function 
            
            string row, remove_name;
            string[] details;

            if (lstStudents.SelectedIndex == -1)
            {
                MessageBox.Show("Please select student to delete");
            }
            else
            {
                row = lstStudents.SelectedItem.ToString();
                details = row.Split(',');
                remove_name = details[0];
                // foreach to iterate over the student list 
                // if name matches name in student class then 
                // remove details from listbox and list 
                // call refresh listbox method
                foreach (Student s in e_Data.s_List)
                {
                    if (s.Name == remove_name)
                    {
                        e_Data.s_List.Remove(s);
                        break;
                    }
                    
                }
                RefreshListBox();

                // Iterate over each Student s in e_Data.s_List and 
                // check if it matches the selected student.

                
            }
         }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 
            // use foreach to iterate over data in student list 
            // write details to file
            // close the file
      
            StreamWriter outputStudentDetails;
            outputStudentDetails = File.CreateText(@"C:\temp\StudentDetails.txt");

            foreach (Student s in e_Data.s_List)
            {
                outputStudentDetails.WriteLine(s.Name + "," + s.Dob + "," + s.Address + "," + s.Gender);
            }
            outputStudentDetails.Close();





            // Write course details to file
            // Mustbe of format:
            // courseName,courseLecturer,num_enrolled,percent_female,percent_male,percent_other
            // call streamwriter and create variable for outputfile 
            // write global variables stored in e_data to file 
            // close the file and application
            StreamWriter outputCourseDetails;
            outputCourseDetails = File.CreateText(@"C:\temp\CourseDetails.txt");
            outputCourseDetails.WriteLine(e_Data.courseName + "," + e_Data.courseLecturer + "," + e_Data.coursePCF + "," + e_Data.coursePCM + "," + e_Data.coursePCO);
            outputCourseDetails.Close();

            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            // set variable to store total amount of times 
            // each occurance appears in the list
           
            int totalm = 0;
            int totalf = 0;
            int totalo = 0;
            
            foreach (Student s in e_Data.s_List)
            {
                // use foreach to iterate over the list 
                // using contains() to search for gender in list 
                // if gender is found in the list then 1 count 
                // is added to the total using +=
                // i dont think .contains() is found in the course 
                // notes but i found it myself and figured out how it takes
                // the parameter and it produces the desired results so this is 
                // why i am using it here.

  
               
                {
                    if (s.Gender.Contains("Female"))
                    {
                        totalf += 1;
                           
                    }
                    else if (s.Gender.Contains("Male"))
                    {
                        totalm += 1;
                        
                    }
                    else if (s.Gender.Contains("Other"))
                    {
                        totalo += 1;
                        
                    }

                    
                }
                // asssign result to global variable names stored in e_data 
                // calculation is the total count of a gender / length of the list 
                // * 100
                
                
            }
            e_Data.coursePCF = (totalf / (double)e_Data.s_List.Count) * 100;
            e_Data.coursePCM = (totalm / (double)e_Data.s_List.Count) * 100;
            e_Data.coursePCO = (totalo / (double)e_Data.s_List.Count) * 100;




            // for each Student s in e_Data.s_list, check gender, keep running total
            // then calculate percentages of each category

            // add results to output label in correct format


            lblOutput.Text = "Course: " + e_Data.courseName + System.Environment.NewLine +
                "Lecturer: " + e_Data.courseLecturer + System.Environment.NewLine +
                "Total Students: " + e_Data.s_List.Count.ToString() + System.Environment.NewLine +
                "Female % : " + e_Data.coursePCF.ToString("N2") + System.Environment.NewLine +
                "Male % : " + e_Data.coursePCM.ToString("N2") + System.Environment.NewLine +
                "Other % : " + e_Data.coursePCO.ToString("N2");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // create instance of the Search form class and display
            // create new search form and show dialogue
            Search searchForm = new Search();
            searchForm.ShowDialog();


            // END OF PROGRAM
        }
    }
}