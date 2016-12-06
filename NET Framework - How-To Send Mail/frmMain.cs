//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Web.Mail;
using System.Text;
using System.ServiceProcess;
using System.Collections;

public class frmMain: System.Windows.Forms.Form {

    // For use with the WndProc override routine

    const int WM_SYSCOMMAND = 0x112;
    const int SC_CLOSE = 0xF060;

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Windows Form Designer generated code "

    public frmMain() {

        

        //This call is required by the Windows Form Designer.

        InitializeComponent();

        //Add any initialization after the InitializeComponent() call
        // So that we only need to set the title of the application once,
        // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
        // to read the AssemblyTitle attribute.

        AssemblyInfo ainfo = new AssemblyInfo();

        this.Text = ainfo.Title;

        this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);

    }

    //Form overrides dispose to clean up the component list.

    protected override void Dispose(bool disposing) {

        if (disposing) {

            if (components != null) {

                components.Dispose();

            }

        }

        base.Dispose(disposing);

    }

    //Required by the Windows Form Designer

    private System.ComponentModel.IContainer components = null;

    //NOTE: The following procedure is required by the Windows Form Designer

    //It can be modified using the Windows Form Designer.  

    //Do not modify it using the code editor.

    private System.Windows.Forms.Button btnSend;

    private System.Windows.Forms.Label lblFrom;

    private System.Windows.Forms.Label lblTo;

    private System.Windows.Forms.Label lblSubject;

    private System.Windows.Forms.Label lblBody;

    private System.Windows.Forms.Label lblBCC;

    private System.Windows.Forms.Label lblCC;

    private System.Windows.Forms.ErrorProvider erpEmailAddresses;

    private System.Windows.Forms.TextBox txtFrom;

    private System.Windows.Forms.TextBox txtTo;

    private System.Windows.Forms.TextBox txtSubject;

    private System.Windows.Forms.TextBox txtBody;

    private System.Windows.Forms.TextBox txtCC;

    private System.Windows.Forms.TextBox txtBCC;

    private System.Windows.Forms.ComboBox cboPriority;

    private System.Windows.Forms.Button btnBrowse;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.OpenFileDialog odlgAttachment;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.ListBox lstAttachments;

	private void InitializeComponent() 
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnSend = new System.Windows.Forms.Button();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblBody = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.lblBCC = new System.Windows.Forms.Label();
            this.lblCC = new System.Windows.Forms.Label();
            this.erpEmailAddresses = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtBCC = new System.Windows.Forms.TextBox();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.odlgAttachment = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.erpEmailAddresses)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.BackColor = System.Drawing.SystemColors.Control;
            this.btnSend.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSend.Name = "btnSend";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtFrom
            // 
            this.txtFrom.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.txtFrom, "txtFrom");
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Validating += new System.ComponentModel.CancelEventHandler(this.emailAddresses_Validating);
            this.txtFrom.Validated += new System.EventHandler(this.emailAddresses_Validated);
            // 
            // lblFrom
            // 
            this.lblFrom.BackColor = System.Drawing.SystemColors.Control;
            this.lblFrom.CausesValidation = false;
            resources.ApplyResources(this.lblFrom, "lblFrom");
            this.lblFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFrom.Name = "lblFrom";
            // 
            // lblTo
            // 
            this.lblTo.BackColor = System.Drawing.SystemColors.Control;
            this.lblTo.CausesValidation = false;
            resources.ApplyResources(this.lblTo, "lblTo");
            this.lblTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTo.Name = "lblTo";
            // 
            // lblSubject
            // 
            this.lblSubject.BackColor = System.Drawing.SystemColors.Control;
            this.lblSubject.CausesValidation = false;
            resources.ApplyResources(this.lblSubject, "lblSubject");
            this.lblSubject.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubject.Name = "lblSubject";
            // 
            // lblBody
            // 
            this.lblBody.BackColor = System.Drawing.SystemColors.Control;
            this.lblBody.CausesValidation = false;
            resources.ApplyResources(this.lblBody, "lblBody");
            this.lblBody.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBody.Name = "lblBody";
            // 
            // txtTo
            // 
            this.txtTo.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.txtTo, "txtTo");
            this.txtTo.Name = "txtTo";
            this.txtTo.Validating += new System.ComponentModel.CancelEventHandler(this.emailAddresses_Validating);
            this.txtTo.Validated += new System.EventHandler(this.emailAddresses_Validated);
            // 
            // txtSubject
            // 
            this.txtSubject.BackColor = System.Drawing.SystemColors.Window;
            this.txtSubject.CausesValidation = false;
            resources.ApplyResources(this.txtSubject, "txtSubject");
            this.txtSubject.Name = "txtSubject";
            // 
            // txtBody
            // 
            this.txtBody.BackColor = System.Drawing.SystemColors.Window;
            this.txtBody.CausesValidation = false;
            resources.ApplyResources(this.txtBody, "txtBody");
            this.txtBody.Name = "txtBody";
            // 
            // txtCC
            // 
            this.txtCC.BackColor = System.Drawing.SystemColors.Window;
            this.txtCC.CausesValidation = false;
            resources.ApplyResources(this.txtCC, "txtCC");
            this.txtCC.Name = "txtCC";
            // 
            // lblBCC
            // 
            this.lblBCC.BackColor = System.Drawing.SystemColors.Control;
            this.lblBCC.CausesValidation = false;
            resources.ApplyResources(this.lblBCC, "lblBCC");
            this.lblBCC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBCC.Name = "lblBCC";
            // 
            // lblCC
            // 
            this.lblCC.BackColor = System.Drawing.SystemColors.Control;
            this.lblCC.CausesValidation = false;
            resources.ApplyResources(this.lblCC, "lblCC");
            this.lblCC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCC.Name = "lblCC";
            // 
            // erpEmailAddresses
            // 
            this.erpEmailAddresses.ContainerControl = this;
            resources.ApplyResources(this.erpEmailAddresses, "erpEmailAddresses");
            // 
            // txtBCC
            // 
            this.txtBCC.BackColor = System.Drawing.SystemColors.Window;
            this.txtBCC.CausesValidation = false;
            resources.ApplyResources(this.txtBCC, "txtBCC");
            this.txtBCC.Name = "txtBCC";
            // 
            // cboPriority
            // 
            this.cboPriority.CausesValidation = false;
            this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboPriority, "cboPriority");
            this.cboPriority.Name = "cboPriority";
            // 
            // btnBrowse
            // 
            this.btnBrowse.CausesValidation = false;
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Name = "Label1";
            // 
            // lstAttachments
            // 
            this.lstAttachments.CausesValidation = false;
            resources.ApplyResources(this.lstAttachments, "lstAttachments");
            this.lstAttachments.Items.AddRange(new object[] {
            resources.GetString("lstAttachments.Items")});
            this.lstAttachments.Name = "lstAttachments";
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.CausesValidation = false;
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.lstAttachments);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.cboPriority);
            this.Controls.Add(this.txtBCC);
            this.Controls.Add(this.txtCC);
            this.Controls.Add(this.lblBCC);
            this.Controls.Add(this.lblCC);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.Label1);
            this.ForeColor = System.Drawing.Color.Blue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erpEmailAddresses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}

