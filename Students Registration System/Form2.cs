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
using System.IO;

namespace Students_Registration_System
{
    public partial class Home : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hasitha\Documents\Visual Studio 2012\Projects\Students Registration System\Students Registration System\Database1.mdf;Integrated Security=True");

        SqlConnection constd = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hasitha\Documents\Visual Studio 2012\Projects\Students Registration System\Students Registration System\DBStudents.mdf;Integrated Security=True");

        SqlConnection constring = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hasitha\Documents\Visual Studio 2012\Projects\Students Registration System\Students Registration System\DBCourse.mdf;Integrated Security=True");

        string pwd = Class1.GetRandomPassword(20);
        string wanted_path;

        public Home()
        {
            InitializeComponent();
            //fillCrz();
            timer1.Start();

        }

        // btnMax = Maximize / Restore_Back

        private void btnMax_Click(object sender, EventArgs e)
        {
            Bitmap mxSv = new Bitmap(@"C:\Users\Hasitha\Desktop\Icon\Maximaze_Silver.png");
            Bitmap reSv = new Bitmap(@"C:\Users\Hasitha\Desktop\Icon\Restor_Down_Silver.png");

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.CenterToScreen();
                btnMax.BackgroundImage = mxSv;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.CenterToScreen();
                btnMax.BackgroundImage = reSv;
            }
        }

        private void btnMax_MouseHover(object sender, EventArgs e)
        {
            Bitmap mxBl = new Bitmap(@"C:\Users\Hasitha\Desktop\Icon\Maximaze_Blue.png");
            Bitmap reBl = new Bitmap(@"C:\Users\Hasitha\Desktop\Icon\Restor_Down_Blue.png");

            if (this.WindowState == FormWindowState.Maximized)
            {
                btnMax.BackgroundImage = reBl;
            }
            else
            {
                btnMax.BackgroundImage = mxBl;
            }
        }

        private void btnMax_MouseLeave(object sender, EventArgs e)
        {
            Bitmap mxSv = new Bitmap(@"C:\Users\Hasitha\Desktop\Icon\Maximaze_Silver.png");
            Bitmap reSv = new Bitmap(@"C:\Users\Hasitha\Desktop\Icon\Restor_Down_Silver.png");

            if (this.WindowState == FormWindowState.Maximized)
            {
                btnMax.BackgroundImage = reSv;
            }
            else
            {
                btnMax.BackgroundImage = mxSv;
            }
        }

        // btnExi = X

        private void btnExi_MouseLeave(object sender, EventArgs e)
        {

            btnExi.ForeColor = System.Drawing.Color.FromArgb(186, 206, 205);
            //btnExi.BackColor = System.Drawing.Color.FromArgb(10, 40, 95);
        }

        private void btnExi_MouseHover(object sender, EventArgs e)
        {
            btnExi.ForeColor = System.Drawing.Color.FromArgb(10, 40, 95);
            //btnExi.BackColor = System.Drawing.Color.Red;
        }

        private void btnExi_MouseDown(object sender, MouseEventArgs e)
        {
            btnExi.ForeColor = System.Drawing.Color.FromArgb(186, 206, 205);
        }

        private void btnExi_MouseUp(object sender, MouseEventArgs e)
        {
            btnExi.ForeColor = System.Drawing.Color.FromArgb(10, 40, 95);
        }

        // Disply_Current_Time

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.lblDate.Text = dateTime.ToString();
        }

        // Slideing Menue_Panel

        // Button Slide

        private void btnMnu_Click(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
            if (pnlMnu.Size.Width == 263)
            {
                pnlMnu.Width = 53;
                btnMnu.Left = 13;
            }
            else
            {
                pnlMnu.Width = 263;
                btnMnu.Left = 236;
            }
        }

        private void btnMnu_MouseHover(object sender, EventArgs e)
        {
            //Bitmap mnuBl = new Bitmap(@"C:\Users\Hasitha\Desktop\Icon\Menue_Blue.png");
            //btnMnu.BackgroundImage = mnuBl;
        }

        private void btnMnu_MouseLeave(object sender, EventArgs e)
        {
            //Bitmap mnuSv = new Bitmap(@"C:\Users\Hasitha\Desktop\Icon\Menue.png");
            //btnMnu.BackgroundImage = mnuSv;
        }

        // Button_Registration

        private void btnMnuReg_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pnlStd.Visible = false;
            pnlStaffReg.Visible = false;
            pnlRegCrz.Visible = false;
            pnlRegFe.Visible = false;
            pnlcrz.Visible = false;
            pnltt.Visible = false;
            lblCrz.BackColor = System.Drawing.Color.FromArgb(186, 205, 206);
            lblFez.BackColor = System.Drawing.Color.FromArgb(186, 205, 206);

            // Details_Panel_Clear

            txtReg.Clear();
            txtNIC.Clear();
            txtFName.Clear();
            txtLName.Clear();
            dtpDOB.ResetText();
            txtAge.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;

            txtAddL1.Text = "Line 1";
            txtAddL1.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            txtAddL1.Font = new Font(txtAddL1.Font, FontStyle.Regular);
            txtAddL2.Text = "Line 2";
            txtAddL2.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            txtAddL2.Font = new Font(txtAddL2.Font, FontStyle.Regular);
            txtAddL3.Text = "Line 3";
            txtAddL3.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            txtAddL3.Font = new Font(txtAddL3.Font, FontStyle.Regular);
            txtAddL4.Text = "Line 4";
            txtAddL4.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            txtAddL4.Font = new Font(txtAddL4.Font, FontStyle.Regular);

            txtMob.Text = "Mobile";
            txtMob.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            txtMob.Font = new Font(txtMob.Font, FontStyle.Regular);
            txtLPhn.Text = "Land Phone";
            txtLPhn.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            txtLPhn.Font = new Font(txtLPhn.Font, FontStyle.Regular);
            txtEmail.Clear();

            // Course_Panel_Clear

            rbHND.Checked = false;
            rbDegree.Checked = false;
            rbDip.Checked = false;
            rbCer.Checked = false;

            cmbxRegCourse.ResetText();
            txtRegBatch.Clear();

            // Fees_panel_Clear

            rbFPay.Checked = false;
            rbMPay.Checked = false;

            txtRegRgFee.Clear();
            txtRegFullPay.Clear();
            pnlPayTyp.Visible = false;

            // Registration_Panel_Visible

            pnlReg.Visible = true;
            lblDtlz.BackColor = System.Drawing.Color.FromArgb(95, 205, 200);
            pnlRegDe.Visible = true;

        }

        // Panel_Contact_Details in Panel_Registration
        // Address

        private void txtAddL1_Click(object sender, EventArgs e)
        {
            if (txtAddL1.Text == "Line 1")
            {
                txtAddL1.Clear();
                txtAddL1.ForeColor = System.Drawing.Color.Black;
                txtAddL1.Font = new Font(txtAddL1.Font, FontStyle.Bold);
            }
        }

        private void txtAddL1_TextChanged(object sender, EventArgs e)
        {
            txtAddL1.ForeColor = System.Drawing.Color.Black;
            txtAddL1.Font = new Font(txtAddL1.Font, FontStyle.Bold);

            txtAddL1.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtAddL1.Text);
            txtAddL1.Select(txtAddL1.Text.Length, 0);
        }

        private void txtAddL2_Click(object sender, EventArgs e)
        {
            if (txtAddL2.Text == "Line 2")
            {
                txtAddL2.Clear();
                txtAddL2.ForeColor = System.Drawing.Color.Black;
                txtAddL2.Font = new Font(txtAddL2.Font, FontStyle.Bold);
            }

        }

        private void txtAddL2_TextChanged(object sender, EventArgs e)
        {
            txtAddL2.ForeColor = System.Drawing.Color.Black;
            txtAddL2.Font = new Font(txtAddL2.Font, FontStyle.Bold);

            txtAddL2.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtAddL2.Text);
            txtAddL2.Select(txtAddL2.Text.Length, 0);
        }

        private void txtAddL3_Click(object sender, EventArgs e)
        {
            if (txtAddL3.Text == "Line 3")
            {
                txtAddL3.Clear();
                txtAddL3.ForeColor = System.Drawing.Color.Black;
                txtAddL3.Font = new Font(txtAddL3.Font, FontStyle.Bold);
            }
        }

        private void txtAddL3_TextChanged(object sender, EventArgs e)
        {
            txtAddL3.ForeColor = System.Drawing.Color.Black;
            txtAddL3.Font = new Font(txtAddL3.Font, FontStyle.Bold);

            txtAddL3.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtAddL3.Text);
            txtAddL3.Select(txtAddL3.Text.Length, 0);
        }

        private void txtAddL4_Click(object sender, EventArgs e)
        {
            if (txtAddL4.Text == "Line 4")
            {
                txtAddL4.Clear();
                txtAddL4.ForeColor = System.Drawing.Color.Black;
                txtAddL4.Font = new Font(txtAddL4.Font, FontStyle.Bold);
            }
        }

        private void txtAddL4_TextChanged(object sender, EventArgs e)
        {
            txtAddL4.ForeColor = System.Drawing.Color.Black;
            txtAddL4.Font = new Font(txtAddL4.Font, FontStyle.Bold);

            txtAddL4.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtAddL4.Text);
            txtAddL4.Select(txtAddL4.Text.Length, 0);
        }

        // Mobile

        private void txtMob_Click(object sender, EventArgs e)
        {
            if (txtMob.Text == "Mobile")
            {
                txtMob.Clear();
                txtMob.ForeColor = System.Drawing.Color.Black;
                txtMob.Font = new Font(txtMob.Font, FontStyle.Bold);
            }
        }

        private void txtMob_TextChanged(object sender, EventArgs e)
        {
            txtMob.ForeColor = System.Drawing.Color.Black;
            txtMob.Font = new Font(txtMob.Font, FontStyle.Bold);
        }

        // Land_Phone

        private void txtLPhn_Click(object sender, EventArgs e)
        {
            if (txtLPhn.Text == "Land Phone")
            {
                txtLPhn.Clear();
                txtLPhn.ForeColor = System.Drawing.Color.Black;
                txtLPhn.Font = new Font(txtLPhn.Font, FontStyle.Bold);
            }
        }

        private void txtLPhn_TextChanged(object sender, EventArgs e)
        {
            txtLPhn.ForeColor = System.Drawing.Color.Black;
            txtLPhn.Font = new Font(txtLPhn.Font, FontStyle.Bold);
        }

        // Button Next To_CoursePanel From_DetailsPanel (PanelRegistration)

        private void btbNxt2Crz_Click(object sender, EventArgs e)
        {
            if (txtReg.Text != "" && txtNIC.Text != "" && txtFName.Text != "" && txtLName.Text != "" && txtAge.Text != "" && (rbMale.Checked || rbFemale.Checked))
            {
                pnlRegDe.Visible = false;
                lblDtlz.BackColor = System.Drawing.Color.FromArgb(186, 205, 206);
                lblCrz.BackColor = System.Drawing.Color.FromArgb(95, 205, 200);
                pnlRegCrz.Visible = true;
            }
            else
            {
                MessageBox.Show("Please Fill the All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Button Clear In_Details (PanelRegistration)

        private void btnRegDtlzClr_Click_1(object sender, EventArgs e)
        {
            txtReg.Clear();
            txtNIC.Clear();
            txtFName.Clear();
            txtLName.Clear();
            dtpDOB.ResetText();
            txtAge.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;

            txtAddL1.Text = "Line 1";
            txtAddL1.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            txtAddL1.Font = new Font(txtAddL1.Font, FontStyle.Regular);
            txtAddL2.Text = "Line 2";
            txtAddL2.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            txtAddL2.Font = new Font(txtAddL2.Font, FontStyle.Regular);
            txtAddL3.Text = "Line 3";
            txtAddL3.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            txtAddL3.Font = new Font(txtAddL3.Font, FontStyle.Regular);
            txtAddL4.Text = "Line 4";
            txtAddL4.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            txtAddL4.Font = new Font(txtAddL4.Font, FontStyle.Regular);

            txtMob.Text = "Mobile";
            txtMob.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            txtMob.Font = new Font(txtMob.Font, FontStyle.Regular);
            txtLPhn.Text = "Land Phone";
            txtLPhn.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            txtLPhn.Font = new Font(txtLPhn.Font, FontStyle.Regular);
            txtEmail.Clear();
            picbxStd.ImageLocation = "";
        }

        // Panel_Course in Panel_Registration

        // Button Next To_FeePanel From_CoursePanel (PanelRegistration)

        private void btnNxt2Fez_Click(object sender, EventArgs e)
        {
            if ((rbHND.Checked || rbDegree.Checked || rbDip.Checked || rbCer.Checked) && cmbxRegCourse.Text != "" && txtRegBatch.Text != "")
            {

                pnlRegCrz.Visible = false;
                lblCrz.BackColor = System.Drawing.Color.FromArgb(186, 205, 206);
                pnlRegFe.Left = 14;
                pnlRegFe.Visible = true;
                lblFez.BackColor = System.Drawing.Color.FromArgb(95, 205, 200);
            }
            else
            {
                MessageBox.Show("Please Fill the All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Button Back To_Details From_Course (PanelRegistration)

        private void btnBk2Dtlz_Click_1(object sender, EventArgs e)
        {
            pnlRegCrz.Visible = false;
            lblCrz.BackColor = System.Drawing.Color.FromArgb(186, 205, 206);
            pnlRegDe.Visible = true;
            lblDtlz.BackColor = System.Drawing.Color.FromArgb(95, 205, 200);
        }

        // Button Clear In_Course (PanelRegistration)

        private void btnRegCrzClr_Click(object sender, EventArgs e)
        {
            rbHND.Checked = false;
            rbDegree.Checked = false;
            rbDip.Checked = false;
            rbCer.Checked = false;

            cmbxRegCourse.ResetText();
            txtRegBatch.Clear();
        }

        // Panel_Fee in Panel_Registration

        private void rbFPAy_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFPay.Checked)
            {
                lblFPay.Text = "Full Payment :";
                pnlPayTyp.Visible = true;
            }
            else
            {
                lblFPay.Text = "First Payment :";
                pnlPayTyp.Visible = true;
            }
        }

        private void rbMPay_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMPay.Checked)
            {
                lblFPay.Text = "First Payment :";
                pnlPayTyp.Visible = true;
            }
            else
            {
                lblFPay.Text = "Full Payment :";
                pnlPayTyp.Visible = true;
            }
        }

        // Button Back To_Course From_Fee (PanelRegistration)

        private void btnBk2Crz_Click(object sender, EventArgs e)
        {
            pnlRegFe.Visible = false;
            lblFez.BackColor = System.Drawing.Color.FromArgb(186, 205, 206);
            lblCrz.BackColor = System.Drawing.Color.FromArgb(95, 205, 200);
            pnlRegCrz.Visible = true;
        }

        // Button Clear In_Fee (PanelRegistration)

        private void btnRegFzClr_Click(object sender, EventArgs e)
        {
            rbFPay.Checked = false;
            rbMPay.Checked = false;

            txtRegRgFee.Clear();
            txtRegFullPay.Clear();
            pnlPayTyp.Visible = false;

        }

        // Button Student

        int t2 = 40;
        int t3 = 40;

        private void btnMnuStd_Click(object sender, EventArgs e)
        {

        }

        private void btnStd_MouseHover(object sender, EventArgs e)
        {
            clear2();

            pnlStdMore.Visible = false;

            this.pnlStdMore.Size = new Size(this.pnlStdMore.Size.Width, t3);

            if (pnlMnu.Width == 53)
            {
                pnlStdMore.Left = 53;
                pnlStdMore.Visible = true;
            }
            else
            {
                pnlStdMore.Left = 263;
                pnlStdMore.Visible = true;
            }

            tmrStdMr.Start();
        }

        private void btnMnuStd_MouseLeave(object sender, EventArgs e)
        {
            tmrStdMr.Stop();
            t2 = 40;

        }

        private void tmrStdMr_Tick(object sender, EventArgs e)
        {
            if (t2 > 126)
            {
                tmrStdMr.Stop();
            }
            else
            {
                this.pnlStdMore.Size = new Size(this.pnlStdMore.Size.Width, t2);
                t2 += 5;
            }
        }

        // Button_Courses

        private void btnMnuCrz_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pnlReg.Visible = false;
            pnlStd.Visible = false;
            pnlStaffReg.Visible = false;
            pnltt.Visible = false;
            pnlcrz.Visible = true;
        }

        // Button_TimeTable

        private void btnMnuTT_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pnlReg.Visible = false;
            pnlStd.Visible = false;
            pnlStaffReg.Visible = false;
            pnlcrz.Visible = false;
            pnltt.Visible = true;
        }

        // Button_Lecturers

        private void btnMnuLec_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }

        // Button_Administrator

        private void btnMnuAdmin_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            clear();
            cmRegSTitle.Items.Clear();
            cmRegSTitle.Text = "";

            pnlReg.Visible = false;
            pnlStd.Visible = false;
            pnlcrz.Visible = false;
            pnltt.Visible = false;
            pnlStaffReg.Visible = true;
            lblStfDe.BackColor = System.Drawing.Color.FromArgb(95, 205, 200);

            string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hasitha\Documents\Visual Studio 2012\Projects\Students Registration System\Students Registration System\DBCourse.mdf;Integrated Security=True";
            string qurey = "Select * from [tbCourse] ;";
            SqlConnection conDataBase = new SqlConnection(conString);
            SqlCommand cmdDataBase = new SqlCommand(qurey, conDataBase);
            SqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string crz = myReader.GetString(0);
                    cmRegSTitle.Items.Add(crz);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error..:    " + ex);
            }
            finally
            {
                conDataBase.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtAdd4_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBk2Dtlz_Click(object sender, EventArgs e)
        {
           
        }

        private void Home_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void btnStfReg_Click(object sender, EventArgs e)
        {
            if (txtRegSPswd.Text.Length >= 6)
            {
                if (txtRegSID.Text != "" && txtRegSFN.Text != "" && txtRegSLN.Text != "" && txtRegSNIC.Text != "" && txtRegSMob.Text != "" && cmRegSTitle.Text != "" && (rbRegSMale.Checked == true || rbRegSFemale.Checked == true) && txtRegSPswd.Text != "")
                {
                    try
                    {
                        //string pass = "pass";
                        //int id = Convert.ToInt32(txtRegSID.Text.Trim());
                        //string query_search = "SELECT * FROM [tbStaff] WHERE stid = '" + id + "'";
                        //SqlCommand cnd = new SqlCommand(query_search, con);
                        //con.Open();
                        //SqlDataReader r = cnd.ExecuteReader();

                        //    pass = r[15].ToString();

                        //con.Close();


                        int sid = Convert.ToInt32(txtRegSID.Text.Trim());
                        string nic = txtRegSNIC.Text.Trim();
                        string title = cmRegSTitle.Text;
                        string fname = txtRegSFN.Text.Trim();
                        string lname = txtRegSLN.Text.Trim();
                        string gen;
                        if (rbRegSMale.Checked == true)
                        {
                            gen = rbRegSMale.Text;
                        }
                        else
                        {
                            gen = rbRegSFemale.Text;
                        }

                        string pos = txtRegSPosi.Text.Trim();
                        string a1 = txtRegSA1.Text.Trim();
                        string a2 = txtRegSA2.Text.Trim();
                        string a3 = txtRegSA3.Text.Trim();
                        string a4 = txtRegSA4.Text.Trim();
                        int mob = Convert.ToInt32(txtRegSMob.Text.Trim());
                        int lan = Convert.ToInt32(txtRegSLand.Text.Trim());
                        string emal = txtRegSEmail.Text.Trim();
                        string not = txtRegSNote.Text.Trim();
                        string pass = txtRegSPswd.Text;

                        string query_insert = "INSERT INTO [tbStaff] VALUES('" + sid + "','" + nic + "','" + title + "','" + fname + "','" + lname + "','" + gen + "','" + pos + "','" + a1 + "','" + a2 + "','" + a3 + "','" + a4 + "','" + mob + "','" + lan + "','" + emal + "','" + not + "','" + pass + "')";
                        SqlCommand cmnd = new SqlCommand(query_insert, con);
                        con.Open();
                        cmnd.ExecuteNonQuery();
                        MessageBox.Show("REGISTERED SUCCESSFULLY...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
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
                    MessageBox.Show("Please Fill the All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Enter Minimum of 6 Characters for Password", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        void clear()
        {
            txtRegSID.Text = txtRegSNIC.Text = txtRegSFN.Text = txtRegSLN.Text = cmRegSTitle.Text = txtRegSPosi.Text = txtRegSA1.Text = txtRegSA2.Text = txtRegSA3.Text = txtRegSA4.Text = txtRegSMob.Text = txtRegSLand.Text = txtRegSEmail.Text = txtRegSNote.Text = txtRegSPswd.Text = "";
            rbRegSFemale.Checked = false;
            rbRegSMale.Checked = false;
        }

        private void btnStfSrch_Click(object sender, EventArgs e)
        {
            if (txtRegSID.Text != "")
            {
                try
                {
                    int id = Convert.ToInt32(txtRegSID.Text.Trim());
                    string query_search = "SELECT * FROM [tbStaff] WHERE stid = '" + id + "'";
                    SqlCommand cmnd = new SqlCommand(query_search, con);
                    con.Open();
                    SqlDataReader r = cmnd.ExecuteReader();
                    while (r.Read())
                    {
                        txtRegSID.Text = r[0].ToString();
                        txtRegSFN.Text = r[3].ToString();
                        txtRegSLN.Text = r[4].ToString();
                        txtRegSA1.Text = r[7].ToString();
                        txtRegSA2.Text = r[8].ToString();
                        txtRegSA3.Text = r[9].ToString();
                        txtRegSA4.Text = r[10].ToString();
                        txtRegSNIC.Text = r[1].ToString();
                        txtRegSMob.Text = r[11].ToString();
                        txtRegSLand.Text = r[12].ToString();
                        txtRegSEmail.Text = r[13].ToString();
                        cmRegSTitle.Text = r[2].ToString();
                        txtRegSPosi.Text = r[6].ToString();
                        txtRegSNote.Text = r[14].ToString();
                        txtRegSPswd.Text = r[15].ToString();

                        string gen = r[5].ToString();
                        if (gen == "Male")
                        {
                            rbRegSMale.Checked = true;
                        }
                        else if (gen == "Female")
                        {
                            rbRegSFemale.Checked = true;
                        }
                        else
                        {
                            rbRegSMale.Checked = false;
                            rbRegSFemale.Checked = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error While Searching  " + ex);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Fill the Staff ID witch you wish to Search ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStfClr_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnStfUpdt_Click(object sender, EventArgs e)
        {
            if (txtRegSPswd.Text.Length >= 6)
            {
                if (txtRegSID.Text != "" && txtRegSFN.Text != "" && txtRegSLN.Text != "" && txtRegSNIC.Text != "" && txtRegSMob.Text != "" && cmRegSTitle.Text != "" && (rbRegSMale.Checked == true || rbRegSFemale.Checked == true) && txtRegSPswd.Text != "")
                {
                    try
                    {
                       
                        
                            con.Open();

                            int sid = Convert.ToInt32(txtRegSID.Text);
                            string nic = txtRegSNIC.Text.Trim();
                            string title = cmRegSTitle.Text.Trim();
                            string fname = txtRegSFN.Text.Trim();
                            string lname = txtRegSLN.Text.Trim();
                            string gen;
                            if (rbRegSMale.Checked == true)
                            {
                                gen = rbRegSMale.Text;
                            }
                            else
                            {
                                gen = rbRegSFemale.Text;
                            }
                            string pos = txtRegSPosi.Text.Trim();
                            string a1 = txtRegSA1.Text.Trim();
                            string a2 = txtRegSA2.Text.Trim();
                            string a3 = txtRegSA3.Text.Trim();
                            string a4 = txtRegSA4.Text.Trim();
                            int mob = Convert.ToInt32(txtRegSMob.Text);
                            int lan = Convert.ToInt32(txtRegSLand.Text);
                            string emal = txtRegSEmail.Text.Trim();
                            string not = txtRegSNote.Text.Trim();
                            string pswd = txtRegSPswd.Text.Trim();
                            string updatesql = "UPDATE [tbStaff] SET stid='" + sid + "',nic='" + nic + "',title='" + title + "',fname='" + fname + "',lname='" + lname + "',gender='" + gen + "',posision='" + pos + "',a1='" + a1 + "',a2='" + a2 + "',a3='" + a3 + "',a4='" + a4 + "',mob='" + mob + "',lan='" + lan + "',emal='" + emal + "',note='" + not + "',password='" + pswd + "' ";
                            SqlCommand cmnd = new SqlCommand(updatesql, con);
                            cmnd.ExecuteNonQuery();
                            MessageBox.Show("UPDATE SUCCESSFULLY... ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);        
                      
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error While Updating : " + ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        private void btnStfDlt_Click(object sender, EventArgs e)
        {
            if (txtRegSID.Text != "")
            {
                con.Open();

                int id = Convert.ToInt32(txtRegSID.Text.Trim());

                string sqlcmd = "DELETE FROM [tbStaff] WHERE stId='" + id + "' ";

                SqlCommand com = new SqlCommand(sqlcmd, con);
                com.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted...","Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                clear();
            }
            else
            {
                MessageBox.Show("Please fill the Staff ID witch you wish to Delete ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRegRgFee.Text != "")
                {
                    int stuid = Convert.ToInt32(txtReg.Text);                    
                    string nic = txtNIC.Text;
                    string fname = txtFName.Text;
                    string lname = txtLName.Text;
                    string date = dtpDOB.Text;
                    int age = Convert.ToInt32(txtAge.Text);
                    string gen;
                    if (rbMale.Checked == true)
                    {
                        gen = rbMale.Text;
                    }
                    else
                    {
                        gen = rbFemale.Text;
                    }
                    string a1 = txtAddL1.Text;
                    string a2 = txtAddL2.Text;
                    string a3 = txtAddL3.Text;
                    string a4 = txtAddL4.Text;
                    int mob = Convert.ToInt32(txtMob.Text.Trim());
                    int lphn = Convert.ToInt32(txtLPhn.Text.Trim());
                    string emal = txtEmail.Text;
                    string corz = cmbxRegCourse.Text;
                    int batch = Convert.ToInt32(txtRegBatch.Text.Trim());
                    int rgfee = Convert.ToInt32(txtRegRgFee.Text.Trim());
                    int fllPay = 0;
                    int fstpay = 0;
                    if (rbMPay.Checked == true)
                    {
                        fstpay = Convert.ToInt32(txtRegFullPay.Text.Trim());
                    }
                    else if (rbFPay.Checked == true)
                    {
                        fllPay = Convert.ToInt32(txtRegFullPay.Text.Trim());
                    }
                    //string cr1 = "";
                    string cr2 = "";
                    string cr3 = "";
                    //string bt1 = "";
                    string bt2 = "No";
                    string fllPayDt = "";

                    //constd.Open();
                    //string query_search = "SELECT * FROM [tbStudent] WHERE stuid = '" + stuid + "'";
                    //SqlCommand cmnd = new SqlCommand(query_search, constd);
                    //SqlDataReader r = cmnd.ExecuteReader();

                    //while (r.Read())
                    //{
                    //    cr1 = r[14].ToString();
                    //    cr2 = r[16].ToString();
                    //    cr3 = r[18].ToString();
                    //    bt1 = r[15].ToString();
                    //    bt2 = r[17].ToString();
                    //    bt3 = r[19].ToString();
                    //}
                    //constd.Close();

                    //if (cr1 == "")
                    //{
                    //        string c2 = "";
                    //        string b2 = "";
                    //        string c3 = "";
                    //        string b3 = "";
                            string rgdt = "";
                            string fstpydt = "";
                            string scndpyfee = "";
                            string scndpydt = "";
                            string trdpyfee = "";
                            string trdpydt = "";
                            string frtpyfee = "";
                            string frtpydt = "";

                            //byte[] imageBt = null;
                            //FileStream fstream = new FileStream(this.tbImgPath.Text, FileMode.Open, FileAccess.Read);
                            //BinaryReader br = new BinaryReader(fstream);
                            string image = tbImgPath.Text;
                            
                            //string img_path;
                            //File.Copy(openFileDialog1.FileName, wanted_path + "\\Students_Images\\" + stuid + ".jpg");
                            //img_path = "" + stuid +".jpg";

                            string query_insert = "INSERT INTO [tbStudent] VALUES('" + stuid + "','" + nic + "','" + fname + "','" + lname + "','" + date + "','" + age + "','" + gen + "','" + a1 + "','" + a2 + "','" + a3 + "','" + a4 + "','" + mob + "','" + lphn + "','" + emal + "','" + corz + "','" + batch + "','" + cr2 + "','" + bt2 + "','" + fllPay + "','" + fllPayDt + "','" + rgfee + "','" + rgdt + "','" + fstpay + "','" + fstpydt + "','" + scndpyfee + "','" + scndpydt + "','" + trdpyfee + "','" + trdpydt + "','" + frtpyfee + "','" + frtpydt + "','" + image + "')";
                            SqlCommand cmd = new SqlCommand(query_insert, constd);
                            constd.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("1...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            constd.Close();
                        //}
                        //else if (cr2 == "")
                        //{

                        //    string c3 = "";
                        //    string b3 = "";
                        //    string rgdt = "";
                        //    string fstpydt = "";
                        //    string scndpyfee = "";
                        //    string scndpydt = "";
                        //    string trdpyfee = "";
                        //    string trdpydt = "";
                        //    string frtpyfee = "";
                        //    string frtpydt = "";

                        //    constd.Open();
                        //    string query_search2 = "SELECT * FROM [tbStudent] WHERE stuid = '" + stuid + "'";
                        //    SqlCommand cmnd2 = new SqlCommand(query_search2, constd);
                        //    SqlDataReader r2 = cmnd2.ExecuteReader();

                        //    while (r2.Read())
                        //    {
                        //        txtReg.Text = r2[0].ToString();
                        //        txtNIC.Text = r2[1].ToString();
                        //        txtFName.Text = r2[2].ToString();
                        //        txtLName.Text = r2[3].ToString();
                        //        dtpDOB.Text = r2[4].ToString();
                        //        txtAge.Text = r2[5].ToString();
                        //        string gen2 = r2[6].ToString();
                        //        if (gen2 == "Male")
                        //        {
                        //            rbMale.Checked = true;
                        //        }
                        //        else if (gen2 == "Female")
                        //        {
                        //            rbFemale.Checked = true;
                        //        }
                        //        else
                        //        {
                        //            rbMale.Checked = false;
                        //            rbFemale.Checked = false;
                        //        }
                        //        txtAddL1.Text = r2[7].ToString();
                        //        txtAddL2.Text = r2[8].ToString();
                        //        txtAddL3.Text = r2[9].ToString();
                        //        txtAddL4.Text = r2[10].ToString();
                        //        txtMob.Text = r2[11].ToString();
                        //        txtLPhn.Text = r2[12].ToString();
                        //        txtEmail.Text = r2[13].ToString();
                        //        string c1 = r2[14].ToString();
                        //        string b1 = r2[15].ToString();
                                //cr1 = r2[16].ToString();
                                //cr1 = r2[17].ToString();
                                //cr1 = r2[18].ToString();
                                //cr1 = r2[19].ToString();
                            //    cr1 = r2[20].ToString();
                            //    cr1 = r2[21].ToString();
                            //    cr1 = r2[22].ToString();
                            //    cr1 = r2[23].ToString();
                            //    cr1 = r2[24].ToString();
                            //    cr1 = r2[25].ToString();
                            //    cr1 = r2[26].ToString();
                            //    cr1 = r2[27].ToString();
                            //    cr1 = r2[28].ToString();
                            //    cr1 = r2[29].ToString();
                            //    cr1 = r2[30].ToString();
                            //}
                            
                //            MessageBox.Show("2...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            constd.Close();
                //        }
                //        else if (cr3 == "")
                //        {

                //            string rgdt = "";
                //            string fstpydt = "";
                //            string scndpyfee = "";
                //            string scndpydt = "";
                //            string trdpyfee = "";
                //            string trdpydt = "";
                //            string frtpyfee = "";
                //            string frtpydt = "";


                //            string query_insert = "INSERT INTO [tbStudent] VALUES('" + stuid + "','" + nic + "','" + fname + "','" + lname + "','" + date + "','" + age + "','" + gen + "','" + a1 + "','" + a2 + "','" + a3 + "','" + a4 + "','" + mob + "','" + lphn + "','" + emal + "','" + cr1 + "','" + bt1 + "','" + cr2 + "','" + bt2 + "','" + corz + "','" + batch + "','" + rgfee + "','" + rgdt + "','" + fstpay + "','" + fstpydt + "','" + scndpyfee + "','" + scndpydt + "','" + trdpyfee + "','" + trdpydt + "','" + frtpyfee + "','" + frtpydt + "','" + lname + "')";
                //            SqlCommand cmd = new SqlCommand(query_insert, constd);
                //            constd.Open();
                //            cmd.ExecuteNonQuery();
                //            MessageBox.Show("3...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            constd.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("You Already Registred 3 Courses..!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        }
                //    //}




                }
                else
                {
                    MessageBox.Show("Please Fill All Fealds", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("ERROR wile Student Registrating  :  " + ex);
            //}
            finally
            {
                //constd.Close();
                pwd = "";
            }
        }

        private void btnBrow_Click(object sender, EventArgs e)
        {

            //wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            //DialogResult result = openFileDialog1.ShowDialog();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|JPEG Files(*.jpeg)|*.jpeg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            //dlg.Title = "Select Student Picture";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //picbxStd.ImageLocation = openFileDialog1.FileName;
                //picbxStd.SizeMode = PictureBoxSizeMode.StretchImage;
                string picPath = dlg.FileName.ToString();
                tbImgPath.Text = picPath;
                picbxStd.ImageLocation = picPath;
                picbxStd.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnStdSrch_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            btnStdDtlzUpdate.Enabled = false;
            btnStdCrzUpdate.Enabled = false;
            btnStdUpdate.Enabled = false;
            btnStdDlt.Enabled = false;

            pnlStaffReg.Visible = false;
            pnlReg.Visible = false;
            pnlStdMore.Visible = false;
            pnlStdCrz.Visible = false;
            pnlStdFez.Visible = false;
            pnlcrz.Visible = false;
            pnltt.Visible = false;
            pnlStd.Visible = true;
            pnlStdDtlz.Visible = true;

            lblStdDtlz.BackColor = System.Drawing.Color.FromArgb(95, 205, 200);

        }

        void clear2()
        {
            txtStdID.Clear();
            txtStdNIC.Clear();
            txtStdFName.Clear();
            txtStdLName.Clear();
            dtpStbDOB.ResetText();
            txtStdAge.Clear();
            rbStdMale.Checked = false;
            rbStdFemale.Checked = false;
            txtStdAddL1.Clear();
            txtStdAddL2.Clear();
            txtStdAddL3.Clear();
            txtStdAddL4.Clear();
            txtStdMob.Clear();
            txtStdLand.Clear();
            txtStdEmail.Clear();
            //pbStdStd.Image;
            lblStdCrzCrz.Text = "";
            lblStdCrzBatch.Text = "";
            lblStdCrzRegDate.Text = "";
            lblStdCrzLvDate.Text = "";
            dtpStdCrzLvDate.ResetText();
            rbStdCrzYes.Checked = false;
            rbStdCrzNo.Checked = false;
            txtStdRegFee.Clear();
            lblStdRegDt.Text = "";
            txtStdFull.Clear();
            lblStdFullDt.Text = "";
            txtStdPay1.Clear();
            txtStdPay2.Clear();
            txtStdPay3.Clear();
            txtStdPay4.Clear();
            lblStd1Dt.Text = "";
            lblStd2Dt.Text = "";
            lblStd3Dt.Text = "";
            lblStd4Dt.Text = "";
        }

        private void btnStdDtlzSearch_Click(object sender, EventArgs e)
        {
                int stuid = Convert.ToInt32(txtStdID.Text);
                constd.Open();
                string query_search2 = "SELECT * FROM [tbStudent] WHERE stuid = '" + stuid + "'";
                SqlCommand cmnd2 = new SqlCommand(query_search2, constd);
                SqlDataReader r2 = cmnd2.ExecuteReader();

                while (r2.Read())
                {
                    txtStdID.Text = r2[0].ToString();
                    txtStdNIC.Text = r2[1].ToString();
                    txtStdFName.Text = r2[2].ToString();
                    txtStdLName.Text = r2[3].ToString();
                    //dtpStbDOB.Text = r2[4].ToString();
                    txtStdAge.Text = r2[5].ToString();
                    string gen2 = r2[6].ToString();
                    if (gen2 == "Female")
                    {
                        rbStdFemale.Checked = true;
                    }
                    else
                    {
                        rbStdMale.Checked = true;
                    }
                   
                    txtStdAddL1.Text = r2[7].ToString();
                    txtStdAddL2.Text = r2[8].ToString();
                    txtStdAddL3.Text = r2[9].ToString();
                    txtStdAddL4.Text = r2[10].ToString();
                    txtStdMob.Text = r2[11].ToString();
                    txtStdLand.Text = r2[12].ToString();
                    txtStdEmail.Text = r2[13].ToString();
                    lblStdCrzCrz.Text = r2[14].ToString();
                    lblStdCrzBatch.Text = r2[15].ToString();
                    lblStdCrzLvDate.Text = r2[16].ToString();
                    string cer = r2[17].ToString();
                    if (cer == "Yes")
                    {
                        rbStdCrzYes.Checked = true;
                    }
                    else if (cer == "No")
                    {
                        rbStdCrzNo.Checked = true;
                    }
                    else
                    {
                        rbStdCrzYes.Checked = false;
                        rbStdCrzNo.Checked = false;
                    }
                    txtStdFull.Text = r2[18].ToString();
                    lblStdFullDt.Text = r2[19].ToString();
                    txtStdRegFee.Text = r2[20].ToString();
                    lblStdCrzRegDate.Text = r2[21].ToString();
                    txtStdPay1.Text = r2[22].ToString();
                    lblStd1Dt.Text = r2[23].ToString();
                    txtStdPay2.Text = r2[24].ToString();
                    lblStd2Dt.Text = r2[25].ToString();
                    txtStdPay3.Text = r2[26].ToString();
                    lblStd3Dt.Text = r2[27].ToString();
                    txtStdPay4.Text = r2[28].ToString();
                    lblStd4Dt.Text = r2[29].ToString();
                    string image = r2[30].ToString();
                    pbStdStd.ImageLocation = image;
                }
                constd.Close();
        }

        private void btnStdDtlz2Crz_Click(object sender, EventArgs e)
        {
            pnlStdCrz.Left = 14;
            pnlStdDtlz.Visible = false;
            lblStdDtlz.BackColor = System.Drawing.Color.FromArgb(186, 205, 206);
            pnlStdCrz.Visible = true;
            lblStdCrz.BackColor = System.Drawing.Color.FromArgb(95, 205, 200);
        }

        private void btnStdCrz2Fez_Click(object sender, EventArgs e)
        {
            pnlStdCrz.Visible = false;
            pnlStdFez.Left = 14;
            lblStdCrz.BackColor = System.Drawing.Color.FromArgb(186, 205, 206);
            pnlStdFez.Visible = true;
            lblStdFez.BackColor = System.Drawing.Color.FromArgb(95, 205, 200);
        }

        private void btnStdCrz2Dtlz_Click(object sender, EventArgs e)
        {
            pnlStdCrz.Visible = false;
            lblStdCrz.BackColor = System.Drawing.Color.FromArgb(186, 205, 206);
            pnlStdDtlz.Visible = true;
            lblStdDtlz.BackColor = System.Drawing.Color.FromArgb(95, 205, 200);
        }

        private void btnStdBk2Crz_Click(object sender, EventArgs e)
        {
            pnlStdFez.Visible = false;
            lblStdFez.BackColor = System.Drawing.Color.FromArgb(186, 205, 206);
            pnlStdCrz.Left = 14;
            pnlStdCrz.Visible = true;
            lblStdCrz.BackColor = System.Drawing.Color.FromArgb(95, 205, 200);
        }

        private void btnStdUpdate_Click(object sender, EventArgs e)
        {
            stdUpdate();
        }

        private void btnStdDlt_Click(object sender, EventArgs e)
        {
            if (txtStdID.Text != "")
            {
                constd.Open();

                int id = Convert.ToInt32(txtStdID.Text.Trim());

                string sqlcmd = "DELETE FROM [tbStudent] WHERE stuid='" + id + "' ";

                SqlCommand com = new SqlCommand(sqlcmd, constd);
                com.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted...", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                constd.Close();
                clear2();
                pnlStdFez.Visible = false;
                pnlStdDtlz.Visible = true;
            }
            else
            {
                MessageBox.Show("Please fill the Student ID witch you wish to Delete ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void stdUpdate()
        {
            if (txtStdID.Text != "" && txtStdNIC.Text != "" && txtStdFName.Text != "" && txtStdLName.Text != "" && dtpStbDOB.Text != "" && txtStdAge.Text != "" && txtStdRegFee.Text != "" && (rbStdMale.Checked == true || rbStdFemale.Checked == true))
            {
                try
                {

                    int stu1id = Convert.ToInt32(txtStdID.Text);
                    constd.Open();
                    string query_search2 = "SELECT * FROM [tbStudent] WHERE stuid = '" + stu1id + "'";
                    SqlCommand cmnd2 = new SqlCommand(query_search2, constd);
                    SqlDataReader r2 = cmnd2.ExecuteReader();

                    while (r2.Read())
                    {
                        int id = Convert.ToInt32(r2[0]);
                        string nic = r2[1].ToString();
                        string fnama = r2[2].ToString();
                        string lname = r2[3].ToString();
                        string dob  = r2[4].ToString();
                        int age = Convert.ToInt32(r2[5]);
                        string gen2 = r2[6].ToString();
                        if (gen2 == "Female")
                        {
                            rbStdFemale.Checked = true;
                        }
                        else
                        {
                            rbStdMale.Checked = true;
                        }

                        string a1 = r2[7].ToString();
                        string a2 = r2[8].ToString();
                        string a3 = r2[9].ToString();
                        string a4 = r2[10].ToString();
                        int mob = Convert.ToInt32(r2[11]);
                        int land = Convert.ToInt32(r2[12]);
                        string emal = r2[13].ToString();
                        string corz = r2[14].ToString();
                        int batch = Convert.ToInt32(r2[15]);
                        string ldt = r2[16].ToString();
                        string cer1 = r2[17].ToString();
                        if (cer1 == "Yes")
                        {
                            rbStdCrzYes.Checked = true;
                        }
                        else if (cer1 == "No")
                        {
                            rbStdCrzNo.Checked = true;
                        }
                        else
                        {
                            rbStdCrzYes.Checked = false;
                            rbStdCrzNo.Checked = false;
                        }
                        int fllpay = Convert.ToInt32(r2[18]);
                        string fllfdt = r2[19].ToString();
                        int rgfee = Convert.ToInt32(r2[20]);
                        string regDt = r2[21].ToString();
                        int p1 = Convert.ToInt32(r2[22]);
                        string p1dt = r2[23].ToString();
                        int p2 = Convert.ToInt32(r2[24]);
                        string p2dt = r2[25].ToString();
                        int p3 = Convert.ToInt32(r2[26]);
                        string p3dt = r2[27].ToString();
                        int p4 = Convert.ToInt32(r2[28]);
                        string p4dt = r2[29].ToString();
                        string img = r2[30].ToString();

                        constd.Close();







                        constd.Open();
                        //int id = 25;//Convert.ToInt32(txtStdID.Text.Trim());
                        //string nic = "95";//txtStdNIC.Text;
                        //string fnama = "dsfg";// txtStdFName.Text;
                        //string lname = "dfg";// txtStdLName.Text;
                        //string dob = "2018";// dtpStbDOB.Text;
                        //int age = 22;// Convert.ToInt32(txtStdAge.Text);
                        string gen;
                        if (rbStdMale.Checked == true)
                        {
                            gen = rbStdMale.Text;
                        }
                        else
                        {
                            gen = rbStdFemale.Text;
                        }
                        //string a1 = "a1";// txtStdAddL1.Text;
                        //string a2 = "a2";//txtStdAddL2.Text;
                        //string a3 = "a3";//txtStdAddL3.Text;
                        //string a4 = "a4";//txtStdAddL4.Text;
                        //int mob = 071;// Convert.ToInt32(txtStdMob.Text);
                        //int land = 034;// Convert.ToInt32(txtStdLand.Text);
                        //string emal = "Emal";//txtStdEmail.Text;
                        ////pbStdStd
                        //string img = "ERROR";
                        //string corz = "Ditec";//lblStdCrzCrz.Text;
                        //int batch = 25;// Convert.ToInt32(lblStdCrzBatch.Text);
                        //string regDt = "a1";//lblStdCrzRegDate.Text;
                        //string ldt = "a1";//lblStdCrzLvDate.Text;
                        string cer;
                        if (rbStdCrzYes.Checked == true)
                        {
                            cer = rbStdCrzYes.Text;
                        }
                        else
                        {
                            cer = rbStdCrzNo.Text;
                        }
                        //int rgfee = 25;// Convert.ToInt32(txtStdRegFee.Text);
                        //int fllpay = 25;// Convert.ToInt32(txtStdFull.Text);
                        //string fllfdt = "a1";//lblStdFullDt.Text;
                        //int p1 = 25;//Convert.ToInt32(txtStdPay1.Text);
                        //string p1dt = "a1";//lblStd1Dt.Text;
                        //int p2 = 25;//Convert.ToInt32(txtStdPay2.Text);
                        //string p2dt = "a1";//lblStd2Dt.Text;
                        //int p3 = 25;//Convert.ToInt32(txtStdPay3.Text);
                        //string p3dt = "a1";//lblStd3Dt.Text;
                        //int p4 = 25;//Convert.ToInt32(txtStdPay4.Text);
                        //string p4dt = "a1";//lblStd4Dt.Text;

                        string sqlcmd = "UPDATE [tbStudent] SET stuid='" + Convert.ToInt32(txtStdID.Text) + "' where stuid='" + id + "'"; //,stunic='" + txtStdNIC.Text + "' where stunic='" + nic + "',fname='" + txtStdFName.Text + "' where fname='" + fnama + "',lname='" + txtStdLName.Text + "' where lname='" + lname + "',dob='" + dtpStbDOB.Text + "' where dob='" + dob + "',age='" + Convert.ToInt32(txtStdAge.Text) + "' where age='" + age + "',gen='" + gen + "' where gen='" + gen2 + "',a1='" + txtStdAddL1.Text + "' where a1='" + a1 + "',a2='" + txtStdAddL2.Text + "' where a2='" + a2 + "',a3='" + txtStdAddL3.Text + "' where a3='" + a3 + "',a4='" + txtStdAddL4.Text + "' where a4='" + a4 + "',mob='" + Convert.ToInt32(txtStdMob.Text) + "' where mob='" + mob + "',land='" + Convert.ToInt32(txtStdLand.Text) + "' where land='" + land + "',emal='" + txtStdEmail.Text + "' where emal='" + emal + "',c1='" + lblStdCrzCrz.Text + "' where c1='" + corz + "',b1='" + Convert.ToInt32(lblStdCrzBatch.Text) + "' where b1='" + batch + "',leave_dat='" + lblStdCrzLvDate.Text + "' where leave_dat='" + ldt + "',ceti_issd='" + cer + "' where ceti_issd='" + cer1 + "',fllPay='" + Convert.ToInt32(txtStdFull.Text) + "' where fllPay='" + fllpay + "',fllPayDt='" + lblStdFullDt.Text + "' where fllPayDt='" + fllfdt + "',regfee='" + Convert.ToInt32(txtStdRegFee.Text) + "' where regfee='" + rgfee + "',regdate='" + lblStdCrzRegDate.Text + "' where regdate='" + regDt + "',1pay='" + Convert.ToInt32(txtStdPay1.Text) + "' where 1pay='" + p1 + "',1dat='" + lblStd1Dt.Text + "' where 1dat='" + p1dt + "',2pay='" + Convert.ToInt32(txtStdPay2.Text) + "' where 2pay='" + p2 + "',2dat='" + lblStd2Dt.Text + "' where 2dat='" + p2dt + "',3pay='" + Convert.ToInt32(txtStdPay3.Text) + "' where 3pay='" + p3 + "',3dat='" + lblStd3Dt.Text + "' where 3dat='" + p3dt + "',4pay='" + Convert.ToInt32(txtStdPay4.Text) + "' where 4pay='" + p4 + "',4dat='" + lblStd4Dt.Text + "' where 4dat='" + p4dt + "',img='" + img + "' where img='" + img + "'";
                        SqlCommand comn = new SqlCommand(sqlcmd, constd);
                        comn.ExecuteNonQuery();
                        MessageBox.Show("Updated Successfully");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error While Updating....:    " + ex);
                }
                finally
                {
                    constd.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Please Fill the All Fields..!! ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
               
            


        }

        private void btnStdDtlzUpdate_Click(object sender, EventArgs e)
        {
            stdUpdate();
        }

        private void btnStdDtlzClr_Click(object sender, EventArgs e)
        {
            clear2();
        }

        private void btnStdCrzClr_Click(object sender, EventArgs e)
        {
            clear2();
        }

        private void btnStdClr_Click(object sender, EventArgs e)
        {
            clear2();
        }

        private void btnStdCrzUpdate_Click(object sender, EventArgs e)
        {
            stdUpdate();
        }

        private void btnStdBrwz_Click(object sender, EventArgs e)
        {

        }

        private void pnlReg_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void pnlRegDe_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlRegDe_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void pnlRegFe_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlRegFe_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void pnlRegCrz_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void pnlStaffReg_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void pnlStfDe_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void pnlStd_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void pnlStdDtlz_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void pnlStdFez_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void pnlStdCrz_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            btnStdDtlzUpdate.Enabled = true;
            btnStdCrzUpdate.Enabled = true;
            btnStdUpdate.Enabled = true;
            btnStdDlt.Enabled = false;
            pnlStdMore.Visible = false;

            pnlStaffReg.Visible = false;
            pnlReg.Visible = false;
            pnlStdCrz.Visible = false;
            pnlStdFez.Visible = false;
            pnlcrz.Visible = false;
            pnltt.Visible = false;
            pnlStd.Visible = true;
            pnlStdDtlz.Visible = true;

            lblStdDtlz.BackColor = System.Drawing.Color.FromArgb(95, 205, 200);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pnlStdMore.Visible = false;
            btnStdDtlzUpdate.Enabled = false;
            btnStdCrzUpdate.Enabled = false;
            btnStdUpdate.Enabled = false;
            btnStdDlt.Enabled = true;

            pnlStaffReg.Visible = false;
            pnlReg.Visible = false;
            pnlStdCrz.Visible = false;
            pnlStdFez.Visible = false;
            pnlcrz.Visible = false;
            pnltt.Visible = false;
            pnlStd.Visible = true;
            pnlStdDtlz.Visible = true;
        }

        private void Home_Load(object sender, EventArgs e)
        {
           
        }

        private void btnMnuReg_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void btnMnuCrz_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void btnMnuDsh_Click(object sender, EventArgs e)
        {
            pnlReg.Visible = false;
            pnltt.Visible = false;
            pnlcrz.Visible = false;
            pnlStaffReg.Visible = false;
            pnlStd.Visible = false;
            pictureBox1.Visible = true;
        }

        private void btnMnuDsh_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void btnMnuTT_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void pnlMnu_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void txtAge_MouseDown(object sender, MouseEventArgs e)
        {
            string bDay = (dtpDOB.Text);
            string year = new string(bDay.Take(4).ToArray());
            string today = DateTime.Today.Year.ToString();
            int age = Convert.ToInt32(today) - Convert.ToInt32(year);
            txtAge.Text = age.ToString();
        }

        private void cmbxRegCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        void fillCrz()
        {
            //if (rbHND.Checked == true)
            //{
                string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hasitha\Documents\Visual Studio 2012\Projects\Students Registration System\Students Registration System\DBCourse.mdf;Integrated Security=True";
                string qurey = "Select * from [tbCourse] ;";
                SqlConnection conDataBase = new SqlConnection(conString);
                SqlCommand cmdDataBase = new SqlCommand(qurey, conDataBase);
                SqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    while (myReader.Read())
                    {
                        string crz = myReader.GetString(1);
                        cmbxRegCourse.Items.Add(crz);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error..:    " + ex);
                }
                finally
                {
                    conDataBase.Close();
                }


            //}
            //else if (rbDegree.Checked == true)
            //{

            //}
            //else if (rbDip.Checked == true)
            //{

            //}
            //else if (rbCer.Checked == true)
            //{

            //}
        }

        private void cmbxRegCourse_Click(object sender, EventArgs e)
        {
            //fillCrz();
        }

        private void rbHND_CheckedChanged(object sender, EventArgs e)
        {
            cmbxRegCourse.Items.Clear();
            cmbxRegCourse.Text = "";
            fillCrz();
        }

        private void rbDegree_CheckedChanged(object sender, EventArgs e)
        {
            cmbxRegCourse.Items.Clear();
            cmbxRegCourse.Text = "";
            string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hasitha\Documents\Visual Studio 2012\Projects\Students Registration System\Students Registration System\DBCourse.mdf;Integrated Security=True";
            string qurey = "Select * from [tbCourse] ;";
            SqlConnection conDataBase = new SqlConnection(conString);
            SqlCommand cmdDataBase = new SqlCommand(qurey, conDataBase);
            SqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string crz = myReader.GetString(2);
                    cmbxRegCourse.Items.Add(crz);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error..:    " + ex);
            }
            finally
            {
                conDataBase.Close();
            }
        }

        private void rbDip_CheckedChanged(object sender, EventArgs e)
        {
            cmbxRegCourse.Items.Clear();
            cmbxRegCourse.Text = "";
            string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hasitha\Documents\Visual Studio 2012\Projects\Students Registration System\Students Registration System\DBCourse.mdf;Integrated Security=True";
            string qurey = "Select * from [tbCourse] ;";
            SqlConnection conDataBase = new SqlConnection(conString);
            SqlCommand cmdDataBase = new SqlCommand(qurey, conDataBase);
            SqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string crz = myReader.GetString(3);
                    cmbxRegCourse.Items.Add(crz);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error..:    " + ex);
            }
            finally
            {
                conDataBase.Close();
            }
        }

        private void rbCer_CheckedChanged(object sender, EventArgs e)
        {
            cmbxRegCourse.Items.Clear();
            cmbxRegCourse.Text = "";
            string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hasitha\Documents\Visual Studio 2012\Projects\Students Registration System\Students Registration System\DBCourse.mdf;Integrated Security=True";
            string qurey = "Select * from [tbCourse] ;";
            SqlConnection conDataBase = new SqlConnection(conString);
            SqlCommand cmdDataBase = new SqlCommand(qurey, conDataBase);
            SqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string crz = myReader.GetString(4);
                    cmbxRegCourse.Items.Add(crz);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error..:    " + ex);
            }
            finally
            {
                conDataBase.Close();
            }
        }

        private void btnLOut_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Close();
        }

        private void pbStdStd_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            rtxtHnd.Visible = false;
            rtxtDeg.Visible = false;
            rtxtDip.Visible = false;
            rtxtCer.Visible = false;

            rtxtHnd.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            rtxtHnd.Visible = false;
            rtxtDeg.Visible = false;
            rtxtDip.Visible = false;
            rtxtCer.Visible = false;

            rtxtDeg.Visible = true;
        }

        private void btnDip_Click(object sender, EventArgs e)
        {
            rtxtHnd.Visible = false;
            rtxtDeg.Visible = false;
            rtxtDip.Visible = false;
            rtxtCer.Visible = false;

            rtxtDip.Visible = true;
        }

        private void btnCer_Click(object sender, EventArgs e)
        {
            rtxtHnd.Visible = false;
            rtxtDeg.Visible = false;
            rtxtDip.Visible = false;
            rtxtCer.Visible = false;

            rtxtCer.Visible = true;
        }

        private void btnGrdVw_Click(object sender, EventArgs e)
        {
            pnlRegDe.Visible = false;
            pnlGrdVw.Visible = true;

            constd.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select* from [tbStudent]",constd);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            constd.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            pnlRegDe.Visible = true;
            pnlGrdVw.Visible = false;
        }

        private void pnlGrdVw_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            pnlStdMore.Visible = false;
        }

        private void btnSGrdVw_Click(object sender, EventArgs e)
        {
            pnlSGrdVw.Visible = true;
            pnlStfDe.Visible = false;

            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select* from [tbStaff]", con);
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void btnSOk_Click(object sender, EventArgs e)
        {
            pnlSGrdVw.Visible = false;
            pnlStfDe.Visible = true;
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            txtFName.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtFName.Text);
            txtFName.Select(txtFName.Text.Length, 0);
        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {
            txtLName.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtLName.Text);
            txtLName.Select(txtLName.Text.Length, 0);
        }

        private void txtRegSFN_TextChanged(object sender, EventArgs e)
        {
            txtRegSFN.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtRegSFN.Text);
            txtRegSFN.Select(txtRegSFN.Text.Length, 0);
        }

        private void txtRegSLN_TextChanged(object sender, EventArgs e)
        {
            txtRegSLN.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtRegSLN.Text);
            txtRegSLN.Select(txtRegSLN.Text.Length, 0);
        }

        private void txtRegSPosi_TextChanged(object sender, EventArgs e)
        {
            txtRegSPosi.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtRegSPosi.Text);
            txtRegSPosi.Select(txtRegSPosi.Text.Length, 0);
        }

        private void txtRegSA1_TextChanged(object sender, EventArgs e)
        {
            txtRegSA1.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtRegSA1.Text);
            txtRegSA1.Select(txtRegSA1.Text.Length, 0);
        }

        private void txtRegSA2_TextChanged(object sender, EventArgs e)
        {
            txtRegSA2.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtRegSA2.Text);
            txtRegSA2.Select(txtRegSA2.Text.Length, 0);
        }

        private void txtRegSA3_TextChanged(object sender, EventArgs e)
        {
            txtRegSA3.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtRegSA3.Text);
            txtRegSA3.Select(txtRegSA3.Text.Length, 0);
        }

        private void txtRegSA4_TextChanged(object sender, EventArgs e)
        {
            txtRegSA4.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtRegSA4.Text);
            txtRegSA4.Select(txtRegSA4.Text.Length, 0);
        }

        private void txtStdFName_TextChanged(object sender, EventArgs e)
        {
            txtStdFName.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtStdFName.Text);
            txtStdFName.Select(txtStdFName.Text.Length, 0);
        }

        private void txtStdLName_TextChanged(object sender, EventArgs e)
        {
            txtStdLName.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtStdLName.Text);
            txtStdLName.Select(txtStdLName.Text.Length, 0);
        }

        private void txtStdAddL1_TextChanged(object sender, EventArgs e)
        {
            txtStdAddL1.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtStdAddL1.Text);
            txtStdAddL1.Select(txtStdAddL1.Text.Length, 0);
        }

        private void txtStdAddL2_TextChanged(object sender, EventArgs e)
        {
            txtStdAddL2.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtStdAddL2.Text);
            txtStdAddL2.Select(txtStdAddL2.Text.Length, 0);
        }

        private void txtStdAddL3_TextChanged(object sender, EventArgs e)
        {
            txtStdAddL3.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtStdAddL3.Text);
            txtStdAddL3.Select(txtStdAddL3.Text.Length, 0);
        }

        private void txtStdAddL4_TextChanged(object sender, EventArgs e)
        {
            txtStdAddL4.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtStdAddL4.Text);
            txtStdAddL4.Select(txtStdAddL4.Text.Length, 0);
        }
    }
}
