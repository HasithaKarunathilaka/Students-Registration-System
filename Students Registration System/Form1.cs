using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Students_Registration_System
{
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hasitha\Documents\Visual Studio 2012\Projects\Students Registration System\Students Registration System\Database1.mdf;Integrated Security=True");
       
        public login()
        {
            InitializeComponent();
        }
        // button_1 = Sign In

        private void button1_Click(object sender, EventArgs e)
        {
            if (slideA.Left == 449)
            {

                slideB.Visible = false;
                slideB.Left = 449;

                slideA.Visible = false;
                slideA.Left = 37;
                slideA.Visible = true;

                lineShape1.X1 = 92;
                lineShape1.X2 = 202;
            }

            txtUN.ForeColor = Color.DimGray;
            txtPW.ForeColor = Color.DimGray;
            txtUN.Text = " Staff ID";
            txtPW.PasswordChar = '\0';
            txtPW.Text = " Password";

            picBxPW1.Visible = false;

            /*
             txtAC.Clear();
             txtFN.Clear();
             txtLN.Clear();
             txtSID.Clear();
             txtSUPW1.ForeColor = Color.DimGray;
             txtSUPW1.Text = " Minimum of 6 Characters";
             txtSUPW2.Clear();
             */

        }

        // button_2 = Sign Up

        private void button2_Click(object sender, EventArgs e)
        {
            // slideB left = 449
            // slideA left = 37

            if (slideB.Left == 449)
            {

                slideA.Visible = false;
                slideA.Left = 449;

                slideB.Visible = false;
                slideB.Left = 37;
                slideB.Visible = true;

                lineShape1.X1 = 204;
                lineShape1.X2 = 314;
            }

            /*
            txtUN.ForeColor = Color.DimGray;
            txtPW.ForeColor = Color.DimGray;
            txtUN.Text = " Staff ID";
            txtPW.Text = " Password";
             */

            txtAC.Clear();
            txtFN.Clear();
            txtLN.Clear();
            txtSID.Clear();
            txtSUPW1.ForeColor = Color.DimGray;
            txtSUPW1.PasswordChar = '\0';
            txtSUPW1.Text = " Minimum of 6 Characters";
            txtSUPW2.Clear();
            lblError.Visible = false;
        }

        // txtUN = Username

        private void txtUN_Click(object sender, EventArgs e)
        {
            if (txtUN.Text == " Staff ID")
            {
                txtUN.Clear();
            }
            txtUN.ForeColor = Color.PowderBlue;
            lblEr.Visible = false;
        }

        private void txtUN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtUN.ForeColor == Color.DimGray)
            {
                txtUN.Clear();
                txtUN.ForeColor = Color.PowderBlue;
            }
        }

        // txtPW = Sign In Password

        private void txtPW_Click(object sender, EventArgs e)
        {
            if (txtPW.Text == " Password")
            {
                txtPW.Clear();
                txtPW.PasswordChar = '\u2022';
            }

            txtPW.ForeColor = Color.PowderBlue;
            lblEr.Visible = false;
        }

        private void txtPW_TextChanged(object sender, EventArgs e)
        {
            if (txtPW.Text.Length > 0)
            {
                picBxPW1.Visible = true;
            }
            else
            {
                picBxPW1.Visible = false;
            }
        }

        private void txtPW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPW.ForeColor == Color.DimGray)
            {
                txtPW.Clear();
                txtPW.ForeColor = Color.PowderBlue;
                txtPW.PasswordChar = '\u2022';
            }
        }

        // picBxPW1 = Sign In Password Show Icon

        private void picBxPW1_MouseDown(object sender, MouseEventArgs e)
        {
            picBxPW1.BackColor = Color.LightSlateGray;
            txtPW.PasswordChar = '\0';
        }

        private void picBxPW1_MouseUp(object sender, MouseEventArgs e)
        {
            picBxPW1.BackColor = Color.Transparent;
            txtPW.PasswordChar = '\u2022';

            //if (txtPW.ForeColor == Color.DimGray)
            //{
            //    txtPW.PasswordChar = '\0';
            //}
            //else
            //{
            //    txtPW.PasswordChar = '\u2022';
            //}            
        }
        
        // txtFN = First Name

        private void txtFN_TextChanged(object sender, EventArgs e)
        {
            txtFN.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtFN.Text);
            txtFN.Select(txtFN.Text.Length, 0);
        }

        // txtLN = Last Name

        private void txtLN_TextChanged(object sender, EventArgs e)
        {
            txtLN.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtLN.Text);
            txtLN.Select(txtLN.Text.Length, 0);
        }

        // txtSUPW = Sign Up Password_1

        private void txtSUPW1_TextChanged(object sender, EventArgs e)
        {
            txtSUPW2.Clear();

            if (txtSUPW1.Text.Length < 6 || txtSUPW1.Text == " Minimum of 6 Characters")
            {
                picBxOk1.Visible = false;
            }
            else
            {
                picBxOk1.Visible = true;
            }

            if (txtSUPW1.ForeColor == Color.DimGray)
            {
                picBxPW2.Visible = false;
            }
            else if (txtSUPW1.Text.Length > 0)
            {
                picBxPW2.Visible = true;
            }
            else
            {
                picBxPW2.Visible = false;
            }

        }

        private void txtSUPW1_Click(object sender, EventArgs e)
        {
            if (txtSUPW1.Text == " Minimum of 6 Characters")
            {
                txtSUPW1.Clear();
                txtSUPW1.PasswordChar = '\u2022';
            }
            txtSUPW1.ForeColor = Color.PowderBlue;
        }

        private void txtSUPW1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSUPW1.ForeColor == Color.DimGray)
            {
                txtSUPW1.Clear();
                txtSUPW1.ForeColor = Color.PowderBlue;
                txtSUPW1.PasswordChar = '\u2022';
            }
        }

        // picBxPW2 = Sign Up Password_1 Show Icon

        private void picBxPW2_MouseDown(object sender, MouseEventArgs e)
        {
            picBxPW2.BackColor = Color.LightSlateGray;
            txtSUPW1.PasswordChar = '\0';
        }

        private void picBxPW2_MouseUp(object sender, MouseEventArgs e)
        {
            picBxPW2.BackColor = Color.Transparent;
            txtSUPW1.PasswordChar = '\u2022';
        }

        // txtSUPW2 = Sign Up Password_2

        private void txtSUPW2_TextChanged(object sender, EventArgs e)
        {

            txtSUPW2.PasswordChar = '\u2022';

           if (txtSUPW2.Text =="")
            {
                picBxOk2.Visible = false;
                picBxWrn1.Visible = false;
            }

            else if (txtSUPW2.Text == txtSUPW1.Text)
            {
                picBxWrn1.Visible = false;
                picBxWrn1.Left = 17;

                picBxOk2.Visible = false;
                picBxOk2.Left = 308;
                picBxOk2.Visible = true;
            }

            else
            {
                picBxOk2.Visible = false;
                picBxOk2.Left = 17;

                picBxWrn1.Visible = false;
                picBxWrn1.Left = 308;

                picBxWrn1.Visible = true;

            }
        }

        // btnExi = X

        private void btnExi_MouseHover(object sender, EventArgs e)
        {
            btnExi.ForeColor = Color.DodgerBlue;
        }

        private void btnExi_MouseLeave(object sender, EventArgs e)
        {
            btnExi.ForeColor = Color.Silver;
        }

        private void btnExi_MouseDown(object sender, MouseEventArgs e)
        {
            btnExi.ForeColor = Color.Gainsboro;
        }

        private void btnExi_MouseUp(object sender, MouseEventArgs e)
        {
            btnExi.ForeColor = Color.DodgerBlue;
        }

        private void btnExi_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if ((txtUN.Text != " Staff ID" && txtPW.Text != " Password") && (txtUN.Text != "" && txtPW.Text != ""))
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hasitha\Documents\Visual Studio 2012\Projects\Students Registration System\Students Registration System\Database1.mdf;Integrated Security=True");
                sqlcon.Open();
                string query = "Select * from [tbStaff] where stid = '" + txtUN.Text.Trim() + "' and password = '" + txtPW.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dtb1 = ds.Tables[0];

                if (dtb1.Rows.Count >= 1)
                {
                    Home h = new Home();
                    h.Show();
                    this.Hide();

                }
                else
                {
                    lblEr.Visible = true;
                    lblEr.Text = "Invalid Username or Password";
                }
            }
            else
            {
                lblEr.Visible = true;
                lblEr.Text = "Fill Username and Password";
            }
            
            
        }

        private void btnSU_Click(object sender, EventArgs e)
        {
            if (txtAC.Text == "789" && txtFN.Text != "" && txtLN.Text != "" && txtSID.Text != "" && picBxOk1.Visible == true && picBxOk2.Visible == true)
            {
               try
                {
                    int sid = Convert.ToInt32(txtSID.Text.Trim());
                    string fname = txtFN.Text.Trim();
                    string lname = txtLN.Text.Trim();
                    string pass = txtSUPW1.Text;             
                    string nic = "";
                    string title = "";                
                    string gen = "";
                    string pos = "";
                    string a1 = "";
                    string a2 = "";
                    string a3 = "";
                    string a4 = "";
                    int mob = 0;
                    int lan = 0;
                    string emal = "";
                    string not = "";

                    string query_insert = "INSERT INTO [tbStaff] VALUES('" + sid + "','" + nic + "','" + title + "','" + fname + "','" + lname + "','" + gen + "','" + pos + "','" + a1 + "','" + a2 + "','" + a3 + "','" + a4 + "','" + mob + "','" + lan + "','" + emal + "','" + not + "','"+ pass +"')";
                    SqlCommand cmnd = new SqlCommand(query_insert, con);
                    con.Open();
                    cmnd.ExecuteNonQuery();
                    
                    lblError.Visible = true;
                    lblError.Text = "Registration Successfull";

                    txtAC.Clear();
                    txtFN.Clear();
                    txtLN.Clear();
                    txtSID.Clear();
                    txtSUPW1.ForeColor = Color.DimGray;
                    txtSUPW1.PasswordChar = '\0';
                    txtSUPW1.Text = " Minimum of 6 Characters";
                    txtSUPW2.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error While Saving  " + ex);
                }
                finally
                {
                    con.Close();
                }

                   
                
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Please Check the Details";
                txtSUPW1.ForeColor = Color.DimGray;
                txtSUPW1.PasswordChar = '\0';
                txtSUPW1.Text = " Minimum of 6 Characters";
                txtSUPW2.Clear();
            }
            
        }

    }
}