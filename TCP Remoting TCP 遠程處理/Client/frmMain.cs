//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Runtime.Remoting;
using RemotingSample;

public class frmMain : System.Windows.Forms.Form
{

#region " Windows Form Designer generated code "

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

	public frmMain() 
	{
		//This call is required by the Windows Form Designer.
		InitializeComponent();
		//Add any initialization after the InitializeComponent() call
		// So that we only need to set the title of the application once,
		// we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
		// to read the AssemblyTitle attribute.
		AssemblyInfo ainfo = new AssemblyInfo();
		this.Text = ainfo.Title;
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

	private System.Windows.Forms.Button cmdClear;

	private System.Windows.Forms.ListBox lstResponses;

	private System.Windows.Forms.Button cmdCreate;

	private System.Windows.Forms.Button cmdGet;

	private System.Windows.Forms.Button cmdUpdate;

	private System.Windows.Forms.Button cmdRelease;

	private System.Windows.Forms.Button cmdDebugData;

	private System.Windows.Forms.GroupBox gbInputData;

	private System.Windows.Forms.TextBox txtnewAge;

	private System.Windows.Forms.TextBox txtnewName;

	private System.Windows.Forms.Label Label1;

	private System.Windows.Forms.Label Label2;

	private System.Windows.Forms.Label lblDefAgeValue;

	private System.Windows.Forms.Label lblDefNameValue;

	private System.Windows.Forms.Label lblDefAge;

	private System.Windows.Forms.Label lblDefName;

	private System.Windows.Forms.Button cmdUpdateAndGet;

	private System.Windows.Forms.GroupBox gbTwo;

	private System.Windows.Forms.RadioButton rbClient;

	private System.Windows.Forms.RadioButton rbSingle;

	private System.Windows.Forms.GroupBox gbSingle;

	private System.Windows.Forms.Button cmdSingleDebug;

	private System.Windows.Forms.Button cmdSingleCall;

	private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cmdClear = new System.Windows.Forms.Button();
            this.lstResponses = new System.Windows.Forms.ListBox();
            this.gbTwo = new System.Windows.Forms.GroupBox();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.cmdUpdateAndGet = new System.Windows.Forms.Button();
            this.cmdDebugData = new System.Windows.Forms.Button();
            this.cmdRelease = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdGet = new System.Windows.Forms.Button();
            this.cmdCreate = new System.Windows.Forms.Button();
            this.gbInputData = new System.Windows.Forms.GroupBox();
            this.txtnewName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblDefAgeValue = new System.Windows.Forms.Label();
            this.lblDefNameValue = new System.Windows.Forms.Label();
            this.lblDefAge = new System.Windows.Forms.Label();
            this.lblDefName = new System.Windows.Forms.Label();
            this.txtnewAge = new System.Windows.Forms.TextBox();
            this.gbSingle = new System.Windows.Forms.GroupBox();
            this.cmdSingleDebug = new System.Windows.Forms.Button();
            this.cmdSingleCall = new System.Windows.Forms.Button();
            this.gbTwo.SuspendLayout();
            this.gbInputData.SuspendLayout();
            this.gbSingle.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClear
            // 
            resources.ApplyResources(this.cmdClear, "cmdClear");
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // lstResponses
            // 
            resources.ApplyResources(this.lstResponses, "lstResponses");
            this.lstResponses.Name = "lstResponses";
            // 
            // gbTwo
            // 
            this.gbTwo.Controls.Add(this.rbSingle);
            this.gbTwo.Controls.Add(this.rbClient);
            this.gbTwo.Controls.Add(this.cmdUpdateAndGet);
            this.gbTwo.Controls.Add(this.cmdDebugData);
            this.gbTwo.Controls.Add(this.cmdRelease);
            this.gbTwo.Controls.Add(this.cmdUpdate);
            this.gbTwo.Controls.Add(this.cmdGet);
            this.gbTwo.Controls.Add(this.cmdCreate);
            resources.ApplyResources(this.gbTwo, "gbTwo");
            this.gbTwo.Name = "gbTwo";
            this.gbTwo.TabStop = false;
            // 
            // rbSingle
            // 
            resources.ApplyResources(this.rbSingle, "rbSingle");
            this.rbSingle.Name = "rbSingle";
            // 
            // rbClient
            // 
            this.rbClient.Checked = true;
            resources.ApplyResources(this.rbClient, "rbClient");
            this.rbClient.Name = "rbClient";
            this.rbClient.TabStop = true;
            // 
            // cmdUpdateAndGet
            // 
            resources.ApplyResources(this.cmdUpdateAndGet, "cmdUpdateAndGet");
            this.cmdUpdateAndGet.Name = "cmdUpdateAndGet";
            this.cmdUpdateAndGet.Click += new System.EventHandler(this.cmdUpdateAndGet_Click);
            // 
            // cmdDebugData
            // 
            resources.ApplyResources(this.cmdDebugData, "cmdDebugData");
            this.cmdDebugData.Name = "cmdDebugData";
            this.cmdDebugData.Click += new System.EventHandler(this.cmdDebugData_Click);
            // 
            // cmdRelease
            // 
            resources.ApplyResources(this.cmdRelease, "cmdRelease");
            this.cmdRelease.Name = "cmdRelease";
            this.cmdRelease.Click += new System.EventHandler(this.cmdRelease_Click);
            // 
            // cmdUpdate
            // 
            resources.ApplyResources(this.cmdUpdate, "cmdUpdate");
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdGet
            // 
            resources.ApplyResources(this.cmdGet, "cmdGet");
            this.cmdGet.Name = "cmdGet";
            this.cmdGet.Click += new System.EventHandler(this.cmdGet_Click);
            // 
            // cmdCreate
            // 
            resources.ApplyResources(this.cmdCreate, "cmdCreate");
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Click += new System.EventHandler(this.cmdCreate_Click);
            // 
            // gbInputData
            // 
            this.gbInputData.Controls.Add(this.txtnewName);
            this.gbInputData.Controls.Add(this.Label1);
            this.gbInputData.Controls.Add(this.Label2);
            this.gbInputData.Controls.Add(this.lblDefAgeValue);
            this.gbInputData.Controls.Add(this.lblDefNameValue);
            this.gbInputData.Controls.Add(this.lblDefAge);
            this.gbInputData.Controls.Add(this.lblDefName);
            this.gbInputData.Controls.Add(this.txtnewAge);
            resources.ApplyResources(this.gbInputData, "gbInputData");
            this.gbInputData.Name = "gbInputData";
            this.gbInputData.TabStop = false;
            // 
            // txtnewName
            // 
            resources.ApplyResources(this.txtnewName, "txtnewName");
            this.txtnewName.Name = "txtnewName";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // lblDefAgeValue
            // 
            resources.ApplyResources(this.lblDefAgeValue, "lblDefAgeValue");
            this.lblDefAgeValue.Name = "lblDefAgeValue";
            // 
            // lblDefNameValue
            // 
            resources.ApplyResources(this.lblDefNameValue, "lblDefNameValue");
            this.lblDefNameValue.Name = "lblDefNameValue";
            // 
            // lblDefAge
            // 
            resources.ApplyResources(this.lblDefAge, "lblDefAge");
            this.lblDefAge.Name = "lblDefAge";
            // 
            // lblDefName
            // 
            resources.ApplyResources(this.lblDefName, "lblDefName");
            this.lblDefName.Name = "lblDefName";
            // 
            // txtnewAge
            // 
            resources.ApplyResources(this.txtnewAge, "txtnewAge");
            this.txtnewAge.Name = "txtnewAge";
            this.txtnewAge.Validating += new System.ComponentModel.CancelEventHandler(this.txtnewAge_Validating);
            // 
            // gbSingle
            // 
            this.gbSingle.Controls.Add(this.cmdSingleDebug);
            this.gbSingle.Controls.Add(this.cmdSingleCall);
            resources.ApplyResources(this.gbSingle, "gbSingle");
            this.gbSingle.Name = "gbSingle";
            this.gbSingle.TabStop = false;
            // 
            // cmdSingleDebug
            // 
            resources.ApplyResources(this.cmdSingleDebug, "cmdSingleDebug");
            this.cmdSingleDebug.Name = "cmdSingleDebug";
            this.cmdSingleDebug.Click += new System.EventHandler(this.cmdSingleDebug_Click);
            // 
            // cmdSingleCall
            // 
            resources.ApplyResources(this.cmdSingleCall, "cmdSingleCall");
            this.cmdSingleCall.Name = "cmdSingleCall";
            this.cmdSingleCall.Click += new System.EventHandler(this.cmdSingleCall_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbSingle);
            this.Controls.Add(this.gbInputData);
            this.Controls.Add(this.gbTwo);
            this.Controls.Add(this.lstResponses);
            this.Controls.Add(this.cmdClear);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Closed += new System.EventHandler(this.frmMain_Closed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbTwo.ResumeLayout(false);
            this.gbInputData.ResumeLayout(false);
            this.gbInputData.PerformLayout();
            this.gbSingle.ResumeLayout(false);
            this.ResumeLayout(false);

	}

#endregion

#region " Standard Menu Code "



	// This code will close the form.
	private void mnuExit_Click(object sender, System.EventArgs e) {
		// Close the current form
		this.Close();
	}

#endregion

	// To be used to obtain a reference to a Client Activated type
	// This is similar to DCOM style programming.
	private Customer mCustomer;
	// This is to be used when we want multiple clients to connect
	// to the same object instance on the server
	private SingletonCustomer mSCustomer;


    private void frmMain_Closed(object sender, System.EventArgs e) //base.Closed;
    {
        // Let go of any objects we may still be holding on to
        if (mCustomer != null)
        {
            mCustomer = null;
        }
    }

    private void frmMain_Load(object sender, System.EventArgs e)
    {
        //Read in the application configuration file (client.exe.config).  This file has the remoting configuration
        //information for the client side remoting infrastructure.
        try
        {
            // This assumes the file is in the same directory this exe.
            RemotingConfiguration.Configure("client.exe.config");
        }
        catch (Exception exp)
        {
            // Will catch any generic exception
            string txt;
            txt = "I was unable to load the file config.xml." + Environment.NewLine +
            "Please make sure it is located in the same directory this exe " +
            " and that it is in the correct format." + Environment.NewLine +
            "Please see the Help, About box for the location of this exe." + Environment.NewLine + Environment.NewLine +
            "Detailed Error Information below:" + Environment.NewLine + Environment.NewLine +
            "  Message: " + exp.Message + Environment.NewLine +
            "  Source: " + exp.Source + Environment.NewLine + Environment.NewLine +
            "  Stack Trace:" + Environment.NewLine +
            exp.StackTrace;
            MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            // turn of the create command buttons
            this.cmdCreate.Enabled = false;
        }
    }

    private void SetCtlState(bool newState)
    {
        // Ensable the create command button
        this.cmdCreate.Enabled = newState;
        // Disable other command buttons
        this.cmdGet.Enabled = (!newState);
        this.cmdUpdate.Enabled = (!newState);
        this.cmdUpdateAndGet.Enabled = (!newState);
        this.cmdDebugData.Enabled = (!newState);
        this.cmdRelease.Enabled = (!newState);
        // Set the radio buttons
        this.rbClient.Enabled = newState;
        this.rbSingle.Enabled = newState;
    }



	private void cmdCreate_Click(object sender, System.EventArgs e) 
	{
		string txt;		  //' Used in the catch handlers;

		try 
		{
			bool objNotCreated = false;

			if (this.rbClient.Checked == true)
			{
				// Use Client Activated Type
				// Notice that in this call to new you can pass parameters to the constructor
				// This type of object is very similar to a DCOM style object.
				mCustomer = new Customer(this.lblDefNameValue.Text, Convert.ToByte(this.lblDefAgeValue.Text));
				objNotCreated = (mCustomer == null);
			}
			else 
			{
				// Use Server Activated Type
				// Notice that you can not pass values to a constructor in this case.
				// this is becuase the server creates the instance and makes it available 
				// to all a singleton.  All we are doing is obtaining a reference to
				// the running instance via a proxy.
				object[] args = null;
				mSCustomer = (RemotingSample.SingletonCustomer) (Activator.CreateInstance(typeof(RemotingSample.SingletonCustomer), args));
				mSCustomer.newClient();
				objNotCreated = (mSCustomer == null);
			}
			// Change the command buttons state
			SetCtlState(objNotCreated);
		}
		catch (RemotingException exp)
		{
			// Will catch any generic Remoting exception
			txt = "I was unable to access the remote customer object." + Environment.NewLine + 
				"Detailed Error Information below:" + Environment.NewLine + 
				"  Message: " + exp.Message + Environment.NewLine + 
				"  Source: " + exp.Source + Environment.NewLine +
                "  Stack Trace:" + exp.StackTrace + Environment.NewLine ;
			MessageBox.Show(txt, "Remoting Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
		catch (System.Net.Sockets.SocketException exp)
		{
			// This will catch any Sockets exceptions.
			// This can be caused since we're using the binary
			// remoting interface which uses Sockets.
			txt = "I was unable to access the remote customer object." + Environment.NewLine + 
				"Is it possible the server is not running?" + Environment.NewLine + 
				"Detailed Error Information below:" + Environment.NewLine +  
				"  Message: " + exp.Message + Environment.NewLine + 
				"  Source: " + exp.Source + Environment.NewLine + 
				"  Error Code: " + exp.ErrorCode.ToString() + Environment.NewLine + 
				"  Native Error Code: " + exp.NativeErrorCode.ToString() + Environment.NewLine +
                "  Stack Trace:" + exp.StackTrace + Environment.NewLine ;
			MessageBox.Show(txt, "Socket Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
		catch (Exception exp) 
		{
			// Will catch any generic exception
            txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine +
            "Detailed Error Information below:" + Environment.NewLine + Environment.NewLine +
            "  Message: " + exp.Message + Environment.NewLine +
            "  Source: " + exp.Source + Environment.NewLine + Environment.NewLine +
            "  Stack Trace:" + exp.StackTrace + Environment.NewLine;
			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}

	private void cmdGet_Click(object sender, System.EventArgs e) 
	{
		// Ask the server for the customer data 
		try 
		{

			if (this.rbClient.Checked == true)
			{
				this.lstResponses.Items.Add(mCustomer.GetCustomerInfo());
			}
			else 
			{
				this.lstResponses.Items.Add(mSCustomer.GetCustomerInfo());
			}
		}
		catch (Exception exp) 
		{
			// Will catch any generic exception
			// See the code in cmdCreate for more detailed examples.
			string txt;
			txt = "I was unable to access the remote customer object." + Environment.NewLine + 
			"Detailed Error Information below:" + Environment.NewLine + 
			"  Message: " + exp.Message + Environment.NewLine + 
			"  Source: " + exp.Source + Environment.NewLine + 
			"  Stack Trace:" + exp.StackTrace + Environment.NewLine;
			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}

	private void cmdUpdate_Click(object sender, System.EventArgs e) 
	{
		// Update the values on the server using public properties.
		// Might not be the most effcient way to update data (esp. if you want a return value).
		// See cmdUpdateAndget {for another example.
		if (( mCustomer != null) || ( mSCustomer != null)) 
		{
			try 
			{
				if (this.rbClient.Checked == true)
				{
					mCustomer.Name = this.txtnewName.Text;
					mCustomer.Age = Convert.ToByte(this.txtnewAge.Text);
				}
				else 
				{
					mSCustomer.Name = this.txtnewName.Text;
					mSCustomer.Age = Convert.ToByte(this.txtnewAge.Text);
				}
				this.lstResponses.Items.Add("Update using properties successful!");
			}
			catch (Exception exp) 
			{
				// Will catch any generic exception
				// See the code in cmdCreate for more detailed examples.
				string txt;
				txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine + 
				"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
				"  Message: " + exp.Message + Environment.NewLine + 
				"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
				"  Stack Trace:" + Environment.NewLine + 
				exp.StackTrace;
				MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}
	}

	private void cmdUpdateAndGet_Click(object sender, System.EventArgs e) 
	{
		// Update the values on the server using a function that accepts both values
		// and get the return data of the Client Activated type.
		// This is generally a better format the code in cmdUpdate since it
		// gets more work done in fewer round-trips.

		if (( mCustomer != null) || ( mSCustomer != null)) 
		{
			try 
			{
				if (this.rbClient.Checked == true)
				{
					this.lstResponses.Items.Add(mCustomer.UpdateCustomerInfo(this.txtnewName.Text, Convert.ToByte(this.txtnewAge.Text)));
				}
				else 
				{
					this.lstResponses.Items.Add(mSCustomer.UpdateCustomerInfo(this.txtnewName.Text, Convert.ToByte(this.txtnewAge.Text)));
				}
			}
			catch (Exception exp) 
			{
				// Will catch any generic exception
				// See the code in cmdCreate for more detailed examples.
				string txt;
				txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine +
				"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
				"  Message: " + exp.Message + Environment.NewLine + 
				"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
				"  Stack Trace:" + Environment.NewLine + 
				exp.StackTrace;
				MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}
	}

    private void cmdDebugData_Click(object sender, System.EventArgs e)
    {
        // Get debug data from the Client Activated type
        if ((mCustomer != null) || (mSCustomer != null))
        {
            try
            {
                if (this.rbClient.Checked == true)
                {
                    this.lstResponses.Items.Add("Debug data follows:");
                    this.lstResponses.Items.Add(string.Format("  Creation Time: {0}", mCustomer.DebugCreationTime.ToString()));
                    this.lstResponses.Items.Add(string.Format("  Code Base: {0}", mCustomer.DebugCodeBase));
                    this.lstResponses.Items.Add(string.Format("  Fully Qualified Name: {0}", mCustomer.DebugFQName));
                    this.lstResponses.Items.Add(string.Format("  Remote Host Name: {0}", mCustomer.DebugHostName));
                    this.lstResponses.Items.Add("End Debug Data");
                }
                else
                {
                    this.lstResponses.Items.Add("Debug data follows:");
                    this.lstResponses.Items.Add(string.Format("  Creation Time: {0}", mSCustomer.DebugCreationTime.ToString()));
                    this.lstResponses.Items.Add(string.Format("  Code Base: {0}", mSCustomer.DebugCodeBase));
                    this.lstResponses.Items.Add(string.Format("  Fully Qualified Name: {0}", mSCustomer.DebugFQName));
                    this.lstResponses.Items.Add(string.Format("  Remote Host Name: {0}", mSCustomer.DebugHostName));
                    this.lstResponses.Items.Add(string.Format("  Number of connected clients: {0}", mSCustomer.Connected.ToString()));
                    this.lstResponses.Items.Add("End Debug Data");
                }
            }
            catch (Exception exp)
            {
                // Will catch any generic exception
                // See the code in cmdCreate for more detailed examples.
                string txt;
                txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine +
                "Detailed Error Information below:" + Environment.NewLine + Environment.NewLine +
                "  Message: " + exp.Message + Environment.NewLine +
                "  Source: " + exp.Source + Environment.NewLine + Environment.NewLine +
                "  Stack Trace:" + Environment.NewLine +
                exp.StackTrace;
                MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }

	private void cmdRelease_Click(object sender, System.EventArgs e) 
	{
		// Release our reference to the server object
		if (( mCustomer != null) || ( mSCustomer != null)) 
		{
			bool objReleased = false;

			if (rbClient.Checked == true)
			{
				// Let go of the proxy reference
				mCustomer = null;
				objReleased = (mCustomer == null);
			}
			else 
			{
				// Since the object exposes the method, we should call it.
				// In our example it doesn't do anything fancy. It simply
				// lowers the connected count.
				
				mSCustomer = null;
				objReleased = (mSCustomer == null);
			}
			// Change the command buttons state
			SetCtlState(objReleased);
		}
	}


	private void cmdSingleCall_Click(object sender, System.EventArgs e) 
	{
		// SingleCall objects only live for the life of one method call.
		// while the properties exist, they can only be used when the object is not
		// being used in SingleCall mode.
		// This model is very similar to a correct MTS/COM+ component implementation.
		// Even though we're not providing arguments, we must pass
		// array defined object. null won't work.
		object[] args = null;
		SingleCallCustomer cust;

		try 
		{
			cust = (RemotingSample.SingleCallCustomer) (Activator.CreateInstance(typeof(RemotingSample.SingleCallCustomer), args));
			this.lstResponses.Items.Add("SingleCall.UpdateCustomerInfo: " + cust.UpdateCustomerInfo(this.txtnewName.Text, Convert.ToByte(this.txtnewAge.Text)));
			this.lstResponses.Items.Add("Update Successful!");
		}
		catch (Exception exp) 
		{
			// Will catch any generic exception
			// See the code in cmdCreate for more detailed examples.
			string txt;
			txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine +
			"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
			"  Message: " + exp.Message + Environment.NewLine + 
			"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
			"  Stack Trace:" + Environment.NewLine + 
			exp.StackTrace;
			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}

	private void cmdSingleDebug_Click(object sender, System.EventArgs e) 
	{
		// SingleCall objects only live for the life of one method call.
		// Each time we go and get debug data, we're getting it from a 
		// new instance of the object.
		// Even though we're not providing arguments, we must pass
		// array defined object. null won't work.
		object[] args = null;
		SingleCallCustomer scCust;
		try 
		{
			scCust = (RemotingSample.SingleCallCustomer) (Activator.CreateInstance(typeof(RemotingSample.SingleCallCustomer), args));
			this.lstResponses.Items.Add("Debug data follows:");
			this.lstResponses.Items.Add(string.Format("  Creation Time: {0}", scCust.DebugCreationTime.ToString()));
			this.lstResponses.Items.Add(string.Format("  Code Base: {0}", scCust.DebugCodeBase));
			this.lstResponses.Items.Add(string.Format("  Fully Qualified Name: {0}", scCust.DebugFQName));
			this.lstResponses.Items.Add(string.Format("  Remote Host Name: {0}", scCust.DebugHostName));
			// Notice how the creation time is different!
			this.lstResponses.Items.Add(string.Format("  Creation Time: {0}", scCust.DebugCreationTime.ToString()));
			this.lstResponses.Items.Add("End Debug Data");
		}
		catch (Exception exp) 
		{
			// Will catch any generic exception
			// See the code in cmdCreate for more detailed examples.
			string txt;
			txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine + 
			"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
			"  Message: " + exp.Message + Environment.NewLine + 
			"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
			"  Stack Trace:" + Environment.NewLine + 
			exp.StackTrace;
			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}



	private void txtnewAge_Validating(object sender, System.ComponentModel.CancelEventArgs e) 
	{
		// Check to make sure only numeric values are entered
		// and check to see if the datatype is a byte
		try 
		{
			byte d = Convert.ToByte(this.txtnewAge.Text);
		}
		catch (Exception exp) 
		{
			string txt;
			txt = "The value you entered, '{0}', for the Customer's new Age is incorrect." + Environment.NewLine + 
			"Please enter a value in the range of 0 to 255." + Environment.NewLine + 
			"The value will be reset to 0 by default.";
			MessageBox.Show(string.Format(txt, this.txtnewAge.Text), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			// Set the default value to 0 and cancel the field exit.
			this.txtnewAge.Text = "0";
			e.Cancel = true;
		}
	}

    private void cmdClear_Click(object sender, System.EventArgs e)
    {
        //clear all items from the listbox
        this.lstResponses.Items.Clear();
    }
}

