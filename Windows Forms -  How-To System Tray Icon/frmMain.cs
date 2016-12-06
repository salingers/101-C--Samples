//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;

public class frmMain: System.Windows.Forms.Form 
{
	#region " Windows Form Designer generated code "
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
		this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing) 
	{
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
	private System.Windows.Forms.MainMenu mnuMain;

	private System.Windows.Forms.MenuItem mnuFile;

	private System.Windows.Forms.MenuItem mnuExit;

	private System.Windows.Forms.MenuItem mnuHelp;

	private System.Windows.Forms.MenuItem mnuAbout;

    private System.Windows.Forms.MenuItem mnuCurrentTimeZone;

    private System.Windows.Forms.MenuItem mnuTimeSinceReboot;

    private System.Windows.Forms.MenuItem mnuFrameworkVersion;

    private System.Windows.Forms.MenuItem mnuCurrentOSVersion;

    private System.Windows.Forms.MenuItem mnuExitApp;

    private System.Windows.Forms.MenuItem mnuCurrentDate;

    private System.Windows.Forms.ContextMenu mnuCtx;

    private System.Windows.Forms.NotifyIcon ntfSystemInfo;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Button btnTray;

    private void InitializeComponent() 
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuHelp = new System.Windows.Forms.MenuItem();
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.ntfSystemInfo = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuCtx = new System.Windows.Forms.ContextMenu();
            this.mnuCurrentDate = new System.Windows.Forms.MenuItem();
            this.mnuCurrentTimeZone = new System.Windows.Forms.MenuItem();
            this.mnuTimeSinceReboot = new System.Windows.Forms.MenuItem();
            this.mnuFrameworkVersion = new System.Windows.Forms.MenuItem();
            this.mnuCurrentOSVersion = new System.Windows.Forms.MenuItem();
            this.mnuExitApp = new System.Windows.Forms.MenuItem();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnTray = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.mnuHelp});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuExit});
            resources.ApplyResources(this.mnuFile, "mnuFile");
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 0;
            resources.ApplyResources(this.mnuExit, "mnuExit");
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Index = 1;
            this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAbout});
            resources.ApplyResources(this.mnuHelp, "mnuHelp");
            // 
            // mnuAbout
            // 
            this.mnuAbout.Index = 0;
            resources.ApplyResources(this.mnuAbout, "mnuAbout");
            // 
            // ntfSystemInfo
            // 
            this.ntfSystemInfo.ContextMenu = this.mnuCtx;
            resources.ApplyResources(this.ntfSystemInfo, "ntfSystemInfo");
            this.ntfSystemInfo.DoubleClick += new System.EventHandler(this.ntfSystemInfo_DoubleClick);
            // 
            // mnuCtx
            // 
            this.mnuCtx.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuCurrentDate,
            this.mnuCurrentTimeZone,
            this.mnuTimeSinceReboot,
            this.mnuFrameworkVersion,
            this.mnuCurrentOSVersion,
            this.mnuExitApp});
            // 
            // mnuCurrentDate
            // 
            this.mnuCurrentDate.Index = 0;
            resources.ApplyResources(this.mnuCurrentDate, "mnuCurrentDate");
            this.mnuCurrentDate.Click += new System.EventHandler(this.mnuCurrentDate_Click);
            // 
            // mnuCurrentTimeZone
            // 
            this.mnuCurrentTimeZone.Index = 1;
            resources.ApplyResources(this.mnuCurrentTimeZone, "mnuCurrentTimeZone");
            this.mnuCurrentTimeZone.Click += new System.EventHandler(this.mnuCurrentTimeZone_Click);
            // 
            // mnuTimeSinceReboot
            // 
            this.mnuTimeSinceReboot.Index = 2;
            resources.ApplyResources(this.mnuTimeSinceReboot, "mnuTimeSinceReboot");
            this.mnuTimeSinceReboot.Click += new System.EventHandler(this.mnuTimeSinceReboot_Click);
            // 
            // mnuFrameworkVersion
            // 
            this.mnuFrameworkVersion.Index = 3;
            resources.ApplyResources(this.mnuFrameworkVersion, "mnuFrameworkVersion");
            this.mnuFrameworkVersion.Click += new System.EventHandler(this.mnuFrameworkVersion_Click);
            // 
            // mnuCurrentOSVersion
            // 
            this.mnuCurrentOSVersion.Index = 4;
            resources.ApplyResources(this.mnuCurrentOSVersion, "mnuCurrentOSVersion");
            this.mnuCurrentOSVersion.Click += new System.EventHandler(this.mnuCurrentOSVersion_Click);
            // 
            // mnuExitApp
            // 
            this.mnuExitApp.Index = 5;
            resources.ApplyResources(this.mnuExitApp, "mnuExitApp");
            this.mnuExitApp.Click += new System.EventHandler(this.mnuExitApp_Click);
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // btnTray
            // 
            resources.ApplyResources(this.btnTray, "btnTray");
            this.btnTray.Name = "btnTray";
            this.btnTray.Click += new System.EventHandler(this.btnTray_Click);
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnTray);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Menu = this.mnuMain;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

    }
	#endregion

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Standard Menu Code "
	// This code will close the form.
	private void mnuExit_Click(object sender, System.EventArgs e) 
	{
		// Close the current form
        Shutdown();
	}