#endregion

#region " Standard Menu Code "

    

    

    // This code simply shows the About form.

    private void mnuAbout_Click(object sender, System.EventArgs e) 
    {



    }

    // This code will close the form.

    private void mnuExit_Click(object sender, System.EventArgs e) {

        // Turn of validation for all controls with CausesValidation = true or else

        // you will not be able to close the Form until valid data is entered.

        txtTo.CausesValidation = false;

        txtFrom.CausesValidation = false;

        // Close the current form

        this.Close();

    }

#endregion

    ArrayList arlAttachments;

    // Checks for empty strings and does basic check for valid email
    // address.

    private void ValidateEmailAddress(TextBox txt)
	{

        // Confirm there is text in the control.

		if (txt.TextLength == 0) 
		{

			throw new Exception("Email address is a required field");
		}
		else 
		{

			// Confirm that there is a "." and an "@" in the e-mail address.

			if ((txt.Text.IndexOf(".") == -1) | (txt.Text.IndexOf("@") == -1)) 
			{
				throw new Exception("E-mail address must be valid e-mail " + 
					"address format." + "\r" + "For example " + 
				"'someone@microsoft.com'");
			}
		}
    }

    // This method overrides the WndProc of the Form and catches the Close message

    // passed when the user attempts to exit the Form. Without this there is no way

    // to prevent the ErrorProvider control from attempting to validate the "To" and 

    // "From" TextBox controls (the only controls with CausesValidation = true). if

    // invalid or no data is entered when the user attempts to close the Form, the

    // validators fire and the Form will not close.

    protected override void WndProc(ref System.Windows.Forms.Message m)
	{

        if (m.Msg == WM_SYSCOMMAND) {

            if (m.WParam.ToInt32() == SC_CLOSE) {

                // Turn off validation for all controls with CausesValidation = true or else
                // you will not be able to close the Form until valid data is entered.

                txtTo.CausesValidation = false;

                txtFrom.CausesValidation = false;

            }

        }

        // Pass other messages on to the original WndProc.

        base.WndProc(ref m);

    }

    // the Browse button click event. Uses an OpenFileDialog to allow the 
    // user to find an attachment to send, which is then added to an arraylist of
    // MailAttachment objects.

    private void btnBrowse_Click(object sender, System.EventArgs e) 
	{	

            odlgAttachment.InitialDirectory = @"C:\";
            odlgAttachment.Filter = "All Files (*.*)|*.*|HTML Files (*.htm;*.html)|*.htm|Microsoft Mail Documents (*.msg)|*.msg|Word Documents (*.doc)|*.doc|Excel Files(*.xl*)|*.xl*|Excel Worksheets (*.xls)|*.xls|Excel Charts (*.xlc)|*.xlc|PowerPoint Presentations (*.ppt)|*.ppt|Text Files (*.txt)|*.txt";
            odlgAttachment.FilterIndex = 1;
            // The OpenFileDialog control only has an Open button, not an OK button.
            // However, there is no DialogResult.Open enum so use DialogResult.OK.
            if (odlgAttachment.ShowDialog() == DialogResult.OK) {
                if (arlAttachments == null) {
                    arlAttachments = new ArrayList();
                    // Clear the "(No Attachments)" default text in the ListView
                    lstAttachments.Items.Clear();
                }
                arlAttachments.Add(new MailAttachment(odlgAttachment.FileName));
                // You only want to show the file name. The OpenFileDialog.FileName
                // property contains the full path. So Split the path and reverse it
                // to grab the first string in the array, which is just the FileName.
                string[] strFileName= odlgAttachment.FileName.Split(Convert.ToChar(@"\"));
				Array.Reverse(strFileName);
                lstAttachments.Items.Add(strFileName[0]);

            }

        

    }

    // the Send button click event. This routine checks for valid email

    // addresses, builds the body of a message using stringBuilder, creates a 

    // mail message, and then attempts to send it.

    private void btnSend_Click(object sender, System.EventArgs e) 
	{
        // Perform validation on the To and From email address fields, which are

        // both required for sending an email.

        try {

            ValidateEmailAddress(txtFrom);

       } catch( Exception ex)
		{
            txtFrom.Select(0, txtFrom.Text.Length);

            // Set the ErrorProvider error with the text to display. 

            erpEmailAddresses.SetError(txtFrom, ex.Message);

            return;

        }

        try {

            ValidateEmailAddress(txtTo);

       } catch( Exception exp)
		{
            txtTo.Select(0, txtTo.Text.Length);

            // Set the ErrorProvider error with the text to display. 

            erpEmailAddresses.SetError(txtTo, exp.Message);

            return;

        }

        // Use the stringBuilder class instead of traditional string concatenation.
        // It is optimized for building strings because it is capable of modifying
        // the underlying buffer instead of having to make a copy of the string for 
        // each concatenation. Consult the SDK documentation for more information on 
        // this new class.

        StringBuilder sb = new StringBuilder();

        // Build the email message body.
        sb.Append("The following email was sent to you from the Send Mail How-To " + 
            "sample application:");
        sb.Append(Environment.NewLine);
        sb.Append(Environment.NewLine);
        sb.Append("SUBJECT: ");
        sb.Append(txtSubject.Text.Trim());
        sb.Append(Environment.NewLine);
        sb.Append(Environment.NewLine);
        sb.Append("MESSAGE: ");
        sb.Append(txtBody.Text.Trim());
        sb.Append(Environment.NewLine);

        // Creating a mail message is simple instantiating a class and 
        // setting a few properties.

        MailMessage mailMsg = new MailMessage();

            mailMsg.From = txtFrom.Text.Trim();
            mailMsg.To = txtTo.Text.Trim();
            mailMsg.Cc = txtCC.Text.Trim();
            mailMsg.Bcc = txtBCC.Text.Trim();
            mailMsg.Subject = txtSubject.Text.Trim();
            mailMsg.Body = sb.ToString();
            mailMsg.Priority = (MailPriority) cboPriority.SelectedIndex;

            if (arlAttachments != null) {

                foreach(object mailAttachment in arlAttachments)
				{
                    mailMsg.Attachments.Add(mailAttachment);

                }

            }

        

        // Set the SmtpServer name. This can be any of the following depending on
        // your local security settings:
        // a) Local IP Address (assuming your local machine's SMTP server has the 
        // right to send messages through a local firewall (if present).
        // b) 127.0.0.1 the loopback of the local machine.
        // c) "smarthost" or the name or the IP address of the exchange server you 
        // utilize for messaging. This is usually what is needed if you are behind
        // a corporate firewall.
        // See the Readme file for more information.

        SmtpMail.SmtpServer = "smarthost";

        // Use structured error handling to attempt to send the email message and 
        // provide feedback to the user about the success or failure of their 
        // attempt.

        try {
            SmtpMail.Send(mailMsg);
            lstAttachments.Items.Clear();
            lstAttachments.Items.Add("(No Attachments)");
            MessageBox.Show("Your email has been successfully sent!", 
                "Email Send Status", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
       } catch( Exception exp)
		{
            MessageBox.Show("The following problem occurred when attempting to " + 
                "send your email: " + exp.Message, 
                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }

    // the event fired when the control is validated.

    private void emailAddresses_Validated(object sender, System.EventArgs e) 
	{
        // Clear the ErrorProvider of errors.

        erpEmailAddresses.SetError((TextBox) sender, "");

    }

    // the event fired when the control starts validating. Cast the sender 
    // instead of hardcoding the ID of the TextBox (e.g., "txtFrom") undergoing 
    // validation so that a single routine can handle the validating event for 
    // more than one TextBox control.

    private void emailAddresses_Validating(object sender, System.ComponentModel.CancelEventArgs e) 
	{
        TextBox txt = (TextBox) sender;

        try {

            ValidateEmailAddress(txt);

       } catch( Exception exp)
		{
            // Cancel the event and highlight the text to be corrected by the user.

            e.Cancel = true;

            txt.Select(0, txt.Text.Length);

            // Set the ErrorProvider error with the text to display. 

            erpEmailAddresses.SetError(txt, exp.Message);

        }

    }

    // the form Load event. Checks to make sure that the SMTP Service is 
    // both installed and running.

    private void frmMain_Load(object sender, System.EventArgs e) {

        // Ensure the SMTP Service is installed.

        ServiceController[] services = ServiceController.GetServices();
        bool blnHasSmtpService = false;
		ServiceController smtpServ = null;
		frmStatus frmStatusMessage = null;

        // Loop through all the services on the machine and find the SMTP Service.

        foreach(ServiceController service in services)
		{
            if (service.ServiceName.ToLower() == "smtpsvc") 
			{
                blnHasSmtpService = true;
				smtpServ = service;
                break;
            }

        }

        if (!blnHasSmtpService) {
            MessageBox.Show("You do not have SMTP Service installed on this " + 
                "machine. Please check the Readme file for information on how " + 
                "to install SMTP Service.", this.Text, 
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        // Ensure the SMTP Service is running. if not, start it.
		if (smtpServ != null)
		{
			if (smtpServ.Status != ServiceControllerStatus.Running) 
			{
				frmStatusMessage = new frmStatus();
				frmStatusMessage.Show("SMTP Service not currently running. " + 
					"Starting service...");
			}
			try 
			{

				smtpServ.Start();

				frmStatusMessage.Close();

			} 
			catch 
			{
				MessageBox.Show("There was an error when attempting " + 
					"to start SMTP Service. Please consult the Readme " + 
					"file for more information.", this.Text, 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        // Fill the Priority ComboBox with the MailPriority values

            cboPriority.Items.AddRange(new string[] {"Normal", "Low", "High"});
            cboPriority.SelectedIndex = 0;

    }

}