#endregion

    private void btnExit_Click(object sender, System.EventArgs e)
	{
        Shutdown();
    }

    private void btnTray_Click(object sender, System.EventArgs e)
	{
        // Hide the main form, as a program running as a tray icon doesn't typically 
        // have a visible form.
        this.Hide();
        ntfSystemInfo.Visible = true;
        ntfSystemInfo.Text = "System Information";
    }

	private void frmMain_Load(object sender, System.EventArgs e) 
	{
        // Make sure that the tray icon doesn't appear until the user clicks Start.
        // Otherwise the tray icon will be visible at the same time as the main form.
        ntfSystemInfo.Visible = false;
    }

    private void mnuCurrentOSVersion_Click(object sender, System.EventArgs e) 
	{
        // Grab the OS Information.  Outputs the Build, Major, Minor, and Revision 
        // Information() for the current OS.  This information can also be accessed 
        // individually via properties.  Eliminates the need to make API calls for 
        // some of this information.
        MessageBox.Show("OS Version: " + Environment.OSVersion.ToString(), "Operating System", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void mnuCurrentDate_Click(object sender, System.EventArgs e) 
	{
        // Displays the current Date.
        MessageBox.Show("Today's Date is: " + DateTime.Now.ToLongDateString(), "Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void mnuCurrentTimeZone_Click(object sender, System.EventArgs e) 
	{
        // Using the TimeZone class display the name of the user's current timezone.  
        // The(Time Zone) class can also be used to determine if the user's location 
        // is currently using daylight savings time as well as the time that daylight 
        // savings time is active for a given time zone.

		if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(DateTime.Now)) 
		{
			MessageBox.Show("The current time zone is: " + TimeZone.CurrentTimeZone.DaylightName, "Time Zone", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		else 
		{
			MessageBox.Show("The current time zone is: " + TimeZone.CurrentTimeZone.StandardName, "Time Zone", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
    }

    private void mnuExitApp_Click(object sender, System.EventArgs e)
	{
        Shutdown();
    }

    private void mnuFrameworkVersion_Click(object sender, System.EventArgs e) 
	{
        // Grab the current .NET Framework Version.  Outputs the Build, Major, 
        // Minor information. This information can also be accessed individually 
        // by properties.
        MessageBox.Show("Framework Version: " + Environment.Version.ToString(), ".NET Framework Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
	}

    private void mnuTimeSinceReboot_Click(object sender, System.EventArgs e)
	{
        // Displays the amount of time that the machine has been up since last being rebooted.
        // The time retrieved from TickCount is in Milliseconds.  This is converted to minutes.
        double timeSinceLastRebootMinutes = ((Environment.TickCount / 1000) / 60);

        MessageBox.Show("It has been : " + timeSinceLastRebootMinutes.ToString() + " minutes since your last reboot.", "Last Reboot", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ntfSystemInfo_DoubleClick(object sender, System.EventArgs e)
	{
        // When the user double-clicks the tray icon, display the main form again.
        // Also, make the tray icon disappear while the form is visible.
        ntfSystemInfo.Visible = false;
        this.Show();
    }

    protected void Shutdown()
	{
		// It's a good idea to make the system tray icon invisible before ending
        // the application, otherwise, it can linger in the tray when the application
        // is no longer running.

        ntfSystemInfo.Visible = false;
        Application.Exit();
    }
}